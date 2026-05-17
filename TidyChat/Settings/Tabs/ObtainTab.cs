using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;
namespace TidyChat.Settings.Tabs;

internal static class ObtainTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.ObtainTab_LootingAndRollingDropdownHeader))
        {
            bool showCastLot = configuration.ShowCastLot;
            if (ImGui.Checkbox(Languages.ObtainTab_CastYourLotMessages, ref showCastLot))
            {
                configuration.ShowCastLot = showCastLot;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_CastYourLotHelpMarker);

            bool showLootRoll = configuration.ShowLootRoll;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowYouRolledMessages, ref showLootRoll))
            {
                configuration.ShowLootRoll = showLootRoll;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowYouRolledMessagesHelpMarker);

            bool showOthersCastLot = configuration.ShowOthersCastLot;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerCastsLotMessages, ref showOthersCastLot))
            {
                configuration.ShowOthersCastLot = showOthersCastLot;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowAnotherPlayerCastsLotMessagesHelpMarker);

            bool showOthersLootRoll = configuration.ShowOthersLootRoll;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerRollsMessages, ref showOthersLootRoll))
            {
                configuration.ShowOthersLootRoll = showOthersLootRoll;
                configuration.Save();
            }

            if (configuration.ShowOthersLootRoll)
            {
                ImGui.Indent();
                bool showOnlyPartyMemberRolls = configuration.ShowOnlyPartyMemberRolls;
                if (ImGui.Checkbox(Languages.ObtainTab_ShowOnlyPartyMemberRolls, ref showOnlyPartyMemberRolls))
                {
                    configuration.ShowOnlyPartyMemberRolls = showOnlyPartyMemberRolls;
                    configuration.Save();
                }

                ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowOnlyPartyMemberRollsHelpMarker);
                ImGui.Unindent();
            }

            bool hideOthersObtain = configuration.HideOthersObtain;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerObtainsItemMessages, ref hideOthersObtain))
            {
                configuration.HideOthersObtain = hideOthersObtain;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowAnotherPlayerObtainsItemMessagesHelpMarker);

            bool hideOthersObtainFromLoot = configuration.HideOthersObtainFromLoot;
            if (ImGui.Checkbox(Languages.ObtainTab_HideOthersObtainFromLoot, ref hideOthersObtainFromLoot))
            {
                configuration.HideOthersObtainFromLoot = hideOthersObtainFromLoot;
                configuration.Save();
            }
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_CommonCurrenciesDropdownHeader))
        {
            bool hideObtainedgil = configuration.HideObtainedGil;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowGil, ref hideObtainedgil))
            {
                configuration.HideObtainedGil = hideObtainedgil;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowGilHelpMarker);

            bool hideObtainedSeals = configuration.HideObtainedSeals;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowGrandCompanySealsMessages, ref hideObtainedSeals))
            {
                configuration.HideObtainedSeals = hideObtainedSeals;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowGrandCompanySealsMessagesHelpMarker);

            bool hideObtainedVenture = configuration.HideObtainedVenture;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowVentureMessages, ref hideObtainedVenture))
            {
                configuration.HideObtainedVenture = hideObtainedVenture;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowVentureMessagesHelpMarker);

            bool hideObtainedMGP = configuration.HideObtainedMGP;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowMGPMessages, ref hideObtainedMGP))
            {
                configuration.HideObtainedMGP = hideObtainedMGP;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowMGPMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_BattleCurrenciesDropdownHeader))
        {
            if (TidyChatPlugin.Tomestones.Count == 0)
            {
                ImGui.TextDisabled("Tomestone data unavailable");
            }
            else
            {
                foreach(TomestoneInfo tomestone in TidyChatPlugin.Tomestones)
                {
                    configuration.HideTomestoneById.TryGetValue(tomestone.RowId, out bool hide);
                    if (ImGui.Checkbox($"Hide {tomestone.Name}", ref hide))
                    {
                        configuration.HideTomestoneById[tomestone.RowId] = hide;
                        configuration.Save();
                    }
                }
            }

            bool hideObtainedWolfMarks = configuration.HideObtainedWolfMarks;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowWolfMarksMessages, ref hideObtainedWolfMarks))
            {
                configuration.HideObtainedWolfMarks = hideObtainedWolfMarks;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowWolfMarksMessagesHelpMarker);

            bool hideObtainedAlliedSeals = configuration.HideObtainedAlliedSeals;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAlliedSealsMessages, ref hideObtainedAlliedSeals))
            {
                configuration.HideObtainedAlliedSeals = hideObtainedAlliedSeals;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowAlliedSealsMessagesHelpMarker);

            bool hideObtainedCenturioSeals = configuration.HideObtainedCenturioSeals;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowCenturioSealsMessages, ref hideObtainedCenturioSeals))
            {
                configuration.HideObtainedCenturioSeals = hideObtainedCenturioSeals;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowCenturioSealsMessagesHelpMarker);

            bool hideObtainedNuts = configuration.HideObtainedNuts;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowSacksOfNutsMessages, ref hideObtainedNuts))
            {
                configuration.HideObtainedNuts = hideObtainedNuts;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowSacksOfNutsMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_BeastTribeQuestsDropdownHeader))
        {
            bool hideObtainedMaterials = configuration.HideObtainedMaterials;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowBeastTribeCraftingMaterialsMessages,
                    ref hideObtainedMaterials))
            {
                configuration.HideObtainedMaterials = hideObtainedMaterials;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowBeastTribeCraftingMaterialsMessagesHelpMarker);

            bool hideObtainedTribalCurrency = configuration.HideObtainedTribalCurrency;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowBeastTribeCurrenciesMessages, ref hideObtainedTribalCurrency))
            {
                configuration.HideObtainedTribalCurrency = hideObtainedTribalCurrency;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowBeastTribeCurrenciesMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_OtherObtainMessagesDropdownHeader))
        {
            bool hideObtainedClusters = configuration.HideObtainedClusters;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowCrackedClustersMessages, ref hideObtainedClusters))
            {
                configuration.HideObtainedClusters = hideObtainedClusters;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowCrackedClustersMessagesHelpMarker);

            bool hideObtainedShards = configuration.HideObtainedShards;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowElementalShardsCrystalsClustersMessages,
                    ref hideObtainedShards))
            {
                configuration.HideObtainedShards = hideObtainedShards;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowElementalShardsCrystalsClustersMessagesHelpMarker);

            bool hideObtainedShardsFromLoot = configuration.HideObtainedShardsFromLoot;
            if (ImGui.Checkbox(Languages.ObtainTab_HideObtainedShardsFromLoot, ref hideObtainedShardsFromLoot))
            {
                configuration.HideObtainedShardsFromLoot = hideObtainedShardsFromLoot;
                configuration.Save();
            }
        }

        ImGui.EndTabItem();
    }
}
