using ImGuiNET;
using System;
using System.Numerics;
using TidyChat.Localization.Resources;
using TidyChat.Settings.Tabs;
using TidyStrings = TidyChat.Utility.InternalStrings;

namespace TidyChat
{
    class PluginUI : IDisposable
    {
        private Configuration configuration;

#pragma warning disable
        private bool settingsVisible = false;
        public bool SettingsVisible
        {
            get { return settingsVisible; }
            set { settingsVisible = value; }
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
                ImGui.SetNextWindowSize(new Vector2(580, 365), ImGuiCond.FirstUseEver | ImGuiCond.Appearing);
                if (!ImGui.Begin("Tidy Chat", ref settingsVisible)) return;

                if (ImGui.BeginTabBar("##tidychatConfigTabs"))
                {
                    ImGui.SameLine(ImGui.GetWindowWidth() - 55f);
                    Vector4 ColorGray = new(0.45f, 0.45f, 0.45f, 1);
                    ImGui.TextColored(ColorGray, TidyStrings.Version);
                    if (ImGui.BeginTabItem(localization.ConfigWindow_SettingsTabHeader))
                    {
                        GeneralTab.Draw(configuration);
                        SettingsTabFooter.Display(configuration, ref settingsVisible);
                    }

                    if (ImGui.BeginTabItem(localization.ConfigWindow_AdvancedSettingsTabHeader))
                    {
                        AdvancedTab.Draw(configuration);
                        SettingsTabFooter.Display(configuration, ref settingsVisible);
                    }
                    ImGui.EndTabBar();
                }
            }
            finally
            {
                ImGui.End();
            }
        }
    }
}
