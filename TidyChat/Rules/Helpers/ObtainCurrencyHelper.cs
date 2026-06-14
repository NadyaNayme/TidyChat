using TidyChat.Localization.Data;
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
        "ShowGatheringCollectableObtains"
    };

    private static readonly HashSet<string> SpecializedObtainShowRuleNames = new(StringComparer.Ordinal)
    {
        "ShowDesynthesisObtains",
        "ShowCosmicRewards"
    };

    private static readonly LocalizedStrings[] GenericObtainStringChecks =
    [
        ChatStrings.ObtainedSingleItem,
        ChatStrings.QuestItemObtain,
        ChatStrings.ObtainedItemQuantity,
        ChatStrings.DesynthesisObtain
    ];

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
        ChatStrings.CosmicToolMasteryPoints
    ];

    private static readonly (LocalizedStrings Marker, LocalizedRegex Regex)[] DedicatedObtainRegexByMarker =
    [
        (ChatStrings.ObtainWolfMarks, ChatStrings.ObtainedWolfMarks),
        (ChatStrings.ObtainAlliedSealsMarker, ChatStrings.ObtainedAlliedSeals),
        (ChatStrings.ObtainCenturioSealsMarker, ChatStrings.ObtainedCenturioSeals),
        (ChatStrings.ObtainNutsMarker, ChatStrings.ObtainedNuts)
    ];

    private static readonly LocalizedStrings[] SharedTemplateCurrencyMarkers =
    [
        ChatStrings.ObtainedGilMarker,
        ChatStrings.ObtainedMgpMarker,
        ChatStrings.ObtainVentureMarker,
        ChatStrings.ObtainNutsMarker,
        ChatStrings.ObtainMaterialsMarker,
        ChatStrings.ObtainClusterMarker,
        ChatStrings.ReceivedGilMarker
    ];

    public static bool ShouldAllowLootNoticeObtain(
        Configuration config,
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tomestones,
        IDictionary<uint, bool> hideTomestoneById,
        IReadOnlyList<TomestoneInfo> tribalCurrencies,
        IDictionary<uint, bool> hideTribalCurrencyById) =>
        ShouldAllowCurrencyObtain(config, normalizedText) ||
        ShouldAllowTomestoneObtain(normalizedText, tomestones, hideTomestoneById) ||
        ShouldAllowTribalCurrencyObtain(config, normalizedText, tribalCurrencies, hideTribalCurrencyById);

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

    public static bool IsTomestoneWeeklyCapMessage(string normalizedText) =>
        L10N.Get(ChatStrings.TomestoneWeeklyCap).IsMatch(normalizedText);

    public static bool TryResolveTomestoneLogMessage(
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tomestones,
        IDictionary<uint, bool> hideTomestoneById,
        out bool shouldAllow,
        out string? decidingRuleName)
    {
        shouldAllow = false;
        decidingRuleName = null;
        if (!TryGetMatchedTomestone(normalizedText, tomestones, out _))
        {
            return false;
        }

        if (ShouldHideTomestone(normalizedText, tomestones, hideTomestoneById))
        {
            decidingRuleName = "tomestone hide";
            return true;
        }

        shouldAllow = true;
        decidingRuleName = "Tomestone (hide off)";
        return true;
    }

    public static bool ShouldHideTribalCurrency(
        Configuration config,
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tribalCurrencies,
        IDictionary<uint, bool> hideTribalCurrencyById)
    {
        if (!TryGetMatchedTribalCurrency(normalizedText, tribalCurrencies, out var currency))
        {
            return false;
        }

        if (config.HideObtainedTribalCurrency)
        {
            return true;
        }

        return hideTribalCurrencyById.TryGetValue(currency.RowId, out var hide) && hide;
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

    public static bool IsSpecializedObtainShowRuleName(string ruleName) =>
        SpecializedObtainShowRuleNames.Contains(ruleName);

    public static bool IsSpecializedObtainShowRule(LocalizedFilterRule rule) =>
        IsSpecializedObtainShowRuleName(rule.Name);

    public static bool IsGenericObtainShowRule(LocalizedFilterRule rule) =>
        GenericObtainShowRuleNames.Contains(rule.Name);

    public static bool UsesGenericObtainStringCheck(LocalizedFilterRule rule) =>
        rule.StringChecks is { Count: > 0 } &&
        rule.StringChecks.Any(check => GenericObtainStringChecks.Contains(check));

    public static bool IsGenericItemObtainLine(string normalizedText) =>
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.ObtainedSingleItem) &&
        !HasDedicatedObtainType(normalizedText);

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

    public static bool IsDedicatedObtainLine(string normalizedText) =>
        L10N.Get(ChatStrings.ObtainedSeals).IsMatch(normalizedText) ||
        L10N.Get(ChatStrings.ObtainedWolfMarks).IsMatch(normalizedText) ||
        L10N.Get(ChatStrings.ObtainedAlliedSeals).IsMatch(normalizedText) ||
        L10N.Get(ChatStrings.ObtainedCenturioSeals).IsMatch(normalizedText) ||
        L10N.Get(ChatStrings.ObtainedNuts).IsMatch(normalizedText) ||
        L10N.Get(ChatStrings.ObtainedTribalCurrency).IsMatch(normalizedText) ||
        L10N.Get(ChatStrings.ObtainedTomestones).IsMatch(normalizedText);

    public static bool IsDedicatedObtainConfirmedForMarker(LocalizedStrings marker, string normalizedText)
    {
        foreach ((var dedicatedMarker, var regex) in DedicatedObtainRegexByMarker)
        {
            if (marker.Equals(dedicatedMarker) && L10N.Get(regex).IsMatch(normalizedText))
            {
                return true;
            }
        }

        // Shared templates 657/1259/1300 often omit the currency name in Lumina tokens even when chat text includes it.
        foreach (var sharedMarker in SharedTemplateCurrencyMarkers)
        {
            if (marker.Equals(sharedMarker))
            {
                return TextMatchHelper.MatchesAllTokens(normalizedText, sharedMarker);
            }
        }

        return false;
    }

    public static bool TemplateMissingDedicatedObtainMarkers(string normalizedText, string[] templateTokens)
    {
        foreach (var marker in DedicatedObtainTypeMarkers)
        {
            if (!TextMatchHelper.MatchesAllTokens(normalizedText, marker))
            {
                continue;
            }

            if (IsDedicatedObtainConfirmedForMarker(marker, normalizedText))
            {
                return false;
            }

            if (L10N.Get(marker).Any(token => !templateTokens.Contains(token)))
            {
                return true;
            }
        }

        if (ItemMarkerCatalog.MatchesAnyGrandCompanySeal(normalizedText))
        {
            if (L10N.Get(ChatStrings.ObtainedSeals).IsMatch(normalizedText))
            {
                return false;
            }

            if (!templateTokens.Any(token => token.Contains("seal", StringComparison.Ordinal)))
            {
                return true;
            }
        }

        if (IsDedicatedObtainLine(normalizedText))
        {
            return false;
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

        if (TryGetMatchedTribalCurrency(normalizedText, TidyChatPlugin.TribalCurrencies, out _) &&
            !ShouldHideTribalCurrency(config, normalizedText, TidyChatPlugin.TribalCurrencies, config.HideTribalCurrencyById))
        {
            return "HideObtainedTribalCurrency";
        }

        return null;
    }

    public static bool ShouldAllowCurrencyObtain(Configuration config, string normalizedText) =>
        GetAllowBecauseHideOffRuleName(config, normalizedText) is not null;

    private static bool ShouldAllowTribalCurrencyObtain(
        Configuration config,
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tribalCurrencies,
        IDictionary<uint, bool> hideTribalCurrencyById) =>
        TryGetMatchedTribalCurrency(normalizedText, tribalCurrencies, out _) &&
        !ShouldHideTribalCurrency(config, normalizedText, tribalCurrencies, hideTribalCurrencyById);

    private static bool TryGetMatchedTribalCurrency(
        string normalizedText,
        IReadOnlyList<TomestoneInfo> tribalCurrencies,
        out TomestoneInfo currency)
    {
        currency = default!;
        if (!ItemMarkerCatalog.IsLoaded || tribalCurrencies.Count == 0)
        {
            return false;
        }

        foreach (var candidate in tribalCurrencies)
        {
            if (!ItemMarkerCatalog.Matches(candidate.RowId, normalizedText))
            {
                continue;
            }

            currency = candidate;
            return true;
        }

        if (!L10N.Get(ChatStrings.ObtainedTribalCurrency).IsMatch(normalizedText))
        {
            return false;
        }

        foreach (var candidate in tribalCurrencies)
        {
            var nameLower = candidate.Name.ToLower(CultureInfo.InvariantCulture);
            if (!normalizedText.Contains(nameLower, StringComparison.Ordinal))
            {
                continue;
            }

            currency = candidate;
            return true;
        }

        return false;
    }

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
        if (!L10N.Get(ChatStrings.ObtainedTomestones).IsMatch(normalizedText))
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
        L10N.Get(ChatStrings.ObtainedNuts).IsMatch(normalizedText) ||
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.ObtainNutsMarker);

    private static bool MatchesWolfMarks(string normalizedText) =>
        L10N.Get(ChatStrings.ObtainedWolfMarks).IsMatch(normalizedText) ||
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.ObtainWolfMarks);

    private static bool MatchesAlliedSeals(string normalizedText) =>
        L10N.Get(ChatStrings.ObtainedAlliedSeals).IsMatch(normalizedText) ||
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.ObtainAlliedSealsMarker);

    private static bool MatchesCenturioSeals(string normalizedText) =>
        L10N.Get(ChatStrings.ObtainedCenturioSeals).IsMatch(normalizedText) ||
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.ObtainCenturioSealsMarker);

    private static bool MatchesGrandCompanySeals(string normalizedText)
    {
        if (ItemMarkerCatalog.IsLoaded && ItemMarkerCatalog.MatchesAnyGrandCompanySeal(normalizedText))
        {
            return true;
        }

        return L10N.Get(ChatStrings.ObtainedSeals).IsMatch(normalizedText);
    }
}
