namespace TidyChat.Settings.Tabs;

internal static class HousingTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.HousingTab_FilteringNote);
        SettingsTabLayout.WarnIfChannelMasterDisabled(configuration.FilterSystemMessages, Languages.GeneralTab_FilterSystemSpam);
        DrawHousingOptions(configuration);
    }

    private static void DrawHousingOptions(Configuration configuration)
    {
        var sanctuaryMessage = configuration.ShowSanctuaryMessage;
        if (ImGui.Checkbox(Languages.HousingTab_ShowSanctuaryMessage, ref sanctuaryMessage))
        {
            configuration.ShowSanctuaryMessage = sanctuaryMessage;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.HousingTab_ShowSanctuaryMessageHelpMarker);

        var housingWardMessage = configuration.ShowHousingWardMessage;
        if (ImGui.Checkbox(Languages.HousingTab_ShowHousingWardMessage, ref housingWardMessage))
        {
            configuration.ShowHousingWardMessage = housingWardMessage;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.HousingTab_ShowHousingWardMessageHelpMarker);
    }
}
