using System.Numerics;

namespace TidyChat.Settings.Tabs;

/// <summary>
///     Shared ImGui layout for settings masters, nested children, and independent siblings.
/// </summary>
internal static class SettingsTabLayout
{
    public static void DrawTabNote(string note)
    {
        ImGui.TextWrapped(note);
        ImGui.Spacing();
    }

    public static void DrawMasterChannelDisabledWarning(string warning)
    {
        ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(1f, 0.78f, 0.25f, 1f));
        ImGui.TextWrapped(warning);
        ImGui.PopStyleColor();
        ImGui.Spacing();
    }

    /// <summary>
    ///     Renders tab sections. A single section is shown flat without a collapsing header.
    /// </summary>
    public static void DrawSections(bool defaultOpenFirstSection, params (string Header, Action Draw)[] sections)
    {
        if (sections.Length == 1)
        {
            sections[0].Draw();
            return;
        }

        for (var i = 0; i < sections.Length; i++)
        {
            var flags = i == 0 && defaultOpenFirstSection
                ? ImGuiTreeNodeFlags.DefaultOpen
                : ImGuiTreeNodeFlags.None;
            if (ImGui.CollapsingHeader(sections[i].Header, flags))
            {
                sections[i].Draw();
            }
        }
    }

    public static void DrawNestedOptions(bool showNested, Action drawOptions)
    {
        if (!showNested)
        {
            return;
        }

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
