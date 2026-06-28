using Dalamud.Interface.Components;
using System.Numerics;
using System.Reflection;
using System.Text;
namespace TidyChat.Settings.Search;

internal static class SettingsSearchIndex
{
    private static readonly HashSet<string> AlwaysOnSettings = new(StringComparer.Ordinal);

    private static readonly HashSet<string> SkippedProperties = new(StringComparer.Ordinal)
    {
        "Enabled",
        "ShowGlamourAltered",
        "ShowLureMessages",
        "ShowPartyDissolved",
        "ShowPartyCountdown",
        "ShowReadyCheckMessages",
        "ShowInvalidCommandError",
        "ShowFriendListMessages",
        "ShowMgpSpending",
        "ShowPlaytime"
    };

    /// <summary>
    ///     Tab UI binds these Show* properties to Hide labels (checked = hide).
    /// </summary>
    private static readonly HashSet<string> InvertedHideLabelProperties = new(StringComparer.Ordinal)
    {
        "ShowGatheringYield",
        "ShowGatheringAttempts",
        "ShowGatherersBoon",
        "HideObtainedTribalCurrency",
        "HideOthersObtain"
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
        var terms = SplitQueryTerms(query);
        var entries = s_entries ??= BuildEntries();

        var matches = entries.Where(e => e.Matches(terms)).ToList();
        AppendTomestoneMatches(configuration, terms, matches);
        AppendTribalCurrencyMatches(configuration, terms, matches);

        ImGui.Spacing();
        if (matches.Count == 0)
        {
            ImGui.TextUnformatted(Languages.ConfigWindow_SearchNoResults);
            return;
        }

        ImGui.TextUnformatted(string.Format(CultureInfo.CurrentCulture, Languages.ConfigWindow_SearchResultCount,
            matches.Count.ToString(CultureInfo.CurrentCulture)));
        ImGui.Spacing();

        using var resultsChild = ImRaii.Child("##settingsSearchResults", new(0, 0));
        if (!resultsChild)
        {
            return;
        }

        foreach (var entry in matches.OrderBy(e => e.Location, StringComparer.OrdinalIgnoreCase)
                     .ThenBy(e => e.Label, StringComparer.OrdinalIgnoreCase))
        {
            DrawEntry(configuration, entry);
        }
    }

    private static void DrawEntry(Configuration configuration, Entry entry)
    {
        using (ImRaii.PushId(entry.Id))
        {
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
                using (ImRaii.Disabled())
                {
                    var value = true;
                    ImGui.Checkbox(entry.Label, ref value);
                }

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
        }
    }

    private static void AppendTribalCurrencyMatches(Configuration configuration, string[] terms, List<Entry> matches)
    {
        if (TidyChatPlugin.TribalCurrencies.Count == 0)
        {
            return;
        }

        foreach (var currency in TidyChatPlugin.TribalCurrencies)
        {
            if (!terms.All(term => Contains(term, currency.Name) ||
                                   Contains(term, "allied society") ||
                                   Contains(term, "beast tribe") ||
                                   Contains(term, "tribal")))
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
                Languages.ConfigWindow_AlliedSocietiesTabHeader,
                null,
                [],
                [],
                true,
                false,
                _ => hide,
                (_, value) => configuration.HideTribalCurrencyById[currency.RowId] = value));
        }
    }

    private static void AppendTomestoneMatches(Configuration configuration, string[] terms, List<Entry> matches)
    {
        if (TidyChatPlugin.Tomestones.Count == 0)
        {
            return;
        }

        foreach (var tomestone in TidyChatPlugin.Tomestones)
        {
            if (!terms.All(term => Contains(term, tomestone.Name) || Contains(term, "tomestones")))
            {
                continue;
            }

            configuration.HideTomestoneById.TryGetValue(tomestone.RowId, out var hide);
            var label = string.Format(CultureInfo.CurrentCulture, Languages.ConfigWindow_SearchHideTomestone,
                tomestone.Name);
            matches.Add(new(
                $"tomestone-{tomestone.RowId}",
                label,
                Languages.ConfigWindow_SearchHideTomestoneHelp,
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

            var inverted = InvertedHideLabelProperties.Contains(property.Name);
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
                inverted
                    ? config => !(bool)property.GetValue(config)!
                    : config => (bool)property.GetValue(config)!,
                inverted
                    ? (config, value) => property.SetValue(config, !value)
                    : (config, value) => property.SetValue(config, value)));
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
        if (SettingsPropertyLabelKeys.TryGet(propertyName) is { } labelKey &&
            TryResolveFromLabelKey(labelKey, out var mappedLabel, out var mappedHelp))
        {
            return (mappedLabel, mappedHelp);
        }

        var labelProperty = FindBestLanguageProperty(propertyName, false);
        if (labelProperty is null)
        {
            return (FormatPropertyName(propertyName), null);
        }

        var label = (string)labelProperty.GetValue(null)!;
        var helpProperty = FindPairedHelpProperty(labelProperty.Name);
        var help = helpProperty is null ? null : (string)helpProperty.GetValue(null)!;
        if (help is not null && helpProperty is not null)
        {
            help = AppendConfiguredHelpNotes(help, helpProperty.Name);
        }

        return (label, help);
    }

    private static bool TryResolveFromLabelKey(string labelKey, out string label, out string? help)
    {
        label = string.Empty;
        help = null;

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
            help = AppendConfiguredHelpNotes((string)helpProperty.GetValue(null)!, helpProperty.Name);
        }

        return true;
    }

    private static string AppendConfiguredHelpNotes(string help, string helpPropertyName)
    {
        if (UiHelp.ShouldAppendLootFilterNote(helpPropertyName))
        {
            return UiHelp.WithLootFilterNote(help);
        }

        if (UiHelp.ShouldAppendLootAndObtainedHideFilterNote(helpPropertyName))
        {
            return UiHelp.WithLootAndObtainedHideFilterNote(help);
        }

        if (UiHelp.ShouldAppendObtainedAndSystemHideFilterNote(helpPropertyName))
        {
            return UiHelp.WithObtainedAndSystemHideFilterNote(help);
        }

        if (UiHelp.ShouldAppendObtainedHideFilterNote(helpPropertyName))
        {
            return UiHelp.WithObtainedHideFilterNote(help);
        }

        if (UiHelp.ShouldAppendSystemHideFilterNote(helpPropertyName))
        {
            return UiHelp.WithSystemHideFilterNote(help);
        }

        if (UiHelp.ShouldAppendGatheringHideFilterNote(helpPropertyName))
        {
            return UiHelp.WithGatheringHideFilterNote(help);
        }

        if (UiHelp.ShouldAppendObtainedFilterNote(helpPropertyName))
        {
            return UiHelp.WithObtainedFilterNote(help);
        }

        if (UiHelp.ShouldAppendGatheringFilterNote(helpPropertyName))
        {
            return UiHelp.WithGatheringFilterNote(help);
        }

        if (UiHelp.ShouldAppendCraftingFilterNote(helpPropertyName))
        {
            return UiHelp.WithCraftingFilterNote(help);
        }

        if (UiHelp.ShouldAppendProgressAndSystemFilterNote(helpPropertyName))
        {
            return UiHelp.WithProgressAndSystemFilterNote(help);
        }

        if (UiHelp.ShouldAppendProgressFilterNote(helpPropertyName))
        {
            return UiHelp.WithProgressFilterNote(help);
        }

        if (UiHelp.ShouldAppendSystemFilterNote(helpPropertyName))
        {
            return UiHelp.WithSystemFilterNote(help);
        }

        return help;
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
        "Crafting" => Languages.ConfigWindow_CraftingTabHeader,
        "Cosmic Exploration" => Languages.ConfigWindow_CosmicExplorationTabHeader,
        "Desynthesis" => Languages.ConfigWindow_DesynthesisTabHeader,
        "Fishing" => Languages.ConfigWindow_FishingTabHeader,
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
            "HideObtainedWolfMarks" or
            "HideTomestoneWeeklyCap" or
            "HideObtainedAlliedSeals" or
            "HideObtainedCenturioSeals" or
            "HideObtainedNuts")
        {
            return Languages.ConfigWindow_CurrenciesTabHeader;
        }

        if (propertyName is "HideRouletteBonus" or
            "HideAdventurerInNeedBonus" or
            "ShowGainExperience" or
            "ShowGainMettle" or
            "ShowGainPvpExp" or
            "ShowGainPvpRank" or
            "ShowGainSeriesExp" or
            "ShowPvpZoneAnnouncements" or
            "ShowLevelUps" or
            "ShowAbilityUnlock" or
            "ShowOtherLevelUps" or
            "ShowEarnAchievement" or
            "ShowOtherEarnedAchievement" or
            "ShowFirstClearAward" or
            "ShowSecondChanceAward")
        {
            return Languages.ConfigWindow_ProgressTabHeader;
        }

        if (propertyName is "HideFateLevelSync")
        {
            return Languages.ConfigWindow_SystemTabHeader;
        }

        if (propertyName is "HideObtainedMaterials")
        {
            return Languages.ConfigWindow_AlliedSocietiesTabHeader;
        }

        if (propertyName is "HideObtainedTribalCurrency")
        {
            return Languages.ConfigWindow_AlliedSocietiesTabHeader;
        }

        if (propertyName is "ShowCastLot" or
            "ShowLootRoll" or
            "ShowOthersCastLot" or
            "ShowOthersLootRoll" or
            "ShowOnlyPartyMemberRolls" or
            "HideOthersObtain")
        {
            return Languages.ConfigWindow_PartyTabHeader;
        }

        if (propertyName is "HideObtainedClusters" or "HideObtainedShards")
        {
            return Languages.ConfigWindow_CurrenciesTabHeader;
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
            return Languages.ConfigWindow_EconomyTabHeader;
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

        if (propertyName is "ShowCaughtFish" or
            "ShowReelInLine" or
            "ShowLoseBait" or
            "ShowMooching" or
            "ShowMeasuringIlms" or
            "ShowCurrentFishingHole" or
            "ShowDiscoveredFishingHole" or
            "ShowLureAttemptMessages" or
            "ShowLureBiteFeelingMessages" or
            "ShowFishingFlavorText")
        {
            return Languages.ConfigWindow_FishingTabHeader;
        }

        if (propertyName is "ShowStellarMissionMessages" or
            "ShowStellarAbleToExecute" or
            "ShowStellarBuffEffectGain" or
            "ShowStellarGpRecovery" or
            "ShowCosmicExplorationMessages" or
            "ShowCosmicRewards" or
            "ShowCosmicContainers" or
            "ShowCosmicClassPointsAndDataset" or
            "ShowCosmicDailyProgress")
        {
            return Languages.ConfigWindow_CosmicExplorationTabHeader;
        }

        if (propertyName.StartsWith("ShowGathering", StringComparison.Ordinal) ||
            propertyName is "ShowLocationAffects" or
                "ShowAetherialReductionSands" or
                "ShowAetherialReductionSuccess" or
                "ShowAetherialReductionMinigame" or
                "ShowGatheringBuffEffectGain")
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

        if (propertyName is "EnableChatHighlights")
        {
            return $"{Languages.ConfigWindow_ToolsTabHeader} > {Languages.ToolsTab_ChatHighlightsDropdownHeader}";
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
            return Languages.ConfigWindow_EconomyTabHeader;
        }

        if (propertyName is "ShowInstanceMessage")
        {
            return Languages.ConfigWindow_DutyTabHeader;
        }

        if (propertyName is "ShowInstancedAreaMessages" or
            "ShowDutyEndedMessage" or
            "ShowGuildhestEndedMessage" or
            "ShowLevelNoLongerSynced")
        {
            return $"{Languages.ConfigWindow_DutyTabHeader} > {Languages.DutyTab_InstanceAndDutyDropdownHeader}";
        }

        if (propertyName is "ShowGlamourDresserMessages" or
            "ShowGlamourDresserOutfit" or
            "ShowGlamourDresserProjection" or
            "ShowGlamourArmoireMessages" or
            "ShowTryOnGlamour" or
            "ShowTryOnGlamourPreview" or
            "ShowTryOnGlamourCast" or
            "ShowGlamourPlateProjected" or
            "ShowGlamourPlatePartialApply" or
            "ShowGearDyeApplied" or
            "ShowGearsetGlamourRestoreFailed" or
            "ShowGearsetEquipped" or
            "ShowJobChange" or
            "ShowPortraitMessages")
        {
            return Languages.ConfigWindow_GlamourTabHeader;
        }

        if (propertyName is "ShowRelicBookStep" or "ShowRelicBookComplete")
        {
            return $"{Languages.ConfigWindow_ProgressTabHeader} > {Languages.ProgressTab_RelicsDropdownHeader}";
        }

        if (propertyName is "ShowSpiritboundGear")
        {
            return $"{Languages.ConfigWindow_MateriaTabHeader} > {Languages.MateriaTab_MateriaDropdownHeader}";
        }

        if (propertyName is "ShowGearItemsRepaired")
        {
            return $"{Languages.ConfigWindow_EconomyTabHeader} > {Languages.EconomyTab_RepairsSectionHeader}";
        }

        if (propertyName is "ShowSanctuaryMessage" or "ShowHousingWardMessage" or "ShowHousingLotteryMessage")
        {
            return Languages.ConfigWindow_HousingTabHeader;
        }

        if (propertyName is "ShowSRankHunt" or "ShowSSRankHunt" or "ShowHuntSlain" or "ShowMarkBillMessages")
        {
            return $"{Languages.ConfigWindow_ExplorationTabHeader} > {Languages.ExplorationTab_HuntMessagesDropdownHeader}";
        }

        if (propertyName is "ShowSearchForItemResults" or
            "ShowItemSearchResults" or
            "ShowLocationSearchResults")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_ItemSearchDropdownHeader}";
        }

        if (propertyName is "ShowEverythingElse")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_CatchAllDropdownHeader}";
        }

        if (propertyName is "HideObtainedMGP")
        {
            return Languages.ConfigWindow_GoldSaucerTabHeader;
        }

        if (propertyName is "ShowGoldSaucerSwingMinigames")
        {
            return Languages.ConfigWindow_GoldSaucerTabHeader;
        }

        if (propertyName is "ShowTripleTriadAllowed" or "ShowTripleTriadNotAllowed")
        {
            return Languages.ConfigWindow_GoldSaucerTabHeader;
        }

        if (propertyName is "ShowQuestReminder" or
            "ShowSpideySenses" or
            "ShowLocationDiscovered" or
            "ShowHostilePresence" or
            "ShowAetherCompass" or
            "ShowVistaMessages")
        {
            return $"{Languages.ConfigWindow_ExplorationTabHeader} > {Languages.ExplorationTab_ExplorationDropdownHeader}";
        }

        if (propertyName is "ShowCommendations")
        {
            return Languages.ConfigWindow_PartyTabHeader;
        }

        if (propertyName is "ShowPersonalMessageBook" or "ShowOnlineStatus")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_SocialDropdownHeader}";
        }

        if (propertyName is "ShowAetheryteTicket")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_TravelDropdownHeader}";
        }

        if (propertyName is "ShowAttachToMail")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_MailDropdownHeader}";
        }

        if (propertyName is "HideOrchestrionPlaying" or "ShowVolumeControlMessages")
        {
            return $"{Languages.ConfigWindow_SystemTabHeader} > {Languages.SystemTab_OrchestrionDropdownHeader}";
        }

        if (propertyName is "ShowTradeSent" or
            "ShowTradeCanceled" or
            "ShowAwaitingTradeConfirmation" or
            "ShowTradeRequestReceived" or
            "ShowTradeReceiveItems" or
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

        if (propertyName.StartsWith("ShowInvite", StringComparison.Ordinal) ||
            propertyName.StartsWith("ShowJoin", StringComparison.Ordinal) ||
            propertyName.StartsWith("ShowLeft", StringComparison.Ordinal) ||
            propertyName.StartsWith("ShowParty", StringComparison.Ordinal) ||
            propertyName is "ShowOfferedTeleport")
        {
            return Languages.ConfigWindow_PartyTabHeader;
        }

        if (propertyName is "ShowDutyFinder" or "ShowCompletionTime")
        {
            return $"{Languages.ConfigWindow_DutyTabHeader} > {Languages.DutyTab_DutyFinderDropdownHeader}";
        }

        return null;
    }

    private static string[] SplitQueryTerms(string query) =>
        query.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    private static bool Contains(string term, string? value) =>
        !string.IsNullOrEmpty(value) &&
        value.Contains(term, StringComparison.OrdinalIgnoreCase);

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
        public bool Matches(string[] queryTerms) => queryTerms.All(MatchesTerm);

        private bool MatchesTerm(string term)
        {
            if (Contains(term, Label) ||
                Contains(term, Help) ||
                Contains(term, Location) ||
                Contains(term, RuleName) ||
                Contains(term, Id))
            {
                return true;
            }

            foreach (var example in Examples)
            {
                if (Contains(term, example))
                {
                    return true;
                }
            }

            foreach (var id in LogMessageIds)
            {
                if (id.ToString(CultureInfo.InvariantCulture).Contains(term, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            foreach (var idTerm in ExtractTerms(Id))
            {
                if (idTerm.Length >= 3 && Contains(term, idTerm))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
