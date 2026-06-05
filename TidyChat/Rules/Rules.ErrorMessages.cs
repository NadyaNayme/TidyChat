namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] ErrorMessageRules =
    [
        // Always shown on Error channel — no user toggle (former HideCannotExecute IDs).
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [579],
            StringChecks = [ChatStrings.CannotExecute],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [586],
            StringChecks = [ChatStrings.OnlyAvailableWhileCrafting],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [563],
            StringChecks = [ChatStrings.InvalidTarget],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [574],
            StringChecks = [ChatStrings.CannotUseAsClass],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [1262],
            StringChecks = [ChatStrings.UnableToUseItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1236],
            StringChecks = [ChatStrings.UnableToObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [1268],
            StringChecks = [ChatStrings.UnableToObtainAlreadyPossess],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [582],
            StringChecks = [ChatStrings.NotYetReady],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [598],
            StringChecks = [ChatStrings.TargetOutOfRange],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [599],
            StringChecks = [ChatStrings.CannotSeeTarget],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [566],
            StringChecks = [ChatStrings.TargetNotInRange],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [562],
            StringChecks = [ChatStrings.TargetNotInLineOfSight],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [765],
            StringChecks = [ChatStrings.GearsetUnableToEquip],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [4316],
            StringChecks = [ChatStrings.UnableToApplyGlamourPlates],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [1310],
            StringChecks = [ChatStrings.TooFarAway],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1314],
            StringChecks = [ChatStrings.ActionCanceledUnderAttack],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [1950],
            StringChecks = [ChatStrings.UnableToUseUniqueItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [7727],
            StringChecks = [ChatStrings.UnableToExecuteWhileCasting],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [7704],
            StringChecks = [ChatStrings.UnableToExecuteWhileMounted],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [7122],
            StringChecks = [ChatStrings.UnableToConvertPartySave],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [726],
            StringChecks = [ChatStrings.CommandUnavailable],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCannotExecuteMessages",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [899],
            StringChecks = [ChatStrings.PartyLeaderDutyRegister],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
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
            Name = "ShowActiveHelpEntry",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1286],
            StringChecks = [ChatStrings.ActiveHelpEntryAdded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];
}
