using System;
using System.Collections.Generic;
using System.Linq;
using Dalamud.Plugin.Services;
using Lumina.Excel.Sheets;
using Lumina.Text.ReadOnly;
using TidyChat.Translation.Data;
namespace TidyChat.Data;

/// <summary>
///     Loads the LogMessage sheet from Lumina and builds match tokens for chat filtering.
///     Templates follow the active client language; pair with <see cref="ChatStrings" /> fallbacks when needed.
/// </summary>
public static class LogMessageCatalog
{

    /// <summary>
    ///     Shared "You obtain …" templates for currency marker hide rules (657 family). Excludes 1606 (dedicated item
    ///     obtain).
    /// </summary>
    public static readonly uint[] SharedObtainTemplateIds = [657, 1259];

    private static readonly Dictionary<uint, string[]> WordTokensById = new();
    private static readonly Dictionary<uint, string> TemplateTextById = new();

    /// <summary>LogMessage IDs that fire in-game but are absent from the Lumina sheet.</summary>
    private static readonly HashSet<uint> RuntimeOnlyIds =
    [
        94, 549,
        4671,
        10766, 10769, 10770, 10771, 10779, 10815, 10822, 10872, 10873, 10874, 10875, 10877, 10878, 10879, 10883,
        10830, 10946, 11156, 11175, 11197, 11331, 11379, 11383
    ];
    private static readonly string[] CompactLinePrefixes =
    [
        "Novice - ",
        "Beginner - ",
        "(NEULINGE) ",
        "(RdN) "
    ];

    public static bool IsLoaded { get; private set; }

    public static void Load(IDataManager dataManager, IPluginLog log)
    {
        WordTokensById.Clear();
        TemplateTextById.Clear();
        IsLoaded = false;

        try
        {
            foreach(LogMessage row in dataManager.GetExcelSheet<LogMessage>())
            {
                ReadOnlySeString template = row.Text;
                string text = template.ExtractText().Trim();
                if (string.IsNullOrWhiteSpace(text)) continue;

                TemplateTextById[row.RowId] = text;

                string[] tokens = LogMessageTokenExtractor.Extract(text);
                if (tokens.Length > 0)
                    WordTokensById[row.RowId] = tokens;
            }

            IsLoaded = true;
            log.Information(
                $"LogMessageCatalog: loaded {TemplateTextById.Count} LogMessage templates " +
                $"({WordTokensById.Count} with match tokens) from Lumina.");
        }
        catch(Exception ex)
        {
            log.Error("LogMessageCatalog: failed to load LogMessage sheet: " + ex);
        }
    }

    public static bool HasTokens(uint logMessageId) =>
        WordTokensById.ContainsKey(logMessageId) ||
        (TemplateTextById.TryGetValue(logMessageId, out string? template) &&
         LogMessageTokenExtractor.Extract(template).Length > 0);

    public static bool HasTemplate(uint logMessageId) => TemplateTextById.ContainsKey(logMessageId);

    /// <summary>First template line with common Novice Network prefixes stripped.</summary>
    public static bool TryGetCompactLine(uint logMessageId, out string line)
    {
        line = string.Empty;
        if (!TemplateTextById.TryGetValue(logMessageId, out string? template)) return false;

        string firstLine = template.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)[0];
        foreach(string prefix in CompactLinePrefixes)
        {
            if (firstLine.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                firstLine = firstLine[prefix.Length..].TrimStart();
                break;
            }
        }

        if (string.IsNullOrWhiteSpace(firstLine)) return false;
        line = firstLine;
        return true;
    }

    /// <summary>True when every derived token appears in <paramref name="normalizedText" />.</summary>
    public static bool Matches(uint logMessageId, string normalizedText)
    {
        if (!WordTokensById.TryGetValue(logMessageId, out string[]? tokens) &&
            TemplateTextById.TryGetValue(logMessageId, out string? template))
        {
            tokens = LogMessageTokenExtractor.Extract(template);
        }

        if (tokens is null || tokens.Length == 0) return false;
        return tokens.All(normalizedText.Contains);
    }

    public static bool MatchesAny(IEnumerable<uint> logMessageIds, string normalizedText)
    {
        foreach(uint id in logMessageIds)
        {
            if (Matches(id, normalizedText)) return true;
        }
        return false;
    }

    /// <summary>
    ///     Match shared obtain templates (657 family) plus an item or currency marker.
    /// </summary>
    public static bool MatchesSharedObtain(string normalizedText, uint markerItemId, LocalizedStrings? markerFallback = null)
    {
        if (!MatchesAny(SharedObtainTemplateIds, normalizedText)) return false;
        return ItemMarkerCatalog.Matches(markerItemId, normalizedText, markerFallback);
    }

    /// <summary>GC seal obtain on a shared template, via any of the three seal item markers.</summary>
    public static bool MatchesSharedObtainSeal(string normalizedText, LocalizedStrings? markerFallback = null)
    {
        if (!MatchesAny(SharedObtainTemplateIds, normalizedText)) return false;
        return ItemMarkerCatalog.MatchesAnySeal(normalizedText, markerFallback);
    }

    /// <summary>Shared obtain template plus gil marker text in the message.</summary>
    public static bool MatchesSharedObtainGil(string normalizedText, LocalizedStrings? markerFallback = null)
    {
        if (!MatchesAny(SharedObtainTemplateIds, normalizedText)) return false;
        if (markerFallback is { } fb) return L10N.Get(fb).All(normalizedText.Contains);
        return normalizedText.Contains("gil", StringComparison.Ordinal);
    }

    /// <summary>Shared obtain template plus MGP marker text in the message.</summary>
    public static bool MatchesSharedObtainMgp(string normalizedText, LocalizedStrings? markerFallback = null)
    {
        if (!MatchesAny(SharedObtainTemplateIds, normalizedText)) return false;
        if (markerFallback is { } fb) return L10N.Get(fb).All(normalizedText.Contains);
        return normalizedText.Contains("mgp", StringComparison.Ordinal);
    }

    /// <summary>Shared obtain template plus an elemental shard, crystal, or cluster marker.</summary>
    public static bool MatchesSharedObtainElemental(string normalizedText, bool clustersOnly, LocalizedStrings? markerFallback = null,
        bool requireSharedTemplate = true)
    {
        if (requireSharedTemplate && !MatchesAny(SharedObtainTemplateIds, normalizedText)) return false;
        uint[] itemIds = clustersOnly ? ItemMarkerCatalog.Items.ElementalClusters : ItemMarkerCatalog.Items.ElementalAll;
        return ItemMarkerCatalog.MatchesAny(itemIds, normalizedText, markerFallback);
    }

    /// <summary>Shared obtain template plus a beast tribe currency marker.</summary>
    public static bool MatchesSharedObtainTribal(string normalizedText, LocalizedStrings? markerFallback = null)
    {
        if (!MatchesAny(SharedObtainTemplateIds, normalizedText)) return false;
        return ItemMarkerCatalog.MatchesAny(ItemMarkerCatalog.Items.TribalCurrency, normalizedText, markerFallback);
    }

    /// <summary>Obtain line ending in a materials suffix (e.g. "You obtain 5 foo materials.").</summary>
    public static bool MatchesMaterialsObtain(string normalizedText, LocalizedStrings? markerFallback = null,
        bool requireSharedTemplate = true)
    {
        if (markerFallback is { } fb)
        {
            if (!L10N.Get(fb).All(normalizedText.Contains)) return false;
        }
        else if (!normalizedText.Contains("materials", StringComparison.Ordinal))
        {
            return false;
        }

        if (requireSharedTemplate) return MatchesAny(SharedObtainTemplateIds, normalizedText);
        return normalizedText.Contains("you obtain", StringComparison.Ordinal) ||
               normalizedText.Contains("you obtains", StringComparison.Ordinal);
    }

    /// <summary>Local-player obtain after name normalization ("you …").</summary>
    public static bool IsPlayerObtainMessage(string normalizedText) =>
        normalizedText.StartsWith("you ", StringComparison.Ordinal);

    /// <summary>Another player's obtain line; skips local player and checks obtain verb markers.</summary>
    public static bool MatchesOtherPlayerObtain(string normalizedText, LocalizedStrings? markerFallback = null)
    {
        if (IsPlayerObtainMessage(normalizedText)) return false;

        if (markerFallback is { } fb)
        {
            foreach(string token in L10N.Get(fb))
            {
                if (normalizedText.Contains(token, StringComparison.Ordinal)) return true;
            }
            return false;
        }

        return normalizedText.Contains(" obtains ", StringComparison.Ordinal);
    }

    /// <summary>Try Lumina tokens first; fall back to hardcoded localized fragments.</summary>
    public static bool MatchesWithFallback(uint logMessageId, string normalizedText, LocalizedStrings fallback)
    {
        if (HasTokens(logMessageId) && Matches(logMessageId, normalizedText)) return true;
        return L10N.Get(fallback).All(normalizedText.Contains);
    }

    /// <summary>Warn when rule IDs are missing from the loaded sheet (patch drift).</summary>
    public static void ValidateRuleIds(IEnumerable<uint> referencedIds, IPluginLog log)
    {
        if (!IsLoaded) return;

        var missing = new List<uint>();
        var seen = new HashSet<uint>();
        foreach(uint id in referencedIds)
        {
            if (!seen.Add(id)) continue;
            if (!TemplateTextById.ContainsKey(id) && !RuntimeOnlyIds.Contains(id)) missing.Add(id);
        }

        if (missing.Count == 0) return;

        missing.Sort();
        log.Warning(
            $"LogMessageCatalog: {missing.Count} rule LogMessage ID(s) not found in the Lumina sheet " +
            $"(game patch drift or retired messages): {string.Join(", ", missing)}");
    }
}
