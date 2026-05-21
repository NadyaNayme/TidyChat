using System.Text.RegularExpressions;
using Dalamud.Game;
using TidyChat.Translation.Data;

namespace TidyChat;

internal static class L10N
{
    public static ClientLanguage Language { get; set; }
    
    public static string[] Get(string[] strings)
    {
#if DEBUG
        TidyChatPlugin.Log?.Debug("Strings not localized: {0}", string.Join(",", strings));
#endif
        return strings;
    }

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

    public static Regex Get(Regex regex)
    {
#if DEBUG
        TidyChatPlugin.Log?.Debug("Regex not localized: {0}", regex.ToString());
#endif
        return regex;
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

    public static string GetTidy(string strings)
    {
#if DEBUG
        TidyChatPlugin.Log?.Debug("Internal strings not localized: {0}", strings);
#endif
        return strings;
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

    /// <summary>
    ///     Returns <paramref name="primary"/> unless it is missing or is still the literal
    ///     <c>"NeedsLocalization"</c> placeholder, in which case <paramref name="fallback"/> is returned.
    ///     Prevents the literal placeholder text from leaking into chat for partially-localized strings.
    /// </summary>
    private static string FallbackIfMissing(string primary, string fallback)
        => string.IsNullOrEmpty(primary) || string.Equals(primary, "NeedsLocalization", System.StringComparison.Ordinal)
            ? fallback
            : primary;

    private static string[] FallbackIfMissing(string[] primary, string[] fallback)
        => primary is null || primary.Length == 0 ||
           (primary.Length == 1 && string.Equals(primary[0], "NeedsLocalization", System.StringComparison.Ordinal))
            ? fallback
            : primary;
}
