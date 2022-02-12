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
                    (ChatRegexStrings.ObtainedShards.IsMatch(input) && !configuration.ShowObtainedShards)
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
