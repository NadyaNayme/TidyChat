global using Dalamud.Bindings.ImGui;
using Dalamud.Game.Gui.Dtr;
using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using System.Threading;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat;

public sealed partial class TidyChatPlugin : IDalamudPlugin
{
    private const string SettingsCommand = TidyStrings.SettingsCommand;
    private const string ShorthandCommand = TidyStrings.ShorthandCommand;

    private const int MaxLogMessageSetSize = 1000;
    private const int MaxSetPlayerNameRetries = 10;
    private const int ServerAnnouncementLoginGraceSeconds = 20;

    private readonly HashSet<string> _allowedByLogMessage = new(StringComparer.OrdinalIgnoreCase);

    private readonly HashSet<string> _blockedByLogMessage = new(StringComparer.OrdinalIgnoreCase);

    private readonly Dictionary<string, string> _logMessageBlockRuleByText =
        new(StringComparer.OrdinalIgnoreCase);

    private readonly Queue<(string Message, long ExpiresAtTicks)> _chatHistory = new();
    private readonly Lock _chatHistoryLock = new();

    private readonly HashSet<uint> _loggedUnmatchedLogMessageIds = new();
    private readonly Lock _logMessageLock = new();

    private readonly Dictionary<uint, int> _pendingAllowedLogMessageIds = new();
    private readonly Dictionary<uint, int> _pendingBlockedLogMessageIds = new();
    private readonly Dictionary<uint, int> _pendingCustomFilterLogMessageIds = new();
    private readonly WindowSystem _windowSystem = new("TidyChat");

    private byte _lastTerritoryExclusiveType;
    private bool _commendationBaselineSynced;

    // #122: announcements inside this window after a Login event are treated as a real login
    private DateTime _serverAnnouncementLoginGraceEnd = DateTime.MinValue;

    private long _sessionBlockedMessages;
    private volatile bool _setPlayerNamePending;
    private int _setPlayerNameRetries;
    [PluginService] public static IDataManager DataManager { get; set; } = null!;
    [PluginService] public static IDtrBar DtrBar { get; set; } = null!;
    [PluginService] public static ICommandManager CommandManager { get; set; } = null!;
    [PluginService] public static IDalamudPluginInterface PluginInterface { get; set; } = null!;
    [PluginService] public static IClientState ClientState { get; set; } = null!;
    [PluginService] public static IChatGui ChatGui { get; set; } = null!;
    [PluginService] public static IObjectTable ObjectTable { get; set; } = null!;
    [PluginService] public static IPartyList PartyList { get; set; } = null!;
    [PluginService] public static IPluginLog Log { get; set; } = null!;
    private static IDtrBarEntry? DtrEntry { get; set; }

    public static IReadOnlyList<TomestoneInfo> Tomestones { get; private set; } = [];
    public static IReadOnlyList<TomestoneInfo> TribalCurrencies { get; private set; } = [];

    public static IReadOnlySet<string> FishingFlavorMessages { get; private set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    private Configuration Configuration { get; }
    private PluginUI? PluginUi { get; }

    public void Dispose()
    {
        Instance = null;
        FlushBlockedMessageCount(persist: true);
        Configuration.PersistIfDirty();

        PluginInterface.UiBuilder.Draw -= DrawUI;
        PluginInterface.UiBuilder.OpenMainUi -= DrawConfigUI;
        PluginInterface.UiBuilder.OpenConfigUi -= DrawConfigUI;
        _windowSystem.RemoveAllWindows();
        PluginUi?.Dispose();

        if (DtrEntry is not null)
        {
            try { DtrEntry.Remove(); }
            catch (Exception ex) { Log.Warning("Failed to remove DTR bar entry on dispose: " + ex); }
            DtrEntry = null;
        }

        CommandManager.RemoveHandler(SettingsCommand);
        CommandManager.RemoveHandler(ShorthandCommand);
        PluginInterface.LanguageChanged -= UpdateLang;
        ChatGui.CheckMessageHandled -= OnChat;
        ChatGui.LogMessage -= OnLogMessage;
        ClientState.TerritoryChanged -= OnTerritoryChanged;
        ClientState.Login -= OnLogin;
        ClientState.Logout -= OnLogout;
        DisposeLogMessageDebugDedup();
    }
    private void OnCommand(string command, string args)
    {
        if (PluginUi is not null)
        {
            PluginUi.IsOpen = true;
        }
    }

    private void UpdateLang(string langCode)
    {
        Languages.Culture = new(langCode);
        PluginUi?.InvalidateLayoutCache();
    }

    private void DrawUI() => _windowSystem.Draw();

    private void DrawConfigUI()
    {
        if (PluginUi is not null)
        {
            PluginUi.IsOpen = true;
        }
    }

    #region Setup

    public static TidyChatPlugin? Instance { get; private set; }

    public TidyChatPlugin()
    {
        Instance = this;
        L10N.Language = ClientState.ClientLanguage;
        LoadFishingFlavorMessages();
        PluginInterface.LanguageChanged += UpdateLang;
        Languages.Culture = new(PluginInterface.UiLanguage);

        var loaded = PluginInterface.GetPluginConfig() as Configuration;
        Configuration = loaded ?? new Configuration();
        Configuration.Initialize(PluginInterface);
        if (Configuration.Version < 12)
        {
            ConfigurationMigration.ApplyVersion12(Configuration);
            Configuration.Version = 12;
            Configuration.Save();
        }

        if (Configuration.Version < 13)
        {
            ConfigurationMigration.ApplyVersion13(Configuration);
            Configuration.Version = 13;
            Configuration.Save();
        }

        if (Configuration.Version < 14)
        {
            ConfigurationMigration.ApplyVersion14(Configuration);
            Configuration.Version = 14;
            Configuration.Save();
        }

        Rules.UpdateIsActiveStates(Configuration);

        MigrateLegacyHighlightColors(Configuration.ChatHighlights);

        ReloadGameDataCaches(validateRuleIds: true);

        if (Configuration.InstanceInDtrBar)
        {
            InstanceDtrBarUpdate(Configuration);
        }

        if (ClientState.IsLoggedIn && Configuration.BetterCommendationMessage)
        {
            _commendationBaselineSynced = TrySyncCommendationBaseline();
            _lastTerritoryExclusiveType = TryGetTerritoryExclusiveType(ClientState.TerritoryType);
        }

        ChatGui.CheckMessageHandled += OnChat;
        ChatGui.LogMessage += OnLogMessage;
        ClientState.TerritoryChanged += OnTerritoryChanged;
        ClientState.Login += OnLogin;
        ClientState.Logout += OnLogout;

        PluginUi = new(Configuration);
        _windowSystem.AddWindow(PluginUi);
        PluginUi.InvalidateLayoutCache();

        CommandManager.AddHandler(SettingsCommand, new(OnCommand)
        {
            HelpMessage = TidyStrings.SettingsHelper
        });

        CommandManager.AddHandler(ShorthandCommand, new(OnCommand)
        {
            HelpMessage = TidyStrings.ShorthandHelper
        });

        PluginInterface.UiBuilder.Draw += DrawUI;
        PluginInterface.UiBuilder.OpenMainUi += DrawConfigUI;
        PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;
    }

    #endregion Setup
}
