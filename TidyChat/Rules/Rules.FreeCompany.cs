namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] FreeCompanyRules =
    [

        new()
        {
            Name = "ShowUserLogins",
            SettingsTab = "System",
            Channel = ChatType.FreeCompanyLoginLogout,
            IsActive = true,
            LogMessageIds = [3085]
        },
        new()
        {
            Name = "ShowUserLogouts",
            SettingsTab = "System",
            Channel = ChatType.FreeCompanyLoginLogout,
            IsActive = true,
            LogMessageIds = [84, 3086],
            StringChecks = [ChatStrings.UserLogout],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowUserLogouts",
            SettingsTab = "System",
            Channel = ChatType.FreeCompanyLoginLogout,
            IsActive = true,
            StringChecks = [ChatStrings.UserLogout],
            Pattern = PatternKind.StringMatch,
        },
        new()
        {
            Name = "ShowMountMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [646],
            StringChecks = [ChatStrings.MountMessage],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMountMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1306],
            StringChecks = [ChatStrings.MountSpeedIncreased],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },

    ];
}
