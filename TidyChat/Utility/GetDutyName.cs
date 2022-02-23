using System.Linq;
using TidyStrings = TidyChat.Utility.InternalStrings;
using Dalamud;
using Dalamud.Game.Text.SeStringHandling;

namespace TidyChat.Utility
{
    internal static class GetDutyName
    {
        /// <see href= "https://xivapi.com/LogMessage/1534?pretty=true">Duty has neded</see>
        public static string FindIn(SeString message, string input)
        {
            if (Localization.Get(ChatStrings.DutyEnded).All(input.Contains))
            {
                switch (Localization.Language)
                {
                    case ClientLanguage.Japanese:
                        //    match here then grab everything up to "」" starting from "「"
                        //         |
                        //         v
                        // 「<duty>」 has ended.
                        return message.TextValue.Substring(message.TextValue.IndexOf("「"), message.TextValue.LastIndexOf("」"));
                    case ClientLanguage.English:
                        //      match here then go back 4 characters to capture everything before " has"
                        //           |
                        //           v
                        // <duty> has ended.
                        return message.TextValue[..(message.TextValue.LastIndexOf(" ") - 4)];
                    case ClientLanguage.German:
                        //   match here then grab everything up to "“" starting from "„"
                        //        |
                        //        v
                        // „<duty>“ wurde beendet.
                        return message.TextValue.Substring(message.TextValue.IndexOf("„"), message.TextValue.LastIndexOf("“"));
                    case ClientLanguage.French:
                        //              match here then grab everything up to "“" starting from "“"
                        //                   |
                        //                   v
                        // La mission “<duty>” prend fin.
                        return message.TextValue.Substring(message.TextValue.IndexOf("“"), message.TextValue.LastIndexOf("”"));
                    default:
                        // This should be unreachable but if we somehow reach it let's keep the last stored duty
                        return Localization.GetTidy(TidyStrings.LastDuty);
                }
            }

            if (Localization.Get(ChatStrings.GuildhestEnded).All(input.Contains))
            {
                return Localization.GetTidy(TidyStrings.Guildhest);
            }

            if ((Localization.Get(ChatStrings.GainPvpExp).All(input.Contains) ||
                 Localization.Get(ChatStrings.ObtainWolfMarks).All(input.Contains) ||
                 Localization.Get(ChatStrings.CappedWolfMarks).All(input.Contains))
               )
            {
                return Localization.GetTidy(TidyStrings.PvPDuty);
            }

            if (Localization.Get(ChatStrings.PalaceOfTheDead).All(input.Contains))
            {
                return Localization.GetTidy(TidyStrings.POTD);
            }

            if (Localization.Get(ChatStrings.HeavenOnHigh).All(input.Contains))
            {
                return Localization.GetTidy(TidyStrings.HOH);
            }

            // LastDuty doesn't need to update every message but gets checked on every message
            // so we return the last known value if no new value has been detected.
            return Localization.GetTidy(TidyStrings.LastDuty);
        }
    }
}
