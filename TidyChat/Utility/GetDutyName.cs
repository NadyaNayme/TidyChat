using System.Linq;
using Dalamud;
using Dalamud.Game.Text.SeStringHandling;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat.Utility;

internal static class GetDutyName
{
    /// <see href="https://xivapi.com/LogMessage/1534?pretty=true">Duty has neded</see>
    public static string FindIn(SeString message, string input)
    {
        if (L10N.Get(ChatStrings.DutyEnded).All(input.Contains))
            switch (L10N.Language)
            {
                case ClientLanguage.Japanese:
                    //    match here then grab everything up to "」" starting from "「"
                    //         |
                    //         v
                    // 「<duty>」 has ended.
                    return message.TextValue.Substring(message.TextValue.IndexOf("「"),
                        message.TextValue.LastIndexOf("」"));
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
                    return message.TextValue.Substring(message.TextValue.IndexOf("„"),
                        message.TextValue.LastIndexOf("“"));
                case ClientLanguage.French:
                    //              match here then grab everything up to "“" starting from "“"
                    //                   |
                    //                   v
                    // La mission “<duty>” prend fin.
                    return message.TextValue.Substring(message.TextValue.IndexOf("“"),
                        message.TextValue.LastIndexOf("”"));
                default:
                    // This should be unreachable but if we somehow reach it let's keep the last stored duty
                    return L10N.GetTidy(TidyStrings.LastDuty);
            }

        if (L10N.Get(ChatStrings.GuildhestEnded).All(input.Contains)) return L10N.GetTidy(TidyStrings.Guildhest);

        if (L10N.Get(ChatStrings.GainPvpExp).All(input.Contains) ||
            L10N.Get(ChatStrings.ObtainWolfMarks).All(input.Contains) ||
            L10N.Get(ChatStrings.CappedWolfMarks).All(input.Contains)
           )
            return L10N.GetTidy(TidyStrings.PvPDuty);

        if (L10N.Get(ChatStrings.PalaceOfTheDead).All(input.Contains)) return L10N.GetTidy(TidyStrings.POTD);

        if (L10N.Get(ChatStrings.HeavenOnHigh).All(input.Contains)) return L10N.GetTidy(TidyStrings.HOH);

        // LastDuty doesn't need to update every message but gets checked on every message
        // so we return the last known value if no new value has been detected.
        return L10N.GetTidy(TidyStrings.LastDuty);
    }
}