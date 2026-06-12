namespace TidyChat.Settings.Tabs;

internal static class ExplorationTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.ExplorationTab_FilteringNote);
        SettingsTabLayout.WarnIfChannelMasterDisabled(configuration.FilterSystemMessages, Languages.GeneralTab_FilterSystemSpam);
        SettingsTabLayout.DrawSections(true,
            (Languages.ExplorationTab_HuntMessagesDropdownHeader, () => DrawHuntMessages(configuration)),
            (Languages.ExplorationTab_ExplorationDropdownHeader, () => DrawExplorationMessages(configuration)));
    }

    private static void DrawHuntMessages(Configuration configuration)
    {
        var sRankHunt = configuration.ShowSRankHunt;
        if (ImGui.Checkbox(Languages.ExplorationTab_ShowSRankSpawnAnnouncement, ref sRankHunt))
        {
            configuration.ShowSRankHunt = sRankHunt;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.ExplorationTab_ShowSRankSpawnAnnouncementHelpMarker);

        var ssRankHunt = configuration.ShowSSRankHunt;
        if (ImGui.Checkbox(Languages.ExplorationTab_ShowSSRankMinionSpawnAnnouncement, ref ssRankHunt))
        {
            configuration.ShowSSRankHunt = ssRankHunt;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.ExplorationTab_ShowSSRankMinionSpawnAnnouncementHelpMarker);

        var showHuntSlain = configuration.ShowHuntSlain;
        if (ImGui.Checkbox(Languages.ExplorationTab_ShowHuntMarkSlainMessages, ref showHuntSlain))
        {
            configuration.ShowHuntSlain = showHuntSlain;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.ExplorationTab_ShowHuntMarkSlainMessagesHelpMarker);

        var showMarkBillMessages = configuration.ShowMarkBillMessages;
        if (ImGui.Checkbox(Languages.ExplorationTab_ShowMarkBillMessages, ref showMarkBillMessages))
        {
            configuration.ShowMarkBillMessages = showMarkBillMessages;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.ExplorationTab_ShowMarkBillMessagesHelpMarker);
    }

    private static void DrawExplorationMessages(Configuration configuration)
    {
        var showQuestReminder = configuration.ShowQuestReminder;
        if (ImGui.Checkbox(Languages.ExplorationTab_ShowSayReminder, ref showQuestReminder))
        {
            configuration.ShowQuestReminder = showQuestReminder;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.ExplorationTab_ShowSayReminderHelpMarker);

        var showSpideySenses = configuration.ShowSpideySenses;
        if (ImGui.Checkbox(Languages.ExplorationTab_ShowYouSenseSomethingMessages, ref showSpideySenses))
        {
            configuration.ShowSpideySenses = showSpideySenses;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.ExplorationTab_ShowYouSenseSomethingMessagesHelpMarker);

        SettingsTabLayout.DrawIndependentOptions(() =>
        {
            var showLocationDiscovered = configuration.ShowLocationDiscovered;
            if (ImGui.Checkbox(Languages.ExplorationTab_ShowLocationDiscoveredMessages, ref showLocationDiscovered))
            {
                configuration.ShowLocationDiscovered = showLocationDiscovered;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.ExplorationTab_ShowLocationDiscoveredMessagesHelpMarker);

            var showHostilePresence = configuration.ShowHostilePresence;
            if (ImGui.Checkbox(Languages.ExplorationTab_ShowHostilePresenceMessages, ref showHostilePresence))
            {
                configuration.ShowHostilePresence = showHostilePresence;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.ExplorationTab_ShowHostilePresenceMessagesHelpMarker);
        });

        var showAetherCompass = configuration.ShowAetherCompass;
        if (ImGui.Checkbox(Languages.ExplorationTab_ShowAetherCompassMessages, ref showAetherCompass))
        {
            configuration.ShowAetherCompass = showAetherCompass;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.ExplorationTab_ShowAetherCompassMessagesHelpMarker);

        var showVistaMessages = configuration.ShowVistaMessages;
        if (ImGui.Checkbox(Languages.ExplorationTab_ShowVistaMessages, ref showVistaMessages))
        {
            configuration.ShowVistaMessages = showVistaMessages;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.ExplorationTab_ShowVistaMessagesHelpMarker);
    }
}
