using System;

namespace TidyChat;

public static class FilterLootMessages
{
    public static bool IsFiltered(string input, Configuration configuration)
    {
        try
        {
            if (
                (!configuration.ShowLootRoll && L10N.Get(ChatRegexStrings.RollsNeedOrGreed).IsMatch(input)) ||
                (!configuration.ShowCastLot && L10N.Get(ChatRegexStrings.CastLot).IsMatch(input)) ||
                (!configuration.ShowObtainedShards && L10N.Get(ChatRegexStrings.ObtainedShards).IsMatch(input)) ||
                /* TODO: #1
                 * Benchmark zero-width negative lookbehind against StartsWith()
                 * I'm like 99% certain StartsWith will be faster
                 *
                 * TODO: #2
                 * Double check if this is even necessary to avoid false positives with your own Loot/Cast rolls
                 * The goal is to not show "You cast your lot" while still showing "Other Player" casts their lot
                 * when the user has changed the chat log from the Full Name setting to an initialized setting
                 * and has not enabled showing their own loot/cast rolls but has enabled showing others' loot/cast rols.
                 *
                 * The && !(input.StartsWith("you")) is done as an alternative to using ^((?!you).).* in each Regex
                 */
                (!configuration.ShowOthersLootRoll && !input.StartsWith("you") &&
                 L10N.Get(ChatRegexStrings.OthersRollNeedOrGreed).IsMatch(input)) ||
                (!configuration.ShowOthersCastLot && !input.StartsWith("you") &&
                 L10N.Get(ChatRegexStrings.OthersCastLot).IsMatch(input)) ||
                (!configuration.ShowOthersObtain && !input.StartsWith("you") &&
                 L10N.Get(ChatRegexStrings.OtherObtains).IsMatch(input))
            )
                return true;
            return false;
        }
        catch (Exception e)
        {
            TidyChat.Log.Debug("Encountered error: " + e);
            return false;
        }
    }
}