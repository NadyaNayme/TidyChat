using Dalamud.Configuration;
using Dalamud.Plugin;
using System;

namespace TidyChat
{
    [Serializable]
    public class Configuration : IPluginConfiguration
    {
        public int Version { get; set; } = 0;
        public bool Enabled { get; set; } = true;
        public string PlayerName { get; set; } = "";
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
        public bool BetterSayReminder { get; set; } = false;
        public bool BetterCommendationMessage { get; set; } = true;
        public bool IncludeDutyNameInComms { get; set; } = true;
        #endregion

        #region Whitelisted Sytstem Messages
        public bool HideSRankHunt { get; set; } = false;
        public bool HideSSRankHunt { get; set; } = false;
        public bool HideCommendations { get; set; } = false;
        public bool HideCompletedVenture { get; set; } = false;
        public bool HideInstanceMessage { get; set; } = false;
        public bool HideQuestReminder { get; set; } = false;
        public bool HideUsedEmotes { get; set; } = false;
        public bool HideReadyChecks { get; set; } = false;
        public bool HideCountdownTime {  get; set; } = false;
        public bool HideUserLogOuts { get; set; } = false;
        public bool HideDebugTeleport { get; set; } = false;
        public bool HideSpideySenses { get; set; } = false;
        public bool HideAetherCompass { get; set; } = false;
        public bool ShowGlamoursProjected { get; set; } = false;
        public bool ShowGearsetEquipped { get; set; } = false;
        public bool ShowMateriaRetrieved { get; set; } = true;
        public bool ShowVolumeControlMessage { get; set; } = false;
        #endregion

        #region Obtained Items
        public bool ShowObtainedGil { get; set; } = false;
        public bool ShowObtainedMGP { get; set; } = false;
        public bool ShowObtainedClusters { get; set; } = false;
        public bool ShowObtainedSeals { get; set; } = false;
        public bool ShowObtainedAlliedSeals { get; set; } = false;
        public bool ShowObtainedCenturioSeals { get; set; } = false;
        public bool ShowObtainedNuts { get; set; } = false;
        public bool ShowObtainedVenture { get; set; } = false;
        public bool ShowObtainedMaterials { get; set; } = false;
        public bool ShowObtainedTribalCurrency { get; set; } = false;
        public bool ShowObtainedShards { get; set; } = false;
        public bool ShowGainExperience { get; set; } = false;
        public bool ShowRouletteBonusExperiencePoints { get; set; } = false;
        public bool ShowGainPvpExp { get; set; } = false;
        public bool ShowEarnAchievement { get; set; } = false;
        public bool ShowObtainedPoeticsTomestones { get; set; } = false;
        public bool ShowObtainedAphorismTomestones { get; set; } = false;
        public bool ShowObtainedAstronomyTomestones { get; set; } = false;
        #endregion

        #region Loot Rolls
        public bool ShowLootRoll { get; set; } = false;
        public bool ShowCastLot { get; set; } = false;
        #endregion

        #region Progression
        public bool ShowLevelUps { get; set; } = true;
        public bool ShowAbilityUnlocks { get; set; } = true;
        #endregion

        #region Crafting
        public bool ShowAttachedMateria { get; set; } = true;
        public bool ShowOvermeldFailure { get; set; } = true;
        public bool ShowMateriaShatters { get; set; } = true;
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
            this.pluginInterface!.SavePluginConfig(this);
        }
    }
}
