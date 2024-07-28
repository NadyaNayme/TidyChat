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

            var hideOthersObtain = configuration.HideOthersObtain;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAnotherPlayerObtainsItemMessages, ref hideOthersObtain))
            {
                configuration.HideOthersObtain = hideOthersObtain;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowAnotherPlayerObtainsItemMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_CommonCurrenciesDropdownHeader))
        {
            var hideObtainedgil = configuration.HideObtainedGil;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowGil, ref hideObtainedgil))
            {
                configuration.HideObtainedGil = hideObtainedgil;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowGilHelpMarker);

            var hideObtainedSeals = configuration.HideObtainedSeals;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowGrandCompanySealsMessages, ref hideObtainedSeals))
            {
                configuration.HideObtainedSeals = hideObtainedSeals;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowGrandCompanySealsMessagesHelpMarker);

            var hideObtainedVenture = configuration.HideObtainedVenture;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowVentureMessages, ref hideObtainedVenture))
            {
                configuration.HideObtainedVenture = hideObtainedVenture;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowVentureMessagesHelpMarker);

            var hideObtainedMGP = configuration.HideObtainedMGP;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowMGPMessages, ref hideObtainedMGP))
            {
                configuration.HideObtainedMGP = hideObtainedMGP;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowMGPMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_BattleCurrenciesDropdownHeader))
        {
            var hideObtainedPoeticsTomestones = configuration.HideObtainedPoeticsTomestones;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowPoeticsMessages, ref hideObtainedPoeticsTomestones))
            {
                configuration.HideObtainedPoeticsTomestones = hideObtainedPoeticsTomestones;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowPoeticsMessagesHelpMarker);

            var hideObtainedAphorismTomestones = configuration.HideObtainedAphorismTomestones;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAphorismMessages, ref hideObtainedAphorismTomestones))
            {
                configuration.HideObtainedAphorismTomestones = hideObtainedAphorismTomestones;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowAphorismMessagesHelpMarker);

            var hideObtainedAstronomyTomestones = configuration.HideObtainedAstronomyTomestones;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAstronomyMessages, ref hideObtainedAstronomyTomestones))
            {
                configuration.HideObtainedAstronomyTomestones = hideObtainedAstronomyTomestones;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowAstronomyMessagesHelpMarker);

            var hideObtainedWolfMarks = configuration.HideObtainedWolfMarks;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowWolfMarksMessages, ref hideObtainedWolfMarks))
            {
                configuration.HideObtainedWolfMarks = hideObtainedWolfMarks;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowWolfMarksMessagesHelpMarker);

            var hideObtainedAlliedSeals = configuration.HideObtainedAlliedSeals;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowAlliedSealsMessages, ref hideObtainedAlliedSeals))
            {
                configuration.HideObtainedAlliedSeals = hideObtainedAlliedSeals;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowAlliedSealsMessagesHelpMarker);

            var hideObtainedCenturioSeals = configuration.HideObtainedCenturioSeals;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowCenturioSealsMessages, ref hideObtainedCenturioSeals))
            {
                configuration.HideObtainedCenturioSeals = hideObtainedCenturioSeals;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowCenturioSealsMessagesHelpMarker);

            var hideObtainedNuts = configuration.HideObtainedNuts;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowSacksOfNutsMessages, ref hideObtainedNuts))
            {
                configuration.HideObtainedNuts = hideObtainedNuts;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowSacksOfNutsMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_BeastTribeQuestsDropdownHeader))
        {
            var hideObtainedMaterials = configuration.HideObtainedMaterials;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowBeastTribeCraftingMaterialsMessages,
                    ref hideObtainedMaterials))
            {
                configuration.HideObtainedMaterials = hideObtainedMaterials;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowBeastTribeCraftingMaterialsMessagesHelpMarker);

            var hideObtainedTribalCurrency = configuration.HideObtainedTribalCurrency;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowBeastTribeCurrenciesMessages, ref hideObtainedTribalCurrency))
            {
                configuration.HideObtainedTribalCurrency = hideObtainedTribalCurrency;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowBeastTribeCurrenciesMessagesHelpMarker);
        }

        if (ImGui.CollapsingHeader(Languages.ObtainTab_OtherObtainMessagesDropdownHeader))
        {
            var hideObtainedClusters = configuration.HideObtainedClusters;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowCrackedClustersMessages, ref hideObtainedClusters))
            {
                configuration.HideObtainedClusters = hideObtainedClusters;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowCrackedClustersMessagesHelpMarker);

            var hideObtainedShards = configuration.HideObtainedShards;
            if (ImGui.Checkbox(Languages.ObtainTab_ShowElementalShardsCrystalsClustersMessages,
                    ref hideObtainedShards))
            {
                configuration.HideObtainedShards = hideObtainedShards;
                configuration.Save();
            }

            ImGuiComponents.HelpMarker(Languages.ObtainTab_ShowElementalShardsCrystalsClustersMessagesHelpMarker);
        }

        ImGui.EndTabItem();
    }
}