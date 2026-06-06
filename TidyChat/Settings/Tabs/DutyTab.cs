namespace TidyChat.Settings.Tabs;

internal static class DutyTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.DutyTab_FilteringNote);

        var showDutyFinder = configuration.ShowDutyFinder;
        if (ImGui.Checkbox(Languages.DutyTab_ShowDutyFinderMessages, ref showDutyFinder))
        {
            configuration.ShowDutyFinder = showDutyFinder;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DutyTab_ShowDutyFinderMessagesHelpMarker);

        var showCompletionTime = configuration.ShowCompletionTime;
        if (ImGui.Checkbox(Languages.DutyTab_ShowCompletionTimeForUnrestrictedParty, ref showCompletionTime))
        {
            configuration.ShowCompletionTime = showCompletionTime;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DutyTab_ShowCompletionTimeForUnrestrictedPartyHelpMarker);
    }
}
