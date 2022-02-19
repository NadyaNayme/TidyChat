using System;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using ChatTwo.Code;

namespace TidyChat
{
    public sealed class FilterEmoteMessages
    {

        public static bool IsFiltered(string input, ChatType chatType,Configuration configuration)
        {
            try
            {
                if (chatType is ChatType.StandardEmote)
                {
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
