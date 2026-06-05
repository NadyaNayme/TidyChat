using Dalamud.Interface.Components;
namespace TidyChat.Settings.Tabs;

internal static class GatheringTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_GatheringLocationsDropdownHeader,
                ImGuiTreeNodeFlags.DefaultOpen))
        {
            var showGatheringSenses = configuration.ShowGatheringSenses;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowGatheringSensesLabel,
                    ref showGatheringSenses))
            {
                configuration.ShowGatheringSenses = showGatheringSenses;
                configuration.OnSettingChanged();
            }

            var showGatheringStartEnd = configuration.ShowGatheringStartEnd;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowGatheringStartEnd,
                    ref showGatheringStartEnd))
            {
                configuration.ShowGatheringStartEnd = showGatheringStartEnd;
                configuration.OnSettingChanged();
            }

            var showLocationAffects = configuration.ShowLocationAffects;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowLocationGatheringEffectMessages,
                    ref showLocationAffects))
            {
                configuration.ShowLocationAffects = showLocationAffects;
                configuration.OnSettingChanged();
            }

            var showGatheringYield = configuration.ShowGatheringYield;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_HideGatheringYieldLocationMessages,
                    ref showGatheringYield))
            {
                configuration.ShowGatheringYield = showGatheringYield;
                configuration.OnSettingChanged();
            }

            var showGatheringAttempts = configuration.ShowGatheringAttempts;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_HideGatheringAttemptsLocationMessages,
                    ref showGatheringAttempts))
            {
                configuration.ShowGatheringAttempts = showGatheringAttempts;
                configuration.OnSettingChanged();
            }

            var showGatherersBoon = configuration.ShowGatherersBoon;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_HideGatheringBoonLocationMessages,
                    ref showGatherersBoon))
            {
                configuration.ShowGatherersBoon = showGatherersBoon;
                configuration.OnSettingChanged();
            }

            var showGatheringCollectableObtains = configuration.ShowGatheringCollectableObtains;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowGatheringCollectableObtainMessages,
                    ref showGatheringCollectableObtains))
            {
                configuration.ShowGatheringCollectableObtains = showGatheringCollectableObtains;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CraftingGatheringTab_ShowGatheringCollectableObtainMessagesHelpMarker);

            var showAllOtherGathering = configuration.ShowAllOtherGathering;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowAllOtherGathering, ref showAllOtherGathering))
            {
                configuration.ShowAllOtherGathering = showAllOtherGathering;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowAllOtherGatheringHelpMarker);

            SettingsTabLayout.DrawNestedOptions(configuration.ShowAllOtherGathering, () =>
            {
                var showGatheringBuff = configuration.ShowGatheringBuffEffectGain;
                if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowGatheringBuffEffectGain, ref showGatheringBuff))
                {
                    configuration.ShowGatheringBuffEffectGain = showGatheringBuff;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowGatheringBuffEffectGainHelpMarker);
            });
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_FishingDropdownHeader))
        {
            var showCaughtFish = configuration.ShowCaughtFish;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishAddedToGuideMessages, ref showCaughtFish))
            {
                configuration.ShowCaughtFish = showCaughtFish;
                configuration.OnSettingChanged();
            }

            var showMooching = configuration.ShowMooching;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMooching, ref showMooching))
            {
                configuration.ShowMooching = showMooching;
                configuration.OnSettingChanged();
            }

            var showMeasuringIlms = configuration.ShowMeasuringIlms;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishSizeMessages, ref showMeasuringIlms))
            {
                configuration.ShowMeasuringIlms = showMeasuringIlms;
                configuration.OnSettingChanged();
            }

            var showCurrentFishingHole = configuration.ShowCurrentFishingHole;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishingHoleName,
                    ref showCurrentFishingHole))
            {
                configuration.ShowCurrentFishingHole = showCurrentFishingHole;
                configuration.OnSettingChanged();
            }

            var showDiscoveredFishingHole = configuration.ShowDiscoveredFishingHole;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishingHoleDiscovered,
                    ref showDiscoveredFishingHole))
            {
                configuration.ShowDiscoveredFishingHole = showDiscoveredFishingHole;
                configuration.OnSettingChanged();
            }

            var showLureMessages = configuration.ShowLureMessages;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowLureMessages, ref showLureMessages))
            {
                configuration.ShowLureMessages = showLureMessages;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CraftingGatheringTab_ShowLureMessagesHelpMarker);

            var showFishingFlavorText = configuration.ShowFishingFlavorText;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowFishingFlavorText, ref showFishingFlavorText))
            {
                configuration.ShowFishingFlavorText = showFishingFlavorText;
                configuration.OnSettingChanged();
            }

            ImGuiComponents.HelpMarker(Languages.CraftingGatheringTab_ShowFishingFlavorTextHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.CraftingGatheringTab_StellarMissionsDropdownHeader))
        {
            ImGui.TextWrapped(Languages.CraftingGatheringTab_StellarSectionFilteringNote);
            ImGui.Spacing();

            var showStellarMissionMessages = configuration.ShowStellarMissionMessages;
            if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowStellarMissionMessages,
                    ref showStellarMissionMessages))
            {
                configuration.ShowStellarMissionMessages = showStellarMissionMessages;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowStellarMissionMessagesHelpMarker);

            SettingsTabLayout.DrawNestedOptions(configuration.ShowStellarMissionMessages, () =>
            {
                var showStellarExecute = configuration.ShowStellarAbleToExecute;
                if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowStellarAbleToExecute, ref showStellarExecute))
                {
                    configuration.ShowStellarAbleToExecute = showStellarExecute;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowStellarAbleToExecuteHelpMarker);

                var showStellarBuff = configuration.ShowStellarBuffEffectGain;
                if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowStellarBuffEffectGain, ref showStellarBuff))
                {
                    configuration.ShowStellarBuffEffectGain = showStellarBuff;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowStellarBuffEffectGainHelpMarker);
            });

            SettingsTabLayout.DrawIndependentOptions(() =>
            {
                var showCosmicExplorationMessages = configuration.ShowCosmicExplorationMessages;
                if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowCosmicExplorationMessages,
                        ref showCosmicExplorationMessages))
                {
                    configuration.ShowCosmicExplorationMessages = showCosmicExplorationMessages;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowCosmicExplorationMessagesHelpMarker);

                var showCosmicRewards = configuration.ShowCosmicRewards;
                if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowCosmicRewards, ref showCosmicRewards))
                {
                    configuration.ShowCosmicRewards = showCosmicRewards;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowCosmicRewardsHelpMarker);

                var showCosmicContainers = configuration.ShowCosmicContainers;
                if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowCosmicContainers, ref showCosmicContainers))
                {
                    configuration.ShowCosmicContainers = showCosmicContainers;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowCosmicContainersHelpMarker);

                var showCosmicClassPointsAndDataset = configuration.ShowCosmicClassPointsAndDataset;
                if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowCosmicClassPointsAndDataset,
                        ref showCosmicClassPointsAndDataset))
                {
                    configuration.ShowCosmicClassPointsAndDataset = showCosmicClassPointsAndDataset;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowCosmicClassPointsAndDatasetHelpMarker);

                var showCosmicDailyProgress = configuration.ShowCosmicDailyProgress;
                if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowCosmicDailyProgress,
                        ref showCosmicDailyProgress))
                {
                    configuration.ShowCosmicDailyProgress = showCosmicDailyProgress;
                    configuration.OnSettingChanged();
                }

                UiHelp.SystemFilterMarker(Languages.CraftingGatheringTab_ShowCosmicDailyProgressHelpMarker);
            });
        }
    }
}
