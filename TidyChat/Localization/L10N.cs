using System;
using System.Text.RegularExpressions;
using Dalamud.Game;
using TidyChat.Translation.Data;
namespace TidyChat;

internal static class L10N
{
    public static ClientLanguage Language { get; set; }

    public static string[] Get(LocalizedStrings strings)
    {
        return Language switch
        {
            ClientLanguage.Japanese => FallbackIfMissing(strings.Jpn, strings.Eng),
            ClientLanguage.English => strings.Eng,
            ClientLanguage.German => FallbackIfMissing(strings.Deu, strings.Eng),
            ClientLanguage.French => FallbackIfMissing(strings.Fra, strings.Eng),
            _ => strings.Eng // Won't work for J/F/D but at least it's not a crash
        };
    }

    public static Regex Get(LocalizedRegex regex)
    {
        return Language switch
        {
            ClientLanguage.Japanese => regex.Jpn,
            ClientLanguage.English => regex.Eng,
            ClientLanguage.German => regex.Deu,
            ClientLanguage.French => regex.Fra,
            _ => regex.Eng // Won't work for J/F/D but at least it's not a crash
        };
    }

    public static string GetTidy(LocalizedTidyStrings strings)
    {
        return Language switch
        {
            ClientLanguage.Japanese => FallbackIfMissing(strings.Jpn, strings.Eng),
            ClientLanguage.English => strings.Eng,
            ClientLanguage.German => FallbackIfMissing(strings.Deu, strings.Eng),
            ClientLanguage.French => FallbackIfMissing(strings.Fra, strings.Eng),
            _ => strings.Eng // Won't work for J/F/D but at least it's not a crash
        };
    }

    private static string FallbackIfMissing(string primary, string fallback)
        => string.IsNullOrEmpty(primary) || string.Equals(primary, "NeedsLocalization", StringComparison.Ordinal)
            ? fallback
            : primary;

    private static string[] FallbackIfMissing(string[] primary, string[] fallback)
        => primary is null || primary.Length == 0 ||
           (primary.Length == 1 && string.Equals(primary[0], "NeedsLocalization", StringComparison.Ordinal))
            ? fallback
            : primary;
}
