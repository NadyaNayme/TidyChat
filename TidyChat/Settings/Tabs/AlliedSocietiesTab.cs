namespace TidyChat.Settings.Tabs;

internal static class AlliedSocietiesTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.ObtainTab_FilteringNote);

        SettingsTabLayout.DrawSections(true,
            (Languages.AlliedSocietiesTab_MaterialsDropdownHeader, () => DrawMaterials(configuration)),
            (Languages.AlliedSocietiesTab_CurrenciesDropdownHeader, () => DrawCurrencies(configuration)));
    }

    private static void DrawMaterials(Configuration configuration)
    {
        var hideObtainedMaterials = configuration.HideObtainedMaterials;
        if (ImGui.Checkbox(Languages.ObtainTab_ShowBeastTribeCraftingMaterialsMessages,
                ref hideObtainedMaterials))
        {
            configuration.HideObtainedMaterials = hideObtainedMaterials;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowBeastTribeCraftingMaterialsMessagesHelpMarker);
    }

    private static void DrawCurrencies(Configuration configuration)
    {
        var hideObtainedTribalCurrency = configuration.HideObtainedTribalCurrency;
        if (ImGui.Checkbox(Languages.ObtainTab_ShowBeastTribeCurrenciesMessages, ref hideObtainedTribalCurrency))
        {
            configuration.HideObtainedTribalCurrency = hideObtainedTribalCurrency;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowBeastTribeCurrenciesMessagesHelpMarker);

        if (TidyChatPlugin.TribalCurrencies.Count == 0)
        {
            ImGui.TextDisabled(Languages.AlliedSocietiesTab_CurrencyDataUnavailable);
        }
        else
        {
            SettingsTabLayout.DrawNestedOptions(!hideObtainedTribalCurrency, () =>
            {
                foreach (var currency in TidyChatPlugin.TribalCurrencies)
                {
                    configuration.HideTribalCurrencyById.TryGetValue(currency.RowId, out var hide);
                    if (ImGui.Checkbox($"Hide {currency.Name}", ref hide))
                    {
                        configuration.HideTribalCurrencyById[currency.RowId] = hide;
                        configuration.OnSettingChanged();
                    }
                }
            });
        }
    }
}
