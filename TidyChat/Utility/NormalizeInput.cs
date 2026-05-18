using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Dalamud.Game.Text.SeStringHandling;
using Lumina.Text.ReadOnly;
namespace TidyChat.Utility;

internal static class NormalizeInput
{

    private static readonly RegexOptions regexOptions =
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

    private static readonly TimeSpan regexTimeout = TimeSpan.FromSeconds(1);

    // Make everything lowercase so I don't have to think about which words are capitalized in the message.
    // Uses Lumina's ReadOnlySeString.ExtractText() rather than SeString.TextValue so that text embedded
    // inside link/expression payloads (e.g. channel-link payloads that encode "Novice Network" as a
    // string-argument expression rather than a raw TextPayload) is also included in the result.
    // Falls back to TextValue if encoding/extraction throws for any reason.
    public static string ToLowercase(SeString message)
    {
        try
        {
            return new ReadOnlySeString(message.Encode()).ExtractText()
                .ToLower(CultureInfo.CurrentCulture);
        }
        catch
        {
            return message.TextValue.ToLower(CultureInfo.CurrentCulture);
        }
    }

    /*
     * IMPORTANT:
     * Initialed name settings & JP localization depends on the
     * player's name being replaced by "you", as there is no other way
     * to distinguish messages about the player. So we replace the player's name or initials
     * with "you" before filtering the message.
     *
     */
    public static string ReplaceName(string normalizedInput, Configuration configuration)
    {
        // I do not claim to be a smart man, but I do like to dabble in the dark magics.
        string FirstNameLastInitial =
            $"{configuration.PlayerName.Split(' ')[0]} {configuration.PlayerName.Split(' ')[1][0]}.";
        string FirstInitialLastName =
            $"{configuration.PlayerName.Split(' ')[0][0]}. {configuration.PlayerName.Split(' ')[1]}";
        string InitialsOnly = $"{configuration.PlayerName.Split(' ')[0][0]}. {configuration.PlayerName.Split(' ')[1][0]}.";
        Regex FNLI = new(@"(^|\s)" + FirstNameLastInitial.ToLower(CultureInfo.CurrentCulture) + @"(\s|$)", regexOptions, regexTimeout);
        Regex FILN = new(@"(^|\s)" + FirstInitialLastName.ToLower(CultureInfo.CurrentCulture) + @"(\s|$)", regexOptions, regexTimeout);
        Regex IO = new(@"(^|\s)" + InitialsOnly.ToLower(CultureInfo.CurrentCulture) + @"(\s|$)", regexOptions, regexTimeout);
        normalizedInput = normalizedInput.Replace($"{configuration.PlayerName}", "you", StringComparison.Ordinal);
        normalizedInput = FNLI.Replace(normalizedInput, "you", 1);
        normalizedInput = FILN.Replace(normalizedInput, "you", 1);
        normalizedInput = IO.Replace(normalizedInput, "you", 1);
        return normalizedInput;
    }
}
