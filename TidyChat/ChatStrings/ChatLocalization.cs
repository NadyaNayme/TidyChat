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
                ClientLanguage.English => strings.Eng,
                ClientLanguage.Japanese => strings.Jpn,
                _ => strings.Eng // probably won't work but at least it's not a crash
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
                ClientLanguage.English => regex.Eng,
                ClientLanguage.Japanese => regex.Jpn,
                _ => regex.Eng
            };
        }
    }

    public record struct LocalizedStrings
    {
        public string[] Eng { get; init; }
        /// <remarks>
        /// The string to be matched is preprocessed and always replaces the local player name with "you"
        /// </remarks>
        public string[] Jpn { get; init; }
    }

    public record struct LocalizedRegex
    {
        public Regex Eng { get; init; }
        /// <remarks>
        /// The string to be matched is preprocessed and always replaces the local player name with "you"
        /// </remarks>
        public Regex Jpn { get; init; }
    }
}
