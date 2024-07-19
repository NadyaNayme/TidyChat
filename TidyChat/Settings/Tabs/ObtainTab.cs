using Dalamud.Interface.Components;
using ImGuiNET;
using TidyChat.Resources.Languages;

namespace TidyChat.Settings.Tabs;

internal static class ObtainTab
{
    public static void Draw(Configuration configuration)
    {
        if (ImGui.CollapsingHeader(Languages.ObtainTab_LootingAndRollingDropdownHeader))
        {
            var showCastLot = configuration.ShowCastLot;
            if (ImGui.Checkbox(Languages.ObtainTab_CastYourLotMessages, ref showCastLot))
            {
                configuration.ShowCastLot = showCastLot;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_CastYourLotHelpMarker);

            var showLootRoll = configuration.ShowLootRoll;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowYouRolledMessages, ref showLootRoll))
            {
                configuration.ShowLootRoll = showLootRoll;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowYouRolledMessagesHelpMarker);

            var showOthersCastLot = configuration.ShowOthersCastLot;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerCastsLotMessages, ref showOthersCastLot))
            {
                configuration.ShowOthersCastLot = showOthersCastLot;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowAnotherPlayerCastsLotMessagesHelpMarker);

            var showOthersLootRoll = configuration.ShowOthersLootRoll;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerRollsMessages, ref showOthersLootRoll))
            {
                configuration.ShowOthersLootRoll = showOthersLootRoll;
                configuration.Save();
            }

            var showOthersObtain = configuration.ShowOthersObtain;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerObtainsItemMessages, ref showOthersObtain))
            {
                configuration.ShowOthersObtain = showOthersObtain;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowAnotherPlayerObtainsItemMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_CommonCurrenciesDropdownHeader))
        {
            var showObtainedgil = configuration.ShowObtainedGil;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowGil, ref showObtainedgil))
            {
                configuration.ShowObtainedGil = showObtainedgil;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowGilHelpMarker);

            var showObtainedSeals = configuration.ShowObtainedSeals;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowGrandCompanySealsMessages, ref showObtainedSeals))
            {
                configuration.ShowObtainedSeals = showObtainedSeals;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowGrandCompanySealsMessagesHelpMarker);

            var showObtainedVenture = configuration.ShowObtainedVenture;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowVentureMessages, ref showObtainedVenture))
            {
                configuration.ShowObtainedVenture = showObtainedVenture;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowVentureMessagesHelpMarker);

            var showObtainedMGP = configuration.ShowObtainedMGP;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowMGPMessages, ref showObtainedMGP))
            {
                configuration.ShowObtainedMGP = showObtainedMGP;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowMGPMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_BattleCurrenciesDropdownHeader))
        {
            var showObtainedPoeticsTomestones = configuration.ShowObtainedPoeticsTomestones;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowPoeticsMessages, ref showObtainedPoeticsTomestones))
            {
                configuration.ShowObtainedPoeticsTomestones = showObtainedPoeticsTomestones;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowPoeticsMessagesHelpMarker);

            var showObtainedAphorismTomestones = configuration.ShowObtainedAphorismTomestones;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAphorismMessages, ref showObtainedAphorismTomestones))
            {
                configuration.ShowObtainedAphorismTomestones = showObtainedAphorismTomestones;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowAphorismMessagesHelpMarker);

            var showObtainedAstronomyTomestones = configuration.ShowObtainedAstronomyTomestones;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAstronomyMessages, ref showObtainedAstronomyTomestones))
            {
                configuration.ShowObtainedAstronomyTomestones = showObtainedAstronomyTomestones;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowAstronomyMessagesHelpMarker);

            var showObtainedWolfMarks = configuration.ShowObtainedWolfMarks;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowWolfMarksMessages, ref showObtainedWolfMarks))
            {
                configuration.ShowObtainedWolfMarks = showObtainedWolfMarks;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowWolfMarksMessagesHelpMarker);

            var showObtainedAlliedSeals = configuration.ShowObtainedAlliedSeals;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAlliedSealsMessages, ref showObtainedAlliedSeals))
            {
                configuration.ShowObtainedAlliedSeals = showObtainedAlliedSeals;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowAlliedSealsMessagesHelpMarker);

            var showObtainedCenturioSeals = configuration.ShowObtainedCenturioSeals;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowCenturioSealsMessages, ref showObtainedCenturioSeals))
            {
                configuration.ShowObtainedCenturioSeals = showObtainedCenturioSeals;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowCenturioSealsMessagesHelpMarker);

            var showObtainedNuts = configuration.ShowObtainedNuts;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowSacksOfNutsMessages, ref showObtainedNuts))
            {
                configuration.ShowObtainedNuts = showObtainedNuts;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowSacksOfNutsMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_BeastTribeQuestsDropdownHeader))
        {
            var showObtainedMaterials = configuration.ShowObtainedMaterials;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowBeastTribeCraftingMaterialsMessages,
                    ref showObtainedMaterials))
            {
                configuration.ShowObtainedMaterials = showObtainedMaterials;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowBeastTribeCraftingMaterialsMessagesHelpMarker);

            var showObtainedTribalCurrency = configuration.ShowObtainedTribalCurrency;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowBeastTribeCurrenciesMessages, ref showObtainedTribalCurrency))
            {
                configuration.ShowObtainedTribalCurrency = showObtainedTribalCurrency;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowBeastTribeCurrenciesMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_OtherObtainMessagesDropdownHeader))
        {
            var showObtainedClusters = configuration.ShowObtainedClusters;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowCrackedClustersMessages, ref showObtainedClusters))
            {
                configuration.ShowObtainedClusters = showObtainedClusters;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowCrackedClustersMessagesHelpMarker);

            var showObtainedShards = configuration.ShowObtainedShards;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowElementalShardsCrystalsClustersMessages,
                    ref showObtainedShards))
            {
                configuration.ShowObtainedShards = showObtainedShards;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowElementalShardsCrystalsClustersMessagesHelpMarker);
        }

        ImGui.EndTabItem();
    }
}