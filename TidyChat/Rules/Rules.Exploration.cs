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
            Name = "ShowSRankHunt",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatStrings.HuntSRankRelayRegex],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowSSRankHunt",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9332]
        },
        new()
        {
            Name = "ShowSSRankHunt",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatStrings.HuntSSRankRelayRegex],
            Pattern = PatternKind.RegexMatch
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
        }
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
        // 9330/9333 — weekly/daily bill mark direction + lost-sense (not S/SS spawn 9331/9332).
        new()
        {
            Name = "ShowMarkBillMessages",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9330, 9333],
            Pattern = PatternKind.None,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMarkBillMessages",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9330],
            RegexChecks = [ChatStrings.MarkBillSenseDirectionRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMarkBillMessages",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9333],
            RegexChecks = [ChatStrings.MarkBillSenseLostRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        }
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

    private static readonly LocalizedFilterRule[] ExplorationFieldOpsRules =
    [
        new()
        {
            Name = "ShowTreasureCofferSenses",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10965, 10966],
            Pattern = PatternKind.None,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTreasureCofferSenses",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10965],
            RegexChecks = [ChatStrings.TreasureCofferSenseRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTreasureCofferSenses",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10966],
            RegexChecks = [ChatStrings.NoTreasureCofferSenseRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTreasurePotSenses",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9003, 9004, 9005, 9006, 10986, 10987, 10988, 10989, 10996, 10997],
            Pattern = PatternKind.None,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTreasurePotSenses",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9003, 9004, 9005, 9006, 10986, 10987, 10988, 10989],
            RegexChecks = [ChatStrings.TreasurePotSenseRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTreasurePotSenses",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10997],
            RegexChecks = [ChatStrings.HappyBunnyAbsentRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTreasurePotSenses",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10996],
            RegexChecks = [ChatStrings.HappyBunnyOfferRegex],
            Pattern = PatternKind.RegexMatch,
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
        }
    ];

    private static readonly LocalizedFilterRule[] ExplorationQuestReminderRules =
    [
        new()
        {
            Name = "ShowQuestReminder",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatStrings.SayQuestReminderRegex],
            Pattern = PatternKind.RegexMatch
        }
    ];
}
