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
            StringChecks = [ChatStrings.LootRoll],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowLootRoll",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.RollsNeedOrGreed],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowCastLot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            StringChecks = [ChatStrings.CastLot],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowCastLot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.CastLot],
            Pattern = PatternKind.RegexMatch
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
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedShards],
            Pattern = PatternKind.RegexMatch,
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
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true
        },
        new()
        {
            Name = "HideObtainedShards",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedShards],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
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
            LogMessageIds = [1233],
            RegexChecks = [ChatRegexStrings.ObtainedShards],
            Pattern = PatternKind.RegexMatch,
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
            RegexChecks = [ChatRegexStrings.NotStartWithYou, ChatRegexStrings.OthersRollNeedOrGreed],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowOthersCastLot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootRoll,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.NotStartWithYou, ChatRegexStrings.OthersCastLot],
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
            Channel = ChatType.LootRoll,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.NotStartWithYou, ChatRegexStrings.OtherObtains],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerOtherPlayer = true,
            ExcludePlayerObtain = true,
            StringChecks = [ChatStrings.OtherObtainMarker]
        }
    ];
}
