namespace TidyChat.Settings.Tabs;

internal static class GoldSaucerTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.GoldSaucerTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.GoldSaucerTab_MgpDropdownHeader, () => DrawMgp(configuration)),
            (Languages.GoldSaucerTab_MinigamesDropdownHeader, () => DrawMinigames(configuration)),
            (Languages.GoldSaucerTab_TripleTriadDropdownHeader, () => DrawTripleTriad(configuration)));
    }

    private static void DrawMgp(Configuration configuration)
    {
        var hideObtainedMgp = configuration.HideObtainedMGP;
        if (ImGui.Checkbox(Languages.GoldSaucerTab_ShowMGPMessages, ref hideObtainedMgp))
        {
            configuration.HideObtainedMGP = hideObtainedMgp;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.GoldSaucerTab_ShowMGPMessagesHelpMarker);
    }

    private static void DrawMinigames(Configuration configuration)
    {
        var showGoldSaucerSwingMinigames = configuration.ShowGoldSaucerSwingMinigames;
        if (ImGui.Checkbox(Languages.GoldSaucerTab_ShowSwingMinigames, ref showGoldSaucerSwingMinigames))
        {
            configuration.ShowGoldSaucerSwingMinigames = showGoldSaucerSwingMinigames;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.GoldSaucerTab_ShowSwingMinigamesHelpMarker);
    }

    private static void DrawTripleTriad(Configuration configuration)
    {
        var showTripleTriadAllowed = configuration.ShowTripleTriadAllowed;
        if (ImGui.Checkbox(Languages.GoldSaucerTab_ShowTripleTriadAllowed, ref showTripleTriadAllowed))
        {
            configuration.ShowTripleTriadAllowed = showTripleTriadAllowed;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.GoldSaucerTab_ShowTripleTriadAllowedHelpMarker);

        var showTripleTriadNotAllowed = configuration.ShowTripleTriadNotAllowed;
        if (ImGui.Checkbox(Languages.GoldSaucerTab_ShowTripleTriadNotAllowed, ref showTripleTriadNotAllowed))
        {
            configuration.ShowTripleTriadNotAllowed = showTripleTriadNotAllowed;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.GoldSaucerTab_ShowTripleTriadNotAllowedHelpMarker);
    }
}
