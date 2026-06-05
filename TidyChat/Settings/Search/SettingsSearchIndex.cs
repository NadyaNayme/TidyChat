using Dalamud.Interface.Components;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;
namespace TidyChat.Settings.Search;

internal static class SettingsSearchIndex
{
    private static readonly HashSet<string> AlwaysOnSettings = new(StringComparer.Ordinal);

    private static readonly HashSet<string> SkippedProperties = new(StringComparer.Ordinal)
    {
        "Enabled"
    };

    private static readonly PropertyInfo[] LanguageProperties =
        typeof(Languages).GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

    private static readonly PropertyInfo[] ConfigBoolProperties =
        typeof(Configuration).GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.PropertyType == typeof(bool) && p.CanRead && p.CanWrite)
            .ToArray();

    private static readonly Dictionary<string, RuleMetadata> RuleMetadataByName = BuildRuleMetadata();

    private static Entry[]? s_entries;

    public static void DrawResults(Configuration configuration)
    {
        var query = SettingsSearch.Query.Trim();
        var entries = s_entries ??= BuildEntries();

        var matches = entries.Where(e => e.Matches(query)).ToList();
        AppendTomestoneMatches(configuration, query, matches);
        AppendTribalCurrencyMatches(configuration, query, matches);

        ImGui.Spacing();
        if (matches.Count == 0)
        {
            ImGui.TextUnformatted(Languages.ConfigWindow_SearchNoResults);
            return;
        }

        ImGui.TextUnformatted(string.Format(CultureInfo.CurrentCulture, Languages.ConfigWindow_SearchResultCount,
            matches.Count.ToString(CultureInfo.CurrentCulture)));
        ImGui.Spacing();

        if (!ImGui.BeginChild("##settingsSearchResults", new(0, 0)))
        {
            return;
        }

        foreach (var entry in matches.OrderBy(e => e.Location, StringComparer.OrdinalIgnoreCase)
                     .ThenBy(e => e.Label, StringComparer.OrdinalIgnoreCase))
        {
            DrawEntry(configuration, entry);
        }

        ImGui.EndChild();
    }

    private static void DrawEntry(Configuration configuration, Entry entry)
    {
        ImGui.PushID(entry.Id);

        if (entry.CanToggle)
        {
            var value = entry.GetBool(configuration);
            if (ImGui.Checkbox(entry.Label, ref value))
            {
                entry.SetBool(configuration, value);
                configuration.OnSettingChanged();
            }
        }
        else if (entry.AlwaysOn)
        {
            ImGui.BeginDisabled();
            var value = true;
            ImGui.Checkbox(entry.Label, ref value);
            ImGui.EndDisabled();
            ImGuiComponents.HelpMarker(Languages.ConfigWindow_SettingAlwaysOn);
        }
        else
        {
            ImGui.TextUnformatted(entry.Label);
        }

        if (!string.IsNullOrEmpty(entry.Help))
        {
            ImGui.SameLine();
            ImGuiComponents.HelpMarker(entry.Help);
        }

        ImGui.TextColored(new Vector4(0.55f, 0.55f, 0.55f, 1f), entry.Location);

        if (!string.IsNullOrEmpty(entry.RuleName))
        {
            ImGui.TextDisabled($"{Languages.ConfigWindow_SearchRuleLabel}: {entry.RuleName}");
        }

        if (entry.Examples.Count > 0)
        {
            var examples = string.Join(" / ", entry.Examples.Take(3));
            ImGui.TextWrapped($"{Languages.ConfigWindow_SearchExamplesLabel}: {examples}");
        }

        if (entry.LogMessageIds.Count > 0)
        {
            var ids = string.Join(", ", entry.LogMessageIds.OrderBy(id => id));
            ImGui.TextDisabled($"{Languages.ConfigWindow_SearchLogMessageIdsLabel}: {ids}");
        }

        ImGui.Spacing();
        ImGui.PopID();
    }

    private static void AppendTribalCurrencyMatches(Configuration configuration, string query, List<Entry> matches)
    {
        if (TidyChatPlugin.TribalCurrencies.Count == 0)
        {
            return;
        }

        foreach (var currency in TidyChatPlugin.TribalCurrencies)
        {
            if (!Contains(query, currency.Name) &&
                !Contains(query, "allied society") &&
                !Contains(query, "beast tribe") &&
                !Contains(query, "tribal"))
            {
                continue;
            }

            configuration.HideTribalCurrencyById.TryGetValue(currency.RowId, out var hide);
            var label = string.Format(CultureInfo.CurrentCulture, Languages.ConfigWindow_SearchHideTomestone,
                currency.Name);
            matches.Add(new(
                $"tribal-currency-{currency.RowId}",
                label,
                null,
                $"{Languages.ConfigWindow_AlliedSocietiesTabHeader} > {Languages.AlliedSocietiesTab_CurrenciesDropdownHeader}",
                null,
                [],
                [],
                true,
                false,
                _ => hide,
                (_, value) => configuration.HideTribalCurrencyById[currency.RowId] = value));
        }
    }

    private static void AppendTomestoneMatches(Configuration configuration, string query, List<Entry> matches)
    {
        if (TidyChatPlugin.Tomestones.Count == 0)
        {
            return;
        }

        foreach (var tomestone in TidyChatPlugin.Tomestones)
        {
            if (!Contains(query, tomestone.Name) && !Contains(query, "tomestone") && !Contains(query, "tomestones"))
            {
                continue;
            }

            configuration.HideTomestoneById.TryGetValue(tomestone.RowId, out var hide);
            var label = string.Format(CultureInfo.CurrentCulture, Languages.ConfigWindow_SearchHideTomestone,
                tomestone.Name);
            matches.Add(new(
                $"tomestone-{tomestone.RowId}",
                label,
                null,
                Languages.ConfigWindow_CurrenciesTabHeader,
                null,
                [],
                [],
                true,
                false,
                _ => hide,
                (_, value) => configuration.HideTomestoneById[tomestone.RowId] = value));
        }
    }

    private static Entry[] BuildEntries()
    {
        var entries = new List<Entry>(ConfigBoolProperties.Length);

        foreach (var property in ConfigBoolProperties)
        {
            if (SkippedProperties.Contains(property.Name))
            {
                continue;
            }

            (var label, var help) = ResolveLabelAndHelp(property.Name);
            var ruleMeta = RuleMetadataByName.GetValueOrDefault(property.Name);
            var location = TryGetInferredLocation(property.Name)
                           ?? (ruleMeta is not null
                               ? FormatRuleLocation(ruleMeta.SettingsTab)
                               : Languages.ConfigWindow_GeneralTabHeader);

            entries.Add(new(
                property.Name,
                label,
                help,
                location,
                ruleMeta is not null ? property.Name : null,
                ruleMeta?.Examples ?? [],
                ruleMeta?.LogMessageIds ?? [],
                !AlwaysOnSettings.Contains(property.Name),
                AlwaysOnSettings.Contains(property.Name),
                config => (bool)property.GetValue(config)!,
                (config, value) => property.SetValue(config, value)));
        }

        return entries.ToArray();
    }

    private static Dictionary<string, RuleMetadata> BuildRuleMetadata()
    {
        var metadata = new Dictionary<string, RuleMetadata>(StringComparer.Ordinal);

        foreach (var group in Rules.AllRules.GroupBy(r => r.Name, StringComparer.Ordinal))
        {
            var examples = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var logIds = new HashSet<uint>();

            foreach (var rule in group)
            {
                if (rule.StringChecks is not null)
                {
                    foreach (var strings in rule.StringChecks)
                    {
                        foreach (var token in strings.Eng)
                        {
                            if (!string.IsNullOrWhiteSpace(token))
                            {
                                examples.Add(token);
                            }
                        }
                    }
                }

                if (rule.LogMessageIds is not null)
                {
                    foreach (var id in rule.LogMessageIds)
                    {
                        logIds.Add(id);
                    }
                }
            }

            metadata[group.Key] = new(
                group.First().SettingsTab,
                examples.ToList(),
                logIds.ToList());
        }

        return metadata;
    }

    private static (string Label, string? Help) ResolveLabelAndHelp(string propertyName)
    {
        if (TryGetGoldSaucerLabelAndHelp(propertyName, out var goldSaucerLabel, out var goldSaucerHelp))
        {
            return (goldSaucerLabel, goldSaucerHelp);
        }

        if (TryGetMovedTabLabelAndHelp(propertyName, out var movedLabel, out var movedHelp))
        {
            return (movedLabel, movedHelp);
        }

        var labelProperty = FindBestLanguageProperty(propertyName, false);
        if (labelProperty is null)
        {
            return (FormatPropertyName(propertyName), null);
        }

        var label = (string)labelProperty.GetValue(null)!;
        var helpProperty = FindPairedHelpProperty(labelProperty.Name);
        var help = helpProperty is null ? null : (string)helpProperty.GetValue(null)!;
        if (help is not null)
        {
            if (UiHelp.ShouldAppendLootFilterNote(helpProperty!.Name))
            {
                help = UiHelp.WithLootFilterNote(help);
            }
            else if (UiHelp.ShouldAppendObtainedFilterNote(helpProperty!.Name))
            {
                help = UiHelp.WithObtainedFilterNote(help);
            }
            else if (UiHelp.ShouldAppendSystemFilterNote(helpProperty.Name))
            {
                help = UiHelp.WithSystemFilterNote(help);
            }
        }

        return (label, help);
    }

    private static bool TryGetGoldSaucerLabelAndHelp(string propertyName, out string label, out string? help)
    {
        label = string.Empty;
        help = null;

        var labelKey = propertyName switch
        {
            "HideObtainedMGP" => nameof(Languages.GoldSaucerTab_ShowMGPMessages),
            "ShowGoldSaucerSwingMinigames" => nameof(Languages.GoldSaucerTab_ShowSwingMinigames),
            "ShowTripleTriadAllowed" => nameof(Languages.GoldSaucerTab_ShowTripleTriadAllowed),
            "ShowTripleTriadNotAllowed" => nameof(Languages.GoldSaucerTab_ShowTripleTriadNotAllowed),
            _ => null
        };

        if (labelKey is null)
        {
            return false;
        }

        var labelProperty = LanguageProperties.FirstOrDefault(p =>
            p.PropertyType == typeof(string) &&
            string.Equals(p.Name, labelKey, StringComparison.Ordinal));
        if (labelProperty is null)
        {
            return false;
        }

        label = (string)labelProperty.GetValue(null)!;
        var helpProperty = FindPairedHelpProperty(labelProperty.Name);
        if (helpProperty is not null)
        {
            help = (string)helpProperty.GetValue(null)!;
            if (UiHelp.ShouldAppendObtainedFilterNote(helpProperty.Name))
            {
                help = UiHelp.WithObtainedFilterNote(help);
            }
            else if (UiHelp.ShouldAppendSystemFilterNote(helpProperty.Name))
            {
                help = UiHelp.WithSystemFilterNote(help);
            }
        }

        return true;
    }

    private static bool TryGetMovedTabLabelAndHelp(string propertyName, out string label, out string? help)
    {
        label = string.Empty;
        help = null;

        var labelKey = propertyName switch
        {
            "ShowCompletedVenture" => nameof(Languages.EconomyTab_ShowCompletedVenture),
            "ShowRetainerVentureMessages" => nameof(Languages.EconomyTab_ShowRetainerVentureMessages),
            "ShowMarketGilEntrustedToRetainer" => nameof(Languages.EconomyTab_ShowMarketGilEntrustedToRetainer),
            "ShowUserLogins" => nameof(Languages.FreeCompanyTab_ShowLoginMessages),
            "ShowUserLogouts" => nameof(Languages.FreeCompanyTab_ShowLogoutMessages),
            "ShowFreeCompanyMessageBook" => nameof(Languages.FreeCompanyTab_ShowFreeCompanyMessageBookMessages),
            "ShowExploratoryVoyage" => nameof(Languages.FreeCompanyTab_ShowAirshipVoyageMessages),
            "ShowSubaquaticVoyage" => nameof(Languages.FreeCompanyTab_ShowSubmarineVoyageMessages),
            "ShowSubaquaticVoyageEmbarked" => nameof(Languages.FreeCompanyTab_ShowSubaquaticVoyageEmbarked),
            "ShowSubaquaticVoyageFinalized" => nameof(Languages.FreeCompanyTab_ShowSubaquaticVoyageFinalized),
            "ShowSubaquaticVoyageOtherFinalized" =>
                nameof(Languages.FreeCompanyTab_ShowSubaquaticVoyageOtherFinalized),
            "ShowSubaquaticVoyageReturned" => nameof(Languages.FreeCompanyTab_ShowSubaquaticVoyageReturned),
            "ShowSubmarinePartRepaired" => nameof(Languages.FreeCompanyTab_ShowSubmarinePartRepaired),
            "ShowSubmarineAttainsRank" => nameof(Languages.FreeCompanyTab_ShowSubmarineAttainsRank),
            "ShowSubmarineRetrievalLevelsIncreased" =>
                nameof(Languages.FreeCompanyTab_ShowSubmarineRetrievalLevelsIncreased),
            _ => null
        };

        if (labelKey is null)
        {
            return false;
        }

        var labelProperty = LanguageProperties.FirstOrDefault(p =>
            p.PropertyType == typeof(string) &&
            string.Equals(p.Name, labelKey, StringComparison.Ordinal));
        if (labelProperty is null)
        {
            return false;
        }

        label = (string)labelProperty.GetValue(null)!;
        var helpProperty = FindPairedHelpProperty(labelProperty.Name);
        if (helpProperty is not null)
        {
            help = (string)helpProperty.GetValue(null)!;
            if (UiHelp.ShouldAppendObtainedFilterNote(helpProperty.Name))
            {
                help = UiHelp.WithObtainedFilterNote(help);
            }
            else if (UiHelp.ShouldAppendSystemFilterNote(helpProperty.Name))
            {
                help = UiHelp.WithSystemFilterNote(help);
            }
        }

        return true;
    }

    private static PropertyInfo? FindPairedHelpProperty(string labelPropertyName)
    {
        var helpName = $"{labelPropertyName}HelpMarker";
        return LanguageProperties.FirstOrDefault(p =>
            p.PropertyType == typeof(string) &&
            string.Equals(p.Name, helpName, StringComparison.Ordinal));
    }

    private static PropertyInfo? FindBestLanguageProperty(string propertyName, bool helpMarker)
    {
        var terms = ExtractTerms(propertyName);
        PropertyInfo? best = null;
        var bestScore = 0;

        foreach (var property in LanguageProperties)
        {
            if (property.PropertyType != typeof(string))
            {
                continue;
            }

            var isHelp = property.Name.EndsWith("HelpMarker", StringComparison.Ordinal);
            if (isHelp != helpMarker)
            {
                continue;
            }

            var score = ScoreLanguageProperty(property.Name, terms);
            if (score <= bestScore)
            {
                continue;
            }

            bestScore = score;
            best = property;
        }

        return bestScore > 0 ? best : null;
    }

    private static int ScoreLanguageProperty(string languagePropertyName, string[] terms)
    {
        var score = 0;
        foreach (var term in terms)
        {
            if (term.Length < 3)
            {
                continue;
            }

            if (languagePropertyName.Contains(term, StringComparison.OrdinalIgnoreCase))
            {
                score += term.Length;
            }
        }

        return score;
    }

    private static string[] ExtractTerms(string propertyName)
    {
        var terms = new List<string>();
        foreach (var part in SplitCamelCase(propertyName))
        {
            if (part is "Show" or "Hide" or "Filter" or "Better" or "Enable" or "Disable")
            {
                continue;
            }

            if (part.EndsWith('s') && part.Length > 4)
            {
                terms.Add(part[..^1]);
            }

            terms.Add(part);
        }

        return terms.ToArray();
    }

    private static IEnumerable<string> SplitCamelCase(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            yield break;
        }

        var current = new StringBuilder();
        for (var i = 0; i < value.Length; i++)
        {
            var c = value[i];
            if (char.IsUpper(c) && current.Length > 0)
            {
                yield return current.ToString();
                current.Clear();
            }

            current.Append(c);
        }

        if (current.Length > 0)
        {
            yield return current.ToString();
        }
    }

    private static string FormatPropertyName(string propertyName) =>
        string.Join(' ', SplitCamelCase(propertyName));

    private static string FormatRuleLocation(string settingsTab) => settingsTab switch
    {
        "System" => Languages.ConfigWindow_SystemTabHeader,
        "Currencies" => Languages.ConfigWindow_CurrenciesTabHeader,
        "Allied Societies" => Languages.ConfigWindow_AlliedSocietiesTabHeader,
        "Gold Saucer" => Languages.ConfigWindow_GoldSaucerTabHeader,
        "Progress" => Languages.ConfigWindow_ProgressTabHeader,
        "Combat" => Languages.ConfigWindow_CombatTabHeader,
        "Crafting" => Languages.ConfigWindow_CraftingTabHeader,
        "Desynthesis" => Languages.ConfigWindow_DesynthesisTabHeader,
        "Gathering" => Languages.ConfigWindow_GatheringTabHeader,
        "Materia" => Languages.ConfigWindow_MateriaTabHeader,
        "Exploration" => Languages.ConfigWindow_ExplorationTabHeader,
        "Housing" => Languages.ConfigWindow_HousingTabHeader,
        "Glamour" => Languages.ConfigWindow_GlamourTabHeader,
        "Deep Dungeons" => Languages.ConfigWindow_DeepDungeonsTabHeader,
        "General" => Languages.ConfigWindow_GeneralTabHeader,
        "Emotes" => Languages.ConfigWindow_EmotesTabHeader,
        "Party" => Languages.ConfigWindow_PartyTabHeader,
        "Duty" => Languages.ConfigWindow_DutyTabHeader,
        "Free Company" => Languages.ConfigWindow_FreeCompanyTabHeader,
        "Economy" => Languages.ConfigWindow_EconomyTabHeader,
        _ => settingsTab
    };

    private static string InferLocation(string propertyName) =>
        TryGetInferredLocation(propertyName) ?? Languages.ConfigWindow_GeneralTabHeader;

    private static string? TryGetInferredLocation(string propertyName)
    {
        if (propertyName.StartsWith("Filter", StringComparison.Ordinal) ||
            propertyName.StartsWith("Better", StringComparison.Ordinal) ||
            propertyName.StartsWith("Include", StringComparison.Ordinal) ||
            propertyName is "EnableSmolMode" or
                "NormalizeBlocks" or
                "AlwaysNormalizeBlocks")
        {
            return Languages.ConfigWindow_GeneralTabHeader;
        }

        if (propertyName is "HideObtainedGil" or
            "HideObtainedSeals" or
            "HideObtainedVenture" or
            "ShowObtainedItems" or
            "ShowObtainedQuestItems" or
            "HideInventoryItemAdded" or
            "ShowInventoryItemAdded" or
            "HideObtainedWolfMarks" or
            "HideObtainedAlliedSeals" or
            "HideObtainedCenturioSeals" or
            "HideObtainedNuts")
        {
            return Languages.ConfigWindow_CurrenciesTabHeader;
        }

        if (propertyName is "HideObtainedMaterials")
        {
            return $"{Languages.ConfigWindow_AlliedSocietiesTabHeader} > {Languages.AlliedSocietiesTab_MaterialsDropdownHeader}";
        }

        if (propertyName is "HideObtainedTribalCurrency")
        {
            return $"{Languages.ConfigWindow_AlliedSocietiesTabHeader} > {Languages.AlliedSocietiesTab_CurrenciesDropdownHeader}";
        }

        if (propertyName is "ShowCastLot" or
            "ShowLootRoll" or
            "ShowOthersCastLot" or
            "ShowOthersLootRoll" or
            "ShowOnlyPartyMemberRolls" or
            "HideOthersObtain")
        {
            return $"{Languages.ConfigWindow_PartyTabHeader} > {Languages.PartyTab_LootingAndRollingDropdownHeader}";
        }

        if (propertyName is "HideObtainedClusters")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_CrackedClustersDropdownHeader}";
        }

        if (propertyName is "HideObtainedShards")
        {
            return $"{Languages.ConfigWindow_GatheringTabHeader} > {Languages.GatheringTab_ElementalShardsDropdownHeader}";
        }

        if (propertyName is "HideObtainedMGP" or
            "ShowGoldSaucerSwingMinigames" or
            "ShowTripleTriadAllowed" or
            "ShowTripleTriadNotAllowed")
        {
            return Languages.ConfigWindow_GoldSaucerTabHeader;
        }

        if (propertyName is "ShowUserLogins" or
            "ShowUserLogouts" or
            "ShowFreeCompanyMessageBook" or
            "ShowExploratoryVoyage" or
            "ShowSubaquaticVoyage" or
            "ShowSubaquaticVoyageEmbarked" or
            "ShowSubaquaticVoyageFinalized" or
            "ShowSubaquaticVoyageOtherFinalized" or
            "ShowSubaquaticVoyageReturned" or
            "ShowSubmarinePartRepaired" or
            "ShowSubmarineAttainsRank" or
            "ShowSubmarineRetrievalLevelsIncreased")
        {
            return Languages.ConfigWindow_FreeCompanyTabHeader;
        }

        if (propertyName is "ShowCompletedVenture" or
            "ShowRetainerVentureMessages" or
            "ShowMarketGilEntrustedToRetainer")
        {
            return $"{Languages.ConfigWindow_EconomyTabHeader} > {Languages.EconomyTab_RetainerSectionHeader}";
        }

        if (propertyName is "ShowDesynthesisLevel" or
            "ShowDesynthedItem" or
            "ShowDesynthesisObtains")
        {
            return Languages.ConfigWindow_DesynthesisTabHeader;
        }

        if (propertyName is "ShowAttachedMateria" or
            "ShowOvermeldFailure" or
            "ShowMateriaRetrieved" or
            "ShowMateriaShatters" or
            "ShowMateriaExtract")
        {
            return Languages.ConfigWindow_MateriaTabHeader;
        }

        if (propertyName is "ShowCraftingSynthesisComplete" or
            "ShowTrialMessages" or
            "ShowOtherSynthesis" or
            "ShowAllOtherCrafting" or
            "ShowCraftingBuffEffectGain" or
            "ShowCraftingAbleToExecute")
        {
            return Languages.ConfigWindow_CraftingTabHeader;
        }

        if (propertyName.StartsWith("ShowGathering", StringComparison.Ordinal) ||
            propertyName is "ShowCaughtFish" or
                "ShowMooching" or
                "ShowLocationAffects" or
                "ShowMeasuringIlms" or
                "ShowCurrentFishingHole" or
                "ShowDiscoveredFishingHole" or
                "ShowLureMessages" or
                "ShowFishingFlavorText" or
                "ShowAetherialReductionSands" or
                "ShowAetherialReductionSuccess" or
                "ShowAetherialReductionMinigame" or
                "ShowStellarMissionMessages" or
                "ShowStellarAbleToExecute" or
                "ShowStellarBuffEffectGain" or
                "ShowGatheringBuffEffectGain" or
                "ShowCosmicExplorationMessages" or
                "ShowCosmicRewards" or
                "ShowCosmicContainers" or
                "ShowCosmicClassPointsAndDataset" or
                "ShowCosmicDailyProgress")
        {
            return Languages.ConfigWindow_GatheringTabHeader;
        }

        if (propertyName.StartsWith("EnableDebug", StringComparison.Ordinal) ||
            propertyName is "DebugIncludeChannel")
        {
            return $"{Languages.ConfigWindow_ToolsTabHeader} > {Languages.ToolsTab_DebugDropdownHeader}";
        }

        if (propertyName is "ShowFirstClearAward" or "ShowSecondChanceAward")
        {
            return Languages.ConfigWindow_ProgressTabHeader;
        }

        if (propertyName.StartsWith("ChatHistory", StringComparison.Ordinal) ||
            propertyName is "DisableSelfChatHistory")
        {
            return $"{Languages.ConfigWindow_ToolsTabHeader} > {Languages.ToolsTab_ChatHistoryDropdownHeader}";
        }

        if (propertyName is "SentByWhitelistPlayer" or "TargetingWhitelistPlayer")
        {
            return $"{Languages.ConfigWindow_ToolsTabHeader} > {Languages.ToolsTab_CustomFiltersDropdownHeader}";
        }

        if (propertyName.StartsWith("FilterEmote", StringComparison.Ordinal) ||
            propertyName is "ShowOtherCustomEmotes" or "ShowSelfUsedEmotes")
        {
            return Languages.ConfigWindow_EmotesTabHeader;
        }

        if (propertyName is "ShowMarketBoardMessages" or
            "ShowMarketItemSold" or
            "ShowMarketAllItemsSold" or
            "ShowMarketBoardSellingStatus" or
            "BetterMarketBoardSaleMessage")
        {
            return $"{Languages.ConfigWindow_EconomyTabHeader} > {Languages.EconomyTab_MarketBoardSectionHeader}";
        }

        if (propertyName is "ShowInstanceMessage" or
            "ShowInstancedAreaMessages" or
            "ShowDutyEndedMessage" or
            "ShowGuildhestEndedMessage" or
            "ShowLevelNoLongerSynced" or
            "ShowDutyMechanicMessages" or
            "ShowDutyObjectiveBonus")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_WorldAndInstancesDropdownHeader}";
        }

        if (propertyName is "ShowTryOnGlamour" or
            "ShowTryOnGlamourCast" or
            "ShowGlamourPlateProjected" or
            "ShowGlamourPlatePartialApply" or
            "ShowGearDyeApplied" or
            "ShowGearsetGlamourRestoreFailed" or
            "ShowGlamourAltered" or
            "ShowSpiritboundGear" or
            "ShowEligibleForCoffers")
        {
            return $"{Languages.ConfigWindow_GlamourTabHeader} > {Languages.SystemTab_GlamourAndGearDropdownHeader}";
        }

        if (propertyName is "ShowGearsetEquipped" or "ShowGearItemsRepaired" or "ShowJobChange" or "ShowPortraitMessages")
        {
            return $"{Languages.ConfigWindow_GlamourTabHeader} > {Languages.SystemTab_CharacterAndGearDropdownHeader}";
        }

        if (propertyName is "ShowSanctuaryMessage" or "ShowHousingWardMessage")
        {
            return Languages.ConfigWindow_HousingTabHeader;
        }

        if (propertyName is "ShowSRankHunt" or "ShowSSRankHunt" or "ShowHuntSlain")
        {
            return $"{Languages.ConfigWindow_ExplorationTabHeader} > {Languages.SystemTab_HuntMessagesDropdownHeader}";
        }

        if (propertyName is "ShowSearchForItemResults" or
            "ShowItemSearchResults" or
            "ShowLocationSearchResults")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_SocialStatusDropdownHeader}";
        }

        if (propertyName is "ShowEverythingElse" or "ShowChangesDiscarded" or "ShowChangesLost")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_CatchAllDropdownHeader}";
        }

        if (propertyName is "HideObtainedMGP")
        {
            return $"{Languages.ConfigWindow_GoldSaucerTabHeader} > {Languages.GoldSaucerTab_MgpDropdownHeader}";
        }

        if (propertyName is "ShowGoldSaucerSwingMinigames")
        {
            return $"{Languages.ConfigWindow_GoldSaucerTabHeader} > {Languages.GoldSaucerTab_MinigamesDropdownHeader}";
        }

        if (propertyName is "ShowTripleTriadAllowed" or "ShowTripleTriadNotAllowed")
        {
            return $"{Languages.ConfigWindow_GoldSaucerTabHeader} > {Languages.GoldSaucerTab_TripleTriadDropdownHeader}";
        }

        if (propertyName is "ShowQuestReminder" or
            "ShowSpideySenses" or
            "ShowLocationDiscovered" or
            "ShowHostilePresence" or
            "ShowAetherCompass" or
            "ShowVistaMessages")
        {
            return $"{Languages.ConfigWindow_ExplorationTabHeader} > {Languages.SystemTab_ExplorationDropdownHeader}";
        }

        if (propertyName is "ShowAetheryteTicket" or "ShowAttuneAetheryte")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_SocialAndMiscDropdownHeader}";
        }

        if (propertyName is "ShowAttachToMail")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_MailDropdownHeader}";
        }

        if (propertyName is "ShowRelicBookStep" or "ShowRelicBookComplete")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_RelicDropdownHeader}";
        }

        if (propertyName is "ShowTradeSent" or
            "ShowTradeCanceled" or
            "ShowAwaitingTradeConfirmation" or
            "ShowTradeComplete" or
            "ShowVendorSellMessages" or
            "ShowVendorPurchaseMessages" or
            "ShowGilWithdrawnMessage" or
            "ShowGilSpentMessage")
        {
            return Languages.ConfigWindow_EconomyTabHeader;
        }

        if (propertyName is "ShowCairnGlows" or
            "ShowRestoresLifeToFallen" or
            "ShowCairnActivates" or
            "ShowTransference" or
            "ShowAetherpoolIncrease" or
            "ShowAetherpoolUnchanged" or
            "ShowObtainedPomander" or
            "ShowPomanderEffects" or
            "ShowFloorNumber" or
            "ShowTrapTriggered" or
            "ShowSenseAccursedHoard" or
            "ShowDoNotSenseAccursedHoard" or
            "ShowDiscoverAccursedHoard")
        {
            return Languages.ConfigWindow_DeepDungeonsTabHeader;
        }

        if (propertyName is "ShowDutyFinder" or "ShowCompletionTime")
        {
            return Languages.ConfigWindow_DutyTabHeader;
        }

        if (propertyName.StartsWith("ShowInvite", StringComparison.Ordinal) ||
            propertyName.StartsWith("ShowJoin", StringComparison.Ordinal) ||
            propertyName.StartsWith("ShowLeft", StringComparison.Ordinal) ||
            propertyName.StartsWith("ShowParty", StringComparison.Ordinal) ||
            propertyName is "ShowOfferedTeleport" or
                "ShowCountdownTime" or
                "ShowReadyChecks" or
                "ShowNowLeaderOf" or
                "ShowSealedOff")
        {
            return Languages.ConfigWindow_PartyTabHeader;
        }

        return null;
    }

    private static bool Contains(string query, string? value) =>
        !string.IsNullOrEmpty(value) &&
        value.Contains(query, StringComparison.OrdinalIgnoreCase);

    private sealed record RuleMetadata(string SettingsTab, List<string> Examples, List<uint> LogMessageIds);

    private sealed record Entry
    (
        string Id,
        string Label,
        string? Help,
        string Location,
        string? RuleName,
        List<string> Examples,
        List<uint> LogMessageIds,
        bool CanToggle,
        bool AlwaysOn,
        Func<Configuration, bool> GetBool,
        Action<Configuration, bool> SetBool)
    {
        public bool Matches(string query)
        {
            if (Contains(query, Label) ||
                Contains(query, Help) ||
                Contains(query, Location) ||
                Contains(query, RuleName) ||
                Contains(query, Id))
            {
                return true;
            }

            foreach (var example in Examples)
            {
                if (Contains(query, example))
                {
                    return true;
                }
            }

            foreach (var id in LogMessageIds)
            {
                if (id.ToString(CultureInfo.InvariantCulture).Contains(query, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            foreach (var term in ExtractTerms(Id))
            {
                if (term.Length >= 3 && Contains(query, term))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
