namespace TidyChat;

public static partial class Rules
{
    private static void AddLootRules(List<LocalizedFilterRule> rules)
    {
        rules.AddRange(LootPartyEarlyRules);
        rules.AddRange(LootGatheringShardRules);
        rules.AddRange(LootPartyLateRules);
    }

    private static readonly LocalizedFilterRule[] LootPartyEarlyRules =
    [
        new()
        {
            Name = "ShowLootRoll",
            SettingsTab = "Party",
            Channel = ChatType.LootRoll,
            IsActive = true,
            LogMessageIds = [1231],
            StringChecks = [ChatStrings.LootRoll],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCastLot",
            SettingsTab = "Party",
            Channel = ChatType.LootRoll,
            IsActive = true,
            LogMessageIds = [5180],
            StringChecks = [ChatStrings.CastLot],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] LootPartyLateRules =
    [
        new()
        {
            Name = "ShowOthersLootRoll",
            SettingsTab = "Party",
            Channel = ChatType.LootRoll,
            IsActive = true,
            LogMessageIds = [1231],
            RegexChecks = [ChatStrings.NotStartWithYou, ChatStrings.OthersRollNeedOrGreed],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowOthersCastLot",
            SettingsTab = "Party",
            Channel = ChatType.LootRoll,
            IsActive = true,
            LogMessageIds = [5180],
            RegexChecks = [ChatStrings.OthersCastLot],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideOthersObtain",
            SettingsTab = "Party",
            Channel = ChatType.LootRoll,
            IsActive = true,
            BlockWhenActive = true,
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerOtherPlayer = true,
            ExcludePlayerObtain = true,
            StringChecks = [ChatStrings.OtherObtainMarker]
        },
        new()
        {
            Name = "HideOthersObtain",
            SettingsTab = "Party",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerOtherPlayer = true,
            ExcludePlayerObtain = true,
            StringChecks = [ChatStrings.OtherObtainMarker]
        },
        new()
        {
            Name = "HideOthersObtain",
            SettingsTab = "Party",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainMaterialsMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerMaterials = true,
            ExcludePlayerObtain = true
        }
    ];

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
            // shares templates with ShowGatheringCollectableObtains; this hide must win via activeHideMatch
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
