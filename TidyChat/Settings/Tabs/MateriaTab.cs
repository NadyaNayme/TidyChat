namespace TidyChat.Settings.Tabs;

internal static class MateriaTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.MateriaTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.CraftingGatheringTab_MateriaDropdownHeader, () => DrawMateriaOptions(configuration)));
    }

    private static void DrawMateriaOptions(Configuration configuration)
    {
        var showAttachedMateria = configuration.ShowAttachedMateria;
        if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaSuccesfullyAttachedMessages,
                ref showAttachedMateria))
        {
            configuration.ShowAttachedMateria = showAttachedMateria;
            configuration.OnSettingChanged();
        }

        var showOvermeldFailure = configuration.ShowOvermeldFailure;
        if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaOvermeldFailuresMessages,
                ref showOvermeldFailure))
        {
            configuration.ShowOvermeldFailure = showOvermeldFailure;
            configuration.OnSettingChanged();
        }

        var showMateriaRetrieved = configuration.ShowMateriaRetrieved;
        if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowSuccesfullyRetrievedMateriaMessages,
                ref showMateriaRetrieved))
        {
            configuration.ShowMateriaRetrieved = showMateriaRetrieved;
            configuration.OnSettingChanged();
        }

        var showMateriaShatters = configuration.ShowMateriaShatters;
        if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaShattersMessages, ref showMateriaShatters))
        {
            configuration.ShowMateriaShatters = showMateriaShatters;
            configuration.OnSettingChanged();
        }

        var showMateriaExtract = configuration.ShowMateriaExtract;
        if (ImGui.Checkbox(Languages.CraftingGatheringTab_ShowMateriaExtractedMessages, ref showMateriaExtract))
        {
            configuration.ShowMateriaExtract = showMateriaExtract;
            configuration.OnSettingChanged();
        }
    }
}
