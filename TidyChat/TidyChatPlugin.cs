using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Timers;
using ChatTwo.Code;
using Dalamud.Game;
using Dalamud.Game.Command;
using Dalamud.Game.Gui.Dtr;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using TidyChat.Utility;
using TidyChat.Resources.Languages;
using Better = TidyChat.Utility.BetterStrings;
using Flags = TidyChat.Utility.ChatFlags;
using TidyStrings = TidyChat.Utility.InternalStrings;
using System.Data;

namespace TidyChat;

public sealed class TidyChatPlugin : IDalamudPlugin
{
    [PluginService] public static IDataManager DataManager { get; private set; } = null!;
    [PluginService] public static IDtrBar DtrBar { get; private set; } = null!;
    [PluginService] public static ICommandManager CommandManager { get; private set; } = null!;
    [PluginService] public static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
    [PluginService] public static IClientState ClientState { get; private set; } = null!;
    [PluginService] public static IChatGui ChatGui { get; private set; } = null!;
    [PluginService] public static ISigScanner SigScanner { get; private set; } = null!;
    [PluginService] public static IGameInteropProvider Hook { get; private set; } = null!;
    [PluginService] public static IPluginLog Log { get; private set; } = null!;

    private Configuration Configuration { get; }
    private PluginUI PluginUi { get; }

    private const string SettingsCommand = TidyStrings.SettingsCommand;
    private const string ShorthandCommand = TidyStrings.ShorthandCommand;
    private readonly DtrBarEntry dtrEntry;
    private ulong SessionBlockedMessages;

    #region Setup

    public TidyChatPlugin()
    {
        // Player cannot change this without restarting the game so should be safe to grab here
        L10N.Language = ClientState.ClientLanguage;
        PluginInterface.LanguageChanged += UpdateLang;
        UpdateLang(PluginInterface.UiLanguage);

        Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Configuration.Initialize(PluginInterface);

        dtrEntry = (DtrBarEntry)DtrBar.Get(TidyStrings.PluginName);
        if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate(dtrEntry, Configuration);

        ChatGui.CheckMessageHandled += OnChat;
        ClientState.TerritoryChanged += OnTerritoryChanged;
        ClientState.Login += OnLogin;
        ClientState.Logout += OnLogout;

        PluginUi = new PluginUI(Configuration);

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
        dtrEntry.Dispose();
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
        if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate(dtrEntry, Configuration);
        SetPlayerName();
    }

    private void OnLogout()
    {
        BlockedCountUpdate();
    }

    private void OnTerritoryChanged(ushort e)
    {
        BlockedCountUpdate();
        if (Configuration.BetterCommendationMessage) BetterCommendationsUpdate();
        if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate(dtrEntry, Configuration);
        if (Configuration.IncludeDutyNameInComms)
            try
            {
                var territory =
                    DataManager.GetExcelSheet<Lumina.Excel.GeneratedSheets.TerritoryType>()!.GetRow(e); // built in sheets will never be null
                var exclusiveType = territory!.ExclusiveType;
                var isPvp = territory.IsPvpZone;

                var placeName = territory.PlaceName.Value?.Name.ToString();
                var dutyName = territory.ContentFinderCondition.Value?.Name.ToString();

                TidyStrings.LastDuty = exclusiveType switch
                {
                    2 when dutyName?.Length >= 1 => dutyName,
                    2 when dutyName?.Length == 0 && placeName?.Length > 0 => placeName,
                    2 when dutyName?.Length == 0 && isPvp => L10N.GetTidy(TidyStrings.PvPDuty),
                    _ => TidyStrings.LastDuty // Keep previous value if we don't care about the new value
                };
            }
            catch (KeyNotFoundException)
            {
                Log.Warning(
                    "Something somehow somewhere went wrong but we don't want to crash on territory change");
            }
    }

    private void OnChat(XivChatType type, int timestamp, ref SeString sender, ref SeString message,
        ref bool isHandled)
    {
        if (!Configuration.Enabled)
        {
            Log.Verbose($"Tidy Chat is not enabled");
            return;
        }

        var chatType = FromDalamud(type);

        // Don't bother checking anything sent to /echo... unless we're debugging
        if (chatType == ChatType.Echo && !Configuration.EnableDebugMode)
        {
            Log.Verbose($"/echo message - refusing to filter. Please enable Debug Mode if testing which filter the message would have matched.");
            return;
        }

        // Check that the user has configured the channel to be filtered
        if (!FilterIsEnabled(chatType)) return;
        Log.Verbose($"Filter for {chatType} Channel is enabled - checking message against filters");

        // Check if emotes from other players should be filtered or not
        if (!Configuration.ShowOtherCustomEmotes && !string.Equals(sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal) && chatType is ChatType.CustomEmote)
        {
            Log.Verbose($"Filtered an emote: {message.ToString()}");
            return;
        }

        // Normalize all messages to lowercase so that we don't have to worry about case sensitivity in the filters
        var normalizedText = NormalizeInput.ToLowercase(message);

        // If the message is a /? command - temporarily disable the filters to allow the command text through
        if (L10N.Get(ChatRegexStrings.QuestionMarkCommandResponse).IsMatch(normalizedText) &&
            Configuration.FilterSystemMessages)
            Better.TemporarilyDisableSystemFilter(Configuration);

        // If we have the player's name, normalize any messages containing the player's name or initials to read "you" instead of the player's name
        if (Configuration.PlayerName != "") normalizedText = NormalizeInput.ReplaceName(normalizedText, Configuration);

        if (Configuration.ShowDebugTeleport && !Configuration.EnableDebugMode && chatType is ChatType.Debug &&
            L10N.Get(ChatStrings.DebugTeleport).All(normalizedText.Contains))
            isHandled = true;

        #region Better Messages

        // Certain messages are improved with better messaging - these will change those messages to be Better Messages
        // Better Messages must always Early Return to avoid being filtered and because if we bettered the message we aren't filtering it anyway

        if (Configuration.BetterInstanceMessage && !Configuration.ShowInstanceMessage &&
            !Configuration.EnableDebugMode && chatType is ChatType.System &&
            L10N.Get(ChatStrings.InstancedArea).All(normalizedText.Contains))
        { 
            message = Better.Instances(message, Configuration);
            return;
        }

        if (Configuration.BetterSayReminder && !Configuration.EnableDebugMode &&
            chatType is ChatType.System && L10N.Get(ChatStrings.SayQuestReminder).All(normalizedText.Contains))

        {
            message = Better.SayReminder(message, Configuration); 
            return;
        }

        if (Configuration.BetterNoviceNetworkMessage && !Configuration.EnableDebugMode &&
            (L10N.Get(ChatStrings.NoviceNetworkJoin).All(normalizedText.Contains) || L10N.Get(ChatStrings.NoviceNetworkLeft).All(normalizedText.Contains)))
        {
            message = Better.NoviceNetwork(message, normalizedText, Configuration);
            return;
        }

        #endregion

        #region Channel Filters

        Rules.UpdateIsActiveStates(Configuration);
        var rules = Rules.AllRules;


        // Block any messages that come from a "spammy" channel
        bool isBlocked = ChannelIsSpammy(chatType);

        // If Inverse Mode is enabled System Channel messages should not be blocked by default - but all other spammy channels should be blocked
        if (chatType is ChatType.System && Configuration.EnableInverseMode)
        {
            Log.Information($"Inverse Mode Active");
            isBlocked = false;
        }

        List<String> rulesPassed = [];
        List<String> rulesSkipped = [];
        List<String> rulesFailed= [];
        foreach (var rule in rules)
        {
            if (rule.Error is not null)
            {
                Log.Debug($"Error: {rule.Error}");
            }

            // Don't bother checking if the rule is not active
            if (!rule.IsActive)
            {
                Log.Verbose($"SKIPPING CHECK: {rule.Name} is inactive");
                rulesSkipped.Add(rule.Name);
                continue;
            }

            // Don't bother with checks for Channels other than the one the rule intends to filter
            if (chatType != rule.Channel)
            {
                Log.Verbose($"SKIPPING CHECK: Message was sent to {chatType} but the rule's filter is for {rule.Channel}");
                rulesSkipped.Add(rule.Name);
                continue;
            }

            if (rule.Channel == ChatType.Echo)
            {
                List<bool> fakeChecksMatched = [];
                switch (rule.Pattern)
                {
                    case PatternKind.RegexMatch:
                        if (rule.RegexChecks is null) return;
                        foreach (var check in rule.RegexChecks)
                        {
                            if (L10N.Get(check).IsMatch(normalizedText))
                            {
                                Log.Debug($"MATCHED: {rule.Name}");
                                fakeChecksMatched.Add(true);
                                rulesPassed.Add(rule.Name);
                            }
                        }
                        break;
                    case PatternKind.StringMatch:
                        if (rule.StringChecks is null) return;
                        foreach (var check in rule.StringChecks)
                        {
                            if (L10N.Get(check).All(normalizedText.Contains))
                            {
                                Log.Debug($"MATCHED: {rule.Name}");
                                fakeChecksMatched.Add(true);
                                rulesPassed.Add(rule.Name);
                            }
                        }
                        break;
                }
                if (fakeChecksMatched.Count == 0)
                {
                    Log.Debug($"/echo message failed to match any rules");
                }
                continue;
            }

            // Forgive me Father for I have sinned by writing this code
            switch (rule.Pattern)
            {
                case PatternKind.RegexMatch:
                    if (rule.RegexChecks is null) return;

                    foreach (var check in rule.RegexChecks)
                    {
                        Log.Verbose($"START CHECK FOR: {rule.Name}");
                        Log.Verbose($"Number of Checks: {rule.RegexChecks.Count}");
                        List<bool> regexChecksMatched = [];
                        if (L10N.Get(check).IsMatch(normalizedText))
                        {
                            Log.Verbose($"MATCHED: {rule.Name}");
                            regexChecksMatched.Add(true);
                        } else
                        {
                            Log.Verbose($"FAILED: {rule.Name}");
                            regexChecksMatched.Add(false);
                        }
                        // If any of the checks fail it doesn't match our rule to allow the message
                        if (!regexChecksMatched.Contains(false))
                        {
                            Log.Verbose($"Passed all checks!");
                            rulesPassed.Add(rule.Name);
                            isBlocked = Configuration.EnableInverseMode;
                        } else
                        {
                            rulesFailed.Add(rule.Name);
                        }
                    }
                    break;
                case PatternKind.StringMatch:
                    if (rule.StringChecks is null) return;

                    foreach (var check in rule.StringChecks)
                    {
                        Log.Verbose($"START CHECK FOR: {rule.Name}");
                        Log.Verbose($"Number of Checks: {rule.StringChecks.Count}");
                        List<bool> stringChecksMatched = [];
                        if (L10N.Get(check).All(normalizedText.Contains))
                        {
                            Log.Verbose($"MATCHED: {rule.Name}");
                            stringChecksMatched.Add(true);
                        } else
                        {
                            Log.Verbose($"FAILED: {rule.Name}");
                            stringChecksMatched.Add(false);
                        }
                        if (!stringChecksMatched.Contains(false))
                        {
                            Log.Verbose($"Passed all checks!");
                            rulesPassed.Add(rule.Name);
                            isBlocked = Configuration.EnableInverseMode;
                        } else
                        {
                            rulesFailed.Add(rule.Name);
                        }
                    }
                    break;
            }
        }
        Log.Debug($"{rulesPassed.Count} Rules Passed: {String.Join(", ", rulesPassed)}");
        Log.Debug($"{rulesSkipped.Count} Rules Skipped: {String.Join(", ", rulesSkipped)}");
        Log.Debug($"{rulesFailed.Count} Rules Failed: {String.Join(", ", rulesFailed)}");
        isHandled = isBlocked;
        if (isHandled)
        {
            Log.Debug($"BLOCKED: {message}");
        } else
        {
            Log.Debug($"ALLOWED: {message}");
        }

        #endregion

        #region Configuration Filter Overrides

        // If the message is an emote used by the player and we are filtering used emotes - it is handled (blocked)
        if (!Configuration.ShowUsedEmotes &&
            (chatType is ChatType.StandardEmote || chatType is ChatType.CustomEmote) &&
            string.Equals(sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal))
            isHandled = true;

        #endregion Channel Filters

        #region Whitelist

        if (Configuration.Whitelist.Count > 0)
            foreach (var playerOrMessage in Configuration.Whitelist)
                CustomFilterCheck(sender, message, ref isHandled, playerOrMessage, chatType);

        #endregion Whitelist

        #region Duplicate Message Spam Filter

        if (Configuration.ChatHistoryFilter && !isHandled)
            try
            {
                /* Disable Chat History for self-sent messages by default */
                if (Configuration.DisableSelfChatHistory && string.Equals(sender.TextValue, Configuration.PlayerName, StringComparison.Ordinal)) return;

                var historyChannels = (ChatFlags.Channels)Configuration.ChatHistoryChannels;
                if (!historyChannels.Equals(ChatFlags.Channels.None))
                {
                    if (Flags.CheckFlags(Configuration, chatType))
                    {
                        var currentMessage = $"{sender.TextValue}: {message.TextValue}";
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

        #region Debug Mode Enabled

        if (Configuration.EnableDebugMode && isHandled && !message.TextValue.StartsWith("[TidyChat]", StringComparison.Ordinal))
        {
            message = BuildDebugString(chatType, message);
            isHandled = false;
        }

        #endregion Debug Mode Enabled
        if (isHandled)
        {
            SessionBlockedMessages += 1;
        }
    }

    private static SeString BuildDebugString(ChatType chatType, SeString message)
    {
        var stringBuilder = new SeStringBuilder();
        Better.AddTidyChatTag(stringBuilder);
        Better.AddDebugTag(stringBuilder);
        stringBuilder.AddText($"[{chatType}] ");
        stringBuilder.AddText(message.TextValue);
        return stringBuilder.BuiltString;
    }

    private static void CustomFilterCheck(SeString sender, SeString message, ref bool isHandled,
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
                Log.Verbose($"The message from {playerOrMessage.FirstName} has been blocked.");
            }

            if (channelSelectedToFilter && !isRegex &&
                message.TextValue.Contains(playerOrMessage.FirstName, StringComparison.Ordinal))
            {
                isHandled = true;
                Log.Verbose($"A message matching \"{playerOrMessage.FirstName}\" has been blocked.");
            }

            if (userPattern != null && channelSelectedToFilter && isRegex &&
                userPattern.IsMatch(message.ToString()))
            {
                isHandled = true;
                Log.Verbose(
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
                Log.Verbose($"The message from {playerOrMessage.FirstName} has been allowed.");
            }

            if (channelSelectedToFilter && !isRegex &&
                message.TextValue.Contains(playerOrMessage.FirstName, StringComparison.Ordinal))
            {
                isHandled = false;
                Log.Verbose($"A message matching \"{playerOrMessage.FirstName}\" has been allowed.");
            }

            if (userPattern != null && channelSelectedToFilter && isRegex &&
                userPattern.IsMatch(message.ToString()))
            {
                isHandled = false;
                Log.Verbose(
                    $"A message matching the regex \"{playerOrMessage.FirstName}\" has been allowed.");
            }
        }
    }

    private void SetPlayerName()
    {
        try
        {
            if (ClientState.LocalPlayer == null) return;

            Configuration.PlayerName = $"{ClientState.LocalPlayer.Name}";
            Log.Information($"Player name saved as {ClientState.LocalPlayer.Name}");
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
        Configuration.TtlMessagesBlocked += SessionBlockedMessages;
        SessionBlockedMessages = 0;
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

            var commendations = "";
            commendations = commendationChange == 1
                ? Languages.BetterStrings_CommendationSingular
                : Languages.BetterStrings_CommendationsPlural;

            var dutyName =
                $"{(Configuration.IncludeDutyNameInComms && TidyStrings.LastDuty.Length > 0 ? " " + Languages.BetterStrings_CommendationsFromCompletingDuty + " " + TidyStrings.LastDuty + "." : ".")}";

            stringBuilder.AddText(
                string.Format(CultureInfo.CurrentCulture, Languages.BetterStrings_ReceivedCommendationsMessages, commendationChange.ToString(CultureInfo.CurrentCulture), commendations, dutyName));

            ChatGui.Print(stringBuilder.BuiltString);
        }
    }

    private bool FilterIsEnabled(ChatType chatType)
    {
        if (chatType is ChatType.System && Configuration.FilterSystemMessages) return true;
        if ((chatType is ChatType.StandardEmote || chatType is ChatType.CustomEmote) && Configuration.FilterEmoteSpam) return true;
        if (chatType is ChatType.Crafting && Configuration.FilterCraftingSpam) return true;
        if ((chatType is ChatType.Gathering || chatType is ChatType.GatheringSystem) && Configuration.FilterGatheringSpam) return true;
        if (chatType is ChatType.LootNotice && Configuration.FilterObtainedSpam) return true;
        if (chatType is ChatType.LootRoll && Configuration.FilterLootSpam) return true;
        if (chatType is ChatType.Progress && Configuration.FilterProgressSpam) return true;
        if (chatType is ChatType.FreeCompanyLoginLogout && Configuration.ShowUserLogins) return true;
        return false;
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
            ChatType.FreeCompanyLoginLogout => true,
            _ => false,
        };
    }

    public static DtrBarEntry GetDtrBar()
    {
        return (DtrBarEntry)DtrBar.Get(TidyStrings.PluginName);
    }
    unsafe public static void InstanceDtrBarUpdate(DtrBarEntry dtrEntry, Configuration configuration)
    {
        if (!configuration.InstanceInDtrBar)
        {
            dtrEntry.Text = String.Empty;
            return;
        }
        try
        {
            // This will return the instance value: 0,1,2,3,4,5,6
            int InstanceNumberFromSignature = (int)UIState.Instance()->PublicInstance.InstanceId;
            var instanceCharacter = ((char)(SeIconChar.Instance1 + (byte)(InstanceNumberFromSignature - 1))).ToString();

            if (InstanceNumberFromSignature >= 1)
            {
                dtrEntry.Text = $"{L10N.GetTidy(TidyStrings.InstanceWord)} {instanceCharacter}";
            }

            else if (InstanceNumberFromSignature == 0)
            {
                dtrEntry.Text = String.Empty;
            }
        }
        catch (Exception ex)
        {
            Log.Error("Error: Failed to update Instance for DtrBarEntry - " + ex);
        }
    }

    private void OnCommand(string command, string args)
    {
        PluginUi.SettingsVisible = true;
    }

    private void UpdateLang(string langCode)
    {
        Languages.Culture = new CultureInfo(langCode);
    }

    private void DrawUI()
    {
        PluginUi.Draw();
    }

    private void DrawConfigUI()
    {
        PluginUi.SettingsVisible = true;
    }

    #region Chat2 ChatTypes

    // Stole this region from Anna's Chat2: https://git.annaclemens.io/ascclemens/ChatTwo/src/branch/main/ChatTwo
    private const ushort Clear7 = ~(~0 << 7);
    internal ushort Raw { get; }
    internal ChatType Type => (ChatType)(Raw & Clear7);

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
