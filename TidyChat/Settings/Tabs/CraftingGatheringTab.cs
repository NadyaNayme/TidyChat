using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
namespace TidyChat.Settings.Tabs;

internal static class CraftingGatheringTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_DesynthesisDropdownHeader))
        {
            bool showDesynthesisLevel = configuration.ShowDesynthesisLevel;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowDesynthesisLevelIncreasesMessages,
                    ref showDesynthesisLevel))
            {
                configuration.ShowDesynthesisLevel = showDesynthesisLevel;
                configuration.Save();
            }

            bool showDesynthedItem = configuration.ShowDesynthedItem;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowItemBeingDesynthesized,
                    ref showDesynthedItem))
            {
                configuration.ShowDesynthedItem = showDesynthedItem;
                configuration.Save();
            }

            bool showDesynthesisObtains = configuration.ShowDesynthesisObtains;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowObtainedItemsFromDesynthesisMessages,
                    ref showDesynthesisObtains))
            {
                configuration.ShowDesynthesisObtains = showDesynthesisObtains;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_MateriaDropdownHeader))
        {
            bool showAttachedMateria = configuration.ShowAttachedMateria;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaSuccesfullyAttachedMessages,
                    ref showAttachedMateria))
            {
                configuration.ShowAttachedMateria = showAttachedMateria;
                configuration.Save();
            }

            bool showOvermeldFailure = configuration.ShowOvermeldFailure;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaOvermeldFailuresMessages,
                    ref showOvermeldFailure))
            {
                configuration.ShowOvermeldFailure = showOvermeldFailure;
                configuration.Save();
            }

            bool showMateriaRetrieved = configuration.ShowMateriaRetrieved;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowSuccesfullyRetrievedMateriaMessages,
                    ref showMateriaRetrieved))
            {
                configuration.ShowMateriaRetrieved = showMateriaRetrieved;
                configuration.Save();
            }

            bool showMateriaShatters = configuration.ShowMateriaShatters;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaShattersMessages, ref showMateriaShatters))
            {
                configuration.ShowMateriaShatters = showMateriaShatters;
                configuration.Save();
            }

            bool showMateriaExtract = configuration.ShowMateriaExtract;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaExtractedMessages, ref showMateriaExtract))
            {
                configuration.ShowMateriaExtract = showMateriaExtract;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_CraftingDropdownHeader))
        {
            bool showCraftingSynthesisComplete = configuration.ShowCraftingSynthesisComplete;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowCraftingSynthesisComplete, ref showCraftingSynthesisComplete))
            {
                configuration.ShowCraftingSynthesisComplete = showCraftingSynthesisComplete;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.CraftingGatheringTab_ShowCraftingSynthesisCompleteHelpMarker);

            bool showTrialMessages = configuration.ShowTrialMessages;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowTrialSynthesisMessages, ref showTrialMessages))
            {
                configuration.ShowTrialMessages = showTrialMessages;
                configuration.Save();
            }

            bool showOtherSynthesis = configuration.ShowOtherSynthesis;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowOtherPlayerCompletedSynthesisMessages,
                    ref showOtherSynthesis))
            {
                configuration.ShowOtherSynthesis = showOtherSynthesis;
                configuration.Save();
            }

            bool showAllOtherCrafting = configuration.ShowAllOtherCrafting;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowAllOtherCrafting, ref showAllOtherCrafting))
            {
                configuration.ShowAllOtherCrafting = showAllOtherCrafting;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_GatheringLocationsDropdownHeader))
        {
            bool showGatheringSenses = configuration.ShowGatheringSenses;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowGatheringSensesLabel,
                    ref showGatheringSenses))
            {
                configuration.ShowGatheringSenses = showGatheringSenses;
                configuration.Save();
            }

            bool showAetherialReductionSands = configuration.ShowAetherialReductionSands;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowObtainedSandsFromAetherialReductionMessages,
                    ref showAetherialReductionSands))
            {
                configuration.ShowAetherialReductionSands = showAetherialReductionSands;
                configuration.Save();
            }

            bool showGatheringStartEnd = configuration.ShowGatheringStartEnd;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowGatheringStartEnd,
                    ref showGatheringStartEnd))
            {
                configuration.ShowGatheringStartEnd = showGatheringStartEnd;
                configuration.Save();
            }

            bool showLocationAffects = configuration.ShowLocationAffects;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowLocationGatheringEffectMessages,
                    ref showLocationAffects))
            {
                configuration.ShowLocationAffects = showLocationAffects;
                configuration.Save();
            }

            bool showGatheringYield = configuration.ShowGatheringYield;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_HideGatheringYieldLocationMessages,
                    ref showGatheringYield))
            {
                configuration.ShowGatheringYield = showGatheringYield;
                configuration.Save();
            }

            bool showGatheringAttempts = configuration.ShowGatheringAttempts;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_HideGatheringAttemptsLocationMessages,
                    ref showGatheringAttempts))
            {
                configuration.ShowGatheringAttempts = showGatheringAttempts;
                configuration.Save();
            }

            bool showGatherersBoon = configuration.ShowGatherersBoon;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_HideGatheringBoonLocationMessages,
                    ref showGatherersBoon))
            {
                configuration.ShowGatherersBoon = showGatherersBoon;
                configuration.Save();
            }

            bool showAllOtherGathering = configuration.ShowAllOtherGathering;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowAllOtherGathering, ref showAllOtherGathering))
            {
                configuration.ShowAllOtherGathering = showAllOtherGathering;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_FishingDropdownHeader))
        {
            bool showCaughtFish = configuration.ShowCaughtFish;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishAddedToGuideMessages, ref showCaughtFish))
            {
                configuration.ShowCaughtFish = showCaughtFish;
                configuration.Save();
            }

            bool showMooching = configuration.ShowMooching;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMooching, ref showMooching))
            {
                configuration.ShowMooching = showMooching;
                configuration.Save();
            }

            bool showMeasuringIlms = configuration.ShowMeasuringIlms;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishSizeMessages, ref showMeasuringIlms))
            {
                configuration.ShowMeasuringIlms = showMeasuringIlms;
                configuration.Save();
            }

            bool showCurrentFishingHole = configuration.ShowCurrentFishingHole;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishingHoleName,
                    ref showCurrentFishingHole))
            {
                configuration.ShowCurrentFishingHole = showCurrentFishingHole;
                configuration.Save();
            }

            bool showDiscoveredFishingHole = configuration.ShowDiscoveredFishingHole;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishingHoleDiscovered,
                    ref showDiscoveredFishingHole))
            {
                configuration.ShowDiscoveredFishingHole = showDiscoveredFishingHole;
                configuration.Save();
            }

            bool showLureMessages = configuration.ShowLureMessages;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowLureMessages, ref showLureMessages))
            {
                configuration.ShowLureMessages = showLureMessages;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.CraftingGatheringTab_ShowLureMessagesHelpMarker);

            bool showFishingFlavorText = configuration.ShowFishingFlavorText;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishingFlavorText, ref showFishingFlavorText))
            {
                configuration.ShowFishingFlavorText = showFishingFlavorText;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.CraftingGatheringTab_ShowFishingFlavorTextHelpMarker);
        }


        ImGui.EndTabItem();
    }
}
