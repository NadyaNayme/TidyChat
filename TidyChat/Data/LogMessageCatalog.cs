using Dalamud.Plugin.Services;
using Lumina.Excel.Sheets;
using TidyChat.Localization.Data;
namespace TidyChat.Data;

public static class LogMessageCatalog
{

    public static readonly uint[] SharedObtainTemplateIds = [657, 1259];

    private static readonly Dictionary<uint, string[]> WordTokensById = new();
    private static readonly Dictionary<uint, string> TemplateTextById = new();
    private static readonly Dictionary<uint, byte> LogKindById = new();

    private static readonly HashSet<uint> RuntimeOnlyIds =
    [
        94, 549, 1168,
        4671,
        10766, 10769, 10770, 10771, 10779, 10781, 10790, 10815, 10822, 10872, 10873, 10874, 10875, 10877, 10878, 10879, 10883,
        10830, 10946, 11156, 11174, 11175, 11197, 11331, 11379, 11383
    ];
    private static readonly string[] CompactLinePrefixes =
    [
        "Novice - ",
        "Beginner - ",
        "(NEULINGE) ",
        "(RdN) "
    ];

    public static bool IsLoaded { get; private set; }

    internal static void LoadForTests(IReadOnlyDictionary<uint, string> templates, byte logKind = 57)
    {
        WordTokensById.Clear();
        TemplateTextById.Clear();
        LogKindById.Clear();
        IsLoaded = false;

        foreach (var (id, text) in templates)
        {
            LogKindById[id] = logKind;
            TemplateTextById[id] = text;
            var tokens = LogMessageTokenExtractor.Extract(text);
            if (tokens.Length > 0)
            {
                WordTokensById[id] = tokens;
            }
        }

        IsLoaded = templates.Count > 0;
    }

    public static void Load(IDataManager dataManager, IPluginLog log)
    {
        WordTokensById.Clear();
        TemplateTextById.Clear();
        LogKindById.Clear();
        IsLoaded = false;

        try
        {
            foreach (var row in dataManager.GetExcelSheet<LogMessage>())
            {
                LogKindById[row.RowId] = (byte)row.LogKind.RowId;

                var template = row.Text;
                var text = template.ExtractText().Trim();
                if (string.IsNullOrWhiteSpace(text))
                {
                    continue;
                }

                TemplateTextById[row.RowId] = text;

                var tokens = LogMessageTokenExtractor.Extract(text);
                if (tokens.Length > 0)
                {
                    WordTokensById[row.RowId] = tokens;
                }
            }

            IsLoaded = true;
            log.Information(
                $"LogMessageCatalog: loaded {TemplateTextById.Count} LogMessage templates " +
                $"({WordTokensById.Count} with match tokens) from Lumina.");
        }
        catch (Exception ex)
        {
            log.Error("LogMessageCatalog: failed to load LogMessage sheet: " + ex);
        }
    }

    public static bool HasTokens(uint logMessageId) =>
        WordTokensById.ContainsKey(logMessageId) ||
        (TemplateTextById.TryGetValue(logMessageId, out var template) &&
         LogMessageTokenExtractor.Extract(template).Length > 0);

    public static bool HasTemplate(uint logMessageId) => TemplateTextById.ContainsKey(logMessageId);

    public static bool IsRuntimeOnly(uint logMessageId) => RuntimeOnlyIds.Contains(logMessageId);

    public static bool TryGetTemplateText(uint logMessageId, out string templateText) =>
        TemplateTextById.TryGetValue(logMessageId, out templateText!);

    public static bool TryGetCompactLine(uint logMessageId, out string line)
    {
        line = string.Empty;
        if (!TemplateTextById.TryGetValue(logMessageId, out var template))
        {
            return false;
        }

        var firstLine = template.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)[0];
        foreach (var prefix in CompactLinePrefixes)
        {
            if (firstLine.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                firstLine = firstLine[prefix.Length..].TrimStart();
                break;
            }
        }

        if (string.IsNullOrWhiteSpace(firstLine))
        {
            return false;
        }
        line = firstLine;
        return true;
    }

    public static bool Matches(uint logMessageId, string normalizedText)
    {
        if (!WordTokensById.TryGetValue(logMessageId, out var tokens) &&
            TemplateTextById.TryGetValue(logMessageId, out var template))
        {
            tokens = LogMessageTokenExtractor.Extract(template);
        }

        if (tokens is null || tokens.Length == 0)
        {
            return false;
        }

        if (!tokens.All(normalizedText.Contains))
        {
            return false;
        }

        return !ObtainCurrencyHelper.TemplateMissingDedicatedObtainMarkers(normalizedText, tokens);
    }

    public static bool MatchesAny(IEnumerable<uint> logMessageIds, string normalizedText)
    {
        foreach (var id in logMessageIds)
        {
            if (Matches(id, normalizedText))
            {
                return true;
            }
        }
        return false;
    }

    public static ChatType? GetChatTypeForId(uint logMessageId)
    {
        if (!LogKindById.TryGetValue(logMessageId, out var logKind))
        {
            return null;
        }
        return (ChatType)logKind;
    }

    public static bool RuleAppliesOnChannel(LocalizedFilterRule rule, ChatType chatType, string normalizedText)
    {
        if (chatType == rule.Channel || chatType is ChatType.Echo)
        {
            return true;
        }
        if (rule.LogMessageIds is not { Length: > 0 })
        {
            return false;
        }

        foreach (var id in rule.LogMessageIds)
        {
            if (GetChatTypeForId(id) is not ChatType idChannel || idChannel != chatType)
            {
                continue;
            }
            if (Matches(id, normalizedText))
            {
                return true;
            }
        }

        return false;
    }

    public static bool MatchesSharedObtain(string normalizedText, uint markerItemId, LocalizedStrings? markerFallback = null)
    {
        if (ItemMarkerCatalog.Matches(markerItemId, normalizedText, markerFallback) &&
            ContainsObtainVerb(normalizedText) &&
            (ObtainCurrencyHelper.IsDedicatedObtainLine(normalizedText) ||
             (markerFallback is { } fb && ObtainCurrencyHelper.IsDedicatedObtainConfirmedForMarker(fb, normalizedText))))
        {
            return true;
        }

        if (!MatchesAny(SharedObtainTemplateIds, normalizedText))
        {
            return false;
        }
        return ItemMarkerCatalog.Matches(markerItemId, normalizedText, markerFallback);
    }

    public static bool MatchesSharedObtainSeal(string normalizedText, LocalizedStrings? markerFallback = null)
    {
        if (!MatchesAny(SharedObtainTemplateIds, normalizedText))
        {
            return false;
        }
        return ItemMarkerCatalog.MatchesAnyGrandCompanySeal(normalizedText);
    }

    /// <summary>
    ///     LogMessage 1300 (GC seals) and shared obtain templates 657/1259 all use different Lumina rows
    ///     but the same style of "You obtain N Storm/Flame/Serpent Seals" chat lines.
    /// </summary>
    public static bool MatchesGrandCompanySealObtain(string normalizedText)
    {
        if (!ItemMarkerCatalog.MatchesAnyGrandCompanySeal(normalizedText))
        {
            return false;
        }

        if (L10N.Get(ChatStrings.ObtainedSeals).IsMatch(normalizedText))
        {
            return true;
        }

        return Matches(1300, normalizedText) || MatchesAny(SharedObtainTemplateIds, normalizedText);
    }

    public static bool MatchesSharedObtainGil(string normalizedText, LocalizedStrings? markerFallback = null)
    {
        if (markerFallback is { } fb &&
            ObtainCurrencyHelper.IsDedicatedObtainConfirmedForMarker(fb, normalizedText) &&
            ContainsObtainVerb(normalizedText))
        {
            return true;
        }

        if (!MatchesAny(SharedObtainTemplateIds, normalizedText))
        {
            return false;
        }
        if (markerFallback is { } fb2)
        {
            return TextMatchHelper.MatchesAllTokens(normalizedText, fb2);
        }
        return normalizedText.Contains("gil", StringComparison.Ordinal);
    }

    public static bool MatchesSharedObtainMgp(string normalizedText, LocalizedStrings? markerFallback = null)
    {
        if (markerFallback is { } fb &&
            ObtainCurrencyHelper.IsDedicatedObtainConfirmedForMarker(fb, normalizedText) &&
            ContainsObtainVerb(normalizedText))
        {
            return true;
        }

        if (!MatchesAny(SharedObtainTemplateIds, normalizedText))
        {
            return false;
        }
        if (markerFallback is { } fb2)
        {
            return TextMatchHelper.MatchesAllTokens(normalizedText, fb2);
        }
        return normalizedText.Contains("mgp", StringComparison.Ordinal);
    }

    public static bool MatchesSharedObtainElemental(string normalizedText, bool clustersOnly, LocalizedStrings? markerFallback = null,
        bool requireSharedTemplate = true)
    {
        if (requireSharedTemplate && !MatchesAny(SharedObtainTemplateIds, normalizedText))
        {
            return false;
        }
        var itemIds = clustersOnly ? ItemMarkerCatalog.Items.ElementalClusters : ItemMarkerCatalog.Items.ElementalAll;
        return ItemMarkerCatalog.MatchesAny(itemIds, normalizedText, markerFallback);
    }

    public static bool MatchesSharedObtainTribal(string normalizedText, LocalizedStrings? markerFallback = null)
    {
        if (L10N.Get(ChatStrings.ObtainedTribalCurrency).IsMatch(normalizedText) &&
            ItemMarkerCatalog.MatchesAny(ItemMarkerCatalog.Items.TribalCurrency, normalizedText, markerFallback))
        {
            return true;
        }

        if (!MatchesAny(SharedObtainTemplateIds, normalizedText))
        {
            return false;
        }
        return ItemMarkerCatalog.MatchesAny(ItemMarkerCatalog.Items.TribalCurrency, normalizedText, markerFallback);
    }

    public static bool MatchesMaterialsObtain(string normalizedText, LocalizedStrings? markerFallback = null,
        bool requireSharedTemplate = true)
    {
        if (markerFallback is { } fb)
        {
            if (!TextMatchHelper.MatchesAllTokens(normalizedText, fb))
            {
                return false;
            }
        }
        else if (!normalizedText.Contains("materials", StringComparison.Ordinal))
        {
            return false;
        }

        if (requireSharedTemplate)
        {
            if (markerFallback is { } confirmed &&
                ObtainCurrencyHelper.IsDedicatedObtainConfirmedForMarker(confirmed, normalizedText) &&
                ContainsObtainVerb(normalizedText))
            {
                return true;
            }

            return MatchesAny(SharedObtainTemplateIds, normalizedText);
        }
        return ContainsObtainVerb(normalizedText);
    }

    public static bool IsPlayerObtainMessage(string normalizedText) =>
        normalizedText.StartsWith("you ", StringComparison.Ordinal);

    public static bool MatchesOtherPlayerObtain(string normalizedText, LocalizedStrings? markerFallback = null)
    {
        if (IsPlayerObtainMessage(normalizedText))
        {
            return false;
        }

        if (markerFallback is { } fb)
        {
            foreach (var token in L10N.Get(fb))
            {
                if (normalizedText.Contains(token, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }

        return normalizedText.Contains(" obtains ", StringComparison.Ordinal);
    }

    public static bool MatchesWithFallback(uint logMessageId, string normalizedText, LocalizedStrings fallback)
    {
        if (HasTokens(logMessageId) && Matches(logMessageId, normalizedText))
        {
            return true;
        }
        return TextMatchHelper.MatchesAllTokens(normalizedText, fallback);
    }

    public static void ValidateRuleIds(IEnumerable<uint> referencedIds, IPluginLog log)
    {
        if (!IsLoaded)
        {
            return;
        }

        var missing = new List<uint>();
        var seen = new HashSet<uint>();
        foreach (var id in referencedIds)
        {
            if (!seen.Add(id))
            {
                continue;
            }
            if (!TemplateTextById.ContainsKey(id) && !RuntimeOnlyIds.Contains(id))
            {
                missing.Add(id);
            }
        }

        if (missing.Count == 0)
        {
            return;
        }

        missing.Sort();
        log.Warning(
            $"LogMessageCatalog: {missing.Count} rule LogMessage ID(s) not found in the Lumina sheet " +
            $"(game patch drift or retired messages): {string.Join(", ", missing)}");
    }

    public static void ValidateRuleChannels(IEnumerable<LocalizedFilterRule> rules, IPluginLog log)
    {
        if (!IsLoaded)
        {
            return;
        }

        foreach (var rule in rules)
        {
            if (rule.LogMessageIds is not { Length: > 0 })
            {
                continue;
            }

            ChatType? sheetChannel = null;
            var mixedKinds = false;
            foreach (var id in rule.LogMessageIds)
            {
                if (!LogKindById.TryGetValue(id, out var logKind))
                {
                    continue;
                }
                var channel = (ChatType)logKind;
                if (sheetChannel is null)
                {
                    sheetChannel = channel;
                }
                else if (sheetChannel != channel)
                {
                    mixedKinds = true;
                    break;
                }
            }

            if (mixedKinds || sheetChannel is null || sheetChannel == rule.Channel)
            {
                continue;
            }

            log.Warning(
                $"Rule '{rule.Name}' uses Channel={rule.Channel} but Lumina LogKind={sheetChannel} " +
                $"for LogMessage ID(s): {string.Join(", ", rule.LogMessageIds)}");
        }
    }

    private static bool ContainsObtainVerb(string normalizedText) =>
        normalizedText.Contains("you obtain", StringComparison.Ordinal) ||
        normalizedText.Contains("you obtains", StringComparison.Ordinal);
}
