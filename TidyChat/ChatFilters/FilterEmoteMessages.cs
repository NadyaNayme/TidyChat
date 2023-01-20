using System;
using ChatTwo.Code;
using Dalamud.Logging;

namespace TidyChat;

public static class FilterEmoteMessages
{
    public static bool IsFiltered(string input, ChatType chatType, Configuration configuration)
    {
        try
        {
            if (chatType is ChatType.StandardEmote)
            {
                if (configuration.FilterEmoteSpam && !L10N.Get(ChatRegexStrings.PlayerTargetedEmote).IsMatch(input))
                    return true;
                if (configuration.FilterEmoteSpam && !L10N.Get(ChatRegexStrings.ConsiderEmote).IsMatch(input))
                    return true;
            }
            else if (chatType is ChatType.CustomEmote)
            {
                if (configuration.HideOtherCustomEmotes &&
                    !L10N.Get(ChatRegexStrings.PlayerTargetedEmote).IsMatch(input)) return true;
            }

            return false;
        }
        catch (Exception e)
        {
            PluginLog.LogDebug("Encountered error: " + e);
            return true;
        }
    }
}