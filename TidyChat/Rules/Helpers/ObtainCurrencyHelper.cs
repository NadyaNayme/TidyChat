using System.Collections.Generic;
using TidyChat.Translation.Data;

namespace TidyChat;

/// <summary>
///     Hunt currencies, tomestones, and similar obtains use per-currency Hide toggles (checked = hide).
///     When hide is off, those lines should show even if Show general item obtains is off.
/// </summary>
internal static class ObtainCurrencyHelper
{
    private static readonly HashSet<string> GenericObtainShowRuleNames = new(StringComparer.Ordinal)
    {
        "ShowObtainedItems",
        "ShowObtainedQuestItems",
        "ShowGatheringCollectableObtains",
    };

    private static readonly LocalizedStrings[] DedicatedObtainTypeMarkers =
    [
        ChatStrings.ObtainedMgpMarker,
        ChatStrings.ObtainedGilMarker,
        ChatStrings.ReceivedGilMarker,
        ChatStrings.ObtainWolfMarks,
        ChatStrings.ObtainAlliedSealsMarker,
        ChatStrings.ObtainCenturioSealsMarker,
        ChatStrings.ObtainNutsMarker,
        ChatStrings.ObtainClusterMarker,
        ChatStrings.ObtainVentureMarker,
        ChatStrings.ObtainMaterialsMarker,
        ChatStrings.CosmicContainerObtain,
        ChatStrings.CosmocreditObtain,
        ChatStrings.CosmocreditReceived,
        ChatStrings.OizysCreditObtain,
        ChatStrings.AuxesiaCreditObtain,
        ChatStrings.OizysDronebitsObtain,
        ChatStrings.CosmicFortuneObtain,
    ];

    public static bool ShouldAllowLootNoticeObtain(
        Configuration config,
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tomestones,
        IDictionary<uint, bool> hideTomestoneById) =>
        ShouldAllowCurrencyObtain(config, normalizedText) ||
        ShouldAllowTomestoneObtain(normalizedText, tomestones, hideTomestoneById);

    public static bool ShouldHideTomestone(
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tomestones,
        IDictionary<uint, bool> hideTomestoneById)
    {
        if (!TryGetMatchedTomestone(normalizedText, tomestones, out var tomestone))
        {
            return false;
        }

        return hideTomestoneById.TryGetValue(tomestone.RowId, out var hide) && hide;
    }

    public static bool HasObtainMarkerConstraint(LocalizedFilterRule rule) =>
        rule.ObtainMarkerItemId is not null ||
        rule.ObtainMarkerAnySeal ||
        rule.ObtainMarkerAnyElemental ||
        rule.ObtainMarkerAnyTribal ||
        rule.ObtainMarkerMaterials ||
        rule.ObtainMarkerOtherPlayer ||
        rule.ObtainMarkerGil ||
        rule.ObtainMarkerMgp;

    public static bool ShouldExcludeGenericObtainShowRule(LocalizedFilterRule rule, string normalizedText) =>
        GenericObtainShowRuleNames.Contains(rule.Name) && HasDedicatedObtainType(normalizedText);

    public static bool HasDedicatedObtainType(string normalizedText)
    {
        foreach (var marker in DedicatedObtainTypeMarkers)
        {
            if (TextMatchHelper.MatchesAllTokens(normalizedText, marker))
            {
                return true;
            }
        }

        return ItemMarkerCatalog.IsLoaded && ItemMarkerCatalog.MatchesAnyGrandCompanySeal(normalizedText);
    }

    public static bool TemplateMissingDedicatedObtainMarkers(string normalizedText, string[] templateTokens)
    {
        foreach (var marker in DedicatedObtainTypeMarkers)
        {
            if (!TextMatchHelper.MatchesAllTokens(normalizedText, marker))
            {
                continue;
            }

            if (L10N.Get(marker).Any(token => !templateTokens.Contains(token)))
            {
                return true;
            }
        }

        if (ItemMarkerCatalog.IsLoaded &&
            ItemMarkerCatalog.MatchesAnyGrandCompanySeal(normalizedText) &&
            !templateTokens.Any(token => token.Contains("seal", StringComparison.Ordinal)))
        {
            return true;
        }

        return false;
    }

    public static string? GetAllowBecauseHideOffRuleName(Configuration config, string normalizedText)
    {
        if (TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.ObtainedMgpMarker) &&
            !config.HideObtainedMGP)
        {
            return "HideObtainedMGP";
        }

        if (TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.ObtainedGilMarker) &&
            !config.HideObtainedGil)
        {
            return "HideObtainedGil";
        }

        if (MatchesNuts(normalizedText) && !config.HideObtainedNuts)
        {
            return "HideObtainedNuts";
        }
        if (MatchesWolfMarks(normalizedText) && !config.HideObtainedWolfMarks)
        {
            return "HideObtainedWolfMarks";
        }

        if (MatchesAlliedSeals(normalizedText) && !config.HideObtainedAlliedSeals)
        {
            return "HideObtainedAlliedSeals";
        }

        if (MatchesCenturioSeals(normalizedText) && !config.HideObtainedCenturioSeals)
        {
            return "HideObtainedCenturioSeals";
        }

        if (MatchesGrandCompanySeals(normalizedText) && !config.HideObtainedSeals)
        {
            return "HideObtainedSeals";
        }

        return null;
    }

    public static bool ShouldAllowCurrencyObtain(Configuration config, string normalizedText) =>
        GetAllowBecauseHideOffRuleName(config, normalizedText) is not null;

    private static bool ShouldAllowTomestoneObtain(
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tomestones,
        IDictionary<uint, bool> hideTomestoneById)
    {
        if (!TryGetMatchedTomestone(normalizedText, tomestones, out var tomestone))
        {
            return false;
        }

        return !hideTomestoneById.TryGetValue(tomestone.RowId, out var hide) || !hide;
    }

    private static bool TryGetMatchedTomestone(
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tomestones,
        out TomestoneInfo tomestone)
    {
        tomestone = default!;
        if (tomestones.Count == 0)
        {
            return false;
        }
        if (!L10N.Get(ChatRegexStrings.ObtainedTomestones).IsMatch(normalizedText))
        {
            return false;
        }

        foreach (var candidate in tomestones)
        {
            var itemNameLower = candidate.Name.ToLower(CultureInfo.InvariantCulture);
            var lastWordStart = itemNameLower.LastIndexOf(' ') + 1;
            var typeName = itemNameLower[lastWordStart..];
            if (!normalizedText.Contains(typeName, StringComparison.Ordinal))
            {
                continue;
            }

            tomestone = candidate;
            return true;
        }

        return false;
    }

    private static bool MatchesNuts(string normalizedText) =>
        L10N.Get(ChatRegexStrings.ObtainedNuts).IsMatch(normalizedText) ||
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.ObtainNutsMarker);

    private static bool MatchesWolfMarks(string normalizedText) =>
        L10N.Get(ChatRegexStrings.ObtainedWolfMarks).IsMatch(normalizedText) ||
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.ObtainWolfMarks);

    private static bool MatchesAlliedSeals(string normalizedText) =>
        L10N.Get(ChatRegexStrings.ObtainedAlliedSeals).IsMatch(normalizedText) ||
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.ObtainAlliedSealsMarker);

    private static bool MatchesCenturioSeals(string normalizedText) =>
        L10N.Get(ChatRegexStrings.ObtainedCenturioSeals).IsMatch(normalizedText) ||
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.ObtainCenturioSealsMarker);

    private static bool MatchesGrandCompanySeals(string normalizedText)
    {
        if (ItemMarkerCatalog.IsLoaded && ItemMarkerCatalog.MatchesAnyGrandCompanySeal(normalizedText))
        {
            return true;
        }

        return L10N.Get(ChatRegexStrings.ObtainedSeals).IsMatch(normalizedText);
    }
}
