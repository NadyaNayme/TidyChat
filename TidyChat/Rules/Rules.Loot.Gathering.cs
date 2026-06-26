namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] LootGatheringShardRules =
    [
        new()
        {
            Name = "HideObtainedShards",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            BlockWhenActive = true,
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true,
            ObtainMarkerRequireSharedTemplate = false
        },
        new()
        {
            Name = "HideObtainedShards",
            SettingsTab = "Gathering",
            Channel = ChatType.LootRoll,
            IsActive = true,
            BlockWhenActive = true,
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true
        },
        new()
        {
            Name = "HideObtainedShards",
            SettingsTab = "Gathering",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true
        },
        new()
        {
            Name = "HideObtainedShards",
            SettingsTab = "Gathering",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1233],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true,
            ObtainMarkerRequireSharedTemplate = false
        },
        new()
        {
            Name = "HideObtainedShards",
            SettingsTab = "Gathering",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1606, 1607, 750, 751],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true,
            ObtainMarkerRequireSharedTemplate = false
        },
        new()
        {
            // Gathering obtain templates also used for collectables (ShowGatheringCollectableObtains).
            // Elemental shards/crystals/clusters gathered here must defer to this hide rule, which wins
            // over the active show rule via activeHideMatch precedence on the LogMessage path.
            Name = "HideObtainedShards",
            SettingsTab = "Gathering",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [3538, 1049, 1050, 1053, 1054],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true,
            ObtainMarkerRequireSharedTemplate = false
        },
        new()
        {
            Name = "HideObtainedShards",
            SettingsTab = "Gathering",
            Channel = ChatType.System,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [4322, 4323],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true,
            ObtainMarkerRequireSharedTemplate = false
        }
    ];
}
