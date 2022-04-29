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
            if (ImGui.Checkbox("Enable debug mode", ref enableDebugMode))
            {
                configuration.EnableDebugMode = enableDebugMode;
                configuration.Save();
            }
            ImGui.Separator();
            ImGui.Spacing();
            if (ImGui.BeginTabBar("##tidychatAdvancedConfigTabs"))
            {
                if (ImGui.BeginTabItem("System"))
                {
                    SystemTab.Draw(configuration);
                }
                if (ImGui.BeginTabItem("Loot/Obtain"))
                {
                    ObtainTab.Draw(configuration);
                }
                if (ImGui.BeginTabItem("Progress"))
                {
                    ProgressTab.Draw(configuration);
                }
                if (ImGui.BeginTabItem("Crafting/Gathering"))
                {
                    CraftingGatheringTab.Draw(configuration);
                }
                if (ImGui.BeginTabItem("Chat History"))
                {
                    ChatHistoryTab.Draw(configuration);
                }
                if (ImGui.BeginTabItem("Whitelist"))
                {
                    WhitelistTab.Draw(configuration);
                }
            }
            ImGui.EndTabBar();

            ImGui.EndTabItem();
        }
    }
}
