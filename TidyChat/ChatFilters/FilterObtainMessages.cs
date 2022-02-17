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
                    (ChatStrings.RouletteBonus.All(input.Contains) && !configuration.ShowRouletteBonus) ||
                    (ChatStrings.AdventurerInNeedBonus.All(input.Contains) && !configuration.ShowAdventurerInNeedBonus) ||
                    (ChatRegexStrings.ObtainedGil.IsMatch(input) && !configuration.ShowObtainedGil) ||
                    (ChatRegexStrings.ObtainedMGP.IsMatch(input) && !configuration.ShowObtainedMGP) ||
                    (ChatRegexStrings.ObtainedSeals.IsMatch(input) && !configuration.ShowObtainedSeals) ||
                    (ChatRegexStrings.ObtainedVenture.IsMatch(input) && !configuration.ShowObtainedVenture) ||
                    (ChatRegexStrings.ObtainedTribalCurrency.IsMatch(input) && !configuration.ShowObtainedTribalCurrency) ||
                    (ChatRegexStrings.ObtainedShards.IsMatch(input) && !configuration.ShowObtainedShards) ||
                    (ChatRegexStrings.ObtainedClusters.IsMatch(input) && !configuration.ShowObtainedClusters) ||
                    (ChatRegexStrings.ObtainedAlliedSeals.IsMatch(input) && !configuration.ShowObtainedAlliedSeals) ||
                    (ChatRegexStrings.ObtainedCenturioSeals.IsMatch(input) && !configuration.ShowObtainedCenturioSeals) ||
                    (ChatRegexStrings.ObtainedNuts.IsMatch(input) && !configuration.ShowObtainedNuts) ||
                    (ChatRegexStrings.ObtainedMaterials.IsMatch(input) && !configuration.ShowObtainedMaterials) ||
                    (ChatRegexStrings.ObtainedTomestones.IsMatch(input) && input.Contains("poetics") && !configuration.ShowObtainedPoeticsTomestones) ||
                    (ChatRegexStrings.ObtainedTomestones.IsMatch(input) && input.Contains("aphorism") && !configuration.ShowObtainedAphorismTomestones) ||
                    (ChatRegexStrings.ObtainedTomestones.IsMatch(input) && input.Contains("astronomy") && !configuration.ShowObtainedAstronomyTomestones) ||
                    (ChatRegexStrings.OthersObtain.IsMatch(input) && !configuration.ShowOthersObtain) ||
                    (ChatRegexStrings.ObtainedMaterials.IsMatch(input) && !configuration.ShowObtainedMaterials)
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
