using Dalamud;
using Dalamud.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TidyChat
{
    internal static class Localization
    {
        public static ClientLanguage language { get; set; }

        public static string[] Get(string[] strings)
        {
            // PluginLog.LogDebug("Strings not localized: %s", string.Join(",", strings));
            return strings;
        }

        public static string[] Get(LocalizedStrings strings)
        {
            return language switch
            {
                ClientLanguage.Japanese => strings.Jpn,
                ClientLanguage.English => strings.Eng,
                ClientLanguage.German => strings.Deu,
                ClientLanguage.French => strings.Fra,
                _ => strings.Eng // Won't work for J/F/D but at least it's not a crash
            };
        }

        public static Regex Get(Regex regex)
        {
            // PluginLog.LogDebug("Regex not localized: %s", regex.ToString());
            return regex;
        }

        public static Regex Get(LocalizedRegex regex)
        {
            return language switch
            {
                ClientLanguage.Japanese => regex.Jpn,
                ClientLanguage.English => regex.Eng,
                ClientLanguage.German => regex.Deu,
                ClientLanguage.French => regex.Fra,
                _ => regex.Eng
            };
        }
    }

    public record struct LocalizedStrings
    {
        /// <remarks>
        /// The string to be matched is preprocessed and always replaces the local player name with "you"
        /// </remarks>
        public string[] Jpn { get; init; }
        public string[] Eng { get; init; }
        public string[] Deu { get; init; }
        public string[] Fra { get; init; }
    }

    public record struct LocalizedRegex
    {
        /// <remarks>
        /// The string to be matched is preprocessed and always replaces the local player name with "you"
        /// </remarks>
        public Regex Jpn { get; init; }
        public Regex Eng { get; init; }
        public Regex Deu { get; init; }
        public Regex Fra { get; init; }
    }
}
