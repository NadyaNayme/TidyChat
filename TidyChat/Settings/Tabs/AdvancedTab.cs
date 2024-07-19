using ImGuiNET;
using TidyChat.Resources.Languages;

namespace TidyChat.Settings.Tabs;

internal static class AdvancedTab
{
    public static void Draw(Configuration configuration)
    {
        ImGui.Spacing();
        ImGui.Spacing();
        var enableDebugMode = configuration.EnableDebugMode;
        if (ImGui.Checkbox(Languages.AdvancedTab_EnableDebugMode, ref enableDebugMode))
        {
            configuration.EnableDebugMode = enableDebugMode;
            configuration.Save();
        }

        ImGui.Separator();
        ImGui.Spacing();
        if (ImGui.BeginTabBar("##tidychatAdvancedConfigTabs"))
        {
            if (ImGui.BeginTabItem(Languages.AdvancedTab_SystemTabHeader)) SystemTab.Draw(configuration);
            if (ImGui.BeginTabItem(Languages.AdvancedTab_LootObtainTabHeader)) ObtainTab.Draw(configuration);
            if (ImGui.BeginTabItem(Languages.AdvancedTab_ProgressTabHeader)) ProgressTab.Draw(configuration);
            if (ImGui.BeginTabItem(Languages.AdvancedTab_CraftingGatheringTabHeader))
                CraftingGatheringTab.Draw(configuration);
            if (ImGui.BeginTabItem(Languages.AdvancedTab_ChatHistoryTabHeader)) ChatHistoryTab.Draw(configuration);
            if (ImGui.BeginTabItem(Languages.AdvancedTab_CustomFiltersHeader)) WhitelistTab.Draw(configuration);
        }

        ImGui.EndTabBar();

        ImGui.EndTabItem();
    }
}