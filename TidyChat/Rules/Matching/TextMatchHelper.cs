using TidyChat.Localization.Data;
namespace TidyChat;

internal static class TextMatchHelper
{
    public static bool MatchesAllTokens(string normalizedText, LocalizedStrings marker) =>
        L10N.Get(marker).All(normalizedText.Contains);

    public static bool MatchesAny(string normalizedText, params LocalizedStrings[] markers)
    {
        foreach (var marker in markers)
        {
            if (MatchesAllTokens(normalizedText, marker))
            {
                return true;
            }
        }

        return false;
    }

    public static bool ContainsIgnoreCase(string haystack, string needle) =>
        !string.IsNullOrEmpty(needle) &&
        haystack.Contains(needle, StringComparison.OrdinalIgnoreCase);

    public static bool IsSlashDelimitedRegex(string value) =>
        value.Length >= 2 && value.StartsWith('/') && value.EndsWith('/');
}
