using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Timers;
using ChatTwo.Code;
using Dalamud.Data;
using Dalamud.Game;
using Dalamud.Game.ClientState;
using Dalamud.Game.Command;
using Dalamud.Game.Gui;
using Dalamud.Game.Gui.Dtr;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.IoC;
using Dalamud.Logging;
using Dalamud.Plugin;
using Dalamud.Plugin.Ipc.Exceptions;
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
    private const string SettingsCommand = TidyStrings.SettingsCommand;
    private const string ShorthandCommand = TidyStrings.ShorthandCommand;
    private readonly DtrBarEntry dtrEntry;
    private ulong SessionBlockedMessages;

    #region Setup

    public TidyChat(
        [RequiredVersion("1.0")] DalamudPluginInterface pluginInterface,
        [RequiredVersion("1.0")] SigScanner sigScanner,
        [RequiredVersion("1.0")] ChatGui chatGui,
        [RequiredVersion("1.0")] DataManager dataManager,
        [RequiredVersion("1.0")] CommandManager commandManager,
        [RequiredVersion("1.0")] ClientState clientState)
    {
        PluginInterface = pluginInterface;
        SigScanner = sigScanner;
        CommandManager = commandManager;
        DataManager = dataManager;
        ChatGui = chatGui;
        ClientState = clientState;

        // Player cannot change this without restarting the game so should be safe to grab here
        L10N.Language = clientState.ClientLanguage;
        pluginInterface.LanguageChanged += UpdateLang;
        UpdateLang(pluginInterface.UiLanguage);
        // Sets name on install / plugin update
        SetPlayerName();

        Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Configuration.Initialize(PluginInterface);

        if (Configuration.InstanceInDtrBar)
            if (DtrBar != null)
                dtrEntry = DtrBar.Get(Name);

        ChatGui.ChatMessage += OnChat;
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

    private DataManager DataManager { get; } = null!;

    [PluginService] private DtrBar DtrBar { get; init; }
    private DalamudPluginInterface PluginInterface { get; }
    private SigScanner SigScanner { get; }
    private ChatGui ChatGui { get; }
    private CommandManager CommandManager { get; }
    private Configuration Configuration { get; }
    private PluginUI PluginUi { get; }
    private ClientState ClientState { get; }

    private Stack<string> ChatHistory { get; } = new();
    public string Name => TidyStrings.PluginName;

    public void Dispose()
    {
        dtrEntry?.Dispose();
        PluginUi.Dispose();
        CommandManager.RemoveHandler(SettingsCommand);
        CommandManager.RemoveHandler(ShorthandCommand);
        PluginInterface.LanguageChanged -= UpdateLang;
        ChatGui.ChatMessage -= OnChat;
        ClientState.TerritoryChanged -= OnTerritoryChanged;
        ClientState.Login -= OnLogin;
        ClientState.Logout -= OnLogout;
    }

    private void TippyIpcTips()
    {
        if (PluginInterface.PluginInternalNames.Contains("Tippy"))
        {
            var tippyTip = PluginInterface.GetIpcSubscriber<string, bool>("Tippy.RegisterTip");

            try
            {
                tippyTip.InvokeFunc(
                    localization.TidyChat_TippyTips1);
                tippyTip.InvokeFunc(localization.TidyChat_TippyTips2);
                tippyTip.InvokeFunc(
                    localization.TidyChat_TippyTips3);
                tippyTip.InvokeFunc(localization.TidyChat_TippyTips4);
                tippyTip.InvokeFunc(
                    localization.TidyChat_TippyTips6);

                switch (Configuration.TtlMessagesBlocked)
                {
                    case > 1000000:
                        tippyTip.InvokeFunc(localization.TidyChat_TippyTipsOverOneMillion);
                        break;
                    case > 500000:
                        tippyTip.InvokeFunc(localization.TidyChat_TippyTipsOverFiveHundredThousand);
                        break;
                    case > 100000:
                        tippyTip.InvokeFunc(localization.TidyChat_TippyTipsOverOneHundredThousand);
                        break;
                    case > 50000:
                        tippyTip.InvokeFunc(localization.TidyChat_TippyTipsOverFiftyThousand);
                        break;
                    case > 10000:
                        tippyTip.InvokeFunc(localization.TidyChat_TippyTipsOverTenThousand);
                        break;
                    case > 5000:
                        tippyTip.InvokeFunc(localization.TidyChat_TippyTipsOverFiveThousand);
                        break;
                    case > 1000:
                        tippyTip.InvokeFunc(localization.TidyChat_TippyTipsOverOneThousand);
                        break;
                    case > 100:
                        tippyTip.InvokeFunc(localization.TidyChat_TippyTipsOverOneHundred);
                        break;
                    case <= 100:
                        break;
                }
            }
            catch (IpcNotReadyError)
            {
                var noTippyMessage = new SeStringBuilder();
                if (Configuration.IncludeChatTag) Better.AddTidyChatTag(noTippyMessage);

                noTippyMessage.AddText(localization.TidyChat_TippyIpcToEnable);
                ChatGui.Print(noTippyMessage.BuiltString);
            }
        }
        else
        {
            var noTippyMessage = new SeStringBuilder();
            if (Configuration.IncludeChatTag) Better.AddTidyChatTag(noTippyMessage);

            noTippyMessage.AddText(localization.TidyChat_TippyIpcToEnable);
            ChatGui.Print(noTippyMessage.BuiltString);
        }
    }

    private void TippyIpcMessages(ushort msg)
    {
        var tippyMsg = PluginInterface.GetIpcSubscriber<string, bool>("Tippy.RegisterMessage");
        try
        {
            switch (msg)
            {
                case 0:
                    tippyMsg.InvokeFunc("Tidy Chat IPC Test Message.");
                    break;
                case 1:
                    var rnd = new Random().Next(100);
                    switch (rnd)
                    {
                        case 0:
                            tippyMsg.InvokeFunc(
                                localization.TidyChat_TippyIpcMessagesDancingThancred);
                            break;
                        case > 85:
                            tippyMsg.InvokeFunc(
                                localization.TidyChat_TippyIpcMessagesZeroCommendations);
                            break;
                    }

                    break;
                case 2:
                    tippyMsg.InvokeFunc(localization.TidyChat_TippyIpcMessagesPopularCommendations);
                    break;
            }
        }
        catch (IpcNotReadyError)
        {
            var noTippyMessage = new SeStringBuilder();
            if (Configuration.IncludeChatTag) Better.AddTidyChatTag(noTippyMessage);

            noTippyMessage.AddText(localization.TidyChat_TippyIpcToEnable);
            ChatGui.Print(noTippyMessage.BuiltString);
        }
    }

    private void OnLogin(object? sender, EventArgs e)
    {
        if (Configuration.EnableTippyTips) TippyIpcTips();
        if (Configuration.BetterCommendationMessage) UpdateCommendationsCount();

        InstanceDtrBarUpdates();
    }

    private void OnLogout(object? sender, EventArgs e)
    {
        UpdateBlockedCount();
    }

    private void OnTerritoryChanged(object? sender, ushort e)
    {
        UpdateBlockedCount();
        UpdateCommendationsCount();
        InstanceDtrBarUpdates();

        if (Configuration.IncludeDutyNameInComms)
            try
            {
                var territory = DataManager.GetExcelSheet<TerritoryType>()?.GetRow(e);
                var exclusiveType = DataManager.GetExcelSheet<TerritoryType>()
                    ?.GetRow(e)
                    ?.ExclusiveType;
                var isPvp = DataManager.GetExcelSheet<TerritoryType>()
                    ?.GetRow(e)
                    ?.IsPvpZone;
                if (territory != null)
                {
                    var placeName = DataManager.GetExcelSheet<ContentFinderCondition>()
                        ?.GetRow(territory.PlaceName.Row)
                        ?.Name.ToString();
                    var dutyName = DataManager.GetExcelSheet<ContentFinderCondition>()
                        ?.GetRow(territory.ContentFinderCondition.Row)
                        ?.Name.ToString();
                    TidyStrings.LastDuty = exclusiveType switch
                    {
                        2 when dutyName?.Length >= 1 => dutyName,
                        2 when dutyName?.Length == 0 && placeName?.Length > 0 => placeName,
                        2 when dutyName?.Length == 0 && isPvp == true => L10N.GetTidy(TidyStrings.PvPDuty),
                        _ => TidyStrings.LastDuty
                    };
                }
            }
            catch (KeyNotFoundException)
            {
                PluginLog.Warning("Could not get territory for current zone");
            }
    }

    private void OnChat(XivChatType type, uint senderId, ref SeString sender, ref SeString message,
        ref bool isHandled)
    {
        if (!Configuration.Enabled) return;

        var chatType = FromDalamud(type);
        var normalizedText = NormalizeInput.ToLowercase(message);

        if (L10N.Get(ChatRegexStrings.QuestionMarkCommandResponse).IsMatch(normalizedText) &&
            Configuration.FilterSystemMessages)
            Better.TemporarilyDisableSystemFilter(Configuration, ChatGui);

        if (Configuration.PlayerName != "") normalizedText = NormalizeInput.ReplaceName(normalizedText, Configuration);

        if (Configuration.HideDebugTeleport && !Configuration.EnableDebugMode && chatType is ChatType.Debug &&
            L10N.Get(ChatStrings.DebugTeleport).All(normalizedText.Contains))
            isHandled = true;

        #region Better Messages

        if (Configuration.BetterInstanceMessage && !Configuration.HideInstanceMessage &&
            !Configuration.EnableDebugMode && chatType is ChatType.System &&
            L10N.Get(ChatStrings.InstancedArea).All(normalizedText.Contains))
            message = Better.Instances(message, Configuration);

        if (Configuration.BetterSayReminder && !Configuration.HideQuestReminder && !Configuration.EnableDebugMode &&
            chatType is ChatType.System && L10N.Get(ChatStrings.SayQuestReminder).All(normalizedText.Contains))
            message = Better.SayReminder(message, Configuration);

        if (Configuration.BetterCommendationMessage && !Configuration.EnableDebugMode &&
            L10N.Get(ChatStrings.PlayerCommendation).All(normalizedText.Contains))
            isHandled = true;

        if (Configuration.BetterNoviceNetworkMessage && !Configuration.EnableDebugMode)
            message = Better.NoviceNetwork(message, normalizedText, Configuration);

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
                            PluginLog.LogDebug($"Found message in chat history and blocked: {currentMessage}");
                            isHandled = true;
                        }
                        else if (ChatHistory.Count > Configuration.ChatHistoryLength)
                        {
                            PluginLog.LogDebug("Chat history reached limit. Removed oldest message and added:" +
                                               currentMessage);
                            ChatHistory.Pop();
                            ChatHistory.Push(currentMessage);
                        }
                        else
                        {
                            PluginLog.LogDebug("Added:" + currentMessage);
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
                PluginLog.LogDebug("Encountered error: " + e);
            }

        #endregion Duplicate Message Spam Filter

        #region Whitelist

        if (Configuration.Whitelist.Count > 0)
            foreach (var player in Configuration.Whitelist)
                if ((isHandled && sender.TextValue == player.FirstName + " " + player.LastName) ||
                    (message.TextValue.Contains(player.FirstName) && message.TextValue.Contains(player.LastName)))
                {
                    if (Configuration.SentByWhitelistPlayer)
                    {
                        // The message was sent by a whitelisted player
                        isHandled = false;
                    }
                    else if (Configuration.TargetingWhitelistPlayer && player.ServerName.Length > 0 &&
                             message.TextValue.Contains(player.FirstName) &&
                             message.TextValue.Contains(player.LastName) &&
                             message.TextValue.Contains(player.ServerName))
                    {
                        // The whitelisted player name is limited to a server
                        isHandled = false;
                    }
                    else if (Configuration.TargetingWhitelistPlayer &&
                             message.TextValue.Contains(player.FirstName) &&
                             message.TextValue.Contains(player.LastName))
                    {
                        // The whitelisted player isn't limited to a server
                        isHandled = false;
                    }
                    else
                    {
                        var e = (ChatFlags.Channels)player.whitelistedChannels;
                        if (!e.Equals(ChatFlags.Channels.None) && isHandled)
                        {
                            isHandled = Flags.CheckFlags(player, chatType);
                            return;
                        }
                    }
                }

        #endregion Whitelist

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

        SessionBlockedMessages += 1;
        if (SessionBlockedMessages > 100) UpdateBlockedCount();
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

    private void InstanceDtrBarUpdates()
    {
        if (Configuration.InstanceInDtrBar)
            try
            {
                var InstanceSignaturePtr =
                    SigScanner.GetStaticAddressFromSig("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 80 BD");

                // This will return the instance value: 0,1,2,3
                int InstanceNumberFromSignature = Marshal.ReadByte(InstanceSignaturePtr, 0x20);

                if (InstanceNumberFromSignature == 1)
                    UpdateDtrBarEntry($"{L10N.GetTidy(TidyStrings.InstanceWord)} {TidyStrings.FirstInstance}");
                else if (InstanceNumberFromSignature == 2)
                    UpdateDtrBarEntry($"{L10N.GetTidy(TidyStrings.InstanceWord)} {TidyStrings.SecondInstance}");
                else if (InstanceNumberFromSignature == 3)
                    UpdateDtrBarEntry($"{L10N.GetTidy(TidyStrings.InstanceWord)} {TidyStrings.ThirdInstance}");
                else if (InstanceNumberFromSignature == 0) UpdateDtrBarEntry();
            }
            catch (Exception ex)
            {
                PluginLog.LogDebug("Error: " + ex);
            }
        else if (!Configuration.InstanceInDtrBar && dtrEntry != null) dtrEntry?.Dispose();
    }

    private void UpdateBlockedCount()
    {
        Configuration.TtlMessagesBlocked += SessionBlockedMessages;
        SessionBlockedMessages = 0;
        Configuration.Save();
    }

    private void UpdateCommendationsCount()
    {
        var totalCommendationsPtr =
            SigScanner.GetStaticAddressFromSig("66 89 05 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8B 44 24 60");
        TidyStrings.CommendationsEarned = Marshal.ReadInt16(totalCommendationsPtr);
        var commendationChange = TidyStrings.CommendationsEarned - TidyStrings.LastCommendations;
        TidyStrings.LastCommendations = TidyStrings.CommendationsEarned;

        if (PluginInterface.PluginInternalNames.Contains("Tippy") && commendationChange == 0) TippyIpcMessages(1);
        if (PluginInterface.PluginInternalNames.Contains("Tippy") && commendationChange >= 3) TippyIpcMessages(2);

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