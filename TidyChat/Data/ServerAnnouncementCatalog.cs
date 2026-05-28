using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Dalamud.Game;
using Dalamud.Plugin.Services;
using Lumina.Excel.Sheets;
using Lumina.Text.ReadOnly;
namespace TidyChat.Data;

/// <summary>
///     Matches login and world-travel server announcement chat (#122).
///     Text is server-pushed and mostly absent from LogMessage; uses curated per-language markers
///     plus fragments from Lumina Lobby and Addon rows.
/// </summary>
public static class ServerAnnouncementCatalog
{
    private const int MinDiscoveredTokenLength = 8;

    private const RegexOptions CompiledRegexOptions =
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

    private static readonly TimeSpan RegexTimeout = TimeSpan.FromSeconds(1);

    private static readonly HashSet<string> DiscoveredAnnouncementTokens = new(StringComparer.OrdinalIgnoreCase);
    private static readonly HashSet<string> DiscoveredPhishingTokens = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    ///     Common gameplay words scraped from sqex.to templates; substring hits here caused false blocks.
    /// </summary>
    private static readonly HashSet<string> DiscoveredTokenDenylist = new(StringComparer.OrdinalIgnoreCase)
    {
        "sanctuary", "instanced", "inventory", "registration", "withdrawn", "interrupted", "projected",
        "glamours", "materials", "selected", "following", "submersible", "subaquatic", "exploration",
        "finalized", "aetherpool", "flickers", "gearsets", "updated", "submarine", "venture", "assign",
        "retainer", "request", "friend", "unable", "craft", "added", "entered", "strength", "begins",
        "report", "plate", "stylist", "tracker", "active", "quick", "return", "cairn", "glow",
        "selling", "markets"
    };

    private static readonly Regex EnglishWorldGreeting =
        new(@"^welcome to .+!$", CompiledRegexOptions, RegexTimeout);

    private static readonly Regex GermanWorldGreeting =
        new(@"^(willkommen (auf|in|bei|zur) .+|welcome to .+)!$", CompiledRegexOptions, RegexTimeout);

    private static readonly Regex FrenchWorldGreeting =
        new(@"^(bienvenue (sur|à|au|a|dans) .+|welcome to .+)!$", CompiledRegexOptions, RegexTimeout);

    private static readonly Regex JapaneseWorldGreeting =
        new(@"^(.+へようこそ！?|welcome to .+!)$", CompiledRegexOptions, RegexTimeout);

    private static readonly Regex FormatNoiseRegex =
        new(@"[^\p{L}\p{N}\s']+", CompiledRegexOptions, RegexTimeout);

    private static readonly Regex EnglishPhishingHeader =
        new(@"\bbe\s+wary\s+of\s+phishing\b", CompiledRegexOptions, RegexTimeout);

    private static readonly Regex EnglishPhishingBody =
        new(@"\breceive\s+a\s+tell\s+containing\s+a\s+url\b", CompiledRegexOptions, RegexTimeout);

    /// <summary>
    ///     Phishing-warning vocabulary when Lumina Lobby or Addon rows omit the strings (#24).
    /// </summary>
    private static readonly string[] HardcodedPhishingTokens =
    [
        "phishing",
        "phishingversuchen",
        "hameçonnage",
        "フィッシング"
    ];

    public static bool IsLoaded { get; private set; }

    public static int DiscoveredTokenCount => DiscoveredAnnouncementTokens.Count + DiscoveredPhishingTokens.Count;

    public static void Load(IDataManager dataManager, IPluginLog log)
    {
        DiscoveredAnnouncementTokens.Clear();
        DiscoveredPhishingTokens.Clear();
        IsLoaded = false;

        try
        {
            ScanLobbySheet(dataManager.GetExcelSheet<Lobby>(), log);
            ScanAddonSheet(dataManager.GetExcelSheet<Addon>(), log);
            ScanLogMessageSheet(dataManager.GetExcelSheet<LogMessage>(), log);
            AddHardcodedPhishingFallbacks();
            IsLoaded = true;
            if (DiscoveredTokenCount > 0)
            {
                log.Information(
                    $"ServerAnnouncementCatalog: loaded {DiscoveredAnnouncementTokens.Count} announcement and " +
                    $"{DiscoveredPhishingTokens.Count} phishing fragment(s) from Lumina.");
            }
        }
        catch(Exception ex)
        {
            log.Error("ServerAnnouncementCatalog: failed to load: " + ex);
        }
    }

    public static bool IsWorldGreeting(string normalizedText)
    {
        if (string.IsNullOrWhiteSpace(normalizedText)) return false;

        Regex pattern = L10N.Language switch
        {
            ClientLanguage.German => GermanWorldGreeting,
            ClientLanguage.French => FrenchWorldGreeting,
            ClientLanguage.Japanese => JapaneseWorldGreeting,
            _ => EnglishWorldGreeting
        };

        if (pattern.IsMatch(normalizedText)) return true;

        // Some clients still print the English world line.
        return L10N.Language is not ClientLanguage.English && EnglishWorldGreeting.IsMatch(normalizedText);
    }

    public static bool IsAnnouncement(string normalizedText)
    {
        if (string.IsNullOrWhiteSpace(normalizedText)) return false;
        if (IsWorldGreeting(normalizedText)) return true;
        if (IsPhishingWarning(normalizedText)) return true;
        if (normalizedText.Contains("sqex.to", StringComparison.OrdinalIgnoreCase)) return true;

        if (ContainsAnyMarker(normalizedText, L10N.Get(ChatStrings.ServerAnnouncementMarkers))) return true;
        return ContainsAnyDiscovered(normalizedText, DiscoveredAnnouncementTokens);
    }

    public static bool IsPhishingWarning(string normalizedText)
    {
        if (string.IsNullOrWhiteSpace(normalizedText)) return false;

        string stripped = StripFormatNoise(normalizedText);
        if (MatchesPhishingPatterns(stripped)) return true;
        if (ContainsAnyMarker(stripped, L10N.Get(ChatStrings.ServerPhishingMarkers))) return true;
        return ContainsAnyDiscovered(stripped, DiscoveredPhishingTokens);
    }

    private static bool MatchesPhishingPatterns(string normalizedText) =>
        EnglishPhishingHeader.IsMatch(normalizedText) || EnglishPhishingBody.IsMatch(normalizedText);

    private static string StripFormatNoise(string normalizedText) =>
        FormatNoiseRegex.Replace(normalizedText, " ");

    private static bool ContainsAnyMarker(string normalizedText, string[] markers)
    {
        foreach(string marker in markers)
        {
            if (marker.Contains(' ', StringComparison.Ordinal))
            {
                if (normalizedText.Contains(marker, StringComparison.OrdinalIgnoreCase)) return true;
            }
            else if (ContainsTokenAsWord(normalizedText, marker))
            {
                return true;
            }
        }

        return false;
    }

    private static bool ContainsAnyDiscovered(string normalizedText, IEnumerable<string> tokens)
    {
        foreach(string token in tokens)
        {
            if (DiscoveredTokenDenylist.Contains(token)) continue;
            if (ContainsTokenAsWord(normalizedText, token)) return true;
        }

        return false;
    }

    private static bool ContainsTokenAsWord(string normalizedText, string token)
    {
        if (string.IsNullOrEmpty(token)) return false;

        int index = 0;
        while((index = normalizedText.IndexOf(token, index, StringComparison.OrdinalIgnoreCase)) >= 0)
        {
            bool startOk = index == 0 || !IsWordChar(normalizedText[index - 1]);
            int endIndex = index + token.Length;
            bool endOk = endIndex >= normalizedText.Length || !IsWordChar(normalizedText[endIndex]);
            if (startOk && endOk) return true;
            index++;
        }

        return false;
    }

    private static bool IsWordChar(char c) => char.IsLetterOrDigit(c) || c is '_' or '\'';

    private static void ScanLobbySheet(IEnumerable<Lobby>? rows, IPluginLog log)
    {
        if (rows is null)
        {
            log.Warning("ServerAnnouncementCatalog: Lumina sheet 'Lobby' was not available.");
            return;
        }

        foreach(Lobby row in rows)
        {
            ReadOnlySeString template = row.Text;
            ScanTemplateText(template.ExtractText());
        }
    }

    private static void ScanAddonSheet(IEnumerable<Addon>? rows, IPluginLog log)
    {
        if (rows is null)
        {
            log.Warning("ServerAnnouncementCatalog: Lumina sheet 'Addon' was not available.");
            return;
        }

        foreach(Addon row in rows)
        {
            ReadOnlySeString template = row.Text;
            ScanTemplateText(template.ExtractText());
        }
    }

    private static void ScanLogMessageSheet(IEnumerable<LogMessage>? rows, IPluginLog log)
    {
        if (rows is null)
        {
            log.Warning("ServerAnnouncementCatalog: Lumina sheet 'LogMessage' was not available.");
            return;
        }

        foreach(LogMessage row in rows)
        {
            ReadOnlySeString template = row.Text;
            ScanTemplateText(template.ExtractText());
        }
    }

    private static void AddHardcodedPhishingFallbacks()
    {
        foreach(string token in HardcodedPhishingTokens)
            DiscoveredPhishingTokens.Add(token);
    }

    private static void ScanTemplateText(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return;

        string lower = text.ToLowerInvariant();
        if (lower.Contains("sqex.to", StringComparison.Ordinal))
            AddDiscoveredTokens(text, DiscoveredAnnouncementTokens);

        if (IsPhishingSeed(lower))
            AddDiscoveredTokens(text, DiscoveredPhishingTokens);
    }

    private static bool IsPhishingSeed(string lower) =>
        lower.Contains("phishing", StringComparison.Ordinal) ||
        lower.Contains("hameçonn", StringComparison.Ordinal) ||
        lower.Contains("フィッシング", StringComparison.Ordinal) ||
        (lower.Contains("tell", StringComparison.Ordinal) && lower.Contains("url", StringComparison.Ordinal));

    private static void AddDiscoveredTokens(string templateText, HashSet<string> target)
    {
        foreach(string token in LogMessageTokenExtractor.Extract(templateText))
        {
            if (token.Length < MinDiscoveredTokenLength) continue;
            if (DiscoveredTokenDenylist.Contains(token)) continue;
            target.Add(token);
        }
    }
}
