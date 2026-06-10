using TidyChat.Localization.Data;
namespace TidyChat;

/// <summary>
///     When <see cref="LocalizedFilterRule.PreferLogMessageCatalog" /> is set, string checks should not
///     broaden a rule beyond its Lumina LogMessage IDs. Rules listed here defer to
///     <c>ShowObtainedItems</c> on generic item obtain lines when their own toggle is off.
/// </summary>
internal static class RuleFallbackHelper
{
    private static readonly LocalizedStrings[] BroadCatalogMissStringChecks =
    [
        ChatStrings.ObtainedGilMarker,
        ChatStrings.CosmicRedAlert
    ];

    public static bool ShouldRejectCatalogTextFallback(LocalizedFilterRule rule)
    {
        if (!rule.PreferLogMessageCatalog || rule.LogMessageIds is not { Length: > 0 })
        {
            return false;
        }

        if (ObtainCurrencyHelper.UsesGenericObtainStringCheck(rule) &&
            !ObtainCurrencyHelper.IsGenericObtainShowRule(rule))
        {
            return true;
        }

        if (rule.ObtainMarkerGil || rule.ObtainMarkerMgp || ObtainCurrencyHelper.HasObtainMarkerConstraint(rule))
        {
            return false;
        }

        return UsesBroadStringCheck(rule);
    }

    public static bool ShouldDeferObtainRuleToGeneral(Configuration config, LocalizedFilterRule rule,
        string normalizedText) =>
        config.ShowObtainedItems &&
        DefersObtainRuleToGeneral(rule) &&
        ObtainCurrencyHelper.IsGenericItemObtainLine(normalizedText);

    public static bool DefersObtainRuleToGeneral(LocalizedFilterRule rule) =>
        ObtainCurrencyHelper.IsSpecializedObtainShowRule(rule) ||
        (string.Equals(rule.Name, "ShowGatheringCollectableObtains", StringComparison.Ordinal) &&
         ObtainCurrencyHelper.UsesGenericObtainStringCheck(rule));

    public static bool DefersObtainRuleToGeneral(string ruleName) =>
        ObtainCurrencyHelper.IsSpecializedObtainShowRuleName(ruleName) ||
        string.Equals(ruleName, "ShowGatheringCollectableObtains", StringComparison.Ordinal);

    private static bool UsesBroadStringCheck(LocalizedFilterRule rule) =>
        rule.StringChecks is { Count: > 0 } &&
        rule.StringChecks.Any(check => BroadCatalogMissStringChecks.Contains(check));
}
