using ImGuiNET;
using System;
using System.Numerics;
using TidyStrings = TidyChat.Utility.InternalStrings;
using TidyChat.Settings.Tabs;

namespace TidyChat
{
    class PluginUI : IDisposable
    {
        private Configuration configuration;

        #pragma warning disable
        private bool settingsVisible = false;
        public bool SettingsVisible
        {
            get { return this.settingsVisible; }
            set { this.settingsVisible = value; }
        }
        #pragma warning restore
        public PluginUI(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public void Dispose()
        {
            // Have around in case we need it
        }

        public void Draw()
        {
            if (!SettingsVisible)
            {
                return;
            }
            try
            {
                ImGui.SetNextWindowSize(new Vector2(580, 735), ImGuiCond.FirstUseEver | ImGuiCond.Appearing); 
                if (!ImGui.Begin("Tidy Chat", ref this.settingsVisible)) return;

                if (ImGui.BeginTabBar("##tidychatConfigTabs"))
                {
                    ImGui.SameLine(ImGui.GetWindowWidth() - 55f);
                    Vector4 ColorGray = new(0.45f, 0.45f, 0.45f, 1);
                    ImGui.TextColored(ColorGray, TidyStrings.Version);
                    if (ImGui.BeginTabItem("General"))
                    {
                        GeneralTab.Draw(this.configuration);
                        SettingsTabFooter.Display(this.configuration, ref this.settingsVisible);
                    }

                    if (ImGui.BeginTabItem("System"))
                    {
                        SystemTab.Draw(this.configuration);
                        SettingsTabFooter.Display(this.configuration, ref this.settingsVisible);
                    }

                    if (ImGui.BeginTabItem("Emotes"))
                    {
                        EmotesTab.Draw(this.configuration);
                        SettingsTabFooter.Display(this.configuration, ref this.settingsVisible);
                    }

                    if (ImGui.BeginTabItem("Loot & Obtain"))
                    {
                        ObtainTab.Draw(this.configuration);
                        SettingsTabFooter.Display(this.configuration, ref this.settingsVisible);
                    }

                    if (ImGui.BeginTabItem("Progress"))
                    {
                        ProgressTab.Draw(this.configuration);
                        SettingsTabFooter.Display(this.configuration, ref this.settingsVisible);
                    }

                    if (ImGui.BeginTabItem("Crafting & Gathering"))
                    {
                        CraftingGatheringTab.Draw(this.configuration);
                        SettingsTabFooter.Display(this.configuration, ref this.settingsVisible);
                    }

                    if (ImGui.BeginTabItem("Whitelist"))
                    {
                        WhitelistTab.Draw(this.configuration);
                        SettingsTabFooter.Display(this.configuration, ref this.settingsVisible);
                    }

                    ImGui.EndTabBar();
                }
            } finally
            {
                ImGui.End();
            }
        }
    }
}
