using System;

namespace TidyChat
{
    public sealed class FilterEmoteMessages
    {

        public static bool IsFiltered(string input)
        {
            try
            {
                bool targetedEmote = input.Contains("you") == true || input.Contains("your") == true;
                return !targetedEmote;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}