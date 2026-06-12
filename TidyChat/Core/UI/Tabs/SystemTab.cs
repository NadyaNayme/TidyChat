using Dalamud.Interface.Components;
namespace TidyChat.Settings.Tabs;

internal static class SystemTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.SystemTab_FilteringNote);
        SettingsTabLayout.WarnIfChannelMasterDisabled(configuration.FilterSystemMessages, Languages.GeneralTab_FilterSystemSpam);

        DrawServerAnnouncements(configuration);
        SettingsTabLayout.DrawSectionSeparator();

        SettingsTabLayout.DrawSections(true,
            (Languages.SystemTab_TravelDropdownHeader, () => DrawTravel(configuration)),
            (Languages.SystemTab_SocialDropdownHeader, () => DrawSocial(configuration)),
            (Languages.SystemTab_MailDropdownHeader, () => DrawMail(configuration)),
            (Languages.SystemTab_OrchestrionDropdownHeader, () => DrawOrchestrion(configuration)),
            (Languages.SystemTab_ItemSearchDropdownHeader, () => DrawItemSearch(configuration)),
            (Languages.SystemTab_CatchAllDropdownHeader, () => DrawCatchAll(configuration)),
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

        ImGui.TextUnformatted(Languages.SystemTab_ServerAnnouncementsDropdownHeader);
        ImGui.Spacing();

        ImGui.TextUnformatted(Languages.SystemTab_ServerAnnouncementsLabel);
        ImGui.SameLine();
        ImGuiComponents.HelpMarker(Languages.SystemTab_ServerAnnouncementsHelpMarker);

        var comboWidth = 0f;
        foreach (var mode in serverAnnouncementModes)
        {
            comboWidth = Math.Max(comboWidth, ImGui.CalcTextSize(mode).X);
        }

        var style = ImGui.GetStyle();
        comboWidth += style.FramePadding.X * 2f + ImGui.GetFrameHeight();
        ImGui.SetNextItemWidth(comboWidth);
        if (ImGui.BeginCombo("##serverAnnouncementMode", serverAnnouncementModes[serverAnnouncementMode]))
        {
            for (var i = 0; i < serverAnnouncementModes.Length; i++)
            {
                var isSelected = serverAnnouncementMode == i;
                if (ImGui.Selectable(serverAnnouncementModes[i], isSelected))
                {
                    configuration.ServerAnnouncementMode = (ServerAnnouncementMode)i;
                    configuration.OnSettingChanged();
                }

                if (isSelected)
                {
                    ImGui.SetItemDefaultFocus();
                }
            }

            ImGui.EndCombo();
        }
    }

    private static void DrawTravel(Configuration configuration)
    {
        var showAetheryteTicket = configuration.ShowAetheryteTicket;
        if (ImGui.Checkbox(Languages.SystemTab_ShowAetheryteTicketMessage, ref showAetheryteTicket))
        {
            configuration.ShowAetheryteTicket = showAetheryteTicket;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowAetheryteTicketMessageHelpMarker);
    }

    private static void DrawSocial(Configuration configuration)
    {
        var showPersonalMessageBook = configuration.ShowPersonalMessageBook;
        if (ImGui.Checkbox(Languages.SystemTab_ShowPersonalMessageBookMessages, ref showPersonalMessageBook))
        {
            configuration.ShowPersonalMessageBook = showPersonalMessageBook;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowPersonalMessageBookMessagesHelpMarker);

        var showOnlineStatus = configuration.ShowOnlineStatus;
        if (ImGui.Checkbox(Languages.SystemTab_ShowOnlineStatusMessages, ref showOnlineStatus))
        {
            configuration.ShowOnlineStatus = showOnlineStatus;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowOnlineStatusMessagesHelpMarker);
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

    private static void DrawOrchestrion(Configuration configuration)
    {
        var hideOrchestrionPlaying = configuration.HideOrchestrionPlaying;
        if (ImGui.Checkbox(Languages.SystemTab_HideOrchestrionPlaying, ref hideOrchestrionPlaying))
        {
            configuration.HideOrchestrionPlaying = hideOrchestrionPlaying;
            configuration.OnSettingChanged();
        }

        UiHelp.StandaloneHideFilterMarker(Languages.SystemTab_HideOrchestrionPlayingHelpMarker);
    }

    private static void DrawItemSearch(Configuration configuration)
    {
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
    }

    private static void DrawErrorMessages(Configuration configuration)
    {
        var hideFateLevelSync = configuration.HideFateLevelSync;
        if (ImGui.Checkbox(Languages.SystemTab_HideFateLevelSyncMessages, ref hideFateLevelSync))
        {
            configuration.HideFateLevelSync = hideFateLevelSync;
            configuration.OnSettingChanged();
        }

        UiHelp.StandaloneHideFilterMarker(Languages.SystemTab_HideFateLevelSyncMessagesHelpMarker);

        var showActiveHelpEntry = configuration.ShowActiveHelpEntry;
        if (ImGui.Checkbox(Languages.SystemTab_ShowActiveHelpEntryMessages, ref showActiveHelpEntry))
        {
            configuration.ShowActiveHelpEntry = showActiveHelpEntry;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.SystemTab_ShowActiveHelpEntryMessagesHelpMarker);
    }
}
