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
            LogMessageIds = [1116],
            StringChecks = [ChatStrings.SomethingBites],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowReelInLine",
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
            Name = "ShowLoseBait",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1117],
            StringChecks = [ChatStrings.LoseBait],
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
        }
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
            Name = "ShowMooching",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3510, 3593, 3594],
            Pattern = PatternKind.None,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMooching",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3510],
            RegexChecks = [ChatStrings.MoochTipRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMooching",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3593],
            RegexChecks = [ChatStrings.MoochIILandRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMooching",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3594],
            RegexChecks = [ChatStrings.MoochMissRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSwimbaitMessages",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [5556, 5557, 5559],
            Pattern = PatternKind.None,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSwimbaitMessages",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [5556],
            RegexChecks = [ChatStrings.SwimbaitKeepRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSwimbaitMessages",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [5557],
            RegexChecks = [ChatStrings.SwimbaitReleaseKeepRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSwimbaitMessages",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [5559],
            RegexChecks = [ChatStrings.SwimbaitReleaseRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCurrentFishingHole",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1110],
            Pattern = PatternKind.None,
            PreferLogMessageCatalog = true,
            SoftHideLogMessage = true
        },
        new()
        {
            Name = "ShowCurrentFishingHole",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1110],
            RegexChecks = [ChatStrings.CurrentFishingHoleRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            SoftHideLogMessage = true
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
            Name = "ShowLureBiteFeelingMessages",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [5565, 5569],
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLureAttemptMessages",
            SettingsTab = "Fishing",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [5566, 5567, 5568, 5570, 5571, 5572],
            PreferLogMessageCatalog = true
        }
    ];
}
