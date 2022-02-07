using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Game.Gui;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using System.Linq;
using ChatTwo.Code;

namespace TidyChat

{
    public sealed class TidyChat : IDalamudPlugin
    {
        public string Name => "Tidy Chat";

        private const string commandName = "/tidychat";

        private DalamudPluginInterface PluginInterface { get; init; }
        private ChatGui ChatGui { get; init; }
        private CommandManager CommandManager { get; init; }
        private Configuration Configuration { get; init; }
        private PluginUI PluginUi { get; init; }

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
            [RequiredVersion("1.0")] CommandManager commandManager)
        {
            this.PluginInterface = pluginInterface;
            this.CommandManager = commandManager;
            this.ChatGui = chatGui;

            this.Configuration = this.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            this.Configuration.Initialize(this.PluginInterface);

            ChatGui.ChatMessage += OnChat;

            this.PluginUi = new PluginUI(this.Configuration);

            this.CommandManager.AddHandler(commandName, new CommandInfo(OnCommand)
            {
                HelpMessage = "Open settings"
            });

            this.PluginInterface.UiBuilder.Draw += DrawUI;
            this.PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;
        }

        public int numberOfCommendations = 0;
        public int runOnlyOnce = 0;
        public string lastDuty = "";

        public void IncrementTimesCommended()
        {
            numberOfCommendations += 1;

            // Why the fuck is it so hard to debounce a function without Threading or Async? Instead I have to do this hacky solution.
            runOnlyOnce += 1;
            if (runOnlyOnce == 1)
            {
                DelayTimer_Commendations();
            }
        }

        private System.Timers.Timer _delayTimer;

        private void DelayTimer_Commendations()
        {
            _delayTimer = new System.Timers.Timer
            {
                Interval = 5000,
                AutoReset = false
            };
            _delayTimer.Elapsed += TimerElapsed_Commendations;
            _delayTimer.Start();
        }

        private void TimerElapsed_Commendations(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (numberOfCommendations > 0)
            {
                ChatGui.Print($"You received {numberOfCommendations} commendation{(numberOfCommendations != 1 ? "s" : "")}{(Configuration.IncludeDutyNameInComms ? " from completing {lastDuty}" : "")}.");
            }
            numberOfCommendations = 0;
            runOnlyOnce = 0;
        }

        public void Dispose()
        {
            this.PluginUi.Dispose();
            this.CommandManager.RemoveHandler(commandName);
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

            if (chatType is ChatType.StandardEmote && Configuration.FilterEmoteSpam)
            {
                isHandled |= FilterEmoteMessages.IsFiltered(message.TextValue);
            }

            if (chatType is ChatType.System)
            {
                isHandled = FilterSystemMessages.IsFiltered(message.TextValue, Configuration);
            }
            
            if (Configuration.BetterInstanceMessage && ChatStrings.InstancedArea.All(normalizedText.Contains))
            {
                // The last character in the first sentence is the instanceNumber so
                // we capture it by finding the period that ends the first sentence and going back one character
                int index = message.TextValue.IndexOf('.');
                string instanceNumber = message.TextValue.Substring(index - 1, 1);
                message = "You are now in instance: " + instanceNumber;
            }

            if (Configuration.BetterCommendationMessage && ChatStrings.PlayerCommendation.All(normalizedText.Contains))
            {
                
                isHandled = true;

                IncrementTimesCommended();
                // Give it a few seconds before sending the /debug message with the total number of commendations in case there is any lag between commendation messages
                // There shouldn't be any lag since I think they all get sent at once - but having this small wait guarantees that there won't be any problems
                DelayTimer_Commendations();
            }

            if (Configuration.BetterCommendationMessage && ChatStrings.DutyEnded.All(normalizedText.Contains))
            {
                //      match here then go back 4 characters to capture everything before " has"
                //           |
                //           v
                // <duty> has ended.
                lastDuty = message.TextValue.Substring(0, message.TextValue.LastIndexOf(" ") - 4);
            }

        }

        private void OnCommand(string command, string args)
        {
            this.PluginUi.Visible = true;
        }

        private void DrawUI()
        {
            this.PluginUi.Draw();
        }

        private void DrawConfigUI()
        {
            this.PluginUi.SettingsVisible = true;
        }
    }
}
