global using Dalamud.Bindings.ImGui;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using ChatTwo.Code;
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
using TidyChat.Utility;
using Better = TidyChat.Utility.BetterStrings;
using Flags = TidyChat.Utility.ChatFlags;
using TidyStrings = TidyChat.Utility.InternalStrings;
using Timer = System.Timers.Timer;

namespace TidyChat;

public sealed class TidyChatPlugin : IDalamudPlugin
{
    private const string SettingsCommand = TidyStrings.SettingsCommand;
    private const string ShorthandCommand = TidyStrings.ShorthandCommand;
    private readonly WindowSystem _windowSystem = new("TidyChat");

    private long _sessionBlockedMessages;

    /// <summary>
    ///     Texts of messages that OnLogMessage explicitly allowed via ID-based rules.
    ///     OnChat checks this set so it doesn't re-block messages that OnLogMessage already approved.
    /// </summary>
    private readonly HashSet<string> _allowedByLogMessage = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    ///     Texts of messages that OnLogMessage would have blocked.
    ///     Only populated in debug mode so OnChat can display them with the [Blocked] prefix
    ///     instead of silently suppressing them via PreventOriginal.
    /// </summary>
    private readonly HashSet<string> _blockedByLogMessage = new(StringComparer.OrdinalIgnoreCase);
    private const int MaxLogMessageSetSize = 1000;
    private readonly Lock _logMessageLock = new();
    private readonly Lock _chatHistoryLock = new();
    private volatile bool _setPlayerNamePending;
    private int _setPlayerNameRetries;
    private const int MaxSetPlayerNameRetries = 10;

    // #122: announcements inside this window after a Login event are treated as a real login
    // (full block shown in "Login only" mode); announcements outside it are world-hops.
    private DateTime _serverAnnouncementLoginGraceEnd = DateTime.MinValue;
    private const int ServerAnnouncementLoginGraceSeconds = 20;

    #region Setup

    public TidyChatPlugin()
    {
        // Player cannot change this without restarting the game so should be safe to grab here
        L10N.Language = ClientState.ClientLanguage;
        LoadTomestones();
        LoadFishingFlavorMessages();
        PluginInterface.LanguageChanged += UpdateLang;
        UpdateLang(PluginInterface.UiLanguage);

        Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Configuration.Initialize(PluginInterface);

        if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate(Configuration);

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
    ///     Fishing flavor text loaded from game data at startup.
    ///     Covers Fisher's Intuition messages (FishingSpot.BigFishOnReach/End/Refresh per spot)
    ///     and per-fish lure flavor text (FishParameter.Unknown_70_1/2/3, added in Dawntrail).
    ///     Stored with OrdinalIgnoreCase for O(1) comparison against normalized incoming messages.
    /// </summary>
    public static IReadOnlySet<string> FishingFlavorMessages { get; private set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    private Configuration Configuration { get; }
    private PluginUI PluginUi { get; }

    private readonly Queue<(string Message, long ExpiresAtTicks)> _chatHistory = new();

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
    private void OnLogin()
    {
        if (Configuration.BetterCommendationMessage) BetterCommendationsUpdate();
        if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate(Configuration);
        _setPlayerNameRetries = 0; // each login gets a fresh retry budget
        // #122: open the grace window so "Login only" mode shows the post-login announcement burst.
        _serverAnnouncementLoginGraceEnd = DateTime.UtcNow.AddSeconds(ServerAnnouncementLoginGraceSeconds);
        SetPlayerName();
    }

    private void OnLogout(int add, int remove)
    {
        BlockedCountUpdate();
    }

    private void OnTerritoryChanged(uint e)
    {
        BlockedCountUpdate();
        // Look up the new territory to determine if we're entering a duty instance.
        byte newExclusiveType = 0;
        try
        {
            newExclusiveType = DataManager.GetExcelSheet<TerritoryType>().GetRow(e).ExclusiveType;
        }
        catch { /* non-critical — default 0 means "not a duty" */ }

        // Only print the better commendation summary when leaving a duty (arriving at
        // a non-instanced zone), not when entering the next one.
        if (Configuration.BetterCommendationMessage) BetterCommendationsUpdate(printMessage: newExclusiveType != 2);
        if (Configuration.InstanceInDtrBar) DelayedInstanceDtrBarUpdate(Configuration);
        if (Configuration.IncludeDutyNameInComms)
            try
            {
                TerritoryType territory =
                    DataManager.GetExcelSheet<TerritoryType>().GetRow(e); // built in sheets will never be null
                byte exclusiveType = territory.ExclusiveType;
                bool isPvp = territory.IsPvpZone;

                string placeName = $"{territory.PlaceName.Value.Name}";
                string dutyName = $"{territory.ContentFinderCondition.Value.Name}";

                TidyStrings.LastDuty = exclusiveType switch
                {
                    2 when dutyName.Length >= 1 => dutyName,
                    2 when dutyName.Length == 0 && placeName.Length > 0 => placeName,
                    2 when dutyName.Length == 0 && isPvp => L10N.GetTidy(TidyStrings.PvPDuty),
                    _ => TidyStrings.LastDuty // Keep previous value if we don't care about the new value
                };
            }
            catch(KeyNotFoundException)
            {
                Log.Warning(
                    "Something somehow somewhere went wrong but we don't want to crash on territory change");
            }
    }

    private void OnLogMessage(ILogMessage message)
    {
        if (!Configuration.Enabled || message.IsHandled) return;

        // Check custom filters (whitelist) that use #LogMessageId syntax.
        // Block entries suppress the message here; Allow entries add it to _allowedByLogMessage.
        if (Configuration.Whitelist.Count > 0)
        {
            foreach(PlayerName entry in Configuration.Whitelist)
            {
                if (!entry.IsLogMessageId) continue;
                uint[] ids = entry.GetLogMessageIds();
                if (ids.Length == 0) continue;
                bool idMatches = false;
                foreach(uint id in ids)
                {
                    if (id == message.LogMessageId) { idMatches = true; break; }
                }
                if (!idMatches) continue;

                if (!entry.AllowMessage)
                {
                    if (Configuration.EnableDebugMode)
                        Log.Debug($"[LogMessage] BLOCKED by custom filter \"{entry.FirstName}\" (ID: {message.LogMessageId})");
                    message.PreventOriginal();
                    Interlocked.Increment(ref _sessionBlockedMessages);
                    return;
                }
                // Allow entry — track it so OnChat doesn't re-block.
                try
                {
                    string text = message.FormatLogMessageForDebugging().ExtractText();
                    if (!string.IsNullOrEmpty(text))
                        lock (_logMessageLock)
                        {
                            if (_allowedByLogMessage.Count >= MaxLogMessageSetSize) _allowedByLogMessage.Clear();
                            _allowedByLogMessage.Add(text);
                        }
                }
                catch { /* non-critical */ }
                if (Configuration.EnableDebugMode)
                    Log.Debug($"[LogMessage] ALLOWED by custom filter \"{entry.FirstName}\" (ID: {message.LogMessageId})");
                return;
            }
        }

        if (!Rules.LogMessageIdToRules.TryGetValue(message.LogMessageId, out IReadOnlyList<LocalizedFilterRule>? matchingRules))
        {
            // No rules registered for this ID — log it in debug mode for ID discovery.
            // Includes the formatted message text so you can correlate the ID with
            // what appeared in chat, making it easy to map unknown messages to IDs in-game.
            if (Configuration.EnableDebugMode)
            {
                try
                {
                    ReadOnlySeString formatted = message.FormatLogMessageForDebugging();
                    Log.Debug($"[LogMessage] Unmatched ID: {message.LogMessageId} | Params: {message.ParameterCount} | Text: {formatted.ExtractText()}");
                }
                catch
                {
                    Log.Debug($"[LogMessage] Unmatched ID: {message.LogMessageId} | Params: {message.ParameterCount}");
                }
            }
            return;
        }

        foreach(LocalizedFilterRule rule in matchingRules)
        {
            // ShouldBlock respects both "Show*" semantics (block when !IsActive)
            // and "Hide*" semantics (block when IsActive) via BlockWhenActive.
            if (rule.ShouldBlock)
            {
                if (Configuration.EnableDebugMode)
                {
                    Log.Debug($"[LogMessage] BLOCKED by {rule.Name} (ID: {message.LogMessageId})");
                    // In debug mode, don't suppress — let OnChat display it with [Blocked] prefix.
                    try
                    {
                        string text = message.FormatLogMessageForDebugging().ExtractText();
                        if (!string.IsNullOrEmpty(text))
                            lock (_logMessageLock)
                            {
                                if (_blockedByLogMessage.Count >= MaxLogMessageSetSize) _blockedByLogMessage.Clear();
                                _blockedByLogMessage.Add(text);
                            }
                    }
                    catch
                    {
                        // ignored
                    }
                    return;
                }
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
                // Print a compact replacement for the suppressed NN join/leave messages.
                if (message.LogMessageId == 7027 || message.LogMessageId == 7011)
                    ChatGui.Print(Better.NoviceNetworkJoinMessage(Configuration));
                else if (message.LogMessageId == 7030)
                    ChatGui.Print(Better.NoviceNetworkLeaveMessage(Configuration));
                return;
            }
        }

        // Track the allowed text so OnChat doesn't re-block this message.
        try
        {
            string text = message.FormatLogMessageForDebugging().ExtractText();
            if (!string.IsNullOrEmpty(text))
                lock (_logMessageLock)
                {
                    if (_allowedByLogMessage.Count >= MaxLogMessageSetSize) _allowedByLogMessage.Clear();
                    _allowedByLogMessage.Add(text);
                }
        }
        catch { /* Safe to ignore — worst case OnChat re-evaluates the message */ }

        if (Configuration.EnableDebugMode)
            Log.Debug($"[LogMessage] ALLOWED (ID: {message.LogMessageId}, Rules: {string.Join(", ", matchingRules.Select(r => r.Name))})");
    }

    private void OnChat(IHandleableChatMessage message)
    {
        if (!Configuration.Enabled)
        {
            Log.Verbose("Tidy Chat is not enabled");
            return;
        }

        // Ignore already filtered messages by other plugins such as NoSol.
        // IHandleableChatMessage only exposes a one-way PreventOriginal(); there is no
        // corresponding "AllowOriginal", so TidyChat cannot un-block messages that another
        // plugin has already suppressed. Custom Allow-list entries therefore cannot override
        // blocks imposed by other plugins (e.g. NoSol).
        if (message.IsHandled) return;

        ChatType chatType = FromDalamud(message.LogKind);
        bool isHandled;

        // Normalize all messages to lowercase so that we don't have to worry about case sensitivity in the filters
        string normalizedText = NormalizeInput.ToLowercase(message.Message);

        // Save original text before Better Messages may modify message.Message.
        // Use ExtractText() to match how OnLogMessage stores allowed/blocked text —
        // TextValue only includes TextPayload content, while ExtractText() also captures
        // text inside expression payloads (e.g. bonus XP "(+80%)" suffixes).
        string rawTextValue = message.Message.TextValue;
        string extractedTextValue;
        try { extractedTextValue = new ReadOnlySeString(message.Message.Encode()).ExtractText(); }
        catch { extractedTextValue = rawTextValue; }

        // If we have the player's name, normalize any messages containing the player's name
        // or initials to read "you" instead of the player's name.
        if (Configuration.PlayerName != "") normalizedText = NormalizeInput.ReplaceName(normalizedText, Configuration);

        // #122: Server announcement check runs BEFORE ChannelCanBeFiltered so it can
        // intercept announcements regardless of which chat type the game sends them on.
        // No channel guard — the regex patterns themselves are specific enough.
        if (Configuration.ServerAnnouncementMode != ServerAnnouncementMode.ShowAll)
        {
            bool isWorldGreeting = L10N.Get(ChatRegexStrings.ServerWorldGreeting).IsMatch(normalizedText);
            bool isAnnouncement = L10N.Get(ChatRegexStrings.ServerAnnouncement).IsMatch(normalizedText);
            if (isWorldGreeting || isAnnouncement)
            {
                bool withinLoginWindow = DateTime.UtcNow < _serverAnnouncementLoginGraceEnd;
                bool isPhishing = L10N.Get(ChatRegexStrings.ServerPhishingWarning).IsMatch(normalizedText);
                bool suppress = Configuration.ServerAnnouncementMode switch
                {
                    ServerAnnouncementMode.HideAll => true,
                    ServerAnnouncementMode.Condensed => !isWorldGreeting,
                    ServerAnnouncementMode.LoginOnly => !withinLoginWindow,
                    ServerAnnouncementMode.LoginThenCondensed =>
                        !withinLoginWindow && !isWorldGreeting,
                    ServerAnnouncementMode.HidePhishing => isPhishing,
                    _ => false
                };
                if (suppress)
                {
                    if (Configuration.EnableDebugMode) Log.Debug($"BLOCKED (server announcement): {message.Message}");
                    message.PreventOriginal();
                    Interlocked.Increment(ref _sessionBlockedMessages);
                    return;
                }

                // Tag surviving lines when TidyChat is actively condensing
                // (suppressing some lines but keeping others), so users know
                // the full block was trimmed.
                bool isCondensing = Configuration.ServerAnnouncementMode switch
                {
                    ServerAnnouncementMode.Condensed => true,
                    ServerAnnouncementMode.LoginThenCondensed => !withinLoginWindow,
                    ServerAnnouncementMode.HidePhishing => true,
                    _ => false
                };
                if (isCondensing && Configuration.IncludeChatTag)
                {
                    SeStringBuilder tagBuilder = new();
                    Better.AddTidyChatTag(tagBuilder);
                    tagBuilder.AddText(message.Message.TextValue);
                    message.Message = tagBuilder.BuiltString;
                }
                return;
            }
        }

        // If the channel is not one that Tidy Chat filters - don't bother running any rules
        // This includes all Battle-related channels, GM-related channels, NPC Dialogue, 
        // and a few other channels
        if (!ChannelCanBeFiltered((chatType))) return;

        // This logic exists elsewhere but I don't care to find/clean it up so I'll be redundant and check here too.
        // Whitelist Block rules are still honoured here so users can suppress one specific spammer
        // in an otherwise-unfiltered emote channel.
        if ((chatType is ChatType.StandardEmote && !Configuration.FilterEmoteChannel) ||
            (chatType is ChatType.CustomEmote && !Configuration.FilterCustomEmoteChannel))
        {
            if (IsWhitelistedBlocked(message.Sender, message.Message, chatType))
            {
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
            }
            return;
        }

        // Check if emotes from other players should be filtered or not.
        // Whitelist Allow rules override this so favourited players' custom emotes still come through.
        if (!Configuration.ShowOtherCustomEmotes && !string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal) && chatType is ChatType.CustomEmote)
        {
            if (!IsWhitelistedAllowed(message.Sender, message.Message, chatType))
            {
                if (Configuration.EnableDebugMode) Log.Verbose($"Filtered an emote: {message.Message}");
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
            }
            return;
        }

        // If the message is a /? command - temporarily disable the filters to allow the command text through
        // We check if FilterSystemMessages is on because we forcefully toggle it on once the timer expires and disabling it is only necessary if it is enabled
        if (L10N.Get(ChatRegexStrings.QuestionMarkCommandResponse).IsMatch(normalizedText) && Configuration.FilterSystemMessages)
        {
            Better.TemporarilyDisableSystemFilter(Configuration);
            return;
        }


        // If we join a party - temporarily disable the filters to allow the Party Information messages through
        // We check if FilterSystemMessages is on because we forcefully toggle it on once the timer expires and disabling it is only necessary if it is enabled
        if (L10N.Get(ChatStrings.JoinParty).All(normalizedText.Contains) && Configuration.ShowJoinParty &&
            Configuration is { ShowPartyInformation: true, FilterSystemMessages: true })
        {
            Better.TemporarilyDisableSystemFilter(Configuration);
            return;
        }

        #region Better Messages

        // Certain messages are improved with better messaging - these will change those messages to be Better Messages
        // Better Messages must always Early Return to avoid being filtered and because if we bettered the message we aren't filtering it anyway

        if (Configuration.BetterInstanceMessage && chatType is ChatType.System &&
            L10N.Get(ChatStrings.InstancedArea).All(normalizedText.Contains))
        {
            message.Message = Better.Instances(message.Message, Configuration);
            if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate(Configuration);
            return;
        }

        // When Better Commendations is enabled, suppress the original System message so only
        // the synthesized better message (printed on territory change) is shown.
        if (Configuration.BetterCommendationMessage && chatType is ChatType.System &&
            L10N.Get(ChatStrings.PlayerCommendation).All(normalizedText.Contains))
        {
            message.PreventOriginal();
            Interlocked.Increment(ref _sessionBlockedMessages);
            return;
        }

        if (Configuration.BetterSayReminder &&
            chatType is ChatType.System && L10N.Get(ChatStrings.SayQuestReminder).All(normalizedText.Contains))

        {
            message.Message = Better.SayReminder(message.Message, Configuration);
            return;
        }

        if (Configuration.BetterTreasureDungeonMessage && chatType is ChatType.System)
        {
            if (L10N.Get(ChatRegexStrings.ChamberOpens).IsMatch(normalizedText))
            {
                Match match = L10N.Get(ChatRegexStrings.ChamberOpens).Match(normalizedText);
                if (match.Groups["chamber"].Success)
                {
                    TidyStrings.LastTreasureDungeonChamber = match.Groups["chamber"].Value;
                }
                return;
            }

            if (L10N.Get(ChatRegexStrings.TrapTriggered).IsMatch(normalizedText))
            {
                if (TidyStrings.LastTreasureDungeonChamber.Length > 0)
                {
                    message.Message = Better.TreasureDungeon(Configuration);
                }
                return;
            }
        }

        // No early returns in the following Better Message settings as the messages still need to be filtered - but have been modified
        if (Configuration.NormalizeBlocks &&
            (Configuration.AlwaysNormalizeBlocks || chatType is not ChatType.Party and not ChatType.Alliance))
        {
            message.Message = DeblockMessage(message.Message);
        }

        if (Configuration.EnableSmolMode)
        {
            message.Message = SmolMessage(message.Message);
        }

        #endregion

        // If OnLogMessage already decided to block this message, show it with [Blocked] in debug.
        bool wasBlockedByLog;
        lock (_logMessageLock) { wasBlockedByLog = _blockedByLogMessage.Count > 0 && (_blockedByLogMessage.Remove(rawTextValue) || _blockedByLogMessage.Remove(extractedTextValue)); }
        if (wasBlockedByLog)
        {
            if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
            {
                message.Message = BuildDebugString(chatType, message.Message, ["LogMessage"], Configuration.DebugIncludeChannel, true);
            }
            return;
        }

        // If OnLogMessage already decided to allow this message via an ID-based rule,
        // respect that decision and don't let OnChat's default-block logic override it.
        bool wasAllowedByLog;
        lock (_logMessageLock) { wasAllowedByLog = _allowedByLogMessage.Count > 0 && (_allowedByLogMessage.Remove(rawTextValue) || _allowedByLogMessage.Remove(extractedTextValue)); }
        if (wasAllowedByLog)
        {
            if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
            {
                message.Message = BuildDebugString(chatType, message.Message, ["LogMessage"], Configuration.DebugIncludeChannel, false);
            }
            return;
        }

        #region Channel Filters

        Rules.UpdateIsActiveStates(Configuration);
        LocalizedFilterRule[] rules = Rules.AllRules;


        // Block any messages that come from a "spammy" channel
        bool isBlocked = ChannelIsSpammy(chatType);

        // Skip filtering if channel filter is disabled — show all messages in that channel.
        // This mirrors FilterSystemMessages and applies to the other filterable channels.
        // Whitelist Block rules are still honoured here so users can suppress one specific
        // spammer in an otherwise-unfiltered channel.
        if ((chatType is ChatType.System && !Configuration.FilterSystemMessages) ||
            (chatType is ChatType.Progress && !Configuration.FilterProgressSpam) ||
            (chatType is ChatType.LootRoll && !Configuration.FilterLootSpam) ||
            (chatType is ChatType.LootNotice && !Configuration.FilterObtainedSpam) ||
            (chatType is ChatType.Gathering or ChatType.GatheringSystem && !Configuration.FilterGatheringSpam) ||
            (chatType is ChatType.Crafting && !Configuration.FilterCraftingSpam))
        {
            if (IsWhitelistedBlocked(message.Sender, message.Message, chatType))
            {
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
            }
            return;
        }

        bool showEverythingElse = false;
        if ((chatType is ChatType.System && Configuration.ShowEverythingElse) ||
            (chatType is ChatType.Crafting && Configuration.ShowAllOtherCrafting) ||
            (chatType is ChatType.Gathering or ChatType.GatheringSystem && Configuration.ShowAllOtherGathering))
        {
            isBlocked = !isBlocked;
            showEverythingElse = true;
        }
        bool defaultBlocked = isBlocked;

        List<string> rulesMatched = [];
        List<string>? rulesSkipped = Configuration.EnableDebugMode ? [] : null;
        List<string>? rulesFailed = Configuration.EnableDebugMode ? [] : null;
        foreach(LocalizedFilterRule rule in rules)
        {
            if (rule.Error is not null)
            {
                Log.Error($"Error: {rule.Error}");
            }

            // Skip rules already handled by OnLogMessage via LogMessageIds
            if (rule.LogMessageIds is not null)
            {
                if (Configuration.EnableDebugMode) Log.Verbose($"SKIPPING CHECK: {rule.Name} handled by LogMessage ID");
                rulesSkipped?.Add(rule.Name);
                continue;
            }

            // Skip rules that wouldn't change isBlocked away from defaultBlocked
            if (rule.IsActive == showEverythingElse)
            {
                string activeOrInactive = showEverythingElse ? "active" : "inactive";
                if (Configuration.EnableDebugMode) Log.Verbose($"SKIPPING CHECK: {rule.Name} is {activeOrInactive}");
                rulesSkipped?.Add(rule.Name);
                continue;
            }

            // Don't bother with checks for Channels other than the one the rule intends to filter
            if (chatType != rule.Channel && chatType is not ChatType.Echo)
            {
                if (Configuration.EnableDebugMode) Log.Verbose($"SKIPPING CHECK: Message was sent to {chatType} but the rule's filter is for {rule.Channel}");
                rulesSkipped?.Add(rule.Name);
                continue;
            }

            if (rule.Channel == ChatType.Echo)
            {
                // Echo rules use OR logic per check — each passing check is independently logged.
                // They don't affect isBlocked; they only record matches for debug display.
                if (RuleMatchesText(rule, normalizedText, Configuration.EnableDebugMode))
                    rulesMatched.Add(rule.Name);
                else if (Configuration.EnableDebugMode)
                    Log.Debug("/echo message failed to match any rules");
                continue;
            }

            if (RuleMatchesText(rule, normalizedText, Configuration.EnableDebugMode))
            {
                rulesMatched.Add(rule.Name);
                isBlocked = !defaultBlocked;
            }
            else
            {
                rulesFailed?.Add(rule.Name);
            }
        }

        if (Configuration.EnableDebugMode)
        {
            Log.Debug($"{rulesMatched.Count} Rules Matched: {string.Join(", ", rulesMatched)}");
            Log.Debug($"{rulesSkipped!.Count} Rules Skipped: {string.Join(", ", rulesSkipped)}");
            Log.Debug($"{rulesFailed!.Count} Rules Failed: {string.Join(", ", rulesFailed)}");
        }

        // LootNotice uses inverted logic: the channel is Allow-By-Default and rules block,
        // whereas other spammy channels are Block-By-Default and rules allow.
        isHandled = chatType is ChatType.LootNotice ? !isBlocked : isBlocked;

        if (Configuration.EnableDebugMode)
            Log.Debug($"{(isHandled ? "BLOCKED" : "ALLOWED")}: {message.Message}");

        #endregion

        #region Configuration Filter Overrides

        // If the text is a Custom Emote and it comes from the player it should not be blocked
        if (chatType is ChatType.CustomEmote &&
            string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
        {
            if (Configuration.EnableDebugMode) Log.Information("Allowing custom emote used by player");
            isHandled = false;
        }

        // If the message is an emote used by the player and we are filtering used emotes - it should be blocked
        if (!Configuration.ShowSelfUsedEmotes &&
            (chatType is ChatType.StandardEmote || chatType is ChatType.CustomEmote) &&
            string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
            isHandled = true;

        // Filter loot roll messages from non-party members (alliance/raid) when ShowOnlyPartyMemberRolls is on.
        // Applies to any LootRoll message that was unblocked (ShowOthersLootRoll, ShowOthersCastLot, etc.)
        // Only active when actually in a party (PartyList.Length > 0).
        if (chatType is ChatType.LootRoll && !isHandled &&
            Configuration.ShowOnlyPartyMemberRolls && PartyList.Length > 0)
        {
            // Player's own messages start with "you" after name normalization — always allow those.
            bool isPlayerMessage = normalizedText.StartsWith("you ", StringComparison.Ordinal);
            bool isPartyMember = isPlayerMessage || PartyList.Any(member =>
                normalizedText.StartsWith(
                    member.Name.TextValue.ToLower(CultureInfo.InvariantCulture) + " ",
                    StringComparison.Ordinal));
            if (!isPartyMember)
            {
                if (Configuration.EnableDebugMode) Log.Debug($"BLOCKED (non-party loot): {message.Message}");
                isHandled = true;
            }
        }

        // Fishing flavor text whitelisting using Lumina-loaded game data.
        // Covers Fisher's Intuition (FishingSpot) and per-fish lure flavor text (FishParameter).
        if (chatType is ChatType.Gathering && isHandled && Configuration.ShowFishingFlavorText &&
            FishingFlavorMessages.Count > 0 && FishingFlavorMessages.Contains(normalizedText))
        {
            if (Configuration.EnableDebugMode) Log.Debug($"ALLOWED (fishing flavor): {message.Message}");
            isHandled = false;
        }

        // Per-type tomestone filtering using Lumina-loaded game data.
        if (chatType is ChatType.LootNotice && !isHandled &&
            L10N.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(normalizedText))
        {
            foreach(TomestoneInfo tomestone in Tomestones)
            {
                string itemNameLower = tomestone.Name.ToLower(CultureInfo.InvariantCulture);
                int lastWordStart = itemNameLower.LastIndexOf(' ') + 1;
                string typeName = itemNameLower[lastWordStart..];
                if (normalizedText.Contains(typeName, StringComparison.Ordinal))
                {
                    if (Configuration.HideTomestoneById.TryGetValue(tomestone.RowId, out bool hide) && hide)
                    {
                        if (Configuration.EnableDebugMode) Log.Debug($"BLOCKED (tomestone): {message.Message}");
                        isHandled = true;
                    }
                    break;
                }
            }
        }

        #endregion Channel Filters

        #region Whitelist

        // Two-pass so Allow rules always win regardless of where they appear in the list:
        // pass 1 applies all Block rules, pass 2 lets any matching Allow rule unblock them.
        if (Configuration.Whitelist.Count > 0)
        {
            try
            {
                foreach(PlayerName p in Configuration.Whitelist)
                    if (!p.AllowMessage)
                        CustomFilterCheck(message.Sender, message.Message, ref isHandled, p, chatType);
                foreach(PlayerName p in Configuration.Whitelist)
                    if (p.AllowMessage)
                        CustomFilterCheck(message.Sender, message.Message, ref isHandled, p, chatType);
            }
            catch(Exception ex)
            {
                Log.Error("Error: Failed to evaluate Whitelist - " + ex);
            }
        }

        #endregion Whitelist

        #region Duplicate Message Spam Filter

        if (Configuration.ChatHistoryFilter && !isHandled)
            try
            {
                /* Disable Chat History for self-sent messages by default */
                if (Configuration.DisableSelfChatHistory && string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal)) return;

                var historyChannels = (ChatFlags.Channels)Configuration.ChatHistoryChannels;
                if (!historyChannels.Equals(ChatFlags.Channels.None))
                {
                    if (Flags.CheckFlags(Configuration, chatType))
                    {
                        string currentMessage = $"{message.Sender.TextValue}: {message.Message.TextValue}";
                        lock (_chatHistoryLock)
                        {
                            // Evict expired entries from the front of the queue.
                            if (Configuration.ChatHistoryTimer > 0)
                            {
                                long now = Environment.TickCount64;
                                while (_chatHistory.Count > 0 && _chatHistory.Peek().ExpiresAtTicks <= now)
                                    _chatHistory.Dequeue();
                            }

                            // Check for duplicate.
                            bool isDuplicate = false;
                            foreach(var entry in _chatHistory)
                            {
                                if (string.Equals(entry.Message, currentMessage, StringComparison.Ordinal))
                                {
                                    isDuplicate = true;
                                    break;
                                }
                            }

                            if (isDuplicate)
                            {
                                Log.Verbose($"Found message in chat history and blocked: {currentMessage}");
                                isHandled = true;
                            }
                            else
                            {
                                if (_chatHistory.Count >= Configuration.ChatHistoryLength)
                                {
                                    Log.Verbose("Chat history reached limit. Removed oldest message and added:" +
                                                currentMessage);
                                    _chatHistory.Dequeue();
                                }
                                else
                                {
                                    Log.Verbose("Added:" + currentMessage);
                                }

                                long expiresAt = Configuration.ChatHistoryTimer > 0
                                    ? Environment.TickCount64 + (Configuration.ChatHistoryTimer * 1000L)
                                    : long.MaxValue;
                                _chatHistory.Enqueue((currentMessage, expiresAt));
                            }
                        }
                    }

                    return;
                }
            }
            catch(Exception ex)
            {
                Log.Error("Error: Failed to handle Chat History - " + ex);
            }

        #endregion Duplicate Message Spam Filter

        // Although Echo can be used for /xllog debugging make sure it never ends up filtered
        if (chatType is ChatType.Echo)
        {
            isHandled = false;
        }

        #region Debug Mode Enabled

        if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
        {
            if (Configuration.DebugIncludeChannel || isHandled)
            {
                message.Message = BuildDebugString(chatType, message.Message, rulesMatched, Configuration.DebugIncludeChannel, isHandled);
            }
            isHandled = false;
        }

        #endregion Debug Mode Enabled
        if (isHandled)
        {
            Interlocked.Increment(ref _sessionBlockedMessages);
            message.PreventOriginal();
        }
    }

    /// <summary>
    ///     Tests whether the rule's regex or string checks all match the normalized text.
    ///     Returns false if the rule has no checks or any check fails (AND logic).
    /// </summary>
    private static bool RuleMatchesText(LocalizedFilterRule rule, string normalizedText, bool debugMode)
    {
        switch (rule.Pattern)
        {
            case PatternKind.RegexMatch:
                if (rule.RegexChecks is null) return false;
                foreach(LocalizedRegex check in rule.RegexChecks)
                {
                    if (L10N.Get(check).IsMatch(normalizedText))
                    {
                        if (debugMode) Log.Debug($"MATCHED: {rule.Name} | REGEX: {L10N.Get(check)}");
                    }
                    else
                    {
                        if (debugMode) Log.Verbose($"FAILED: {rule.Name} | REGEX: {L10N.Get(check)}");
                        return false;
                    }
                }
                return true;
            case PatternKind.StringMatch:
                if (rule.StringChecks is null) return false;
                foreach(LocalizedStrings check in rule.StringChecks)
                {
                    if (L10N.Get(check).All(normalizedText.Contains))
                    {
                        if (debugMode) Log.Debug($"MATCHED: {rule.Name} | CONTAINS: {string.Join(", ", L10N.Get(check))}");
                    }
                    else
                    {
                        if (debugMode) Log.Verbose($"FAILED: {rule.Name} | CONTAINS: {string.Join(", ", L10N.Get(check))}");
                        return false;
                    }
                }
                return true;
            default:
                return false;
        }
    }

    private static SeString BuildDebugString(ChatType chatType, SeString message, List<string> rulesMatched, bool debugIncludeChannel, bool isBlocked)
    {
        SeStringBuilder stringBuilder = new();
        Better.AddTidyChatTag(stringBuilder);
        if (debugIncludeChannel)
        {
            Better.AddChannelTag(stringBuilder, chatType);
        }
        if (isBlocked) Better.AddBlockedTag(stringBuilder);
        if (rulesMatched.Count > 0)
        {
            if (!isBlocked) Better.AddAllowedTag(stringBuilder);
            Better.AddRuleTag(stringBuilder, rulesMatched);
        }
        stringBuilder.AddText(message.TextValue);
        return stringBuilder.BuiltString;
    }

    /// <summary>
    ///     Returns true if <paramref name="entry"/> matches the message/sender/channel. Handles the empty-name guard,
    ///     channel scoping, regex (cached + crash-safe via <see cref="PlayerName.GetCompiledRegex"/>), and the
    ///     <see cref="PlayerNameMatchMode"/> selection for plain-text entries.
    /// </summary>
    private bool CustomFilterMatches(SeString sender, SeString message, PlayerName entry, ChatType chatType)
    {
        if (string.IsNullOrWhiteSpace(entry.FirstName)) return false; // empty name would Contains-match everything

        // LogMessageId entries are handled in OnLogMessage, not here.
        if (entry.IsLogMessageId) return false;

        var channels = (ChatFlags.Channels)entry.WhitelistedChannels;
        if (channels == ChatFlags.Channels.None) return false;
        if (!Flags.CheckFlags(entry, chatType)) return false;

        if (entry.IsRegex)
        {
            Regex? regex = entry.GetCompiledRegex((src, ex) =>
                Log.Warning($"[Whitelist] Invalid regex \"{src}\": {ex.Message}"));
            try
            {
                return regex != null && regex.IsMatch(message.TextValue);
            }
            catch(RegexMatchTimeoutException)
            {
                Log.Warning($"[Whitelist] Regex match timeout for \"{entry.FirstName}\"");
                return false;
            }
        }

        // Plain text mode
        if (entry.MatchMode == PlayerNameMatchMode.ExactSender)
            return string.Equals(sender.TextValue, entry.FirstName, StringComparison.Ordinal);

        // MessageContains (backward-compatible default): sender match OR substring match
        return string.Equals(sender.TextValue, entry.FirstName, StringComparison.Ordinal)
            || message.TextValue.Contains(entry.FirstName, StringComparison.Ordinal);
    }

    /// <summary>True if any Allow rule in the whitelist would unblock this message.</summary>
    private bool IsWhitelistedAllowed(SeString sender, SeString message, ChatType chatType)
    {
        if (Configuration.Whitelist.Count == 0) return false;
        foreach(PlayerName p in Configuration.Whitelist)
        {
            if (!p.AllowMessage) continue;
            if (CustomFilterMatches(sender, message, p, chatType)) return true;
        }
        return false;
    }

    /// <summary>True if any Block rule in the whitelist would suppress this message.</summary>
    private bool IsWhitelistedBlocked(SeString sender, SeString message, ChatType chatType)
    {
        if (Configuration.Whitelist.Count == 0) return false;
        foreach(PlayerName p in Configuration.Whitelist)
        {
            if (p.AllowMessage) continue;
            if (CustomFilterMatches(sender, message, p, chatType)) return true;
        }
        return false;
    }

    private void CustomFilterCheck(SeString sender, SeString message, ref bool isHandled,
        PlayerName playerOrMessage,
        ChatType chatType)
    {
        // Cheap rejects first: empty entries match everything via Contains("") so they must be skipped.
        if (string.IsNullOrWhiteSpace(playerOrMessage.FirstName)) return;
        if (!CustomFilterMatches(sender, message, playerOrMessage, chatType)) return;

        if (!isHandled && !playerOrMessage.AllowMessage)
        {
            isHandled = true;
            if (Configuration.EnableDebugMode)
                Log.Verbose($"A message matching \"{playerOrMessage.FirstName}\" has been blocked.");
        }
        else if (isHandled && playerOrMessage.AllowMessage)
        {
            isHandled = false;
            if (Configuration.EnableDebugMode)
                Log.Verbose($"A message matching \"{playerOrMessage.FirstName}\" has been allowed.");
        }
    }

    private void SetPlayerName()
    {
        if (_setPlayerNamePending) return;
        try
        {
            IPlayerCharacter? player = ObjectTable.LocalPlayer;
            if (player is null) return;

            Configuration.PlayerName = $"{player.Name}";
            Log.Information($"Player name saved as {player.Name}");
            Configuration.Save();
            _setPlayerNameRetries = 0; // success — reset the retry budget for the next login cycle
        }
        catch(Exception ex)
        {
            if (_setPlayerNameRetries >= MaxSetPlayerNameRetries)
            {
                Log.Error($"Error: Failed to capture player's name after {MaxSetPlayerNameRetries} retries. Giving up until next login. " + ex);
                return;
            }

            _setPlayerNameRetries++;
            Log.Error($"Error: Failed to capture player's name - retry {_setPlayerNameRetries}/{MaxSetPlayerNameRetries} in 30 seconds. " + ex);
            _setPlayerNamePending = true;
            Timer t = new()
            {
                Interval = 30000,
                AutoReset = false
            };
            t.Elapsed += delegate
            {
                _setPlayerNamePending = false;
                t.Enabled = false;
                t.Dispose();
                SetPlayerName();
            };
            t.Enabled = true;
        }
    }

    private void BlockedCountUpdate()
    {
        Configuration.TtlMessagesBlocked += (ulong)Interlocked.Exchange(ref _sessionBlockedMessages, 0);
        Configuration.Save();
    }

    private unsafe void BetterCommendationsUpdate(bool printMessage = true)
    {
        try
        {
            PlayerState* player = PlayerState.Instance();
            if (player == null)
            {
                Log.Error("PlayerState was null, something went wrong");
                return;
            }

            TidyStrings.CommendationsEarned = player->PlayerCommendations;
        }
        catch(Exception ex)
        {
            Log.Error(ex, "Failed to improve Commendations message");
        }

        int commendationChange = TidyStrings.CommendationsEarned - TidyStrings.LastCommendations;
        TidyStrings.LastCommendations = TidyStrings.CommendationsEarned;

        if (printMessage && commendationChange is >= 1 and <= 7)
        {
            SeStringBuilder stringBuilder = new();
            if (Configuration.IncludeChatTag) Better.AddTidyChatTag(stringBuilder);

            string? commendations = commendationChange == 1
                ? Languages.BetterStrings_CommendationSingular
                : Languages.BetterStrings_CommendationsPlural;

            string dutyName =
                $"{(Configuration.IncludeDutyNameInComms && TidyStrings.LastDuty.Length > 0 ? " " + Languages.BetterStrings_CommendationsFromCompletingDuty + " " + TidyStrings.LastDuty + "." : ".")}";

            stringBuilder.AddText(
                string.Format(CultureInfo.CurrentCulture, Languages.BetterStrings_ReceivedCommendationsMessages, commendationChange.ToString(CultureInfo.CurrentCulture), commendations, dutyName));

            ChatGui.Print(stringBuilder.BuiltString);
        }
    }

    private static void LoadFishingFlavorMessages()
    {
        var messages = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        try
        {
            // Load Fisher's Intuition flavor text from FishingSpot sheet.
            // BigFishOnReach   = message shown when a big fish becomes catchable (Fisher's Intuition activates)
            // BigFishOnEnd     = message shown when the big fish window expires
            // BigFishOnRefresh = message shown when the window refreshes
            foreach(FishingSpot row in DataManager.GetExcelSheet<FishingSpot>())
            {
                string reach = $"{row.BigFishOnReach}".Trim();
                string end = $"{row.BigFishOnEnd}".Trim();
                string refresh = $"{row.BigFishOnRefresh}".Trim();

                if (!string.IsNullOrWhiteSpace(reach)) messages.Add(reach);
                if (!string.IsNullOrWhiteSpace(end)) messages.Add(end);
                if (!string.IsNullOrWhiteSpace(refresh)) messages.Add(refresh);
            }
        }
        catch(Exception ex)
        {
            Log.Error("Failed to load fishing flavor messages from FishingSpot: " + ex);
        }

        try
        {
            // Load per-fish lure flavor text from FishParameter sheet.
            // Unknown_70_1/2/3 are three lure flavor message variants per fish entry,
            // added in patch 7.0 (Dawntrail). They appear in the Gathering channel when
            // a lure (Versatile/Ambitious/Modest Lure) is used at a compatible fishing spot.
            foreach(FishParameter row in DataManager.GetExcelSheet<FishParameter>())
            {
                string lure1 = $"{row.Unknown_70_1}".Trim();
                string lure2 = $"{row.Unknown_70_2}".Trim();
                string lure3 = $"{row.Unknown_70_3}".Trim();

                if (!string.IsNullOrWhiteSpace(lure1)) messages.Add(lure1);
                if (!string.IsNullOrWhiteSpace(lure2)) messages.Add(lure2);
                if (!string.IsNullOrWhiteSpace(lure3)) messages.Add(lure3);
            }
        }
        catch(Exception ex)
        {
            Log.Error("Failed to load lure flavor messages from FishParameter: " + ex);
        }

        FishingFlavorMessages = messages;
        Log.Information($"Loaded {FishingFlavorMessages.Count} fishing flavor messages.");
    }

    private static void LoadTomestones()
    {
        List<TomestoneInfo> tomestones = new();
        try
        {
            // Each Tomestones slot (Poetics / capped / weekly-capped) accumulates retired tomestones over patches.
            // Take the highest TomestonesItem RowId per slot — that’s the currently active one for that slot.
            Dictionary<uint, (uint RowId, string Name)> bestPerSlot = new();
            foreach(TomestonesItem row in DataManager.GetExcelSheet<TomestonesItem>())
            {
                uint slotId = row.Tomestones.RowId;
                if (slotId == 0) continue;
                string name = $"{row.Item.Value.Name}";
                if (string.IsNullOrWhiteSpace(name)) continue;
                if (!bestPerSlot.TryGetValue(slotId, out (uint RowId, string Name) existing) || row.RowId > existing.RowId)
                    bestPerSlot[slotId] = (row.RowId, name);
            }
            foreach((uint rowId, string name) in bestPerSlot.Values)
                tomestones.Add(new(rowId, name));
        }
        catch(Exception ex)
        {
            Log.Error("Failed to load tomestone data from Lumina: " + ex);
        }
        Tomestones = tomestones.AsReadOnly();
        Log.Information($"Loaded {Tomestones.Count} tomestones: {string.Join(", ", Tomestones.Select(t => t.Name))}");
    }

    private static bool ChannelIsSpammy(ChatType chatType)
    {
        return chatType switch
        {
            ChatType.System or
                ChatType.StandardEmote or
                ChatType.CustomEmote or
                ChatType.Crafting or
                ChatType.Gathering or
                ChatType.GatheringSystem or
                ChatType.LootNotice or
                ChatType.LootRoll or
                ChatType.Progress or
                ChatType.FreeCompanyLoginLogout or
                ChatType.Echo => true,
            _ => false
        };
    }

    private static bool ChannelCanBeFiltered(ChatType chatType)
    {
        // Every spammy channel is filterable, plus player/social/error channels.
        if (ChannelIsSpammy(chatType)) return true;
        return chatType switch
        {
            ChatType.Error or
                ChatType.Say or ChatType.Shout or ChatType.Yell or
                ChatType.TellIncoming or ChatType.PvpTeam or
                ChatType.NoviceNetwork or ChatType.NoviceNetworkSystem or
                ChatType.FreeCompany or ChatType.PeriodicRecruitmentNotification or
                ChatType.Party or ChatType.CrossParty or ChatType.Alliance or
                ChatType.Linkshell1 or ChatType.Linkshell2 or ChatType.Linkshell3 or
                ChatType.Linkshell4 or ChatType.Linkshell5 or ChatType.Linkshell6 or
                ChatType.Linkshell7 or ChatType.Linkshell8 or
                ChatType.CrossLinkshell1 or ChatType.CrossLinkshell2 or ChatType.CrossLinkshell3 or
                ChatType.CrossLinkshell4 or ChatType.CrossLinkshell5 or ChatType.CrossLinkshell6 or
                ChatType.CrossLinkshell7 or ChatType.CrossLinkshell8 or
                ChatType.Orchestrion => true,
            _ => false
        };
    }

    private static SeString SmolMessage(SeString msg)
    {
        List<Payload> payloads = msg.Payloads;
        SeStringBuilder stringBuilder = new();
        payloads.ForEach(payload =>
        {
            if (payload.Type is not PayloadType.RawText)
            {
                stringBuilder.Add(payload);
            }
            else if (payload is TextPayload { Text: not null } textPayload)
            {
                var sb = new StringBuilder(textPayload.Text.Length);
                foreach(int i in textPayload.Text)
                {
                    sb.Append(i is >= 65 and <= 90
                        ? (char)(i + 32)  // 65='A', 90='Z' (91='[', not a letter)
                        : (char)i);
                }
                stringBuilder.AddText(sb.ToString());
            }
        });
        msg = stringBuilder.Build();
        msg.EncodeWithNullTerminator();
        return msg;
    }

    private static SeString DeblockMessage(SeString msg)
    {
        List<Payload> payloads = msg.Payloads;
        SeStringBuilder stringBuilder = new();
        payloads.ForEach(payload =>
        {
            if (payload.Type is not PayloadType.RawText)
            {
                stringBuilder.Add(payload);
            }
            else if (payload is TextPayload { Text: not null } textPayload)
            {
                var sb = new StringBuilder(textPayload.Text.Length);
                foreach(int i in textPayload.Text)
                {
                    char c = i switch
                    {
                        >= 57457 and <= 57483 => (char)(i - 57392), // A-Z Blocks
                        >= 57487 and <= 57496 => (char)(i - 57439), // Number Blocks
                        >= 57521 and <= 57529 => (char)(i - 57472), // Hexgonical Numbers
                        >= 57440 and <= 57449 => (char)(i - 57392), // Monospace Numbers
                        _ => (char)i
                    };
                    sb.Append(c);
                }
                stringBuilder.AddText(sb.ToString());
            }
        });
        msg = stringBuilder.Build();
        msg.EncodeWithNullTerminator();
        return msg;
    }

    public static IDtrBarEntry GetDtrBar() => DtrBar.Get(TidyStrings.PluginName);

    private static void DelayedInstanceDtrBarUpdate(Configuration configuration)
    {
        Timer t = new()
        {
            Interval = 1000,
            AutoReset = false
        };
        t.Elapsed += delegate
        {
            t.Enabled = false;
            t.Dispose();
            InstanceDtrBarUpdate(configuration);
        };
        t.Enabled = true;
    }

    public unsafe static void InstanceDtrBarUpdate(Configuration configuration)
    {
        DtrEntry ??= GetDtrBar();
        DtrEntry.Tooltip = "TidyChat";

        if (!configuration.InstanceInDtrBar)
        {
            DtrEntry.Shown = false;
            DtrEntry.Text = string.Empty;
            return;
        }
        try
        {
            UIState* uiState = UIState.Instance();
            if (uiState == null)
            {
                DtrEntry.Shown = false;
                DtrEntry.Text = string.Empty;
                return;
            }

            // This will return the instance value: 0,1,2,3,4,5,6
            int instanceNumberFromSignature = (int)uiState->PublicInstance.InstanceId;
            string instanceCharacter = ((char)(SeIconChar.Instance1 + (byte)(instanceNumberFromSignature - 1))).ToString();

            DtrEntry.Text = instanceNumberFromSignature switch
            {
                >= 1 => $"{L10N.GetTidy(TidyStrings.InstanceWord)} {instanceCharacter}",
                _ => string.Empty
            };
            DtrEntry.Shown = instanceNumberFromSignature >= 1;
        }
        catch(Exception ex)
        {
            Log.Error("Error: Failed to update Instance for DtrBarEntry - " + ex);
        }
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

    #region Chat2 ChatTypes

    // Stole this region from Anna's Chat2: https://git.annaclemens.io/ascclemens/ChatTwo/src/branch/main/ChatTwo
    private const ushort Clear7 = ~(~0 << 7);

    private static ChatType FromCode(ushort code) => (ChatType)(code & Clear7);

    private static ChatType FromDalamud(XivChatType type) => FromCode((ushort)type);

    #endregion Chat2 ChatTypes
}
