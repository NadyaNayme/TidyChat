using System;
using System.Linq;

namespace TidyChat
{
    public sealed class FilterFreeCompanyMessages
    {
        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
                if (
                    Localization.Get(ChatStrings.HasLoggedOut).All(input.Contains) ||
                    // It never hurts to be safe.
                    Localization.Get(ChatRegexStrings.HasLoggedOut).IsMatch(input)
                   )
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
