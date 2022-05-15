using System;
using System.Linq;
using Dalamud;
using Dalamud.Logging;

namespace TidyChat;

public static class FilterObtainMessages
{
    public static bool IsFiltered(string input, Configuration configuration)
    {
        try
        {
            PluginLog.LogDebug("Debug Mode: " + input);
            if (
                (!configuration.ShowRouletteBonus && L10N.Get(ChatStrings.RouletteBonus).All(input.Contains)) ||
                (!configuration.ShowAdventurerInNeedBonus &&
                 L10N.Get(ChatStrings.AdventurerInNeedBonus).All(input.Contains)) ||
                (!configuration.ShowObtainedGil && L10N.Get(ChatRegexStrings.ObtainedGil).IsMatch(input)) ||
                (!configuration.ShowObtainedMGP && L10N.Get(ChatRegexStrings.ObtainedMGP).IsMatch(input)) ||
                (!configuration.ShowObtainedWolfMarks && L10N.Get(ChatRegexStrings.ObtainedWolfMarks).IsMatch(input)) ||
                (!configuration.ShowObtainedSeals && L10N.Get(ChatRegexStrings.ObtainedSeals).IsMatch(input)) ||
                (!configuration.ShowObtainedVenture && L10N.Get(ChatRegexStrings.ObtainedVenture).IsMatch(input)) ||
                (!configuration.ShowObtainedTribalCurrency &&
                 L10N.Get(ChatRegexStrings.ObtainedTribalCurrency).IsMatch(input)) ||
                (!configuration.ShowObtainedShards && L10N.Get(ChatRegexStrings.ObtainedShards).IsMatch(input)) ||
                (!configuration.ShowObtainedClusters && L10N.Get(ChatRegexStrings.ObtainedClusters).IsMatch(input)) ||
                (!configuration.ShowObtainedAlliedSeals &&
                 L10N.Get(ChatRegexStrings.ObtainedAlliedSeals).IsMatch(input)) ||
                (!configuration.ShowObtainedCenturioSeals &&
                 L10N.Get(ChatRegexStrings.ObtainedCenturioSeals).IsMatch(input)) ||
                (!configuration.ShowObtainedNuts && L10N.Get(ChatRegexStrings.ObtainedNuts).IsMatch(input)) ||
                (!configuration.ShowObtainedMaterials && L10N.Get(ChatRegexStrings.ObtainedMaterials).IsMatch(input)) ||
                (!configuration.ShowObtainedPoeticsTomestones &&
                 L10N.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(input) && L10N.Language switch
                 {
                     ClientLanguage.Japanese => input.Contains("詩学"),
                     ClientLanguage.English => input.Contains("poetics"),
                     ClientLanguage.German => input.Contains("poesie"),
                     ClientLanguage.French => input.Contains("poétique"),
                     _ => input.Contains("poetics")
                 }) ||
                (!configuration.ShowObtainedAphorismTomestones &&
                 L10N.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(input) && L10N.Language switch
                 {
                     ClientLanguage.Japanese => input.Contains("経典"),
                     ClientLanguage.English => input.Contains("aphorism"),
                     ClientLanguage.German => input.Contains("aphorismus"),
                     ClientLanguage.French => input.Contains("aphoristique"),
                     _ => input.Contains("aphorism")
                 }) ||
                (!configuration.ShowObtainedAstronomyTomestones &&
                 L10N.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(input) && L10N.Language switch
                 {
                     ClientLanguage.Japanese => input.Contains("天文"),
                     ClientLanguage.English => input.Contains("astronomy"),
                     ClientLanguage.German => input.Contains("astronomie"),
                     ClientLanguage.French => input.Contains("astronomique"),
                     _ => input.Contains("astronomy")
                 }) ||
                (!configuration.ShowOthersObtain && !input.StartsWith("you ") &&
                 L10N.Get(ChatRegexStrings.OtherObtains).IsMatch(input)) ||
                (!configuration.ShowObtainedMaterials && L10N.Get(ChatRegexStrings.ObtainedMaterials).IsMatch(input))
            )
                return true;

            // We hit the end of our blacklist - allow the message
            return false;
        }
        // If we somehow encounter an error - allow the message
        catch (Exception e)
        {
            PluginLog.LogDebug("Encountered error: " + e);
            return false;
        }
    }
}