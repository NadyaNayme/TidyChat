namespace TidyChat.Settings.Tabs;

internal static class ToolsTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.ToolsTab_DebugDropdownHeader, ImGuiTreeNodeFlags.DefaultOpen))
        {
            var enableDebugMode = configuration.EnableDebugMode;
            if (ImGui.Checkbox(Languages.ToolsTab_EnableDebugMode, ref enableDebugMode))
            {
                configuration.EnableDebugMode = enableDebugMode;
                configuration.OnSettingChanged();
            }

            var debugIncludeChannel = configuration.DebugIncludeChannel;
            if (ImGui.Checkbox(Languages.ToolsTab_DebugIncludeChannel, ref debugIncludeChannel))
            {
                configuration.DebugIncludeChannel = debugIncludeChannel;
                configuration.OnSettingChanged();
            }
        }

        if (ImGui.CollapsingHeader(Languages.ToolsTab_ChatHistoryDropdownHeader))
        {
            ChatHistoryTab.DrawContent(configuration);
        }

        if (ImGui.CollapsingHeader(Languages.ToolsTab_CustomFiltersDropdownHeader))
        {
            WhitelistTab.DrawContent(configuration);
        }
    }
}
