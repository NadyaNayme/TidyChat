using System;
using System.Linq;
using Dalamud.Game;

namespace TidyChat;

public static class FilterObtainMessages
{
    public static bool IsFiltered(string input, Configuration configuration)
    {
        try
        {
            TidyChatPlugin.Log.Debug("Debug Mode: " + input);
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
                     ClientLanguage.Japanese => input.Contains("詩学", StringComparison.Ordinal),
                     ClientLanguage.English => input.Contains("poetics", StringComparison.Ordinal),
                     ClientLanguage.German => input.Contains("poesie", StringComparison.Ordinal),
                     ClientLanguage.French => input.Contains("poétique", StringComparison.Ordinal),
                     _ => input.Contains("poetics", StringComparison.Ordinal)
                 }) ||
                (!configuration.ShowObtainedAphorismTomestones &&
                 L10N.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(input) && L10N.Language switch
                 {
                     ClientLanguage.Japanese => input.Contains("経典", StringComparison.Ordinal),
                     ClientLanguage.English => input.Contains("aphorism", StringComparison.Ordinal),
                     ClientLanguage.German => input.Contains("aphorismus", StringComparison.Ordinal),
                     ClientLanguage.French => input.Contains("aphoristique", StringComparison.Ordinal),
                     _ => input.Contains("aphorism", StringComparison.Ordinal)
                 }) ||
                (!configuration.ShowObtainedAstronomyTomestones &&
                 L10N.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(input) && L10N.Language switch
                 {
                     ClientLanguage.Japanese => input.Contains("天文", StringComparison.Ordinal),
                     ClientLanguage.English => input.Contains("astronomy", StringComparison.Ordinal),
                     ClientLanguage.German => input.Contains("astronomie", StringComparison.Ordinal),
                     ClientLanguage.French => input.Contains("astronomique", StringComparison.Ordinal),
                     _ => input.Contains("astronomy", StringComparison.Ordinal)
                 }) ||
                (!configuration.ShowOthersObtain && !input.StartsWith("you ", StringComparison.Ordinal) &&
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
            TidyChatPlugin.Log.Error("Encountered error: " + e);
            return false;
        }
    }
}