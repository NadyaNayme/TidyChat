namespace TidyChat.Settings.Tabs;

internal static class CurrenciesTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.CurrenciesTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.CurrenciesTab_CommonCurrenciesDropdownHeader, () => DrawCommonCurrencies(configuration)),
            (Languages.CurrenciesTab_BattleCurrenciesDropdownHeader, () => DrawBattleCurrencies(configuration)));
    }

    private static void DrawCommonCurrencies(Configuration configuration)
    {
        var showObtainedItems = configuration.ShowObtainedItems;
        if (ImGui.Checkbox(Languages.CurrenciesTab_ShowGeneralItemObtains, ref showObtainedItems))
        {
            configuration.ShowObtainedItems = showObtainedItems;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.CurrenciesTab_ShowGeneralItemObtainsHelpMarker);

        var hideInventoryItemAdded = configuration.HideInventoryItemAdded;
        if (ImGui.Checkbox(Languages.CurrenciesTab_HideInventoryItemAddedMessages, ref hideInventoryItemAdded))
        {
            configuration.HideInventoryItemAdded = hideInventoryItemAdded;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.CurrenciesTab_HideInventoryItemAddedMessagesHelpMarker);

        var showObtainedQuestItems = configuration.ShowObtainedQuestItems;
        if (ImGui.Checkbox(Languages.CurrenciesTab_ShowObtainedQuestItems, ref showObtainedQuestItems))
        {
            configuration.ShowObtainedQuestItems = showObtainedQuestItems;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.CurrenciesTab_ShowObtainedQuestItemsHelpMarker);

        var hideObtainedgil = configuration.HideObtainedGil;
        if (ImGui.Checkbox(Languages.CurrenciesTab_ShowGil, ref hideObtainedgil))
        {
            configuration.HideObtainedGil = hideObtainedgil;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.CurrenciesTab_ShowGilHelpMarker);

        var hideObtainedSeals = configuration.HideObtainedSeals;
        if (ImGui.Checkbox(Languages.CurrenciesTab_ShowGrandCompanySealsMessages, ref hideObtainedSeals))
        {
            configuration.HideObtainedSeals = hideObtainedSeals;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.CurrenciesTab_ShowGrandCompanySealsMessagesHelpMarker);

        var hideObtainedVenture = configuration.HideObtainedVenture;
        if (ImGui.Checkbox(Languages.CurrenciesTab_ShowVentureMessages, ref hideObtainedVenture))
        {
            configuration.HideObtainedVenture = hideObtainedVenture;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.CurrenciesTab_ShowVentureMessagesHelpMarker);
    }

    private static void DrawBattleCurrencies(Configuration configuration)
    {
        if (TidyChatPlugin.Tomestones.Count == 0)
        {
            ImGui.TextDisabled(Languages.CurrenciesTab_TomestoneDataUnavailable);
        }
        else
        {
            foreach (var tomestone in TidyChatPlugin.Tomestones)
            {
                configuration.HideTomestoneById.TryGetValue(tomestone.RowId, out var hide);
                if (ImGui.Checkbox($"Hide {tomestone.Name}", ref hide))
                {
                    configuration.HideTomestoneById[tomestone.RowId] = hide;
                    configuration.OnSettingChanged();
                }
            }
        }

        var hideObtainedWolfMarks = configuration.HideObtainedWolfMarks;
        if (ImGui.Checkbox(Languages.CurrenciesTab_ShowWolfMarksMessages, ref hideObtainedWolfMarks))
        {
            configuration.HideObtainedWolfMarks = hideObtainedWolfMarks;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.CurrenciesTab_ShowWolfMarksMessagesHelpMarker);

        var hideObtainedAlliedSeals = configuration.HideObtainedAlliedSeals;
        if (ImGui.Checkbox(Languages.CurrenciesTab_ShowAlliedSealsMessages, ref hideObtainedAlliedSeals))
        {
            configuration.HideObtainedAlliedSeals = hideObtainedAlliedSeals;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.CurrenciesTab_ShowAlliedSealsMessagesHelpMarker);

        var hideObtainedCenturioSeals = configuration.HideObtainedCenturioSeals;
        if (ImGui.Checkbox(Languages.CurrenciesTab_ShowCenturioSealsMessages, ref hideObtainedCenturioSeals))
        {
            configuration.HideObtainedCenturioSeals = hideObtainedCenturioSeals;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.CurrenciesTab_ShowCenturioSealsMessagesHelpMarker);

        var hideObtainedNuts = configuration.HideObtainedNuts;
        if (ImGui.Checkbox(Languages.CurrenciesTab_ShowSacksOfNutsMessages, ref hideObtainedNuts))
        {
            configuration.HideObtainedNuts = hideObtainedNuts;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.CurrenciesTab_ShowSacksOfNutsMessagesHelpMarker);
    }
}

