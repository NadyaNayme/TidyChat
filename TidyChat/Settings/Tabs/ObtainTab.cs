namespace TidyChat.Settings.Tabs;

internal static class ObtainTab
{
    public static void Draw(Configuration configuration)
    {
        ImGui.TextWrapped(Languages.ObtainTab_FilteringNote);
        ImGui.Spacing();

        if (ImGui.CollapsingHeader(Languages.ObtainTab_LootingAndRollingDropdownHeader))
        {
            var showCastLot = configuration.ShowCastLot;
            if (ImGui.Checkbox(Languages.ObtainTab_CastYourLotMessages, ref showCastLot))
            {
                configuration.ShowCastLot = showCastLot;
                configuration.OnSettingChanged();
            }

            UiHelp.LootFilterMarker(Languages.ObtainTab_CastYourLotHelpMarker);

            var showLootRoll = configuration.ShowLootRoll;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowYouRolledMessages, ref showLootRoll))
            {
                configuration.ShowLootRoll = showLootRoll;
                configuration.OnSettingChanged();
            }

            UiHelp.LootFilterMarker(Languages.ObtainTab_ShowYouRolledMessagesHelpMarker);

            var showOthersCastLot = configuration.ShowOthersCastLot;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerCastsLotMessages, ref showOthersCastLot))
            {
                configuration.ShowOthersCastLot = showOthersCastLot;
                configuration.OnSettingChanged();
            }

            UiHelp.LootFilterMarker(Languages.ObtainTab_ShowAnotherPlayerCastsLotMessagesHelpMarker);

            var showOthersLootRoll = configuration.ShowOthersLootRoll;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerRollsMessages, ref showOthersLootRoll))
            {
                configuration.ShowOthersLootRoll = showOthersLootRoll;
                configuration.OnSettingChanged();
            }

            UiHelp.LootFilterMarker(Languages.ObtainTab_ShowAnotherPlayerRollsMessagesHelpMarker);

            SettingsTabLayout.DrawNestedOptions(configuration.ShowOthersLootRoll, () =>
            {
                var showOnlyPartyMemberRolls = configuration.ShowOnlyPartyMemberRolls;
                if (ImGui.Checkbox(Languages.ObtainTab_ShowOnlyPartyMemberRolls, ref showOnlyPartyMemberRolls))
                {
                    configuration.ShowOnlyPartyMemberRolls = showOnlyPartyMemberRolls;
                    configuration.OnSettingChanged();
                }

                UiHelp.LootFilterMarker(Languages.ObtainTab_ShowOnlyPartyMemberRollsHelpMarker);
            });

            SettingsTabLayout.DrawIndependentOptions(() =>
            {
                var hideOthersObtain = configuration.HideOthersObtain;
                if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerObtainsItemMessages, ref hideOthersObtain))
                {
                    configuration.HideOthersObtain = hideOthersObtain;
                    configuration.OnSettingChanged();
                }

                UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowAnotherPlayerObtainsItemMessagesHelpMarker);
            });
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_CommonCurrenciesDropdownHeader))
        {
            var showObtainedItems = configuration.ShowObtainedItems;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowGeneralItemObtains, ref showObtainedItems))
            {
                configuration.ShowObtainedItems = showObtainedItems;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowGeneralItemObtainsHelpMarker);

            var hideInventoryItemAdded = configuration.HideInventoryItemAdded;
            if (ImGui.Checkbox(Languages.ObtainTab_HideInventoryItemAddedMessages, ref hideInventoryItemAdded))
            {
                configuration.HideInventoryItemAdded = hideInventoryItemAdded;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_HideInventoryItemAddedMessagesHelpMarker);

            var showObtainedQuestItems = configuration.ShowObtainedQuestItems;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowObtainedQuestItems, ref showObtainedQuestItems))
            {
                configuration.ShowObtainedQuestItems = showObtainedQuestItems;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowObtainedQuestItemsHelpMarker);

            var hideObtainedgil = configuration.HideObtainedGil;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowGil, ref hideObtainedgil))
            {
                configuration.HideObtainedGil = hideObtainedgil;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowGilHelpMarker);

            var hideObtainedSeals = configuration.HideObtainedSeals;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowGrandCompanySealsMessages, ref hideObtainedSeals))
            {
                configuration.HideObtainedSeals = hideObtainedSeals;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowGrandCompanySealsMessagesHelpMarker);

            var hideObtainedVenture = configuration.HideObtainedVenture;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowVentureMessages, ref hideObtainedVenture))
            {
                configuration.HideObtainedVenture = hideObtainedVenture;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowVentureMessagesHelpMarker);

            var hideObtainedMGP = configuration.HideObtainedMGP;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowMGPMessages, ref hideObtainedMGP))
            {
                configuration.HideObtainedMGP = hideObtainedMGP;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowMGPMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_BattleCurrenciesDropdownHeader))
        {
            if (TidyChatPlugin.Tomestones.Count == 0)
            {
                ImGui.TextDisabled("Tomestone data unavailable");
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
            if (ImGui.Checkbox(Languages.ObtainTab_ShowWolfMarksMessages, ref hideObtainedWolfMarks))
            {
                configuration.HideObtainedWolfMarks = hideObtainedWolfMarks;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowWolfMarksMessagesHelpMarker);

            var hideObtainedAlliedSeals = configuration.HideObtainedAlliedSeals;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAlliedSealsMessages, ref hideObtainedAlliedSeals))
            {
                configuration.HideObtainedAlliedSeals = hideObtainedAlliedSeals;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowAlliedSealsMessagesHelpMarker);

            var hideObtainedCenturioSeals = configuration.HideObtainedCenturioSeals;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowCenturioSealsMessages, ref hideObtainedCenturioSeals))
            {
                configuration.HideObtainedCenturioSeals = hideObtainedCenturioSeals;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowCenturioSealsMessagesHelpMarker);

            var hideObtainedNuts = configuration.HideObtainedNuts;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowSacksOfNutsMessages, ref hideObtainedNuts))
            {
                configuration.HideObtainedNuts = hideObtainedNuts;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowSacksOfNutsMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_BeastTribeQuestsDropdownHeader))
        {
            var hideObtainedMaterials = configuration.HideObtainedMaterials;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowBeastTribeCraftingMaterialsMessages,
                    ref hideObtainedMaterials))
            {
                configuration.HideObtainedMaterials = hideObtainedMaterials;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowBeastTribeCraftingMaterialsMessagesHelpMarker);

            var hideObtainedTribalCurrency = configuration.HideObtainedTribalCurrency;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowBeastTribeCurrenciesMessages, ref hideObtainedTribalCurrency))
            {
                configuration.HideObtainedTribalCurrency = hideObtainedTribalCurrency;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowBeastTribeCurrenciesMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_OtherObtainMessagesDropdownHeader))
        {
            var hideObtainedClusters = configuration.HideObtainedClusters;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowCrackedClustersMessages, ref hideObtainedClusters))
            {
                configuration.HideObtainedClusters = hideObtainedClusters;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowCrackedClustersMessagesHelpMarker);

            var hideObtainedShards = configuration.HideObtainedShards;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowElementalShardsCrystalsClustersMessages,
                    ref hideObtainedShards))
            {
                configuration.HideObtainedShards = hideObtainedShards;
                configuration.OnSettingChanged();
            }

            UiHelp.ObtainedFilterMarker(Languages.ObtainTab_ShowElementalShardsCrystalsClustersMessagesHelpMarker);
        }
    }
}
