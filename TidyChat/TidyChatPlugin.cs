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

        Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Configuration.Initialize(PluginInterface);
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
    private void OnLogin()
    {
        L10N.Language = ClientState.ClientLanguage;
        ReloadGameDataCaches(validateRuleIds: false);
        if (Configuration.BetterCommendationMessage) BetterCommendationsUpdate(printMessage: false);
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
        catch
        {
            /* non-critical — default 0 means "not a duty" */
        }

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
        Rules.UpdateIsActiveStates(Configuration);

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
                    if (id == message.LogMessageId)
                    {
                        idMatches = true;
                        break;
                    }
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
                    RememberLogMessageTexts(_allowedByLogMessage, text);
                    RememberLogMessageAllow(message.LogMessageId);
                }
                catch
                {
                    /* non-critical */
                }
                if (Configuration.EnableDebugMode)
                    Log.Debug($"[LogMessage] ALLOWED by custom filter \"{entry.FirstName}\" (ID: {message.LogMessageId})");
                return;
            }
        }

        if (!Rules.LogMessageIdToRules.TryGetValue(message.LogMessageId, out IReadOnlyList<LocalizedFilterRule>? matchingRules))
        {
            if (Configuration.EnableDebugMode && _loggedUnmatchedLogMessageIds.Add(message.LogMessageId))
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
            if (!rule.ShouldBlock) continue;

            // Shared LogMessage templates may need a text check (e.g. 657 "You obtain .").
            if (rule.Pattern != PatternKind.None &&
                (!TryGetNormalizedLogMessageText(message, out string normalizedText) ||
                 !RuleMatchesText(rule, normalizedText, Configuration.EnableDebugMode)))
            {
                if (Configuration.EnableDebugMode)
                    Log.Debug($"[LogMessage] ID {message.LogMessageId} matched {rule.Name} but text check failed");
                continue;
            }

            if (Configuration.EnableDebugMode)
            {
                Log.Debug($"[LogMessage] BLOCKED by {rule.Name} (ID: {message.LogMessageId})");
                // In debug mode, don't suppress — let OnChat display it with [Blocked] prefix.
                try
                {
                    string text = message.FormatLogMessageForDebugging().ExtractText();
                    RememberLogMessageTexts(_blockedByLogMessage, text);
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

        // Track the allowed text so OnChat doesn't re-block this message.
        try
        {
            string text = message.FormatLogMessageForDebugging().ExtractText();
            RememberLogMessageTexts(_allowedByLogMessage, text);
            RememberLogMessageAllow(message.LogMessageId);
        }
        catch
        {
            /* Safe to ignore — worst case OnChat re-evaluates the message */
        }

        if (Configuration.EnableDebugMode)
        {
            string ruleNames = string.Join(", ", matchingRules.Select(r => r.Name).Distinct(StringComparer.Ordinal));
            Log.Debug($"[LogMessage] ALLOWED (ID: {message.LogMessageId}, Rules: {ruleNames})");
        }
    }

    private void OnChat(IHandleableChatMessage message)
    {
        if (!Configuration.Enabled)
        {
            Log.Verbose("Tidy Chat is not enabled");
            return;
        }
        if (message.IsHandled) return;

        ChatType chatType = FromDalamud(message.LogKind);
        string normalizedText = NormalizeInput.ToLowercase(message.Message);
        string rawTextValue = message.Message.TextValue;
        string extractedTextValue;
        try { extractedTextValue = new ReadOnlySeString(message.Message.Encode()).ExtractText(); }
        catch { extractedTextValue = rawTextValue; }
        if (Configuration.PlayerName != "") normalizedText = NormalizeInput.ReplaceName(normalizedText, Configuration);

        // Each handler returns true if OnChat should stop processing.
        // Respect OnLogMessage allow/block before server-announcement filtering (#122 / open issue #1).
        if (CheckLogMessageDecision(message, chatType, rawTextValue, extractedTextValue, normalizedText)) return;
        if (IsProtectedByActiveShowRule(chatType, normalizedText, out List<string> protectingRules))
        {
            if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                message.Message = BuildDebugString(chatType, message.Message, protectingRules, Configuration.DebugIncludeChannel, false);
            return;
        }
        if (HandleServerAnnouncements(message, chatType, normalizedText)) return;
        if (!ChannelCanBeFiltered(chatType)) return;
        if (HandleEmoteFilters(message, chatType)) return;
        if (HandleTemporaryFilterDisables(normalizedText)) return;
        if (HandleBetterMessages(message, chatType, normalizedText)) return;

        bool? channelResult = EvaluateChannelRules(message, chatType, normalizedText, out List<string> rulesMatched);
        if (channelResult is null) return; // null sentinel: EvaluateChannelRules handled the early-return internally
        bool isHandled = channelResult.Value;
        ApplyFilterOverrides(message, chatType, normalizedText, ref isHandled);
        ApplyWhitelist(message, chatType, ref isHandled);
        if (CheckChatHistory(message, chatType, ref isHandled)) return;

        if (chatType is ChatType.Echo) isHandled = false;

        if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
        {
            if (Configuration.DebugIncludeChannel || isHandled)
                message.Message = BuildDebugString(chatType, message.Message, rulesMatched, Configuration.DebugIncludeChannel, isHandled);
            isHandled = false;
        }

        if (isHandled)
        {
            Interlocked.Increment(ref _sessionBlockedMessages);
            message.PreventOriginal();
        }
    }

    /// <summary>Filters login and world-travel server announcements (#122). Returns true when fully handled.</summary>
    private bool HandleServerAnnouncements(IHandleableChatMessage message, ChatType chatType, string normalizedText)
    {
        if (Configuration.ServerAnnouncementMode == ServerAnnouncementMode.ShowAll) return false;

        bool isWorldGreeting = ServerAnnouncementCatalog.IsWorldGreeting(normalizedText);
        bool isAnnouncement = ServerAnnouncementCatalog.IsAnnouncement(normalizedText);
        if (!isWorldGreeting && !isAnnouncement) return false;

        bool isPhishing = ServerAnnouncementCatalog.IsPhishingWarning(normalizedText);
        // Login announcements usually use System; some clients also deliver them on Notice/Urgent (#24).
        if (chatType is not ChatType.System && chatType is not ChatType.Notice and not ChatType.Urgent)
            return false;

        bool withinLoginWindow = DateTime.UtcNow < _serverAnnouncementLoginGraceEnd;
        bool suppress = Configuration.ServerAnnouncementMode switch
        {
            ServerAnnouncementMode.HideAll => true,
            ServerAnnouncementMode.Condensed => !isWorldGreeting,
            ServerAnnouncementMode.LoginOnly => !withinLoginWindow,
            ServerAnnouncementMode.LoginThenCondensed => !withinLoginWindow && !isWorldGreeting,
            ServerAnnouncementMode.HidePhishing => isPhishing,
            _ => false
        };
        if (suppress)
        {
            if (Configuration.EnableDebugMode)
            {
                Log.Debug($"BLOCKED (server announcement): {message.Message}");
                if (!message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                    message.Message = BuildDebugString(chatType, message.Message, ["ServerAnnouncement"], Configuration.DebugIncludeChannel, true);
                return true;
            }
            message.PreventOriginal();
            Interlocked.Increment(ref _sessionBlockedMessages);
            return true;
        }

        if (Configuration.EnableDebugMode)
        {
            if (!message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                message.Message = BuildDebugString(chatType, message.Message, ["ServerAnnouncement"], Configuration.DebugIncludeChannel, false);
            return true;
        }

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
        return true;
    }

    /// <summary>Handles emote channel filtering. Returns true when fully handled.</summary>
    private bool HandleEmoteFilters(IHandleableChatMessage message, ChatType chatType)
    {
        // Unfiltered emote channels — only whitelist Block rules apply.
        if ((chatType is ChatType.StandardEmote && !Configuration.FilterEmoteChannel) ||
            (chatType is ChatType.CustomEmote && !Configuration.FilterCustomEmoteChannel))
        {
            if (IsWhitelistedBlocked(message.Sender, message.Message, chatType))
            {
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
            }
            return true;
        }

        // Block other players' custom emotes unless whitelisted.
        if (!Configuration.ShowOtherCustomEmotes &&
            !string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal) &&
            chatType is ChatType.CustomEmote)
        {
            if (!IsWhitelistedAllowed(message.Sender, message.Message, chatType))
            {
                if (Configuration.EnableDebugMode) Log.Verbose($"Filtered an emote: {message.Message}");
                message.PreventOriginal();
                Interlocked.Increment(ref _sessionBlockedMessages);
            }
            return true;
        }

        return false;
    }

    /// <summary>Turns off system filtering briefly for /? help and party-join messages. Returns true when disabled.</summary>
    private bool HandleTemporaryFilterDisables(string normalizedText)
    {
        if (L10N.Get(ChatRegexStrings.QuestionMarkCommandResponse).IsMatch(normalizedText) && Configuration.FilterSystemMessages)
        {
            Better.TemporarilyDisableSystemFilter(Configuration);
            return true;
        }

        if (L10N.Get(ChatStrings.JoinParty).All(normalizedText.Contains) && Configuration.ShowJoinParty &&
            Configuration is { ShowPartyInformation: true, FilterSystemMessages: true })
        {
            Better.TemporarilyDisableSystemFilter(Configuration);
            return true;
        }

        return false;
    }

    /// <summary>Runs Better Messages rewrites. Returns true when the message is done and needs no further filtering.</summary>
    private bool HandleBetterMessages(IHandleableChatMessage message, ChatType chatType, string normalizedText)
    {
        if (Configuration.BetterInstanceMessage && chatType is ChatType.System &&
            LogMessageCatalog.MatchesWithFallback(1350, normalizedText, ChatStrings.InstancedArea))
        {
            message.Message = Better.Instances(message.Message, Configuration);
            if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate(Configuration);
            return true;
        }

        if (Configuration.BetterCommendationMessage && chatType is ChatType.System &&
            LogMessageCatalog.MatchesWithFallback(926, normalizedText, ChatStrings.PlayerCommendation))
        {
            message.PreventOriginal();
            Interlocked.Increment(ref _sessionBlockedMessages);
            return true;
        }

        if (Configuration.BetterSayReminder &&
            chatType is ChatType.System &&
            L10N.Get(ChatStrings.SayQuestReminder).All(normalizedText.Contains))
        {
            message.Message = Better.SayReminder(message.Message, Configuration);
            return true;
        }

        if (Configuration.BetterTreasureDungeonMessage && chatType is ChatType.System)
        {
            if (L10N.Get(ChatRegexStrings.ChamberOpens).IsMatch(normalizedText))
            {
                Match match = L10N.Get(ChatRegexStrings.ChamberOpens).Match(normalizedText);
                if (match.Groups["chamber"].Success)
                    TidyStrings.LastTreasureDungeonChamber = match.Groups["chamber"].Value;
                return true;
            }
            if (L10N.Get(ChatRegexStrings.TrapTriggered).IsMatch(normalizedText))
            {
                if (TidyStrings.LastTreasureDungeonChamber.Length > 0)
                    message.Message = Better.TreasureDungeon(Configuration);
                return true;
            }
        }

        // Non-early-return transformations: deblock and smol still need filtering afterward.
        if (Configuration.NormalizeBlocks &&
            (Configuration.AlwaysNormalizeBlocks || chatType is not ChatType.Party and not ChatType.Alliance))
            message.Message = DeblockMessage(message.Message);

        if (Configuration.EnableSmolMode)
            message.Message = SmolMessage(message.Message);

        return false;
    }

    /// <summary>Applies an earlier OnLogMessage allow/block decision. Returns true when handled.</summary>
    private bool CheckLogMessageDecision(IHandleableChatMessage message, ChatType chatType, string rawTextValue, string extractedTextValue, string normalizedText)
    {
        string[] textCandidates = [rawTextValue, extractedTextValue, normalizedText];

        bool wasBlockedByLog;
        lock(_logMessageLock)
        {
            wasBlockedByLog = _blockedByLogMessage.Count > 0 &&
                              TryRemoveFromLogMessageSet(_blockedByLogMessage, textCandidates);
        }
        if (wasBlockedByLog)
        {
            if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                message.Message = BuildDebugString(chatType, message.Message, ["LogMessage"], Configuration.DebugIncludeChannel, true);
            return true;
        }

        bool wasAllowedByLog;
        lock(_logMessageLock)
        {
            wasAllowedByLog = _allowedByLogMessage.Count > 0 &&
                              TryRemoveFromLogMessageSet(_allowedByLogMessage, textCandidates);
        }
        if (wasAllowedByLog)
        {
            if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                message.Message = BuildDebugString(chatType, message.Message, ["LogMessage"], Configuration.DebugIncludeChannel, false);
            return true;
        }

        if (TryConsumePendingLogMessageAllow(normalizedText))
        {
            if (Configuration.EnableDebugMode && !message.Message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
                message.Message = BuildDebugString(chatType, message.Message, ["LogMessage"], Configuration.DebugIncludeChannel, false);
            return true;
        }

        return false;
    }

    /// <summary>
    ///     True when an enabled Show rule matches this text, so server announcement filtering must leave it alone.
    /// </summary>
    private bool IsProtectedByActiveShowRule(ChatType chatType, string normalizedText, out List<string> protectingRules)
    {
        protectingRules = [];
        Rules.UpdateIsActiveStates(Configuration);
        foreach(LocalizedFilterRule rule in Rules.AllRules)
        {
            if (rule.ShouldBlock) continue;
            if (chatType != rule.Channel && chatType is not ChatType.Echo) continue;
            if (rule.Pattern == PatternKind.None) continue;
            if (RuleMatchesText(rule, normalizedText, false))
                protectingRules.Add(rule.Name);
        }

        return protectingRules.Count > 0;
    }

    private void RememberLogMessageTexts(HashSet<string> target, string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return;

        lock(_logMessageLock)
        {
            if (target.Count >= MaxLogMessageSetSize) target.Clear();
            target.Add(text);
            string trimmed = text.Trim();
            if (trimmed.Length > 0) target.Add(trimmed);
            string lower = trimmed.ToLower(CultureInfo.CurrentCulture);
            if (lower.Length > 0) target.Add(lower);
        }
    }

    private void RememberLogMessageAllow(uint logMessageId)
    {
        lock(_logMessageLock)
        {
            _pendingAllowedLogMessageIds.TryGetValue(logMessageId, out int count);
            _pendingAllowedLogMessageIds[logMessageId] = count + 1;
        }
    }

    private bool TryConsumePendingLogMessageAllow(string normalizedText)
    {
        if (string.IsNullOrWhiteSpace(normalizedText)) return false;

        lock(_logMessageLock)
        {
            if (_pendingAllowedLogMessageIds.Count == 0) return false;

            uint[] pendingIds = _pendingAllowedLogMessageIds.Keys.ToArray();
            foreach(uint id in pendingIds)
            {
                if (!_pendingAllowedLogMessageIds.TryGetValue(id, out int count) || count <= 0) continue;
                if (!PendingLogMessageTextMatches(id, normalizedText)) continue;

                if (count == 1) _pendingAllowedLogMessageIds.Remove(id);
                else _pendingAllowedLogMessageIds[id] = count - 1;
                return true;
            }
        }

        return false;
    }

    private static bool PendingLogMessageTextMatches(uint logMessageId, string normalizedText)
    {
        if (LogMessageCatalog.IsLoaded && LogMessageCatalog.HasTemplate(logMessageId) &&
            LogMessageCatalog.Matches(logMessageId, normalizedText))
            return true;

        if (!Rules.LogMessageIdToRules.TryGetValue(logMessageId, out IReadOnlyList<LocalizedFilterRule>? matchingRules))
            return false;

        foreach(LocalizedFilterRule rule in matchingRules)
        {
            if (rule.Pattern == PatternKind.None) continue;
            if (RuleMatchesText(rule, normalizedText, false)) return true;
        }

        return false;
    }

    private static bool TryRemoveFromLogMessageSet(HashSet<string> target, IReadOnlyList<string> candidates)
    {
        foreach(string candidate in candidates)
        {
            if (string.IsNullOrWhiteSpace(candidate)) continue;
            if (target.Remove(candidate)) return true;

            string trimmed = candidate.Trim();
            if (trimmed.Length > 0 && target.Remove(trimmed)) return true;

            string lower = trimmed.ToLower(CultureInfo.CurrentCulture);
            if (lower.Length > 0 && target.Remove(lower)) return true;
        }

        return false;
    }

    /// <summary>
    ///     Runs channel filter rules. Returns <c>isHandled</c>, or null when channel filtering is off
    ///     and the caller should return immediately.
    /// </summary>
    private bool? EvaluateChannelRules(IHandleableChatMessage message, ChatType chatType, string normalizedText, out List<string> rulesMatched)
    {
        rulesMatched = [];
        Rules.UpdateIsActiveStates(Configuration);
        LocalizedFilterRule[] rules = Rules.AllRules;

        bool isBlocked = ChannelIsSpammy(chatType);

        // Skip filtering if channel filter is disabled — only whitelist Block rules apply.
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
            return null; // sentinel: caller should return immediately
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

        List<string>? rulesSkipped = Configuration.EnableDebugMode ? [] : null;
        List<string>? rulesFailed = Configuration.EnableDebugMode ? [] : null;
        foreach(LocalizedFilterRule rule in rules)
        {
            if (rule.Error is not null) Log.Error($"Error: {rule.Error}");

            if (rule.LogMessageIds is not null && rule.Pattern == PatternKind.None)
            {
                if (Configuration.EnableDebugMode) Log.Verbose($"SKIPPING CHECK: {rule.Name} handled by LogMessage ID");
                rulesSkipped?.Add(rule.Name);
                continue;
            }
            if (rule.IsActive == showEverythingElse)
            {
                if (Configuration.EnableDebugMode) Log.Verbose($"SKIPPING CHECK: {rule.Name} is {(showEverythingElse ? "active" : "inactive")}");
                rulesSkipped?.Add(rule.Name);
                continue;
            }
            if (chatType != rule.Channel && chatType is not ChatType.Echo)
            {
                if (Configuration.EnableDebugMode) Log.Verbose($"SKIPPING CHECK: Message was sent to {chatType} but the rule's filter is for {rule.Channel}");
                rulesSkipped?.Add(rule.Name);
                continue;
            }

            if (rule.Channel == ChatType.Echo)
            {
                if (RuleMatchesText(rule, normalizedText, Configuration.EnableDebugMode))
                    rulesMatched.Add(rule.Name);
                else if (Configuration.EnableDebugMode)
                    Log.Debug("/echo message failed to match any rules");
                continue;
            }

            if (RuleMatchesText(rule, normalizedText, Configuration.EnableDebugMode))
            {
                rulesMatched.Add(rule.Name);
                isBlocked = rule.BlockWhenActive
                    ? chatType is ChatType.LootNotice || !defaultBlocked
                        ? !defaultBlocked
                        : defaultBlocked
                    : !defaultBlocked;
            }
            else
            {
                rulesFailed?.Add(rule.Name);
            }
        }

        bool isHandled = chatType is ChatType.LootNotice ? !isBlocked : isBlocked;

        if (Configuration.EnableDebugMode && (rulesMatched.Count > 0 || isHandled))
        {
            Log.Debug($"{rulesMatched.Count} Rules Matched: {string.Join(", ", rulesMatched)}");
            if (rulesSkipped!.Count > 0)
                Log.Debug($"{rulesSkipped.Count} Rules Skipped: {string.Join(", ", rulesSkipped)}");
            if (rulesFailed!.Count > 0)
                Log.Debug($"{rulesFailed.Count} Rules Failed: {string.Join(", ", rulesFailed)}");
            Log.Debug($"{(isHandled ? "BLOCKED" : "ALLOWED")}: {message.Message}");
        }

        return isHandled;
    }

    /// <summary>Post-rule overrides for self emotes, party-only loot rolls, fishing flavor, and tomestones.</summary>
    private void ApplyFilterOverrides(IHandleableChatMessage message, ChatType chatType, string normalizedText, ref bool isHandled)
    {
        if (chatType is ChatType.CustomEmote &&
            string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
        {
            if (Configuration.EnableDebugMode) Log.Information("Allowing custom emote used by player");
            isHandled = false;
        }

        if (!Configuration.ShowSelfUsedEmotes &&
            chatType is ChatType.StandardEmote or ChatType.CustomEmote &&
            string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
            isHandled = true;

        if (chatType is ChatType.LootRoll && !isHandled &&
            Configuration.ShowOnlyPartyMemberRolls && PartyList.Length > 0)
        {
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

        if (chatType is ChatType.Gathering && isHandled && Configuration.ShowFishingFlavorText &&
            FishingFlavorMessages.Count > 0 && FishingFlavorMessages.Contains(normalizedText))
        {
            if (Configuration.EnableDebugMode) Log.Debug($"ALLOWED (fishing flavor): {message.Message}");
            isHandled = false;
        }

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
    }

    /// <summary>Runs whitelist Allow/Block rules. Allow pass runs after Block so Allow wins ties.</summary>
    private void ApplyWhitelist(IHandleableChatMessage message, ChatType chatType, ref bool isHandled)
    {
        if (Configuration.Whitelist.Count == 0) return;
        try
        {
            foreach(PlayerName p in Configuration.Whitelist)
            {
                if (!p.AllowMessage)
                    CustomFilterCheck(message.Sender, message.Message, ref isHandled, p, chatType);
            }
            foreach(PlayerName p in Configuration.Whitelist)
            {
                if (p.AllowMessage)
                    CustomFilterCheck(message.Sender, message.Message, ref isHandled, p, chatType);
            }
        }
        catch(Exception ex)
        {
            Log.Error("Error: Failed to evaluate Whitelist - " + ex);
        }
    }

    /// <summary>Suppresses duplicate chat lines. Returns true when OnChat should stop.</summary>
    private bool CheckChatHistory(IHandleableChatMessage message, ChatType chatType, ref bool isHandled)
    {
        if (!Configuration.ChatHistoryFilter || isHandled) return false;
        try
        {
            if (Configuration.DisableSelfChatHistory &&
                string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
                return true;

            var historyChannels = (ChatFlags.Channels)Configuration.ChatHistoryChannels;
            if (historyChannels.Equals(ChatFlags.Channels.None)) return false;
            if (!Flags.CheckFlags(Configuration, chatType)) return false;

            string currentMessage = $"{message.Sender.TextValue}: {message.Message.TextValue}";
            lock(_chatHistoryLock)
            {
                if (Configuration.ChatHistoryTimer > 0)
                {
                    long now = Environment.TickCount64;
                    while(_chatHistory.Count > 0 && _chatHistory.Peek().ExpiresAtTicks <= now)
                        _chatHistory.Dequeue();
                }

                bool isDuplicate = false;
                foreach((string Message, long ExpiresAtTicks) entry in _chatHistory)
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
                        Log.Verbose("Chat history reached limit. Removed oldest message and added:" + currentMessage);
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
            return true; // chat history always returns after processing
        }
        catch(Exception ex)
        {
            Log.Error("Error: Failed to handle Chat History - " + ex);
            return false;
        }
    }

    private static bool TryGetNormalizedLogMessageText(ILogMessage message, out string normalizedText)
    {
        normalizedText = string.Empty;
        try
        {
            normalizedText = message.FormatLogMessageForDebugging().ExtractText()
                .ToLower(CultureInfo.CurrentCulture);
            return normalizedText.Length > 0;
        }
        catch
        {
            return false;
        }
    }

    private static bool RequiresLogMessageCatalog(LocalizedFilterRule rule) =>
        rule.PreferLogMessageCatalog && rule.LogMessageIds is { Length: > 0 };

    private static bool LogMessageCatalogMatches(LocalizedFilterRule rule, string normalizedText) =>
        RequiresLogMessageCatalog(rule) &&
        LogMessageCatalog.IsLoaded &&
        LogMessageCatalog.MatchesAny(rule.LogMessageIds!, normalizedText);

    private static bool RuleHasTextChecks(LocalizedFilterRule rule) =>
        rule.Pattern switch
        {
            PatternKind.StringMatch => rule.StringChecks is not null,
            PatternKind.RegexMatch => rule.RegexChecks is not null,
            _ => false
        };

    /// <summary>
    ///     When PreferLogMessageCatalog is set but the Lumina template misses, fall back to
    ///     <see cref="LocalizedFilterRule.StringChecks" /> or <see cref="LocalizedFilterRule.RegexChecks" />.
    /// </summary>
    private static bool ShouldFallbackToTextChecksWhenCatalogMisses(LocalizedFilterRule rule) =>
        RuleHasTextChecks(rule);

    /// <summary>
    ///     True when every regex or string check on the rule matches <paramref name="normalizedText" /> (AND logic).
    ///     False when the rule has no checks or any check fails.
    /// </summary>
    private static bool RuleMatchesText(LocalizedFilterRule rule, string normalizedText, bool debugMode)
    {
        if (TryMatchObtainMarkerRule(rule, normalizedText, debugMode, out bool obtainMatched))
            return obtainMatched;

        bool requiresCatalog = RequiresLogMessageCatalog(rule);
        bool catalogMatched = LogMessageCatalogMatches(rule, normalizedText);
        bool allowTextFallback = requiresCatalog && !catalogMatched &&
                                 ShouldFallbackToTextChecksWhenCatalogMisses(rule);

        switch (rule.Pattern)
        {
            case PatternKind.RegexMatch:
                if (rule.RegexChecks is null) return false;

                if (requiresCatalog && !catalogMatched && !allowTextFallback)
                {
                    if (debugMode) Log.Verbose($"FAILED: {rule.Name} | LUMINA LogMessage catalog");
                    return false;
                }

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

                if (catalogMatched && debugMode)
                    Log.Debug($"MATCHED: {rule.Name} | LUMINA LogMessage catalog");
                return true;
            case PatternKind.StringMatch:
                if (rule.StringChecks is null) return false;

                if (requiresCatalog && !catalogMatched && !allowTextFallback)
                {
                    if (debugMode) Log.Verbose($"FAILED: {rule.Name} | LUMINA LogMessage catalog");
                    return false;
                }

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

                if (catalogMatched && debugMode)
                    Log.Debug($"MATCHED: {rule.Name} | LUMINA LogMessage catalog");
                return true;
            default:
                return false;
        }
    }

    private static bool TryMatchObtainMarkerRule(LocalizedFilterRule rule, string normalizedText, bool debugMode, out bool matched)
    {
        matched = false;
        if (!rule.PreferLogMessageCatalog) return false;

        bool isObtainMarkerRule = rule.ObtainMarkerAnySeal ||
                                  rule.ObtainMarkerAnyElemental ||
                                  rule.ObtainMarkerAnyTribal ||
                                  rule.ObtainMarkerMaterials ||
                                  rule.ObtainMarkerOtherPlayer ||
                                  rule.ObtainMarkerGil ||
                                  rule.ObtainMarkerMgp ||
                                  rule.ObtainMarkerItemId is not null;
        if (!isObtainMarkerRule) return false;

        if (rule.ExcludePlayerObtain && LogMessageCatalog.IsPlayerObtainMessage(normalizedText))
        {
            matched = false;
            return true;
        }

        LocalizedStrings? markerFallback = rule.StringChecks is { Count: > 0 } ? rule.StringChecks[0] : null;
        if (markerFallback is null && rule.ObtainMarkerAnySeal)
            markerFallback = ChatStrings.ObtainSealsMarker;
        else if (markerFallback is null && rule.ObtainMarkerClustersOnly)
            markerFallback = ChatStrings.ObtainClusterMarker;
        else if (markerFallback is null && rule.ObtainMarkerMaterials)
            markerFallback = ChatStrings.ObtainMaterialsMarker;
        else if (markerFallback is null && rule.ObtainMarkerOtherPlayer)
            markerFallback = ChatStrings.OtherObtainMarker;

        if (rule.ObtainMarkerOtherPlayer)
        {
            matched = LogMessageCatalog.MatchesOtherPlayerObtain(normalizedText, markerFallback);
            if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA other-player obtain marker");
            return true;
        }

        if (rule.ObtainMarkerMaterials)
        {
            matched = LogMessageCatalog.MatchesMaterialsObtain(
                normalizedText, markerFallback, rule.ObtainMarkerRequireSharedTemplate);
            if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA materials obtain marker");
            return true;
        }

        if (rule.ObtainMarkerAnyElemental)
        {
            matched = LogMessageCatalog.MatchesSharedObtainElemental(
                normalizedText, rule.ObtainMarkerClustersOnly, markerFallback, rule.ObtainMarkerRequireSharedTemplate);
            if (debugMode && matched)
                Log.Debug($"MATCHED: {rule.Name} | LUMINA {(rule.ObtainMarkerClustersOnly ? "cluster" : "elemental")} obtain marker");
            return true;
        }

        if (rule.ObtainMarkerAnyTribal)
        {
            matched = LogMessageCatalog.MatchesSharedObtainTribal(normalizedText, markerFallback);
            if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA tribal currency obtain marker");
            return true;
        }

        if (rule.ObtainMarkerAnySeal)
        {
            matched = LogMessageCatalog.MatchesSharedObtainSeal(normalizedText, markerFallback);
            if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA shared obtain + GC seal marker");
            return true;
        }

        if (rule.ObtainMarkerGil)
        {
            matched = LogMessageCatalog.MatchesSharedObtainGil(normalizedText, markerFallback);
            if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA shared obtain + gil marker");
            return true;
        }

        if (rule.ObtainMarkerMgp)
        {
            matched = LogMessageCatalog.MatchesSharedObtainMgp(normalizedText, markerFallback);
            if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA shared obtain + MGP marker");
            return true;
        }

        matched = LogMessageCatalog.MatchesSharedObtain(normalizedText, rule.ObtainMarkerItemId!.Value, markerFallback);
        if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA shared obtain + item marker");
        return true;
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
    ///     True when the whitelist entry matches sender, message text, and channel.
    ///     Handles empty-name guard, channel scoping, cached regex, and <see cref="PlayerNameMatchMode" />.
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

    /// <summary>True when a whitelist Allow entry would let this message through.</summary>
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

    /// <summary>True when a whitelist Block entry would suppress this message.</summary>
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
            string? commendations = commendationChange == 1
                ? Languages.BetterStrings_CommendationSingular
                : Languages.BetterStrings_CommendationsPlural;

            string dutyName =
                $"{(Configuration.IncludeDutyNameInComms && TidyStrings.LastDuty.Length > 0 ? " " + Languages.BetterStrings_CommendationsFromCompletingDuty + " " + TidyStrings.LastDuty + "." : ".")}";

            string summaryText = string.Format(
                CultureInfo.CurrentCulture,
                Languages.BetterStrings_ReceivedCommendationsMessages,
                commendationChange.ToString(CultureInfo.CurrentCulture),
                commendations,
                dutyName);

            SeString output;
            if (Configuration.EnableDebugMode)
            {
                SeStringBuilder debugBuilder = new();
                Better.AddTidyChatTag(debugBuilder);
                if (Configuration.DebugIncludeChannel)
                    Better.AddChannelTag(debugBuilder, ChatType.System);
                Better.AddAllowedTag(debugBuilder);
                Better.AddRuleTag(debugBuilder, ["BetterCommendationMessage"]);
                debugBuilder.AddText(summaryText);
                output = debugBuilder.BuiltString;
            }
            else
            {
                SeStringBuilder stringBuilder = new();
                if (Configuration.IncludeChatTag) Better.AddTidyChatTag(stringBuilder);
                stringBuilder.AddText(summaryText);
                output = stringBuilder.BuiltString;
            }

            ChatGui.Print(output);
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

    private void ReloadGameDataCaches(bool validateRuleIds)
    {
        LoadTomestones();
        LoadFishingFlavorMessages();
        LogMessageCatalog.Load(DataManager, Log);
        ItemMarkerCatalog.Load(DataManager, Log);
        ServerAnnouncementCatalog.Load(DataManager, Log);
        LogMessageCatalog.ApplyDiscoveries();
        Rules.RebuildLogMessageIdLookup();
        if (validateRuleIds)
            LogMessageCatalog.ValidateRuleIds(Rules.EnumerateReferencedLogMessageIds(), Log);
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
                ChatType.Say or
                ChatType.Shout or
                ChatType.Yell or
                ChatType.TellIncoming or
                ChatType.PvpTeam or
                ChatType.NoviceNetwork or
                ChatType.NoviceNetworkSystem or
                ChatType.FreeCompany or
                ChatType.PeriodicRecruitmentNotification or
                ChatType.Party or
                ChatType.CrossParty or
                ChatType.Alliance or
                ChatType.Linkshell1 or
                ChatType.Linkshell2 or
                ChatType.Linkshell3 or
                ChatType.Linkshell4 or
                ChatType.Linkshell5 or
                ChatType.Linkshell6 or
                ChatType.Linkshell7 or
                ChatType.Linkshell8 or
                ChatType.CrossLinkshell1 or
                ChatType.CrossLinkshell2 or
                ChatType.CrossLinkshell3 or
                ChatType.CrossLinkshell4 or
                ChatType.CrossLinkshell5 or
                ChatType.CrossLinkshell6 or
                ChatType.CrossLinkshell7 or
                ChatType.CrossLinkshell8 or
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
                        ? (char)(i + 32) // 65='A', 90='Z' (91='[', not a letter)
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
