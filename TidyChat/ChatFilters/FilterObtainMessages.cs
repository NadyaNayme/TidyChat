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
                    (ChatRegexStrings.ObtainedGil.IsMatch(input) && configuration.HideObtainedGil) ||
                    (ChatRegexStrings.ObtainedClusters.IsMatch(input) && configuration.HideObtainedClusters) ||
                    (ChatRegexStrings.ObtainedSeals.IsMatch(input) && configuration.HideObtainedSeals) ||
                    (ChatRegexStrings.ObtainedNuts.IsMatch(input) && configuration.HideObtainedNuts) ||
                    (ChatRegexStrings.ObtainedVenture.IsMatch(input) && configuration.HideObtainedVenture) ||
                    (ChatRegexStrings.ObtainedMaterials.IsMatch(input) && configuration.HideObtainedMaterials) ||
                    (ChatRegexStrings.ObtainedShards.IsMatch(input) && configuration.HideObtainedShards)
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