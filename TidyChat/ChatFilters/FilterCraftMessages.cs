using System;
using System.Linq;

namespace TidyChat;

public static class FilterCraftMessages
{
    public static bool IsFiltered(string input, Configuration configuration)
    {
        try
        {
            if (
                (configuration.FilterCraftingSpam && L10N.Get(ChatStrings.YouSynthesize).All(input.Contains)) ||
                (configuration.ShowAttachedMateria && L10N.Get(ChatRegexStrings.AttachedMateria).IsMatch(input)) ||
                (configuration.ShowOvermeldFailure && L10N.Get(ChatStrings.OvermeldFailure).All(input.Contains)) ||
                (configuration.ShowMateriaExtract && L10N.Get(ChatStrings.MateriaExtract).All(input.Contains)) ||
                (configuration.ShowTrialMessages && L10N.Get(ChatRegexStrings.TrialSynthesis).IsMatch(input)) ||
                (configuration.ShowTrialMessages && L10N.Get(ChatRegexStrings.TrialQuality).IsMatch(input)) ||
                (configuration.ShowTrialMessages && L10N.Get(ChatRegexStrings.TrialHQ).IsMatch(input)) ||
                (configuration.ShowTrialMessages && L10N.Get(ChatRegexStrings.TrialCollectability).IsMatch(input)) ||
                (configuration.ShowOtherSynthesis && L10N.Get(ChatRegexStrings.OtherSynthesis).IsMatch(input))
            )
                return false;
            return true;
        }
        catch (Exception e)
        {
            TidyChat.Log.Debug("Encountered error: " + e);
            return true;
        }
    }
}