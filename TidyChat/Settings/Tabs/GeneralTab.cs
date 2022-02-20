using Dalamud.Interface.Components;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class GeneralTab
    {
        public static void Draw(Configuration configuration)
        {
            var enabled = configuration.Enabled;
            if (ImGui.Checkbox("Enable filters", ref enabled))
            {
                configuration.Enabled = enabled;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This should be left on unless testing or debugging.");

            var noCoffee = configuration.NoCoffee;
            if (ImGui.Checkbox("Hide ko-fi button", ref noCoffee))
            {
                configuration.NoCoffee = noCoffee;
                configuration.Save();
            }

            var includeChatTag = configuration.IncludeChatTag;
            if (ImGui.Checkbox("Add [TidyChat] tag to modified messages", ref includeChatTag))
            {
                configuration.IncludeChatTag = includeChatTag;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("Prepends messages sent or modified by Tidy Chat with [TidyChat]");

            ImGui.Separator();
            ImGui.Spacing();

            if (ImGui.CollapsingHeader("Messaging Improvements"))
            {

                var betterInstanceMessage = configuration.BetterInstanceMessage;
                if (ImGui.Checkbox("Improved /instance messaging", ref betterInstanceMessage))
                {
                    configuration.BetterInstanceMessage = betterInstanceMessage;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Changes the instance text to: You are now in instance: #");

                var betterCommendationMessage = configuration.BetterCommendationMessage;
                if (ImGui.Checkbox("Condensed Commendations", ref betterCommendationMessage))
                {
                    configuration.BetterCommendationMessage = betterCommendationMessage;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Disables System message for received commendations and instead logs a single message to your Dalamud General Chat Channel (check your Dalamud General Settings for which channel that is - it is Debug by default)");

                var includeDutyNameInComms = configuration.IncludeDutyNameInComms;
                if (ImGui.Checkbox("Include completed duty in condensed commendations", ref includeDutyNameInComms))
                {
                    configuration.IncludeDutyNameInComms = includeDutyNameInComms;
                    if (!configuration.BetterCommendationMessage && configuration.IncludeDutyNameInComms)
                    {
                        configuration.BetterCommendationMessage = true;
                    }
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Requires Condensed Commendations to be enabled");

                var betterSayReminder = configuration.BetterSayReminder;
                if (ImGui.Checkbox("Improved /Say message for quests", ref betterSayReminder))
                {
                    configuration.BetterSayReminder = betterSayReminder;
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

            }

            ImGui.Spacing();
            if (ImGui.CollapsingHeader("Uncategorized Filters"))
            {

                var showSealedOff = configuration.ShowSealedOff;
                if (ImGui.Checkbox("Show \"<arena> will be sealed off\" type messages", ref showSealedOff))
                {
                    configuration.ShowSealedOff = showSealedOff;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("In some instances Cactbot's Raidfinder depends on detecting these messages in chat. It is recommend to enable this setting if you depend on Raidboss callouts.");

                var hideDebugTeleport = configuration.HideDebugTeleport;
                if (ImGui.Checkbox("Hide \"Teleporting to <Location>...\" Dalamud Debug messages ", ref hideDebugTeleport))
                {
                    configuration.HideDebugTeleport = hideDebugTeleport;
                    configuration.Save();
                }

                var hideUserLogOuts = configuration.HideUserLogouts;
                if (ImGui.Checkbox("Hide \"User has logged out\" Free Company messages ", ref hideUserLogOuts))
                {
                    configuration.HideUserLogouts = hideUserLogOuts;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Hides the message that appears when a Free Company member logs out");
            }
            ImGui.EndTabItem();
        }
    }
}
