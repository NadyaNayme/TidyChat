using Dalamud.Configuration;
using Dalamud.Plugin;
using System;
using System.Collections.Generic;

namespace TidyChat
{
    [Serializable]
    public class Configuration : IPluginConfiguration
    {
        public int Version { get; set; } = 0;
        public ulong TotalMessagesBlocked { get; set; } = 0; // To be removed next update
        public ulong TtlMessagesBlocked { get; set; } = 0;
        public bool Enabled { get; set; } = true;
        public bool EnableDebugMode { get; set; } = false;
        public bool EnableInverseMode { get; set; } = false;
        public bool IncludeChatTag { get; set; } = true;
        public string PlayerName { get; set; } = "";
        public List<PlayerName> Whitelist { get; set; } = new();
        public bool SentByWhitelistPlayer { get; set; } = true;
        public bool TargetingWhitelistPlayer { get; set; } = true;
        public bool ChatHistoryFilter { get; set; } = false;
        public int ChatHistoryChannels { get; set; } = 2;
        public int ChatHistoryLength { get; set; } = 10;
        public int ChatHistoryTimer { get; set; } = 10;
        public bool DisableSelfChatHistory { get; set; } = true;
        public bool NoCoffee { get; set; } = false;
        public bool EnableTippyTips { get; set; } = false;
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
        public bool HideSRankHunt { get; set; } = false;
        public bool HideSSRankHunt { get; set; } = false;
        public bool HideCommendations { get; set; } = false;
        public bool HideCompletedVenture { get; set; } = false;
        public bool HideInstanceMessage { get; set; } = false;
        public bool HideQuestReminder { get; set; } = false;
        public bool HideUsedEmotes { get; set; } = false;
        public bool HideOtherCustomEmotes { get; set; } = false;
        public bool HideReadyChecks { get; set; } = false;
        public bool HideCountdownTime { get; set; } = false;
        public bool HideUserLogins { get; set; } = false;
        public bool HideUserLogouts { get; set; } = false;
        public bool HideDebugTeleport { get; set; } = false;
        public bool HideSpideySenses { get; set; } = false;
        public bool HideAetherCompass { get; set; } = false;
        public bool HideSearchForItemResults { get; set; } = false;
        public bool HideExploratoryVoyage { get; set; } = false;
        public bool HideSubaquaticVoyage { get; set; } = false;
        public bool HideVistaMessages { get; set; } = false;
        public bool HideTryOnGlamour { get; set; } = true;
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
        public bool ShowDesynthesisObtains { get; set; } = false;
        public bool ShowTrialMessages { get; set; } = true;
        public bool ShowOtherSynthesis { get; set; } = false;
        #endregion

        #region Gathering
        public bool FilterGatheringSpam { get; set; } = false;
        public bool ShowAetherialReductionSands { get; set; } = true;
        public bool ShowLocationAffects { get; set; } = true;
        public bool HideGatheringYield { get; set; } = true;
        public bool HideGatherersBoon { get; set; } = true;
        public bool HideGatheringAttempts { get; set; } = true;
        public bool ShowCaughtFish { get; set; } = true;
        public bool ShowMeasuringIlms { get; set; } = true;
        #endregion
        // the below exist just to make saving less cumbersome

        [NonSerialized]
        private DalamudPluginInterface? pluginInterface;

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            this.pluginInterface = pluginInterface;
        }

        public void Save()
        {
            pluginInterface!.SavePluginConfig(this);
        }
    }
}
