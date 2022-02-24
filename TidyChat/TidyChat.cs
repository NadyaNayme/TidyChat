using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Game.ClientState;
using Dalamud.Game.Command;
using Dalamud.Game.Gui;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;

using TidyChat.Utility;
using GetDuty = TidyChat.Utility.GetDutyName;
using TidyStrings = TidyChat.Utility.InternalStrings;
using Better = TidyChat.Utility.BetterStrings;

using System.Linq;
using ChatTwo.Code;
using System.Collections.Generic;
using Dalamud.Logging;
using System;

namespace TidyChat

{
    public sealed class TidyChat : IDalamudPlugin
    {
        public string Name => TidyStrings.PluginName;

        private const string SettingsCommand = TidyStrings.SettingsCommand;
        private const string ShorthandCommand = TidyStrings.ShorthandCommand;

        private DalamudPluginInterface PluginInterface { get; init; }
        private ChatGui ChatGui { get; init; }
        private CommandManager CommandManager { get; init; }
        private Configuration Configuration { get; init; }
        private PluginUI PluginUi { get; init; }
        private ClientState ClientState { get; init; }

        private Stack<string> ChatHistory { get; init; } = new();

        #region Chat2 ChatTypes
        // Stole this region from Anna's Chat2: https://git.annaclemens.io/ascclemens/ChatTwo/src/branch/main/ChatTwo
        private const ushort Clear7 = ~(~0 << 7);
        internal ushort Raw { get; }
        internal ChatType Type => (ChatType)(this.Raw & Clear7);

        private static ChatType FromCode(ushort code)
        {
            return (ChatType)(code & Clear7);
        }

        private static ChatType FromDalamud(XivChatType type)
        {
            return FromCode((ushort)type);
        }
        #endregion Chat2 ChatTypes
        #region Setup
        public TidyChat(
            [RequiredVersion("1.0")] DalamudPluginInterface pluginInterface,
            [RequiredVersion("1.0")] ChatGui chatGui,
            [RequiredVersion("1.0")] CommandManager commandManager,
            [RequiredVersion("1.0")] ClientState clientState)
        {
            this.PluginInterface = pluginInterface;
            this.CommandManager = commandManager;
            this.ChatGui = chatGui;
            this.ClientState = clientState;

            // Player cannot change this without restarting the game so should be safe to grab here
            Localization.Language = clientState.ClientLanguage;
            // Sets name on install / plugin update
            SetPlayerName();

            this.Configuration = this.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            this.Configuration.Initialize(this.PluginInterface);

            ChatGui.ChatMessage += OnChat;

            this.PluginUi = new PluginUI(this.Configuration);

            this.CommandManager.AddHandler(SettingsCommand, new CommandInfo(OnCommand)
            {
                HelpMessage = TidyStrings.SettingsHelper
            });

            this.CommandManager.AddHandler(ShorthandCommand, new CommandInfo(OnCommand)
            {
                HelpMessage = TidyStrings.ShorthandHelper
            });

            this.PluginInterface.UiBuilder.Draw += DrawUI;
            this.PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;
        }
        #endregion Setup

        public void Dispose()
        {
            this.PluginUi.Dispose();
            this.CommandManager.RemoveHandler(SettingsCommand);
            this.CommandManager.RemoveHandler(ShorthandCommand);
            this.ChatGui.ChatMessage -= this.OnChat;
        }


        private void OnChat(XivChatType type, uint senderId, ref SeString sender, ref SeString message, ref bool isHandled)
        {
            if (!Configuration.Enabled)
            {
                return;
            }

            var chatType = FromDalamud(type);
            string normalizedText = NormalizeInput.ToLowercase(message);

            if (Configuration.PlayerName != "" && Configuration.PlayerName != null)
            {
                normalizedText = NormalizeInput.ReplaceName(normalizedText, Configuration);
            }

            if (Configuration.HideDebugTeleport && chatType is ChatType.Debug && Localization.Get(ChatStrings.DebugTeleport).All(normalizedText.Contains))
            {
                isHandled = true;
            }

            #region Better Messages
            if (Configuration.BetterInstanceMessage && chatType is ChatType.System && Localization.Get(ChatStrings.InstancedArea).All(normalizedText.Contains))
            {
                message = Better.Instances(message, Configuration);
            }

            if (Configuration.BetterSayReminder && !Configuration.HideQuestReminder && chatType is ChatType.System && Localization.Get(ChatStrings.SayQuestReminder).All(normalizedText.Contains))
            {
                message = Better.SayReminder(message, Configuration);
            }

            if (Configuration.IncludeDutyNameInComms)
            {
                TidyStrings.LastDuty = GetDuty.FindIn(message, normalizedText);
            }

            if (Configuration.BetterCommendationMessage && Localization.Get(ChatStrings.PlayerCommendation).All(normalizedText.Contains))
            {
                isHandled = true;
                Better.Commendations(Configuration, ChatGui);
            }

            if (Configuration.BetterNoviceNetworkMessage)
            {
                message = Better.NoviceNetwork(message, normalizedText, Configuration);
            }
            #endregion

            #region Channel Filters
            #region Emotes
            if (Configuration.FilterEmoteSpam && chatType is ChatType.StandardEmote)
            {
                isHandled = FilterEmoteMessages.IsFiltered(normalizedText, chatType, Configuration);
            }

            if (Configuration.HideOtherCustomEmotes && sender.TextValue != Configuration.PlayerName && chatType is ChatType.CustomEmote)
            {
                isHandled = FilterEmoteMessages.IsFiltered(normalizedText, chatType, Configuration);
            }

            if (Configuration.HideUsedEmotes && (chatType is ChatType.StandardEmote || chatType is ChatType.CustomEmote) && sender.TextValue == Configuration.PlayerName)
            {
                isHandled = true;
            }
            #endregion Emotes
            if (Configuration.FilterSystemMessages && chatType is ChatType.System)
            {
                isHandled = FilterSystemMessages.IsFiltered(normalizedText, Configuration);
            }

            if (Configuration.FilterObtainedSpam && chatType is ChatType.LootNotice)
            {
                isHandled = FilterObtainMessages.IsFiltered(normalizedText, Configuration);
            }

            if (Configuration.FilterLootSpam && chatType is ChatType.LootRoll)
            {
                isHandled = FilterLootMessages.IsFiltered(normalizedText, Configuration);
            }

            if (Configuration.FilterProgressSpam && chatType is ChatType.Progress)
            {
                isHandled = FilterProgressMessages.IsFiltered(normalizedText, Configuration);
            }

            #region DoH/DoL
            if (Configuration.FilterCraftingSpam && chatType is ChatType.Crafting)
            {
                isHandled = FilterCraftMessages.IsFiltered(normalizedText, Configuration);
            }

            if (Configuration.FilterGatheringSpam && chatType is ChatType.GatheringSystem or ChatType.Gathering)
            {
                isHandled = FilterGatherMessages.IsFiltered(normalizedText, Configuration);
            }
            #endregion DoH/DoL

            if ((Configuration.HideUserLogins || Configuration.HideUserLogouts) && chatType is ChatType.FreeCompanyLoginLogout)
            {
                isHandled = FilterFreeCompanyMessages.IsFiltered(normalizedText, Configuration);
            }
            #endregion Channel Filters

            #region Whitelist
            if (Configuration.Whitelist.Count > 0)
            {
                foreach (var player in Configuration.Whitelist)
                {
                    if (Configuration.SentByWhitelistPlayer && sender.TextValue == player.FirstName + " " + player.LastName)
                    {
                        // The message was sent by a whitelisted player
                        isHandled = false;
                    }
                    else if (Configuration.TargetingWhitelistPlayer && player.ServerName.Length > 0 && message.TextValue.Contains(player.FirstName) && message.TextValue.Contains(player.LastName) && message.TextValue.Contains(player.ServerName))
                    {
                        // The whitelisted player name is limited to a server
                        isHandled = false;
                    }
                    else if (Configuration.TargetingWhitelistPlayer && message.TextValue.Contains(player.FirstName) && message.TextValue.Contains(player.LastName))
                    {
                        // The whitelisted player isn't limited to a server
                        isHandled = false;
                    }
                }
            }
            #endregion Whitelist

            #region Duplicate Message Spam Filter
            if (Configuration.ChatHistoryFilter && !isHandled && ((Configuration.ChatHistoryFilterOverride && chatType is not ChatType.BattleSystem && chatType is not ChatType.GainBuff && chatType is not ChatType.GainDebuff && chatType is not ChatType.Action && chatType is not ChatType.Healing && chatType is not ChatType.LoseBuff && chatType is not ChatType.LoseDebuff && chatType is not ChatType.Miss && chatType is not ChatType.FreeCompanyLoginLogout && chatType is not ChatType.Debug) || chatType is ChatType.StandardEmote || chatType is ChatType.CustomEmote))
            {
                try
                {
                    string currentMessage = $"{sender.TextValue}: {message.TextValue}";
                    if (ChatHistory.Contains(currentMessage))
                    {
                        PluginLog.LogDebug($"Found message in chat history and blocked: {currentMessage}");
                        isHandled = true;
                    }
                    else if (ChatHistory.Count > Configuration.ChatHistoryLength)
                    {
                        PluginLog.LogDebug("Chat history reached limit. Removed oldest message and added:" + currentMessage);
                        ChatHistory.Pop();
                        ChatHistory.Push(currentMessage);
                    }
                    else
                    {
                        PluginLog.LogDebug("Added:" + currentMessage);
                        ChatHistory.Push(currentMessage);
                    }
                }
                catch (Exception e)
                {
                    PluginLog.LogDebug("Encountered error: " + e);
                }
            }
            #endregion Duplicate Message Spam Filter
        }

        private void SetPlayerName() {
            try {
                if (ClientState.LocalPlayer == null)
                {
                    return;
                }
                this.Configuration.PlayerName = $"{ClientState.LocalPlayer.Name}";
                this.Configuration.Save();
            }
            catch
            {
                // Just don't do anything if we can't set player name
            }
        }
        private void OnCommand(string command, string args)
        {
            SetPlayerName();
            this.PluginUi.SettingsVisible = true;
        }

        private void DrawUI()
        {
            this.PluginUi.Draw();
        }

        private void DrawConfigUI()
        {
            SetPlayerName();
            this.PluginUi.SettingsVisible = true;
        }
    }
}
