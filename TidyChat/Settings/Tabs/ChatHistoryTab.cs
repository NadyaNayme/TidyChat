using System;
using System.Globalization;
using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
namespace TidyChat.Settings.Tabs;

internal static class ChatHistoryTab
{
    public static void Draw(Configuration configuration)
    {
        bool chatHistoryFilter = configuration.ChatHistoryFilter;
        if (ImGui.Checkbox(Languages.ChatHistoryTab_EnableChatHistoryFilter, ref chatHistoryFilter))
        {
            configuration.ChatHistoryFilter = chatHistoryFilter;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(helpText: string.Format(CultureInfo.CurrentCulture,
            Languages.ChatHistoryTab_EnableChatHistoryFilterHelpMarker,
            configuration.ChatHistoryLength.ToString(CultureInfo.CurrentCulture)));

        bool disableSelfChatHistory = configuration.DisableSelfChatHistory;
        if (ImGui.Checkbox(Languages.ChatHistoryTab_IgnoreMessagesSentByPlayer, ref disableSelfChatHistory))
        {
            configuration.DisableSelfChatHistory = disableSelfChatHistory;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.ChatHistoryTab_IgnoreMessagesSentByPlayerHelpMarker);

        int chatHistoryLength = configuration.ChatHistoryLength;
        ImGui.SetNextItemWidth(120f);
        if (ImGui.InputInt(Languages.ChatHistoryTab_LengthOfChatHistory, ref chatHistoryLength))
        {
            configuration.ChatHistoryLength = Math.Clamp(chatHistoryLength, 1, 1000);
            configuration.OnSettingChanged();
        }

        ImGui.TextUnformatted(Languages.ChatHistoryTab_LengthOfChatHistoryWarningMessage);

        int chatHistoryTimer = configuration.ChatHistoryTimer;
        ImGui.SetNextItemWidth(120f);
        if (ImGui.InputInt(Languages.ChatHistoryTab_ChatHistoryTimer, ref chatHistoryTimer))
        {
            configuration.ChatHistoryTimer = Math.Clamp(chatHistoryTimer, 0, 3600);
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.ChatHistoryTab_ChatHistoryTimerHelpMarker);

        ImGui.NewLine();

        #region Channels

        int chatHistoryChannels = configuration.ChatHistoryChannels;
        ImGui.TextUnformatted(Languages.ChatHistoryTab_SelectChannels);
        if (ImGui.CheckboxFlags(Languages.ChatHistoryTab_EmotesChannel, ref chatHistoryChannels, 1 << 1))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.OnSettingChanged();
        }

        ImGui.SameLine(90f);
        if (ImGui.CheckboxFlags(Languages.ChatHistoryTab_LootChannel, ref chatHistoryChannels, 1 << 5))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.OnSettingChanged();
        }

        if (ImGui.CheckboxFlags(Languages.ChatHistoryTab_CraftingChannel, ref chatHistoryChannels, 1 << 8))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.OnSettingChanged();
        }

        ImGui.SameLine(90f);
        if (ImGui.CheckboxFlags(Languages.ChatHistoryTab_GatheringChannel, ref chatHistoryChannels, 1 << 9))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.OnSettingChanged();
        }

        if (ImGui.CheckboxFlags(Languages.ChatHistoryTab_TalkingChannel, ref chatHistoryChannels, 1 << 2))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.OnSettingChanged();
        }

        ImGui.SameLine(90f);
        if (ImGui.CheckboxFlags(Languages.ChatHistoryTab_LoginLogoutChannel, ref chatHistoryChannels, 1 << 7))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.OnSettingChanged();
        }
        if (ImGui.CheckboxFlags(Languages.ChatHistoryTab_ProgressChannel, ref chatHistoryChannels, 1 << 4))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.OnSettingChanged();
        }

        ImGui.SameLine(90f);
        if (ImGui.CheckboxFlags(Languages.ChatHistoryTab_SystemChannel, ref chatHistoryChannels, 1 << 3))
        {
            configuration.ChatHistoryChannels = chatHistoryChannels;
            configuration.OnSettingChanged();
        }

        #endregion Channels

        ImGui.EndTabItem();
    }
}
