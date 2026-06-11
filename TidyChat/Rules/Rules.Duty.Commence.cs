namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] DutyCommenceRules =
    [
        new()
        {
            Name = "ShowDutyCommenceMessage",
            SettingsTab = "General",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1531],
            // Anchored regex instead of token matching: the 1531 template tokens are just
            // "has begun", which also matches event lines like the aramitama Lifestream FATE.
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
}
