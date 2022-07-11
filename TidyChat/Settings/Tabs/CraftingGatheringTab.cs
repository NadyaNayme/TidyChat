using ImGuiNET;
using TidyChat.Localization.Resources;

namespace TidyChat.Settings.Tabs;

internal static class CraftingGatheringTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(localization.CraftingGatheringTab_DesynthesisDropdownHeader))
        {
            var showDesynthesisLevel = configuration.ShowDesynthesisLevel;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowDesynthesisLevelIncreasesMessages,
                    ref showDesynthesisLevel))
            {
                configuration.ShowDesynthesisLevel = showDesynthesisLevel;
                configuration.Save();
            }

            var showDesynthedItem = configuration.ShowDesynthedItem;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowItemBeingDesynthesized,
                    ref showDesynthedItem))
            {
                configuration.ShowDesynthedItem = showDesynthedItem;
                configuration.Save();
            }

            var showDesynthesisObtains = configuration.ShowDesynthesisObtains;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowObtainedItemsFromDesynthesisMessages,
                    ref showDesynthesisObtains))
            {
                configuration.ShowDesynthesisObtains = showDesynthesisObtains;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(localization.CraftingGatheringTab_MateriaDropdownHeader))
        {
            var showAttachedMateria = configuration.ShowAttachedMateria;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowMateriaSuccesfullyAttachedMessages,
                    ref showAttachedMateria))
            {
                configuration.ShowAttachedMateria = showAttachedMateria;
                configuration.Save();
            }

            var showOvermeldFailure = configuration.ShowOvermeldFailure;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowMateriaOvermeldFailuresMessages,
                    ref showOvermeldFailure))
            {
                configuration.ShowOvermeldFailure = showOvermeldFailure;
                configuration.Save();
            }

            var showMateriaRetrieved = configuration.ShowMateriaRetrieved;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowSuccesfullyRetrievedMateriaMessages,
                    ref showMateriaRetrieved))
            {
                configuration.ShowMateriaRetrieved = showMateriaRetrieved;
                configuration.Save();
            }

            var showMateriaShatters = configuration.ShowMateriaShatters;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowMateriaShattersMessages, ref showMateriaShatters))
            {
                configuration.ShowMateriaShatters = showMateriaShatters;
                configuration.Save();
            }

            var showMateriaExtract = configuration.ShowMateriaExtract;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowMateriaExtractedMessages, ref showMateriaExtract))
            {
                configuration.ShowMateriaExtract = showMateriaExtract;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(localization.CraftingGatheringTab_CraftingDropdownHeader))
        {
            var showTrialMessages = configuration.ShowTrialMessages;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowTrialSynthesisMessages, ref showTrialMessages))
            {
                configuration.ShowTrialMessages = showTrialMessages;
                configuration.Save();
            }

            var showOtherSynthesis = configuration.ShowOtherSynthesis;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowOtherPlayerCompletedSynthesisMessages,
                    ref showOtherSynthesis))
            {
                configuration.ShowOtherSynthesis = showOtherSynthesis;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(localization.CraftingGatheringTab_GatheringLocationsDropdownHeader))
        {
            var showGatheringSenses = configuration.ShowGatheringSenses;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowGatheringSensesLabel,
                    ref showGatheringSenses))
            {
                configuration.ShowGatheringSenses = showGatheringSenses;
                configuration.Save();
            }

            var showAetherialReductionSands = configuration.ShowAetherialReductionSands;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowObtainedSandsFromAetherialReductionMessages,
                    ref showAetherialReductionSands))
            {
                configuration.ShowAetherialReductionSands = showAetherialReductionSands;
                configuration.Save();
            }

            var showLocationAffects = configuration.ShowLocationAffects;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowLocationGatheringEffectMessages,
                    ref showLocationAffects))
            {
                configuration.ShowLocationAffects = showLocationAffects;
                configuration.Save();
            }

            var hideGatheringYield = configuration.HideGatheringYield;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_HideGatheringYieldLocationMessages,
                    ref hideGatheringYield))
            {
                configuration.HideGatheringYield = hideGatheringYield;
                configuration.Save();
            }

            var hideGatheringAttempts = configuration.HideGatheringAttempts;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_HideGatheringAttemptsLocationMessages,
                    ref hideGatheringAttempts))
            {
                configuration.HideGatheringAttempts = hideGatheringAttempts;
                configuration.Save();
            }

            var hideGatherersBoon = configuration.HideGatherersBoon;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_HideGatheringBoonLocationMessages,
                    ref hideGatherersBoon))
            {
                configuration.HideGatherersBoon = hideGatherersBoon;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(localization.CraftingGatheringTab_FishingDropdownHeader))
        {
            var showCaughtFish = configuration.ShowCaughtFish;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowFishAddedToGuideMessages, ref showCaughtFish))
            {
                configuration.ShowCaughtFish = showCaughtFish;
                configuration.Save();
            }

            var showMeasuringIlms = configuration.ShowMeasuringIlms;
            if (ImGui.Checkbox(localization.CraftingGatheringTab_ShowFishSizeMessages, ref showMeasuringIlms))
            {
                configuration.ShowMeasuringIlms = showMeasuringIlms;
                configuration.Save();
            }
        }


        ImGui.EndTabItem();
    }
}