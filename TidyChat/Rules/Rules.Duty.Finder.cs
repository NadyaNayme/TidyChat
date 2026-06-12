namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] DutyFinderRules =
    [
        new()
        {
            Name = "ShowDutyFinder",
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
}
