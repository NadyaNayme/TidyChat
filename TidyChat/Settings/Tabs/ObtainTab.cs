using Dalamud.Interface.Components;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class ObtainTab
    {
        public static void Draw(Configuration configuration)
		{
            var filterObtainedSpam = configuration.FilterObtainedSpam;
            if (ImGui.Checkbox("Filters spammy Obtain messages", ref filterObtainedSpam))
            {
                configuration.FilterObtainedSpam = filterObtainedSpam;
                configuration.Save();
            }

            ImGui.Separator();
            ImGui.TextUnformatted("The options below will allow you to override the spammy Obtain messages filter.");

            if (ImGui.CollapsingHeader("Common Currencies"))
            {
                var showObtainedgil = configuration.ShowObtainedGil;
                if (ImGui.Checkbox("Show Gil", ref showObtainedgil))
                {
                    configuration.ShowObtainedGil = showObtainedgil;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You obtain 69 gil.");

                var showObtainedSeals = configuration.ShowObtainedSeals;
                if (ImGui.Checkbox("Show Grand Company Seals", ref showObtainedSeals))
                {
                    configuration.ShowObtainedSeals = showObtainedSeals;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You obtain 420 Flame Seals.");

                var showObtainedVenture = configuration.ShowObtainedVenture;
                if (ImGui.Checkbox("Show Ventures", ref showObtainedVenture))
                {
                    configuration.ShowObtainedVenture = showObtainedVenture;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You obtain a Venture.");

                var showObtainedMGP = configuration.ShowObtainedMGP;
                if (ImGui.Checkbox("Show MGP", ref showObtainedMGP))
                {
                    configuration.ShowObtainedMGP = showObtainedMGP;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You obtain 117 MGP.");
            }

            ImGui.Spacing();
            if (ImGui.CollapsingHeader("Battle Currencies"))
            {

                var showObtainedPoeticsTomestones = configuration.ShowObtainedPoeticsTomestones;
                if (ImGui.Checkbox("Show Allagan tomestones of Poetics", ref showObtainedPoeticsTomestones))
                {
                    configuration.ShowObtainedPoeticsTomestones = showObtainedPoeticsTomestones;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You obtain 100 Allagan tomestones of Poetics.");

                var showObtainedAphorismTomestones = configuration.ShowObtainedAphorismTomestones;
                if (ImGui.Checkbox("Show Allagan tomestones of Aphorism", ref showObtainedAphorismTomestones))
                {
                    configuration.ShowObtainedAphorismTomestones = showObtainedAphorismTomestones;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You obtain 60 Allagan tomestones of Aphorism.");

                var showObtainedAstronomyTomestones = configuration.ShowObtainedAstronomyTomestones;
                if (ImGui.Checkbox("Show Allagan tomestones of Astronomy", ref showObtainedAstronomyTomestones))
                {
                    configuration.ShowObtainedAstronomyTomestones = showObtainedAstronomyTomestones;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You obtain 20 Allagan tomestones of Astronomy.");

                var showObtainedAlliedSeals = configuration.ShowObtainedAlliedSeals;
                if (ImGui.Checkbox("Show Allied Seals", ref showObtainedAlliedSeals))
                {
                    configuration.ShowObtainedAlliedSeals = showObtainedAlliedSeals;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You obtain 100 Allied Seals.");

                var showObtainedCenturioSeals = configuration.ShowObtainedCenturioSeals;
                if (ImGui.Checkbox("Show Centurio Seals", ref showObtainedCenturioSeals))
                {
                    configuration.ShowObtainedCenturioSeals = showObtainedCenturioSeals;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You obtain 40 Centurio Seals.");

                var showObtainedNuts = configuration.ShowObtainedNuts;
                if (ImGui.Checkbox("Show sacks of Nuts", ref showObtainedNuts))
                {
                    configuration.ShowObtainedNuts = showObtainedNuts;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("eg. You obtain 100 sacks of Nuts.");
            }

            ImGui.Spacing();
            if (ImGui.CollapsingHeader("Beast Tribe Quests"))
            {
                var showObtainedMaterials = configuration.ShowObtainedMaterials;
                if (ImGui.Checkbox("Show Beast Tribe crafting materials", ref showObtainedMaterials))
                {
                    configuration.ShowObtainedMaterials = showObtainedMaterials;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("This will show the message that occurs when you receive crafting materials to be used in Beast Tribe crafting quests.\neg. You obtain Starboard Hull Component Materials");

                var showObtainedTribalCurrency = configuration.ShowObtainedTribalCurrency;
                if (ImGui.Checkbox("Show Beast Tribe Currencies", ref showObtainedTribalCurrency))
                {
                    configuration.ShowObtainedTribalCurrency = showObtainedTribalCurrency;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("This will show the message that occurs when you receive Beast Tribe currencies upon completion of a Beast Tribe quest.");
            }

            ImGui.Spacing();
            if (ImGui.CollapsingHeader("Other"))
            {
                var showObtainedClusters = configuration.ShowObtainedClusters;
                if (ImGui.Checkbox("Show cracked clusters", ref showObtainedClusters))
                {
                    configuration.ShowObtainedClusters = showObtainedClusters;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("This will show cracked clusters such as Dendroclusters and Anthoclusters.\nFor hiding elemental clusters see the hide elemental clusters option down below.\neg. You obtain a cracked dendrocluster");

                var showObtainedShards = configuration.ShowObtainedShards;
                if (ImGui.Checkbox("Show elemental shards, crystals, and clusters", ref showObtainedShards))
                {
                    configuration.ShowObtainedShards = showObtainedShards;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker("This will show the message that occurs when you gather or receive elemental shards, crystals, or clusters\neg. You obtain 30 ice shards");

				ImGui.EndTabItem();
            }
        }
    }
}
