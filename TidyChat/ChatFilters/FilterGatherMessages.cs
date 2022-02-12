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
					(ChatStrings.LocationAffects.All(input.Contains) &&
						ChatStrings.GatheringYield.All(input.Contains) && configuration.HideGatheringYield) ||
					(ChatStrings.LocationAffects.All(input.Contains) &&
						ChatStrings.GatherersBoon.All(input.Contains) && configuration.HideGatherersBoon) ||
					(ChatStrings.LocationAffects.All(input.Contains) &&
						ChatStrings.GatheringAttempts.All(input.Contains) && configuration.HideGatheringAttempts)
				) {
					return true;
				}
                if (
                    (ChatStrings.LocationAffects.All(input.Contains) && configuration.ShowLocationAffects)
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
