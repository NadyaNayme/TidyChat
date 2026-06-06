using Dalamud.Interface.Components;
using System.Collections.Generic;
namespace TidyChat.Settings;

internal static class UiHelp
{
    private static readonly HashSet<string> ProgressSystemFilterHelpMarkers = new(StringComparer.Ordinal)
    {
        nameof(Languages.ProgressTab_ShowQuestProgressMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowLearnedAbilityMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowOtherPlayerLevelUpMessagesHelpMarker)
    };

    private static readonly HashSet<string> ProgressObtainedHideFilterHelpMarkers = new(StringComparer.Ordinal)
    {
        nameof(Languages.ProgressTab_ShowBonusAwardForDutyRouletteMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowAdventurerInNeedAwardMessagesHelpMarker)
    };

    public static string WithSystemFilterNote(string help) =>
        AppendNote(help, Languages.Shared_RequiresSystemFilteringNote);

    public static string WithObtainedFilterNote(string help) =>
        AppendNote(help, Languages.Shared_RequiresObtainedFilteringNote);

    public static string WithObtainedHideFilterNote(string help) =>
        AppendNote(help, Languages.Shared_RequiresObtainedHideFilteringNote);

    public static string WithLootFilterNote(string help) =>
        AppendNote(help, Languages.Shared_RequiresLootFilteringNote);

    public static string WithSystemHideFilterNote(string help) =>
        AppendNote(help, Languages.Shared_RequiresSystemHideFilteringNote);

    public static string WithGatheringHideFilterNote(string help) =>
        AppendNote(help, Languages.Shared_RequiresGatheringHideFilteringNote);

    public static bool ShouldAppendObtainedFilterNote(string helpPropertyName) =>
        ShouldAppendObtainedChannelNote(helpPropertyName) &&
        !ShouldAppendObtainedHideFilterNote(helpPropertyName);

    public static bool ShouldAppendObtainedHideFilterNote(string helpPropertyName) =>
        (ShouldAppendObtainedChannelNote(helpPropertyName) &&
         helpPropertyName is not nameof(Languages.CurrenciesTab_ShowGeneralItemObtainsHelpMarker) and
             not nameof(Languages.CurrenciesTab_ShowObtainedQuestItemsHelpMarker)) ||
        ProgressObtainedHideFilterHelpMarkers.Contains(helpPropertyName);

    private static bool ShouldAppendObtainedChannelNote(string helpPropertyName) =>
        (helpPropertyName.StartsWith("CurrenciesTab_", StringComparison.Ordinal) ||
         helpPropertyName.StartsWith("AlliedSocietiesTab_", StringComparison.Ordinal) ||
         helpPropertyName.StartsWith("GoldSaucerTab_", StringComparison.Ordinal) ||
         helpPropertyName is nameof(Languages.PartyTab_ShowAnotherPlayerObtainsItemMessagesHelpMarker) ||
         helpPropertyName is nameof(Languages.SystemTab_ShowCrackedClustersMessagesHelpMarker) ||
         helpPropertyName is nameof(Languages.GatheringTab_ShowElementalShardsCrystalsClustersMessagesHelpMarker)) &&
        !IsLootRollHelpMarker(helpPropertyName) &&
        !helpPropertyName.Contains("SwingMinigames", StringComparison.Ordinal) &&
        !helpPropertyName.Contains("TripleTriad", StringComparison.Ordinal);

    public static bool ShouldAppendSystemFilterNote(string helpPropertyName) =>
        helpPropertyName switch
        {
            nameof(Languages.SystemTab_ServerAnnouncementsHelpMarker) => false,
            nameof(Languages.SystemTab_ShowEverythingElseHelpMarker) => false,
            _ when helpPropertyName.StartsWith("GoldSaucerTab_", StringComparison.Ordinal) &&
                   (helpPropertyName.Contains("SwingMinigames", StringComparison.Ordinal) ||
                    helpPropertyName.Contains("TripleTriad", StringComparison.Ordinal)) => true,
            _ when helpPropertyName.StartsWith("FreeCompanyTab_ShowAirship", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("FreeCompanyTab_ShowSubmarine", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("FreeCompanyTab_ShowSubaquatic", StringComparison.Ordinal) => true,
            _ when helpPropertyName is nameof(Languages.SystemTab_ShowFateLevelSyncMessagesHelpMarker) or
                   nameof(Languages.SystemTab_ShowOrchestrionPlayingHelpMarker) => false,
            _ when helpPropertyName.StartsWith("SystemTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("PartyTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("DutyTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("DeepDungeonsTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("EconomyTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("GatheringTab_ShowCosmic", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("GatheringTab_ShowStellar", StringComparison.Ordinal) => true,
            _ => ProgressSystemFilterHelpMarkers.Contains(helpPropertyName)
        };

    public static bool ShouldAppendLootFilterNote(string helpPropertyName) =>
        IsLootRollHelpMarker(helpPropertyName);

    public static bool ShouldAppendSystemHideFilterNote(string helpPropertyName) =>
        helpPropertyName is nameof(Languages.CurrenciesTab_HideInventoryItemAddedMessagesHelpMarker);

    public static bool ShouldAppendGatheringHideFilterNote(string helpPropertyName) =>
        helpPropertyName.StartsWith("GatheringTab_HideGathering", StringComparison.Ordinal) &&
        helpPropertyName.EndsWith("LocationMessages", StringComparison.Ordinal);

    public static void SystemFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithSystemFilterNote(help));

    public static void ObtainedFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithObtainedFilterNote(help));

    public static void ObtainedHideFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithObtainedHideFilterNote(help));

    public static void LootFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithLootFilterNote(help));

    public static void CraftingFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(AppendNote(help, Languages.Shared_RequiresCraftingFilteringNote));

    public static void GatheringFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(AppendNote(help, Languages.Shared_RequiresGatheringFilteringNote));

    public static void GatheringHideFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithGatheringHideFilterNote(help));

    public static void SystemHideFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithSystemHideFilterNote(help));

    public static void StandaloneHideFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(help);

    private static bool IsLootRollHelpMarker(string helpPropertyName) =>
        helpPropertyName is nameof(Languages.PartyTab_CastYourLotHelpMarker) or
            nameof(Languages.PartyTab_ShowYouRolledMessagesHelpMarker) or
            nameof(Languages.PartyTab_ShowAnotherPlayerCastsLotMessagesHelpMarker) or
            nameof(Languages.PartyTab_ShowAnotherPlayerRollsMessagesHelpMarker) or
            nameof(Languages.PartyTab_ShowOnlyPartyMemberRollsHelpMarker) or
            nameof(Languages.PartyTab_ShowOtherPlayersLootRollsHelpMarker);

    private static string AppendNote(string help, string note) =>
        string.IsNullOrWhiteSpace(help)
            ? note
            : help.TrimEnd().Contains(note, StringComparison.Ordinal)
                ? help
                : help.TrimEnd() + "\n\n" + note;
}
