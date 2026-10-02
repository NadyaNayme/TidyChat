using Dalamud.Utility;
using Lumina.Text.Parse;
using Lumina.Text.ReadOnly;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
namespace TidyChat.Settings;

public class ChatHighlight
{
    [NonSerialized] private Regex? _compiledPattern;
    [NonSerialized] private string? _compiledPatternSource;

    public int Channels = (int)ChatFlags.Channels.Loot;
    public string Pattern = string.Empty;
    public uint RgbaColor = ChatHighlightPresets.DefaultRgba;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ushort UiForegroundColor { get; set; }

    public bool IsRegex => TextMatchHelper.IsSlashDelimitedRegex(Pattern);

    public Regex? GetCompiledRegex(Action<string, Exception>? onError = null)
    {
        if (string.IsNullOrEmpty(Pattern) || !TextMatchHelper.IsSlashDelimitedRegex(Pattern))
        {
            return null;
        }

        if (string.Equals(_compiledPatternSource, Pattern, StringComparison.Ordinal))
        {
            return _compiledPattern;
        }

        _compiledPatternSource = Pattern;
        try
        {
            _compiledPattern = new(
                Pattern[1..^1],
                RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture,
                TimeSpan.FromSeconds(1));
        }
        catch (Exception ex)
        {
            _compiledPattern = null;
            onError?.Invoke(Pattern, ex);
        }

        return _compiledPattern;
    }
}

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

internal static class ChatHighlightHelper
{
    private static readonly MacroStringParseOptions MacroParseOptions = new()
    {
        ExceptionMode = MacroStringParseExceptionMode.Throw
    };

    public static SeString ApplyForeground(
        SeString message, uint rgbaColor)
    {
        string text;
        try
        {
            text = new ReadOnlySeString(message.Encode()).ExtractText();
        }
        catch
        {
            text = message.TextValue;
        }

        if (string.IsNullOrEmpty(text))
        {
            return message;
        }

        var argbColor = ColourUtil.RgbaToArgb(rgbaColor);
        var macroText = $"<color(0x{argbColor:X8})>{EscapeMacroText(text)}<color(stackcolor)>";
        using var rented = new RentedSeStringBuilder();
        rented.Builder.AppendMacroString(Encoding.UTF8.GetBytes(macroText), MacroParseOptions);
        return rented.Builder.ToReadOnlySeString().ToDalamudString();
    }

    private static string EscapeMacroText(string text)
    {
        if (text.IndexOfAny(['\\', '<', '>', '(', ')', '[', ']', ',']) < 0)
        {
            return text;
        }

        var builder = new StringBuilder(text.Length + 8);
        foreach (var ch in text)
        {
            if (ch is '\\' or '<' or '>' or '(' or ')' or '[' or ']' or ',')
            {
                builder.Append('\\');
            }

            builder.Append(ch);
        }

        return builder.ToString();
    }

    public static bool TryGetMatchingHighlight(IList<ChatHighlight> highlights, ChatType chatType,
        string rawTextValue, string extractedTextValue, string normalizedText, out ChatHighlight? match)
    {
        foreach (var entry in highlights)
        {
            if (Matches(entry, chatType, rawTextValue, extractedTextValue, normalizedText))
            {
                match = entry;
                return true;
            }
        }

        match = null;
        return false;
    }

    private static bool Matches(ChatHighlight entry, ChatType chatType, string rawTextValue,
        string extractedTextValue, string normalizedText)
    {
        if (string.IsNullOrWhiteSpace(entry.Pattern))
        {
            return false;
        }

        var channels = (ChatFlags.Channels)entry.Channels;
        if (channels == ChatFlags.Channels.None || !ChatFlags.CheckFlags(entry.Channels, chatType))
        {
            return false;
        }

        if (entry.IsRegex)
        {
            var regex = entry.GetCompiledRegex();
            if (regex is null)
            {
                return false;
            }

            try
            {
                return regex.IsMatch(rawTextValue) ||
                       regex.IsMatch(extractedTextValue) ||
                       regex.IsMatch(normalizedText);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        return TextMatchHelper.ContainsIgnoreCase(rawTextValue, entry.Pattern) ||
               TextMatchHelper.ContainsIgnoreCase(extractedTextValue, entry.Pattern) ||
               TextMatchHelper.ContainsIgnoreCase(normalizedText, entry.Pattern);
    }
}
