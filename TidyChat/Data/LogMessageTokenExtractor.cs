using System.Text.RegularExpressions;
namespace TidyChat.Data;

internal readonly record struct TemplateToken(string Text, bool OpenStart, bool OpenEnd)
{
    // only macro-glued edges may run into letters (plurals); others need a word break so "ward" ≠ "wardr…" (#132)
    public bool IsIn(string text)
    {
        var index = text.IndexOf(Text, StringComparison.Ordinal);
        while (index >= 0)
        {
            var end = index + Text.Length;
            if ((OpenStart || index == 0 || !char.IsLetterOrDigit(text[index - 1])) &&
                (OpenEnd || end == text.Length || !char.IsLetterOrDigit(text[end])))
            {
                return true;
            }
            index = text.IndexOf(Text, index + 1, StringComparison.Ordinal);
        }
        return false;
    }
}

internal static class LogMessageTokenExtractor
{
    internal const char MacroMarker = '\u0001';

    private const RegexOptions Options =
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture;

    private static readonly TimeSpan RegexTimeout = TimeSpan.FromSeconds(1);

    private static readonly Regex BraceParameterRegex = new(@"\{[^{}]*\}", Options, RegexTimeout);
    private static readonly Regex XmlTagRegex = new(@"</?[A-Za-z][^>]*>", Options, RegexTimeout);
    private static readonly Regex FfxivParameterRegex = new(
        @"(Integer|Object|String|Player|StringParameter|IntegerParameter|SheetParameter)\([^)]*\)",
        Options, RegexTimeout);
    private static readonly Regex PlaceholderRegex = new(@"%[\d]*[a-zA-Z]|%[^\s%]+", Options, RegexTimeout);
    private static readonly Regex AnglePlaceholderRegex = new(@"<[^>]+>", Options, RegexTimeout);
    private static readonly Regex SelfClosingFragmentRegex = new(@"\)/>", Options, RegexTimeout);
    private static readonly Regex SeIconRegex = new(@"[-]", Options, RegexTimeout);
    private static readonly Regex WordRegex = new(@"[\p{L}\p{N}]+", Options, RegexTimeout);

    public static string[] Extract(string templateText) =>
        [.. ExtractTokens(templateText).Select(token => token.Text)];

    public static TemplateToken[] ExtractTokens(string templateText)
    {
        if (string.IsNullOrWhiteSpace(templateText))
        {
            return [];
        }

        var marker = MacroMarker.ToString();
        var stripped = BraceParameterRegex.Replace(templateText, marker);
        stripped = XmlTagRegex.Replace(stripped, marker);
        stripped = FfxivParameterRegex.Replace(stripped, marker);
        stripped = PlaceholderRegex.Replace(stripped, marker);
        stripped = AnglePlaceholderRegex.Replace(stripped, marker);
        stripped = SelfClosingFragmentRegex.Replace(stripped, marker);
        stripped = SeIconRegex.Replace(stripped, " ");

        var tokens = new List<TemplateToken>();
        foreach (Match match in WordRegex.Matches(stripped))
        {
            var token = match.Value.ToLower(CultureInfo.CurrentCulture);
            var cjk = ContainsCjk(token);
            if (token.Length == 1 && !cjk)
            {
                continue;
            }

            var end = match.Index + match.Length;
            tokens.Add(new TemplateToken(
                token,
                cjk || (match.Index > 0 && stripped[match.Index - 1] == MacroMarker),
                cjk || (end < stripped.Length && stripped[end] == MacroMarker)));
        }

        return [.. tokens];
    }

    private static bool ContainsCjk(string token)
    {
        foreach (var c in token)
        {
            if (c is >= '぀' and <= '鿿')
            {
                return true;
            }
        }
        return false;
    }
}
