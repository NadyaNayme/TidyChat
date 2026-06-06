namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] ExplorationHuntRankRules =
    [
        new()
        {
            Name = "ShowSRankHunt",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9331]
        },
        new()
        {
            Name = "ShowSSRankHunt",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9332]
        }

    ];

    private static readonly LocalizedFilterRule[] ExplorationHuntSlainRules =
    [
        new()
        {
            Name = "ShowHuntSlain",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4411]
        },

    ];

    private static readonly LocalizedFilterRule[] ExplorationHuntMarkBillRules =
    [
        new()
        {
            Name = "ShowMarkBillMessages",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4412],
            StringChecks = [ChatStrings.MarkBillComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMarkBillMessages",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4415],
            StringChecks = [ChatStrings.MarkBillObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMarkBillMessages",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4416],
            StringChecks = [ChatStrings.MarkBillAbandon],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },

    ];

    private static readonly LocalizedFilterRule[] ExplorationDiscoveryRules =
    [
        new()
        {
            Name = "ShowHostilePresence",
            SettingsTab = "Exploration",
            Channel = ChatType.BattleSystem,
            IsActive = true,
            LogMessageIds = [3240],
            StringChecks = [ChatStrings.HostilePresence],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSpideySenses",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2600],
            StringChecks = [ChatStrings.SpideySenses],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLocationDiscovered",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [88],
            StringChecks = [ChatStrings.LocationDiscovered],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherCompass",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3712],
            StringChecks = [ChatStrings.AetherCompass],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }

    ];

    private static readonly LocalizedFilterRule[] ExplorationVistaRules =
    [
        new()
        {
            Name = "ShowVistaMessages",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1272, 1273]
        },

    ];

    private static readonly LocalizedFilterRule[] ExplorationQuestReminderRules =
    [
        new()
        {
            Name = "ShowQuestReminder",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.SayQuestReminder],
            Pattern = PatternKind.StringMatch
        }

    ];
}