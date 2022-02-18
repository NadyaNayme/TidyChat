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
                if (ChatRegexStrings.HasLoggedOut.IsMatch(input))
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
