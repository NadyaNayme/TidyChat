namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] LootRules =
    [
        new()
        {
            Name = "ShowLootRoll",
            SettingsTab = "Loot/Obtain",
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
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            LogMessageIds = [5180],
            StringChecks = [ChatStrings.CastLot],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
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
            SettingsTab = "Loot/Obtain",
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
            SettingsTab = "Loot/Obtain",
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
            SettingsTab = "Loot/Obtain",
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
            SettingsTab = "Loot/Obtain",
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
            Name = "ShowOthersLootRoll",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            LogMessageIds = [1231],
            RegexChecks = [ChatRegexStrings.NotStartWithYou, ChatRegexStrings.OthersRollNeedOrGreed],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowOthersCastLot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            LogMessageIds = [5180],
            RegexChecks = [ChatRegexStrings.OthersCastLot],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideOthersObtain",
            SettingsTab = "Loot/Obtain",
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
            SettingsTab = "Loot/Obtain",
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
}
