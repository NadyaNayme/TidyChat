namespace TidyChat.Settings.Tabs;

internal static class FishingTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.FishingTab_FilteringNote);
        SettingsTabLayout.WarnIfChannelMasterDisabled(configuration.FilterGatheringSpam, Languages.GeneralTab_FilterGatheringSpam);

        var showCaughtFish = configuration.ShowCaughtFish;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowFishAddedToGuideMessages, ref showCaughtFish))
        {
            configuration.ShowCaughtFish = showCaughtFish;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowFishAddedToGuideMessagesHelpMarker);

        var showReelInLine = configuration.ShowReelInLine;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowReelInLineMessages, ref showReelInLine))
        {
            configuration.ShowReelInLine = showReelInLine;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowReelInLineMessagesHelpMarker);

        var showLoseBait = configuration.ShowLoseBait;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowLoseBaitMessages, ref showLoseBait))
        {
            configuration.ShowLoseBait = showLoseBait;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowLoseBaitMessagesHelpMarker);

        var showMooching = configuration.ShowMooching;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowMooching, ref showMooching))
        {
            configuration.ShowMooching = showMooching;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowMoochingHelpMarker);

        var showMeasuringIlms = configuration.ShowMeasuringIlms;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowFishSizeMessages, ref showMeasuringIlms))
        {
            configuration.ShowMeasuringIlms = showMeasuringIlms;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowFishSizeMessagesHelpMarker);

        var showCurrentFishingHole = configuration.ShowCurrentFishingHole;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowFishingHoleName,
                ref showCurrentFishingHole))
        {
            configuration.ShowCurrentFishingHole = showCurrentFishingHole;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowFishingHoleNameHelpMarker);

        var showDiscoveredFishingHole = configuration.ShowDiscoveredFishingHole;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowFishingHoleDiscovered,
                ref showDiscoveredFishingHole))
        {
            configuration.ShowDiscoveredFishingHole = showDiscoveredFishingHole;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowFishingHoleDiscoveredHelpMarker);

        var showLureBiteFeelingMessages = configuration.ShowLureBiteFeelingMessages;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowLureBiteFeelingMessages, ref showLureBiteFeelingMessages))
        {
            configuration.ShowLureBiteFeelingMessages = showLureBiteFeelingMessages;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowLureBiteFeelingMessagesHelpMarker);

        var showLureAttemptMessages = configuration.ShowLureAttemptMessages;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowLureAttemptMessages, ref showLureAttemptMessages))
        {
            configuration.ShowLureAttemptMessages = showLureAttemptMessages;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowLureAttemptMessagesHelpMarker);

        var showFishingFlavorText = configuration.ShowFishingFlavorText;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowFishingFlavorText, ref showFishingFlavorText))
        {
            configuration.ShowFishingFlavorText = showFishingFlavorText;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowFishingFlavorTextHelpMarker);
    }
}
