namespace TidyChat.Settings;

internal static class ChatHighlightPresets
{
    internal static readonly uint DefaultRgba = ColourUtil.ComponentsToRgba(100, 160, 255);

    private static readonly ushort[] LegacyColorKeys = [1, 2, 8, 9, 14, 25, 37, 45, 43, 52];

    private static readonly uint[] LegacyPresetRgba =
    [
        ColourUtil.ComponentsToRgba(240, 240, 240),
        ColourUtil.ComponentsToRgba(140, 140, 140),
        ColourUtil.ComponentsToRgba(255, 120, 200),
        ColourUtil.ComponentsToRgba(100, 230, 120),
        ColourUtil.ComponentsToRgba(255, 230, 80),
        ColourUtil.ComponentsToRgba(255, 150, 60),
        ColourUtil.ComponentsToRgba(100, 160, 255),
        ColourUtil.ComponentsToRgba(130, 210, 255),
        ColourUtil.ComponentsToRgba(200, 130, 255),
        ColourUtil.ComponentsToRgba(255, 90, 90)
    ];

    internal static uint FromLegacyUiForeground(ushort uiForeground)
    {
        var legacyIndex = Array.IndexOf(LegacyColorKeys, uiForeground);
        if (legacyIndex >= 0 && legacyIndex < LegacyPresetRgba.Length)
        {
            return LegacyPresetRgba[legacyIndex];
        }

        return DefaultRgba;
    }
}
