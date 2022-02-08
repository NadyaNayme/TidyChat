using System;
using ChatTwo.Code;

namespace TidyChat
{
    public sealed class FilterLootMessages
    {
        public static bool IsFiltered(string input, Configuration configuration)
        {
            try
            {
                if (!configuration.ShowLootRoll && ChatRegexStrings.RollsNeedOrGreed.IsMatch(input))
                {
                    return true;
                }
                if (!configuration.ShowCastLot && ChatRegexStrings.CastLot.IsMatch(input))
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