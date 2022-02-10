using System;
using System.Linq;

namespace TidyChat
{
    public sealed class FilterLootMessages
    {
        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
                if (
                    (ChatRegexStrings.RollsNeedOrGreed.IsMatch(input) && !configuration.ShowLootRoll) ||
                    (ChatRegexStrings.CastLot.IsMatch(input) && !configuration.ShowCastLot) ||
                    (ChatStrings.RouletteBonusExperiencePoints.All(input.Contains) && !configuration.ShowRouletteBonusExperiencePoints)
                )
                {
                    return true;
                } 
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}