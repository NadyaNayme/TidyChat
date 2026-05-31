global using Dalamud.Bindings.ImGui;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Dalamud.Game.Chat;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Game.Gui.Dtr;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using Lumina.Excel.Sheets;
using Lumina.Text.ReadOnly;
using TidyChat.Localization.Resources;
using TidyChat.Translation.Data;
using Flags = TidyChat.Utility.ChatFlags;
using TidyStrings = TidyChat.Utility.InternalStrings;
using Timer = System.Timers.Timer;

namespace TidyChat;

public sealed partial class TidyChatPlugin : IDalamudPlugin
{
    private const string SettingsCommand = TidyStrings.SettingsCommand;
    private const string ShorthandCommand = TidyStrings.ShorthandCommand;

    private const int MaxLogMessageSetSize = 1000;
    private const int MaxSetPlayerNameRetries = 10;
    private const int ServerAnnouncementLoginGraceSeconds = 20;

    /// <summary>
    ///     Messages OnLogMessage already allowed. OnChat checks this set so it will not block them again.
    /// </summary>
    private readonly HashSet<string> _allowedByLogMessage = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    ///     In debug mode, messages OnLogMessage would have blocked. OnChat shows them with a [Blocked] prefix
    ///     instead of calling <see cref="IHandleableChatMessage.PreventOriginal" />.
    /// </summary>
    private readonly HashSet<string> _blockedByLogMessage = new(StringComparer.OrdinalIgnoreCase);

    private readonly Queue<(string Message, long ExpiresAtTicks)> _chatHistory = new();
    private readonly Lock _chatHistoryLock = new();

    /// <summary>LogMessage IDs logged as unmatched at most once per session (debug).</summary>
    private readonly HashSet<uint> _loggedUnmatchedLogMessageIds = new();
    private readonly Lock _logMessageLock = new();

    /// <summary>
    ///     LogMessage IDs allowed on the log path and consumed on the chat path when
    ///     <see cref="OnChat" /> runs before <see cref="OnLogMessage" />.
    /// </summary>
    private readonly Dictionary<uint, int> _pendingAllowedLogMessageIds = new();
    private readonly WindowSystem _windowSystem = new("TidyChat");

    // #122: announcements inside this window after a Login event are treated as a real login
    // (full block shown in "Login only" mode); announcements outside it are world-hops.
    private DateTime _serverAnnouncementLoginGraceEnd = DateTime.MinValue;

    private long _sessionBlockedMessages;
    volatile private bool _setPlayerNamePending;
    private int _setPlayerNameRetries;

    #region Setup

    public TidyChatPlugin()
    {
        // Player cannot change this without restarting the game so should be safe to grab here
        L10N.Language = ClientState.ClientLanguage;
        LoadFishingFlavorMessages();
        PluginInterface.LanguageChanged += UpdateLang;
        UpdateLang(PluginInterface.UiLanguage);

        var loaded = PluginInterface.GetPluginConfig() as Configuration;
        Configuration = loaded ?? new Configuration();
        Configuration.Initialize(PluginInterface);
        if (Configuration.Version < 1)
        {
            Configuration.ShowStellarMissionMessages =
                Configuration.ShowAllOtherGathering || Configuration.ShowEverythingElse;
            Configuration.ShowCosmicRewards = Configuration.ShowObtainedItems;
            Configuration.ShowCosmicDailyProgress =
                Configuration.ShowGainExperience && Configuration.ShowQuestProgress;
            Configuration.Version = 1;
            Configuration.Save();
        }

        if (Configuration.Version < 2)
        {
            Configuration.ShowCosmicExplorationMessages =
                Configuration.ShowStellarMissionMessages || Configuration.ShowAllOtherGathering;
            Configuration.Version = 2;
            Configuration.Save();
        }

        if (Configuration.Version < 3)
        {
            if (Configuration.HideObtainedShardsFromLoot)
                Configuration.HideObtainedShards = true;
            Configuration.Version = 3;
            Configuration.Save();
        }

        if (Configuration.Version < 4)
        {
            if (Configuration.HideOthersObtainFromLoot)
                Configuration.HideOthersObtain = true;
            Configuration.ShowSSRankHunt = Configuration.ShowSRankHunt || Configuration.ShowSSRankHunt;
            Configuration.ShowUserLogouts = Configuration.ShowUserLogins || Configuration.ShowUserLogouts;
            Configuration.ShowSubaquaticVoyage = Configuration.ShowExploratoryVoyage || Configuration.ShowSubaquaticVoyage;
            Configuration.ShowTradeCanceled = Configuration.ShowTradeSent || Configuration.ShowTradeCanceled;
            Configuration.ShowAwaitingTradeConfirmation = Configuration.ShowTradeSent || Configuration.ShowAwaitingTradeConfirmation;
            Configuration.ShowTradeComplete = Configuration.ShowTradeSent || Configuration.ShowTradeComplete;
            Configuration.ShowRelicBookComplete = Configuration.ShowRelicBookStep || Configuration.ShowRelicBookComplete;
            Configuration.ShowDesynthedItem = Configuration.ShowDesynthesisLevel || Configuration.ShowDesynthedItem;
            Configuration.ShowDesynthesisObtains = Configuration.ShowDesynthesisLevel || Configuration.ShowDesynthesisObtains;
            Configuration.HideAdventurerInNeedBonus = Configuration.HideRouletteBonus || Configuration.HideAdventurerInNeedBonus;
            Configuration.ShowLootRoll = Configuration.ShowCastLot || Configuration.ShowLootRoll;
            Configuration.ShowOthersLootRoll = Configuration.ShowOthersCastLot || Configuration.ShowOthersLootRoll;
            Configuration.ShowOtherEarnedAchievement = Configuration.ShowEarnAchievement || Configuration.ShowOtherEarnedAchievement;
            Configuration.FilterCustomEmoteChannel = Configuration.FilterEmoteChannel || Configuration.FilterCustomEmoteChannel;
            Configuration.Version = 4;
            Configuration.Save();
        }

        // TODO(next release): Config migration v6 — remove deprecated Configuration properties listed in
        // docs/rules-review-checklist.md (HideObtainedShardsFromLoot, HideOthersObtainFromLoot).
        // Bump Configuration.Version to 6 after v1–v5 migrations remain for upgrade path.

        if (Configuration.Version < 5)
        {
            if (Configuration.ShowGearsetEquipped)
            {
                Configuration.ShowJobChange = true;
                Configuration.ShowPortraitMessages = true;
            }

            Configuration.Version = 5;
            Configuration.Save();
        }

        Rules.UpdateIsActiveStates(Configuration);

        ReloadGameDataCaches(validateRuleIds: true);

        if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate(Configuration);

        // Sync commendation baseline without printing (plugin reload mid-session).
        if (ClientState.IsLoggedIn && Configuration.BetterCommendationMessage)
            BetterCommendationsUpdate(printMessage: false);

        ChatGui.CheckMessageHandled += OnChat;
        ChatGui.LogMessage += OnLogMessage;
        ClientState.TerritoryChanged += OnTerritoryChanged;
        ClientState.Login += OnLogin;
        ClientState.Logout += OnLogout;

        PluginUi = new(Configuration);
        _windowSystem.AddWindow(PluginUi);

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

    /// <summary>
    ///     Fishing flavor lines loaded from game data at startup (Fisher's Intuition, lure text, and similar).
    ///     Stored in a case-insensitive set for lookup against normalized chat text.
    /// </summary>
    public static IReadOnlySet<string> FishingFlavorMessages { get; private set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    private Configuration Configuration { get; }
    private PluginUI PluginUi { get; }

    public void Dispose()
    {
        // UI: tear down the window system and the three UiBuilder subscriptions so the host
        // doesn't keep calling into a disposed plugin on reload.
        PluginInterface.UiBuilder.Draw -= DrawUI;
        PluginInterface.UiBuilder.OpenMainUi -= DrawConfigUI;
        PluginInterface.UiBuilder.OpenConfigUi -= DrawConfigUI;
        _windowSystem.RemoveAllWindows();
        PluginUi.Dispose();

        // DTR bar: drop the entry so it doesn't linger after the plugin is gone.
        if (DtrEntry is not null)
        {
            try { DtrEntry.Remove(); }
            catch(Exception ex) { Log.Warning("Failed to remove DTR bar entry on dispose: " + ex); }
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
    }
    private void OnCommand(string command, string args)
    {
        PluginUi.IsOpen = true;
    }

    private void UpdateLang(string langCode)
    {
        Languages.Culture = new(langCode);
    }

    private void DrawUI()
    {
        _windowSystem.Draw();
    }

    private void DrawConfigUI()
    {
        PluginUi.IsOpen = true;
    }
}
