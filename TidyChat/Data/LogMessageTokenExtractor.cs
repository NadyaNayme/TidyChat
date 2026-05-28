using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
namespace TidyChat.Data;

/// <summary>
///     Builds lowercase word tokens from LogMessage template text for substring matching in filters.
/// </summary>
internal static class LogMessageTokenExtractor
{
    private const RegexOptions Options =
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture;

    private static readonly TimeSpan RegexTimeout = TimeSpan.FromSeconds(1);

    private static readonly Regex XmlTagRegex = new(@"</?[A-Za-z][^>]*>", Options, RegexTimeout);
    private static readonly Regex FfxivParameterRegex = new(
        @"(Integer|Object|String|Player|StringParameter|IntegerParameter|SheetParameter)\([^)]*\)",
        Options, RegexTimeout);
    private static readonly Regex PlaceholderRegex = new(@"%[\d]*[a-zA-Z]|%[^\s%]+", Options, RegexTimeout);
    private static readonly Regex AnglePlaceholderRegex = new(@"<[^>]+>", Options, RegexTimeout);
    private static readonly Regex SelfClosingFragmentRegex = new(@"\)/>", Options, RegexTimeout);
    private static readonly Regex SeIconRegex = new(@"[\uE000-\uF8FF]", Options, RegexTimeout);
    private static readonly Regex WordRegex = new(@"[\p{L}\p{N}]+", Options, RegexTimeout);

    /// <summary>
    ///     Tokenize template text for <c>normalizedText.Contains</c> checks.
    ///     Strips FFXIV placeholders, XML-like tags, format codes, and icon characters first.
    /// </summary>
    public static string[] Extract(string templateText)
    {
        if (string.IsNullOrWhiteSpace(templateText)) return [];

        string stripped = XmlTagRegex.Replace(templateText, " ");
        stripped = FfxivParameterRegex.Replace(stripped, " ");
        stripped = PlaceholderRegex.Replace(stripped, " ");
        stripped = AnglePlaceholderRegex.Replace(stripped, " ");
        stripped = SelfClosingFragmentRegex.Replace(stripped, " ");
        stripped = SeIconRegex.Replace(stripped, " ");

        var tokens = new List<string>();
        foreach(Match match in WordRegex.Matches(stripped))
        {
            string token = match.Value.ToLower(CultureInfo.CurrentCulture);
            if (token.Length == 0) continue;
            if (token.Length == 1 && !ContainsCjk(token)) continue;
            tokens.Add(token);
        }

        return tokens.Count == 0 ? [] : tokens.ToArray();
    }

    private static bool ContainsCjk(string token)
    {
        foreach(char c in token)
        {
            if (c is >= '\u3040' and <= '\u9FFF') return true;
        }
        return false;
    }
}
