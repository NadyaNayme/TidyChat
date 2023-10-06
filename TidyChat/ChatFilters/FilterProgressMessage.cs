using System;
using System.Linq;

namespace TidyChat;

public sealed class FilterProgressMessages
{
    public static bool IsFiltered(string input, Configuration configuration)
    {
        try
        {
            if (
                (configuration.ShowCompletionTime && L10N.Get(ChatStrings.CompletionTime).All(input.Contains)) ||
                (configuration.ShowGainExperience && L10N.Get(ChatStrings.GainExperiencePoints).All(input.Contains)) ||
                (configuration.ShowGainExperience && L10N.Get(ChatRegexStrings.GainExperiencePoints).IsMatch(input)) ||
                (configuration.ShowGainPvpExp && L10N.Get(ChatStrings.GainPvpExp).All(input.Contains)) ||
                (configuration.ShowEarnAchievement && L10N.Get(ChatStrings.EarnAchievement).All(input.Contains)) ||
                (configuration.ShowOtherEarnedAchievement &&
                 L10N.Get(ChatStrings.OtherEarnAchievement).All(input.Contains)) ||
                (configuration.ShowLevelUps && L10N.Get(ChatStrings.YouAttainLevel).All(input.Contains)) ||
                (configuration.ShowOtherLevelUps && L10N.Get(ChatStrings.OtherAttainsLevel).All(input.Contains)) ||
                (configuration.ShowAbilityUnlocks && L10N.Get(ChatStrings.YouLearnAbility).All(input.Contains)) ||
                (configuration.ShowDesynthesisLevel && L10N.Get(ChatStrings.DesynthesisLevel).All(input.Contains))
            )
                return false;
            return true;
        }
        catch (Exception e)
        {
            TidyChat.Log.Debug("Encountered error: " + e);
            return true;
        }
    }
}