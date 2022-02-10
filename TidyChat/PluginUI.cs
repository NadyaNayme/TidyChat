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
            if (!SettingsVisible)
            {
                return;
            }
            try
            {
                ImGui.SetNextWindowSize(new Vector2(560, 500), ImGuiCond.FirstUseEver);
                if (!ImGui.Begin("Tidy Chat Settings", ref this.settingsVisible)) return;

                if(ImGui.BeginTabBar("##tidychatConfigTabs"))
                {
                    if (ImGui.BeginTabItem("General"))
                    {
                        DrawGeneralTab();
                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("System"))
                    {
                        DrawSystemTab();
                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Emotes"))
                    {
                        DrawEmotesTab();
                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Obtain"))
                    {
                        DrawObtainTab();
                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Loot"))
                    {
                        DrawLootTab();
                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Progress"))
                    {
                        DrawProgressTab();
                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Crafting"))
                    {
                        DrawCraftingTab();
                        ImGui.EndTabItem();
                    }

                    ImGui.EndTabBar();

                    ImGui.Separator();
                    ImGui.Spacing();
                    if (ImGui.Button("Save and Close Config"))
                    {
                        this.configuration.Save();
                        SettingsVisible = false;
                    }
                }
            } finally
            {
                ImGui.End();
            }
        }

        public void DrawGeneralTab()
        {
            var enabled = this.configuration.Enabled;
            if (ImGui.Checkbox("Enable filters", ref enabled))
            {
                this.configuration.Enabled = enabled;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This should be left on unless testing or debugging.");

            ImGui.Separator();

            if (ImGui.CollapsingHeader("Messaging Improvements"))
            {

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
                ImGuiComponents.HelpMarker("Disables System message for received commendations and instead logs a single message to your Dalamud General Chat Channel (check your Dalamud General Settings for which channel that is - it is Debug by default)");

                var includeDutyNameInComms = this.configuration.IncludeDutyNameInComms;
                if (ImGui.Checkbox("Include completed duty in condensed commendations", ref includeDutyNameInComms))
                {
                    this.configuration.IncludeDutyNameInComms = includeDutyNameInComms;
                    if (!this.configuration.BetterCommendationMessage && this.configuration.IncludeDutyNameInComms)
                    {
                        this.configuration.BetterCommendationMessage = true;
                    }
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("Requires Condensed Commendations to be enabled");

                var betterSayReminder = this.configuration.BetterSayReminder;
                if (ImGui.Checkbox("Improved /Say message for quests", ref betterSayReminder))
                {
                    this.configuration.BetterSayReminder = betterSayReminder;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("When a quest requires you to /Say something in chat, change the message into one that can be copy and pasted easily");

            }

            ImGui.Spacing();
            if (ImGui.CollapsingHeader("Uncategorized Filters"))
            {

                var hideDebugTeleport = this.configuration.HideDebugTeleport;
                if (ImGui.Checkbox("Hide \"Teleporting to <Location>...\" Dalamud Debug messages ", ref hideDebugTeleport))
                {
                    this.configuration.HideDebugTeleport = hideDebugTeleport;
                    this.configuration.Save();
                }

                var hideUserLogOuts = this.configuration.HideUserLogOuts;
                if (ImGui.Checkbox("Hide \"User has logged out\" Free Company messages ", ref hideUserLogOuts))
                {
                    this.configuration.HideUserLogOuts = hideUserLogOuts;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("Hides the message that appears when a Free Company member logs out");
            }
        }
        public void DrawSystemTab()
        {
            var filterSystemMessages = this.configuration.FilterSystemMessages;
            if (ImGui.Checkbox("Filter spammy system messages", ref filterSystemMessages))
            {
                this.configuration.FilterSystemMessages = filterSystemMessages;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("Hide all System messages except: Instance, Commendations, S Rank Hunt, Completed Ventures.");

            ImGui.Separator();

            ImGui.TextUnformatted("The options below will allow you to hide System messages that Tiny Chat does not consider to be spam.");

            var instanceMessage = this.configuration.HideInstanceMessage;
            if (ImGui.Checkbox("Hide /instance message", ref instanceMessage))
            {
                this.configuration.HideInstanceMessage = instanceMessage;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This is the message that appears when you join an instanced zone or use the /instance command.");


            var sRankHunt = this.configuration.HideSRankHunt;
            if (ImGui.Checkbox("Hide S Rank Hunt spawn announcement", ref sRankHunt))
            {
                this.configuration.HideSRankHunt = sRankHunt;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This is the message that appears when an S rank hunt has spawned in your current zone.");

            var ssRankHunt = this.configuration.HideSSRankHunt;
            if (ImGui.Checkbox("Hide SS Rank Minion spawn and withdraw announcement", ref ssRankHunt))
            {
                this.configuration.HideSSRankHunt = ssRankHunt;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("These are the messages that appears when an SS rank's minions have spawned in or withdrawn from your current zone.");

            var commendations = this.configuration.HideCommendations;
            if (ImGui.Checkbox("Hide Received Commendations", ref commendations))
            {
                this.configuration.HideCommendations = commendations;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This is the message that appears when you have received a player commendation.");

            var completedVenture = this.configuration.HideCompletedVenture;
            if (ImGui.Checkbox("Hide Completed Venture", ref completedVenture))
            {
                this.configuration.HideCompletedVenture = completedVenture;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This is the message that appears when a retainer completes a venture.");

            var hideQuestReminder = this.configuration.HideQuestReminder;
            if (ImGui.Checkbox("Hide reminders of what to /say in chat during quests.", ref hideQuestReminder))
            {
                this.configuration.HideQuestReminder = hideQuestReminder;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This is the message that appears when interacting with a quest objective that requires you to /say a specific word or phrase.");

            var hideSpideySenses = this.configuration.HideSpideySenses;
            if (ImGui.Checkbox("Hide the \"You sense something...\" message", ref hideSpideySenses))
            {
                this.configuration.HideSpideySenses = hideSpideySenses;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This is the message that appears when interacting with an item that is guiding you in a direction.\neg. You sense something to the far, far southwest.");

            var hideAetherCompass = this.configuration.HideAetherCompass;
            if (ImGui.Checkbox("Hide the \"The compass detects a current approximately ___ yalms to the <direction>...\" message", ref hideAetherCompass))
            {
                this.configuration.HideAetherCompass = hideAetherCompass;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This is the message that appears when using the Aether Compass to find Aether Currents. This does not hide the toast notification.");

            var hideCountdownTime = this.configuration.HideCountdownTime;
            if (ImGui.Checkbox("Hide the \"Battle commencing in __ seconds!\" message", ref hideCountdownTime))
            {
                this.configuration.HideCountdownTime = hideCountdownTime;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This is the message that appears when a countdown begins with the length of the countdown. It does not remove the toast notifications or on-screen time countdowns.");

            var hideReadyChecks = this.configuration.HideReadyChecks;
            if (ImGui.Checkbox("Hide the \"Ready check complete.\" message", ref hideReadyChecks))
            {
                this.configuration.HideReadyChecks = hideReadyChecks;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This is the message that appears when a ready check completes. Not sure why you would want to hide this but you can if you want.");
        }
        public void DrawEmotesTab()
        {
            var filterEmoteSpam = this.configuration.FilterEmoteSpam;
            if (ImGui.Checkbox("Filter emote spam", ref filterEmoteSpam))
            {
                this.configuration.FilterEmoteSpam = filterEmoteSpam;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will hide all emote text unless it is an emote targeting you or an emote you used.");

            var hideUsedEmotes = this.configuration.HideUsedEmotes;
            if (ImGui.Checkbox("Filter emotes used by yourself", ref hideUsedEmotes))
            {
                this.configuration.HideUsedEmotes = hideUsedEmotes;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will hide the message that occurs when you use an emote.\neg. You gently pat <user>");

            ImGui.Separator();
            ImGui.TextUnformatted("Custom emotes are currently not blocked.\nIn a future update, Custom Emotes can be blocked unless they mention your name.\nFor now you can filter the CustomEmotes channel if you do not wish to see them.");
        }
        public void DrawObtainTab()
        {
            var filterObtainedSpam = this.configuration.FilterObtainedSpam;
            if (ImGui.Checkbox("Filters spammy Obtain messages", ref filterObtainedSpam))
            {
                this.configuration.FilterObtainedSpam = filterObtainedSpam;
                this.configuration.Save();
            }

            ImGui.Separator();
            ImGui.TextUnformatted("The options below will allow you to show Obtain messages Tiny Chat considers to be spam.");

            if (ImGui.CollapsingHeader("Common Currencies"))
            {
                var showObtainedgil = this.configuration.ShowObtainedGil;
                if (ImGui.Checkbox("Show Gil", ref showObtainedgil))
                {
                    this.configuration.ShowObtainedGil = showObtainedgil;
                    this.configuration.Save();
                }

                var showObtainedSeals = this.configuration.ShowObtainedSeals;
                if (ImGui.Checkbox("Show Grand Company Seals", ref showObtainedSeals))
                {
                    this.configuration.ShowObtainedSeals = showObtainedSeals;
                    this.configuration.Save();
                }

                var showObtainedVenture = this.configuration.ShowObtainedVenture;
                if (ImGui.Checkbox("Show Ventures", ref showObtainedVenture))
                {
                    this.configuration.ShowObtainedVenture = showObtainedVenture;
                    this.configuration.Save();
                }

                var showObtainedMGP = this.configuration.ShowObtainedMGP;
                if (ImGui.Checkbox("Show MGP", ref showObtainedMGP))
                {
                    this.configuration.ShowObtainedMGP = showObtainedMGP;
                    this.configuration.Save();
                }
            }

            ImGui.Spacing();
            if (ImGui.CollapsingHeader("Battle Currencies"))
            {

                var showObtainedPoeticsTomestones = this.configuration.ShowObtainedPoeticsTomestones;
                if (ImGui.Checkbox("Show Allagan tomestones of Poetics", ref showObtainedPoeticsTomestones))
                {
                    this.configuration.ShowObtainedPoeticsTomestones = showObtainedPoeticsTomestones;
                    this.configuration.Save();
                }

                var showObtainedAphorismTomestones = this.configuration.ShowObtainedAphorismTomestones;
                if (ImGui.Checkbox("Show Allagan tomestones of Aphorism", ref showObtainedAphorismTomestones))
                {
                    this.configuration.ShowObtainedAphorismTomestones = showObtainedAphorismTomestones;
                    this.configuration.Save();
                }

                var showObtainedAstronomyTomestones = this.configuration.ShowObtainedAstronomyTomestones;
                if (ImGui.Checkbox("Show Allagan tomestones of Astronomy", ref showObtainedAstronomyTomestones))
                {
                    this.configuration.ShowObtainedAstronomyTomestones = showObtainedAstronomyTomestones;
                    this.configuration.Save();
                }

                var showObtainedAlliedSeals = this.configuration.ShowObtainedAlliedSeals;
                if (ImGui.Checkbox("Show Allied Seals", ref showObtainedAlliedSeals))
                {
                    this.configuration.ShowObtainedAlliedSeals = showObtainedAlliedSeals;
                    this.configuration.Save();
                }

                var showObtainedCenturioSeals = this.configuration.ShowObtainedCenturioSeals;
                if (ImGui.Checkbox("Show Centurio Seals", ref showObtainedCenturioSeals))
                {
                    this.configuration.ShowObtainedCenturioSeals = showObtainedCenturioSeals;
                    this.configuration.Save();
                }

                var showObtainedNuts = this.configuration.ShowObtainedNuts;
                if (ImGui.Checkbox("Show sacks of Nuts", ref showObtainedNuts))
                {
                    this.configuration.ShowObtainedNuts = showObtainedNuts;
                    this.configuration.Save();
                }
            }

            ImGui.Spacing();
            if (ImGui.CollapsingHeader("Beast Tribe Quests"))
            {
                var showObtainedMaterials = this.configuration.ShowObtainedMaterials;
                if (ImGui.Checkbox("Show Beast Tribe crafting materials", ref showObtainedMaterials))
                {
                    this.configuration.ShowObtainedMaterials = showObtainedMaterials;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("This will show the message that occurs when you receive crafting materials to be used in Beast Tribe crafting quests");

                var showObtainedTribalCurrency = this.configuration.ShowObtainedTribalCurrency;
                if (ImGui.Checkbox("Show Beast Tribe Currencies", ref showObtainedTribalCurrency))
                {
                    this.configuration.ShowObtainedTribalCurrency = showObtainedTribalCurrency;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("This will show the message that occurs when you receive crafting materials to be used in Beast Tribe crafting quests");
            }

            ImGui.Spacing();
            if (ImGui.CollapsingHeader("Other"))
            {
                var showObtainedClusters = this.configuration.ShowObtainedClusters;
                if (ImGui.Checkbox("Show cracked clusters", ref showObtainedClusters))
                {
                    this.configuration.ShowObtainedClusters = showObtainedClusters;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("This will show cracked clusters such as Dendroclusters and Anthoclusters.\nFor hiding elemental clusters see the hide elemental clusters option down below.");

                var showObtainedShards = this.configuration.ShowObtainedShards;
                if (ImGui.Checkbox("Show elemental shards, crystals, and clusters", ref showObtainedShards))
                {
                    this.configuration.ShowObtainedShards = showObtainedShards;
                    this.configuration.Save();
                }
                ImGuiComponents.HelpMarker("This will show the message that occurs when you gather or receive elemental shards, crystals, or clusters");
            }
        }

        public void DrawLootTab()
        {
            var filterObtainedSpam = this.configuration.FilterObtainedSpam;
            if (ImGui.Checkbox("Filters spammy Loot messages", ref filterObtainedSpam))
            {
                this.configuration.FilterObtainedSpam = filterObtainedSpam;
                this.configuration.Save();
            }

            ImGui.Separator();

            ImGui.TextUnformatted("The options below will allow you to show Loot messages Tiny Chat considers to be spam");
            var showCastLot = this.configuration.ShowCastLot;
            if (ImGui.Checkbox("Show \"You cast your lot\" messages", ref showCastLot))
            {
                this.configuration.ShowCastLot = showCastLot;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will show the message that occurs when you roll on loot.\nYou cast your lot for the <item>");

            var showLootRoll = this.configuration.ShowLootRoll;
            if (ImGui.Checkbox("Show \"You rolled ##\" messages", ref showLootRoll))
            {
                this.configuration.ShowLootRoll = showLootRoll;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will show the message that occurs after everyone has rolled on loot and you are given the result of your roll.\nYou roll Need/Greed on the <item>. 63!");
        }

        public void DrawProgressTab()
        {
            var filterObtainedSpam = this.configuration.FilterObtainedSpam;
            if (ImGui.Checkbox("Filters spammy Progress messages", ref filterObtainedSpam))
            {
                this.configuration.FilterObtainedSpam = filterObtainedSpam;
                this.configuration.Save();
            }

            ImGui.Separator();

            ImGui.TextUnformatted("The options below will allow you to show Progress messages Tiny Chat considers to be spam.");
            var showGainExperience = this.configuration.ShowGainExperience;
            if (ImGui.Checkbox("Show experience gain messages", ref showGainExperience))
            {
                this.configuration.ShowGainExperience = showGainExperience;
                this.configuration.Save();
            }

            var showGainPvpExp = this.configuration.ShowGainPvpExp;
            if (ImGui.Checkbox("Show PVP EXP gain messages", ref showGainPvpExp))
            {
                this.configuration.ShowGainPvpExp = showGainPvpExp;
                this.configuration.Save();
            }

            var showEarnAchievement = this.configuration.ShowEarnAchievement;
            if (ImGui.Checkbox("Show earned achievement messages", ref showEarnAchievement))
            {
                this.configuration.ShowEarnAchievement = showEarnAchievement;
                this.configuration.Save();
            }

            var showLevelUps = this.configuration.ShowLevelUps;
            if (ImGui.Checkbox("Show level up messages", ref showLevelUps))
            {
                this.configuration.ShowLevelUps = showLevelUps;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will show the message that occurs when you level up.\nIt can be considered spammy in Palace of the Dead and Heaven On High.");

            var showAbilityUnlocks = this.configuration.ShowAbilityUnlocks;
            if (ImGui.Checkbox("Show learned ability messages", ref showAbilityUnlocks))
            {
                this.configuration.ShowAbilityUnlocks = showAbilityUnlocks;
                this.configuration.Save();
            }
            ImGuiComponents.HelpMarker("This will show the message that occurs when you learn a new ability.\nIt can be considered spammy in Palace of the Dead and Heaven On High.");
        }

        public void DrawCraftingTab()
        {
            var filterObtainedSpam = this.configuration.FilterObtainedSpam;
            if (ImGui.Checkbox("Filter all Crafting messages except \"You synthesize a/an <item>\"", ref filterObtainedSpam))
            {
                this.configuration.FilterObtainedSpam = filterObtainedSpam;
                this.configuration.Save();
            };
            ImGuiComponents.HelpMarker("This allows you to use ChatAlerts to create an alert for \"You synthesize\" instead of using macro-finished alerts.");
        }

    }
}