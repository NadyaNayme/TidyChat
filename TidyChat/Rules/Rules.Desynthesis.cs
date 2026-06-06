namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] DesynthesisRules =
    [
        new()
        {
            Name = "ShowDesynthedItem",
            SettingsTab = "Desynthesis",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4321],
            StringChecks = [ChatStrings.DesynthedItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDesynthesisObtains",
            SettingsTab = "Desynthesis",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4322, 4323],
            StringChecks = [ChatStrings.DesynthesisObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }

    ];
}