using System;
using System.Linq;

namespace TidyChat
{
    public class FilterSystemMessages
    {

        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
                if (
                    (ChatStrings.PowerfulMark.All(input.Contains) && !configuration.HideSRankHunt) ||
                    (ChatStrings.CompletedVenture.All(input.Contains) && !configuration.HideCompletedVenture) ||
                    (ChatStrings.PlayerCommendation.All(input.Contains) && !configuration.HideCommendations && !configuration.BetterCommendationMessage) ||
                    (ChatStrings.InstancedArea.All(input.Contains) && !configuration.HideInstanceMessage)
                   )
                {
                    return false;
                }

                // We hit the end of our whitelist - block the message
                return true;
            }
            // If we somehow encounter an error - block the message
            catch (Exception)
            {
                return true;
            }
        }
    }
}