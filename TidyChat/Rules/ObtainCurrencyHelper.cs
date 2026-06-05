using System.Collections.Generic;
using TidyChat.Utility;

namespace TidyChat;

/// <summary>
///     Hunt currencies, tomestones, and similar obtains use per-currency Hide toggles (checked = hide).
///     When hide is off, those lines should show even if Show general item obtains is off.
/// </summary>
internal static class ObtainCurrencyHelper
{
    public static bool ShouldAllowLootNoticeObtain(
        Configuration config,
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tomestones,
        IDictionary<uint, bool> hideTomestoneById) =>
        ShouldAllowCurrencyObtain(config, normalizedText) ||
        TomestoneHelper.ShouldAllowObtain(normalizedText, tomestones, hideTomestoneById);

    public static bool HasObtainMarkerConstraint(LocalizedFilterRule rule) =>
        rule.ObtainMarkerItemId is not null ||
        rule.ObtainMarkerAnySeal ||
        rule.ObtainMarkerAnyElemental ||
        rule.ObtainMarkerAnyTribal ||
        rule.ObtainMarkerMaterials ||
        rule.ObtainMarkerOtherPlayer ||
        rule.ObtainMarkerGil ||
        rule.ObtainMarkerMgp;

    public static bool ShouldAllowCurrencyObtain(Configuration config, string normalizedText)
    {
        if (MatchesNuts(normalizedText) && !config.HideObtainedNuts)
        {
            return true;
        }
        if (MatchesWolfMarks(normalizedText) && !config.HideObtainedWolfMarks)
        {
            return true;
        }
        if (MatchesAlliedSeals(normalizedText) && !config.HideObtainedAlliedSeals)
        {
            return true;
        }
        if (MatchesCenturioSeals(normalizedText) && !config.HideObtainedCenturioSeals)
        {
            return true;
        }
        if (MatchesGrandCompanySeals(normalizedText) && !config.HideObtainedSeals)
        {
            return true;
        }
        return false;
    }

    private static bool MatchesNuts(string normalizedText) =>
        L10N.Get(ChatRegexStrings.ObtainedNuts).IsMatch(normalizedText) ||
        L10N.Get(ChatStrings.ObtainNutsMarker).All(normalizedText.Contains);

    private static bool MatchesWolfMarks(string normalizedText) =>
        L10N.Get(ChatRegexStrings.ObtainedWolfMarks).IsMatch(normalizedText) ||
        L10N.Get(ChatStrings.ObtainWolfMarks).All(normalizedText.Contains);

    private static bool MatchesAlliedSeals(string normalizedText) =>
        L10N.Get(ChatRegexStrings.ObtainedAlliedSeals).IsMatch(normalizedText) ||
        L10N.Get(ChatStrings.ObtainAlliedSealsMarker).All(normalizedText.Contains);

    private static bool MatchesCenturioSeals(string normalizedText) =>
        L10N.Get(ChatRegexStrings.ObtainedCenturioSeals).IsMatch(normalizedText) ||
        L10N.Get(ChatStrings.ObtainCenturioSealsMarker).All(normalizedText.Contains);

    private static bool MatchesGrandCompanySeals(string normalizedText)
    {
        if (ItemMarkerCatalog.IsLoaded && ItemMarkerCatalog.MatchesAnyGrandCompanySeal(normalizedText))
        {
            return true;
        }

        return L10N.Get(ChatRegexStrings.ObtainedSeals).IsMatch(normalizedText);
    }
}
