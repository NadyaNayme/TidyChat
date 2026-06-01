using System;
using System.Collections.Generic;
using Dalamud.Interface.Components;
using TidyChat.Localization.Resources;

namespace TidyChat.Settings;

internal static class UiHelp
{
    private static readonly HashSet<string> ProgressSystemFilterHelpMarkers = new(StringComparer.Ordinal)
    {
        nameof(Languages.ProgressTab_ShowQuestProgressMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowBonusAwardForDutyRouletteMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowAdventurerInNeedAwardMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowLearnedAbilityMessagesHelpMarker),
        nameof(Languages.ProgressTab_ShowOtherPlayerLevelUpMessagesHelpMarker),
    };

    public static string WithSystemFilterNote(string help) =>
        string.IsNullOrWhiteSpace(help)
            ? Languages.Shared_RequiresSystemFilteringNote
            : help.TrimEnd() + "\n\n" + Languages.Shared_RequiresSystemFilteringNote;

    public static bool ShouldAppendSystemFilterNote(string helpPropertyName) =>
        helpPropertyName switch
        {
            nameof(Languages.SystemTab_ServerAnnouncementsHelpMarker) => false,
            nameof(Languages.SystemTab_ShowEverythingElseHelpMarker) => false,
            _ when helpPropertyName.StartsWith("SystemTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("PartyDutyTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("EconomyTab_", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("CraftingGatheringTab_ShowCosmic", StringComparison.Ordinal) => true,
            _ when helpPropertyName.StartsWith("CraftingGatheringTab_ShowStellar", StringComparison.Ordinal) => true,
            _ => ProgressSystemFilterHelpMarkers.Contains(helpPropertyName),
        };

    public static void SystemFilterMarker(string help) =>
        ImGuiComponents.HelpMarker(WithSystemFilterNote(help));
}
