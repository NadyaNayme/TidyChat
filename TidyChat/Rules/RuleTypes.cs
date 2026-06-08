using TidyChat.Localization.Data;
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

    public bool BlockWhenActive { get; set; }

    public bool PreferLogMessageCatalog { get; set; }

    /// <summary>
    ///     When blocking on the LogMessage path, hide in chat only — do not call
    ///     <see cref="Dalamud.Game.Chat.ILogMessage.PreventOriginal" /> so other plugins can still observe the event.
    /// </summary>
    public bool SoftHideLogMessage { get; set; }

    public uint? ObtainMarkerItemId { get; set; }

    public bool ObtainMarkerAnySeal { get; set; }

    public bool ObtainMarkerAnyElemental { get; set; }

    public bool ObtainMarkerClustersOnly { get; set; }

    public bool ObtainMarkerAnyTribal { get; set; }

    public bool ObtainMarkerMaterials { get; set; }

    public bool ObtainMarkerOtherPlayer { get; set; }

    public bool ExcludePlayerObtain { get; set; }

    public bool ObtainMarkerRequireSharedTemplate { get; set; } = true;

    public bool ObtainMarkerGil { get; set; }

    public bool ObtainMarkerMgp { get; set; }

    public bool ShouldBlock => BlockWhenActive ? IsActive : !IsActive;
}
