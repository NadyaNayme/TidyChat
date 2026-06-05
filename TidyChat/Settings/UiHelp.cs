using Dalamud.Interface.Components;
using System.Collections.Generic;
namespace TidyChat.Settings;

internal static class UiHelp
{
    private static readonly HashSet<string> ProgressSystemFilterHelpMarkers = new(StringComparer.Ordinal)
    {
        nameof(Languages.ProgressTab_ShowQuestProgressMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowBonusAwardForDutyRouletteMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowAdventurerInNeedAwardMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowLearnedAbilityMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowOtherPlayerLevelUpMessagesHelpMarker)
    };

    public static string WithSystemFilterNote(string help) =>
        AppendNote(help, Languages.Shared_RequiresSystemFilteringNote);

    public static string WithObtainedFilterNote(string help) =>
        AppendNote(help, Languages.Shared_RequiresObtainedFilteringNote);

    public static string WithLootFilterNote(string help) =>
        AppendNote(help, Languages.Shared_RequiresLootFilteringNote);

    public static bool ShouldAppendObtainedFilterNote(string helpPropertyName) =>
        (helpPropertyName.StartsWith("ObtainTab_", StringComparison.Ordinal) ||
         helpPropertyName.StartsWith("GoldSaucerTab_", StringComparison.Ordinal)) &&
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
            _ when helpPropertyName.StartsWith("PartyDutyTab_ShowAirship", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("PartyDutyTab_ShowSubmarine", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("PartyDutyTab_ShowSubaquatic", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("SystemTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("PartyDutyTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("EconomyTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("CraftingGatheringTab_ShowCosmic", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("CraftingGatheringTab_ShowStellar", StringComparison.Ordinal) => true,
            _ => ProgressSystemFilterHelpMarkers.Contains(helpPropertyName)
        };

    public static bool ShouldAppendLootFilterNote(string helpPropertyName) =>
        IsLootRollHelpMarker(helpPropertyName);

    public static void SystemFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithSystemFilterNote(help));

    public static void ObtainedFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithObtainedFilterNote(help));

    public static void LootFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithLootFilterNote(help));

    public static void CraftingFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(AppendNote(help, Languages.Shared_RequiresCraftingFilteringNote));

    public static void GatheringFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(AppendNote(help, Languages.Shared_RequiresGatheringFilteringNote));

    public static void ProgressFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(AppendNote(help, Languages.Shared_RequiresProgressFilteringNote));

    private static bool IsLootRollHelpMarker(string helpPropertyName) =>
        helpPropertyName is nameof(Languages.ObtainTab_CastYourLotHelpMarker) or
            nameof(Languages.ObtainTab_ShowYouRolledMessagesHelpMarker) or
            nameof(Languages.ObtainTab_ShowAnotherPlayerCastsLotMessagesHelpMarker) or
            nameof(Languages.ObtainTab_ShowAnotherPlayerRollsMessagesHelpMarker) or
            nameof(Languages.ObtainTab_ShowOnlyPartyMemberRollsHelpMarker) or
            nameof(Languages.ObtainTab_ShowOtherPlayersLootRollsHelpMarker);

    private static string AppendNote(string help, string note) =>
        string.IsNullOrWhiteSpace(help)
            ? note
            : help.TrimEnd().Contains(note, StringComparison.Ordinal)
                ? help
                : help.TrimEnd() + "\n\n" + note;
}
