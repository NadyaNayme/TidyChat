using System;
using System.Collections.Generic;
namespace TidyChat;

public static partial class Rules
{
    // Rule arrays live in Rules.*.cs partials; _rules must be built after they initialize.
    private static readonly List<LocalizedFilterRule> _rules;

    private static readonly Dictionary<string, Func<Configuration, bool>> ConfigAccessors = new(StringComparer.Ordinal)
    {
        ["ShowSRankHunt"] = _ => true,
        ["ShowSSRankHunt"] = _ => true,
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
        ["ShowInvitedBy"] = _ => true,
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
        ["ShowTrapTriggered"] = _ => true,
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
        ["ShowReadyChecks"] = _ => true,
        ["ShowSpideySenses"] = _ => true,
        ["ShowAetherCompass"] = c => c.ShowAetherCompass,
        ["ShowCountdownTime"] = _ => true,
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
        ["ShowFateDiscovery"] = _ => true,
        ["ShowActiveHelpEntry"] = c => c.ShowActiveHelpEntry,
        ["ShowOfferedTeleport"] = c => c.ShowOfferedTeleport,
        ["ShowGearsetEquipped"] = c => c.ShowGearsetEquipped,
        ["ShowMateriaRetrieved"] = c => c.ShowMateriaRetrieved,
        ["ShowMateriaShatters"] = _ => true,
        ["ShowVolumeControlMessage"] = _ => true,
        ["ShowAetherialReductionSands"] = c => c.ShowAetherialReductionSands,
        ["ShowSealedOff"] = _ => true,
        ["ShowSearchForItemResults"] = c => c.ShowSearchForItemResults,
        ["ShowAetheryteTicket"] = c => c.ShowAetheryteTicket,
        ["BetterNoviceNetworkMessage"] = c => c.BetterNoviceNetworkMessage,
        ["FilterEmoteChannel"] = c => c.FilterEmoteChannel,
        ["ShowOtherCustomEmotes"] = c => c.ShowOtherCustomEmotes,
        ["ShowAttachedMateria"] = c => c.ShowAttachedMateria,
        ["ShowOvermeldFailure"] = _ => true,
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
        ["ShowStellarMissionMessages"] = c => c.ShowStellarMissionMessages,
        ["ShowCosmicExplorationMessages"] = _ => true,
        ["ShowCosmicRewards"] = c => c.ShowCosmicRewards,
        ["ShowCosmicDailyProgress"] = c => c.ShowCosmicDailyProgress,
        ["ShowCombatCasting"] = c => c.ShowCombatCasting,
        ["ShowCombatAbilities"] = c => c.ShowCombatAbilities,
        ["ShowCombatDamage"] = c => c.ShowCombatDamage,
        ["ShowCombatMisses"] = c => c.ShowCombatMisses,
        ["ShowCombatHealing"] = c => c.ShowCombatHealing,
        ["ShowCombatEffects"] = c => c.ShowCombatEffects,
        ["ShowCombatDefeat"] = c => c.ShowCombatDefeat,
        ["ShowCombatEnemyReady"] = c => c.ShowCombatEnemyReady,
        ["ShowCombatAdds"] = _ => true,
        ["ShowCombatEnmity"] = c => c.ShowCombatEnmity,
        ["ShowObtainedQuestItems"] = _ => true,
        ["ShowObtainedItems"] = c => c.ShowObtainedItems,
        ["ShowUserLogins"] = c => c.ShowUserLogins,
        ["ShowUserLogouts"] = c => c.ShowUserLogouts,
        ["ShowFriendList"] = _ => true,
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
        ["ShowCompletionTime"] = c => c.ShowCompletionTime,
        ["ShowGainExperience"] = c => c.ShowGainExperience,
        ["ShowGainPvpExp"] = c => c.ShowGainPvpExp,
        ["ShowEarnAchievement"] = c => c.ShowEarnAchievement,
        ["ShowOtherEarnedAchievement"] = c => c.ShowOtherEarnedAchievement,
        ["ShowLevelUps"] = c => c.ShowLevelUps,
        ["ShowOtherLevelUps"] = c => c.ShowOtherLevelUps,
        ["ShowAbilityUnlocks"] = _ => true,
        ["ShowDesynthesisLevel"] = c => c.ShowDesynthesisLevel,
        ["ShowEverythingElse"] = c => c.ShowEverythingElse
    };

    static Rules()
    {
        _rules = CreateRules();
        LogMessageIdToRules = BuildLogMessageIdLookup();
    }

    public static LocalizedFilterRule[] AllRules => [.. _rules];

    /// <summary>
    ///     Maps each LogMessage ID to filter rules that reference it. Built once at startup.
    /// </summary>
    public static IReadOnlyDictionary<uint, IReadOnlyList<LocalizedFilterRule>> LogMessageIdToRules { get; private set; } =
        new Dictionary<uint, IReadOnlyList<LocalizedFilterRule>>();

    private static List<LocalizedFilterRule> CreateRules()
    {
        var rules = new List<LocalizedFilterRule>(400);
        rules.AddRange(SystemRules);
        rules.AddRange(ErrorMessageRules);
        rules.AddRange(EmoteRules);
        rules.AddRange(CraftingRules);
        rules.AddRange(GatheringRules);
        rules.AddRange(StellarRules);
        rules.AddRange(CombatRules);
        rules.AddRange(FreeCompanyRules);
        rules.AddRange(OrchestrionRules);
        rules.AddRange(LootRules);
        rules.AddRange(ObtainRules);
        rules.AddRange(ProgressRules);
        return rules;
    }

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

    /// <summary>Every LogMessage ID used by filter rules or whitelist documentation.</summary>
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
