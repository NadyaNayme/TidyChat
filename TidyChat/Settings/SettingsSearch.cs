using TidyChat.Localization.Resources;

namespace TidyChat.Settings;

internal static class SettingsSearch
{
    private static string s_query = string.Empty;

    public static string Query => s_query;

    public static bool IsActive => !string.IsNullOrWhiteSpace(s_query);

    public static void DrawSearchBar()
    {
        ImGui.SetNextItemWidth(-1f);
        ImGui.InputTextWithHint("##settingsSearch", Languages.ConfigWindow_SearchPlaceholder, ref s_query, 256);
    }
}
