using Dalamud.Interface.Components;

namespace TidyChat.Settings.Tabs;

internal static class ToolsTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.ToolsTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.ToolsTab_DebugDropdownHeader, () => DrawDebug(configuration)),
            (Languages.ToolsTab_ChatHistoryDropdownHeader, () => ChatHistoryTab.DrawContent(configuration)),
            (Languages.ToolsTab_CustomFiltersDropdownHeader, () => WhitelistTab.DrawContent(configuration)));
    }

    private static void DrawDebug(Configuration configuration)
    {
        var enableDebugMode = configuration.EnableDebugMode;
        if (ImGui.Checkbox(Languages.ToolsTab_EnableDebugMode, ref enableDebugMode))
        {
            configuration.EnableDebugMode = enableDebugMode;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.ToolsTab_EnableDebugModeHelpMarker);

        var debugIncludeChannel = configuration.DebugIncludeChannel;
        if (ImGui.Checkbox(Languages.ToolsTab_DebugIncludeChannel, ref debugIncludeChannel))
        {
            configuration.DebugIncludeChannel = debugIncludeChannel;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.ToolsTab_DebugIncludeChannelHelpMarker);
    }
}
