namespace TidyChat.Settings.Tabs;

internal static class DutyTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.DutyTab_FilteringNote);
        SettingsTabLayout.WarnIfChannelMasterDisabled(configuration.FilterSystemMessages, Languages.GeneralTab_FilterSystemSpam);

        SettingsTabLayout.DrawSections(true,
            (Languages.DutyTab_DutyFinderDropdownHeader, () => DrawDutyFinder(configuration)),
            (Languages.DutyTab_InstanceAndDutyDropdownHeader, () => DrawInstanceAndDuty(configuration)));
    }

    private static void DrawDutyFinder(Configuration configuration)
    {
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

    private static void DrawInstanceAndDuty(Configuration configuration)
    {
        var instanceMessage = configuration.ShowInstanceMessage;
        if (ImGui.Checkbox(Languages.DutyTab_ShowInstanceMessage, ref instanceMessage))
        {
            configuration.ShowInstanceMessage = instanceMessage;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DutyTab_ShowInstanceMessageHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowInstanceMessage,
            () => DrawInstanceMessageSubOptions(configuration));
    }

    private static void DrawInstanceMessageSubOptions(Configuration configuration)
    {
        var showInstancedArea = configuration.ShowInstancedAreaMessages;
        if (ImGui.Checkbox(Languages.DutyTab_ShowInstancedAreaMessages, ref showInstancedArea))
        {
            configuration.ShowInstancedAreaMessages = showInstancedArea;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DutyTab_ShowInstancedAreaMessagesHelpMarker);

        var showDutyEnded = configuration.ShowDutyEndedMessage;
        if (ImGui.Checkbox(Languages.DutyTab_ShowDutyEndedMessage, ref showDutyEnded))
        {
            configuration.ShowDutyEndedMessage = showDutyEnded;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DutyTab_ShowDutyEndedMessageHelpMarker);

        var showGuildhestEnded = configuration.ShowGuildhestEndedMessage;
        if (ImGui.Checkbox(Languages.DutyTab_ShowGuildhestEndedMessage, ref showGuildhestEnded))
        {
            configuration.ShowGuildhestEndedMessage = showGuildhestEnded;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DutyTab_ShowGuildhestEndedMessageHelpMarker);

        var showLevelNoLongerSynced = configuration.ShowLevelNoLongerSynced;
        if (ImGui.Checkbox(Languages.DutyTab_ShowLevelNoLongerSynced, ref showLevelNoLongerSynced))
        {
            configuration.ShowLevelNoLongerSynced = showLevelNoLongerSynced;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DutyTab_ShowLevelNoLongerSyncedHelpMarker);
    }
}
