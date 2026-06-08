using Dalamud.Interface.Components;
namespace TidyChat.Settings.Tabs;

internal static class FreeCompanyTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.FreeCompanyTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.FreeCompanyTab_SocialDropdownHeader, () => DrawSocial(configuration)),
            (Languages.FreeCompanyTab_MessageBookDropdownHeader, () => DrawMessageBook(configuration)),
            (Languages.FreeCompanyTab_AirshipsDropdownHeader, () => DrawAirships(configuration)),
            (Languages.FreeCompanyTab_SubmarinesDropdownHeader, () => DrawSubmarines(configuration)));
    }

    private static void DrawSocial(Configuration configuration)
    {
        var showUserLogins = configuration.ShowUserLogins;
        if (ImGui.Checkbox(Languages.FreeCompanyTab_ShowLoginMessages, ref showUserLogins))
        {
            configuration.ShowUserLogins = showUserLogins;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.FreeCompanyTab_ShowLoginMessagesHelpMarker);

        var showUserLogouts = configuration.ShowUserLogouts;
        if (ImGui.Checkbox(Languages.FreeCompanyTab_ShowLogoutMessages, ref showUserLogouts))
        {
            configuration.ShowUserLogouts = showUserLogouts;
            configuration.OnSettingChanged();
        }

        ImGuiComponents.HelpMarker(Languages.FreeCompanyTab_ShowLogoutMessagesHelpMarker);
    }

    private static void DrawMessageBook(Configuration configuration)
    {
        var showFreeCompanyMessageBook = configuration.ShowFreeCompanyMessageBook;
        if (ImGui.Checkbox(Languages.FreeCompanyTab_ShowFreeCompanyMessageBookMessages,
                ref showFreeCompanyMessageBook))
        {
            configuration.ShowFreeCompanyMessageBook = showFreeCompanyMessageBook;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.FreeCompanyTab_ShowFreeCompanyMessageBookMessagesHelpMarker);
    }

    private static void DrawAirships(Configuration configuration)
    {
        var showExploratoryVoyage = configuration.ShowExploratoryVoyage;
        if (ImGui.Checkbox(Languages.FreeCompanyTab_ShowAirshipVoyageMessages, ref showExploratoryVoyage))
        {
            configuration.ShowExploratoryVoyage = showExploratoryVoyage;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.FreeCompanyTab_ShowAirshipVoyageMessagesHelpMarker);
    }

    private static void DrawSubmarines(Configuration configuration)
    {
        var showSubaquaticVoyage = configuration.ShowSubaquaticVoyage;
        if (ImGui.Checkbox(Languages.FreeCompanyTab_ShowSubmarineVoyageMessages, ref showSubaquaticVoyage))
        {
            configuration.ShowSubaquaticVoyage = showSubaquaticVoyage;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.FreeCompanyTab_ShowSubmarineVoyageMessagesHelpMarker);

        SettingsTabLayout.DrawNestedOptions(configuration.ShowSubaquaticVoyage,
            () => DrawSubaquaticSubOptions(configuration));
    }

    private static void DrawSubaquaticSubOptions(Configuration configuration)
    {
        var showEmbarked = configuration.ShowSubaquaticVoyageEmbarked;
        if (ImGui.Checkbox(Languages.FreeCompanyTab_ShowSubaquaticVoyageEmbarked, ref showEmbarked))
        {
            configuration.ShowSubaquaticVoyageEmbarked = showEmbarked;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.FreeCompanyTab_ShowSubaquaticVoyageEmbarkedHelpMarker);

        var showFinalized = configuration.ShowSubaquaticVoyageFinalized;
        if (ImGui.Checkbox(Languages.FreeCompanyTab_ShowSubaquaticVoyageFinalized, ref showFinalized))
        {
            configuration.ShowSubaquaticVoyageFinalized = showFinalized;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.FreeCompanyTab_ShowSubaquaticVoyageFinalizedHelpMarker);

        var showOtherFinalized = configuration.ShowSubaquaticVoyageOtherFinalized;
        if (ImGui.Checkbox(Languages.FreeCompanyTab_ShowSubaquaticVoyageOtherFinalized, ref showOtherFinalized))
        {
            configuration.ShowSubaquaticVoyageOtherFinalized = showOtherFinalized;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.FreeCompanyTab_ShowSubaquaticVoyageOtherFinalizedHelpMarker);

        var showReturned = configuration.ShowSubaquaticVoyageReturned;
        if (ImGui.Checkbox(Languages.FreeCompanyTab_ShowSubaquaticVoyageReturned, ref showReturned))
        {
            configuration.ShowSubaquaticVoyageReturned = showReturned;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.FreeCompanyTab_ShowSubaquaticVoyageReturnedHelpMarker);

        var showPartRepaired = configuration.ShowSubmarinePartRepaired;
        if (ImGui.Checkbox(Languages.FreeCompanyTab_ShowSubmarinePartRepaired, ref showPartRepaired))
        {
            configuration.ShowSubmarinePartRepaired = showPartRepaired;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.FreeCompanyTab_ShowSubmarinePartRepairedHelpMarker);

        var showAttainsRank = configuration.ShowSubmarineAttainsRank;
        if (ImGui.Checkbox(Languages.FreeCompanyTab_ShowSubmarineAttainsRank, ref showAttainsRank))
        {
            configuration.ShowSubmarineAttainsRank = showAttainsRank;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.FreeCompanyTab_ShowSubmarineAttainsRankHelpMarker);

        var showRetrievalLevels = configuration.ShowSubmarineRetrievalLevelsIncreased;
        if (ImGui.Checkbox(Languages.FreeCompanyTab_ShowSubmarineRetrievalLevelsIncreased, ref showRetrievalLevels))
        {
            configuration.ShowSubmarineRetrievalLevelsIncreased = showRetrievalLevels;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.FreeCompanyTab_ShowSubmarineRetrievalLevelsIncreasedHelpMarker);
    }
}
