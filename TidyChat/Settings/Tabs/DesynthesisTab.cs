namespace TidyChat.Settings.Tabs;

internal static class DesynthesisTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.DesynthesisTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.CraftingGatheringTab_DesynthesisDropdownHeader, () => DrawDesynthesisOptions(configuration)));
    }

    private static void DrawDesynthesisOptions(Configuration configuration)
    {
        var showDesynthesisLevel = configuration.ShowDesynthesisLevel;
        if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowDesynthesisLevelIncreasesMessages,
                ref showDesynthesisLevel))
        {
            configuration.ShowDesynthesisLevel = showDesynthesisLevel;
            configuration.OnSettingChanged();
        }

        var showDesynthedItem = configuration.ShowDesynthedItem;
        if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowItemBeingDesynthesized,
                ref showDesynthedItem))
        {
            configuration.ShowDesynthedItem = showDesynthedItem;
            configuration.OnSettingChanged();
        }

        var showDesynthesisObtains = configuration.ShowDesynthesisObtains;
        if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowObtainedItemsFromDesynthesisMessages,
                ref showDesynthesisObtains))
        {
            configuration.ShowDesynthesisObtains = showDesynthesisObtains;
            configuration.OnSettingChanged();
        }
    }
}
