namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] CraftingRules =
    [
        new()
        {
            Name = "ShowAttachedMateria",
            SettingsTab = "Materia",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1201],
            StringChecks = [ChatStrings.MateriaAttach],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowOvermeldFailure",
            SettingsTab = "Materia",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1202],
            StringChecks = [ChatStrings.MateriaOvermeldFailure],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMateriaExtract",
            SettingsTab = "Materia",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1200],
            StringChecks = [ChatStrings.MateriaExtract],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTrialMessages",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [5902, 5904, 5906, 5907, 5908],
            StringChecks = [ChatStrings.TrialSynthesis],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowOtherSynthesis",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1156],
            StringChecks = [ChatStrings.OtherSynthesis],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCraftingSynthesisComplete",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1156, 1157, 1158],
            StringChecks = [ChatStrings.SynthesisComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCraftingSynthesisComplete",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1178],
            StringChecks = [ChatStrings.CraftingLogProof],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },

        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1150],
            StringChecks = [ChatStrings.CraftingBeginSynthesizing],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1154, 5912],
            StringChecks = [ChatStrings.CraftingAbilitySuccess],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1162],
            StringChecks = [ChatStrings.CraftingProgressIncrease],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1164],
            StringChecks = [ChatStrings.CraftingQualityIncrease],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1167],
            StringChecks = [ChatStrings.CraftingDurabilityDecrease],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1168, 1169]
        },
        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1168],
            StringChecks = [ChatStrings.CraftingMaterialRemoved],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [1169],
            StringChecks = [ChatStrings.CraftingRemoveFromBagHeader],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "AlwaysShowCraftingErrors",
            SettingsTab = "Crafting",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [1147],
            StringChecks = [ChatStrings.UnableToCraft],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [5918],
            StringChecks = [ChatStrings.CraftingDurabilityRestored],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCraftingBuffEffectGain",
            SettingsTab = "Crafting",
            Channel = ChatType.GainBuff,
            IsActive = true,
            LogMessageIds = [603],
            StringChecks = [ChatStrings.BuffEffectGain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCraftingAbleToExecute",
            SettingsTab = "Crafting",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [5533],
            StringChecks = [ChatStrings.AbleToExecute],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMateriaRetrieved",
            SettingsTab = "Materia",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1953, 1954]
        },
        new()
        {
            Name = "ShowMateriaRetrieved",
            SettingsTab = "Materia",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1953],
            StringChecks = [ChatStrings.MateriaAttemptRemove],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMateriaRetrieved",
            SettingsTab = "Materia",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1954],
            StringChecks = [ChatStrings.MateriaRetrieved],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMateriaShatters",
            SettingsTab = "Materia",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1955]
        },
        new()
        {
            Name = "ShowMateriaShatters",
            SettingsTab = "Materia",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1955],
            StringChecks = [ChatStrings.MateriaShatters],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
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
        }
    ];
}
