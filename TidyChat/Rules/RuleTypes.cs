using System.Collections.Generic;
using ChatTwo.Code;
using TidyChat.Data;
using TidyChat.Translation.Data;

namespace TidyChat;

#pragma warning disable MA0048
public enum PatternKind
{
    None,
    StringMatch,
    RegexMatch
}

public enum SettingTab
{
    Basic,
    System,
    LootObtain,
    Progress,
    CraftingGathering
}

public enum SettingCategory
{
    None,
    EmoteFilters,
    ImprovedMessages,
    FreeCompany,
    DeepDungeon,
    Party,
    Trading,
    Looting,
    CommonCurrency,
    BattleCurrency,
    BeastTribe,
    OtherObtain,
    Desynthesis,
    Materia,
    Crafting,
    Gathering,
    Fishing
}

public class LocalizedFilterRule
{
    public required string Name { get; set; }
    public required string SettingsTab { get; set; }
    public ChatType Channel { get; set; }
    public IList<LocalizedRegex>? RegexChecks { get; set; }
    public IList<LocalizedStrings>? StringChecks { get; set; }
    public PatternKind Pattern { get; set; } = PatternKind.None;
    public required bool IsActive { get; set; }
    public string? Error { get; set; }
    public uint[]? LogMessageIds { get; set; }

    /// <summary>
    ///     When true, the rule blocks messages when IsActive is true ("Hide*" semantics).
    ///     When false (default), the rule blocks when IsActive is false ("Show*" semantics).
    ///     When <see cref="LogMessageIds"/> is also set, a non-<see cref="PatternKind.None"/> pattern
    ///     requires the formatted LogMessage text to match (for shared templates like 657 "You obtain .").
    /// </summary>
    public bool BlockWhenActive { get; set; }

    /// <summary>
    ///     When true, string matching prefers tokens derived from the Lumina LogMessage sheet
    ///     (using <see cref="LogMessageIds"/>) before falling back to <see cref="StringChecks"/>.
    /// </summary>
    public bool PreferLogMessageCatalog { get; set; }

    /// <summary>
    ///     When set, matches shared obtain LogMessage templates plus markers from this Lumina Item row.
    ///     Uses <see cref="ItemMarkerCatalog"/> with <see cref="StringChecks"/> as fallback markers.
    /// </summary>
    public uint? ObtainMarkerItemId { get; set; }

    /// <summary>When true, <see cref="ObtainMarkerItemId"/> matches any GC seal item marker.</summary>
    public bool ObtainMarkerAnySeal { get; set; }

    /// <summary>When true, matches any elemental shard/crystal/cluster item from Lumina (items 2–19).</summary>
    public bool ObtainMarkerAnyElemental { get; set; }

    /// <summary>When true with <see cref="ObtainMarkerAnyElemental"/>, limits matching to cluster items (14–19).</summary>
    public bool ObtainMarkerClustersOnly { get; set; }

    /// <summary>When true, matches any beast tribe currency item loaded from Lumina.</summary>
    public bool ObtainMarkerAnyTribal { get; set; }

    /// <summary>When true, matches obtain messages with a materials suffix.</summary>
    public bool ObtainMarkerMaterials { get; set; }

    /// <summary>When true, matches another player's obtain message (excludes messages starting with "you ").</summary>
    public bool ObtainMarkerOtherPlayer { get; set; }

    /// <summary>When true, only matches when the message is not from the local player ("you …").</summary>
    public bool ExcludePlayerObtain { get; set; }

    /// <summary>When false, elemental/materials markers skip the shared 657-template requirement (e.g. Gathering channel).</summary>
    public bool ObtainMarkerRequireSharedTemplate { get; set; } = true;

    /// <summary>When true, matches shared obtain templates plus gil marker text (not a Lumina Item row).</summary>
    public bool ObtainMarkerGil { get; set; }

    /// <summary>When true, matches shared obtain templates plus MGP marker text (not a Lumina Item row).</summary>
    public bool ObtainMarkerMgp { get; set; }

    public bool ShouldBlock => BlockWhenActive ? IsActive : !IsActive;
}
