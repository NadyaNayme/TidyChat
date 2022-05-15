using Dalamud.Interface.Components;
using ImGuiNET;

namespace TidyChat.Settings.Tabs
{
    internal static class ObtainTab
    {
        public static void Draw(Configuration configuration)
        {

            if (ImGui.CollapsingHeader(localization.ObtainTab_LootingAndRollingDropdownHeader))
            {
                var showCastLot = configuration.ShowCastLot;
                if (ImGui.Checkbox(localization.ObtainTab_CastYourLotMessages, ref showCastLot))
                {
                    configuration.ShowCastLot = showCastLot;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_CastYourLotHelpMarker);

                var showLootRoll = configuration.ShowLootRoll;
                if (ImGui.Checkbox(localization.ObtainTab_ShowYouRolledMessages, ref showLootRoll))
                {
                    configuration.ShowLootRoll = showLootRoll;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowYouRolledMessagesHelpMarker);

                var showOthersCastLot = configuration.ShowOthersCastLot;
                if (ImGui.Checkbox(localization.ObtainTab_ShowAnotherPlayerCastsLotMessages, ref showOthersCastLot))
                {
                    configuration.ShowOthersCastLot = showOthersCastLot;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowAnotherPlayerCastsLotMessagesHelpMarker);

                var showOthersLootRoll = configuration.ShowOthersLootRoll;
                if (ImGui.Checkbox(localization.ObtainTab_ShowAnotherPlayerRollsMessages, ref showOthersLootRoll))
                {
                    configuration.ShowOthersLootRoll = showOthersLootRoll;
                    configuration.Save();
                }

                var showOthersObtain = configuration.ShowOthersObtain;
                if (ImGui.Checkbox(localization.ObtainTab_ShowAnotherPlayerObtainsItemMessages, ref showOthersObtain))
                {
                    configuration.ShowOthersObtain = showOthersObtain;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowAnotherPlayerObtainsItemMessagesHelpMarker);

            }

            if (ImGui.CollapsingHeader(localization.ObtainTab_CommonCurrenciesDropdownHeader))
            {
                var showObtainedgil = configuration.ShowObtainedGil;
                if (ImGui.Checkbox(localization.ObtainTab_ShowGil, ref showObtainedgil))
                {
                    configuration.ShowObtainedGil = showObtainedgil;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowGilHelpMarker);

                var showObtainedSeals = configuration.ShowObtainedSeals;
                if (ImGui.Checkbox(localization.ObtainTab_ShowGrandCompanySealsMessages, ref showObtainedSeals))
                {
                    configuration.ShowObtainedSeals = showObtainedSeals;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowGrandCompanySealsMessagesHelpMarker);

                var showObtainedVenture = configuration.ShowObtainedVenture;
                if (ImGui.Checkbox(localization.ObtainTab_ShowVentureMessages, ref showObtainedVenture))
                {
                    configuration.ShowObtainedVenture = showObtainedVenture;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowVentureMessagesHelpMarker);

                var showObtainedMGP = configuration.ShowObtainedMGP;
                if (ImGui.Checkbox(localization.ObtainTab_ShowMGPMessages, ref showObtainedMGP))
                {
                    configuration.ShowObtainedMGP = showObtainedMGP;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowMGPMessagesHelpMarker);
            }

            if (ImGui.CollapsingHeader(localization.ObtainTab_BattleCurrenciesDropdownHeader))
            {

                var showObtainedPoeticsTomestones = configuration.ShowObtainedPoeticsTomestones;
                if (ImGui.Checkbox(localization.ObtainTab_ShowPoeticsMessages, ref showObtainedPoeticsTomestones))
                {
                    configuration.ShowObtainedPoeticsTomestones = showObtainedPoeticsTomestones;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowPoeticsMessagesHelpMarker);

                var showObtainedAphorismTomestones = configuration.ShowObtainedAphorismTomestones;
                if (ImGui.Checkbox(localization.ObtainTab_ShowAphorismMessages, ref showObtainedAphorismTomestones))
                {
                    configuration.ShowObtainedAphorismTomestones = showObtainedAphorismTomestones;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowAphorismMessagesHelpMarker);

                var showObtainedAstronomyTomestones = configuration.ShowObtainedAstronomyTomestones;
                if (ImGui.Checkbox(localization.ObtainTab_ShowAstronomyMessages, ref showObtainedAstronomyTomestones))
                {
                    configuration.ShowObtainedAstronomyTomestones = showObtainedAstronomyTomestones;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowAstronomyMessagesHelpMarker);

                var showObtainedWolfMarks = configuration.ShowObtainedWolfMarks;
                if (ImGui.Checkbox(localization.ObtainTab_ShowWolfMarksMessages, ref showObtainedWolfMarks))
                {
                    configuration.ShowObtainedWolfMarks = showObtainedWolfMarks;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowWolfMarksMessagesHelpMarker);

                var showObtainedAlliedSeals = configuration.ShowObtainedAlliedSeals;
                if (ImGui.Checkbox(localization.ObtainTab_ShowAlliedSealsMessages, ref showObtainedAlliedSeals))
                {
                    configuration.ShowObtainedAlliedSeals = showObtainedAlliedSeals;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowAlliedSealsMessagesHelpMarker);

                var showObtainedCenturioSeals = configuration.ShowObtainedCenturioSeals;
                if (ImGui.Checkbox(localization.ObtainTab_ShowCenturioSealsMessages, ref showObtainedCenturioSeals))
                {
                    configuration.ShowObtainedCenturioSeals = showObtainedCenturioSeals;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowCenturioSealsMessagesHelpMarker);

                var showObtainedNuts = configuration.ShowObtainedNuts;
                if (ImGui.Checkbox(localization.ObtainTab_ShowSacksOfNutsMessages, ref showObtainedNuts))
                {
                    configuration.ShowObtainedNuts = showObtainedNuts;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowSacksOfNutsMessagesHelpMarker);
            }

            if (ImGui.CollapsingHeader(localization.ObtainTab_BeastTribeQuestsDropdownHeader))
            {
                var showObtainedMaterials = configuration.ShowObtainedMaterials;
                if (ImGui.Checkbox(localization.ObtainTab_ShowBeastTribeCraftingMaterialsMessages, ref showObtainedMaterials))
                {
                    configuration.ShowObtainedMaterials = showObtainedMaterials;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowBeastTribeCraftingMaterialsMessagesHelpMarker);

                var showObtainedTribalCurrency = configuration.ShowObtainedTribalCurrency;
                if (ImGui.Checkbox(localization.ObtainTab_ShowBeastTribeCurrenciesMessages, ref showObtainedTribalCurrency))
                {
                    configuration.ShowObtainedTribalCurrency = showObtainedTribalCurrency;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowBeastTribeCurrenciesMessagesHelpMarker);
            }

            if (ImGui.CollapsingHeader(localization.ObtainTab_OtherObtainMessagesDropdownHeader))
            {
                var showObtainedClusters = configuration.ShowObtainedClusters;
                if (ImGui.Checkbox(localization.ObtainTab_ShowCrackedClustersMessages, ref showObtainedClusters))
                {
                    configuration.ShowObtainedClusters = showObtainedClusters;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowCrackedClustersMessagesHelpMarker);

                var showObtainedShards = configuration.ShowObtainedShards;
                if (ImGui.Checkbox(localization.ObtainTab_ShowElementalShardsCrystalsClustersMessages, ref showObtainedShards))
                {
                    configuration.ShowObtainedShards = showObtainedShards;
                    configuration.Save();
                }
                ImGuiComponents.HelpMarker(localization.ObtainTab_ShowElementalShardsCrystalsClustersMessagesHelpMarker);
            }

            ImGui.EndTabItem();
        }
    }
}
