using System;
using System.Linq;

namespace TidyChat
{
    public sealed class FilterProgressMessages
    {
        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
                if (
                     (ChatStrings.GainExperiencePoints.All(input.Contains) && !configuration.ShowGainExperience) ||
                     (ChatRegexStrings.GainExperiencePoints.IsMatch(input) && !configuration.ShowGainExperience) ||
                     (ChatStrings.GainPvpExp.All(input.Contains) && !configuration.ShowGainPvpExp) ||
                     (ChatStrings.EarnAchievement.All(input.Contains) && !configuration.ShowEarnAchievement) ||
                     (ChatStrings.YouAttainLevel.All(input.Contains) && !configuration.ShowLevelUps) ||
                     (ChatStrings.OtherAttainsLevel.All(input.Contains) && !configuration.ShowOtherLevelUps) ||
                     (ChatStrings.YouLearnAbility.All(input.Contains) && !configuration.ShowAbilityUnlocks)
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
