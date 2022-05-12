using Dalamud.Interface.Components;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class GeneralTab
    {
        public static void Draw(Configuration configuration)
        {

            ImGui.TextUnformatted($"Tidy Chat has blocked {configuration.TtlMessagesBlocked:n0} messages so far.");
            ImGuiComponents.HelpMarker("Count is only updated every 100 blocked messages, when changing zones, or when logging off.");
            ImGui.Separator();

            var filterSystemMessages = configuration.FilterSystemMessages;
            if (ImGui.Checkbox("Filter System spam", ref filterSystemMessages))
            {
                configuration.FilterSystemMessages = filterSystemMessages;
                configuration.Save();
            }

            var filterProgressSpam = configuration.FilterProgressSpam;
            if (ImGui.Checkbox("Filter Progress spam", ref filterProgressSpam))
            {
                configuration.FilterProgressSpam = filterProgressSpam;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("These filters include messages like earned achievements or experience points");

            var filterLootSpam = configuration.FilterLootSpam;
            if (ImGui.Checkbox("Filter Loot roll spam", ref filterLootSpam))
            {
                configuration.FilterLootSpam = filterLootSpam;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This filter includes messages like rolling greed or player obtained a gear piece");

            var filterObtainedSpam = configuration.FilterObtainedSpam;
            if (ImGui.Checkbox("Filter Obtained item spam", ref filterObtainedSpam))
            {
                configuration.FilterObtainedSpam = filterObtainedSpam;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This filter includes items obtained as monster drops, quest rewards, and roulette rewards");

            var filterCraftingSpam = configuration.FilterCraftingSpam;
            if (ImGui.Checkbox("Filter Crafting spam.", ref filterCraftingSpam))
            {
                configuration.FilterCraftingSpam = filterCraftingSpam;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This filter includes all crafting messages except \"You synthesize a/an <item>\"\nThis allows you to use ChatAlerts to create an alert for \"You synthesize\" instead of using macro-finished alerts");

            var filterGatheringSpam = configuration.FilterGatheringSpam;
            if (ImGui.Checkbox("Filter Gathering spam.", ref filterGatheringSpam))
            {
                configuration.FilterGatheringSpam = filterGatheringSpam;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This filter includes \"you begin/finish\" gathering messages, as well as location affects");

            if (ImGui.CollapsingHeader("Emote Filters"))
            {
                EmotesTab.Draw(configuration);
            }

            if (ImGui.CollapsingHeader("Improved Messages"))
            {
                var includeChatTag = configuration.IncludeChatTag;
                if (ImGui.Checkbox("Add [TidyChat] tag to any modified messages", ref includeChatTag))
                {
                    configuration.IncludeChatTag = includeChatTag;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Prepends messages sent or modified by Tidy Chat with [TidyChat]");

                var betterInstanceMessage = configuration.BetterInstanceMessage;
                if (ImGui.Checkbox("Improved /instance messaging", ref betterInstanceMessage))
                {
                    configuration.BetterInstanceMessage = betterInstanceMessage;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Changes the instance text to: You are now in instance: #");

                var useDTRBar = configuration.UseDTRBar;
                if (ImGui.Checkbox("Display current instance in DTR Bar", ref useDTRBar))
                {
                    configuration.UseDTRBar = useDTRBar;
                    configuration.DTRIsEnabled = useDTRBar;
                    configuration.InstanceInDtrBar = useDTRBar;
                    configuration.Save();
                }

                var betterCommendationMessage = configuration.BetterCommendationMessage;
                if (ImGui.Checkbox("Improved Player Commendations", ref betterCommendationMessage))
                {
                    configuration.BetterCommendationMessage = betterCommendationMessage;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Disables System message for received commendations and instead logs a single message to your Dalamud General Chat Channel (check your Dalamud General Settings for which channel that is - it is Debug by default)");

                var includeDutyNameInComms = configuration.IncludeDutyNameInComms;
                if (ImGui.Checkbox("Include completed duty with commendations message", ref includeDutyNameInComms))
                {
                    configuration.IncludeDutyNameInComms = includeDutyNameInComms;
                    if (!configuration.BetterCommendationMessage && configuration.IncludeDutyNameInComms)
                    {
                        configuration.BetterCommendationMessage = true;
                    }
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Requires Improved Player Commendations to be enabled");

                var betterSayReminder = configuration.BetterSayReminder;
                if (ImGui.Checkbox("Improved /Say message for quests", ref betterSayReminder))
                {
                    configuration.BetterSayReminder = betterSayReminder;
                    if (!configuration.BetterSayReminder && configuration.CopyBetterSayReminder)
                    {
                        configuration.CopyBetterSayReminder = false;
                    }
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("When a quest requires you to /Say something in chat, change the message into one that can be copy and pasted easily");

                var copyBetterSayReminder = configuration.CopyBetterSayReminder;
                if (ImGui.Checkbox("Automatically copy improved /say message to clipboard", ref copyBetterSayReminder))
                {
                    configuration.CopyBetterSayReminder = copyBetterSayReminder;
                    if (!configuration.BetterSayReminder && configuration.CopyBetterSayReminder)
                    {
                        configuration.BetterSayReminder = true;
                    }
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Requires Improved /Say message for quests to be enabled");

                var betterNoviceNetworkMessage = configuration.BetterNoviceNetworkMessage;
                if (ImGui.Checkbox("Improved Novice Network join and leave messages", ref betterNoviceNetworkMessage))
                {
                    configuration.BetterNoviceNetworkMessage = betterNoviceNetworkMessage;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Reduces the amount of Novice Network text when the Novice Network is joined and changes the leave message to be consistently worded.");

                ImGui.Separator();
            }
            var enableTippyTips = configuration.EnableTippyTips;
            if (ImGui.Checkbox("Enable Tippy IPC", ref enableTippyTips))
            {
                configuration.EnableTippyTips = enableTippyTips;
                configuration.Save();
            }
            var noCoffee = configuration.NoCoffee;
            if (ImGui.Checkbox("Hide ko-fi button", ref noCoffee))
            {
                configuration.NoCoffee = noCoffee;
                configuration.Save();
            }

            ImGui.EndTabItem();
        }
    }
}
