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
                    !configuration.ShowLootRoll && Localization.Get(ChatRegexStrings.RollsNeedOrGreed).IsMatch(input) ||
                    !configuration.ShowCastLot && Localization.Get(ChatRegexStrings.CastLot).IsMatch(input) ||
                    !configuration.ShowObtainedShards && Localization.Get(ChatRegexStrings.ObtainedShards).IsMatch(input) ||
                    !configuration.ShowOthersLootRoll && Localization.Get(ChatRegexStrings.OthersRollNeedOrGreed).IsMatch(input) ||
                    !configuration.ShowOthersCastLot && Localization.Get(ChatRegexStrings.OthersCastLot).IsMatch(input) ||
                    !configuration.ShowOthersObtain && Localization.Get(ChatRegexStrings.OthersObtain).IsMatch(input)
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
