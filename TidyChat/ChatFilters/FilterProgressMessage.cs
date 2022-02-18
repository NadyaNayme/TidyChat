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
                     !configuration.ShowGainExperience && Localization.Get(ChatStrings.GainExperiencePoints).All(input.Contains) ||
                     !configuration.ShowGainExperience && Localization.Get(ChatRegexStrings.GainExperiencePoints).IsMatch(input) ||
                     !configuration.ShowGainPvpExp && Localization.Get(ChatStrings.GainPvpExp).All(input.Contains) ||
                     !configuration.ShowEarnAchievement && Localization.Get(ChatStrings.EarnAchievement).All(input.Contains) ||
                     !configuration.ShowLevelUps && Localization.Get(ChatStrings.YouAttainLevel).All(input.Contains) ||
                     !configuration.ShowOtherLevelUps && Localization.Get(ChatStrings.OtherAttainsLevel).All(input.Contains) ||
                     !configuration.ShowAbilityUnlocks && Localization.Get(ChatStrings.YouLearnAbility).All(input.Contains)
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
