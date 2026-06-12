namespace TidyChat.Settings.Tabs;

internal static class MateriaTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.MateriaTab_FilteringNote);
        SettingsTabLayout.WarnIfChannelMasterDisabled(configuration.FilterCraftingSpam, Languages.GeneralTab_FilterCraftingSpam);
        SettingsTabLayout.WarnIfChannelMasterDisabled(configuration.FilterSystemMessages, Languages.GeneralTab_FilterSystemSpam);

        SettingsTabLayout.DrawSections(true,
            (Languages.MateriaTab_MateriaDropdownHeader, () => DrawMateriaOptions(configuration)));
    }

    private static void DrawMateriaOptions(Configuration configuration)
    {
        var showSpiritboundGear = configuration.ShowSpiritboundGear;
        if (ImGui.Checkbox(Languages.MateriaTab_ShowSpiritboundMessages, ref showSpiritboundGear))
        {
            configuration.ShowSpiritboundGear = showSpiritboundGear;
            configuration.OnSettingChanged();
        }

        UiHelp.SystemFilterMarker(Languages.MateriaTab_ShowSpiritboundMessagesHelpMarker);

        var showMateriaExtract = configuration.ShowMateriaExtract;
        if (ImGui.Checkbox(Languages.MateriaTab_ShowMateriaExtractedMessages, ref showMateriaExtract))
        {
            configuration.ShowMateriaExtract = showMateriaExtract;
            configuration.OnSettingChanged();
        }

        UiHelp.CraftingFilterMarker(Languages.MateriaTab_ShowMateriaExtractedMessagesHelpMarker);

        var showAttachedMateria = configuration.ShowAttachedMateria;
        if (ImGui.Checkbox(Languages.MateriaTab_ShowMateriaSuccesfullyAttachedMessages,
                ref showAttachedMateria))
        {
            configuration.ShowAttachedMateria = showAttachedMateria;
            configuration.OnSettingChanged();
        }

        UiHelp.CraftingFilterMarker(Languages.MateriaTab_ShowMateriaSuccesfullyAttachedMessagesHelpMarker);

        var showOvermeldFailure = configuration.ShowOvermeldFailure;
        if (ImGui.Checkbox(Languages.MateriaTab_ShowMateriaOvermeldFailuresMessages,
                ref showOvermeldFailure))
        {
            configuration.ShowOvermeldFailure = showOvermeldFailure;
            configuration.OnSettingChanged();
        }

        UiHelp.CraftingFilterMarker(Languages.MateriaTab_ShowMateriaOvermeldFailuresMessagesHelpMarker);

        var showMateriaRetrieved = configuration.ShowMateriaRetrieved;
        if (ImGui.Checkbox(Languages.MateriaTab_ShowSuccesfullyRetrievedMateriaMessages,
                ref showMateriaRetrieved))
        {
            configuration.ShowMateriaRetrieved = showMateriaRetrieved;
            configuration.OnSettingChanged();
        }

        UiHelp.CraftingFilterMarker(Languages.MateriaTab_ShowSuccesfullyRetrievedMateriaMessagesHelpMarker);

        var showMateriaShatters = configuration.ShowMateriaShatters;
        if (ImGui.Checkbox(Languages.MateriaTab_ShowMateriaShattersMessages, ref showMateriaShatters))
        {
            configuration.ShowMateriaShatters = showMateriaShatters;
            configuration.OnSettingChanged();
        }

        UiHelp.CraftingFilterMarker(Languages.MateriaTab_ShowMateriaShattersMessagesHelpMarker);
    }
}
