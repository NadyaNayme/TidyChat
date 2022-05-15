using Dalamud.Interface.Components;
using ImGuiNET;
using TidyChat.Localization.Resources;

namespace TidyChat.Settings.Tabs;

internal static class ChatHistoryTab
{
    public static void Draw(Configuration configuration)
    {
        var chatHistoryFilter = configuration.ChatHistoryFilter;
        if (ImGui.Checkbox(localization.ChatHistoryTab_EnableChatHistoryFilter, ref chatHistoryFilter))
        {
            configuration.ChatHistoryFilter = chatHistoryFilter;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(string.Format(localization.ChatHistoryTab_EnableChatHistoryFilterHelpMarker,
            configuration.ChatHistoryLength.ToString()));

        var disableSelfChatHistory = configuration.DisableSelfChatHistory;
        if (ImGui.Checkbox(localization.ChatHistoryTab_IgnoreMessagesSentByPlayer, ref disableSelfChatHistory))
        {
            configuration.DisableSelfChatHistory = disableSelfChatHistory;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.ChatHistoryTab_IgnoreMessagesSentByPlayerHelpMarker);

        var chatHistoryLength = configuration.ChatHistoryLength;
        ImGui.SetNextItemWidth(120f);
        if (ImGui.InputInt(localization.ChatHistoryTab_LengthOfChatHistory, ref chatHistoryLength))
        {
            configuration.ChatHistoryLength = chatHistoryLength;
            configuration.Save();
        }

        ImGui.TextUnformatted(localization.ChatHistoryTab_LengthOfChatHistoryWarningMessage);

        var chatHistoryTimer = configuration.ChatHistoryTimer;
        ImGui.SetNextItemWidth(120f);
        if (ImGui.InputInt(localization.ChatHistoryTab_ChatHistoryTimer, ref chatHistoryTimer))
        {
            configuration.ChatHistoryTimer = chatHistoryTimer;
            configuration.Save();
        }

        ImGuiComponents.HelpMarker(localization.ChatHistoryTab_ChatHistoryTimerHelpMarker);

        ImGui.NewLine();

        #region Channels

        var chatHistoryChannels = configuration.ChatHistoryChannels;
        ImGui.TextUnformatted(localization.ChatHistoryTab_SelectChannels);
        if (ImGui.CheckboxFlags(localization.ChatHistoryTab_EmotesChannel, ref chatHistoryChannels, 1 << 1))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.Save();
        }

        ImGui.SameLine(90f);
        if (ImGui.CheckboxFlags(localization.ChatHistoryTab_LootChannel, ref chatHistoryChannels, 1 << 5))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.Save();
        }

        if (ImGui.CheckboxFlags(localization.ChatHistoryTab_CraftingChannel, ref chatHistoryChannels, 1 << 8))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.Save();
        }

        ImGui.SameLine(90f);
        if (ImGui.CheckboxFlags(localization.ChatHistoryTab_GatheringChannel, ref chatHistoryChannels, 1 << 9))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.Save();
        }

        if (ImGui.CheckboxFlags(localization.ChatHistoryTab_TalkingChannel, ref chatHistoryChannels, 1 << 2))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.Save();
        }

        ImGui.SameLine(90f);
        if (ImGui.CheckboxFlags(localization.ChatHistoryTab_LoginLogoutChannel, ref chatHistoryChannels, 1 << 7))
            configuration.ChatHistoryChannels = chatHistoryChannels;
        {
            configuration.Save();
        }
        if (ImGui.CheckboxFlags(localization.ChatHistoryTab_ProgressChannel, ref chatHistoryChannels, 1 << 4))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.Save();
        }

        ImGui.SameLine(90f);
        if (ImGui.CheckboxFlags(localization.ChatHistoryTab_SystemChannel, ref chatHistoryChannels, 1 << 3))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.Save();
        }

        #endregion Channels

        ImGui.EndTabItem();
    }
}