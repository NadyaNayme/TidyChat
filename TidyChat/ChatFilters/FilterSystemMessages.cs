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
                // Whitelist specific phrases

                // You sense the presence of a powerful mark...
                string[] powerfulMark = { "you", "sense", "the", "presense", "of", "a", "powerful" };
                // Retainer completed a venture.
                string[] completedVenture = { "completed", "a", "venture" };
                // You received a player commendation!
                string[] playerCommendation = { "you", "received", "a", "player", "commendation" };
                // You are now in the instanced area Location Instance. Blah blah blah.
                string[] instancedArea = { "you", "are", "now", "in", "the", "instanced", "area" };

                if (
                    (powerfulMark.All(input.Contains) && !configuration.HideSRankHunt) ||
                    (completedVenture.All(input.Contains) && !configuration.HideCompletedVenture) ||
                    (playerCommendation.All(input.Contains) && !configuration.HideCommendations && !configuration.BetterCommendationMessage) ||
                    (instancedArea.All(input.Contains) && !configuration.HideInstanceMessage)
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