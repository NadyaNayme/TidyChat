namespace TidyChat.Settings.Tabs;

internal static class FishingTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.FishingTab_FilteringNote);

        var showCaughtFish = configuration.ShowCaughtFish;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowFishAddedToGuideMessages, ref showCaughtFish))
        {
            configuration.ShowCaughtFish = showCaughtFish;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowFishAddedToGuideMessagesHelpMarker);

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

        var showLureMessages = configuration.ShowLureMessages;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowLureMessages, ref showLureMessages))
        {
            configuration.ShowLureMessages = showLureMessages;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowLureMessagesHelpMarker);

        var showFishingFlavorText = configuration.ShowFishingFlavorText;
        if (ImGui.Checkbox(Languages.GatheringTab_ShowFishingFlavorText, ref showFishingFlavorText))
        {
            configuration.ShowFishingFlavorText = showFishingFlavorText;
            configuration.OnSettingChanged();
        }

        UiHelp.GatheringFilterMarker(Languages.GatheringTab_ShowFishingFlavorTextHelpMarker);
    }
}
