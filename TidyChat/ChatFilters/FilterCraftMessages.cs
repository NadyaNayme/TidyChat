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
                    (ChatStrings.YouSynthesize.All(input.Contains) && configuration.FilterCraftingSpam) ||
                    (ChatRegexStrings.AttachedMateria.IsMatch(input) && configuration.ShowAttachedMateria) ||
                    (ChatStrings.OvermeldFailure.All(input.Contains) && configuration.ShowOvermeldFailure) ||
                    (ChatStrings.MateriaExtract.All(input.Contains) && configuration.ShowMateriaExtract)
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
