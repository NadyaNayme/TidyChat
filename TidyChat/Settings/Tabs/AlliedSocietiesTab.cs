namespace TidyChat.Settings.Tabs;

internal static class AlliedSocietiesTab
{
    public static void Draw(Configuration configuration)
    {
        SettingsTabLayout.DrawTabNote(Languages.AlliedSocietiesTab_FilteringNote);

        if (!configuration.FilterObtainedSpam)
        {
            SettingsTabLayout.DrawMasterChannelDisabledWarning(string.Format(
                CultureInfo.CurrentCulture,
                Languages.Shared_FilterObtainedDisabledWarning,
                Languages.GeneralTab_FilterObtainedSpam,
                Languages.ConfigWindow_GeneralTabHeader));
        }

        var hideObtainedMaterials = configuration.HideObtainedMaterials;
        if (ImGui.Checkbox(Languages.AlliedSocietiesTab_HideBeastTribeCraftingMaterialsMessages,
                ref hideObtainedMaterials))
        {
            configuration.HideObtainedMaterials = hideObtainedMaterials;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedHideFilterMarker(Languages.AlliedSocietiesTab_HideBeastTribeCraftingMaterialsMessagesHelpMarker);

        var hideObtainedTribalCurrency = configuration.HideObtainedTribalCurrency;
        if (ImGui.Checkbox(Languages.AlliedSocietiesTab_HideBeastTribeCurrenciesMessages, ref hideObtainedTribalCurrency))
        {
            configuration.HideObtainedTribalCurrency = hideObtainedTribalCurrency;
            configuration.OnSettingChanged();
        }

        UiHelp.ObtainedHideFilterMarker(Languages.AlliedSocietiesTab_HideBeastTribeCurrenciesMessagesHelpMarker);

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

                    UiHelp.ObtainedHideFilterMarker(Languages.AlliedSocietiesTab_HideTribalCurrencyByIdHelpMarker);
                }
            });
        }
    }
}
