using System.IO;
using System.Text.Json;
using Dalamud.Plugin;
namespace TidyChat.Settings;

internal static class ConfigurationMigration
{
    public static void ApplyPreV5(Configuration config, IDalamudPluginInterface pluginInterface)
    {
        if (config.Version >= 5)
            return;

        ApplyLegacyJsonFields(config, pluginInterface);

        config.ShowStellarMissionMessages =
            config.ShowAllOtherGathering || config.ShowEverythingElse;
        config.ShowCosmicRewards = config.ShowObtainedItems;
        config.ShowCosmicDailyProgress =
            config.ShowGainExperience && config.ShowQuestProgress;

        config.ShowCosmicExplorationMessages =
            config.ShowStellarMissionMessages || config.ShowAllOtherGathering;

        config.ShowSSRankHunt = config.ShowSRankHunt || config.ShowSSRankHunt;
        config.ShowUserLogouts = config.ShowUserLogins || config.ShowUserLogouts;
        config.ShowSubaquaticVoyage = config.ShowExploratoryVoyage || config.ShowSubaquaticVoyage;
        config.ShowTradeCanceled = config.ShowTradeSent || config.ShowTradeCanceled;
        config.ShowAwaitingTradeConfirmation = config.ShowTradeSent || config.ShowAwaitingTradeConfirmation;
        config.ShowTradeComplete = config.ShowTradeSent || config.ShowTradeComplete;
        config.ShowRelicBookComplete = config.ShowRelicBookStep || config.ShowRelicBookComplete;
        config.ShowDesynthedItem = config.ShowDesynthesisLevel || config.ShowDesynthedItem;
        config.ShowDesynthesisObtains = config.ShowDesynthesisLevel || config.ShowDesynthesisObtains;
        config.HideAdventurerInNeedBonus = config.HideRouletteBonus || config.HideAdventurerInNeedBonus;
        config.ShowLootRoll = config.ShowCastLot || config.ShowLootRoll;
        config.ShowOthersLootRoll = config.ShowOthersCastLot || config.ShowOthersLootRoll;
        config.ShowOtherEarnedAchievement = config.ShowEarnAchievement || config.ShowOtherEarnedAchievement;
        config.FilterCustomEmoteChannel = config.FilterEmoteChannel || config.FilterCustomEmoteChannel;

        if (config.ShowGearsetEquipped)
        {
            config.ShowJobChange = true;
            config.ShowPortraitMessages = true;
        }

        if (config.ShowMarketBoardMessages)
            config.ShowMarketBoardSellingStatus = true;
    }

    public static void ApplyVersion6(Configuration config)
    {
        if (config.ShowMarketBoardMessages)
            config.ShowMarketGilEntrustedToRetainer = true;
    }

    public static void ApplyVersion8(Configuration config)
    {
        if (config.ShowCosmicRewards)
            config.ShowCosmicContainers = true;
    }

    public static void ApplyVersion9(Configuration config)
    {
        if (config.ShowMarketBoardMessages)
        {
            config.ShowMarketItemSold = true;
            config.ShowMarketAllItemsSold = true;
        }

        if (config.ShowSpideySenses)
        {
            config.ShowLocationDiscovered = true;
            config.ShowHostilePresence = true;
        }

        if (config.ShowAetheryteTicket)
            config.ShowAttuneAetheryte = true;
    }

    public static void ApplyVersion10(Configuration config)
    {
        if (config.ShowInstanceMessage)
        {
            config.ShowInstancedAreaMessages = true;
            config.ShowDutyEndedMessage = true;
            config.ShowGuildhestEndedMessage = true;
            config.ShowLevelNoLongerSynced = true;
            config.ShowDutyMechanicMessages = true;
            config.ShowDutyObjectiveBonus = true;
        }

        if (config.ShowEverythingElse)
        {
            config.ShowChangesDiscarded = true;
            config.ShowChangesLost = true;
            config.ShowTripleTriadAllowed = true;
            config.ShowTripleTriadNotAllowed = true;
        }

        if (config.ShowSubaquaticVoyage)
        {
            config.ShowSubaquaticVoyageEmbarked = true;
            config.ShowSubaquaticVoyageFinalized = true;
            config.ShowSubaquaticVoyageOtherFinalized = true;
            config.ShowSubaquaticVoyageReturned = true;
            config.ShowSubmarinePartRepaired = true;
            config.ShowSubmarineAttainsRank = true;
            config.ShowSubmarineRetrievalLevelsIncreased = true;
        }

        if (config.ShowTryOnGlamour)
        {
            config.ShowTryOnGlamourCast = true;
            config.ShowGlamourPlateProjected = true;
            config.ShowGlamourPlatePartialApply = true;
            config.ShowGearDyeApplied = true;
            config.ShowGearsetGlamourRestoreFailed = true;
            config.ShowGlamourAltered = true;
        }

        if (config.ShowSearchForItemResults)
        {
            config.ShowItemSearchResults = true;
            config.ShowLocationSearchResults = true;
        }

        if (config.ShowAllOtherCrafting)
        {
            config.ShowCraftingBuffEffectGain = true;
            config.ShowCraftingAbleToExecute = true;
        }

        if (config.ShowAllOtherGathering)
            config.ShowGatheringBuffEffectGain = true;

        if (config.ShowStellarMissionMessages)
        {
            config.ShowStellarAbleToExecute = true;
            config.ShowStellarBuffEffectGain = true;
        }
    }

    public static void ApplyVersion11(Configuration config)
    {
        if (config.ShowCosmicDailyProgress)
            config.ShowCosmicClassPointsAndDataset = true;
    }

    public static void ApplyVersion12(Configuration config)
    {
        config.ShowGatheringCollectableObtains = config.ShowObtainedItems;
    }

    private static void ApplyLegacyJsonFields(Configuration config, IDalamudPluginInterface pluginInterface)
    {
        string path = Path.Combine(pluginInterface.ConfigDirectory.FullName, $"{pluginInterface.InternalName}.json");
        if (!File.Exists(path))
            return;

        try
        {
            using var doc = JsonDocument.Parse(File.ReadAllText(path));
            JsonElement root = doc.RootElement;
            if (TryGetBool(root, "HideObtainedShardsFromLoot") == true)
                config.HideObtainedShards = true;
            if (TryGetBool(root, "HideOthersObtainFromLoot") == true)
                config.HideOthersObtain = true;
        }
        catch
        { }
    }

    private static bool? TryGetBool(JsonElement root, string name)
    {
        if (!root.TryGetProperty(name, out JsonElement el))
            return null;
        return el.ValueKind switch
        {
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            _ => null
        };
    }
}
