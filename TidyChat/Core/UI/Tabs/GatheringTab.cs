namespace TidyChat.Settings.Tabs;

internal static class GatheringTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.GatheringTab_FilteringNote);
        SettingsTabLayout.WarnIfChannelMasterDisabled(configuration.FilterGatheringSpam, Languages.GeneralTab_FilterGatheringSpam);

        SettingsTabLayout.DrawSections(true,
            (Languages.GatheringTab_GatheringLocationsDropdownHeader, () => DrawGatheringLocations(configuration)),
            (Languages.GatheringTab_AetherialReductionDropdownHeader, () => DrawAetherialReduction(configuration)));
    }

    private static void DrawGatheringLocations(Configuration configuration)
    {
        var showGatheringSenses = configuration.ShowGatheringSenses;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowGatheringSensesLabel,
                ref showGatheringSenses))
        {
            configuration.ShowGatheringSenses = showGatheringSenses;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowGatheringSensesLabelHelpMarker);

        var showGatheringStartEnd = configuration.ShowGatheringStartEnd;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowGatheringStartEnd,
                ref showGatheringStartEnd))
        {
            configuration.ShowGatheringStartEnd = showGatheringStartEnd;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowGatheringStartEndHelpMarker);

        var showLocationAffects = configuration.ShowLocationAffects;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowLocationGatheringEffectMessages,
                ref showLocationAffects))
        {
            configuration.ShowLocationAffects = showLocationAffects;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowLocationGatheringEffectMessagesHelpMarker);

        var hideGatheringYield = !configuration.ShowGatheringYield;
        if (ImGui.Checkbox(Languages.GatheringTab_HideGatheringYieldLocationMessages,
                ref hideGatheringYield))
        {
            configuration.ShowGatheringYield = !hideGatheringYield;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringHideFilterMarker(Languages.GatheringTab_HideGatheringYieldLocationMessagesHelpMarker);

        var hideGatheringAttempts = !configuration.ShowGatheringAttempts;
        if (ImGui.Checkbox(Languages.GatheringTab_HideGatheringAttemptsLocationMessages,
                ref hideGatheringAttempts))
        {
            configuration.ShowGatheringAttempts = !hideGatheringAttempts;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringHideFilterMarker(Languages.GatheringTab_HideGatheringAttemptsLocationMessagesHelpMarker);

        var hideGatherersBoon = !configuration.ShowGatherersBoon;
        if (ImGui.Checkbox(Languages.GatheringTab_HideGatheringBoonLocationMessages,
                ref hideGatherersBoon))
        {
            configuration.ShowGatherersBoon = !hideGatherersBoon;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringHideFilterMarker(Languages.GatheringTab_HideGatheringBoonLocationMessagesHelpMarker);

        var showGatheringCollectableObtains = configuration.ShowGatheringCollectableObtains;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowGatheringCollectableObtainMessages,
                ref showGatheringCollectableObtains))
        {
            configuration.ShowGatheringCollectableObtains = showGatheringCollectableObtains;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowGatheringCollectableObtainMessagesHelpMarker);

        var showAllOtherGathering = configuration.ShowAllOtherGathering;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowAllOtherGathering, ref showAllOtherGathering))
        {
            configuration.ShowAllOtherGathering = showAllOtherGathering;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowAllOtherGatheringHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowAllOtherGathering, () =>
        {
            var showGatheringBuff = configuration.ShowGatheringBuffEffectGain;
            if (ImGui.Checkbox(Languages.GatheringTab_ShowGatheringBuffEffectGain, ref showGatheringBuff))
            {
                configuration.ShowGatheringBuffEffectGain = showGatheringBuff;
                configuration.OnSettingChanged();
            }

            UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowGatheringBuffEffectGainHelpMarker);
        });
    }

    private static void DrawAetherialReduction(Configuration configuration)
    {
        var showAetherialReductionSands = configuration.ShowAetherialReductionSands;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowObtainedSandsFromAetherialReductionMessages,
                ref showAetherialReductionSands))
        {
            configuration.ShowAetherialReductionSands = showAetherialReductionSands;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.GatheringTab_ShowObtainedSandsFromAetherialReductionMessagesHelpMarker);

        var showAetherialReductionSuccess = configuration.ShowAetherialReductionSuccess;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowAetherialReductionSuccessMessages,
                ref showAetherialReductionSuccess))
        {
            configuration.ShowAetherialReductionSuccess = showAetherialReductionSuccess;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.GatheringTab_ShowAetherialReductionSuccessMessagesHelpMarker);

        var showAetherialReductionMinigame = configuration.ShowAetherialReductionMinigame;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowAetherialReductionMinigameMessages,
                ref showAetherialReductionMinigame))
        {
            configuration.ShowAetherialReductionMinigame = showAetherialReductionMinigame;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowAetherialReductionMinigameMessagesHelpMarker);
    }
}
