namespace TidyChat.Settings.Tabs;

internal static class CosmicExplorationTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.CosmicExplorationTab_FilteringNote);
        SettingsTabLayout.WarnIfChannelMasterDisabled(configuration.FilterSystemMessages, Languages.GeneralTab_FilterSystemSpam);

        SettingsTabLayout.DrawSections(true,
            (Languages.CosmicExplorationTab_StellarMissionsDropdownHeader, () => DrawStellarMissions(configuration)),
            (Languages.CosmicExplorationTab_BaseCampDropdownHeader, () => DrawBaseCamp(configuration)));
    }

    private static void DrawStellarMissions(Configuration configuration)
    {
        var showStellarMissionMessages = configuration.ShowStellarMissionMessages;
        if (ImGui.Checkbox(Languages.CosmicExplorationTab_ShowStellarMissionMessages,
                ref showStellarMissionMessages))
        {
            configuration.ShowStellarMissionMessages = showStellarMissionMessages;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.CosmicExplorationTab_ShowStellarMissionMessagesHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowStellarMissionMessages, () =>
        {
            var showStellarExecute = configuration.ShowStellarAbleToExecute;
            if (ImGui.Checkbox(Languages.CosmicExplorationTab_ShowStellarAbleToExecute, ref showStellarExecute))
            {
                configuration.ShowStellarAbleToExecute = showStellarExecute;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.CosmicExplorationTab_ShowStellarAbleToExecuteHelpMarker);

            var showStellarBuff = configuration.ShowStellarBuffEffectGain;
            if (ImGui.Checkbox(Languages.CosmicExplorationTab_ShowStellarBuffEffectGain, ref showStellarBuff))
            {
                configuration.ShowStellarBuffEffectGain = showStellarBuff;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.CosmicExplorationTab_ShowStellarBuffEffectGainHelpMarker);

            var showStellarGpRecovery = configuration.ShowStellarGpRecovery;
            if (ImGui.Checkbox(Languages.CosmicExplorationTab_ShowStellarGpRecovery, ref showStellarGpRecovery))
            {
                configuration.ShowStellarGpRecovery = showStellarGpRecovery;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.CosmicExplorationTab_ShowStellarGpRecoveryHelpMarker);
        });
    }

    private static void DrawBaseCamp(Configuration configuration)
    {
        var showCosmicExplorationMessages = configuration.ShowCosmicExplorationMessages;
        if (ImGui.Checkbox(Languages.CosmicExplorationTab_ShowCosmicExplorationMessages,
                ref showCosmicExplorationMessages))
        {
            configuration.ShowCosmicExplorationMessages = showCosmicExplorationMessages;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.CosmicExplorationTab_ShowCosmicExplorationMessagesHelpMarker);

        var showCosmicRewards = configuration.ShowCosmicRewards;
        if (ImGui.Checkbox(Languages.CosmicExplorationTab_ShowCosmicRewards, ref showCosmicRewards))
        {
            configuration.ShowCosmicRewards = showCosmicRewards;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.CosmicExplorationTab_ShowCosmicRewardsHelpMarker);

        var showCosmicContainers = configuration.ShowCosmicContainers;
        if (ImGui.Checkbox(Languages.CosmicExplorationTab_ShowCosmicContainers, ref showCosmicContainers))
        {
            configuration.ShowCosmicContainers = showCosmicContainers;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.CosmicExplorationTab_ShowCosmicContainersHelpMarker);

        var showCosmicClassPointsAndDataset = configuration.ShowCosmicClassPointsAndDataset;
        if (ImGui.Checkbox(Languages.CosmicExplorationTab_ShowCosmicClassPointsAndDataset,
                ref showCosmicClassPointsAndDataset))
        {
            configuration.ShowCosmicClassPointsAndDataset = showCosmicClassPointsAndDataset;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.CosmicExplorationTab_ShowCosmicClassPointsAndDatasetHelpMarker);

        var showCosmicDailyProgress = configuration.ShowCosmicDailyProgress;
        if (ImGui.Checkbox(Languages.CosmicExplorationTab_ShowCosmicDailyProgress,
                ref showCosmicDailyProgress))
        {
            configuration.ShowCosmicDailyProgress = showCosmicDailyProgress;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.CosmicExplorationTab_ShowCosmicDailyProgressHelpMarker);
    }
}
