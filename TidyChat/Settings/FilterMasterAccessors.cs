namespace TidyChat;

/// <summary>
///     Combines UI master toggles with nested child settings for rule active state.
///     Child checkbox values are preserved when a master is off; they only take effect when the master is on.
/// </summary>
internal static class FilterMasterAccessors
{
    public static bool MarketItemSold(Configuration c) =>
        c.ShowMarketBoardMessages && c.ShowMarketItemSold;

    public static bool MarketAllItemsSold(Configuration c) =>
        c.ShowMarketBoardMessages && c.ShowMarketAllItemsSold;

    public static bool MarketBoardSellingStatus(Configuration c) =>
        c.ShowMarketBoardMessages && c.ShowMarketBoardSellingStatus;

    public static bool InstancedAreaMessages(Configuration c) =>
        c.ShowInstanceMessage && c.ShowInstancedAreaMessages;

    public static bool DutyEndedMessage(Configuration c) =>
        c.ShowInstanceMessage && c.ShowDutyEndedMessage;

    public static bool GuildhestEndedMessage(Configuration c) =>
        c.ShowInstanceMessage && c.ShowGuildhestEndedMessage;

    public static bool LevelNoLongerSynced(Configuration c) =>
        c.ShowInstanceMessage && c.ShowLevelNoLongerSynced;

    public static bool DutyMechanicMessages(Configuration c) =>
        c.ShowInstanceMessage && c.ShowDutyMechanicMessages;

    public static bool DutyObjectiveBonus(Configuration c) =>
        c.ShowInstanceMessage && c.ShowDutyObjectiveBonus;

    public static bool TryOnGlamourCast(Configuration c) =>
        c.ShowTryOnGlamour && c.ShowTryOnGlamourCast;

    public static bool GlamourPlateProjected(Configuration c) =>
        c.ShowTryOnGlamour && c.ShowGlamourPlateProjected;

    public static bool GlamourPlatePartialApply(Configuration c) =>
        c.ShowTryOnGlamour && c.ShowGlamourPlatePartialApply;

    public static bool GearDyeApplied(Configuration c) =>
        c.ShowTryOnGlamour && c.ShowGearDyeApplied;

    public static bool GearsetGlamourRestoreFailed(Configuration c) =>
        c.ShowTryOnGlamour && c.ShowGearsetGlamourRestoreFailed;

    public static bool GlamourAltered(Configuration c) =>
        c.ShowTryOnGlamour && c.ShowGlamourAltered;

    public static bool ItemSearchResults(Configuration c) =>
        c.ShowSearchForItemResults && c.ShowItemSearchResults;

    public static bool LocationSearchResults(Configuration c) =>
        c.ShowSearchForItemResults && c.ShowLocationSearchResults;

    public static bool ChangesDiscarded(Configuration c) =>
        c.ShowEverythingElse && c.ShowChangesDiscarded;

    public static bool ChangesLost(Configuration c) =>
        c.ShowEverythingElse && c.ShowChangesLost;

    public static bool TripleTriadAllowed(Configuration c) => c.ShowTripleTriadAllowed;

    public static bool TripleTriadNotAllowed(Configuration c) => c.ShowTripleTriadNotAllowed;

    public static bool SubaquaticVoyageEmbarked(Configuration c) =>
        c.ShowSubaquaticVoyage && c.ShowSubaquaticVoyageEmbarked;

    public static bool SubaquaticVoyageFinalized(Configuration c) =>
        c.ShowSubaquaticVoyage && c.ShowSubaquaticVoyageFinalized;

    public static bool SubaquaticVoyageOtherFinalized(Configuration c) =>
        c.ShowSubaquaticVoyage && c.ShowSubaquaticVoyageOtherFinalized;

    public static bool SubaquaticVoyageReturned(Configuration c) =>
        c.ShowSubaquaticVoyage && c.ShowSubaquaticVoyageReturned;

    public static bool SubmarinePartRepaired(Configuration c) =>
        c.ShowSubaquaticVoyage && c.ShowSubmarinePartRepaired;

    public static bool SubmarineAttainsRank(Configuration c) =>
        c.ShowSubaquaticVoyage && c.ShowSubmarineAttainsRank;

    public static bool SubmarineRetrievalLevelsIncreased(Configuration c) =>
        c.ShowSubaquaticVoyage && c.ShowSubmarineRetrievalLevelsIncreased;

    public static bool CraftingBuffEffectGain(Configuration c) =>
        c.ShowAllOtherCrafting && c.ShowCraftingBuffEffectGain;

    public static bool CraftingAbleToExecute(Configuration c) =>
        c.ShowAllOtherCrafting && c.ShowCraftingAbleToExecute;

    public static bool GatheringBuffEffectGain(Configuration c) =>
        c.ShowAllOtherGathering && c.ShowGatheringBuffEffectGain;

    public static bool StellarAbleToExecute(Configuration c) =>
        c.ShowStellarMissionMessages && c.ShowStellarAbleToExecute;

    public static bool StellarBuffEffectGain(Configuration c) =>
        c.ShowStellarMissionMessages && c.ShowStellarBuffEffectGain;

    public static bool OthersLootRoll(Configuration c) => c.ShowOthersLootRoll;

    public static bool OnlyPartyMemberLootRolls(Configuration c) =>
        c.ShowOthersLootRoll && c.ShowOnlyPartyMemberRolls;
}
