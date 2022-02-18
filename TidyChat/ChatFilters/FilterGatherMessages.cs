using System;
using System.Linq;

namespace TidyChat
{
    public sealed class FilterGatherMessages
    {
        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
				if (
					configuration.HideGatheringYield &&
                        Localization.Get(ChatStrings.LocationAffects).All(input.Contains) &&
                        Localization.Get(ChatStrings.GatheringYield).All(input.Contains) ||
					configuration.HideGatherersBoon &&
                        Localization.Get(ChatStrings.LocationAffects).All(input.Contains) &&
						Localization.Get(ChatStrings.GatherersBoon).All(input.Contains) ||
					configuration.HideGatheringAttempts &&
                        Localization.Get(ChatStrings.LocationAffects).All(input.Contains) &&
						Localization.Get(ChatStrings.GatheringAttempts).All(input.Contains) ||
					Localization.Get(ChatRegexStrings.GatheringStartEnd).IsMatch(input)
				) {
					return true;
				}
                if (
                    (configuration.ShowLocationAffects && Localization.Get(ChatStrings.LocationAffects).All(input.Contains))
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
