using Dalamud;
using Dalamud.Logging;
using System.Text.RegularExpressions;

namespace TidyChat
{
    internal static class Localization
    {
        public static ClientLanguage Language { get; set; }

        public static string[] Get(string[] strings)
        {
            // PluginLog.LogDebug("Strings not localized: %s", string.Join(",", strings));
            return strings;
        }

        public static string[] Get(LocalizedStrings strings)
        {
            return Language switch
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
            return Language switch
            {
                ClientLanguage.Japanese => regex.Jpn,
                ClientLanguage.English => regex.Eng,
                ClientLanguage.German => regex.Deu,
                ClientLanguage.French => regex.Fra,
                _ => regex.Eng // Won't work for J/F/D but at least it's not a crash
            };
        }

        public static string GetTidy(string strings)
        {
            // PluginLog.LogDebug("Internal strings not localized: %s", strings.ToString());
            return strings;
        }

        public static string GetTidy(LocalizedTidyStrings strings)
        {
            return Language switch
            {
                ClientLanguage.Japanese => strings.Jpn,
                ClientLanguage.English => strings.Eng,
                ClientLanguage.German => strings.Deu,
                ClientLanguage.French => strings.Fra,
                _ => strings.Eng // Won't work for J/F/D but at least it's not a crash
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

    public record struct LocalizedTidyStrings
    {
        /// <remarks>
        /// For use with Utility.InternalStrings and Utility.BetterStrings
        /// </remarks>
        public string Jpn { get; init; }
        public string Eng { get; init; }
        public string Deu { get; init; }
        public string Fra { get; init; }
    }
}
