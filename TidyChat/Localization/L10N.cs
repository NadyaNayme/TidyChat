using Dalamud.Game;
using System.Text.RegularExpressions;
using TidyChat.Localization.Data;
namespace TidyChat;

internal static class L10N
{
    public static ClientLanguage Language { get; set; }

    public static string[] Get(LocalizedStrings strings) => Language switch
    {
        ClientLanguage.Japanese => FallbackIfMissing(strings.Jpn, strings.Eng),
        ClientLanguage.English => strings.Eng,
        ClientLanguage.German => FallbackIfMissing(strings.Deu, strings.Eng),
        ClientLanguage.French => FallbackIfMissing(strings.Fra, strings.Eng),
        _ => strings.Eng
    };

    public static Regex Get(LocalizedRegex regex) => Language switch
    {
        ClientLanguage.Japanese => FallbackRegexIfMissing(regex.Jpn, regex.Eng),
        ClientLanguage.English => regex.Eng,
        ClientLanguage.German => FallbackRegexIfMissing(regex.Deu, regex.Eng),
        ClientLanguage.French => FallbackRegexIfMissing(regex.Fra, regex.Eng),
        _ => regex.Eng
    };

    public static string GetTidy(LocalizedTidyStrings strings) => Language switch
    {
        ClientLanguage.Japanese => FallbackIfMissing(strings.Jpn, strings.Eng),
        ClientLanguage.English => strings.Eng,
        ClientLanguage.German => FallbackIfMissing(strings.Deu, strings.Eng),
        ClientLanguage.French => FallbackIfMissing(strings.Fra, strings.Eng),
        _ => strings.Eng
    };

    private static string FallbackIfMissing(string primary, string fallback)
        => string.IsNullOrEmpty(primary) || string.Equals(primary, "NeedsLocalization", StringComparison.Ordinal)
            ? fallback
            : primary;

    private static string[] FallbackIfMissing(string[] primary, string[] fallback)
        => primary is null || primary.Length == 0 ||
           (primary.Length == 1 && string.Equals(primary[0], "NeedsLocalization", StringComparison.Ordinal))
            ? fallback
            : primary;

    private static Regex FallbackRegexIfMissing(Regex primary, Regex fallback) =>
        string.Equals(primary.ToString(), "NeedsLocalization", StringComparison.Ordinal)
            ? fallback
            : primary;
}
