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
            Name = "ShowInvalidCommandError",
            SettingsTab = "System",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [725],
            Pattern = PatternKind.None,
            PreferLogMessageCatalog = true
        }
    ];
}
