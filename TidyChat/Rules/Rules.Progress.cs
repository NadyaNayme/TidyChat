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
            Name = "ShowAbilityUnlocks",
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
            Name = "ShowAbilityUnlocks",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [609],
            StringChecks = [ChatStrings.MinionUnlock],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAbilityUnlocks",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3612],
            StringChecks = [ChatStrings.JobWisdomBequeathed],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAbilityUnlocks",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3613],
            StringChecks = [ChatStrings.JobMemoriesAwoken],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAbilityUnlocks",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1461],
            StringChecks = [ChatStrings.OathGaugeExpanded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowQuestProgress",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [410],
            StringChecks = [ChatStrings.ClassJobQuestAvailable],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowQuestProgress",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3780],
            StringChecks = [ChatStrings.ChallengeLogComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowQuestProgress",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3783],
            StringChecks = [ChatStrings.ChallengeLogAlmostComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowQuestProgress",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1601],
            StringChecks = [ChatStrings.QuestAccepted],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowQuestProgress",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1602],
            StringChecks = [ChatStrings.QuestComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowQuestProgress",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1603],
            StringChecks = [ChatStrings.QuestObjectiveFulfilled],
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
}
