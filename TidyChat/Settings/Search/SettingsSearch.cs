using Dalamud.Interface;
using Dalamud.Interface.Components;

namespace TidyChat.Settings.Search;

internal static class SettingsSearch
{
    private static string s_query = string.Empty;

    public static string Query => s_query;

    public static bool IsActive => !string.IsNullOrWhiteSpace(s_query);

    public static void DrawSearchBar()
    {
        var style = ImGui.GetStyle();
        var clearButtonWidth = ImGui.GetFrameHeight();
        var showClear = s_query.Length > 0;
        var inputWidth = ImGui.GetContentRegionAvail().X;

        if (showClear)
        {
            inputWidth -= clearButtonWidth + style.ItemInnerSpacing.X;
        }

        ImGui.SetNextItemWidth(inputWidth);
        ImGui.InputTextWithHint("##settingsSearch", Languages.ConfigWindow_SearchPlaceholder, ref s_query, 256);

        if (!showClear)
        {
            return;
        }

        ImGui.SameLine(0f, style.ItemInnerSpacing.X);
        if (ImGuiComponents.IconButton(FontAwesomeIcon.Times))
        {
            s_query = string.Empty;
        }

        if (ImGui.IsItemHovered())
        {
            ImGui.SetTooltip(Languages.ConfigWindow_SearchClear);
        }
    }
}
