using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
namespace TidyChat.Settings;

public class ChatHighlight
{
    [NonSerialized] private Regex? _compiledPattern;
    [NonSerialized] private string? _compiledPatternSource;

    public string Pattern = string.Empty;
    public uint RgbaColor = ChatHighlightPresets.DefaultRgba;
    public int Channels = (int)ChatFlags.Channels.Loot;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ushort UiForegroundColor { get; set; }

    public bool IsRegex => IsRegexShape(Pattern);

    public Regex? GetCompiledRegex(Action<string, Exception>? onError = null)
    {
        if (string.IsNullOrEmpty(Pattern) || !IsRegexShape(Pattern))
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

    private static bool IsRegexShape(string value)
        => value.Length >= 2 && value.StartsWith('/') && value.EndsWith('/');
}
