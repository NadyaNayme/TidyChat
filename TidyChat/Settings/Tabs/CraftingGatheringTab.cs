using ImGuiNET;
using TidyChat.Resources.Languages;

namespace TidyChat.Settings.Tabs;

internal static class CraftingGatheringTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_DesynthesisDropdownHeader))
        {
            var showDesynthesisLevel = configuration.ShowDesynthesisLevel;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowDesynthesisLevelIncreasesMessages,
                    ref showDesynthesisLevel))
            {
                configuration.ShowDesynthesisLevel = showDesynthesisLevel;
                configuration.Save();
            }

            var showDesynthedItem = configuration.ShowDesynthedItem;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowItemBeingDesynthesized,
                    ref showDesynthedItem))
            {
                configuration.ShowDesynthedItem = showDesynthedItem;
                configuration.Save();
            }

            var showDesynthesisObtains = configuration.ShowDesynthesisObtains;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowObtainedItemsFromDesynthesisMessages,
                    ref showDesynthesisObtains))
            {
                configuration.ShowDesynthesisObtains = showDesynthesisObtains;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_MateriaDropdownHeader))
        {
            var showAttachedMateria = configuration.ShowAttachedMateria;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaSuccesfullyAttachedMessages,
                    ref showAttachedMateria))
            {
                configuration.ShowAttachedMateria = showAttachedMateria;
                configuration.Save();
            }

            var showOvermeldFailure = configuration.ShowOvermeldFailure;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaOvermeldFailuresMessages,
                    ref showOvermeldFailure))
            {
                configuration.ShowOvermeldFailure = showOvermeldFailure;
                configuration.Save();
            }

            var showMateriaRetrieved = configuration.ShowMateriaRetrieved;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowSuccesfullyRetrievedMateriaMessages,
                    ref showMateriaRetrieved))
            {
                configuration.ShowMateriaRetrieved = showMateriaRetrieved;
                configuration.Save();
            }

            var showMateriaShatters = configuration.ShowMateriaShatters;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaShattersMessages, ref showMateriaShatters))
            {
                configuration.ShowMateriaShatters = showMateriaShatters;
                configuration.Save();
            }

            var showMateriaExtract = configuration.ShowMateriaExtract;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaExtractedMessages, ref showMateriaExtract))
            {
                configuration.ShowMateriaExtract = showMateriaExtract;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_CraftingDropdownHeader))
        {
            var showTrialMessages = configuration.ShowTrialMessages;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowTrialSynthesisMessages, ref showTrialMessages))
            {
                configuration.ShowTrialMessages = showTrialMessages;
                configuration.Save();
            }

            var showOtherSynthesis = configuration.ShowOtherSynthesis;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowOtherPlayerCompletedSynthesisMessages,
                    ref showOtherSynthesis))
            {
                configuration.ShowOtherSynthesis = showOtherSynthesis;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_GatheringLocationsDropdownHeader))
        {
            var showGatheringSenses = configuration.ShowGatheringSenses;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowGatheringSensesLabel,
                    ref showGatheringSenses))
            {
                configuration.ShowGatheringSenses = showGatheringSenses;
                configuration.Save();
            }

            var showAetherialReductionSands = configuration.ShowAetherialReductionSands;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowObtainedSandsFromAetherialReductionMessages,
                    ref showAetherialReductionSands))
            {
                configuration.ShowAetherialReductionSands = showAetherialReductionSands;
                configuration.Save();
            }

            var showGatheringStartEnd = configuration.ShowGatheringStartEnd;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowGatheringStartEnd,
                    ref showGatheringStartEnd))
            {
                configuration.ShowGatheringStartEnd = showGatheringStartEnd;
                configuration.Save();
            }

            var showLocationAffects = configuration.ShowLocationAffects;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowLocationGatheringEffectMessages,
                    ref showLocationAffects))
            {
                configuration.ShowLocationAffects = showLocationAffects;
                configuration.Save();
            }

            var showGatheringYield = configuration.ShowGatheringYield;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_HideGatheringYieldLocationMessages,
                    ref showGatheringYield))
            {
                configuration.ShowGatheringYield = showGatheringYield;
                configuration.Save();
            }

            var showGatheringAttempts = configuration.ShowGatheringAttempts;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_HideGatheringAttemptsLocationMessages,
                    ref showGatheringAttempts))
            {
                configuration.ShowGatheringAttempts = showGatheringAttempts;
                configuration.Save();
            }

            var showGatherersBoon = configuration.ShowGatherersBoon;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_HideGatheringBoonLocationMessages,
                    ref showGatherersBoon))
            {
                configuration.ShowGatherersBoon = showGatherersBoon;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_FishingDropdownHeader))
        {
            var showCaughtFish = configuration.ShowCaughtFish;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishAddedToGuideMessages, ref showCaughtFish))
            {
                configuration.ShowCaughtFish = showCaughtFish;
                configuration.Save();
            }

            var showMooching = configuration.ShowMooching;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMooching, ref showMooching))
            {
                configuration.ShowMooching = showMooching;
                configuration.Save();
            }

            var showMeasuringIlms = configuration.ShowMeasuringIlms;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishSizeMessages, ref showMeasuringIlms))
            {
                configuration.ShowMeasuringIlms = showMeasuringIlms;
                configuration.Save();
            }

            var showCurrentFishingHole = configuration.ShowCurrentFishingHole;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishingHoleName,
                    ref showCurrentFishingHole))
            {
                configuration.ShowCurrentFishingHole = showCurrentFishingHole;
                configuration.Save();
            }

            var showDiscoveredFishingHole = configuration.ShowDiscoveredFishingHole;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishingHoleDiscovered,
                    ref showDiscoveredFishingHole))
            {
                configuration.ShowDiscoveredFishingHole = showDiscoveredFishingHole;
                configuration.Save();
            }
        }


        ImGui.EndTabItem();
    }
}