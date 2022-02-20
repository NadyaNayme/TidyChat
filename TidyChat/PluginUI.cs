﻿using ImGuiNET;
using System;
using System.Numerics;
using TidyStrings = TidyChat.Utility.InternalStrings;
using TidyChat.Settings.Tabs;

namespace TidyChat
{
    class PluginUI : IDisposable
    {
        private Configuration configuration;

        private bool visible = false;
        public bool Visible
        {
            get { return this.visible; }
            set { this.visible = value; }
        }

        private bool settingsVisible = false;
        public bool SettingsVisible
        {
            get { return this.settingsVisible; }
            set { this.settingsVisible = value; }
        }

        public PluginUI(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public void Dispose()
        {

        }

        public void Draw()
        {
            if (!SettingsVisible)
            {
                return;
            }
            try
            {
                ImGui.SetNextWindowSize(new Vector2(560, 500), ImGuiCond.FirstUseEver);
                if (!ImGui.Begin("Tidy Chat", ref this.settingsVisible)) return;

                if (ImGui.BeginTabBar("##tidychatConfigTabs"))
                {
                    ImGui.SameLine(ImGui.GetWindowWidth() - 55f);
                    Vector4 ColorGray = new Vector4(0.45f, 0.45f, 0.45f, 1);
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

                    if (ImGui.BeginTabItem("Obtain"))
                    {
                        ObtainTab.Draw(this.configuration);
                        SettingsTabFooter.Display(this.configuration, ref this.settingsVisible);
                    }

                    if (ImGui.BeginTabItem("Loot"))
                    {
                        LootTab.Draw(this.configuration);
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

                    ImGui.EndTabBar();
                }
            } finally
            {
                ImGui.End();
            }
        }
    }
}
