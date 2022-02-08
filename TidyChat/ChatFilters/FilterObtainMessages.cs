using System;

namespace TidyChat
{
    public class FilterObtainMessages
    {
        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
                if (
                    (ChatRegexStrings.ObtainedGil.IsMatch(input) && !configuration.ShowObtainedGil) ||
                    (ChatRegexStrings.ObtainedClusters.IsMatch(input) && !configuration.ShowObtainedClusters) ||
                    (ChatRegexStrings.ObtainedSeals.IsMatch(input) && !configuration.ShowObtainedSeals) ||
                    (ChatRegexStrings.ObtainedNuts.IsMatch(input) && !configuration.ShowObtainedNuts) ||
                    (ChatRegexStrings.ObtainedVenture.IsMatch(input) && !configuration.ShowObtainedVenture) ||
                    (ChatRegexStrings.ObtainedMaterials.IsMatch(input) && !configuration.ShowObtainedMaterials) ||
                    (ChatRegexStrings.ObtainedShards.IsMatch(input) && !configuration.ShowObtainedShards)
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