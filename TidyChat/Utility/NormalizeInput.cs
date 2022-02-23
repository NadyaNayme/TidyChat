using System.Text.RegularExpressions;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Logging;

namespace TidyChat.Utility
{
    internal static class NormalizeInput
    {
        // Make everything lowercase so I don't have to think about which words are capitalized in the message
        public static string ToLowercase(SeString message)
        {
            return message.TextValue.ToLower();            
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
            string FirstNameLastInitial = $"{configuration.PlayerName.Split(' ')[0]} {configuration.PlayerName.Split(' ')[1][0]}.";
            string FirstInitialLastName = $"{configuration.PlayerName.Split(' ')[0][0]}. {configuration.PlayerName.Split(' ')[1]}";
            string InitialsOnly = $"{configuration.PlayerName.Split(' ')[0][0]}. {configuration.PlayerName.Split(' ')[1][0]}.";
            Regex FNLI = new(@"(^|\s)" + FirstNameLastInitial.ToLower() + @"(\s|$)");
            Regex FILN = new(@"(^|\s)" + FirstInitialLastName.ToLower() + @"(\s|$)");
            Regex IO = new(@"(^|\s)" + InitialsOnly.ToLower() + @"(\s|$)");
            normalizedInput = normalizedInput.Replace($"{configuration.PlayerName}", "you");
            normalizedInput = FNLI.Replace(normalizedInput, "you", 1);
            normalizedInput = FILN.Replace(normalizedInput, "you", 1);
            normalizedInput = IO.Replace(normalizedInput, "you", 1);
            return normalizedInput;
        }
    }
}
