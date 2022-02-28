using Dalamud.Interface.Components;
using ImGuiNET;
using Flags = TidyChat.Utility.ChatFlags;

namespace TidyChat.Settings.Tabs
{
    internal static class GeneralTab
    {
        public static void Draw(Configuration configuration)
        {
            var enableDebugMode = configuration.EnableDebugMode;
            if (ImGui.Checkbox("Enable debug mode", ref enableDebugMode))
            {
                configuration.EnableDebugMode = enableDebugMode;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("Display all messages.\nMessages that would be filtered outside of debug mode are prepended with [TidyChat] and [Debug] tags");

            var noCoffee = configuration.NoCoffee;
            if (ImGui.Checkbox("Hide ko-fi button", ref noCoffee))
            {
                configuration.NoCoffee = noCoffee;
                configuration.Save();
            }

            ImGui.Separator();
            ImGui.Spacing();

            if (ImGui.CollapsingHeader("Chat History"))
            {
                var chatHistoryFilter = configuration.ChatHistoryFilter;
                if (ImGui.Checkbox("Enable Chat History Filter", ref chatHistoryFilter))
                {
                    configuration.ChatHistoryFilter = chatHistoryFilter;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker($"If a message was sent within the last {configuration.ChatHistoryLength} messages it will be filtered");


                ImGui.TextUnformatted("Number of messages to keep in chat history:");
                var chatHistoryLength = configuration.ChatHistoryLength;
                ImGui.SetNextItemWidth(120f);
                if (ImGui.InputInt("", ref chatHistoryLength))
                {
                    configuration.ChatHistoryLength = chatHistoryLength;
                    configuration.Save();
                }
                ImGui.TextUnformatted("WARNING: Having this number set too high may impact game performance.\nIt's recommended to keep it at 50 or lower.");

                ImGui.NewLine();
                #region Channels
                int chatHistoryChannels = configuration.ChatHistoryChannels;
                ImGui.TextUnformatted($"Select channels for Chat History to filter:");
                if (ImGui.CheckboxFlags($"Emotes", ref chatHistoryChannels, 1 << 1))
                {
                    configuration.ChatHistoryChannels = chatHistoryChannels;
                    configuration.Save();
                }
                ImGui.SameLine(90f);
                if (ImGui.CheckboxFlags($"Loot", ref chatHistoryChannels, 1 << 5))
                {
                    configuration.ChatHistoryChannels = chatHistoryChannels;
                    configuration.Save();
                }
                if (ImGui.CheckboxFlags($"Crafting", ref chatHistoryChannels, 1 << 8))
                {
                    configuration.ChatHistoryChannels = chatHistoryChannels;
                    configuration.Save();
                }
                ImGui.SameLine(90f);
                if (ImGui.CheckboxFlags($"Gathering", ref chatHistoryChannels, 1 << 9))
                {
                    configuration.ChatHistoryChannels = chatHistoryChannels;
                    configuration.Save();
                }
                if (ImGui.CheckboxFlags($"Talking", ref chatHistoryChannels, 1 << 2))
                {
                    configuration.ChatHistoryChannels = chatHistoryChannels;
                    configuration.Save();
                }
                ImGui.SameLine(90f);
                if (ImGui.CheckboxFlags($"Login/Logout", ref chatHistoryChannels, 1 << 7))
                    configuration.ChatHistoryChannels = chatHistoryChannels;
                {
                    configuration.Save();
                }
                if (ImGui.CheckboxFlags($"Progress", ref chatHistoryChannels, 1 << 4))
                {
                    configuration.ChatHistoryChannels = chatHistoryChannels;
                    configuration.Save();
                }
                ImGui.SameLine(90f);
                if (ImGui.CheckboxFlags($"System", ref chatHistoryChannels, 1 << 3))
                {
                    configuration.ChatHistoryChannels = chatHistoryChannels;
                    configuration.Save();
                }
                #endregion Channels
            }

            ImGui.Spacing();
            if (ImGui.CollapsingHeader("Messaging Improvements"))
            {
                var includeChatTag = configuration.IncludeChatTag;
                if (ImGui.Checkbox("Add [TidyChat] tag to modified messages", ref includeChatTag))
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
                    configuration.Save();
                }

                var instanceMessageTimer = configuration.InstanceMessageTimer;
                ImGui.SetNextItemWidth(200f);
                if (ImGui.DragInt("Delay to check for /instance message (in milliseconds)", ref instanceMessageTimer, 50, 100, 1000))
                {
                    configuration.InstanceMessageTimer = instanceMessageTimer;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Slower load times should use a larger number - faster load times should use a smaller number. Recommended value is 300.");

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

                var hideUserLogins = configuration.HideUserLogins;
                if (ImGui.Checkbox("Hide \"User has logged in\" Free Company messages ", ref hideUserLogins))
                {
                    configuration.HideUserLogins = hideUserLogins;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Hides the message that appears when a Free Company member logs in");

                var hideUserLogouts = configuration.HideUserLogouts;
                if (ImGui.Checkbox("Hide \"User has logged out\" Free Company messages ", ref hideUserLogouts))
                {
                    configuration.HideUserLogouts = hideUserLogouts;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("Hides the message that appears when a Free Company member logs out");
            }
            ImGui.EndTabItem();
        }
    }
}
