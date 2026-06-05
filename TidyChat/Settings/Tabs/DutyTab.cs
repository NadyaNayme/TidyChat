namespace TidyChat.Settings.Tabs;

internal static class DutyTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.DutyTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.PartyDutyTab_DutyFinderDropdownHeader, () => DrawDutyFinderOptions(configuration)),
            (Languages.PartyDutyTab_DutyCompletionDropdownHeader, () => DrawDutyCompletionOptions(configuration)));
    }

    private static void DrawDutyFinderOptions(Configuration configuration)
    {
        var showDutyFinder = configuration.ShowDutyFinder;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowDutyFinderMessages, ref showDutyFinder))
        {
            configuration.ShowDutyFinder = showDutyFinder;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowDutyFinderMessagesHelpMarker);
    }

    private static void DrawDutyCompletionOptions(Configuration configuration)
    {
        var showCompletionTime = configuration.ShowCompletionTime;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowCompletionTimeForUnrestrictedParty, ref showCompletionTime))
        {
            configuration.ShowCompletionTime = showCompletionTime;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowCompletionTimeForUnrestrictedPartyHelpMarker);
    }
}
