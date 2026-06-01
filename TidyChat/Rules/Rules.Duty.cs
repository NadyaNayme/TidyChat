namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] DutyCommenceRules =
    [
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
}
