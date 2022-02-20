using System;
using System.Linq;

namespace TidyChat
{
    public static class FilterCraftMessages
    {
        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
                if (
                    configuration.FilterCraftingSpam && Localization.Get(ChatStrings.YouSynthesize).All(input.Contains) ||
                    configuration.ShowAttachedMateria && Localization.Get(ChatRegexStrings.AttachedMateria).IsMatch(input) ||
                    configuration.ShowOvermeldFailure && Localization.Get(ChatStrings.OvermeldFailure).All(input.Contains) ||
                    configuration.ShowMateriaExtract && Localization.Get(ChatStrings.MateriaExtract).All(input.Contains)
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
