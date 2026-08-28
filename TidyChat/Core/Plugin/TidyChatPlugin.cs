global using Dalamud.Bindings.ImGui;
using Dalamud.Game.Gui.Dtr;
using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using System.Threading;
using System.Threading.Tasks;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat;

public sealed partial class TidyChatPlugin : IAsyncDalamudPlugin
{
    private const string SettingsCommand = TidyStrings.SettingsCommand;
    private const string ShorthandCommand = TidyStrings.ShorthandCommand;

    private const int MaxLogMessageSetSize = 1000;
    private const int MaxSetPlayerNameRetries = 10;
    private const int ServerAnnouncementLoginGraceSeconds = 20;
    private const string EchoPassthroughRuleName = "Echo passthrough";

    private readonly HashSet<string> _allowedByLogMessage = new(StringComparer.OrdinalIgnoreCase);

    private readonly HashSet<string> _blockedByLogMessage = new(StringComparer.OrdinalIgnoreCase);

    private readonly Dictionary<string, string> _logMessageBlockRuleByText =
        new(StringComparer.OrdinalIgnoreCase);

    private readonly Queue<(string Message, long ExpiresAtTicks)> _chatHistory = new();
    private readonly Lock _chatHistoryLock = new();

    private readonly HashSet<uint> _loggedUnmatchedLogMessageIds = [];
    private readonly Lock _logMessageLock = new();

    private readonly Dictionary<uint, int> _pendingAllowedLogMessageIds = [];
    private readonly Dictionary<uint, int> _pendingBlockedLogMessageIds = [];
    private readonly Dictionary<uint, int> _pendingCustomFilterLogMessageIds = [];
    private readonly WindowSystem _windowSystem = new("TidyChat");

    private byte _lastTerritoryExclusiveType;
    private bool _commendationBaselineSynced;
    private bool _configInitialized;

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
    [PluginService] public static IFramework Framework { get; set; } = null!;
    private static IDtrBarEntry? DtrEntry { get; set; }

    public static IReadOnlyList<TomestoneInfo> Tomestones { get; private set; } = [];
    public static IReadOnlyList<TomestoneInfo> TribalCurrencies { get; private set; } = [];

    public static IReadOnlySet<string> FishingFlavorMessages { get; private set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    private Configuration Configuration { get; set; } = null!;
    private PluginUI? PluginUi { get; set; }

    public ValueTask DisposeAsync()
    {
        Instance = null;
        if (_configInitialized)
        {
            FlushBlockedMessageCount(persist: true);
            Configuration.PersistIfDirty();
        }

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

        try { CommandManager.RemoveHandler(SettingsCommand); }
        catch (Exception ex) { Log.Warning("Failed to remove settings command on dispose: " + ex); }
        try { CommandManager.RemoveHandler(ShorthandCommand); }
        catch (Exception ex) { Log.Warning("Failed to remove shorthand command on dispose: " + ex); }
        PluginInterface.LanguageChanged -= UpdateLang;
        ChatGui.CheckMessageHandled -= OnChat;
        ChatGui.LogMessage -= OnLogMessage;
        ClientState.TerritoryChanged -= OnTerritoryChanged;
        ClientState.Login -= OnLogin;
        ClientState.Logout -= OnLogout;
        DisposeLogMessageDebugDedup();
        return ValueTask.CompletedTask;
    }
    private void OnCommand(string command, string args)
    {
        switch (TidyChatCommandParser.Parse(args, out var debugEnabled))
        {
            case TidyChatCommandParser.ActionKind.OpenSettings:
                OpenPluginUi();
                return;
            case TidyChatCommandParser.ActionKind.ToggleDebug:
                SetDebugMode(!Configuration.EnableDebugMode);
                return;
            case TidyChatCommandParser.ActionKind.SetDebug:
                SetDebugMode(debugEnabled);
                return;
            case TidyChatCommandParser.ActionKind.ShowUsage:
            default:
                PrintCommandFeedback(TidyStrings.CommandUsage);
                return;
        }
    }

    private void SetDebugMode(bool enabled)
    {
        if (Configuration.EnableDebugMode == enabled)
        {
            PrintCommandFeedback(L10N.GetTidy(enabled
                ? TidyStrings.DebugModeEnabled
                : TidyStrings.DebugModeDisabled));
            return;
        }

        Configuration.EnableDebugMode = enabled;
        Configuration.Save();
        if (!enabled)
        {
            FlushLogMessageDebugDedup();
        }

        PrintCommandFeedback(L10N.GetTidy(enabled
            ? TidyStrings.DebugModeEnabled
            : TidyStrings.DebugModeDisabled));
    }

    private void PrintCommandFeedback(string text)
    {
        SeStringBuilder builder = new();
        if (Configuration.IncludeChatTag)
        {
            Better.AddTidyChatTag(builder);
        }

        builder.AddText(text);
        ChatGui.Print(builder.BuiltString);
    }

    private void UpdateLang(string langCode)
    {
        Languages.Culture = new(langCode);
        PluginUi?.InvalidateLayoutCache();
    }

    private void DrawUI() => _windowSystem.Draw();

    private void DrawConfigUI() => OpenPluginUi();

    private void OpenPluginUi() => PluginUi!.IsOpen = true;

    public static TidyChatPlugin? Instance { get; private set; }

    public TidyChatPlugin() => Instance = this;

    public async Task LoadAsync(CancellationToken cancellationToken)
    {
        L10N.Language = ClientState.ClientLanguage;
        PluginInterface.LanguageChanged += UpdateLang;
        Languages.Culture = new(PluginInterface.UiLanguage);

        var loaded = PluginInterface.GetPluginConfig() as Configuration;
        Configuration = loaded ?? new Configuration();
        Configuration.Initialize(PluginInterface);
        Configuration.ApplyPendingMigrations();
        _configInitialized = true;

        Rules.UpdateIsActiveStates(Configuration);
        MigrateLegacyHighlightColors(Configuration.ChatHighlights);

        cancellationToken.ThrowIfCancellationRequested();
        ReloadGameDataCaches(validateRuleIds: true);
        cancellationToken.ThrowIfCancellationRequested();

        var needsFrameworkThread = Configuration.InstanceInDtrBar
            || (ClientState.IsLoggedIn && Configuration.BetterCommendationMessage);
        if (needsFrameworkThread)
        {
            await Framework.RunOnFrameworkThread(ApplyFrameworkThreadLoadState).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
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

    private void ApplyFrameworkThreadLoadState()
    {
        if (Configuration.InstanceInDtrBar)
        {
            InstanceDtrBarUpdate(Configuration);
        }

        if (ClientState.IsLoggedIn && Configuration.BetterCommendationMessage)
        {
            _commendationBaselineSynced = TrySyncCommendationBaseline();
            _lastTerritoryExclusiveType = TryGetTerritoryExclusiveType(ClientState.TerritoryType);
        }
    }
}
