using System.Collections.Generic;
using TidyChat.Translation.Data;
namespace TidyChat;

public sealed partial class TidyChatPlugin
{
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

    private static bool RuleMatchesText(LocalizedFilterRule rule, string normalizedText, bool debugMode)
    {
        if (TryMatchObtainMarkerRule(rule, normalizedText, debugMode, out bool obtainMatched))
            return obtainMatched;

        bool requiresCatalog = RequiresLogMessageCatalog(rule);
        bool catalogMatched = LogMessageCatalogMatches(rule, normalizedText);
        if (requiresCatalog && catalogMatched)
        {
            if (debugMode) Log.Debug($"MATCHED: {rule.Name} | LUMINA LogMessage catalog");
            return true;
        }

        bool allowTextFallback = requiresCatalog && !catalogMatched &&
                                 ShouldFallbackToTextChecksWhenCatalogMisses(rule);

        switch (rule.Pattern)
        {
            case PatternKind.RegexMatch:
                if (rule.RegexChecks is null) return false;

                if (requiresCatalog && !catalogMatched && !allowTextFallback)
                {
                    if (debugMode) Log.Verbose($"FAILED: {rule.Name} | LUMINA LogMessage catalog");
                    return false;
                }

                foreach(LocalizedRegex check in rule.RegexChecks)
                {
                    if (L10N.Get(check).IsMatch(normalizedText))
                    {
                        if (debugMode) Log.Debug($"MATCHED: {rule.Name} | REGEX: {L10N.Get(check)}");
                    }
                    else
                    {
                        if (debugMode) Log.Verbose($"FAILED: {rule.Name} | REGEX: {L10N.Get(check)}");
                        return false;
                    }
                }

                return true;
            case PatternKind.StringMatch:
                if (rule.StringChecks is null) return false;

                if (requiresCatalog && !catalogMatched && !allowTextFallback)
                {
                    if (debugMode) Log.Verbose($"FAILED: {rule.Name} | LUMINA LogMessage catalog");
                    return false;
                }

                foreach(LocalizedStrings check in rule.StringChecks)
                {
                    if (L10N.Get(check).All(normalizedText.Contains))
                    {
                        if (debugMode) Log.Debug($"MATCHED: {rule.Name} | CONTAINS: {string.Join(", ", L10N.Get(check))}");
                    }
                    else
                    {
                        if (debugMode) Log.Verbose($"FAILED: {rule.Name} | CONTAINS: {string.Join(", ", L10N.Get(check))}");
                        return false;
                    }
                }

                return true;
            case PatternKind.None:
                if (rule.LogMessageIds is not { Length: > 0 }) return false;
                if (LogMessageCatalog.IsLoaded && LogMessageCatalog.MatchesAny(rule.LogMessageIds, normalizedText))
                    return true;
                return false;
            default:
                return false;
        }
    }

    private static bool TryMatchObtainMarkerRule(LocalizedFilterRule rule, string normalizedText, bool debugMode, out bool matched)
    {
        matched = false;
        if (!rule.PreferLogMessageCatalog) return false;

        bool isObtainMarkerRule = rule.ObtainMarkerAnySeal ||
                                  rule.ObtainMarkerAnyElemental ||
                                  rule.ObtainMarkerAnyTribal ||
                                  rule.ObtainMarkerMaterials ||
                                  rule.ObtainMarkerOtherPlayer ||
                                  rule.ObtainMarkerGil ||
                                  rule.ObtainMarkerMgp ||
                                  rule.ObtainMarkerItemId is not null;
        if (!isObtainMarkerRule) return false;

        if (rule.ExcludePlayerObtain && LogMessageCatalog.IsPlayerObtainMessage(normalizedText))
        {
            matched = false;
            return true;
        }

        LocalizedStrings? markerFallback = rule.StringChecks is { Count: > 0 } ? rule.StringChecks[0] : null;
        if (markerFallback is null && rule.ObtainMarkerAnySeal)
            markerFallback = ChatStrings.ObtainSealsMarker;
        else if (markerFallback is null && rule.ObtainMarkerClustersOnly)
            markerFallback = ChatStrings.ObtainClusterMarker;
        else if (markerFallback is null && rule.ObtainMarkerMaterials)
            markerFallback = ChatStrings.ObtainMaterialsMarker;
        else if (markerFallback is null && rule.ObtainMarkerOtherPlayer)
            markerFallback = ChatStrings.OtherObtainMarker;

        if (rule.ObtainMarkerOtherPlayer)
        {
            matched = LogMessageCatalog.MatchesOtherPlayerObtain(normalizedText, markerFallback);
            if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA other-player obtain marker");
            return true;
        }

        if (rule.ObtainMarkerMaterials)
        {
            matched = LogMessageCatalog.MatchesMaterialsObtain(
                normalizedText, markerFallback, rule.ObtainMarkerRequireSharedTemplate);
            if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA materials obtain marker");
            return true;
        }

        if (rule.ObtainMarkerAnyElemental)
        {
            matched = LogMessageCatalog.MatchesSharedObtainElemental(
                normalizedText, rule.ObtainMarkerClustersOnly, markerFallback, rule.ObtainMarkerRequireSharedTemplate);
            if (debugMode && matched)
                Log.Debug($"MATCHED: {rule.Name} | LUMINA {(rule.ObtainMarkerClustersOnly ? "cluster" : "elemental")} obtain marker");
            return true;
        }

        if (rule.ObtainMarkerAnyTribal)
        {
            matched = LogMessageCatalog.MatchesSharedObtainTribal(normalizedText, markerFallback);
            if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA tribal currency obtain marker");
            return true;
        }

        if (rule.ObtainMarkerAnySeal)
        {
            matched = LogMessageCatalog.MatchesSharedObtainSeal(normalizedText, markerFallback);
            if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA shared obtain + GC seal marker");
            return true;
        }

        if (rule.ObtainMarkerGil)
        {
            matched = LogMessageCatalog.MatchesSharedObtainGil(normalizedText, markerFallback);
            if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA shared obtain + gil marker");
            return true;
        }

        if (rule.ObtainMarkerMgp)
        {
            matched = LogMessageCatalog.MatchesSharedObtainMgp(normalizedText, markerFallback);
            if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA shared obtain + MGP marker");
            return true;
        }

        matched = LogMessageCatalog.MatchesSharedObtain(normalizedText, rule.ObtainMarkerItemId!.Value, markerFallback);
        if (debugMode && matched) Log.Debug($"MATCHED: {rule.Name} | LUMINA shared obtain + item marker");
        return true;
    }

    private static SeString BuildDebugString(ChatType chatType, SeString message, List<string> rulesMatched, bool debugIncludeChannel, bool isBlocked)
    {
        SeStringBuilder stringBuilder = new();
        Better.AddTidyChatTag(stringBuilder);
        if (debugIncludeChannel)
        {
            Better.AddChannelTag(stringBuilder, chatType);
        }
        if (isBlocked) Better.AddBlockedTag(stringBuilder);
        if (rulesMatched.Count > 0)
        {
            if (!isBlocked) Better.AddAllowedTag(stringBuilder);
            Better.AddRuleTag(stringBuilder, rulesMatched);
        }
        stringBuilder.AddText(message.TextValue);
        return stringBuilder.BuiltString;
    }
}
