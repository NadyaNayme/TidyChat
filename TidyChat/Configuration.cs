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
        public bool FilterSystemMessages { get; set; } = true;
        public bool FilterEmoteSpam { get; set; } = true;
        public bool BetterInstanceMessage { get; set; } = true;
        public bool BetterCommendationMessage { get; set; } = true;
        public bool IncludeDutyNameInComms { get; set; } = true;
        public bool HideSRankHunt { get; set; } = false;
        public bool HideCommendations { get; set; } = false;
        public bool HideCompletedVenture { get; set; } = false;
        public bool HideInstanceMessage { get; set; } = false;


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
