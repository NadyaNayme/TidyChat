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
        #region Chat Filters
        public bool FilterSystemMessages { get; set; } = true;
        public bool FilterEmoteSpam { get; set; } = true;
        public bool FilterObtainedSpam { get; set; } = true;
        #endregion
        #region Better Messaging
        public bool BetterInstanceMessage { get; set; } = true;
        public bool BetterCommendationMessage { get; set; } = true;
        public bool IncludeDutyNameInComms { get; set; } = true;
        #endregion

        #region Whitelisted Sytstem Messages
        public bool HideSRankHunt { get; set; } = false;
        public bool HideCommendations { get; set; } = false;
        public bool HideCompletedVenture { get; set; } = false;
        public bool HideInstanceMessage { get; set; } = false;
        public bool HideSayQuestReminder { get; set; } = false;
        public bool HideUsedEmotes { get; set; } = false;
        #endregion

        #region Obtained Items
        public bool HideObtainedGil { get; set; } = true;
        public bool HideObtainedClusters { get; set; } = true;
        public bool HideObtainedSeals { get; set; } = true;
        public bool HideObtainedNuts { get; set; } = true;
        public bool HideObtainedVenture { get; set; } = true;
        public bool HideObtainedMaterials { get; set; } = true;
        public bool HideObtainedShards { get; set; } = true;
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
