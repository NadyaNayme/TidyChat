using Dalamud.Interface.Components;
namespace TidyChat.Settings.Tabs;

internal static class SystemTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.SystemTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.SystemTab_ServerAnnouncementsDropdownHeader, () => DrawServerAnnouncements(configuration)),
            (Languages.SystemTab_WorldAndInstancesDropdownHeader, () => DrawWorldAndInstances(configuration)),
            (Languages.SystemTab_SocialAndMiscDropdownHeader, () => DrawSocialAndMisc(configuration)),
            (Languages.SystemTab_MailDropdownHeader, () => DrawMail(configuration)),
            (Languages.SystemTab_RelicDropdownHeader, () => DrawRelic(configuration)),
            (Languages.SystemTab_SocialStatusDropdownHeader, () => DrawSocialStatus(configuration)),
            (Languages.SystemTab_CatchAllDropdownHeader, () => DrawCatchAll(configuration)),
            (Languages.SystemTab_OrchestrionDropdownHeader, () => DrawOrchestrion(configuration)),
            (Languages.SystemTab_CrackedClustersDropdownHeader, () => DrawCrackedClusters(configuration)),
            (Languages.SystemTab_ErrorMessagesDropdownHeader, () => DrawErrorMessages(configuration)));
    }

    private static void DrawServerAnnouncements(Configuration configuration)
    {
        string[] serverAnnouncementModes =
        [
            Languages.SystemTab_ServerAnnouncementMode_ShowAll,
            Languages.SystemTab_ServerAnnouncementMode_HideAll,
            Languages.SystemTab_ServerAnnouncementMode_Condensed,
            Languages.SystemTab_ServerAnnouncementMode_LoginOnly,
            Languages.SystemTab_ServerAnnouncementMode_LoginThenCondensed,
            Languages.SystemTab_ServerAnnouncementMode_HidePhishing
        ];
        var serverAnnouncementMode =
            Math.Clamp((int)configuration.ServerAnnouncementMode, 0, serverAnnouncementModes.Length - 1);
        ImGui.TextUnformatted(Languages.SystemTab_ServerAnnouncementsLabel);
        ImGui.SetNextItemWidth(320f);
        if (ImGui.BeginCombo("##serverAnnouncementMode", serverAnnouncementModes[serverAnnouncementMode]))
        {
            for (var i = 0; i < serverAnnouncementModes.Length; i++)
            {
                if (ImGui.Selectable(serverAnnouncementModes[i], serverAnnouncementMode == i))
                {
                    configuration.ServerAnnouncementMode = (ServerAnnouncementMode)i;
                    configuration.OnSettingChanged();
                }
            }

            ImGui.EndCombo();
        }

        ImGuiComponents.HelpMarker(Languages.SystemTab_ServerAnnouncementsHelpMarker);
    }

    private static void DrawWorldAndInstances(Configuration configuration)
    {
        var instanceMessage = configuration.ShowInstanceMessage;
        if (ImGui.Checkbox(Languages.SystemTab_ShowInstanceMessage, ref instanceMessage))
        {
            configuration.ShowInstanceMessage = instanceMessage;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowInstanceMessageHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowInstanceMessage,
            () => DrawInstanceMessageSubOptions(configuration));
    }

    private static void DrawSocialAndMisc(Configuration configuration)
    {
        var commendations = configuration.ShowCommendations;
        if (ImGui.Checkbox(Languages.SystemTab_ShowReceivedCommendations, ref commendations))
        {
            configuration.ShowCommendations = commendations;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowReceivedCommendationsHelpMarker);

        var showPersonalMessageBook = configuration.ShowPersonalMessageBook;
        if (ImGui.Checkbox(Languages.SystemTab_ShowPersonalMessageBookMessages, ref showPersonalMessageBook))
        {
            configuration.ShowPersonalMessageBook = showPersonalMessageBook;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowPersonalMessageBookMessagesHelpMarker);

        var showAetheryteTicket = configuration.ShowAetheryteTicket;
        if (ImGui.Checkbox(Languages.SystemTab_ShowAetheryteTicketMessage, ref showAetheryteTicket))
        {
            configuration.ShowAetheryteTicket = showAetheryteTicket;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowAetheryteTicketMessageHelpMarker);

        var showAttuneAetheryte = configuration.ShowAttuneAetheryte;
        if (ImGui.Checkbox(Languages.SystemTab_ShowAttuneAetheryteMessage, ref showAttuneAetheryte))
        {
            configuration.ShowAttuneAetheryte = showAttuneAetheryte;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowAttuneAetheryteMessageHelpMarker);
    }

    private static void DrawMail(Configuration configuration)
    {
        var showAttachToMail = configuration.ShowAttachToMail;
        if (ImGui.Checkbox(Languages.SystemTab_ShowMailAttachmentMessages, ref showAttachToMail))
        {
            configuration.ShowAttachToMail = showAttachToMail;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowMailAttachmentMessagesHelpMarker);
    }

    private static void DrawRelic(Configuration configuration)
    {
        var showRelicBookStep = configuration.ShowRelicBookStep;
        if (ImGui.Checkbox(Languages.SystemTab_ShowARRRelicProgressMessages, ref showRelicBookStep))
        {
            configuration.ShowRelicBookStep = showRelicBookStep;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowARRRelicProgressMessagesHelpMarker);

        var showRelicBookComplete = configuration.ShowRelicBookComplete;
        if (ImGui.Checkbox(Languages.SystemTab_ShowARRRelicBookStepMessages, ref showRelicBookComplete))
        {
            configuration.ShowRelicBookComplete = showRelicBookComplete;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowARRRelicBookStepMessagesHelpMarker);
    }

    private static void DrawSocialStatus(Configuration configuration)
    {
        var showOnlineStatus = configuration.ShowOnlineStatus;
        if (ImGui.Checkbox(Languages.SystemTab_ShowOnlineStatusMessages, ref showOnlineStatus))
        {
            configuration.ShowOnlineStatus = showOnlineStatus;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowOnlineStatusMessagesHelpMarker);

        var showSearchForItemResults = configuration.ShowSearchForItemResults;
        if (ImGui.Checkbox(Languages.SystemTab_ShowItemSearchResultsMessage, ref showSearchForItemResults))
        {
            configuration.ShowSearchForItemResults = showSearchForItemResults;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowItemSearchResultsMessageHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowSearchForItemResults, () =>
        {
            var showItemSearchResults = configuration.ShowItemSearchResults;
            if (ImGui.Checkbox(Languages.SystemTab_ShowInventoryItemSearchResults, ref showItemSearchResults))
            {
                configuration.ShowItemSearchResults = showItemSearchResults;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowInventoryItemSearchResultsHelpMarker);

            var showLocationSearchResults = configuration.ShowLocationSearchResults;
            if (ImGui.Checkbox(Languages.SystemTab_ShowLocationSearchResults, ref showLocationSearchResults))
            {
                configuration.ShowLocationSearchResults = showLocationSearchResults;
                configuration.OnSettingChanged();
            }

            UiHelp.SystemFilterMarker(Languages.SystemTab_ShowLocationSearchResultsHelpMarker);
        });
    }

    private static void DrawCatchAll(Configuration configuration)
    {
        var showEverythingElse = configuration.ShowEverythingElse;
        if (ImGui.Checkbox(Languages.SystemTab_ShowEverythingElse, ref showEverythingElse))
        {
            configuration.ShowEverythingElse = showEverythingElse;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.SystemTab_ShowEverythingElseHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowEverythingElse,
            () => DrawMiscSystemSubOptions(configuration));
    }

    private static void DrawOrchestrion(Configuration configuration)
    {
        var hideOrchestrionPlaying = configuration.HideOrchestrionPlaying;
        if (ImGui.Checkbox(Languages.SystemTab_ShowOrchestrionPlaying, ref hideOrchestrionPlaying))
        {
            configuration.HideOrchestrionPlaying = hideOrchestrionPlaying;
            configuration.OnSettingChanged();
        }

        UiHelp.StandaloneHideFilterMarker(Languages.SystemTab_ShowOrchestrionPlayingHelpMarker);
    }

    private static void DrawCrackedClusters(Configuration configuration)
    {
        var hideObtainedClusters = configuration.HideObtainedClusters;
        if (ImGui.Checkbox(Languages.SystemTab_ShowCrackedClustersMessages, ref hideObtainedClusters))
        {
            configuration.HideObtainedClusters = hideObtainedClusters;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedHideFilterMarker(Languages.SystemTab_ShowCrackedClustersMessagesHelpMarker);
    }

    private static void DrawErrorMessages(Configuration configuration)
    {
        var hideFateLevelSync = configuration.HideFateLevelSync;
        if (ImGui.Checkbox(Languages.SystemTab_ShowFateLevelSyncMessages, ref hideFateLevelSync))
        {
            configuration.HideFateLevelSync = hideFateLevelSync;
            configuration.OnSettingChanged();
        }

        UiHelp.StandaloneHideFilterMarker(Languages.SystemTab_ShowFateLevelSyncMessagesHelpMarker);

        var showActiveHelpEntry = configuration.ShowActiveHelpEntry;
        if (ImGui.Checkbox(Languages.SystemTab_ShowActiveHelpEntryMessages, ref showActiveHelpEntry))
        {
            configuration.ShowActiveHelpEntry = showActiveHelpEntry;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowActiveHelpEntryMessagesHelpMarker);
    }

    private static void DrawInstanceMessageSubOptions(Configuration configuration)
    {
        var showInstancedArea = configuration.ShowInstancedAreaMessages;
        if (ImGui.Checkbox(Languages.SystemTab_ShowInstancedAreaMessages, ref showInstancedArea))
        {
            configuration.ShowInstancedAreaMessages = showInstancedArea;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowInstancedAreaMessagesHelpMarker);

        var showDutyEnded = configuration.ShowDutyEndedMessage;
        if (ImGui.Checkbox(Languages.SystemTab_ShowDutyEndedMessage, ref showDutyEnded))
        {
            configuration.ShowDutyEndedMessage = showDutyEnded;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowDutyEndedMessageHelpMarker);

        var showGuildhestEnded = configuration.ShowGuildhestEndedMessage;
        if (ImGui.Checkbox(Languages.SystemTab_ShowGuildhestEndedMessage, ref showGuildhestEnded))
        {
            configuration.ShowGuildhestEndedMessage = showGuildhestEnded;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowGuildhestEndedMessageHelpMarker);

        var showLevelNoLongerSynced = configuration.ShowLevelNoLongerSynced;
        if (ImGui.Checkbox(Languages.SystemTab_ShowLevelNoLongerSynced, ref showLevelNoLongerSynced))
        {
            configuration.ShowLevelNoLongerSynced = showLevelNoLongerSynced;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowLevelNoLongerSyncedHelpMarker);

        var showDutyMechanic = configuration.ShowDutyMechanicMessages;
        if (ImGui.Checkbox(Languages.SystemTab_ShowDutyMechanicMessages, ref showDutyMechanic))
        {
            configuration.ShowDutyMechanicMessages = showDutyMechanic;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowDutyMechanicMessagesHelpMarker);

        var showDutyObjectiveBonus = configuration.ShowDutyObjectiveBonus;
        if (ImGui.Checkbox(Languages.SystemTab_ShowDutyObjectiveBonus, ref showDutyObjectiveBonus))
        {
            configuration.ShowDutyObjectiveBonus = showDutyObjectiveBonus;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowDutyObjectiveBonusHelpMarker);
    }

    private static void DrawMiscSystemSubOptions(Configuration configuration)
    {
        var showChangesDiscarded = configuration.ShowChangesDiscarded;
        if (ImGui.Checkbox(Languages.SystemTab_ShowChangesDiscarded, ref showChangesDiscarded))
        {
            configuration.ShowChangesDiscarded = showChangesDiscarded;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowChangesDiscardedHelpMarker);

        var showChangesLost = configuration.ShowChangesLost;
        if (ImGui.Checkbox(Languages.SystemTab_ShowChangesLost, ref showChangesLost))
        {
            configuration.ShowChangesLost = showChangesLost;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowChangesLostHelpMarker);
    }
}
