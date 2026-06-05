using Dalamud.Interface.Components;
namespace TidyChat.Settings.Tabs;

internal static class CraftingTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_DesynthesisDropdownHeader, ImGuiTreeNodeFlags.DefaultOpen))
        {
            var showDesynthesisLevel = configuration.ShowDesynthesisLevel;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowDesynthesisLevelIncreasesMessages,
                    ref showDesynthesisLevel))
            {
                configuration.ShowDesynthesisLevel = showDesynthesisLevel;
                configuration.OnSettingChanged();
            }

            var showDesynthedItem = configuration.ShowDesynthedItem;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowItemBeingDesynthesized,
                    ref showDesynthedItem))
            {
                configuration.ShowDesynthedItem = showDesynthedItem;
                configuration.OnSettingChanged();
            }

            var showDesynthesisObtains = configuration.ShowDesynthesisObtains;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowObtainedItemsFromDesynthesisMessages,
                    ref showDesynthesisObtains))
            {
                configuration.ShowDesynthesisObtains = showDesynthesisObtains;
                configuration.OnSettingChanged();
            }
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_MateriaDropdownHeader))
        {
            var showAttachedMateria = configuration.ShowAttachedMateria;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaSuccesfullyAttachedMessages,
                    ref showAttachedMateria))
            {
                configuration.ShowAttachedMateria = showAttachedMateria;
                configuration.OnSettingChanged();
            }

            var showOvermeldFailure = configuration.ShowOvermeldFailure;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaOvermeldFailuresMessages,
                    ref showOvermeldFailure))
            {
                configuration.ShowOvermeldFailure = showOvermeldFailure;
                configuration.OnSettingChanged();
            }

            var showMateriaRetrieved = configuration.ShowMateriaRetrieved;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowSuccesfullyRetrievedMateriaMessages,
                    ref showMateriaRetrieved))
            {
                configuration.ShowMateriaRetrieved = showMateriaRetrieved;
                configuration.OnSettingChanged();
            }

            var showMateriaShatters = configuration.ShowMateriaShatters;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaShattersMessages, ref showMateriaShatters))
            {
                configuration.ShowMateriaShatters = showMateriaShatters;
                configuration.OnSettingChanged();
            }

            var showMateriaExtract = configuration.ShowMateriaExtract;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaExtractedMessages, ref showMateriaExtract))
            {
                configuration.ShowMateriaExtract = showMateriaExtract;
                configuration.OnSettingChanged();
            }
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_CraftingDropdownHeader))
        {
            var showCraftingSynthesisComplete = configuration.ShowCraftingSynthesisComplete;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowCraftingSynthesisComplete, ref showCraftingSynthesisComplete))
            {
                configuration.ShowCraftingSynthesisComplete = showCraftingSynthesisComplete;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CraftingGatheringTab_ShowCraftingSynthesisCompleteHelpMarker);

            var showTrialMessages = configuration.ShowTrialMessages;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowTrialSynthesisMessages, ref showTrialMessages))
            {
                configuration.ShowTrialMessages = showTrialMessages;
                configuration.OnSettingChanged();
            }

            var showOtherSynthesis = configuration.ShowOtherSynthesis;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowOtherPlayerCompletedSynthesisMessages,
                    ref showOtherSynthesis))
            {
                configuration.ShowOtherSynthesis = showOtherSynthesis;
                configuration.OnSettingChanged();
            }

            var showAllOtherCrafting = configuration.ShowAllOtherCrafting;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowAllOtherCrafting, ref showAllOtherCrafting))
            {
                configuration.ShowAllOtherCrafting = showAllOtherCrafting;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowAllOtherCraftingHelpMarker);

            SettingsTabLayout.DrawNestedOptions(configuration.ShowAllOtherCrafting, () =>
            {
                var showCraftingBuff = configuration.ShowCraftingBuffEffectGain;
                if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowCraftingBuffEffectGain, ref showCraftingBuff))
                {
                    configuration.ShowCraftingBuffEffectGain = showCraftingBuff;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowCraftingBuffEffectGainHelpMarker);

                var showCraftingExecute = configuration.ShowCraftingAbleToExecute;
                if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowCraftingAbleToExecute, ref showCraftingExecute))
                {
                    configuration.ShowCraftingAbleToExecute = showCraftingExecute;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowCraftingAbleToExecuteHelpMarker);
            });
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_AetherialReductionDropdownHeader))
        {
            var showAetherialReductionSands = configuration.ShowAetherialReductionSands;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowObtainedSandsFromAetherialReductionMessages,
                    ref showAetherialReductionSands))
            {
                configuration.ShowAetherialReductionSands = showAetherialReductionSands;
                configuration.OnSettingChanged();
            }

            var showAetherialReductionSuccess = configuration.ShowAetherialReductionSuccess;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowAetherialReductionSuccessMessages,
                    ref showAetherialReductionSuccess))
            {
                configuration.ShowAetherialReductionSuccess = showAetherialReductionSuccess;
                configuration.OnSettingChanged();
            }

            var showAetherialReductionMinigame = configuration.ShowAetherialReductionMinigame;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowAetherialReductionMinigameMessages,
                    ref showAetherialReductionMinigame))
            {
                configuration.ShowAetherialReductionMinigame = showAetherialReductionMinigame;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CraftingGatheringTab_ShowAetherialReductionMinigameMessagesHelpMarker);
        }
    }
}
