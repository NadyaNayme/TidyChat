using System.Text.RegularExpressions;
using Dalamud.Game.Text.SeStringHandling;

namespace TidyChat.Utility
{
    internal static class NormalizeInput
    {
        // Make everything lowercase so I don't have to think about which words are capitalized in the message
        public static string ToLowercase(SeString message)
        {
            string input = message.TextValue.ToLower();
            return input;
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
            Regex FNLI = new(FirstNameLastInitial.ToLower());
            Regex FILN = new(FirstInitialLastName.ToLower());
            Regex IO = new(InitialsOnly.ToLower());
            normalizedInput = normalizedInput.Replace($"{configuration.PlayerName.ToLower()}", "you");
            normalizedInput = FNLI.Replace(normalizedInput, "you", 1);
            normalizedInput = FILN.Replace(normalizedInput, "you", 1);
            normalizedInput = IO.Replace(normalizedInput, "you", 1);
            return normalizedInput;
        }
    }
}
