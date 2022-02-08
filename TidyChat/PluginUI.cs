using ImGuiNET;
using System;
using System.Numerics;
using Dalamud.Interface;
using Dalamud.Interface.Components;

namespace TidyChat
{
    // It is good to have this be disposable in general, in case you ever need it
    // to do any cleanup
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
            DrawMainWindow();
            DrawSettingsWindow();
        }

        public void DrawMainWindow()
        {
            if (!Visible)
            {
                return;
            }

            ImGui.SetNextWindowSize(new Vector2(375, 330), ImGuiCond.FirstUseEver);
            ImGui.SetNextWindowSizeConstraints(new Vector2(375, 330), new Vector2(float.MaxValue, float.MaxValue));
            if (ImGui.Begin("TidyChat", ref this.visible, ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse))
            {
                if (ImGui.Button("Show Settings"))
                {
                    SettingsVisible = true;
                }
            }
            ImGui.End();
        }

        public void DrawSettingsWindow()
        {
            if (!SettingsVisible)
            {
                return;
            }

            ImGui.SetNextWindowSize(new Vector2(560, 415), ImGuiCond.FirstUseEver);
            if (ImGui.Begin("TidyChat Settings", ref this.settingsVisible))
            {
                var enabled = this.configuration.Enabled;
                if (ImGui.Checkbox("Enable filters", ref enabled))
                {
                    this.configuration.Enabled = enabled;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("This should be left on unless testing or debugging.");
                var filterSystemMessages = this.configuration.FilterSystemMessages;
                if (ImGui.Checkbox("Filter system messages", ref filterSystemMessages))
                {
                    this.configuration.FilterSystemMessages = filterSystemMessages;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("Hide all System messages except: Instance, Commendations, S Rank Hunt, Completed Ventures.");
                var filterEmoteSpam = this.configuration.FilterEmoteSpam;
                if (ImGui.Checkbox("Filter emote spam", ref filterEmoteSpam))
                {
                    this.configuration.FilterEmoteSpam = filterEmoteSpam;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("Hides all emotes that are not targeting you or used by you from chat.");
                var filterObtainedSpam = this.configuration.FilterObtainedSpam;
                if (ImGui.Checkbox("Filters spammy Obtain messages. See tooltip for examples.", ref filterObtainedSpam))
                {
                    this.configuration.FilterObtainedSpam = filterObtainedSpam;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("You obtain ### gil.\nYou obtain ### GC Seals.\nYou obtain ### sacks of Nuts. (Hunt Rewards)\nYou obtain a ___cluster.\nYou obtain a set of ___ materials. (Beast Tribe crafting materials)\nYou obtain ## [ele] shards/crystals/clusters.");
                var betterInstanceMessage = this.configuration.BetterInstanceMessage;
                if (ImGui.Checkbox("Improved /instance messaging", ref betterInstanceMessage))
                {
                    this.configuration.BetterInstanceMessage = betterInstanceMessage;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("Changes the instance text to: You are now in instance: #");
                var betterCommendationMessage = this.configuration.BetterCommendationMessage;
                if (ImGui.Checkbox("Condensed Commendations", ref betterCommendationMessage))
                {
                    this.configuration.BetterCommendationMessage = betterCommendationMessage;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("Disables System message for received commendations. Instead logs the total received commendations to Debug. Make sure you have the Debug channel visible in your chat settings.");
                var includeDutyNameInComms = this.configuration.IncludeDutyNameInComms;
                if (ImGui.Checkbox("Include completed duty in condensed commendations", ref includeDutyNameInComms))
                {
                    this.configuration.IncludeDutyNameInComms = includeDutyNameInComms;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("Requires Better Commendations to be enabled.");
                var instanceMessage = this.configuration.HideInstanceMessage;
                if (ImGui.Checkbox("Hide /instance message", ref instanceMessage))
                {
                    this.configuration.HideInstanceMessage = instanceMessage;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("Removes the instanced area notification from the whitelist.");
                var sRankHunt = this.configuration.HideSRankHunt;
                if (ImGui.Checkbox("Hide S Rank Hunt spawn announcement", ref sRankHunt))
                {
                    this.configuration.HideSRankHunt = sRankHunt;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("Removes the announcement that an S Rank Hunt has spawned in the zone notification from the whitelist.");
                var commendations = this.configuration.HideCommendations;
                if (ImGui.Checkbox("Hide Received Commendations", ref commendations))
                {
                    this.configuration.HideCommendations = commendations;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("Removes the you have earned a commendation notification from the whitelist.");
                var completedVenture = this.configuration.HideCompletedVenture;
                if (ImGui.Checkbox("Hide Completed Venture", ref completedVenture))
                {
                    this.configuration.HideCompletedVenture = completedVenture;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("Removes the completed venture notification from the whitelist.");
                var sayQuestTalk = this.configuration.HideSayQuestReminder;
                if (ImGui.Checkbox("Hide reminders of what to /say in chat during quests.", ref sayQuestTalk))
                {
                    this.configuration.HideSayQuestReminder = sayQuestTalk;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("Removes the completed venture notification from the whitelist.");
                ImGui.Spacing();
                if (ImGui.Button("Save and Close Config"))
                {
                    this.configuration.Save();
                    SettingsVisible = false;
                }
            }
            ImGui.End();
        }
    }
}