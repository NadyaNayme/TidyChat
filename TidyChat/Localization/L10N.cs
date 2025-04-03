﻿using System.Text.RegularExpressions;
using Dalamud.Game;
using Dalamud.IoC;
using Dalamud.Plugin.Services;
using TidyChat.Translation.Data;

namespace TidyChat;

internal static class L10N
{
    public static ClientLanguage Language { get; set; }
    [PluginService] public static IPluginLog PluginLog { get; private set; } = null!;

    public static string[] Get(string[] strings)
    {
#if DEBUG
            PluginLog.Debug("Strings not localized: %s", string.Join(",", strings));
#endif
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
#if DEBUG
            PluginLog.Debug("Regex not localized: %s", regex.ToString());
#endif
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
#if DEBUG
            PluginLog.Debug("Internal strings not localized: %s", strings.ToString());
#endif
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