using System;
using ChatTwo.Code;

namespace TidyChat
{
    public sealed class FilterEmoteMessages
    {

        public static bool IsFiltered(string input, ChatType chatType, Configuration configuration)
        {
            try
            {
                if (chatType is ChatType.StandardEmote)
                {
                    if (configuration.HideUsedEmotes && Localization.Get(ChatRegexStrings.PlayerUsedEmote).IsMatch(input))
                    {
                        return true;
                    }
                    if (configuration.FilterEmoteSpam && !Localization.Get(ChatRegexStrings.PlayerTargetedEmote).IsMatch(input))
                    {
                        return true;
                    }
                }
                else if (chatType is ChatType.CustomEmote)
                {
                    if (configuration.HideOtherCustomEmotes && !Localization.Get(ChatRegexStrings.PlayerTargetedEmote).IsMatch(input)) {
                        return true;
                    }

                }
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
