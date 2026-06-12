namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] CosmicExplorationRules =
    [
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds =
            [
                631, 10764, 10766, 10769, 10770, 10771, 10779, 10781, 10804, 10815, 10822, 10827, 10828,
                10878, 10879, 10946, 11154, 11165, 11197, 11200, 11379, 11383, 10784
            ]
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11154],
            StringChecks = [ChatStrings.StellarMissionUnderway],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10764],
            StringChecks = [ChatStrings.StellarSpecialActionUnlock],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10804],
            StringChecks = [ChatStrings.StellarMissionScore],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarAbleToExecute",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [5533, 11365],
            StringChecks = [ChatStrings.AbleToExecute],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarBuffEffectGain",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [11366],
            StringChecks = [ChatStrings.BuffEffectGain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10770],
            StringChecks = [ChatStrings.StellarSilverStarRating],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10771],
            StringChecks = [ChatStrings.StellarGoldStarRating],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10766],
            StringChecks = [ChatStrings.StellarObjectivesComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10822],
            StringChecks = [ChatStrings.StellarTimeLimitExpired],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10769],
            StringChecks = [ChatStrings.StellarReportMission],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10815],
            StringChecks = [ChatStrings.StellarSequentialMissions],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10779],
            StringChecks = [ChatStrings.StellarMissionCompleted],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11197],
            StringChecks = [ChatStrings.StellarGoldCountStreak],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10878],
            StringChecks = [ChatStrings.StellarMissionLogCommittedPlain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = false
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10879],
            StringChecks = [ChatStrings.StellarMissionLogCommitted],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarGpRecovery",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11174],
            StringChecks = [ChatStrings.StellarGpRecoverySelf],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarGpRecovery",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11174],
            StringChecks = [ChatStrings.StellarGpRecoveryOther],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarGpRecovery",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11175],
            StringChecks = [ChatStrings.StellarGpRecovered],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10946],
            StringChecks = [ChatStrings.CordialRecastReset],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11379],
            StringChecks = [ChatStrings.ReconnaissanceDroneLocatedArtifact],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = false
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11383],
            StringChecks = [ChatStrings.ArtifactAppraisalComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = false
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10828],
            StringChecks = [ChatStrings.StellarMissionEvaluationComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10827],
            StringChecks = [ChatStrings.StellarReductionNoItemsLeft],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11200],
            StringChecks = [ChatStrings.StellarMissionGoldCountReset],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowStellarMissionMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11165],
            StringChecks = [ChatStrings.StellarMissionTimeRemaining],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicExplorationMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10830],
            StringChecks = [ChatStrings.MechOpDirective],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = false
        },
        new()
        {
            Name = "ShowCosmicExplorationMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10884, 10881, 10807, 11334, 11335],
            StringChecks = [ChatStrings.CosmicRedAlert],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicExplorationMessages",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10787, 10788, 10789],
            StringChecks = [ChatStrings.CosmicExplorationContribution],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicRewards",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.LootNotice,
            IsActive = true,
            LogMessageIds = [10800],
            StringChecks = [ChatStrings.CosmicFortuneObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicContainers",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.LootNotice,
            IsActive = true,
            LogMessageIds = [10750],
            StringChecks = [ChatStrings.CosmicContainerObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicRewards",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10872],
            StringChecks = [ChatStrings.CosmocreditObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicRewards",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10859],
            StringChecks = [ChatStrings.CosmocreditReceived],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicRewards",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10873],
            StringChecks = [ChatStrings.OizysCreditObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicRewards",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10873],
            StringChecks = [ChatStrings.AuxesiaCreditObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicRewards",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11331],
            StringChecks = [ChatStrings.OizysDronebitsObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = false
        },
        new()
        {
            Name = "ShowCosmicRewards",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10883],
            StringChecks = [ChatStrings.ObtainedSingleItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicClassPointsAndDataset",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10874],
            StringChecks = [ChatStrings.CosmicClassPoints],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicDailyProgress",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10875],
            StringChecks = [ChatStrings.DailyPointsEarned],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicDailyProgress",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [11156],
            StringChecks = [ChatStrings.DailySuccessAchieved],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicDailyProgress",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10877],
            StringChecks = [ChatStrings.DailySuccessGoalAchieved],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicDailyProgress",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10876],
            StringChecks = [ChatStrings.StellarSuccessAchieved],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCosmicClassPointsAndDataset",
            SettingsTab = "Cosmic Exploration",
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [10803],
            StringChecks = [ChatStrings.CosmicDatasetSubmitted],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];
}
