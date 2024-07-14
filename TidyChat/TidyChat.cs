using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
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
using Lumina.Excel.GeneratedSheets;
using TidyChat.Localization.Resources;
using TidyChat.Utility;
using Better = TidyChat.Utility.BetterStrings;
using Flags = TidyChat.Utility.ChatFlags;
using GetDuty = TidyChat.Utility.GetDutyName;
using TidyStrings = TidyChat.Utility.InternalStrings;
using Lumina = Lumina.Excel.GeneratedSheets;

namespace TidyChat;

public sealed class TidyChat : IDalamudPlugin
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

    public TidyChat()
    {
        // Player cannot change this without restarting the game so should be safe to grab here
        L10N.Language = ClientState.ClientLanguage;
        PluginInterface.LanguageChanged += UpdateLang;
        UpdateLang(PluginInterface.UiLanguage);
        // Sets name on install / plugin update
        SetPlayerName();

        Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Configuration.Initialize(PluginInterface);

        if (Configuration.InstanceInDtrBar)
            dtrEntry = (DtrBarEntry?)DtrBar.Get(Name);

        ChatGui.CheckMessageHandled += OnChat;
        ClientState.TerritoryChanged += OnTerritoryChanged;
        ClientState.Login += OnLogin;
        ClientState.Logout += OnLogout;

        PluginUi = new PluginUI(Configuration);

        CommandManager.AddHandler(SettingsCommand, new CommandInfo(OnCommand)
        {
            HelpMessage = TidyStrings.SettingsHelper
        });

        CommandManager.AddHandler(ShorthandCommand, new CommandInfo(OnCommand)
        {
            HelpMessage = TidyStrings.ShorthandHelper
        });

        PluginInterface.UiBuilder.Draw += DrawUI;
        PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;
    }

    #endregion Setup

    private Stack<string> ChatHistory { get; } = new();
    public string Name => TidyStrings.PluginName;

    public void Dispose()
    {
        dtrEntry?.Dispose();
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
        if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate();
    }

    private void OnLogout()
    {
        BlockedCountUpdate();
    }

    private void OnTerritoryChanged(ushort e)
    {
        BlockedCountUpdate();
        if (Configuration.BetterCommendationMessage) BetterCommendationsUpdate();
        if (Configuration.InstanceInDtrBar) InstanceDtrBarUpdate();
        if (Configuration.IncludeDutyNameInComms)
            try
            {
                var territory =
                    DataManager.GetExcelSheet<TerritoryType>()!.GetRow(e); // built in sheets will never be null
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
        if (!Configuration.Enabled) return;

        var chatType = FromDalamud(type);
        var normalizedText = NormalizeInput.ToLowercase(message);

        if (L10N.Get(ChatRegexStrings.QuestionMarkCommandResponse).IsMatch(normalizedText) &&
            Configuration.FilterSystemMessages)
            Better.TemporarilyDisableSystemFilter(Configuration);

        if (Configuration.PlayerName != "") normalizedText = NormalizeInput.ReplaceName(normalizedText, Configuration);

        if (Configuration.HideDebugTeleport && !Configuration.EnableDebugMode && chatType is ChatType.Debug &&
            L10N.Get(ChatStrings.DebugTeleport).All(normalizedText.Contains))
            isHandled = true;

        #region Better Messages

        if (Configuration.BetterInstanceMessage && !Configuration.HideInstanceMessage &&
            !Configuration.EnableDebugMode && chatType is ChatType.System &&
            L10N.Get(ChatStrings.InstancedArea).All(normalizedText.Contains))
            message = Better.Instances(message, Configuration);

        if (Configuration.BetterSayReminder && !Configuration.EnableDebugMode &&
            chatType is ChatType.System && L10N.Get(ChatStrings.SayQuestReminder).All(normalizedText.Contains))
            message = Better.SayReminder(message, Configuration);

        if (Configuration.BetterCommendationMessage && !Configuration.EnableDebugMode &&
            L10N.Get(ChatStrings.PlayerCommendation).All(normalizedText.Contains))
            isHandled = true;

        if (Configuration.BetterNoviceNetworkMessage && !Configuration.EnableDebugMode)
            message = Better.NoviceNetwork(message, normalizedText, Configuration);

        if (Configuration.HideNoviceNetworkFull && chatType is ChatType.NoviceNetworkSystem &&
            L10N.Get(ChatRegexStrings.NoviceNetworkFull).IsMatch(normalizedText))
            isHandled = true;

        #endregion

        #region Channel Filters

        #region Emotes

        if (Configuration.FilterEmoteSpam && chatType is ChatType.StandardEmote)
            isHandled = FilterEmoteMessages.IsFiltered(normalizedText, chatType, Configuration);

        if (Configuration.HideOtherCustomEmotes && sender.TextValue != Configuration.PlayerName &&
            chatType is ChatType.CustomEmote)
            isHandled = FilterEmoteMessages.IsFiltered(normalizedText, chatType, Configuration);

        if (Configuration.HideUsedEmotes &&
            (chatType is ChatType.StandardEmote || chatType is ChatType.CustomEmote) &&
            sender.TextValue == Configuration.PlayerName)
            isHandled = true;

        #endregion Emotes

        if (!Configuration.EnableInverseMode && Configuration.FilterSystemMessages && chatType is ChatType.System)
            isHandled = FilterSystemMessages.IsFiltered(normalizedText, Configuration);

        if (Configuration.EnableInverseMode && Configuration.FilterSystemMessages && chatType is ChatType.System)
            isHandled = FilterSystemMessagesInversed.IsFiltered(normalizedText, Configuration);

        if (Configuration.FilterObtainedSpam && chatType is ChatType.LootNotice)
            isHandled = FilterObtainMessages.IsFiltered(normalizedText, Configuration);

        if (Configuration.FilterLootSpam && chatType is ChatType.LootRoll)
            isHandled = FilterLootMessages.IsFiltered(normalizedText, Configuration);

        if (Configuration.FilterProgressSpam && chatType is ChatType.Progress)
            isHandled = FilterProgressMessages.IsFiltered(normalizedText, Configuration);

        #region DoH/DoL

        if (Configuration.FilterCraftingSpam && chatType is ChatType.Crafting)
            isHandled = FilterCraftMessages.IsFiltered(normalizedText, Configuration);

        if (Configuration.FilterGatheringSpam && chatType is ChatType.GatheringSystem or ChatType.Gathering)
            isHandled = FilterGatherMessages.IsFiltered(normalizedText, Configuration);

        #endregion DoH/DoL

        if ((Configuration.HideUserLogins || Configuration.HideUserLogouts) &&
            chatType is ChatType.FreeCompanyLoginLogout)
            isHandled = FilterFreeCompanyMessages.IsFiltered(normalizedText, Configuration);

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
                if (Configuration.DisableSelfChatHistory && sender.TextValue == Configuration.PlayerName) return;

                var historyChannels = (ChatFlags.Channels)Configuration.ChatHistoryChannels;
                if (!historyChannels.Equals(ChatFlags.Channels.None))
                {
                    if (Flags.CheckFlags(Configuration, chatType))
                    {
                        var currentMessage = $"{sender.TextValue}: {message.TextValue}";
                        if (ChatHistory.Contains(currentMessage))
                        {
                            Log.Debug($"Found message in chat history and blocked: {currentMessage}");
                            isHandled = true;
                        }
                        else if (ChatHistory.Count > Configuration.ChatHistoryLength)
                        {
                            Log.Debug("Chat history reached limit. Removed oldest message and added:" +
                                      currentMessage);
                            ChatHistory.Pop();
                            ChatHistory.Push(currentMessage);
                        }
                        else
                        {
                            Log.Debug("Added:" + currentMessage);
                            ChatHistory.Push(currentMessage);
                            if (Configuration.ChatHistoryTimer > 0)
                            {
                                var t = new Timer
                                {
                                    Interval = Configuration.ChatHistoryTimer * 1000,
                                    AutoReset = false
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
            catch (Exception e)
            {
                Log.Debug("Encountered error: " + e);
            }

        #endregion Duplicate Message Spam Filter

        #region Debug Mode Enabled

        if (Configuration.EnableDebugMode && isHandled && !message.TextValue.StartsWith("[TidyChat]"))
        {
            var stringBuilder = new SeStringBuilder();
            Better.AddTidyChatTag(stringBuilder);
            Better.AddDebugTag(stringBuilder);
            stringBuilder.AddText($"[{chatType.ToString()}] ");
            stringBuilder.AddText(message.TextValue);
            message = stringBuilder.BuiltString;
            isHandled = false;
        }

        #endregion Debug Mode Enabled
        if (isHandled)
        {
            SessionBlockedMessages += 1;
        }
    }

    private static void CustomFilterCheck(SeString sender, SeString message, ref bool isHandled,
        PlayerName playerOrMessage,
        ChatType chatType)
    {
        if (!isHandled && !playerOrMessage.AllowMessage)
        {
            var e = (ChatFlags.Channels)playerOrMessage.whitelistedChannels;
            var isRegex = false;
            Regex userPattern = null;
            if (playerOrMessage.FirstName.StartsWith('/') && playerOrMessage.FirstName.EndsWith('/'))
            {
                isRegex = true;
                userPattern =
                    new Regex(playerOrMessage.FirstName.Substring(1, playerOrMessage.FirstName.Length - 2));
            }

            var channelSelectedToFilter = false;
            if (!e.Equals(ChatFlags.Channels.None))
                channelSelectedToFilter = Flags.CheckFlags(playerOrMessage, chatType);

            if (channelSelectedToFilter &&
                sender.TextValue == playerOrMessage.FirstName)
            {
                isHandled = true;
                Log.Debug($"The message from {playerOrMessage.FirstName} has been blocked.");
            }

            if (channelSelectedToFilter && !isRegex &&
                message.TextValue.Contains(playerOrMessage.FirstName))
            {
                isHandled = true;
                Log.Debug($"A message matching \"{playerOrMessage.FirstName}\" has been blocked.");
            }

            if (userPattern != null && channelSelectedToFilter && isRegex &&
                userPattern.IsMatch(message.ToString()))
            {
                isHandled = true;
                Log.Debug(
                    $"A message matching the regex \"{playerOrMessage.FirstName}\" has been blocked.");
            }
        }

        if (isHandled && playerOrMessage.AllowMessage)
        {
            var e = (ChatFlags.Channels)playerOrMessage.whitelistedChannels;
            var isRegex = false;
            Regex userPattern = null;
            if (playerOrMessage.FirstName.StartsWith('/') && playerOrMessage.FirstName.EndsWith('/'))
            {
                isRegex = true;
                userPattern =
                    new Regex(playerOrMessage.FirstName.Substring(1, playerOrMessage.FirstName.Length - 2));
            }

            var channelSelectedToFilter = false;
            if (!e.Equals(ChatFlags.Channels.None))
                channelSelectedToFilter = Flags.CheckFlags(playerOrMessage, chatType);

            if (channelSelectedToFilter &&
                sender.TextValue == playerOrMessage.FirstName)
            {
                isHandled = false;
                Log.Debug($"The message from {playerOrMessage.FirstName} has been allowed.");
            }

            if (channelSelectedToFilter && !isRegex &&
                message.TextValue.Contains(playerOrMessage.FirstName))
            {
                isHandled = false;
                Log.Debug($"A message matching \"{playerOrMessage.FirstName}\" has been allowed.");
            }

            if (userPattern != null && channelSelectedToFilter && isRegex &&
                userPattern.IsMatch(message.ToString()))
            {
                isHandled = false;
                Log.Debug(
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
            Configuration.Save();
        }
        catch
        {
            // Just don't do anything if we can't set player name
        }
    }

    unsafe private void InstanceDtrBarUpdate()
    {
        if (Configuration.InstanceInDtrBar)
            try
            {
                // This will return the instance value: 0,1,2,3,4,5,6
                int InstanceNumberFromSignature = (int)UIState.Instance()->PublicInstance.InstanceId;
                var instanceCharacter = ((char)(SeIconChar.Instance1 + (byte)(InstanceNumberFromSignature - 1))).ToString();

                if (InstanceNumberFromSignature >= 1)
                    UpdateDtrBarEntry($"{L10N.GetTidy(TidyStrings.InstanceWord)} {instanceCharacter}");
                else if (InstanceNumberFromSignature == 0) UpdateDtrBarEntry();
            }
            catch (Exception ex)
            {
                Log.Debug("Error: " + ex);
            }
        else if (!Configuration.InstanceInDtrBar && dtrEntry != null) dtrEntry?.Dispose();
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
        catch (Exception e)
        {
            Log.Error(e, "Something went wrong");
        }

        var commendationChange = TidyStrings.CommendationsEarned - TidyStrings.LastCommendations;
        TidyStrings.LastCommendations = TidyStrings.CommendationsEarned;

        if (commendationChange is >= 1 and <= 7)
        {
            var stringBuilder = new SeStringBuilder();
            if (Configuration.IncludeChatTag) Better.AddTidyChatTag(stringBuilder);

            var commendations = "";
            commendations = commendationChange == 1
                ? localization.BetterStrings_CommendationSingular
                : localization.BetterStrings_CommendationsPlural;

            var dutyName =
                $"{(Configuration.IncludeDutyNameInComms && TidyStrings.LastDuty.Length > 0 ? " " + localization.BetterStrings_CommendationsFromCompletingDuty + " " + TidyStrings.LastDuty + "." : ".")}";

            stringBuilder.AddText(string.Format(localization.BetterStrings_ReceivedCommendationsMessages,
                commendationChange.ToString(), commendations, dutyName));

            ChatGui.Print(stringBuilder.BuiltString);
        }
    }

    private void UpdateDtrBarEntry(string text = "")
    {
        dtrEntry.Text = text;
    }

    private void OnCommand(string command, string args)
    {
        SetPlayerName();
        PluginUi.SettingsVisible = true;
    }

    private void UpdateLang(string langCode)
    {
        localization.Culture = new CultureInfo(langCode);
    }

    private void DrawUI()
    {
        PluginUi.Draw();
    }

    private void DrawConfigUI()
    {
        SetPlayerName();
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
