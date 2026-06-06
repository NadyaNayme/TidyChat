namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] FishingRulesEarly =
    [
        new()
        {
            Name = "ShowCaughtFish",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1116, 1117, 3511, 5584, 11333]
        },
        new()
        {
            Name = "ShowCaughtFish",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1116],
            StringChecks = [ChatStrings.SomethingBites],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCaughtFish",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [5584, 3511],
            StringChecks = [ChatStrings.ReelInLine],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCaughtFish",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [11333],
            StringChecks = [ChatStrings.MultihookBonusFish],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
    ];

    private static readonly LocalizedFilterRule[] FishingRulesLate =
    [
        new()
        {
            Name = "ShowMooching",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1121],
            StringChecks = [ChatStrings.Mooching],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCurrentFishingHole",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1110],
            StringChecks = [ChatStrings.CurrentFishingHole],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDiscoveredFishingHole",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1130, 3513, 3579],
            StringChecks = [ChatStrings.DiscoveredFishingHole],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMeasuringIlms",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3512, 3559],
            StringChecks = [ChatStrings.MeasuringIlms],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLureMessages",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [5566, 5565, 5569, 5570, 5571, 5572],
            StringChecks = [ChatStrings.LureFish],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];
}