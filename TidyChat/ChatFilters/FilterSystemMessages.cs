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
                    (ChatRegexStrings.BetterPlayerCommendation.IsMatch(input) && configuration.BetterCommendationMessage) ||
                    (ChatStrings.InstancedArea.All(input.Contains) && !configuration.HideInstanceMessage) ||
                    (ChatStrings.SayQuestReminder.All(input.Contains) && !configuration.HideQuestReminder) ||
                    (ChatStrings.ReadyCheckComplete.All(input.Contains) && !configuration.HideReadyChecks) ||
                    (ChatStrings.SpideySenses.All(input.Contains) && !configuration.HideSpideySenses) ||
                    (ChatStrings.AetherCompass.All(input.Contains) && !configuration.HideAetherCompass) ||
                    (ChatStrings.CountdownTime.All(input.Contains) && !configuration.HideCountdownTime) ||
                    (ChatRegexStrings.ItemSearchCommand.IsMatch(input)) ||
                    (ChatStrings.SayQuestReminder.All(input.Contains) && !configuration.HideQuestReminder && configuration.BetterSayReminder)
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