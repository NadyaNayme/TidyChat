namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] DungeonMechanicRules =
    [
        new()
        {
            Name = "ShowDungeonMechanicMessages",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds =
            [
                2051, 2052, 2053, 2054, 2055, 2056, 2057, 2058, 2059, 2060, 2061, 2062, 2063, 2064, 2065, 2066,
                2067, 2068, 2069
            ]
        },
        new()
        {
            Name = "ShowDungeonMechanicMessages",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2060],
            StringChecks = [ChatStrings.DungeonFiresandSet],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDungeonMechanicMessages",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2061, 2062, 2065],
            StringChecks = [ChatStrings.DungeonShaftClear],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDungeonMechanicMessages",
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2069],
            RegexChecks = [ChatStrings.DungeonMechanicDropsRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        }
    ];
}
