namespace TidyChat.Settings.Tabs;

internal static class DesynthesisTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.DesynthesisTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.DesynthesisTab_DesynthesisDropdownHeader, () => DrawDesynthesisOptions(configuration)));
    }

    private static void DrawDesynthesisOptions(Configuration configuration)
    {
        var showDesynthesisLevel = configuration.ShowDesynthesisLevel;
        if (ImGui.Checkbox(Languages.DesynthesisTab_ShowDesynthesisLevelIncreasesMessages,
                ref showDesynthesisLevel))
        {
            configuration.ShowDesynthesisLevel = showDesynthesisLevel;
            configuration.OnSettingChanged();
        }

        UiHelp.ProgressFilterMarker(Languages.DesynthesisTab_ShowDesynthesisLevelIncreasesMessagesHelpMarker);

        var showDesynthedItem = configuration.ShowDesynthedItem;
        if (ImGui.Checkbox(Languages.DesynthesisTab_ShowItemBeingDesynthesized,
                ref showDesynthedItem))
        {
            configuration.ShowDesynthedItem = showDesynthedItem;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DesynthesisTab_ShowItemBeingDesynthesizedHelpMarker);

        var showDesynthesisObtains = configuration.ShowDesynthesisObtains;
        if (ImGui.Checkbox(Languages.DesynthesisTab_ShowObtainedItemsFromDesynthesisMessages,
                ref showDesynthesisObtains))
        {
            configuration.ShowDesynthesisObtains = showDesynthesisObtains;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.DesynthesisTab_ShowObtainedItemsFromDesynthesisMessagesHelpMarker);
    }
}
