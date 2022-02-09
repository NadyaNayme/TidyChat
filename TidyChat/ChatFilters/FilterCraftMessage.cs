using System;
using System.Linq;

namespace TidyChat
{
    public sealed class FilterCraftMessages
    {
        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
                if (
                    (ChatStrings.YouSynthesize.All(input.Contains) && configuration.FilterCraftingSpam)
                   )
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}