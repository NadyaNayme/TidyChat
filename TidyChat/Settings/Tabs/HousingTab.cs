namespace TidyChat.Settings.Tabs;

internal static class HousingTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.HousingTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.SystemTab_WorldAndInstancesDropdownHeader, () => DrawHousingOptions(configuration)));
    }

    private static void DrawHousingOptions(Configuration configuration)
    {
        var sanctuaryMessage = configuration.ShowSanctuaryMessage;
        if (ImGui.Checkbox(Languages.SystemTab_ShowSanctuaryMessage, ref sanctuaryMessage))
        {
            configuration.ShowSanctuaryMessage = sanctuaryMessage;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSanctuaryMessageHelpMarker);

        var housingWardMessage = configuration.ShowHousingWardMessage;
        if (ImGui.Checkbox(Languages.SystemTab_ShowHousingWardMessage, ref housingWardMessage))
        {
            configuration.ShowHousingWardMessage = housingWardMessage;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowHousingWardMessageHelpMarker);
    }
}
