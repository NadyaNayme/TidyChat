using Dalamud.Logging;
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
                    configuration.ShowMateriaExtract && Localization.Get(ChatStrings.MateriaExtract).All(input.Contains) ||
                    configuration.ShowTrialMessages && Localization.Get(ChatRegexStrings.TrialSynthesis).IsMatch(input) ||
                    configuration.ShowTrialMessages && Localization.Get(ChatRegexStrings.TrialQuality).IsMatch(input) ||
                    configuration.ShowTrialMessages && Localization.Get(ChatRegexStrings.TrialHQ).IsMatch(input) ||
                    configuration.ShowTrialMessages && Localization.Get(ChatRegexStrings.TrialCollectability).IsMatch(input) ||
                    configuration.ShowOtherSynthesis && Localization.Get(ChatRegexStrings.OtherSynthesis).IsMatch(input)
                   )
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                PluginLog.LogDebug("Encountered error: " + e);
                return true;
            }
        }
    }
}
