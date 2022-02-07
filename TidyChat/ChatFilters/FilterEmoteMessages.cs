using System;

namespace TidyChat
{
    public sealed class FilterEmoteMessages
    {

        public static bool IsFiltered(string input)
        {
            try
            {
                bool targetedEmote = input.ToLower().Contains("you") == true || input.ToLower().Contains("your") == true;
                return !targetedEmote;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}