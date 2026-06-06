using TidyChat.Localization.Data;
namespace TidyChat;

internal static class RuleMatcher
{
    public static bool MatchesText(LocalizedFilterRule rule, string normalizedText, out string? matchDetail)
    {
        matchDetail = null;

        if (TryMatchObtainMarkerRule(rule, normalizedText, out var obtainMatched, out var obtainDetail))
        {
            if (obtainMatched)
            {
                matchDetail = obtainDetail;
            }
            return obtainMatched;
        }

        if (ObtainCurrencyHelper.ShouldExcludeGenericObtainShowRule(rule, normalizedText))
        {
            return false;
        }

        var requiresCatalog = RequiresLogMessageCatalog(rule);
        var catalogMatched = LogMessageCatalogMatches(rule, normalizedText);
        var allowTextFallback = requiresCatalog && !catalogMatched &&
                                ShouldFallbackToTextChecksWhenCatalogMisses(rule);

        if (requiresCatalog && catalogMatched && !ObtainCurrencyHelper.HasObtainMarkerConstraint(rule) &&
            !RuleHasTextChecks(rule))
        {
            matchDetail = "LUMINA LogMessage catalog";
            return true;
        }

        switch (rule.Pattern)
        {
            case PatternKind.RegexMatch:
                if (rule.RegexChecks is null)
                {
                    return false;
                }

                if (requiresCatalog && !catalogMatched && !allowTextFallback)
                {
                    return false;
                }

                foreach (var check in rule.RegexChecks)
                {
                    if (L10N.Get(check).IsMatch(normalizedText))
                    {
                        matchDetail = $"REGEX: {L10N.Get(check)}";
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            case PatternKind.StringMatch:
                if (rule.StringChecks is null)
                {
                    return false;
                }

                if (requiresCatalog && !catalogMatched && !allowTextFallback)
                {
                    return false;
                }

                foreach (var check in rule.StringChecks)
                {
                    if (TextMatchHelper.MatchesAllTokens(normalizedText, check))
                    {
                        var via = catalogMatched ? "catalog+string" : "string";
                        matchDetail = $"{via.ToUpperInvariant()}: {string.Join(", ", L10N.Get(check))}";
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            case PatternKind.None:
                if (rule.LogMessageIds is not { Length: > 0 })
                {
                    return false;
                }
                if (LogMessageCatalog.IsLoaded && LogMessageCatalog.MatchesAny(rule.LogMessageIds, normalizedText))
                {
                    matchDetail = "LUMINA LogMessage catalog";
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    public static bool MatchesText(LocalizedFilterRule rule, string normalizedText, bool _) =>
        MatchesText(rule, normalizedText, out string? _);

    private static bool RequiresLogMessageCatalog(LocalizedFilterRule rule) =>
        rule.PreferLogMessageCatalog && rule.LogMessageIds is { Length: > 0 };

    private static bool LogMessageCatalogMatches(LocalizedFilterRule rule, string normalizedText) =>
        RequiresLogMessageCatalog(rule) &&
        LogMessageCatalog.IsLoaded &&
        LogMessageCatalog.MatchesAny(rule.LogMessageIds!, normalizedText);

    private static bool RuleHasTextChecks(LocalizedFilterRule rule) =>
        rule.Pattern switch
        {
            PatternKind.StringMatch => rule.StringChecks is not null,
            PatternKind.RegexMatch => rule.RegexChecks is not null,
            _ => false
        };

    private static bool ShouldFallbackToTextChecksWhenCatalogMisses(LocalizedFilterRule rule) =>
        RuleHasTextChecks(rule);

    private static bool TryMatchObtainMarkerRule(LocalizedFilterRule rule, string normalizedText, out bool matched,
        out string? matchDetail)
    {
        matched = false;
        matchDetail = null;
        if (!rule.PreferLogMessageCatalog)
        {
            return false;
        }

        if (!ObtainCurrencyHelper.HasObtainMarkerConstraint(rule))
        {
            return false;
        }

        if (rule.ExcludePlayerObtain && LogMessageCatalog.IsPlayerObtainMessage(normalizedText))
        {
            matched = false;
            return true;
        }

        LocalizedStrings? markerFallback = rule.StringChecks is { Count: > 0 } ? rule.StringChecks[0] : null;
        if (markerFallback is null && rule.ObtainMarkerAnySeal)
        {
            markerFallback = ChatStrings.ObtainSealsMarker;
        }
        else if (markerFallback is null && rule.ObtainMarkerClustersOnly)
        {
            markerFallback = ChatStrings.ObtainClusterMarker;
        }
        else if (markerFallback is null && rule.ObtainMarkerMaterials)
        {
            markerFallback = ChatStrings.ObtainMaterialsMarker;
        }
        else if (markerFallback is null && rule.ObtainMarkerOtherPlayer)
        {
            markerFallback = ChatStrings.OtherObtainMarker;
        }

        if (rule.ObtainMarkerOtherPlayer)
        {
            matched = LogMessageCatalog.MatchesOtherPlayerObtain(normalizedText, markerFallback);
            if (matched)
            {
                matchDetail = "LUMINA other-player obtain marker";
            }
            return true;
        }

        if (rule.ObtainMarkerMaterials)
        {
            matched = LogMessageCatalog.MatchesMaterialsObtain(
                normalizedText, markerFallback, rule.ObtainMarkerRequireSharedTemplate);
            if (matched)
            {
                matchDetail = "LUMINA materials obtain marker";
            }
            return true;
        }

        if (rule.ObtainMarkerAnyElemental)
        {
            matched = LogMessageCatalog.MatchesSharedObtainElemental(
                normalizedText, rule.ObtainMarkerClustersOnly, markerFallback, rule.ObtainMarkerRequireSharedTemplate);
            if (matched)
            {
                matchDetail = rule.ObtainMarkerClustersOnly
                    ? "LUMINA cluster obtain marker"
                    : "LUMINA elemental obtain marker";
            }
            return true;
        }

        if (rule.ObtainMarkerAnyTribal)
        {
            matched = LogMessageCatalog.MatchesSharedObtainTribal(normalizedText, markerFallback);
            if (matched)
            {
                matchDetail = "LUMINA tribal currency obtain marker";
            }
            return true;
        }

        if (rule.ObtainMarkerAnySeal)
        {
            matched = LogMessageCatalog.MatchesGrandCompanySealObtain(normalizedText);
            if (matched)
            {
                matchDetail = LogMessageCatalog.Matches(1300, normalizedText)
                    ? "LUMINA 1300 + GC seal marker"
                    : "LUMINA shared obtain + GC seal marker";
            }
            return true;
        }

        if (rule.ObtainMarkerGil)
        {
            matched = LogMessageCatalog.MatchesSharedObtainGil(normalizedText, markerFallback);
            if (matched)
            {
                matchDetail = "LUMINA shared obtain + gil marker";
            }
            return true;
        }

        if (rule.ObtainMarkerMgp)
        {
            matched = LogMessageCatalog.MatchesSharedObtainMgp(normalizedText, markerFallback);
            if (matched)
            {
                matchDetail = "LUMINA shared obtain + MGP marker";
            }
            return true;
        }

        var itemId = rule.ObtainMarkerItemId!.Value;
        matched = LogMessageCatalog.MatchesSharedObtain(normalizedText, itemId, markerFallback)
                  || ItemMarkerCatalog.Matches(itemId, normalizedText, markerFallback);
        if (matched)
        {
            matchDetail = LogMessageCatalog.MatchesSharedObtain(normalizedText, itemId, markerFallback)
                ? "LUMINA shared obtain + item marker"
                : "dedicated obtain + item marker";
        }
        return true;
    }
}
