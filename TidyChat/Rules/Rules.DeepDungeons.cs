namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] DeepDungeonRules =
    [
        new()
        {
            Name = "ShowObtainedPomander",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7220, 7221, 7222],
            StringChecks = [ChatStrings.ObtainedPomander],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCairnGlows",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7242],
            StringChecks = [ChatStrings.CairnGlows],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowRestoresLifeToFallen",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7243],
            StringChecks = [ChatStrings.CairnRestoresLife],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCairnActivates",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7245],
            StringChecks = [ChatStrings.CairnActivates],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTransference",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7246, 7247, 7248],
            StringChecks = [ChatStrings.Transference],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherpoolIncrease",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7250],
            StringChecks = [ChatStrings.AetherpoolIncrease],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherpoolUnchanged",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7251],
            StringChecks = [ChatStrings.AetherpoolUnchanged],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPomanderEffects",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7254, 7255, 7256, 7257, 7258, 7259, 7260, 7261, 7263, 7264],
            StringChecks = [ChatStrings.PomanderEffect],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTrapTriggered",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7224, 7225, 7226, 7227, 7228, 7229],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTrapTriggered",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.DeepDungeonLandmineTriggered],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowTrapTriggered",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.DeepDungeonTrapTriggered],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowTrapTriggered",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.DeepDungeonDetonatorTriggered],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowFloorNumber",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7249],
            StringChecks = [ChatStrings.DeepDungeonIndependentLeveling],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFloorNumber",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7270, 9218],
            StringChecks = [ChatStrings.FloorNumber],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFloorNumber",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7265],
            StringChecks = [ChatStrings.FloorNumber],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSenseAccursedHoard",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7272],
            StringChecks = [ChatStrings.SenseAccursedHoard],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDoNotSenseAccursedHoard",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7273],
            StringChecks = [ChatStrings.NoAccursedHoard],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDiscoverAccursedHoard",
            SettingsTab = "Deep Dungeons",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7274],
            StringChecks = [ChatStrings.DiscoverAccursedHoard],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];
}
