namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] GatheringCoreRules =
    [
        new()
        {
            Name = "ShowGatheringYield",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3537, 1099],
            StringChecks = [ChatStrings.GatheringYield],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGatheringAttempts",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [1098],
            StringChecks = [ChatStrings.GatheringAttempts],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGatheringAttempts",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [1102, 1103, 1105],
            StringChecks = [ChatStrings.GatheringAttemptGranted],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGatherersBoon",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [1097],
            StringChecks = [ChatStrings.GatherersBoon],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGatherersBoon",
            SettingsTab = "Gathering",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11172, 11173],
            StringChecks = [ChatStrings.GatherersBoonScore],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGatheringStartEnd",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1063, 1064, 1065, 1066],
            StringChecks = [ChatStrings.GatheringBegin],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGatheringStartEnd",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1067, 1068, 1069, 1070],
            StringChecks = [ChatStrings.GatheringFinish],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGatheringSenses",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [1086, 3501, 3502, 3518, 3519]
        },
        new()
        {
            Name = "ShowGatheringSenses",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [1086, 3501],
            StringChecks = [ChatStrings.GatheringSenses],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGatheringSenses",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [3502],
            StringChecks = [ChatStrings.GatheringNoLongerSense],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGatheringSenses",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [1086, 3501],
            RegexChecks = [ChatStrings.SpideySensesRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLocationAffects",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [1096],
            StringChecks = [ChatStrings.LocationAffects],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLocationAffects",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [5550],
            StringChecks = [ChatStrings.LocationCollectabilityIncrease],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLocationAffects",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [5551],
            StringChecks = [ChatStrings.LocationMeticulousIntegrity],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGatheringCollectableObtains",
            SettingsTab = "Gathering",
            Channel = ChatType.LootNotice,
            IsActive = true,
            LogMessageIds = [3538, 1049, 1050, 1053, 1054],
            StringChecks = [ChatStrings.ObtainedSingleItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGatheringCollectableObtains",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            StringChecks = [ChatStrings.ObtainedSingleItem],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowAllOtherGathering",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3549],
            StringChecks = [ChatStrings.CollectabilityIncreases],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAllOtherGathering",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3569],
            StringChecks = [ChatStrings.CollectabilityMeticulousIntuition],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] GatheringMiscRules =
    [
        new()
        {
            Name = "ShowAllOtherGathering",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1111, 3549, 3569]
        },
        new()
        {
            Name = "ShowGatheringBuffEffectGain",
            SettingsTab = "Gathering",
            Channel = ChatType.GainBuff,
            IsActive = true,
            LogMessageIds = [603],
            StringChecks = [ChatStrings.BuffEffectGain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAllOtherGathering",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1111],
            StringChecks = [ChatStrings.PutAwayRod],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static void AddGatheringRules(List<LocalizedFilterRule> rules)
    {
        rules.AddRange(GatheringCoreRules);
        rules.AddRange(FishingRulesEarly);
        rules.AddRange(GatheringMiscRules);
        rules.AddRange(FishingRulesLate);
    }
}
