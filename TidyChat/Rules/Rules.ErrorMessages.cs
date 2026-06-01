namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] ErrorMessageRules =
    [
        new()
        {
            Name = "HideFateLevelSync",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2070, 2166],
            StringChecks = [ChatStrings.FateLevelTooHighToAttack],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFateDiscovery",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2001, 2026],
            StringChecks = [ChatStrings.FateDiscovered],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFriendList",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7487],
            StringChecks = [ChatStrings.FriendRequestSent],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFriendList",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7488],
            StringChecks = [ChatStrings.FriendRequestReceived],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFriendList",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [78],
            StringChecks = [ChatStrings.FriendAddedToList],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFriendList",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [81],
            StringChecks = [ChatStrings.FriendListUpdated],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFriendList",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.FriendRequestSent],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowFriendList",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.FriendRequestReceived],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowFriendList",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.FriendAddedToList],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowFriendList",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.FriendListUpdated],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowActiveHelpEntry",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1286],
            StringChecks = [ChatStrings.ActiveHelpEntryAdded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowActiveHelpEntry",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.ActiveHelpEntryAdded],
            Pattern = PatternKind.StringMatch
        }
    ];
}
