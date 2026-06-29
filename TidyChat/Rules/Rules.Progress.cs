namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] ProgressRules =
    [
        new()
        {
            Name = "ShowCompletionTime",
            SettingsTab = "Duty",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [4679],
            StringChecks = [ChatStrings.CompletionTime],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGainExperience",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [588, 589, 4466, 7300, 10953],
            StringChecks = [ChatStrings.GainExperience],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGainMettle",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [9635],
            StringChecks = [ChatStrings.GainMettle],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGainExperience",
            SettingsTab = "Progress",
            Channel = ChatType.BattleSystem,
            IsActive = true,
            LogMessageIds = [549],
            StringChecks = [ChatStrings.GainExperience],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGainExperience",
            SettingsTab = "Progress",
            Channel = ChatType.BattleSystem,
            IsActive = true,
            LogMessageIds = [549],
            StringChecks = [ChatStrings.ExpChainBonus],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = false
        },
        new()
        {
            Name = "ShowGainPvpExp",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [659],
            StringChecks = [ChatStrings.GainPvpExp],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGainPvpRank",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [660],
            StringChecks = [ChatStrings.GainPvpRank],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGainSeriesExp",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [7556],
            StringChecks = [ChatStrings.GainSeriesExp],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGainSeriesExp",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [7557],
            StringChecks = [ChatStrings.GainSeriesLevel],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPvpZoneAnnouncements",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11308],
            StringChecks = [ChatStrings.WorqorTriumphReduced],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPvpZoneAnnouncements",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11311],
            StringChecks = [ChatStrings.WorqorLimitGauge],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPvpZoneAnnouncements",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11312],
            StringChecks = [ChatStrings.WorqorAuroras],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPvpZoneAnnouncements",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11313],
            StringChecks = [ChatStrings.WorqorHighRankTriumphs],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPvpZoneAnnouncements",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11368],
            StringChecks = [ChatStrings.WorqorSnowStopped],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPvpZoneAnnouncements",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatStrings.FrontlineObjectiveAnnouncementRegex],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowPvpCombatMessages",
            SettingsTab = "Progress",
            Channel = ChatType.BattleSystem,
            IsActive = true,
            LogMessageIds = [557, 558, 559, 560],
            Pattern = PatternKind.None,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPvpCombatMessages",
            SettingsTab = "Progress",
            Channel = ChatType.BattleSystem,
            IsActive = true,
            RegexChecks = [ChatStrings.PvpCombatMessageRegex],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "ShowEarnAchievement",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [952],
            StringChecks = [ChatStrings.PlayerEarnAchievement],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowOtherEarnedAchievement",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [952],
            StringChecks = [ChatStrings.OtherEarnAchievement],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLevelUps",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [590],
            StringChecks = [ChatStrings.LevelUp],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLevelUps",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [591],
            StringChecks = [ChatStrings.OtherLevelUp],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAbilityUnlock",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [552],
            StringChecks = [ChatStrings.AbilityUnlock],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowOtherLevelUps",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3921, 9454],
            StringChecks = [ChatStrings.OtherLevelUp],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDesynthesisLevel",
            SettingsTab = "Desynthesis",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [4325],
            StringChecks = [ChatStrings.DesynthesisLevel],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];
    private static readonly LocalizedFilterRule[] ProgressAwardRules =
    [
        new()
        {
            Name = "ShowFirstClearAward",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4225],
            StringChecks = [ChatStrings.FirstClearBonus],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSecondChanceAward",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7975],
            StringChecks = [ChatStrings.SecondChanceAward],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] ObtainProgressHideRules =
    [
        new()
        {
            Name = "HideRouletteBonus",
            SettingsTab = "Progress",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2246]
        },
        new()
        {
            Name = "HideAdventurerInNeedBonus",
            SettingsTab = "Progress",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2244]
        }
    ];
}
