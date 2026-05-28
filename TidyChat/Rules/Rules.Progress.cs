namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] ProgressRules =
    [
        new()
        {
            Name = "ShowCompletionTime",
            SettingsTab = "Progress",
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
            Pattern = PatternKind.StringMatch
        },
        // Regex fallback: catches XP messages whose LogMessageId isn't registered above
        // (e.g. bonus-XP variants with (+N%) suffix added in newer patches).
        new()
        {
            Name = "ShowGainExperience",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [588, 589, 4466, 7300, 10953],
            RegexChecks = [ChatRegexStrings.GainExperience],
            Pattern = PatternKind.RegexMatch
        },
        // OnChat fallback when LogMessage handling did not run (no LogMessageIds — avoids Lumina catalog gate).
        new()
        {
            Name = "ShowGainExperience",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            StringChecks = [ChatStrings.GainExperience],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGainExperience",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.GainExperience],
            Pattern = PatternKind.RegexMatch
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
            Pattern = PatternKind.StringMatch
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowLevelUps",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            StringChecks = [ChatStrings.LevelUp],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowOtherLevelUps",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
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
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowAbilityUnlocks",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [609],
            StringChecks = [ChatStrings.MinionUnlock],
            Pattern = PatternKind.StringMatch
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowAbilityUnlocks",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            StringChecks = [ChatStrings.AbilityUnlock],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowAbilityUnlocks",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            StringChecks = [ChatStrings.MinionUnlock],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowAbilityUnlocks",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
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
            Channel = ChatType.Progress,
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
            Channel = ChatType.Progress,
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
            Channel = ChatType.Progress,
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
            Channel = ChatType.Progress,
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
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [1603],
            StringChecks = [ChatStrings.QuestObjectiveFulfilled],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDesynthesisLevel",
            SettingsTab = "Progress",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [4325],
            StringChecks = [ChatStrings.DesynthesisLevel],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];
}
