using System.Numerics;
using System.Reflection;
namespace TidyChat.Settings.UI;

internal static class TitleBarVersion
{
    public static void DrawFromContext(int customTitleBarButtonCount, bool showAdditionalOptionsButton)
    {
        var windowPos = ImGui.GetWindowPos();
        var windowSize = ImGui.GetWindowSize();
        if (windowSize.X <= 0f || windowSize.Y <= 0f)
        {
            return;
        }

        DrawAt(windowPos, windowSize, customTitleBarButtonCount, showAdditionalOptionsButton);
    }

    private static void DrawAt(
        Vector2 windowPos,
        Vector2 windowSize,
        int customTitleBarButtonCount,
        bool showAdditionalOptionsButton)
    {
        var text = GetVersionLabel();
        if (string.IsNullOrEmpty(text))
        {
            return;
        }

        var textSize = ImGui.CalcTextSize(text);
        var style = ImGui.GetStyle();
        var buttonSize = ImGui.GetFontSize();
        var padRight = style.FramePadding.X + buttonSize + style.ItemInnerSpacing.X;

        if (style.WindowMenuButtonPosition == ImGuiDir.Right)
        {
            padRight += buttonSize + style.ItemInnerSpacing.X;
        }

        var extraButtons = customTitleBarButtonCount + (showAdditionalOptionsButton ? 1 : 0);
        padRight += extraButtons * (buttonSize + style.ItemInnerSpacing.X);
        padRight += style.ItemInnerSpacing.X;

        var position = new Vector2(
            windowPos.X + windowSize.X - padRight - textSize.X,
            windowPos.Y + style.FramePadding.Y);

        // Window draw list keeps TidyChat's z-order, so the version is occluded by windows drawn
        // in front of it instead of bleeding through. Expand the clip to the full window so the
        // title-bar coordinates are not culled by the content-area clip active during Draw().
        var drawList = ImGui.GetWindowDrawList();
        drawList.PushClipRect(windowPos, windowPos + windowSize, false);
        drawList.AddText(
            ImGui.GetFont(),
            ImGui.GetFontSize(),
            position,
            ImGui.ColorConvertFloat4ToU32(new(0.75f, 0.75f, 0.75f, 1f)),
            text);
        drawList.PopClipRect();
    }

    private static string GetVersionLabel()
    {
        var manifestVersion = TidyChatPlugin.PluginInterface.Manifest.AssemblyVersion;
        if (manifestVersion != null)
        {
            return "v" + FormatVersion(manifestVersion);
        }

        var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
        return assemblyVersion != null ? "v" + FormatVersion(assemblyVersion) : "v?.?.?.?";
    }

    private static string FormatVersion(Version version) =>
        version.Revision >= 0 ? version.ToString(4) : version.ToString(3);
}
