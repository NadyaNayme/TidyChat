namespace TidyChat.Settings.Tabs;

internal static class ExplorationTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.ExplorationTab_FilteringNote);
        SettingsTabLayout.WarnIfChannelMasterDisabled(configuration.FilterSystemMessages, Languages.GeneralTab_FilterSystemSpam);
        SettingsTabLayout.DrawSections(true,
            (Languages.SystemTab_HuntMessagesDropdownHeader, () => DrawHuntMessages(configuration)),
            (Languages.SystemTab_ExplorationDropdownHeader, () => DrawExplorationMessages(configuration)));
    }
    private static void DrawHuntMessages(Configuration configuration)
    {
        var sRankHunt = configuration.ShowSRankHunt;
        if (ImGui.Checkbox(Languages.SystemTab_ShowSRankSpawnAnnouncement, ref sRankHunt))
        {
            configuration.ShowSRankHunt = sRankHunt;
            configuration.OnSettingChanged();
        }
        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSRankSpawnAnnouncementHelpMarker);
        var ssRankHunt = configuration.ShowSSRankHunt;
        if (ImGui.Checkbox(Languages.SystemTab_ShowSSRankMinionSpawnAnnouncement, ref ssRankHunt))
        {
            configuration.ShowSSRankHunt = ssRankHunt;
            configuration.OnSettingChanged();
        }
        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSSRankMinionSpawnAnnouncementHelpMarker);
        var showHuntSlain = configuration.ShowHuntSlain;
        if (ImGui.Checkbox(Languages.SystemTab_ShowHuntMarkSlainMessages, ref showHuntSlain))
        {
            configuration.ShowHuntSlain = showHuntSlain;
            configuration.OnSettingChanged();
        }
        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowHuntMarkSlainMessagesHelpMarker);
        var showMarkBillMessages = configuration.ShowMarkBillMessages;
        if (ImGui.Checkbox(Languages.SystemTab_ShowMarkBillMessages, ref showMarkBillMessages))
        {
            configuration.ShowMarkBillMessages = showMarkBillMessages;
            configuration.OnSettingChanged();
        }
        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowMarkBillMessagesHelpMarker);
    }
    private static void DrawExplorationMessages(Configuration configuration)
    {
        var showQuestReminder = configuration.ShowQuestReminder;
        if (ImGui.Checkbox(Languages.SystemTab_ShowSayReminder, ref showQuestReminder))
        {
            configuration.ShowQuestReminder = showQuestReminder;
            configuration.OnSettingChanged();
        }
        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowSayReminderHelpMarker);
        var showSpideySenses = configuration.ShowSpideySenses;
        if (ImGui.Checkbox(Languages.SystemTab_ShowYouSenseSomethingMessages, ref showSpideySenses))
        {
            configuration.ShowSpideySenses = showSpideySenses;
            configuration.OnSettingChanged();
        }
        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowYouSenseSomethingMessagesHelpMarker);
        SettingsTabLayout.DrawIndependentOptions(() =>
        {
            var showLocationDiscovered = configuration.ShowLocationDiscovered;
            if (ImGui.Checkbox(Languages.SystemTab_ShowLocationDiscoveredMessages, ref showLocationDiscovered))
            {
                configuration.ShowLocationDiscovered = showLocationDiscovered;
                configuration.OnSettingChanged();
            }
            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowLocationDiscoveredMessagesHelpMarker);
            var showHostilePresence = configuration.ShowHostilePresence;
            if (ImGui.Checkbox(Languages.SystemTab_ShowHostilePresenceMessages, ref showHostilePresence))
            {
                configuration.ShowHostilePresence = showHostilePresence;
                configuration.OnSettingChanged();
            }
            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowHostilePresenceMessagesHelpMarker);
        });
        var showAetherCompass = configuration.ShowAetherCompass;
        if (ImGui.Checkbox(Languages.SystemTab_ShowAetherCompassMessages, ref showAetherCompass))
        {
            configuration.ShowAetherCompass = showAetherCompass;
            configuration.OnSettingChanged();
        }
        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowAetherCompassMessagesHelpMarker);
        var showVistaMessages = configuration.ShowVistaMessages;
        if (ImGui.Checkbox(Languages.SystemTab_ShowVistaMessages, ref showVistaMessages))
        {
            configuration.ShowVistaMessages = showVistaMessages;
            configuration.OnSettingChanged();
        }
        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowVistaMessagesHelpMarker);
    }
}
