using System;
using System.Collections.Generic;

namespace TidyChat;

public static partial class Rules
{
    private static readonly List<LocalizedFilterRule> _rules =
    [
        .. SystemRules,
        .. ErrorMessageRules,
        .. EmoteRules,
        .. CraftingRules,
        .. GatheringRules,
        .. CombatRules,
        .. FreeCompanyRules,
        .. OrchestrionRules,
        .. LootRules,
        .. ObtainRules,
        .. ProgressRules,
    ];

    private static readonly LocalizedFilterRule[] _allRulesCache = [.. _rules];
    public static LocalizedFilterRule[] AllRules => _allRulesCache;

    /// <summary>
    ///     Lookup from LogMessageId → list of rules that match that ID.
    ///     Built once at static init from rules that have LogMessageIds set.
    /// </summary>
    public static IReadOnlyDictionary<uint, IReadOnlyList<LocalizedFilterRule>> LogMessageIdToRules { get; private set; } = BuildLogMessageIdLookup();

    public static void RebuildLogMessageIdLookup() => LogMessageIdToRules = BuildLogMessageIdLookup();

    private static IReadOnlyDictionary<uint, IReadOnlyList<LocalizedFilterRule>> BuildLogMessageIdLookup()
    {
        // Build with mutable inner lists, then expose as read-only.
        var mutable = new Dictionary<uint, List<LocalizedFilterRule>>();
        foreach(LocalizedFilterRule rule in _rules)
        {
            if (rule.LogMessageIds is null) continue;
            foreach(uint id in rule.LogMessageIds)
            {
                if (!mutable.TryGetValue(id, out List<LocalizedFilterRule>? list))
                {
                    list = [];
                    mutable[id] = list;
                }
                list.Add(rule);
            }
        }
        var result = new Dictionary<uint, IReadOnlyList<LocalizedFilterRule>>(mutable.Count);
        foreach(KeyValuePair<uint, List<LocalizedFilterRule>> kvp in mutable)
            result[kvp.Key] = kvp.Value;
        return result;
    }

    private static readonly Dictionary<string, Func<Configuration, bool>> ConfigAccessors = new(StringComparer.Ordinal)
    {
        ["ShowTotalPlayTime"] = static _ => true,
        ["ShowSRankHunt"] = c => c.ShowSRankHunt,
        ["ShowSSRankHunt"] = c => c.ShowSSRankHunt,
        ["ShowCompletedVenture"] = c => c.ShowCompletedVenture,
        ["ShowCommendations"] = c => c.ShowCommendations,
        ["ShowInstanceMessage"] = c => c.ShowInstanceMessage,
        ["ShowSanctuaryMessage"] = c => c.ShowSanctuaryMessage,
        ["ShowHousingWardMessage"] = c => c.ShowHousingWardMessage,
        ["ShowQuestReminder"] = c => c.ShowQuestReminder,
        ["ShowQuestProgress"] = c => c.ShowQuestProgress,
        ["ShowMountMessages"] = c => c.ShowMountMessages,
        ["ShowInviteSent"] = c => c.ShowInviteSent,
        ["ShowInviteeJoins"] = c => c.ShowInviteeJoins,
        ["ShowLeftParty"] = c => c.ShowLeftParty,
        ["ShowPartyDisband"] = c => c.ShowPartyDisband,
        ["ShowPartyDissolved"] = c => c.ShowPartyDissolved,
        ["ShowInvitedBy"] = c => c.ShowInvitedBy,
        ["ShowJoinParty"] = c => c.ShowJoinParty,
        ["ShowDutyFinder"] = c => c.ShowDutyFinder,
        ["ShowHuntSlain"] = c => c.ShowHuntSlain,
        ["ShowRelicBookStep"] = c => c.ShowRelicBookStep,
        ["ShowRelicBookComplete"] = c => c.ShowRelicBookComplete,
        ["ShowOnlineStatus"] = c => c.ShowOnlineStatus,
        ["ShowAttachToMail"] = c => c.ShowAttachToMail,
        ["ShowDesynthedItem"] = c => c.ShowDesynthedItem,
        ["ShowDesynthesisObtains"] = c => c.ShowDesynthesisObtains,
        ["ShowObtainedPomander"] = c => c.ShowObtainedPomander,
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
        ["ShowReadyChecks"] = c => c.ShowReadyChecks,
        ["ShowSpideySenses"] = c => c.ShowSpideySenses,
        ["ShowAetherCompass"] = c => c.ShowAetherCompass,
        ["ShowCountdownTime"] = c => c.ShowCountdownTime,
        ["ShowSpiritboundGear"] = c => c.ShowSpiritboundGear,
        ["ShowExploratoryVoyage"] = c => c.ShowExploratoryVoyage,
        ["ShowSubaquaticVoyage"] = c => c.ShowSubaquaticVoyage,
        ["ShowVistaMessages"] = c => c.ShowVistaMessages,
        ["ShowTryOnGlamour"] = c => c.ShowTryOnGlamour,
        ["ShowEligibleForCoffers"] = c => c.ShowEligibleForCoffers,
        ["ShowFreeCompanyMessageBook"] = c => c.ShowFreeCompanyMessageBook,
        ["ShowPersonalMessageBook"] = c => c.ShowPersonalMessageBook,
        ["BetterCommendationMessage"] = c => c.BetterCommendationMessage,
        ["ShowTradeSent"] = c => c.ShowTradeSent,
        ["ShowTradeCanceled"] = c => c.ShowTradeCanceled,
        ["ShowAwaitingTradeConfirmation"] = c => c.ShowAwaitingTradeConfirmation,
        ["ShowTradeComplete"] = c => c.ShowTradeComplete,
        ["ShowNowLeaderOf"] = c => c.ShowNowLeaderOf,
        ["ShowFirstClearAward"] = c => c.ShowFirstClearAward,
        ["ShowSecondChanceAward"] = c => c.ShowSecondChanceAward,
        ["HideFateLevelSync"] = c => c.HideFateLevelSync,
        ["HideCannotExecute"] = c => c.HideCannotExecute,
        ["ShowFateDiscovery"] = c => c.ShowFateDiscovery,
        ["ShowActiveHelpEntry"] = c => c.ShowActiveHelpEntry,
        ["ShowOfferedTeleport"] = c => c.ShowOfferedTeleport,
        ["ShowGearsetEquipped"] = c => c.ShowGearsetEquipped,
        ["ShowMateriaRetrieved"] = c => c.ShowMateriaRetrieved,
        ["ShowMateriaShatters"] = c => c.ShowMateriaShatters,
        ["ShowVolumeControlMessage"] = c => c.ShowVolumeControlMessage,
        ["ShowAetherialReductionSands"] = c => c.ShowAetherialReductionSands,
        ["ShowSealedOff"] = c => c.ShowSealedOff,
        ["ShowSearchForItemResults"] = c => c.ShowSearchForItemResults,
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
        ["ShowGatheringYield"] = c => c.ShowGatheringYield,
        ["ShowGatheringAttempts"] = c => c.ShowGatheringAttempts,
        ["ShowGatherersBoon"] = c => c.ShowGatherersBoon,
        ["ShowGatheringStartEnd"] = c => c.ShowGatheringStartEnd,
        ["ShowGatheringSenses"] = c => c.ShowGatheringSenses,
        ["ShowLocationAffects"] = c => c.ShowLocationAffects,
        ["ShowCaughtFish"] = c => c.ShowCaughtFish,
        ["ShowMooching"] = c => c.ShowMooching,
        ["ShowCurrentFishingHole"] = c => c.ShowCurrentFishingHole,
        ["ShowDiscoveredFishingHole"] = c => c.ShowDiscoveredFishingHole,
        ["ShowMeasuringIlms"] = c => c.ShowMeasuringIlms,
        ["ShowLureMessages"] = c => c.ShowLureMessages,
        ["ShowAllOtherGathering"] = c => c.ShowAllOtherGathering,
        ["ShowCombatCasting"] = c => c.ShowCombatCasting,
        ["ShowCombatAbilities"] = c => c.ShowCombatAbilities,
        ["ShowCombatDamage"] = c => c.ShowCombatDamage,
        ["ShowCombatMisses"] = c => c.ShowCombatMisses,
        ["ShowCombatHealing"] = c => c.ShowCombatHealing,
        ["ShowCombatEffects"] = c => c.ShowCombatEffects,
        ["ShowCombatDefeat"] = c => c.ShowCombatDefeat,
        ["ShowCombatEnemyReady"] = c => c.ShowCombatEnemyReady,
        ["ShowCombatAdds"] = c => c.ShowCombatAdds,
        ["ShowCombatEnmity"] = c => c.ShowCombatEnmity,
        ["ShowObtainedQuestItems"] = c => c.ShowObtainedQuestItems,
        ["ShowObtainedItems"] = c => c.ShowObtainedItems,
        ["ShowUserLogins"] = c => c.ShowUserLogins,
        ["ShowUserLogouts"] = c => c.ShowUserLogouts,
        ["ShowFriendList"] = c => c.ShowFriendList,
        ["HideOrchestrionPlaying"] = c => c.HideOrchestrionPlaying,
        ["ShowLootRoll"] = c => c.ShowLootRoll,
        ["ShowCastLot"] = c => c.ShowCastLot,
        ["HideObtainedShards"] = c => c.HideObtainedShards,
        ["ShowOthersLootRoll"] = c => c.ShowOthersLootRoll,
        ["ShowOthersCastLot"] = c => c.ShowOthersCastLot,
        ["HideOthersObtain"] = c => c.HideOthersObtain,
        ["HideRouletteBonus"] = c => c.HideRouletteBonus,
        ["HideAdventurerInNeedBonus"] = c => c.HideAdventurerInNeedBonus,
        ["HideObtainedGil"] = c => c.HideObtainedGil,
        ["HideObtainedMGP"] = c => c.HideObtainedMGP,
        ["HideObtainedWolfMarks"] = c => c.HideObtainedWolfMarks,
        ["HideObtainedSeals"] = c => c.HideObtainedSeals,
        ["HideObtainedVenture"] = c => c.HideObtainedVenture,
        ["HideObtainedTribalCurrency"] = c => c.HideObtainedTribalCurrency,
        ["HideObtainedClusters"] = c => c.HideObtainedClusters,
        ["HideObtainedAlliedSeals"] = c => c.HideObtainedAlliedSeals,
        ["HideObtainedCenturioSeals"] = c => c.HideObtainedCenturioSeals,
        ["HideObtainedNuts"] = c => c.HideObtainedNuts,
        ["HideObtainedMaterials"] = c => c.HideObtainedMaterials,
        ["HideObtainedShardsFromLoot"] = c => c.HideObtainedShardsFromLoot,
        ["HideOthersObtainFromLoot"] = c => c.HideOthersObtainFromLoot,
        ["ShowCompletionTime"] = c => c.ShowCompletionTime,
        ["ShowGainExperience"] = c => c.ShowGainExperience,
        ["ShowGainPvpExp"] = c => c.ShowGainPvpExp,
        ["ShowEarnAchievement"] = c => c.ShowEarnAchievement,
        ["ShowOtherEarnedAchievement"] = c => c.ShowOtherEarnedAchievement,
        ["ShowLevelUps"] = c => c.ShowLevelUps,
        ["ShowOtherLevelUps"] = c => c.ShowOtherLevelUps,
        ["ShowAbilityUnlocks"] = c => c.ShowAbilityUnlocks,
        ["ShowDesynthesisLevel"] = c => c.ShowDesynthesisLevel,
    };

    public static void UpdateIsActiveStates(Configuration config)
    {
        foreach(LocalizedFilterRule rule in _rules)
        {
            if (ConfigAccessors.TryGetValue(rule.Name, out Func<Configuration, bool>? accessor))
            {
                rule.IsActive = accessor(config);
                rule.Error = null;
            }
            else
            {
                // Unknown rule name — default to active and log once.
                rule.IsActive = true;
                rule.Error ??= $"No config accessor for rule '{rule.Name}'";
                TidyChatPlugin.Log.Error(rule.Error);
            }
        }
    }

    /// <summary>All LogMessage IDs referenced by filter rules and custom-filter documentation.</summary>
    public static IEnumerable<uint> EnumerateReferencedLogMessageIds()
    {
        var seen = new HashSet<uint>();
        foreach(LocalizedFilterRule rule in _rules)
        {
            if (rule.LogMessageIds is null) continue;
            foreach(uint id in rule.LogMessageIds)
                seen.Add(id);
        }
        return seen;
    }
}
