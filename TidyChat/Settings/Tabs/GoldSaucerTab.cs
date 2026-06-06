namespace TidyChat.Settings.Tabs;

internal static class GoldSaucerTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.GoldSaucerTab_FilteringNote);

        var hideObtainedMgp = configuration.HideObtainedMGP;
        if (ImGui.Checkbox(Languages.GoldSaucerTab_ShowMGPMessages, ref hideObtainedMgp))
        {
            configuration.HideObtainedMGP = hideObtainedMgp;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedHideFilterMarker(Languages.GoldSaucerTab_ShowMGPMessagesHelpMarker);

        var showGoldSaucerSwingMinigames = configuration.ShowGoldSaucerSwingMinigames;
        if (ImGui.Checkbox(Languages.GoldSaucerTab_ShowSwingMinigames, ref showGoldSaucerSwingMinigames))
        {
            configuration.ShowGoldSaucerSwingMinigames = showGoldSaucerSwingMinigames;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.GoldSaucerTab_ShowSwingMinigamesHelpMarker);

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
