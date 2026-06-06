using Dalamud.Interface.Components;

using System.Collections.Generic;

namespace TidyChat.Settings;

internal static class UiHelp
{
    private static readonly HashSet<string> ProgressSystemFilterHelpMarkers = new(StringComparer.Ordinal)
    {
        nameof(Languages.ProgressTab_ShowQuestProgressMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowOtherPlayerLevelUpMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowFirstClearAwardHelpMarker),
        nameof(Languages.ProgressTab_ShowSecondChanceAwardHelpMarker)
    };

    private static readonly HashSet<string> ProgressAndSystemFilterHelpMarkers = new(StringComparer.Ordinal)
    {
        nameof(Languages.ProgressTab_ShowLearnedAbilityMessagesHelpMarker)
    };

    private static readonly HashSet<string> ProgressFilterHelpMarkers = new(StringComparer.Ordinal)
    {
        nameof(Languages.ProgressTab_ShowExperienceGainMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowPvpExpGainMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowPvpRankMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowSeriesProgressMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowLevelUpMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowEarnedAchievementMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowOtherPlayersEarnedAchievementMessagesHelpMarker),
        nameof(Languages.DesynthesisTab_ShowDesynthesisLevelIncreasesMessagesHelpMarker)
    };

    private static readonly HashSet<string> ProgressObtainedHideFilterHelpMarkers = new(StringComparer.Ordinal)
    {
        nameof(Languages.ProgressTab_HideBonusAwardForDutyRouletteMessagesHelpMarker),
        nameof(Languages.ProgressTab_HideAdventurerInNeedAwardMessagesHelpMarker)
    };

    private static readonly HashSet<string> ObtainedAndSystemHideFilterHelpMarkers = new(StringComparer.Ordinal)
    {
        nameof(Languages.CurrenciesTab_HideGilMessagesHelpMarker),
        nameof(Languages.GoldSaucerTab_HideMGPMessagesHelpMarker)
    };

    private static readonly HashSet<string> LootAndObtainedHideFilterHelpMarkers = new(StringComparer.Ordinal)
    {
        nameof(Languages.PartyTab_HideAnotherPlayerObtainsItemMessagesHelpMarker)
    };

    private static readonly HashSet<string> ObtainedHideFilterHelpMarkers = new(StringComparer.Ordinal)
    {
        nameof(Languages.CurrenciesTab_HideTomestoneByIdHelpMarker),
        nameof(Languages.AlliedSocietiesTab_HideTribalCurrencyByIdHelpMarker)
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

    public static string WithProgressFilterNote(string help) =>
        AppendNote(help, Languages.Shared_RequiresProgressFilteringNote);

    public static string WithProgressAndSystemFilterNote(string help) =>
        AppendNote(AppendNote(help, Languages.Shared_RequiresProgressFilteringNote),
            Languages.Shared_RequiresSystemFilteringNote);

    public static string WithObtainedAndSystemHideFilterNote(string help) =>
        AppendNote(AppendNote(help, Languages.Shared_RequiresObtainedHideFilteringNote),
            Languages.Shared_RequiresSystemHideFilteringNote);

    public static string WithLootAndObtainedHideFilterNote(string help) =>
        AppendNote(AppendNote(help, Languages.Shared_RequiresObtainedHideFilteringNote),
            Languages.Shared_RequiresLootFilteringNote);

    public static bool ShouldAppendProgressAndSystemFilterNote(string helpPropertyName) =>
        ProgressAndSystemFilterHelpMarkers.Contains(helpPropertyName);

    public static bool ShouldAppendObtainedFilterNote(string helpPropertyName) =>
        ShouldAppendObtainedChannelNote(helpPropertyName) &&
        !ShouldAppendObtainedHideFilterNote(helpPropertyName) &&
        !ObtainedAndSystemHideFilterHelpMarkers.Contains(helpPropertyName);

    public static bool ShouldAppendObtainedHideFilterNote(string helpPropertyName) =>
        ObtainedHideFilterHelpMarkers.Contains(helpPropertyName) ||
        (((ShouldAppendObtainedChannelNote(helpPropertyName) &&
           helpPropertyName is not nameof(Languages.CurrenciesTab_ShowGeneralItemObtainsHelpMarker) and
               not nameof(Languages.CurrenciesTab_ShowObtainedQuestItemsHelpMarker)) ||
          ProgressObtainedHideFilterHelpMarkers.Contains(helpPropertyName)) &&
         !ObtainedAndSystemHideFilterHelpMarkers.Contains(helpPropertyName) &&
         !LootAndObtainedHideFilterHelpMarkers.Contains(helpPropertyName));

    private static bool ShouldAppendObtainedChannelNote(string helpPropertyName) =>
        (helpPropertyName.StartsWith("CurrenciesTab_", StringComparison.Ordinal) ||
         helpPropertyName.StartsWith("AlliedSocietiesTab_", StringComparison.Ordinal) ||
         helpPropertyName.StartsWith("GoldSaucerTab_", StringComparison.Ordinal) ||
         helpPropertyName is nameof(Languages.PartyTab_HideAnotherPlayerObtainsItemMessagesHelpMarker) ||
         helpPropertyName is nameof(Languages.SystemTab_HideCrackedClustersMessagesHelpMarker) ||
         helpPropertyName is nameof(Languages.GatheringTab_HideElementalShardsCrystalsClustersMessagesHelpMarker)) &&
        !IsLootRollHelpMarker(helpPropertyName) &&
        !helpPropertyName.Contains("SwingMinigames", StringComparison.Ordinal) &&
        !helpPropertyName.Contains("TripleTriad", StringComparison.Ordinal);

    public static bool ShouldAppendProgressFilterNote(string helpPropertyName) =>
        ProgressFilterHelpMarkers.Contains(helpPropertyName);

    public static bool ShouldAppendObtainedAndSystemHideFilterNote(string helpPropertyName) =>
        ObtainedAndSystemHideFilterHelpMarkers.Contains(helpPropertyName);

    public static bool ShouldAppendLootAndObtainedHideFilterNote(string helpPropertyName) =>
        LootAndObtainedHideFilterHelpMarkers.Contains(helpPropertyName);

    public static bool ShouldAppendSystemFilterNote(string helpPropertyName) =>
        helpPropertyName switch
        {
            nameof(Languages.SystemTab_ServerAnnouncementsHelpMarker) => false,
            nameof(Languages.SystemTab_ShowEverythingElseHelpMarker) => false,
            nameof(Languages.ProgressTab_ShowPvpZoneAnnouncementsHelpMarker) => true,
            _ when helpPropertyName.StartsWith("GoldSaucerTab_", StringComparison.Ordinal) &&
                   (helpPropertyName.Contains("SwingMinigames", StringComparison.Ordinal) ||
                    helpPropertyName.Contains("TripleTriad", StringComparison.Ordinal)) => true,
            _ when helpPropertyName.StartsWith("FreeCompanyTab_ShowAirship", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("FreeCompanyTab_ShowSubmarine", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("FreeCompanyTab_ShowSubaquatic", StringComparison.Ordinal) => true,
            _ when helpPropertyName is nameof(Languages.SystemTab_HideFateLevelSyncMessagesHelpMarker) or
                   nameof(Languages.SystemTab_HideOrchestrionPlayingHelpMarker) => false,
            _ when helpPropertyName.StartsWith("SystemTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("PartyTab_", StringComparison.Ordinal) =>
                helpPropertyName is not nameof(Languages.PartyTab_ShowPartyObjectiveOnJoinHelpMarker),
            _ when helpPropertyName.StartsWith("DutyTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("DeepDungeonsTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("EconomyTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("GatheringTab_ShowCosmic", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("GatheringTab_ShowStellar", StringComparison.Ordinal) => true,
            _ when helpPropertyName is nameof(Languages.GatheringTab_ShowObtainedSandsFromAetherialReductionMessagesHelpMarker) or
                   nameof(Languages.GatheringTab_ShowAetherialReductionSuccessMessagesHelpMarker) => true,
            _ when helpPropertyName.StartsWith("MateriaTab_", StringComparison.Ordinal) =>
                helpPropertyName.Contains("Retrieved", StringComparison.Ordinal) ||
                helpPropertyName.Contains("Shatters", StringComparison.Ordinal),
            _ when helpPropertyName.StartsWith("DesynthesisTab_", StringComparison.Ordinal) =>
                helpPropertyName is not nameof(Languages.DesynthesisTab_ShowDesynthesisLevelIncreasesMessagesHelpMarker),
            _ when helpPropertyName is nameof(Languages.FreeCompanyTab_ShowFreeCompanyMessageBookMessagesHelpMarker) => true,
            _ when helpPropertyName is nameof(Languages.FreeCompanyTab_ShowLoginMessagesHelpMarker) or
                   nameof(Languages.FreeCompanyTab_ShowLogoutMessagesHelpMarker) => false,
            _ => ProgressSystemFilterHelpMarkers.Contains(helpPropertyName)
        };

    public static bool ShouldAppendLootFilterNote(string helpPropertyName) =>
        IsLootRollHelpMarker(helpPropertyName);

    public static bool ShouldAppendSystemHideFilterNote(string helpPropertyName) =>
        helpPropertyName is nameof(Languages.CurrenciesTab_HideInventoryItemAddedMessagesHelpMarker);

    public static bool ShouldAppendGatheringHideFilterNote(string helpPropertyName) =>
        helpPropertyName.StartsWith("GatheringTab_HideGathering", StringComparison.Ordinal) &&
        helpPropertyName.EndsWith("HelpMarker", StringComparison.Ordinal);

    public static void SystemFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithSystemFilterNote(help));

    public static void ObtainedFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithObtainedFilterNote(help));

    public static void ObtainedHideFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithObtainedHideFilterNote(help));

    public static void ObtainedAndSystemHideFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithObtainedAndSystemHideFilterNote(help));

    public static void LootAndObtainedHideFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithLootAndObtainedHideFilterNote(help));

    public static void LootFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithLootFilterNote(help));

    public static string WithCraftingFilterNote(string help) =>
        AppendNote(help, Languages.Shared_RequiresCraftingFilteringNote);

    public static bool ShouldAppendCraftingFilterNote(string helpPropertyName) =>
        helpPropertyName.EndsWith("HelpMarker", StringComparison.Ordinal) &&
        (helpPropertyName.StartsWith("CraftingTab_", StringComparison.Ordinal) ||
         helpPropertyName is nameof(Languages.MateriaTab_ShowMateriaSuccesfullyAttachedMessagesHelpMarker) or
             nameof(Languages.MateriaTab_ShowMateriaOvermeldFailuresMessagesHelpMarker) or
             nameof(Languages.MateriaTab_ShowMateriaExtractedMessagesHelpMarker)) &&
        helpPropertyName is not nameof(Languages.CraftingTab_ShowCraftingAbleToExecuteHelpMarker);

    public static string WithGatheringFilterNote(string help) =>
        AppendNote(help, Languages.Shared_RequiresGatheringFilteringNote);

    public static bool ShouldAppendGatheringFilterNote(string helpPropertyName) =>
        helpPropertyName.StartsWith("GatheringTab_", StringComparison.Ordinal) &&
        helpPropertyName.EndsWith("HelpMarker", StringComparison.Ordinal) &&
        !helpPropertyName.StartsWith("GatheringTab_Hide", StringComparison.Ordinal) &&
        helpPropertyName is not nameof(Languages.GatheringTab_ShowGatheringCollectableObtainMessagesHelpMarker) and
            not nameof(Languages.GatheringTab_ShowObtainedSandsFromAetherialReductionMessagesHelpMarker) and
            not nameof(Languages.GatheringTab_ShowAetherialReductionSuccessMessagesHelpMarker);

    public static void CraftingFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithCraftingFilterNote(help));

    public static void GatheringFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(AppendNote(help, Languages.Shared_RequiresGatheringFilteringNote));

    public static void GatheringHideFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithGatheringHideFilterNote(help));

    public static void ProgressFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithProgressFilterNote(help));

    public static void ProgressAndSystemFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithProgressAndSystemFilterNote(help));

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
