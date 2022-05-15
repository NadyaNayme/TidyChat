using Dalamud.Interface.Components;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class AdvancedTab
    {
        public static void Draw(Configuration configuration)
        {
            ImGui.Spacing();
            ImGui.Spacing();
            var enableDebugMode = configuration.EnableDebugMode;
            if (ImGui.Checkbox(localization.AdvancedTab_EnableDebugMode, ref enableDebugMode))
            {
                configuration.EnableDebugMode = enableDebugMode;
                configuration.Save();
            }
            ImGui.Separator();
            ImGui.Spacing();
            if (ImGui.BeginTabBar("##tidychatAdvancedConfigTabs"))
            {
                if (ImGui.BeginTabItem(localization.AdvancedTab_SystemTabHeader))
                {
                    SystemTab.Draw(configuration);
                }
                if (ImGui.BeginTabItem(localization.AdvancedTab_LootObtainTabHeader))
                {
                    ObtainTab.Draw(configuration);
                }
                if (ImGui.BeginTabItem(localization.AdvancedTab_ProgressTabHeader))
                {
                    ProgressTab.Draw(configuration);
                }
                if (ImGui.BeginTabItem(localization.AdvancedTab_CraftingGatheringTabHeader))
                {
                    CraftingGatheringTab.Draw(configuration);
                }
                if (ImGui.BeginTabItem(localization.AdvancedTab_ChatHistoryTabHeader))
                {
                    ChatHistoryTab.Draw(configuration);
                }
                if (ImGui.BeginTabItem(localization.AdvancedTab_WhitelistTabHeader))
                {
                    WhitelistTab.Draw(configuration);
                }
            }
            ImGui.EndTabBar();

            ImGui.EndTabItem();
        }
    }
}
