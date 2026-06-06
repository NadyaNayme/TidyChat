namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] GatheringAetherialReductionRules =
    [
        new()
        {
            Name = "ShowAetherialReductionSands",
            SettingsTab = "Gathering",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3555],
            StringChecks = [ChatStrings.AetherialReductionSands],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherialReductionSuccess",
            SettingsTab = "Gathering",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3553],
            StringChecks = [ChatStrings.AetherialReductionSuccess],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherialReductionMinigame",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [5514, 5516, 5573, 5574, 5550, 3549, 3569]
        },
        new()
        {
            Name = "ShowAetherialReductionMinigame",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [5514, 5516, 5573, 5574, 5550, 3549, 3569],
            StringChecks = [ChatStrings.AetherialReductionIntegrity],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherialReductionMinigame",
            SettingsTab = "Gathering",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [5550],
            StringChecks = [ChatStrings.CollectabilityLocationBonus],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherialReductionMinigame",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3549],
            StringChecks = [ChatStrings.BrazenWoodsman],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherialReductionMinigame",
            SettingsTab = "Gathering",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [3569],
            StringChecks = [ChatStrings.MeticulousWoodsman],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherialReductionMinigame",
            SettingsTab = "Gathering",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3563],
            StringChecks = [ChatStrings.AetherialReductionDoubleBonus],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];
}