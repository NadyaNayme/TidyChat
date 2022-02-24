using Dalamud.Interface.Components;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class CraftingGatheringTab
    {
        public static void Draw(Configuration configuration)
        {
            var filterCraftingSpam = configuration.FilterCraftingSpam;
            if (ImGui.Checkbox("Filter all Crafting messages except \"You synthesize a/an <item>\"", ref filterCraftingSpam))
            {
                configuration.FilterCraftingSpam = filterCraftingSpam;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("This allows you to use ChatAlerts to create an alert for \"You synthesize\" instead of using macro-finished alerts");

            var filterGatheringSpam = configuration.FilterGatheringSpam;
            if (ImGui.Checkbox("Filter spammy Gathering messages.", ref filterGatheringSpam))
            {
                configuration.FilterGatheringSpam = filterGatheringSpam;
                configuration.Save();
            }
            ImGuiComponents.HelpMarker("Hide \"begin/finish\" gathering messages, as well as location affects");

            ImGui.Separator();

            if (ImGui.CollapsingHeader("Desynthesis"))
            {
                var showDesynthesisLevel = configuration.ShowDesynthesisLevel;
                if (ImGui.Checkbox("Show desynthesis level increases messages", ref showDesynthesisLevel))
                {
                    configuration.ShowDesynthesisLevel = showDesynthesisLevel;
                    configuration.Save();
                }

                var showDesynthesisObtains = configuration.ShowDesynthesisObtains;
                if (ImGui.Checkbox("Show obtained items from desynthesis", ref showDesynthesisObtains))
                {
                    configuration.ShowDesynthesisObtains = showDesynthesisObtains;
                    configuration.Save();
                }
            }

            if (ImGui.CollapsingHeader("Materia"))
            {
                var showAttachedMateria = configuration.ShowAttachedMateria;
                if (ImGui.Checkbox("Show message when materia is succesfully attached to gear", ref showAttachedMateria))
                {
                    configuration.ShowAttachedMateria = showAttachedMateria;
                    configuration.Save();
                }

                var showOvermeldFailure = configuration.ShowOvermeldFailure;
                if (ImGui.Checkbox("Show message when materia fails to be overmelded onto gear", ref showOvermeldFailure))
                {
                    configuration.ShowOvermeldFailure = showOvermeldFailure;
                    configuration.Save();
                }

                var showMateriaRetrieved = configuration.ShowMateriaRetrieved;
                if (ImGui.Checkbox("Show message when you succesfully retrieve materia from gear", ref showMateriaRetrieved))
                {
                    configuration.ShowMateriaRetrieved = showMateriaRetrieved;
                    configuration.Save();
                }

                var showMateriaShatters = configuration.ShowMateriaShatters;
                if (ImGui.Checkbox("Show message when materia shatters during retrieval", ref showMateriaShatters))
                {
                    configuration.ShowMateriaShatters = showMateriaShatters;
                    configuration.Save();
                }

                var showMateriaExtract = configuration.ShowMateriaExtract;
                if (ImGui.Checkbox("Show message when materia is extracted from spiritbonded gear", ref showMateriaExtract))
                {
                    configuration.ShowMateriaExtract = showMateriaExtract;
                    configuration.Save();
                }
            }

            ImGui.Spacing();

            if (ImGui.CollapsingHeader("Gathering Locations"))
            {
                var showAetherialReductionSands = configuration.ShowAetherialReductionSands;
                if (ImGui.Checkbox("Show the number of obtained sands after using aetherial reduction", ref showAetherialReductionSands))
                {
                    configuration.ShowAetherialReductionSands = showAetherialReductionSands;
                    configuration.Save();
                }

                var showLocationAffects = configuration.ShowLocationAffects;
                if (ImGui.Checkbox("Show message when location affects gathering yield, receiving Gatherer's Boon, or gathering attempts", ref showLocationAffects))
                {
                    configuration.ShowLocationAffects = showLocationAffects;
                    configuration.Save();
                }

                var hideGatheringYield = configuration.HideGatheringYield;
                if (ImGui.Checkbox("Hide only locations that affect gathering yield", ref hideGatheringYield))
                {
                    configuration.HideGatheringYield = hideGatheringYield;
                    configuration.Save();
                }

                var hideGatheringAttempts = configuration.HideGatheringAttempts;
                if (ImGui.Checkbox("Hide only locations that affect gathering attempts", ref hideGatheringAttempts))
                {
                    configuration.HideGatheringAttempts = hideGatheringAttempts;
                    configuration.Save();
                }

                var hideGatherersBoon = configuration.HideGatherersBoon;
                if (ImGui.Checkbox("Hide only locations that affect Gatherer's Boon", ref hideGatherersBoon))
                {
                    configuration.HideGatherersBoon = hideGatherersBoon;
                    configuration.Save();
                }
            }

            ImGui.EndTabItem();
        }
    }
}
