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
            LogMessageIds = [2070, 2166]
        },
        new()
        {
            Name = "HideFateLevelSync",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2166],
            StringChecks = [ChatStrings.FateLevelTooHighToAttack],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Crafting,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1147],
            StringChecks = [ChatStrings.UnableToCraft],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [579],
            StringChecks = [ChatStrings.CannotExecute],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [563],
            StringChecks = [ChatStrings.InvalidTarget],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [574],
            StringChecks = [ChatStrings.CannotUseAsClass],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1262],
            StringChecks = [ChatStrings.UnableToUseItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1236],
            StringChecks = [ChatStrings.UnableToObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1268],
            StringChecks = [ChatStrings.UnableToObtainAlreadyPossess],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [582],
            StringChecks = [ChatStrings.NotYetReady],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [598],
            StringChecks = [ChatStrings.TargetOutOfRange],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [566],
            StringChecks = [ChatStrings.TargetNotInRange],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [562],
            StringChecks = [ChatStrings.TargetNotInLineOfSight],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [4316],
            StringChecks = [ChatStrings.UnableToApplyGlamourPlates],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1310],
            StringChecks = [ChatStrings.TooFarAway],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1950],
            StringChecks = [ChatStrings.UnableToUseUniqueItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [7727],
            StringChecks = [ChatStrings.UnableToExecuteWhileCasting],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideCannotExecute",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [7122],
            StringChecks = [ChatStrings.UnableToConvertPartySave],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFateDiscovery",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2001],
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
            LogMessageIds = [78],
            StringChecks = [ChatStrings.FriendAddedToList],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowFriendList",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.FriendRequestSent],
            Pattern = PatternKind.StringMatch,
        },
        new()
        {
            Name = "ShowFriendList",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.FriendAddedToList],
            Pattern = PatternKind.StringMatch,
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
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowActiveHelpEntry",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.ActiveHelpEntryAdded],
            Pattern = PatternKind.StringMatch,
        },

    ];
}
