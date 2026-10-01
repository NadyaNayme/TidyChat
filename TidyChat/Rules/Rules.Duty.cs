namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] DutyFinderRules =
    [
        new()
        {
            Name = "ShowRecruitmentSearchResults",
            SettingsTab = "Duty",
            Channel = ChatType.PeriodicRecruitmentNotification,
            IsActive = true,
            LogMessageIds = [94],
            StringChecks = [ChatStrings.DutyFinderRecruitment],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = false
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4670],
            StringChecks = [ChatStrings.DutyFinderParticipation],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4671],
            StringChecks = [ChatStrings.DutyFinderPartyType],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = false
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [4680],
            StringChecks = [ChatStrings.DutyFinderMinimumIlActive],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4681],
            StringChecks = [ChatStrings.DutyFinderRegistrationLanguage],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4682],
            StringChecks = [ChatStrings.DutyFinderLanguageSet],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [897],
            StringChecks = [ChatStrings.DutyRegistrationComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [890],
            StringChecks = [ChatStrings.DutyRegistrationWithdrawn],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [902],
            StringChecks = [ChatStrings.PartyMemberDutyWithdrawn],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4676],
            StringChecks = [ChatStrings.DutyUnrestrictedCommence],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4218],
            StringChecks = [ChatStrings.EchoStrength],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4248],
            StringChecks = [ChatStrings.EnteredUnrestrictedDuty],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [979],
            StringChecks = [ChatStrings.PartyRecruitmentCommenced],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [981],
            StringChecks = [ChatStrings.PartyRecruitmentEnded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] DutyCommenceRules =
    [
        new()
        {
            Name = "ShowDutyCommenceMessage",
            SettingsTab = "General",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1531],
            // anchored regex, not 1531 tokens: "has begun" alone also matches FATE event lines
            RegexChecks = [ChatStrings.DutyHasBegunRegex],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideDutyCommenceBriefing",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [618, 4224, 9602, 9606, 9795, 4217]
        },
        new()
        {
            Name = "HideDutyCommenceBriefing",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [9602],
            StringChecks = [ChatStrings.DutyLevelSyncedBriefing],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideDutyCommenceBriefing",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [618],
            StringChecks = [ChatStrings.DutyPlayerLevelSynced],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideDutyCommenceBriefing",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [4224, 9606],
            StringChecks = [ChatStrings.DutyItemLevelSynced],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideDutyCommenceBriefing",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [9795],
            StringChecks = [ChatStrings.DutyAllianceReformNotice],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideDutyCommenceBriefing",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [4217],
            StringChecks = [ChatStrings.EchoStrength],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] DungeonMechanicRules =
    [
        new()
        {
            Name = "ShowDungeonMechanicMessages",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds =
            [
                2051, 2052, 2053, 2054, 2055, 2056, 2057, 2058, 2059, 2060, 2061, 2062, 2063, 2064, 2065, 2066,
                2067, 2068, 2069
            ]
        },
        new()
        {
            Name = "ShowDungeonMechanicMessages",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2060],
            StringChecks = [ChatStrings.DungeonFiresandSet],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDungeonMechanicMessages",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2061, 2062, 2065],
            StringChecks = [ChatStrings.DungeonShaftClear],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDungeonMechanicMessages",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2069],
            RegexChecks = [ChatStrings.DungeonMechanicDropsRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        }
    ];
}
