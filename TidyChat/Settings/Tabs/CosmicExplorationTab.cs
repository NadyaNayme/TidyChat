namespace TidyChat.Settings.Tabs;

internal static class CosmicExplorationTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.CosmicExplorationTab_FilteringNote);

        var showStellarMissionMessages = configuration.ShowStellarMissionMessages;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowStellarMissionMessages,
                ref showStellarMissionMessages))
        {
            configuration.ShowStellarMissionMessages = showStellarMissionMessages;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.GatheringTab_ShowStellarMissionMessagesHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowStellarMissionMessages, () =>
        {
            var showStellarExecute = configuration.ShowStellarAbleToExecute;
            if (ImGui.Checkbox(Languages.GatheringTab_ShowStellarAbleToExecute, ref showStellarExecute))
            {
                configuration.ShowStellarAbleToExecute = showStellarExecute;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.GatheringTab_ShowStellarAbleToExecuteHelpMarker);

            var showStellarBuff = configuration.ShowStellarBuffEffectGain;
            if (ImGui.Checkbox(Languages.GatheringTab_ShowStellarBuffEffectGain, ref showStellarBuff))
            {
                configuration.ShowStellarBuffEffectGain = showStellarBuff;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.GatheringTab_ShowStellarBuffEffectGainHelpMarker);

            var showStellarGpRecovery = configuration.ShowStellarGpRecovery;
            if (ImGui.Checkbox(Languages.GatheringTab_ShowStellarGpRecovery, ref showStellarGpRecovery))
            {
                configuration.ShowStellarGpRecovery = showStellarGpRecovery;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.GatheringTab_ShowStellarGpRecoveryHelpMarker);
        });

        SettingsTabLayout.DrawIndependentOptions(() =>
        {
            var showCosmicExplorationMessages = configuration.ShowCosmicExplorationMessages;
            if (ImGui.Checkbox(Languages.GatheringTab_ShowCosmicExplorationMessages,
                    ref showCosmicExplorationMessages))
            {
                configuration.ShowCosmicExplorationMessages = showCosmicExplorationMessages;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.GatheringTab_ShowCosmicExplorationMessagesHelpMarker);

            var showCosmicRewards = configuration.ShowCosmicRewards;
            if (ImGui.Checkbox(Languages.GatheringTab_ShowCosmicRewards, ref showCosmicRewards))
            {
                configuration.ShowCosmicRewards = showCosmicRewards;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.GatheringTab_ShowCosmicRewardsHelpMarker);

            var showCosmicContainers = configuration.ShowCosmicContainers;
            if (ImGui.Checkbox(Languages.GatheringTab_ShowCosmicContainers, ref showCosmicContainers))
            {
                configuration.ShowCosmicContainers = showCosmicContainers;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.GatheringTab_ShowCosmicContainersHelpMarker);

            var showCosmicClassPointsAndDataset = configuration.ShowCosmicClassPointsAndDataset;
            if (ImGui.Checkbox(Languages.GatheringTab_ShowCosmicClassPointsAndDataset,
                    ref showCosmicClassPointsAndDataset))
            {
                configuration.ShowCosmicClassPointsAndDataset = showCosmicClassPointsAndDataset;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.GatheringTab_ShowCosmicClassPointsAndDatasetHelpMarker);

            var showCosmicDailyProgress = configuration.ShowCosmicDailyProgress;
            if (ImGui.Checkbox(Languages.GatheringTab_ShowCosmicDailyProgress,
                    ref showCosmicDailyProgress))
            {
                configuration.ShowCosmicDailyProgress = showCosmicDailyProgress;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.GatheringTab_ShowCosmicDailyProgressHelpMarker);
        });
    }
}
