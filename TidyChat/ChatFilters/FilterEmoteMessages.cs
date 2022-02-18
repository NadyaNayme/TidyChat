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
                // ToDo: Find way to detect when the player is <t> in a Custom Emote so that CustomEmote can be blocked unless <t>
                else if (chatType is ChatType.CustomEmote)
                {
                    return false;
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
