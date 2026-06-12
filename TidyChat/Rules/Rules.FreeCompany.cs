namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] FreeCompanyRules =
    [
        new()
        {
            Name = "ShowUserLogins",
            SettingsTab = "Free Company",
            Channel = ChatType.FreeCompanyLoginLogout,
            IsActive = true,
            LogMessageIds = [3085]
        },
        new()
        {
            Name = "ShowUserLogouts",
            SettingsTab = "Free Company",
            Channel = ChatType.FreeCompanyLoginLogout,
            IsActive = true,
            LogMessageIds = [3086],
            StringChecks = [ChatStrings.UserLoggedOut],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowUserLogouts",
            SettingsTab = "Free Company",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [84],
            StringChecks = [ChatStrings.UserLogout],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowExploratoryVoyage",
            SettingsTab = "Free Company",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4163]
        },
        new()
        {
            Name = "ShowSubaquaticVoyageEmbarked",
            SettingsTab = "Free Company",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6057],
            StringChecks = [ChatStrings.SubaquaticVoyageEmbarked],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSubaquaticVoyageFinalized",
            SettingsTab = "Free Company",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6059],
            StringChecks = [ChatStrings.SubaquaticVoyageFinalized],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSubaquaticVoyageOtherFinalized",
            SettingsTab = "Free Company",
            Channel = ChatType.FreeCompanyAnnouncement,
            IsActive = true,
            LogMessageIds = [6060],
            StringChecks = [ChatStrings.SubaquaticVoyageFinalized],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSubaquaticVoyageReturned",
            SettingsTab = "Free Company",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6061]
        },
        new()
        {
            Name = "ShowSubmarinePartRepaired",
            SettingsTab = "Free Company",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4168],
            StringChecks = [ChatStrings.SubmarinePartRepaired],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSubmarineAttainsRank",
            SettingsTab = "Free Company",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6062],
            StringChecks = [ChatStrings.SubmarineAttainsRank],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSubmarineRetrievalLevelsIncreased",
            SettingsTab = "Free Company",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6092],
            StringChecks = [ChatStrings.SubmarineRetrievalLevelsIncreased],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFreeCompanyMessageBook",
            SettingsTab = "Free Company",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3087, 6065, 3127]
        },
        new()
        {
            Name = "ShowFreeCompanyMessageBook",
            SettingsTab = "Free Company",
            Channel = ChatType.FreeCompanyAnnouncement,
            IsActive = true,
            LogMessageIds = [3127],
            StringChecks = [ChatStrings.CompanyActionExpired],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFreeCompanyMessageBook",
            SettingsTab = "Free Company",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.CompanyActionExpired],
            Pattern = PatternKind.StringMatch
        }
    ];
}
