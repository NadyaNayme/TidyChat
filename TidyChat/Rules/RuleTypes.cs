using System.Collections.Generic;
using TidyChat.Translation.Data;
namespace TidyChat;

#pragma warning disable MA0048
public enum PatternKind
{
    None,
    StringMatch,
    RegexMatch
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
    ///     When true, the rule blocks while <see cref="IsActive" /> is true ("Hide*" settings).
    ///     When false, it blocks while inactive ("Show*" settings).
    ///     With <see cref="LogMessageIds" /> set, non-<see cref="PatternKind.None" /> patterns also require
    ///     the formatted LogMessage text to match (for shared templates such as 657 "You obtain .").
    /// </summary>
    public bool BlockWhenActive { get; set; }

    /// <summary>
    ///     Prefer Lumina LogMessage tokens from <see cref="LogMessageIds" /> before
    ///     <see cref="StringChecks" />.
    /// </summary>
    public bool PreferLogMessageCatalog { get; set; }

    /// <summary>
    ///     Match shared obtain LogMessage templates plus markers from this Lumina Item row.
    ///     Uses <see cref="ItemMarkerCatalog" /> with <see cref="StringChecks" /> as fallback.
    /// </summary>
    public uint? ObtainMarkerItemId { get; set; }

    /// <summary>Match any GC seal item marker via <see cref="ObtainMarkerItemId" />.</summary>
    public bool ObtainMarkerAnySeal { get; set; }

    /// <summary>Match elemental shard, crystal, or cluster items from Lumina (rows 2-19).</summary>
    public bool ObtainMarkerAnyElemental { get; set; }

    /// <summary>With <see cref="ObtainMarkerAnyElemental" />, match cluster items only (rows 14-19).</summary>
    public bool ObtainMarkerClustersOnly { get; set; }

    /// <summary>Match any beast tribe currency item loaded from Lumina.</summary>
    public bool ObtainMarkerAnyTribal { get; set; }

    /// <summary>Match obtain messages with a materials suffix.</summary>
    public bool ObtainMarkerMaterials { get; set; }

    /// <summary>Match another player's obtain line (skip messages starting with "you ").</summary>
    public bool ObtainMarkerOtherPlayer { get; set; }

    /// <summary>Skip local-player obtain lines ("you …").</summary>
    public bool ExcludePlayerObtain { get; set; }

    /// <summary>When false, skip the shared 657-template requirement (e.g. Gathering channel).</summary>
    public bool ObtainMarkerRequireSharedTemplate { get; set; } = true;

    /// <summary>Match shared obtain templates plus gil marker text (not a Lumina Item row).</summary>
    public bool ObtainMarkerGil { get; set; }

    /// <summary>Match shared obtain templates plus MGP marker text (not a Lumina Item row).</summary>
    public bool ObtainMarkerMgp { get; set; }

    public bool ShouldBlock => BlockWhenActive ? IsActive : !IsActive;
}
