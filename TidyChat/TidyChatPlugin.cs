global using Dalamud.Bindings.ImGui;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Timers;
using ChatTwo.Code;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Game.Command;
using Dalamud.Game.Gui.Dtr;
using Dalamud.Game.Chat;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using TidyChat.Localization.Resources;
using TidyChat.Utility;
using Better = TidyChat.Utility.BetterStrings;
using Flags = TidyChat.Utility.ChatFlags;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat;

public sealed class TidyChatPlugin : IDalamudPlugin
{
    [PluginService] public static IDataManager DataManager { get; private set; } = null!;
    [PluginService] public static IDtrBar DtrBar { get; private set; } = null!;
    [PluginService] public static ICommandManager CommandManager { get; private set; } = null!;
    [PluginService] public static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
    [PluginService] public static IClientState ClientState { get; private set; } = null!;
    [PluginService] public static IChatGui ChatGui { get; private set; } = null!;
    [PluginService] public static IObjectTable ObjectTable { get; private set; } = null!;
    [PluginService] public static ISigScanner SigScanner { get; private set; } = null!;
    [PluginService] public static IGameInteropProvider Hook { get; private set; } = null!;
    [PluginService] public static IPluginLog Log { get; private set; } = null!;
    private static IDtrBarEntry? DtrEntry { get; set; }

    public static IReadOnlyList<TomestoneInfo> Tomestones { get; private set; } = [];

    private Configuration Configuration { get; }
    private PluginUI PluginUi { get; }
    private readonly WindowSystem _windowSystem = new("TidyChat");

    private const string SettingsCommand = TidyStrings.SettingsCommand;
    private const string ShorthandCommand = TidyStrings.ShorthandCommand;
    
    private ulong _sessionBlockedMessages;

    #region Setup

    public TidyChatPlugin()
    {
        // Player cannot change this without restarting the game so should be safe to grab here
        L10N.Language = ClientState.ClientLanguage;
        LoadTomestones();
        PluginInterface.LanguageChanged += UpdateLang;
        UpdateLang(PluginInterface.UiLanguage);
        
        Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Configuration.Initialize(PluginInterface);
        
        if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate(Configuration);

        ChatGui.CheckMessageHandled += OnChat;
        ClientState.TerritoryChanged += OnTerritoryChanged;
        ClientState.Login += OnLogin;
        ClientState.Logout += OnLogout;

        PluginUi = new PluginUI(Configuration);
        _windowSystem.AddWindow(PluginUi);

        CommandManager.AddHandler(SettingsCommand, new CommandInfo(OnCommand)
        {
            HelpMessage = TidyStrings.SettingsHelper,
        });

        CommandManager.AddHandler(ShorthandCommand, new CommandInfo(OnCommand)
        {
            HelpMessage = TidyStrings.ShorthandHelper,
        });

        PluginInterface.UiBuilder.Draw += DrawUI;
        PluginInterface.UiBuilder.OpenMainUi += DrawConfigUI;
        PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;
    }

    #endregion Setup

    private Stack<string> ChatHistory { get; } = new();

    public void Dispose()
    {
        PluginUi.Dispose();
        CommandManager.RemoveHandler(SettingsCommand);
        CommandManager.RemoveHandler(ShorthandCommand);
        PluginInterface.LanguageChanged -= UpdateLang;
        ChatGui.CheckMessageHandled -= OnChat;
        ClientState.TerritoryChanged -= OnTerritoryChanged;
        ClientState.Login -= OnLogin;
        ClientState.Logout -= OnLogout;
    }
    private void OnLogin()
    {
        if (Configuration.BetterCommendationMessage) BetterCommendationsUpdate();
        if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate(Configuration);
        SetPlayerName();
    }

    private void OnLogout(int add, int remove)
    {
        BlockedCountUpdate();
    }

    private void OnTerritoryChanged(uint e)
    {
        BlockedCountUpdate();
        if (Configuration.BetterCommendationMessage) BetterCommendationsUpdate();
        if (Configuration.InstanceInDtrBar) DelayedInstanceDtrBarUpdate(Configuration);
        if (Configuration.IncludeDutyNameInComms)
            try
            {
                var territory =
                    DataManager.GetExcelSheet<Lumina.Excel.Sheets.TerritoryType>().GetRow(e); // built in sheets will never be null
                var exclusiveType = territory.ExclusiveType;
                var isPvp = territory.IsPvpZone;

                var placeName = territory.PlaceName.Value.Name.ToString();
                var dutyName = territory.ContentFinderCondition.Value.Name.ToString();

                TidyStrings.LastDuty = exclusiveType switch
                {
                    2 when dutyName.Length >= 1 => dutyName,
                    2 when dutyName.Length == 0 && placeName.Length > 0 => placeName,
                    2 when dutyName.Length == 0 && isPvp => L10N.GetTidy(TidyStrings.PvPDuty),
                    _ => TidyStrings.LastDuty // Keep previous value if we don't care about the new value
                };
            }
            catch (KeyNotFoundException)
            {
                Log.Warning(
                    "Something somehow somewhere went wrong but we don't want to crash on territory change");
            }
    }

    private void OnChat(IHandleableChatMessage message)
    {
        if (!Configuration.Enabled)
        {
            Log.Verbose($"Tidy Chat is not enabled");
            return;
        }
        
        // Ignore already filtered messages by other plugins such as NoSol
        // TODO: Allow Custom Filters to still run
        if (message.IsHandled) return;

        var chatType = FromDalamud(message.LogKind);
        bool isHandled;

        // If the channel is not one that Tidy Chat filters - don't bother running any rules
        // This includes all Battle-related channels, GM-related channels, NPC Dialogue, 
        // and a few other channels
        if (!ChannelCanBeFiltered((chatType))) return;
        
        // This logic exists elsewhere but I don't care to find/clean it up so I'll be redundant and check here too
        if (chatType is ChatType.StandardEmote && !Configuration.FilterEmoteChannel) return;
        if (chatType is ChatType.CustomEmote && !Configuration.FilterCustomEmoteChannel) return;

        // Check if emotes from other players should be filtered or not
        if (!Configuration.ShowOtherCustomEmotes && !string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal) && chatType is ChatType.CustomEmote)
        {
            if (Configuration.EnableDebugMode) Log.Verbose($"Filtered an emote: {message.Message}");
            return;
        }

        // Normalize all messages to lowercase so that we don't have to worry about case sensitivity in the filters
        var normalizedText = NormalizeInput.ToLowercase(message.Message);

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
            

        // If we have the player's name, normalize any messages containing the player's name or initials to read "you" instead of the player's name
        if (Configuration.PlayerName != "") normalizedText = NormalizeInput.ReplaceName(normalizedText, Configuration);

        if (Configuration.ShowDebugTeleport && chatType is ChatType.Debug &&
            L10N.Get(ChatStrings.DebugTeleport).All(normalizedText.Contains))
        {
            
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
            _sessionBlockedMessages += 1;
            return;
        }

        if (Configuration.BetterSayReminder &&
            chatType is ChatType.System && L10N.Get(ChatStrings.SayQuestReminder).All(normalizedText.Contains))

        {
            message.Message = Better.SayReminder(message.Message, Configuration);
            return;
        }

        if (Configuration.BetterNoviceNetworkMessage &&
            (L10N.Get(ChatStrings.NoviceNetworkJoin).All(normalizedText.Contains) || L10N.Get(ChatStrings.NoviceNetworkLeft).All(normalizedText.Contains)))
        {
            message.Message = Better.NoviceNetwork(message.Message, normalizedText, Configuration);
            return;
        }

        if (Configuration.BetterTreasureDungeonMessage && chatType is ChatType.System)
        {
            if (L10N.Get(ChatRegexStrings.ChamberOpens).IsMatch(normalizedText))
            {
                var match = L10N.Get(ChatRegexStrings.ChamberOpens).Match(normalizedText);
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
        if (Configuration.NormalizeBlocks)
        {
            if (Configuration.AlwaysNormalizeBlocks)
            {
                message.Message = DeblockMessage(message.Message);
            }
            else if (chatType is ChatType.Party || chatType is ChatType.Alliance)
            {
                // Do nothing if the message is to Party or Alliance
            }
            else
            {
                message.Message = DeblockMessage(message.Message);
            }
        }

        if (Configuration.EnableSmolMode)
        {
            message.Message = SmolMessage(message.Message);
        }

        #endregion

        #region Channel Filters

        Rules.UpdateIsActiveStates(Configuration);
        var rules = Rules.AllRules;


        // Block any messages that come from a "spammy" channel
        bool isBlocked = ChannelIsSpammy(chatType);
        
        // Skip filtering if chatType is System and System Filter is disabled
        if (chatType is ChatType.System && !Configuration.FilterSystemMessages) return;

        // If Inverse Mode is enabled System Channel messages should not be blocked by default - but all other spammy channels should be blocked
        if (chatType is ChatType.System && Configuration.EnableInverseMode)
        {
            if (Configuration.EnableDebugMode) Log.Information($"Inverse Mode Active");
            isBlocked = false;
        }

        var showEverythingElse = false;
        if ((chatType is ChatType.System && Configuration.ShowEverythingElse) ||
            (chatType is ChatType.Crafting && Configuration.ShowAllOtherCrafting) ||
            (chatType is ChatType.Gathering or ChatType.GatheringSystem && Configuration.ShowAllOtherGathering))
        {
            isBlocked = !isBlocked;
            showEverythingElse = true;
        }
        var defaultBlocked = isBlocked;

        List<String> rulesMatched = [];
        List<String> rulesSkipped = [];
        List<String> rulesFailed = [];
        foreach (var rule in rules)
        {
            if (rule.Error is not null)
            {
                Log.Error($"Error: {rule.Error}");
            }

            // Skip rules that wouldn't change isBlocked away from defaultBlocked
            if (rule.IsActive == showEverythingElse)
            {
                var activeOrInactive = showEverythingElse ? "active" : "inactive";
                if (Configuration.EnableDebugMode) Log.Verbose($"SKIPPING CHECK: {rule.Name} is {activeOrInactive}");
                rulesSkipped.Add(rule.Name);
                continue;
            }

            // Don't bother with checks for Channels other than the one the rule intends to filter
            if (chatType != rule.Channel && chatType is not ChatType.Echo)
            {
                if (Configuration.EnableDebugMode) Log.Verbose($"SKIPPING CHECK: Message was sent to {chatType} but the rule's filter is for {rule.Channel}");
                rulesSkipped.Add(rule.Name);
                continue;
            }

            if (rule.Channel == ChatType.Echo)
            {
                List<bool> fakeChecksMatched = [];
                switch (rule.Pattern)
                {
                    case PatternKind.RegexMatch:
                        if (rule.RegexChecks is null) continue;
                        foreach (var check in rule.RegexChecks)
                        {
                            if (!L10N.Get(check).IsMatch(normalizedText)) continue;
                            if (Configuration.EnableDebugMode) Log.Debug($"MATCHED RULE: {rule.Name} | REGEX: {L10N.Get(check)}");
                            fakeChecksMatched.Add(true);
                            rulesMatched.Add(rule.Name);
                        }
                        break;
                    case PatternKind.StringMatch:
                        if (rule.StringChecks is null) continue;
                        foreach (var check in rule.StringChecks)
                        {
                            if (!L10N.Get(check).All(normalizedText.Contains)) continue;
                            if (Configuration.EnableDebugMode) Log.Debug($"MATCHED RULE: {rule.Name} | CONTAINS: {String.Join(", ", L10N.Get(check))}");
                            fakeChecksMatched.Add(true);
                            rulesMatched.Add(rule.Name);
                        }
                        break;
                }
                if (fakeChecksMatched.Count == 0)
                {
                    if (Configuration.EnableDebugMode) Log.Debug($"/echo message failed to match any rules");
                }
                continue;
            }

            // Forgive me Father for I have sinned by writing this code
            switch (rule.Pattern)
            {
                case PatternKind.RegexMatch:
                    if (rule.RegexChecks is null) continue;

                    if (Configuration.EnableDebugMode) 
                    {
                        Log.Verbose($"START REGEX CHECK FOR: {rule.Name}");
                        Log.Verbose($"Number of Checks: {rule.RegexChecks.Count}");
                    }

                    List<bool> regexChecksMatched = [];
                    foreach (var check in rule.RegexChecks)
                    {
                        if (L10N.Get(check).IsMatch(normalizedText))
                        {
                            if (Configuration.EnableDebugMode) Log.Debug($"MATCHED RULE: {rule.Name} | REGEX: {L10N.Get(check)}");
                            regexChecksMatched.Add(true);
                        }
                        else
                        {
                            if (Configuration.EnableDebugMode) Log.Verbose($"FAILED: {rule.Name} | REGEX: {L10N.Get(check)}");
                            regexChecksMatched.Add(false);
                        }
                    }
                    // All checks must pass (AND logic)
                    if (!regexChecksMatched.Contains(false))
                    {
                        if (Configuration.EnableDebugMode) Log.Verbose($"Passed all checks!");
                        rulesMatched.Add(rule.Name);
                        isBlocked = !defaultBlocked;
                    }
                    else
                    {
                        rulesFailed.Add(rule.Name);
                    }
                    break;
                case PatternKind.StringMatch:
                    if (rule.StringChecks is null) continue;

                    if (Configuration.EnableDebugMode)
                    {
                        Log.Verbose($"START STRING CHECK FOR: {rule.Name}");
                        Log.Verbose($"Number of Checks: {rule.StringChecks.Count}");
                    }

                    List<bool> stringChecksMatched = [];
                    foreach (var check in rule.StringChecks)
                    {
                        if (L10N.Get(check).All(normalizedText.Contains))
                        {
                            if (Configuration.EnableDebugMode) Log.Debug($"MATCHED RULE: {rule.Name} | CONTAINS: {String.Join(", ", L10N.Get(check))}");
                            stringChecksMatched.Add(true);
                        }
                        else
                        {
                            if (Configuration.EnableDebugMode) Log.Verbose($"FAILED: {rule.Name} | CONTAINS: {String.Join(", ", L10N.Get(check))}");
                            stringChecksMatched.Add(false);
                        }
                    }
                    // All checks must pass (AND logic)
                    if (!stringChecksMatched.Contains(false))
                    {
                        if (Configuration.EnableDebugMode) Log.Verbose($"Passed all checks!");
                        rulesMatched.Add(rule.Name);
                        isBlocked = !defaultBlocked;
                    }
                    else
                    {
                        rulesFailed.Add(rule.Name);
                    }
                    break;
            }
        }

        if (Configuration.EnableDebugMode)
        {
            Log.Debug($"{rulesMatched.Count} Rules Matched: {String.Join(", ", rulesMatched)}");
            Log.Debug($"{rulesSkipped.Count} Rules Skipped: {String.Join(", ", rulesSkipped)}");
            Log.Debug($"{rulesFailed.Count} Rules Failed: {String.Join(", ", rulesFailed)}");   
        }

        // Sigh... previously LootNotice was Allow-By-Default and the filters Blocked
        // so we have to do some inversion here to restore previous behavior since
        // Tidy Chat 2.0 only runs Checks with True Configuration values
        if (chatType is not ChatType.LootNotice)
        {
            isHandled = isBlocked;
        }
        else
        {
            isHandled = !isBlocked;
        }
        if (isHandled && Configuration.EnableDebugMode)
        {
            Log.Debug($"BLOCKED: {message.Message}");
        }
        else
        {
            Log.Debug($"ALLOWED: {message.Message}");
        }

        #endregion

        #region Configuration Filter Overrides
        
        // If the text is a Custom Emote and it comes from the player it should not be blocked
        if (chatType is ChatType.CustomEmote &&
            string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
        {
            if (Configuration.EnableDebugMode) Log.Information($"Allowing custom emote used by player");
            isHandled = false;
        }

        // If the message is an emote used by the player and we are filtering used emotes - it should be blocked
        if (!Configuration.ShowSelfUsedEmotes &&
            (chatType is ChatType.StandardEmote || chatType is ChatType.CustomEmote) &&
            string.Equals(message.Sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
            isHandled = true;

        // Per-type tomestone filtering using Lumina-loaded game data.
        if (chatType is ChatType.LootNotice && !isHandled &&
            L10N.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(normalizedText))
        {
            foreach (var tomestone in Tomestones)
            {
                var itemNameLower = tomestone.Name.ToLower(CultureInfo.InvariantCulture);
                var lastWordStart = itemNameLower.LastIndexOf(' ') + 1;
                var typeName = itemNameLower[lastWordStart..];
                if (normalizedText.Contains(typeName, StringComparison.Ordinal))
                {
                    if (Configuration.HideTomestoneById.TryGetValue(tomestone.RowId, out var hide) && hide)
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

        if (Configuration.Whitelist.Count > 0)
            foreach (var playerOrMessage in Configuration.Whitelist)
                CustomFilterCheck(message.Sender, message.Message, ref isHandled, playerOrMessage, chatType);

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
                        var currentMessage = $"{message.Sender.TextValue}: {message.Message.TextValue}";
                        if (ChatHistory.Contains(currentMessage, StringComparer.Ordinal))
                        {
                            Log.Verbose($"Found message in chat history and blocked: {currentMessage}");
                            isHandled = true;
                        }
                        else if (ChatHistory.Count > Configuration.ChatHistoryLength)
                        {
                            Log.Verbose("Chat history reached limit. Removed oldest message and added:" +
                                      currentMessage);
                            ChatHistory.Pop();
                            ChatHistory.Push(currentMessage);
                        }
                        else
                        {
                            Log.Verbose("Added:" + currentMessage);
                            ChatHistory.Push(currentMessage);
                            if (Configuration.ChatHistoryTimer > 0)
                            {
                                var t = new Timer
                                {
                                    Interval = Configuration.ChatHistoryTimer * 1000,
                                    AutoReset = false,
                                };
                                t.Elapsed += delegate
                                {
                                    t.Enabled = false;
                                    t.Dispose();
                                    ChatHistory.Pop();
                                };
                                t.Enabled = true;
                            }
                        }
                    }

                    return;
                }
            }
            catch (Exception ex)
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
            _sessionBlockedMessages += 1;
            message.PreventOriginal();
        }
    }

    private static SeString BuildDebugString(ChatType chatType, SeString message, List<string> rulesMatched, bool debugIncludeChannel, bool isBlocked)
    {
        var stringBuilder = new SeStringBuilder();
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

    private void CustomFilterCheck(SeString sender, SeString message, ref bool isHandled,
        PlayerName playerOrMessage,
        ChatType chatType)
    {
        if (!isHandled && !playerOrMessage.AllowMessage)
        {
            var e = (ChatFlags.Channels)playerOrMessage.whitelistedChannels;
            var isRegex = false;
            Regex? userPattern = null;
            if (playerOrMessage.FirstName.StartsWith('/') && playerOrMessage.FirstName.EndsWith('/'))
            {
                isRegex = true;
                userPattern =
                    new Regex(playerOrMessage.FirstName[1..^1], RegexOptions.None, TimeSpan.FromSeconds(1));
            }

            var channelSelectedToFilter = false;
            if (!e.Equals(ChatFlags.Channels.None))
                channelSelectedToFilter = Flags.CheckFlags(playerOrMessage, chatType);

            if (channelSelectedToFilter &&
                string.Equals(sender.TextValue, playerOrMessage.FirstName, StringComparison.Ordinal))
            {
                isHandled = true;
                if (Configuration.EnableDebugMode) Log.Verbose($"The message from {playerOrMessage.FirstName} has been blocked.");
            }

            if (channelSelectedToFilter && !isRegex &&
                message.TextValue.Contains(playerOrMessage.FirstName, StringComparison.Ordinal))
            {
                isHandled = true;
                if (Configuration.EnableDebugMode) Log.Verbose($"A message matching \"{playerOrMessage.FirstName}\" has been blocked.");
            }

            if (userPattern != null && channelSelectedToFilter && isRegex &&
                userPattern.IsMatch(message.ToString()))
            {
                isHandled = true;
                if (Configuration.EnableDebugMode) Log.Verbose(
                    $"A message matching the regex \"{playerOrMessage.FirstName}\" has been blocked.");
            }
        }

        if (isHandled && playerOrMessage.AllowMessage)
        {
            var e = (ChatFlags.Channels)playerOrMessage.whitelistedChannels;
            var isRegex = false;
            Regex? userPattern = null;
            if (playerOrMessage.FirstName.StartsWith('/') && playerOrMessage.FirstName.EndsWith('/'))
            {
                isRegex = true;
                userPattern =
                    new Regex(playerOrMessage.FirstName[1..^1], RegexOptions.None, TimeSpan.FromSeconds(1));
            }

            var channelSelectedToFilter = false;
            if (!e.Equals(ChatFlags.Channels.None))
                channelSelectedToFilter = Flags.CheckFlags(playerOrMessage, chatType);

            if (channelSelectedToFilter &&
                string.Equals(sender.TextValue, playerOrMessage.FirstName, StringComparison.Ordinal))
            {
                isHandled = false;
                if (Configuration.EnableDebugMode) Log.Verbose($"The message from {playerOrMessage.FirstName} has been allowed.");
            }

            if (channelSelectedToFilter && !isRegex &&
                message.TextValue.Contains(playerOrMessage.FirstName, StringComparison.Ordinal))
            {
                isHandled = false;
                if (Configuration.EnableDebugMode) Log.Verbose($"A message matching \"{playerOrMessage.FirstName}\" has been allowed.");
            }

            if (userPattern != null && channelSelectedToFilter && isRegex &&
                userPattern.IsMatch(message.ToString()))
            {
                isHandled = false;
                if (Configuration.EnableDebugMode) Log.Verbose(
                    $"A message matching the regex \"{playerOrMessage.FirstName}\" has been allowed.");
            }
        }
    }

    private void SetPlayerName()
    {
        try
        {
            if ((ObjectTable[0] as IPlayerCharacter) == null) return;

            Configuration.PlayerName = $"{(ObjectTable[0] as IPlayerCharacter)?.Name}";
            Log.Information($"Player name saved as {(ObjectTable[0] as IPlayerCharacter)?.Name}");
            Configuration.Save();
        }
        catch (Exception ex)
        {
            Log.Error("Error: Failed to capture player's name - trying again in 30 seconds" + ex);
            var t = new Timer
            {
                Interval = 30000,
                AutoReset = false,
            };
            t.Elapsed += delegate
            {
                t.Enabled = false;
                t.Dispose();
                SetPlayerName();
            };
            t.Enabled = true;
        }
    }

    private void BlockedCountUpdate()
    {
        Configuration.TtlMessagesBlocked += _sessionBlockedMessages;
        _sessionBlockedMessages = 0;
        Configuration.Save();
    }

    private unsafe void BetterCommendationsUpdate()
    {
        try
        {
            var player = PlayerState.Instance();
            if (player == null)
            {
                Log.Error("PlayerState was null, something went wrong");
                return;
            }

            TidyStrings.CommendationsEarned = player->PlayerCommendations;
        }
        catch (Exception ex)
        {
            Log.Error("Failed to improve Commendations message", ex);
        }

        var commendationChange = TidyStrings.CommendationsEarned - TidyStrings.LastCommendations;
        TidyStrings.LastCommendations = TidyStrings.CommendationsEarned;

        if (commendationChange is >= 1 and <= 7)
        {
            var stringBuilder = new SeStringBuilder();
            if (Configuration.IncludeChatTag) Better.AddTidyChatTag(stringBuilder);

            string commendations = commendationChange == 1
                ? Languages.BetterStrings_CommendationSingular
                : Languages.BetterStrings_CommendationsPlural;

            var dutyName =
                $"{(Configuration.IncludeDutyNameInComms && TidyStrings.LastDuty.Length > 0 ? " " + Languages.BetterStrings_CommendationsFromCompletingDuty + " " + TidyStrings.LastDuty + "." : ".")}";

            stringBuilder.AddText(
                string.Format(CultureInfo.CurrentCulture, Languages.BetterStrings_ReceivedCommendationsMessages, commendationChange.ToString(CultureInfo.CurrentCulture), commendations, dutyName));

            ChatGui.Print(stringBuilder.BuiltString);
        }
    }

    private static void LoadTomestones()
    {
        var tomestones = new List<TomestoneInfo>();
        try
        {
            // Each Tomestones slot (Poetics / capped / weekly-capped) accumulates retired tomestones over patches.
            // Take the highest TomestonesItem RowId per slot — that’s the currently active one for that slot.
            var bestPerSlot = new Dictionary<uint, (uint RowId, string Name)>();
            foreach (var row in DataManager.GetExcelSheet<Lumina.Excel.Sheets.TomestonesItem>())
            {
                var slotId = row.Tomestones.RowId;
                if (slotId == 0) continue;
                var name = row.Item.Value.Name.ToString();
                if (string.IsNullOrWhiteSpace(name)) continue;
                if (!bestPerSlot.TryGetValue(slotId, out var existing) || row.RowId > existing.RowId)
                    bestPerSlot[slotId] = (row.RowId, name);
            }
            foreach (var (rowId, name) in bestPerSlot.Values)
                tomestones.Add(new TomestoneInfo(rowId, name));
        }
        catch (Exception ex)
        {
            Log.Error("Failed to load tomestone data from Lumina: " + ex);
        }
        Tomestones = tomestones.AsReadOnly();
        Log.Information($"Loaded {Tomestones.Count} tomestones: {string.Join(", ", Tomestones.Select(t => t.Name))}");
    }

    private bool FilterIsEnabled(ChatType chatType)
    {
        switch (chatType)
        {
            case ChatType.System when Configuration.FilterSystemMessages:
            case ChatType.StandardEmote or ChatType.CustomEmote when Configuration.FilterEmoteChannel:
            case ChatType.Crafting when Configuration.FilterCraftingSpam:
            case ChatType.Gathering or ChatType.GatheringSystem when Configuration.FilterGatheringSpam:
            case ChatType.LootNotice when Configuration.FilterObtainedSpam:
            case ChatType.LootRoll when Configuration.FilterLootSpam:
            case ChatType.Progress when Configuration.FilterProgressSpam:
            case ChatType.FreeCompanyLoginLogout when (!Configuration.ShowUserLogins && !Configuration.ShowUserLogins):
            case ChatType.Echo when Configuration.EnableDebugMode:
                return true;
            default:
                return false;
        }
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
            _ => false,
        };
    }
    
    private static bool ChannelCanBeFiltered(ChatType chatType)
    {
        return chatType switch
        {
            ChatType.Error or
                ChatType.Say or
                ChatType.Shout or
                ChatType.Yell or
                ChatType.TellIncoming or
                ChatType.PvpTeam or
                ChatType.NoviceNetwork or
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
            _ => false,
        };
    }

    private static SeString SmolMessage(SeString msg)
    {
        var payloads = msg.Payloads;
        var stringBuilder = new SeStringBuilder();
        payloads.ForEach(payload =>
        {
            if (payload.Type is not PayloadType.RawText)
            {
                stringBuilder.Add(payload);
            }
            else if (payload is TextPayload { Text: not null } textPayload)
            {
                string smolMessage = "";
                foreach (int i in textPayload.Text)
                {
                    if (i is >= 65 and <= 91) smolMessage += (char)(i + 32);
                    else smolMessage += (char)i;
                }
                stringBuilder.AddText(smolMessage);
            }
        });
        msg = stringBuilder.Build();
        msg.EncodeWithNullTerminator();
        return msg;
    }

    private static SeString DeblockMessage(SeString msg)
    {
        var payloads = msg.Payloads;
        var stringBuilder = new SeStringBuilder();
        payloads.ForEach(payload =>
        {
            if (payload.Type is not PayloadType.RawText)
            {
                stringBuilder.Add(payload);
            }
            else if (payload is TextPayload { Text: not null } textPayload)
            {
                string deblockedMessage = "";
                foreach (int i in textPayload.Text)
                {
                    switch (i)
                    {
                        case >= 57457 and <= 57483:
                            deblockedMessage += (char)(i - 57392); // A-Z Blocks
                            break;
                        case >= 57487 and <= 57496:
                            deblockedMessage += (char)(i - 57439); // Number Blocks
                            break;
                        case >= 57521 and <= 57529:
                            deblockedMessage += (char)(i - 57472); // Hexgonical Numbers
                            break;
                        case >= 57440 and <= 57449:
                            deblockedMessage += (char)(i - 57392); // Monospace Numbers
                            break;
                        default:
                            deblockedMessage += (char)i;
                            break;
                    }
                }
                stringBuilder.AddText(deblockedMessage);
            }
        });
        msg = stringBuilder.Build();
        msg.EncodeWithNullTerminator();
        return msg;
    }

    public static IDtrBarEntry GetDtrBar() => DtrBar.Get(TidyStrings.PluginName);

    private static void DelayedInstanceDtrBarUpdate(Configuration configuration)
    {
        var t = new Timer
        {
            Interval = 1000,
            AutoReset = false,
        };
        t.Elapsed += delegate
        {
            t.Enabled = false;
            t.Dispose();
            InstanceDtrBarUpdate(configuration);
        };
        t.Enabled = true;
    }

    public static unsafe void InstanceDtrBarUpdate(Configuration configuration)
    {
        DtrEntry ??= GetDtrBar();
        DtrEntry.Tooltip = "TidyChat";

        if (!configuration.InstanceInDtrBar)
        {
            DtrEntry.Shown = false;
            DtrEntry.Text = String.Empty;
            return;
        }
        try
        {
            // This will return the instance value: 0,1,2,3,4,5,6
            var instanceNumberFromSignature = (int)UIState.Instance()->PublicInstance.InstanceId;
            var instanceCharacter = ((char)(SeIconChar.Instance1 + (byte)(instanceNumberFromSignature - 1))).ToString();

            DtrEntry.Text = instanceNumberFromSignature switch
            {
                >= 1 => $"{L10N.GetTidy(TidyStrings.InstanceWord)} {instanceCharacter}",
                _ => String.Empty,
            };
            DtrEntry.Shown = instanceNumberFromSignature >= 1;
        }
        catch (Exception ex)
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
        Languages.Culture = new CultureInfo(langCode);
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

    private static ChatType FromCode(ushort code)
    {
        return (ChatType)(code & Clear7);
    }

    private static ChatType FromDalamud(XivChatType type)
    {
        return FromCode((ushort)type);
    }

    #endregion Chat2 ChatTypes
}
