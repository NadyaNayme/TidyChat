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
                    (ChatRegexStrings.ObtainedShards.IsMatch(input) && !configuration.ShowObtainedShards) ||
                    (ChatRegexStrings.OthersRollNeedOrGreed.IsMatch(input) && !configuration.ShowOthersLootRoll) ||
                    (ChatRegexStrings.OthersCastLot.IsMatch(input) && !configuration.ShowOthersCastLot) ||
                    (ChatRegexStrings.OthersObtain.IsMatch(input) && !configuration.ShowOthersObtain)
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
