using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Dalamud.Configuration;
using Dalamud.Game.Gui.Dtr;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using FFXIVClientStructs;
using FFXIVClientStructs.Havok.Common.Base.Reflection;

namespace TidyChat;

[Serializable]
public class Configuration : IPluginConfiguration
{
    // the below exist just to make saving less cumbersome

    [NonSerialized] private IDalamudPluginInterface? pluginInterface;

    public ulong TtlMessagesBlocked { get; set; } = 0;
    public bool Enabled { get; set; } = true;
    public bool EnableDebugMode { get; set; } = false;
    public bool DebugIncludeChannel { get; set; } = false;
    public bool EnableInverseMode { get; set; } = false;
    public bool IncludeChatTag { get; set; } = true;
    public string PlayerName { get; set; } = "";
    public IList<PlayerName> Whitelist { get; set; } = [];
    public bool SentByWhitelistPlayer { get; set; } = true;
    public bool TargetingWhitelistPlayer { get; set; } = true;
    public bool ChatHistoryFilter { get; set; } = false;
    public int ChatHistoryChannels { get; set; } = 2;
    public int ChatHistoryLength { get; set; } = 10;
    public int ChatHistoryTimer { get; set; } = 10;
    public bool DisableSelfChatHistory { get; set; } = true;
    public bool NoCoffee { get; set; } = false;
    public int Version { get; set; } = 0;

    public void Initialize(IDalamudPluginInterface pluginInterface)
    {
        this.pluginInterface = pluginInterface;
    }

    public T? GetPropertyValue<T>(object obj, string propName) {
        return (T?)obj?.GetType()?.GetProperty(propName)?.GetValue(this, index: null); 
    }

    public void Save()
    {
        pluginInterface!.SavePluginConfig(this);
        Rules.UpdateIsActiveStates(this);
        TidyChatPlugin.InstanceDtrBarUpdate(TidyChatPlugin.GetDtrBar(), this);
    }

    #region Chat Filters

    public bool FilterSystemMessages { get; set; } = true;
    public bool FilterEmoteSpam { get; set; } = true;
    public bool FilterObtainedSpam { get; set; } = true;
    public bool FilterLootSpam { get; set; } = true;
    public bool FilterProgressSpam { get; set; } = true;
    public bool FilterCraftingSpam { get; set; } = true;

    #endregion

    #region Better Messaging

    public bool BetterInstanceMessage { get; set; } = true;
    public bool UseDTRBar { get; set; } = false;
    public bool DTRIsEnabled { get; set; } = false;
    public bool InstanceInDtrBar { get; set; } = false;
    public bool BetterSayReminder { get; set; } = false;
    public bool CopyBetterSayReminder { get; set; } = false;
    public bool BetterCommendationMessage { get; set; } = true;
    public bool IncludeDutyNameInComms { get; set; } = true;
    public bool BetterNoviceNetworkMessage { get; set; } = true;

    #endregion

    #region Whitelisted System Messages

    public bool ShowSRankHunt { get; set; } = true;
    public bool ShowSSRankHunt { get; set; } = true;
    public bool ShowCommendations { get; set; } = true;
    public bool ShowCompletedVenture { get; set; } = true;
    public bool ShowInstanceMessage { get; set; } = true;
    public bool ShowQuestReminder { get; set; } = true;
    public bool ShowUsedEmotes { get; set; } = true;
    public bool ShowOtherCustomEmotes { get; set; } = true;
    public bool ShowReadyChecks { get; set; } = true;
    public bool ShowCountdownTime { get; set; } = true;
    public bool ShowUserLogins { get; set; } = true;
    public bool ShowUserLogouts { get; set; } = true;
    public bool ShowDebugTeleport { get; set; } = true;
    public bool ShowSpiritboundGear { get; set; } = true;
    public bool ShowSpideySenses { get; set; } = true;
    public bool ShowAetherCompass { get; set; } = true;
    public bool ShowSearchForItemResults { get; set; } = true;
    public bool ShowExploratoryVoyage { get; set; } = true;
    public bool ShowSubaquaticVoyage { get; set; } = true;
    public bool ShowFreeCompanyMessageBook { get; set; } = true;
    public bool ShowPersonalMessageBook { get; set; } = true;
    public bool ShowVistaMessages { get; set; } = true;
    public bool ShowTryOnGlamour { get; set; } = true;
    public bool ShowEligibleForCoffers { get; set; } = true;
    public bool ShowGlamoursProjected { get; set; } = false;
    public bool ShowGearsetEquipped { get; set; } = false;
    public bool ShowMateriaRetrieved { get; set; } = true;
    public bool ShowVolumeControlMessage { get; set; } = false;
    public bool ShowTradeSent { get; set; } = false;
    public bool ShowTradeCanceled { get; set; } = false;
    public bool ShowAwaitingTradeConfirmation { get; set; } = false;
    public bool ShowTradeComplete { get; set; } = false;
    public bool ShowInviteSent { get; set; } = false;
    public bool ShowInviteeJoins { get; set; } = false;
    public bool ShowLeftParty { get; set; } = false;
    public bool ShowPartyDisband { get; set; } = false;
    public bool ShowPartyDissolved { get; set; } = false;
    public bool ShowInvitedBy { get; set; } = false;
    public bool ShowJoinParty { get; set; } = false;
    public bool ShowOfferedTeleport { get; set; } = false;
    public bool ShowSealedOff { get; set; } = false;
    public bool ShowHuntSlain { get; set; } = false;
    public bool ShowCompletionTime { get; set; } = false;
    public bool ShowRelicBookStep { get; set; } = false;
    public bool ShowRelicBookComplete { get; set; } = false;
    public bool ShowOnlineStatus { get; set; } = false;
    public bool ShowAttachToMail { get; set; } = false;
    public bool ShowNowLeaderOf { get; set; } = false;
    public bool ShowFirstClearAward { get; set; } = false;
    public bool ShowSecondChanceAward { get; set; } = false;
    public bool ShowNoviceNetworkFull { get; set; } = true;

    #endregion

    #region PotD & HoH

    public bool ShowObtainedPomander { get; set; } = true;
    public bool ShowReturnedPomander { get; set; } = false;
    public bool ShowCairnGlows { get; set; } = true;
    public bool ShowRestoresLifeToFallen { get; set; } = false;
    public bool ShowCairnActivates { get; set; } = true;
    public bool ShowTransference { get; set; } = false;
    public bool ShowAetherpoolIncrease { get; set; } = true;
    public bool ShowAetherpoolUnchanged { get; set; } = false;
    public bool ShowPomanderOfSafety { get; set; } = true;
    public bool ShowPomanderOfSight { get; set; } = true;
    public bool ShowPomanderOfAffluence { get; set; } = true;
    public bool ShowPomanderOfFlight { get; set; } = true;
    public bool ShowPomanderOfAlteration { get; set; } = true;
    public bool ShowPomanderOfWitching { get; set; } = true;
    public bool ShowPomanderOfSerenity { get; set; } = true;
    public bool ShowFloorNumber { get; set; } = true;
    public bool ShowSenseAccursedHoard { get; set; } = true;
    public bool ShowDoNotSenseAccursedHoard { get; set; } = false;
    public bool ShowDiscoverAccursedHoard { get; set; } = true;

    #endregion PotD & HoH

    #region Obtained Items

    public bool ShowObtainedGil { get; set; } = false;
    public bool ShowObtainedMGP { get; set; } = false;
    public bool ShowObtainedClusters { get; set; } = false;
    public bool ShowObtainedWolfMarks { get; set; } = false;
    public bool ShowObtainedSeals { get; set; } = false;
    public bool ShowObtainedAlliedSeals { get; set; } = false;
    public bool ShowObtainedCenturioSeals { get; set; } = false;
    public bool ShowObtainedNuts { get; set; } = false;
    public bool ShowObtainedVenture { get; set; } = false;
    public bool ShowObtainedMaterials { get; set; } = false;
    public bool ShowObtainedTribalCurrency { get; set; } = false;
    public bool ShowObtainedShards { get; set; } = false;
    public bool ShowGainExperience { get; set; } = false;
    public bool ShowRouletteBonus { get; set; } = false;
    public bool ShowAdventurerInNeedBonus { get; set; } = false;
    public bool ShowGainPvpExp { get; set; } = false;
    public bool ShowEarnAchievement { get; set; } = false;
    public bool ShowOtherEarnedAchievement { get; set; } = false;
    public bool ShowObtainedPoeticsTomestones { get; set; } = false;
    public bool ShowObtainedAphorismTomestones { get; set; } = false;
    public bool ShowObtainedAstronomyTomestones { get; set; } = false;

    #endregion

    #region Loot Rolls

    public bool ShowLootRoll { get; set; } = false;
    public bool ShowCastLot { get; set; } = false;
    public bool ShowOthersLootRoll { get; set; } = false;
    public bool ShowOthersCastLot { get; set; } = false;
    public bool ShowOthersObtain { get; set; } = false;

    #endregion

    #region Progression

    public bool ShowLevelUps { get; set; } = true;
    public bool ShowOtherLevelUps { get; set; } = false;
    public bool ShowAbilityUnlocks { get; set; } = true;

    #endregion

    #region Crafting

    public bool ShowAttachedMateria { get; set; } = true;
    public bool ShowOvermeldFailure { get; set; } = true;
    public bool ShowMateriaShatters { get; set; } = true;
    public bool ShowMateriaExtract { get; set; } = true;
    public bool ShowDesynthesisLevel { get; set; } = false;
    public bool ShowDesynthedItem { get; set; } = false;
    public bool ShowDesynthesisObtains { get; set; } = false;
    public bool ShowTrialMessages { get; set; } = true;
    public bool ShowOtherSynthesis { get; set; } = false;

    #endregion

    #region Gathering

    public bool FilterGatheringSpam { get; set; } = false;
    public bool ShowGatheringSenses { get; set; } = true;
    public bool ShowAetherialReductionSands { get; set; } = true;
    public bool ShowLocationAffects { get; set; } = true;
    public bool ShowGatheringStartEnd { get; set; } = true;
    public bool ShowGatheringYield { get; set; } = true;
    public bool ShowGatherersBoon { get; set; } = true;
    public bool ShowGatheringAttempts { get; set; } = true;
    public bool ShowCaughtFish { get; set; } = true;
    public bool ShowMooching { get; set; } = true;
    public bool ShowCurrentFishingHole { get; set; } = true;
    public bool ShowDiscoveredFishingHole { get; set; } = true;
    public bool ShowMeasuringIlms { get; set; } = true;

    #endregion
}
