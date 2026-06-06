using Dalamud.Interface;
using Dalamud.Interface.Components;
namespace TidyChat.Settings.Search;

internal static class SettingsSearch
{
    private static string s_query = string.Empty;
    private static bool s_clearNextFrame;

    public static string Query => s_query;

    public static bool IsActive => !string.IsNullOrWhiteSpace(s_query);

    public static void DrawSearchBar()
    {
        if (s_clearNextFrame)
        {
            s_query = string.Empty;
            s_clearNextFrame = false;
        }

        var showClear = s_query.Length > 0;

        ImGui.SetNextItemWidth(-1f);
        ImGui.InputTextWithHint("##settingsSearch", Languages.ConfigWindow_SearchPlaceholder, ref s_query, 256);

        if (!showClear)
        {
            return;
        }

        ImGui.SetItemAllowOverlap();

        var buttonSize = ImGui.GetFrameHeight();
        ImGui.SameLine(0f, 0f);
        ImGui.SetCursorPosX(ImGui.GetCursorPosX() - buttonSize);
        ImGui.PushID("settingsSearchClear");
        if (ImGuiComponents.IconButton(FontAwesomeIcon.Times, new(buttonSize, buttonSize)))
        {
            s_clearNextFrame = true;
        }

        if (ImGui.IsItemHovered())
        {
            ImGui.SetTooltip(Languages.ConfigWindow_SearchClear);
        }

        ImGui.PopID();
    }
}
