using System.Numerics;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat.Settings.UI;

internal static class TitleBarVersion
{
    private static Vector2? cachedPosition;
    private static string cachedText = string.Empty;

    public static void CachePosition(int customTitleBarButtonCount, bool showAdditionalOptionsButton)
    {
        var style = ImGui.GetStyle();
        var fontSize = ImGui.GetFontSize();
        var buttonSize = fontSize;
        cachedText = $"v{TidyStrings.Version}";
        var textSize = ImGui.CalcTextSize(cachedText);

        var padRight = style.FramePadding.X;
        padRight += buttonSize + style.ItemInnerSpacing.X;

        if (style.WindowMenuButtonPosition == ImGuiDir.Right)
        {
            padRight += buttonSize + style.ItemInnerSpacing.X;
        }

        var extraButtons = customTitleBarButtonCount + (showAdditionalOptionsButton ? 1 : 0);
        padRight += extraButtons * (buttonSize + style.ItemInnerSpacing.X);
        padRight += style.ItemInnerSpacing.X;

        var windowPos = ImGui.GetWindowPos();
        var windowSize = ImGui.GetWindowSize();
        cachedPosition = new Vector2(
            windowPos.X + windowSize.X - padRight - textSize.X,
            windowPos.Y + style.FramePadding.Y);
    }

    public static void DrawCached()
    {
        if (cachedPosition is not { } position || string.IsNullOrEmpty(cachedText))
        {
            return;
        }

        var drawList = ImGui.GetForegroundDrawList();
        drawList.AddText(
            ImGui.GetFont(),
            ImGui.GetFontSize(),
            position,
            ImGui.ColorConvertFloat4ToU32(new Vector4(0.75f, 0.75f, 0.75f, 1f)),
            cachedText);
    }

    public static void ClearCache() => cachedPosition = null;
}
