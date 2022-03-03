using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Game.ClientState;
using Dalamud.Game.Command;
using Dalamud.Game.Gui;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Gui.Dtr;

using TidyChat.Utility;
using GetDuty = TidyChat.Utility.GetDutyName;
using TidyStrings = TidyChat.Utility.InternalStrings;
using Better = TidyChat.Utility.BetterStrings;
using Flags = TidyChat.Utility.ChatFlags;

using System.Linq;
using ChatTwo.Code;
using System.Collections.Generic;
using Dalamud.Logging;
using System;
using static TidyChat.Utility.ChatFlags;
using Dalamud;

namespace TidyChat

{
    public sealed class TidyChat : IDalamudPlugin
    {
        public string Name => TidyStrings.PluginName;

        private const string SettingsCommand = TidyStrings.SettingsCommand;
        private const string ShorthandCommand = TidyStrings.ShorthandCommand;

        [PluginService] private DtrBar DtrBar { get; init; }
        private DalamudPluginInterface PluginInterface { get; init; }
        private ChatGui ChatGui { get; init; }
        private CommandManager CommandManager { get; init; }
        private Configuration Configuration { get; init; }
        private PluginUI PluginUi { get; init; }
        private ClientState ClientState { get; init; }

        private Stack<string> ChatHistory { get; init; } = new();
        private DtrBarEntry dtrEntry;

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
            this.dtrEntry = DtrBar.Get(this.Name);

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
            this.dtrEntry.Dispose();
            this.PluginUi.Dispose();
            this.CommandManager.RemoveHandler(SettingsCommand);
            this.CommandManager.RemoveHandler(ShorthandCommand);
            this.ChatGui.ChatMessage -= this.OnChat;
        }

        private bool leftSanctuary = false;
        private bool enteredSanctuary = false;
        private bool receivedInstanceText = false;

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

            if (Configuration.HideDebugTeleport && !Configuration.EnableDebugMode && chatType is ChatType.Debug && Localization.Get(ChatStrings.DebugTeleport).All(normalizedText.Contains))
            {
                isHandled = true;
            }

            #region Better Messages
            if (Configuration.BetterInstanceMessage && !Configuration.HideInstanceMessage && !Configuration.EnableDebugMode && chatType is ChatType.System && Localization.Get(ChatStrings.InstancedArea).All(normalizedText.Contains))
            {
               message = Better.Instances(message, Configuration);
            }

            if (Configuration.UseDTRBar && (chatType is ChatType.System || chatType is ChatType.Error) && Localization.Get(ChatRegexStrings.NotInstancedArea).IsMatch(normalizedText) || Localization.Get(ChatStrings.HasBegun).All(normalizedText.Contains) || Localization.Get(ChatRegexStrings.LeftSanctuary).IsMatch(normalizedText) || Localization.Get(ChatRegexStrings.EnteredSanctuary).IsMatch(normalizedText) || Localization.Get(ChatRegexStrings.GetInstanceNumber).IsMatch(normalizedText))
            {
                string instanceNumber = "";
                if (Localization.Get(ChatRegexStrings.NotInstancedArea).IsMatch(normalizedText) || Localization.Get(ChatStrings.HasBegun).All(normalizedText.Contains))
                {
                    isHandled = true;
                    UpdateDtrBarEntry("");
                } 
                else if (Localization.Get(ChatRegexStrings.LeftSanctuary).IsMatch(normalizedText) || Localization.Get(ChatRegexStrings.EnteredSanctuary).IsMatch(normalizedText) || Localization.Get(ChatRegexStrings.GetInstanceNumber).IsMatch(normalizedText))
                {
                    if (Localization.Get(ChatRegexStrings.LeftSanctuary).IsMatch(normalizedText))
                    {
                        leftSanctuary = true;
                        receivedInstanceText = false;
                    }
                    if (Localization.Get(ChatRegexStrings.EnteredSanctuary).IsMatch(normalizedText))
                    {
                        enteredSanctuary = true;
                        receivedInstanceText = false;
                    }
                    if (Localization.Get(ChatRegexStrings.GetInstanceNumber).IsMatch(normalizedText) && Localization.Get(ChatStrings.InstancedArea).All(normalizedText.Contains))
                    {
                        receivedInstanceText = true;
                    }
                    if (leftSanctuary && enteredSanctuary)
                    {
                        var t = new System.Timers.Timer
                        {
                            Interval = Configuration.InstanceMessageTimer,
                            AutoReset = false
                        };
                        t.Elapsed += delegate
                        {
                            t.Enabled = false;
                            if (!receivedInstanceText)
                            {
                                UpdateDtrBarEntry("");
                            }
                            t.Dispose();
                            leftSanctuary = false;
                            enteredSanctuary = false;
                        };
                        t.Enabled = true;
                    }
                    if (leftSanctuary || enteredSanctuary)
                    {
                        var t = new System.Timers.Timer
                        {
                            Interval = Configuration.InstanceMessageTimer + 50,
                            AutoReset = false
                        };
                        t.Elapsed += delegate
                        {
                            t.Enabled = false;
                            t.Dispose();
                            leftSanctuary = false;
                            enteredSanctuary = false;
                        };
                        t.Enabled = true;
                    }
                }
                if (Localization.Get(ChatRegexStrings.GetInstanceNumber).IsMatch(normalizedText) && Localization.Get(ChatStrings.InstancedArea).All(normalizedText.Contains))
                {
                    instanceNumber = Localization.Get(ChatRegexStrings.GetInstanceNumber).Matches(normalizedText).First().Groups["instance"].Value;
                    if (instanceNumber == "")
                    {
                        UpdateDtrBarEntry($"Instance ");
                    }
                    else if (instanceNumber == "")
                    {
                        UpdateDtrBarEntry($"Instance ");
                    }
                    else if (instanceNumber == "")
                    {
                        UpdateDtrBarEntry($"Instance ");
                    }
                }
            } else if (!Configuration.UseDTRBar)
            {
                UpdateDtrBarEntry("");
            }

            if (Configuration.BetterSayReminder && !Configuration.HideQuestReminder && !Configuration.EnableDebugMode && chatType is ChatType.System && Localization.Get(ChatStrings.SayQuestReminder).All(normalizedText.Contains))
            {
                message = Better.SayReminder(message, Configuration);
            }

            if (Configuration.IncludeDutyNameInComms && !Configuration.EnableDebugMode)
            {
                TidyStrings.LastDuty = GetDuty.FindIn(message, normalizedText);
            }

            if (Configuration.BetterCommendationMessage && !Configuration.EnableDebugMode && Localization.Get(ChatStrings.PlayerCommendation).All(normalizedText.Contains))
            {
                isHandled = true;
                Better.Commendations(Configuration, ChatGui);
            }

            if (Configuration.BetterNoviceNetworkMessage && !Configuration.EnableDebugMode)
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

            #region Duplicate Message Spam Filter
            if (Configuration.ChatHistoryFilter && !isHandled)
            {
                try
                {
                    /* Disable Chat History for self-sent messages by default */
                    if (Configuration.DisableSelfChatHistory && sender.TextValue == Configuration.PlayerName)
                    {
                        return;
                    }
                    Channels historyChannels = (Channels)Configuration.ChatHistoryChannels;
                    if (!historyChannels.Equals(Flags.Channels.None))
                    {
                        if(Flags.CheckFlags(Configuration, chatType))
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
                        return;
                    }
                }
                catch (Exception e)
                {
                    PluginLog.LogDebug("Encountered error: " + e);
                }
            }
            #endregion Duplicate Message Spam Filter

            #region Whitelist
            if (Configuration.Whitelist.Count > 0)
            {
                foreach (var player in Configuration.Whitelist)
                {
                    if (isHandled && sender.TextValue == player.FirstName + " " + player.LastName || message.TextValue.Contains(player.FirstName) && message.TextValue.Contains(player.LastName))
                    {

                        if (Configuration.SentByWhitelistPlayer)
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
                        else
                        {
                            Channels e = (Channels)player.whitelistedChannels;
                            if (!e.Equals(Flags.Channels.None) && isHandled)
                            {
                                isHandled = Flags.CheckFlags(player, chatType);
                                return;
                            }
                        }
                    }
                }
            }
            #endregion Whitelist

            #region Debug Mode Enabled
            if (Configuration.EnableDebugMode && isHandled && !message.TextValue.ToString().StartsWith("[TidyChat]"))
            {
                var stringBuilder = new SeStringBuilder();
                stringBuilder.AddUiForeground(14);
                stringBuilder.AddText(TidyStrings.Tag);
                stringBuilder.AddUiForegroundOff();
                stringBuilder.AddUiForeground(8);
                stringBuilder.AddText(TidyStrings.DebugTag);
                stringBuilder.AddUiForegroundOff();
                stringBuilder.AddText(message.TextValue);
                message = stringBuilder.BuiltString;
                isHandled = false;
            }
            #endregion Debug Mode Enabled
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
        private void UpdateDtrBarEntry(string text = "")
        {
            dtrEntry.Text = text;
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
