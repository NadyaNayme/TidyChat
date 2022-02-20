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
                HelpMessage = TidyStrings.SettingsHelper
            });

            this.CommandManager.AddHandler(ShorthandCommand, new CommandInfo(OnCommand)
            {
                HelpMessage = TidyStrings.ShorthandHelper
            });

            this.PluginInterface.UiBuilder.Draw += DrawUI;
            this.PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;
        }

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

            // Lifted below line from Anna's chat2
            var chatType = FromDalamud(type);
            string normalizedText = NormalizeInput.ToLowercase(message);

            if (Configuration.PlayerName != "" && Configuration.PlayerName != null)
            {
                normalizedText = NormalizeInput.ReplaceName(normalizedText, Configuration);
            }

            if (Configuration.BetterInstanceMessage && chatType is ChatType.System && ChatStrings.InstancedArea.All(normalizedText.Contains))
            {
                message = Better.Instances(message, Configuration);
            }

            if (Configuration.BetterSayReminder && !Configuration.HideQuestReminder && chatType is ChatType.System && ChatStrings.SayQuestReminder.All(normalizedText.Contains))
            {
                message = Better.SayReminder(message, Configuration);
            }

            if (Configuration.IncludeDutyNameInComms)
            {
                TidyStrings.LastDuty = GetDuty.FindIn(message, normalizedText);
            }

            if (Configuration.BetterCommendationMessage && ChatStrings.PlayerCommendation.All(normalizedText.Contains))
            {
                isHandled = true;
                Better.Commendations(Configuration, ChatGui);

            }

            if (Configuration.HideDebugTeleport && chatType is ChatType.Debug && ChatStrings.DebugTeleport.All(normalizedText.Contains))
            {
                isHandled = true;
            }

            if (Configuration.FilterEmoteSpam && chatType is ChatType.StandardEmote)
            {
                isHandled = FilterEmoteMessages.IsFiltered(normalizedText, chatType, Configuration);
            }

            if (Configuration.HideOtherCustomEmotes && sender.TextValue != Configuration.PlayerName && chatType is ChatType.CustomEmote)
            {
                isHandled = FilterEmoteMessages.IsFiltered(normalizedText, chatType, Configuration);
            }

            if (Configuration.HideUsedEmotes && (chatType is ChatType.StandardEmote || chatType is ChatType.CustomEmote) && sender.TextValue == Configuration.PlayerName) {
               isHandled = true;
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
