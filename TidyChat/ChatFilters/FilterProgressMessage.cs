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
                     (ChatStrings.EarnAchievement.All(input.Contains) && !configuration.ShowEarnAchievement)
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