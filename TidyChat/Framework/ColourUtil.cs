using System.Numerics;
namespace TidyChat.Utility;

internal static class ColourUtil
{
    internal static Vector3 RgbaToVector3(uint rgba)
    {
        (var r, var g, var b, _) = RgbaToRgbaComponents(rgba);
        return new(r / 255f, g / 255f, b / 255f);
    }

    internal static uint Vector3ToRgba(Vector3 col)
        => ComponentsToRgba(
            (byte)Math.Round(col.X * 255),
            (byte)Math.Round(col.Y * 255),
            (byte)Math.Round(col.Z * 255));

    internal static uint ComponentsToRgba(byte red, byte green, byte blue, byte alpha = 0xFF)
        => alpha | (uint)(red << 24) | (uint)(green << 16) | (uint)(blue << 8);

    internal static uint RgbaToArgb(uint rgba)
    {
        (var r, var g, var b, var a) = RgbaToRgbaComponents(rgba);
        return (uint)(a << 24 | r << 16 | g << 8 | b);
    }

    internal static (byte r, byte g, byte b, byte a) RgbaToRgbaComponents(uint rgba)
    {
        var r = (byte)((rgba & 0xFF000000) >> 24);
        var g = (byte)((rgba & 0xFF0000) >> 16);
        var b = (byte)((rgba & 0xFF00) >> 8);
        var a = (byte)(rgba & 0xFF);
        return (r, g, b, a);
    }
}
