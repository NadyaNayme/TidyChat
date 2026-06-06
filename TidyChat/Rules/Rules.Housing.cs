namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] HousingRules =
    [
        new()
        {
            Name = "ShowSanctuaryMessage",
            SettingsTab = "Housing",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [732, 733],
            StringChecks = [ChatStrings.SanctuaryMessage],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowHousingWardMessage",
            SettingsTab = "Housing",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3379],
            StringChecks = [ChatStrings.HousingWardMessage],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },

    ];
}