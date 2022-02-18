using Dalamud;
using System;
using System.Linq;

namespace TidyChat
{
    public class FilterObtainMessages
    {
        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
                if (
                     !configuration.ShowRouletteBonus && Localization.Get(ChatStrings.RouletteBonus).All(input.Contains) ||
                     !configuration.ShowAdventurerInNeedBonus && Localization.Get(ChatStrings.AdventurerInNeedBonus).All(input.Contains) ||
                     !configuration.ShowObtainedGil && Localization.Get(ChatRegexStrings.ObtainedGil).IsMatch(input) ||
                     !configuration.ShowObtainedMGP && Localization.Get(ChatRegexStrings.ObtainedMGP).IsMatch(input) ||
                     !configuration.ShowObtainedSeals && Localization.Get(ChatRegexStrings.ObtainedSeals).IsMatch(input) ||
                     !configuration.ShowObtainedVenture && Localization.Get(ChatRegexStrings.ObtainedVenture).IsMatch(input) ||
                     !configuration.ShowObtainedTribalCurrency && Localization.Get(ChatRegexStrings.ObtainedTribalCurrency).IsMatch(input) ||
                     !configuration.ShowObtainedShards && Localization.Get(ChatRegexStrings.ObtainedShards).IsMatch(input) ||
                     !configuration.ShowObtainedClusters && Localization.Get(ChatRegexStrings.ObtainedClusters).IsMatch(input) ||
                     !configuration.ShowObtainedAlliedSeals && Localization.Get(ChatRegexStrings.ObtainedAlliedSeals).IsMatch(input) ||
                     !configuration.ShowObtainedCenturioSeals && Localization.Get(ChatRegexStrings.ObtainedCenturioSeals).IsMatch(input) ||
                     !configuration.ShowObtainedNuts && Localization.Get(ChatRegexStrings.ObtainedNuts).IsMatch(input) ||
                     !configuration.ShowObtainedMaterials && Localization.Get(ChatRegexStrings.ObtainedMaterials).IsMatch(input) ||
                     !configuration.ShowObtainedPoeticsTomestones && Localization.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(input) && Localization.language switch {
                         ClientLanguage.Japanese => input.Contains("詩学"),
                         _ => input.Contains("poetics")
                     } ||
                     !configuration.ShowObtainedAphorismTomestones && Localization.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(input) && Localization.language switch
                     {
                         ClientLanguage.Japanese => input.Contains("経典"),
                         _ => input.Contains("aphorism")
                     } ||
                     !configuration.ShowObtainedAstronomyTomestones && Localization.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(input) && Localization.language switch
                     {
                         ClientLanguage.Japanese => input.Contains("天文"),
                         _ => input.Contains("astronomy")
                     } ||
                     !configuration.ShowOthersObtain && Localization.Get(ChatRegexStrings.OthersObtain).IsMatch(input) ||
                     !configuration.ShowObtainedMaterials && Localization.Get(ChatRegexStrings.ObtainedMaterials).IsMatch(input)
                    )
                {
                    return true;
                }

                // We hit the end of our blacklist - allow the message
                return false;
            }
            // If we somehow encounter an error - allow the message
            catch (Exception)
            {
                return false;
            }
        }
    }
}
