namespace TidyChat;

public static partial class Rules
{
    private static readonly List<LocalizedFilterRule> _rules;

    private static readonly Dictionary<string, Func<Configuration, bool>> ConfigAccessors = new(StringComparer.Ordinal)
    {
        ["ShowSRankHunt"] = c => c.ShowSRankHunt,
        ["ShowSSRankHunt"] = c => c.ShowSSRankHunt,
        ["ShowCompletedVenture"] = c => c.ShowCompletedVenture,
        ["ShowRetainerVentureMessages"] = c => c.ShowRetainerVentureMessages,
        ["ShowCommendations"] = c => c.ShowCommendations,
        ["ShowInstancedAreaMessages"] = FilterMasterAccessors.InstancedAreaMessages,
        ["ShowDutyEndedMessage"] = FilterMasterAccessors.DutyEndedMessage,
        ["ShowGuildhestEndedMessage"] = FilterMasterAccessors.GuildhestEndedMessage,
        ["ShowLevelNoLongerSynced"] = FilterMasterAccessors.LevelNoLongerSynced,
        ["ShowSanctuaryMessage"] = c => c.ShowSanctuaryMessage,
        ["ShowHousingWardMessage"] = c => c.ShowHousingWardMessage,
        ["ShowQuestReminder"] = c => c.ShowQuestReminder,
        ["ShowInviteSent"] = c => c.ShowInviteSent,
        ["ShowInviteeJoins"] = c => c.ShowInviteeJoins,
        ["ShowLeftParty"] = c => c.ShowLeftParty,
        ["ShowPartyDisband"] = c => c.ShowPartyDisband,
        ["ShowPartyDissolved"] = c => c.ShowPartyDissolved,
        ["ShowInvitedBy"] = c => c.ShowInvitedBy,
        ["ShowJoinParty"] = c => c.ShowJoinParty,
        ["ShowDutyFinder"] = c => c.ShowDutyFinder,
        ["ShowCompletionTime"] = c => c.ShowCompletionTime,
        ["ShowHuntSlain"] = c => c.ShowHuntSlain,
        ["ShowMarkBillMessages"] = c => c.ShowMarkBillMessages,
        ["ShowRelicBookStep"] = c => c.ShowRelicBookStep,
        ["ShowRelicBookComplete"] = c => c.ShowRelicBookComplete,
        ["ShowOnlineStatus"] = c => c.ShowOnlineStatus,
        ["ShowAttachToMail"] = c => c.ShowAttachToMail,
        ["ShowDesynthedItem"] = c => c.ShowDesynthedItem,
        ["ShowDesynthesisObtains"] = c => c.ShowDesynthesisObtains,
        ["ShowObtainedPomander"] = c => c.ShowObtainedPomander,
        ["ShowTrapTriggered"] = c => c.ShowTrapTriggered,
        ["ShowCairnGlows"] = c => c.ShowCairnGlows,
        ["ShowRestoresLifeToFallen"] = c => c.ShowRestoresLifeToFallen,
        ["ShowCairnActivates"] = c => c.ShowCairnActivates,
        ["ShowTransference"] = c => c.ShowTransference,
        ["ShowAetherpoolIncrease"] = c => c.ShowAetherpoolIncrease,
        ["ShowAetherpoolUnchanged"] = c => c.ShowAetherpoolUnchanged,
        ["ShowPomanderEffects"] = c => c.ShowPomanderEffects,
        ["ShowFloorNumber"] = c => c.ShowFloorNumber,
        ["ShowSenseAccursedHoard"] = c => c.ShowSenseAccursedHoard,
        ["ShowDoNotSenseAccursedHoard"] = c => c.ShowDoNotSenseAccursedHoard,
        ["ShowDiscoverAccursedHoard"] = c => c.ShowDiscoverAccursedHoard,
        ["ShowSpideySenses"] = c => c.ShowSpideySenses,
        ["ShowLocationDiscovered"] = c => c.ShowLocationDiscovered,
        ["ShowHostilePresence"] = c => c.ShowHostilePresence,
        ["ShowAetherCompass"] = c => c.ShowAetherCompass,
        ["ShowSpiritboundGear"] = c => c.ShowSpiritboundGear,
        ["ShowExploratoryVoyage"] = c => c.ShowExploratoryVoyage,
        ["ShowSubaquaticVoyageEmbarked"] = FilterMasterAccessors.SubaquaticVoyageEmbarked,
        ["ShowSubaquaticVoyageFinalized"] = FilterMasterAccessors.SubaquaticVoyageFinalized,
        ["ShowSubaquaticVoyageOtherFinalized"] = FilterMasterAccessors.SubaquaticVoyageOtherFinalized,
        ["ShowSubaquaticVoyageReturned"] = FilterMasterAccessors.SubaquaticVoyageReturned,
        ["ShowSubmarinePartRepaired"] = FilterMasterAccessors.SubmarinePartRepaired,
        ["ShowSubmarineAttainsRank"] = FilterMasterAccessors.SubmarineAttainsRank,
        ["ShowSubmarineRetrievalLevelsIncreased"] = FilterMasterAccessors.SubmarineRetrievalLevelsIncreased,
        ["ShowVistaMessages"] = c => c.ShowVistaMessages,
        ["ShowVolumeControlMessages"] = c => c.ShowVolumeControlMessages,
        ["ShowGlamourDresserOutfit"] = FilterMasterAccessors.GlamourDresserOutfit,
        ["ShowGlamourDresserProjection"] = FilterMasterAccessors.GlamourDresserProjection,
        ["ShowGlamourArmoireMessages"] = FilterMasterAccessors.GlamourArmoireMessages,
        ["ShowTryOnGlamourPreview"] = FilterMasterAccessors.TryOnGlamourPreview,
        ["ShowTryOnGlamourCast"] = FilterMasterAccessors.TryOnGlamourCast,
        ["ShowGlamourPlateProjected"] = FilterMasterAccessors.GlamourPlateProjected,
        ["ShowGlamourPlatePartialApply"] = FilterMasterAccessors.GlamourPlatePartialApply,
        ["ShowGearDyeApplied"] = FilterMasterAccessors.GearDyeApplied,
        ["ShowGearsetGlamourRestoreFailed"] = FilterMasterAccessors.GearsetGlamourRestoreFailed,
        ["ShowJobChange"] = c => c.ShowJobChange,
        ["ShowPortraitMessages"] = c => c.ShowPortraitMessages,
        ["ShowFreeCompanyMessageBook"] = c => c.ShowFreeCompanyMessageBook,
        ["ShowPersonalMessageBook"] = c => c.ShowPersonalMessageBook,
        ["ShowTradeSent"] = c => c.ShowTradeSent,
        ["ShowTradeCanceled"] = c => c.ShowTradeCanceled,
        ["ShowAwaitingTradeConfirmation"] = c => c.ShowAwaitingTradeConfirmation,
        ["ShowTradeRequestReceived"] = c => c.ShowTradeRequestReceived,
        ["ShowTradeReceiveItems"] = c => c.ShowTradeReceiveItems,
        ["ShowTradeComplete"] = c => c.ShowTradeComplete,
        ["ShowFirstClearAward"] = c => c.ShowFirstClearAward,
        ["ShowSecondChanceAward"] = c => c.ShowSecondChanceAward,
        ["HideFateLevelSync"] = c => c.HideFateLevelSync,
        ["ShowActiveHelpEntry"] = c => c.ShowActiveHelpEntry,
        ["ShowOfferedTeleport"] = c => c.ShowOfferedTeleport,
        ["ShowVendorSellMessages"] = c => c.ShowVendorSellMessages,
        ["ShowVendorPurchaseMessages"] = c => c.ShowVendorPurchaseMessages,
        ["ShowMarketItemSold"] = FilterMasterAccessors.MarketItemSold,
        ["ShowMarketAllItemsSold"] = FilterMasterAccessors.MarketAllItemsSold,
        ["ShowMarketGilEntrustedToRetainer"] = c => c.ShowMarketGilEntrustedToRetainer,
        ["ShowMarketBoardSellingStatus"] = FilterMasterAccessors.MarketBoardSellingStatus,
        ["ShowGilWithdrawnMessage"] = c => c.ShowGilWithdrawnMessage,
        ["ShowGilSpentMessage"] = c => c.ShowGilSpentMessage,
        ["ShowDutyCommenceMessage"] = c => c.BetterDutyCommenceMessage,
        ["HideDutyCommenceBriefing"] = c => c.BetterDutyCommenceMessage,
        ["ShowGearsetEquipped"] = c => c.ShowGearsetEquipped,
        ["ShowGearItemsRepaired"] = c => c.ShowGearItemsRepaired,
        ["ShowMateriaRetrieved"] = c => c.ShowMateriaRetrieved,
        ["ShowMateriaShatters"] = c => c.ShowMateriaShatters,
        ["ShowAetherialReductionSands"] = c => c.ShowAetherialReductionSands,
        ["ShowAetherialReductionSuccess"] = c => c.ShowAetherialReductionSuccess,
        ["ShowAetherialReductionMinigame"] = c => c.ShowAetherialReductionMinigame,
        ["ShowItemSearchResults"] = FilterMasterAccessors.ItemSearchResults,
        ["ShowLocationSearchResults"] = FilterMasterAccessors.LocationSearchResults,
        ["ShowAetheryteTicket"] = c => c.ShowAetheryteTicket,
        ["BetterNoviceNetworkMessage"] = c => c.BetterNoviceNetworkMessage,
        ["FilterEmoteChannel"] = c => c.FilterEmoteChannel,
        ["ShowOtherCustomEmotes"] = c => c.ShowOtherCustomEmotes,
        ["ShowAttachedMateria"] = c => c.ShowAttachedMateria,
        ["ShowOvermeldFailure"] = c => c.ShowOvermeldFailure,
        ["ShowMateriaExtract"] = c => c.ShowMateriaExtract,
        ["ShowTrialMessages"] = c => c.ShowTrialMessages,
        ["ShowOtherSynthesis"] = c => c.ShowOtherSynthesis,
        ["ShowCraftingSynthesisComplete"] = c => c.ShowCraftingSynthesisComplete,
        ["ShowAllOtherCrafting"] = c => c.ShowAllOtherCrafting,
        ["ShowCraftingBuffEffectGain"] = FilterMasterAccessors.CraftingBuffEffectGain,
        ["ShowCraftingAbleToExecute"] = FilterMasterAccessors.CraftingAbleToExecute,
        ["ShowGatheringYield"] = c => c.ShowGatheringYield,
        ["ShowGatheringAttempts"] = c => c.ShowGatheringAttempts,
        ["ShowGatherersBoon"] = c => c.ShowGatherersBoon,
        ["ShowGatheringStartEnd"] = c => c.ShowGatheringStartEnd,
        ["ShowGatheringSenses"] = c => c.ShowGatheringSenses,
        ["ShowGatheringCollectableObtains"] = c => c.ShowGatheringCollectableObtains,
        ["ShowLocationAffects"] = c => c.ShowLocationAffects,
        ["ShowCaughtFish"] = c => c.ShowCaughtFish,
        ["ShowReelInLine"] = c => c.ShowReelInLine,
        ["ShowLoseBait"] = c => c.ShowLoseBait,
        ["ShowMooching"] = c => c.ShowMooching,
        ["ShowCurrentFishingHole"] = c => c.ShowCurrentFishingHole,
        ["ShowDiscoveredFishingHole"] = c => c.ShowDiscoveredFishingHole,
        ["ShowMeasuringIlms"] = c => c.ShowMeasuringIlms,
        ["ShowLureAttemptMessages"] = c => c.ShowLureAttemptMessages,
        ["ShowLureBiteFeelingMessages"] = c => c.ShowLureBiteFeelingMessages,
        ["ShowAllOtherGathering"] = c => c.ShowAllOtherGathering,
        ["ShowGatheringBuffEffectGain"] = FilterMasterAccessors.GatheringBuffEffectGain,
        ["ShowStellarMissionMessages"] = c => c.ShowStellarMissionMessages,
        ["ShowStellarAbleToExecute"] = FilterMasterAccessors.StellarAbleToExecute,
        ["ShowStellarBuffEffectGain"] = FilterMasterAccessors.StellarBuffEffectGain,
        ["ShowStellarGpRecovery"] = FilterMasterAccessors.StellarGpRecovery,
        ["ShowCosmicExplorationMessages"] = c => c.ShowCosmicExplorationMessages,
        ["ShowCosmicRewards"] = c => c.ShowCosmicRewards,
        ["ShowCosmicContainers"] = c => c.ShowCosmicContainers,
        ["ShowCosmicClassPointsAndDataset"] = c => c.ShowCosmicClassPointsAndDataset,
        ["ShowCosmicDailyProgress"] = c => c.ShowCosmicDailyProgress,
        ["ShowObtainedQuestItems"] = c => c.ShowObtainedQuestItems,
        ["ShowObtainedItems"] = c => c.ShowObtainedItems,
        ["HideInventoryItemAdded"] = c => c.HideInventoryItemAdded,
        ["ShowInventoryItemAdded"] = c => !c.HideInventoryItemAdded,
        ["ShowUserLogins"] = c => c.ShowUserLogins,
        ["ShowUserLogouts"] = c => c.ShowUserLogouts,
        ["HideOrchestrionPlaying"] = c => c.HideOrchestrionPlaying,
        ["ShowLootRoll"] = c => c.ShowLootRoll,
        ["ShowCastLot"] = c => c.ShowCastLot,
        ["HideObtainedShards"] = c => c.HideObtainedShards,
        ["ShowOthersLootRoll"] = FilterMasterAccessors.OthersLootRoll,
        ["ShowOthersCastLot"] = c => c.ShowOthersCastLot,
        ["HideOthersObtain"] = c => c.HideOthersObtain,
        ["HideRouletteBonus"] = c => c.HideRouletteBonus,
        ["HideAdventurerInNeedBonus"] = c => c.HideAdventurerInNeedBonus,
        ["HideObtainedGil"] = c => c.HideObtainedGil,
        ["HideObtainedMGP"] = c => c.HideObtainedMGP,
        ["ShowMgpSpending"] = c => !c.HideObtainedMGP,
        ["ShowGoldSaucerSwingMinigames"] = c => c.ShowGoldSaucerSwingMinigames,
        ["HideObtainedWolfMarks"] = c => c.HideObtainedWolfMarks,
        ["HideTomestoneWeeklyCap"] = c => c.HideTomestoneWeeklyCap,
        ["HideObtainedSeals"] = c => c.HideObtainedSeals,
        ["HideObtainedVenture"] = c => c.HideObtainedVenture,
        ["HideObtainedTribalCurrency"] = c => c.HideObtainedTribalCurrency,
        ["HideObtainedClusters"] = c => c.HideObtainedClusters,
        ["HideObtainedAlliedSeals"] = c => c.HideObtainedAlliedSeals,
        ["HideObtainedCenturioSeals"] = c => c.HideObtainedCenturioSeals,
        ["HideObtainedNuts"] = c => c.HideObtainedNuts,
        ["HideObtainedMaterials"] = c => c.HideObtainedMaterials,
        ["ShowGainExperience"] = c => c.ShowGainExperience,
        ["ShowGainMettle"] = c => c.ShowGainMettle,
        ["ShowGainPvpExp"] = c => c.ShowGainPvpExp,
        ["ShowGainPvpRank"] = c => c.ShowGainPvpRank,
        ["ShowGainSeriesExp"] = c => c.ShowGainSeriesExp,
        ["ShowPvpZoneAnnouncements"] = c => c.ShowPvpZoneAnnouncements,
        ["ShowEarnAchievement"] = c => c.ShowEarnAchievement,
        ["ShowOtherEarnedAchievement"] = c => c.ShowOtherEarnedAchievement,
        ["ShowLevelUps"] = c => c.ShowLevelUps,
        ["ShowOtherLevelUps"] = c => c.ShowOtherLevelUps,
        ["ShowDesynthesisLevel"] = c => c.ShowDesynthesisLevel,
        ["ShowTripleTriadAllowed"] = FilterMasterAccessors.TripleTriadAllowed,
        ["ShowTripleTriadNotAllowed"] = FilterMasterAccessors.TripleTriadNotAllowed
    };

    static Rules()
    {
        _rules = CreateRules();
        LogMessageIdToRules = BuildLogMessageIdLookup();
    }

    public static LocalizedFilterRule[] AllRules => [.. _rules];

    public static IReadOnlyDictionary<uint, IReadOnlyList<LocalizedFilterRule>> LogMessageIdToRules { get; private set; } =
        new Dictionary<uint, IReadOnlyList<LocalizedFilterRule>>();

    private static List<LocalizedFilterRule> CreateRules()
    {
        var rules = new List<LocalizedFilterRule>(400);
        AddSystemRules(rules);
        rules.AddRange(DutyCommenceRules);
        rules.AddRange(ErrorMessageRules);
        rules.AddRange(EmotesRules);
        rules.AddRange(MateriaCraftChannelRules);
        rules.AddRange(CraftingMessageRules);
        rules.AddRange(MateriaSystemChannelRules);
        rules.AddRange(GatheringAetherialReductionRules);
        AddGatheringRules(rules);
        rules.AddRange(CosmicExplorationRules);
        rules.AddRange(FreeCompanyRules);
        rules.AddRange(OrchestrionRules);
        AddLootRules(rules);
        AddObtainRules(rules);
        rules.AddRange(GoldSaucerRules);
        rules.AddRange(ProgressRules);
        return rules;
    }

    public static void RebuildLogMessageIdLookup() => LogMessageIdToRules = BuildLogMessageIdLookup();

    private static IReadOnlyDictionary<uint, IReadOnlyList<LocalizedFilterRule>> BuildLogMessageIdLookup()
    {
        var mutable = new Dictionary<uint, List<LocalizedFilterRule>>();
        foreach (var rule in _rules)
        {
            if (rule.LogMessageIds is null)
            {
                continue;
            }
            foreach (var id in rule.LogMessageIds)
            {
                if (!mutable.TryGetValue(id, out var list))
                {
                    list = [];
                    mutable[id] = list;
                }
                list.Add(rule);
            }
        }
        var result = new Dictionary<uint, IReadOnlyList<LocalizedFilterRule>>(mutable.Count);
        foreach (var kvp in mutable)
        {
            result[kvp.Key] = kvp.Value;
        }
        return result;
    }

    public static void UpdateIsActiveStates(Configuration config)
    {
        foreach (var rule in _rules)
        {
            if (ConfigAccessors.TryGetValue(rule.Name, out var accessor))
            {
                rule.IsActive = accessor(config);
                rule.Error = null;
            }
            else
            {
                rule.IsActive = true;
                rule.Error ??= $"No config accessor for rule '{rule.Name}'";
                TidyChatPlugin.Log.Error(rule.Error);
            }
        }
    }

    public static IEnumerable<uint> EnumerateReferencedLogMessageIds()
    {
        var seen = new HashSet<uint>();
        foreach (var rule in _rules)
        {
            if (rule.LogMessageIds is null)
            {
                continue;
            }
            foreach (var id in rule.LogMessageIds)
            {
                seen.Add(id);
            }
        }
        return seen;
    }
}
