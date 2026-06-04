namespace TidyChat.Settings.Tabs;

/// <summary>
/// Shared ImGui layout for settings masters, nested children, and independent siblings.
/// </summary>
internal static class SettingsTabLayout
{
    public static void DrawNestedOptions(bool showNested, Action drawOptions)
    {
        if (!showNested)
            return;

        ImGui.Indent();
        drawOptions();
        ImGui.Unindent();
    }

    public static void DrawSectionSeparator()
    {
        ImGui.Spacing();
        ImGui.Separator();
        ImGui.Spacing();
    }

    public static void DrawIndependentOptions(Action drawOptions)
    {
        DrawSectionSeparator();
        drawOptions();
    }
}
