using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Game.ClientState;
using Dalamud.Game.Command;
using Dalamud.Game.Gui;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using System.Linq;
using System.Text.RegularExpressions;
using ChatTwo.Code;
using Dalamud.Logging;

namespace TidyChat

{
    public sealed class TidyChat : IDalamudPlugin
    {
        public string Name => "Tidy Chat";

        private const string SettingsCommand = "/tidychat";
        private const string ShorthandCommand = "/tidy";

        private DalamudPluginInterface PluginInterface { get; init; }
        private ChatGui ChatGui { get; init; }
        private CommandManager CommandManager { get; init; }
        private Configuration Configuration { get; init; }
        private PluginUI PluginUi { get; init; }
        private ClientState ClientState { get; init; }

        // Lifted below lines (27-39) from Anna's Chat2
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

            // player cannot change this without restarting the game so should be safe to grab here
            Localization.language = clientState.ClientLanguage;
            // sets name on first install / plugin update
            SetPlayerName();

            this.Configuration = this.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            this.Configuration.Initialize(this.PluginInterface);

            ChatGui.ChatMessage += OnChat;

            this.PluginUi = new PluginUI(this.Configuration);

            this.CommandManager.AddHandler(SettingsCommand, new CommandInfo(OnCommand)
            {
                HelpMessage = "Open settings"
            });

            this.CommandManager.AddHandler(ShorthandCommand, new CommandInfo(OnCommand)
            {
                HelpMessage = "Shorthand command to open settings"
            });

            this.PluginInterface.UiBuilder.Draw += DrawUI;
            this.PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;
        }

        public int numberOfCommendations = 0;
        public string lastDuty = "";

        public void Dispose()
        {
            this.PluginUi.Dispose();
            this.CommandManager.RemoveHandler(SettingsCommand);
            this.CommandManager.RemoveHandler(ShorthandCommand);
            this.ChatGui.ChatMessage -= this.OnChat;
        }


        private void OnChat(XivChatType type, uint senderId, ref SeString sender, ref SeString message, ref bool isHandled)
        {
            // Lifted below line from Anna's chat2
            var chatType = FromDalamud(type);

            // Make everything lowercase so I don't have to think about which words are capitalized in the message
            string normalizedText = message.TextValue.ToLower();

            if (!Configuration.Enabled)
            {
                return;
            }

            if (Configuration.PlayerName != "" && Configuration.PlayerName != null)
            {
                // I do not claim to be a smart man, but I do like to dabble in the dark magics.
                string FirstNameLastInitial = $"{Configuration.PlayerName.Split(' ')[0]} {Configuration.PlayerName.Split(' ')[1][0]}.";
                string FirstInitialLastName = $"{Configuration.PlayerName.Split(' ')[0][0]}. {Configuration.PlayerName.Split(' ')[1]}";
                string InitialsOnly = $"{Configuration.PlayerName.Split(' ')[0][0]}. {Configuration.PlayerName.Split(' ')[1][0]}.";
                Regex FNLI = new(FirstNameLastInitial.ToLower());
                Regex FILN = new(FirstInitialLastName.ToLower());
                Regex IO = new(InitialsOnly.ToLower());
                // important: Japanese matchers depend on the player's name being replaced by "you",
                // as there is no other way to distinguish messages about the player.
                normalizedText = normalizedText.Replace($"{Configuration.PlayerName.ToLower()}", "you");
                normalizedText = FNLI.Replace(normalizedText, "you", 1);
                normalizedText = FILN.Replace(normalizedText, "you", 1);
                normalizedText = IO.Replace(normalizedText, "you", 1);
            }

            if (Configuration.BetterInstanceMessage && chatType is ChatType.System && ChatStrings.InstancedArea.All(normalizedText.Contains))
            {
                // The last character in the first sentence is the instanceNumber so
                // we capture it by finding the period that ends the first sentence and going back one character
                int index = message.TextValue.IndexOf('.');
                string instanceNumber = message.TextValue.Substring(index - 1, 1);
                var stringBuilder = new SeStringBuilder();
                if (Configuration.IncludeChatTag)
                {
                    stringBuilder.AddUiForeground(14);
                    stringBuilder.AddText($"[TidyChat] ");
                    stringBuilder.AddUiForegroundOff();
                }
                stringBuilder.AddText($"You are now in instance: {instanceNumber}");
                message = stringBuilder.BuiltString;
            }

            if (Configuration.BetterSayReminder && !Configuration.HideQuestReminder && chatType is ChatType.System && ChatStrings.SayQuestReminder.All(normalizedText.Contains))
            {
                // With the chat mode in Say, enter a phrase containing "Capture this"

                int containingPhraseStart = message.TextValue.IndexOf('“');
                int containingPhraseEnd = message.TextValue.LastIndexOf('”');
                int lengthOfPhrase = containingPhraseEnd - containingPhraseStart;
                string containingPhrase = message.TextValue.Substring(containingPhraseStart + 1, lengthOfPhrase - 1);
                message = $"/say {containingPhrase}";
                if (Configuration.CopyBetterSayReminder)
                {
                    var stringBuilder = new SeStringBuilder();
                    if (Configuration.IncludeChatTag)
                    {
                        stringBuilder.AddUiForeground(14);
                        stringBuilder.AddText($"[TidyChat] ");
                        stringBuilder.AddUiForegroundOff();
                    }
                    stringBuilder.AddText($"\"/say {containingPhrase}\" has been copied to clipboard");
                    TextCopy.ClipboardService.SetText($"/say {containingPhrase}");
                    message = stringBuilder.BuiltString;
                }
            }

            if (Configuration.BetterCommendationMessage && ChatStrings.PlayerCommendation.All(normalizedText.Contains))
            {

                isHandled = true;
                numberOfCommendations++;

                if (ChatStrings.DutyEnded.All(normalizedText.Contains))
                {
                    //      match here then go back 4 characters to capture everything before " has"
                    //           |
                    //           v
                    // <duty> has ended.
                    lastDuty = message.TextValue.Substring(0, message.TextValue.LastIndexOf(" ") - 4);
                }

                if (ChatStrings.GuildhestEnded.All(normalizedText.Contains))
                {
                    lastDuty = "a Guildhest";
                }

                if ((ChatStrings.GainPvpExp.All(normalizedText.Contains) ||
                     ChatStrings.CappedWolfMarks.All(normalizedText.Contains) ||
                     ChatStrings.ObtainWolfMarks.All(normalizedText.Contains))
                   )
                {
                    lastDuty = "a PvP duty";
                }

                if (ChatStrings.PalaceOfTheDead.All(normalizedText.Contains))
                {
                    lastDuty = "Palace of the Dead";
                }

                if (ChatStrings.HeavenOnHigh.All(normalizedText.Contains))
                {
                    lastDuty = "Heaven-on-High";
                }

                // Give it a few seconds before sending the /debug message with the total number of commendations in case there is any lag between commendation messages
                // There shouldn't be any lag since I think they all get sent at once - but having this small wait guarantees that there won't be any problems
                if (numberOfCommendations == 1)
                {
                    var t = new System.Timers.Timer();
                    t.Interval = 2500;
                    t.AutoReset = false;
                    t.Elapsed += delegate
                    {
                        var stringBuilder = new SeStringBuilder();
                        if (Configuration.IncludeChatTag)
                        {
                            stringBuilder.AddUiForeground(14);
                            stringBuilder.AddText($"[TidyChat] ");
                            stringBuilder.AddUiForegroundOff();
                        }
                        string commendations = $"commendation{(numberOfCommendations == 1 ? "" : "s")}";
                        string dutyName = $"{(Configuration.IncludeDutyNameInComms && lastDuty.Length > 0 ? " from completing " + lastDuty + "." : ".")}";
                        stringBuilder.AddText($"You received {numberOfCommendations} {commendations}{dutyName}");
                        ChatGui.Print(stringBuilder.BuiltString);
                        t.Enabled = false;
                        t.Dispose();
                        numberOfCommendations = 0;
                        lastDuty = "";
                    };
                    t.Enabled = true;
                }
            }

            if (Configuration.HideDebugTeleport && chatType is ChatType.Debug && ChatStrings.DebugTeleport.All(normalizedText.Contains))
            {
                isHandled = true;
            }

            if ((Configuration.FilterEmoteSpam || Configuration.HideUsedEmotes) && chatType is ChatType.StandardEmote)
            {
                isHandled = FilterEmoteMessages.IsFiltered(normalizedText, chatType, Configuration);
            }

            if (chatType is ChatType.CustomEmote)
            {
                isHandled = FilterEmoteMessages.IsFiltered(normalizedText, chatType, Configuration);
            }

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

            if (Configuration.FilterCraftingSpam && chatType is ChatType.Crafting)
            {
                isHandled = FilterCraftMessages.IsFiltered(normalizedText, Configuration);
            }

            if (Configuration.FilterGatheringSpam && chatType is ChatType.GatheringSystem or ChatType.Gathering)
            {
                isHandled = FilterGatherMessages.IsFiltered(normalizedText, Configuration);
            }

            if (Configuration.HideUserLogouts && chatType is ChatType.FreeCompanyLoginLogout)
            {
                isHandled = FilterFreeCompanyMessages.IsFiltered(normalizedText, Configuration);
            }
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
