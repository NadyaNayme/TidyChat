using System.Linq;
using TidyStrings = TidyChat.Utility.InternalStrings;
using Dalamud.Game.Text.SeStringHandling;

namespace TidyChat.Utility
{
    internal static class GetDutyName
    {
        public static string FindIn(SeString message, string input)
        {
            if (Localization.Get(ChatStrings.DutyEnded).All(input.Contains))
            {
                //      match here then go back 4 characters to capture everything before " has"
                //           |
                //           v
                // <duty> has ended.
                return message.TextValue[..(message.TextValue.LastIndexOf(" ") - 4)];
            }

            if (Localization.Get(ChatStrings.GuildhestEnded).All(input.Contains))
            {
                return TidyStrings.Guildhest;
            }

            if ((Localization.Get(ChatStrings.GainPvpExp).All(input.Contains) ||
                 Localization.Get(ChatStrings.ObtainWolfMarks).All(input.Contains) ||
                 Localization.Get(ChatStrings.CappedWolfMarks).All(input.Contains))
               )
            {
                return TidyStrings.PvPDuty;
            }

            if (Localization.Get(ChatStrings.PalaceOfTheDead).All(input.Contains))
            {
                return TidyStrings.POTD;
            }

            if (Localization.Get(ChatStrings.HeavenOnHigh).All(input.Contains))
            {
                return TidyStrings.HOH;
            }

            // LastDuty doesn't need to update every message but gets checked on every message
            // so we return the last known value if no new value has been detected.
            return TidyStrings.LastDuty;
        }
    }
}
