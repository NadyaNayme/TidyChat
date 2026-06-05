namespace TidyChat.Settings.Tabs;

internal static class FreeCompanyTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.FreeCompanyTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.FreeCompanyTab_SocialDropdownHeader, () => DrawSocial(configuration)),
            (Languages.FreeCompanyTab_MessageBookDropdownHeader, () => DrawMessageBook(configuration)),
            (Languages.FreeCompanyTab_WorkshopDropdownHeader, () => DrawWorkshop(configuration)));
    }

    private static void DrawSocial(Configuration configuration)
    {
        var showUserLogins = configuration.ShowUserLogins;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowLoginMessages, ref showUserLogins))
        {
            configuration.ShowUserLogins = showUserLogins;
            configuration.OnSettingChanged();
        }

        var showUserLogouts = configuration.ShowUserLogouts;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowLogoutMessages, ref showUserLogouts))
        {
            configuration.ShowUserLogouts = showUserLogouts;
            configuration.OnSettingChanged();
        }
    }

    private static void DrawMessageBook(Configuration configuration)
    {
        var showFreeCompanyMessageBook = configuration.ShowFreeCompanyMessageBook;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowFreeCompanyMessageBookMessages,
                ref showFreeCompanyMessageBook))
        {
            configuration.ShowFreeCompanyMessageBook = showFreeCompanyMessageBook;
            configuration.OnSettingChanged();
        }
    }

    private static void DrawWorkshop(Configuration configuration)
    {
        var showExploratoryVoyage = configuration.ShowExploratoryVoyage;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowAirshipVoyageMessages, ref showExploratoryVoyage))
        {
            configuration.ShowExploratoryVoyage = showExploratoryVoyage;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowAirshipVoyageMessagesHelpMarker);

        SettingsTabLayout.DrawSectionSeparator();

        var showSubaquaticVoyage = configuration.ShowSubaquaticVoyage;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSubmarineVoyageMessages, ref showSubaquaticVoyage))
        {
            configuration.ShowSubaquaticVoyage = showSubaquaticVoyage;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowSubmarineVoyageMessagesHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowSubaquaticVoyage,
            () => DrawSubaquaticSubOptions(configuration));
    }

    private static void DrawSubaquaticSubOptions(Configuration configuration)
    {
        var showEmbarked = configuration.ShowSubaquaticVoyageEmbarked;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSubaquaticVoyageEmbarked, ref showEmbarked))
        {
            configuration.ShowSubaquaticVoyageEmbarked = showEmbarked;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowSubaquaticVoyageEmbarkedHelpMarker);

        var showFinalized = configuration.ShowSubaquaticVoyageFinalized;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSubaquaticVoyageFinalized, ref showFinalized))
        {
            configuration.ShowSubaquaticVoyageFinalized = showFinalized;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowSubaquaticVoyageFinalizedHelpMarker);

        var showOtherFinalized = configuration.ShowSubaquaticVoyageOtherFinalized;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSubaquaticVoyageOtherFinalized, ref showOtherFinalized))
        {
            configuration.ShowSubaquaticVoyageOtherFinalized = showOtherFinalized;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowSubaquaticVoyageOtherFinalizedHelpMarker);

        var showReturned = configuration.ShowSubaquaticVoyageReturned;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSubaquaticVoyageReturned, ref showReturned))
        {
            configuration.ShowSubaquaticVoyageReturned = showReturned;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowSubaquaticVoyageReturnedHelpMarker);

        var showPartRepaired = configuration.ShowSubmarinePartRepaired;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSubmarinePartRepaired, ref showPartRepaired))
        {
            configuration.ShowSubmarinePartRepaired = showPartRepaired;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowSubmarinePartRepairedHelpMarker);

        var showAttainsRank = configuration.ShowSubmarineAttainsRank;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSubmarineAttainsRank, ref showAttainsRank))
        {
            configuration.ShowSubmarineAttainsRank = showAttainsRank;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowSubmarineAttainsRankHelpMarker);

        var showRetrievalLevels = configuration.ShowSubmarineRetrievalLevelsIncreased;
        if (ImGui.Checkbox(Languages.PartyDutyTab_ShowSubmarineRetrievalLevelsIncreased, ref showRetrievalLevels))
        {
            configuration.ShowSubmarineRetrievalLevelsIncreased = showRetrievalLevels;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.PartyDutyTab_ShowSubmarineRetrievalLevelsIncreasedHelpMarker);
    }
}
