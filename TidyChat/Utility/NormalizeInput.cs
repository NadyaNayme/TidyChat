using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Dalamud.Game.Text.SeStringHandling;

namespace TidyChat.Utility;

internal static class NormalizeInput
{
    // Make everything lowercase so I don't have to think about which words are capitalized in the message
    public static string ToLowercase(SeString message)
    {
        return message.TextValue.ToLower(CultureInfo.CurrentCulture);
    }

    private static readonly RegexOptions regexOptions =
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

    private static readonly TimeSpan regexTimeout = TimeSpan.FromSeconds(1);

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
        var FirstNameLastInitial =
            $"{configuration.PlayerName.Split(' ')[0]} {configuration.PlayerName.Split(' ')[1][0]}.";
        var FirstInitialLastName =
            $"{configuration.PlayerName.Split(' ')[0][0]}. {configuration.PlayerName.Split(' ')[1]}";
        var InitialsOnly = $"{configuration.PlayerName.Split(' ')[0][0]}. {configuration.PlayerName.Split(' ')[1][0]}.";
        Regex FNLI = new(@"(^|\s)" + FirstNameLastInitial.ToLower(CultureInfo.CurrentCulture) + @"(\s|$)", regexOptions, regexTimeout);
        Regex FILN = new(@"(^|\s)" + FirstInitialLastName.ToLower(CultureInfo.CurrentCulture) + @"(\s|$)", regexOptions, regexTimeout);
        Regex IO = new(@"(^|\s)" + InitialsOnly.ToLower(CultureInfo.CurrentCulture) + @"(\s|$)", regexOptions, regexTimeout);
        normalizedInput = normalizedInput.Replace($"{configuration.PlayerName}", "you", System.StringComparison.Ordinal);
        normalizedInput = FNLI.Replace(normalizedInput, "you", 1);
        normalizedInput = FILN.Replace(normalizedInput, "you", 1);
        normalizedInput = IO.Replace(normalizedInput, "you", 1);
        return normalizedInput;
    }
}