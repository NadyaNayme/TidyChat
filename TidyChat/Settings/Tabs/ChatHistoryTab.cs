using Dalamud.Interface.Components;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class ChatHistoryTab
    {
        public static void Draw(Configuration configuration)
        {
            var chatHistoryFilter = configuration.ChatHistoryFilter;
            if (ImGui.Checkbox("Enable Chat History Filter", ref chatHistoryFilter))
            {
                configuration.ChatHistoryFilter = chatHistoryFilter;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker($"If a message was sent within the last {configuration.ChatHistoryLength} messages it will be filtered");

            var disableSelfChatHistory = configuration.DisableSelfChatHistory;
            if (ImGui.Checkbox("Ignore messages sent by player", ref disableSelfChatHistory))
            {
                configuration.DisableSelfChatHistory = disableSelfChatHistory;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker($"Filters duplicate messages sent by the player, enable if you want duplicate messages you sent to be filtered from your view.");

            var chatHistoryLength = configuration.ChatHistoryLength;
            ImGui.SetNextItemWidth(120f);
            if (ImGui.InputInt("Number of messages to keep in chat history", ref chatHistoryLength))
            {
                configuration.ChatHistoryLength = chatHistoryLength;
                configuration.Save();
            }
            ImGui.TextUnformatted("WARNING: Having the history length set too high may impact game performance.\nIt's recommended to keep it at 50 or lower.");

            var chatHistoryTimer = configuration.ChatHistoryTimer;
            ImGui.SetNextItemWidth(120f);
            if (ImGui.InputInt("Number of seconds to keep messages in chat history", ref chatHistoryTimer))
            {
                configuration.ChatHistoryTimer = chatHistoryTimer;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker($"Set to 0 to disable");

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
            ImGui.EndTabItem();
        }
    }
}
