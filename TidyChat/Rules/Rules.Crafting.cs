namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] CraftingRules =
    [
        new()
        {
            Name = "ShowAttachedMateria",
            SettingsTab = "Crafting",
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
            SettingsTab = "Crafting",
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
            SettingsTab = "Crafting",
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
            StringChecks = [ChatStrings.AbilityUseMessage],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            StringChecks = [ChatStrings.BuffGainEffect],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            StringChecks = [ChatStrings.BuffLossEffect],
            Pattern = PatternKind.StringMatch
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
            StringChecks = [ChatStrings.CraftingMaterialRemoved],
            Pattern = PatternKind.StringMatch
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
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            StringChecks = [ChatStrings.CraftingRemoveFromBagHeader],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            StringChecks = [ChatStrings.UnableToCraft],
            Pattern = PatternKind.StringMatch
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
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [603],
            StringChecks = [ChatStrings.BuffEffectGain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAllOtherCrafting",
            SettingsTab = "Crafting",
            Channel = ChatType.Crafting,
            IsActive = true,
            LogMessageIds = [5533],
            StringChecks = [ChatStrings.AbleToExecute],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
new()
        {
            Name = "ShowMateriaRetrieved",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1953, 1954]
        },
        new()
        {
            Name = "ShowMateriaRetrieved",
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.MateriaAttemptRemove],
            Pattern = PatternKind.StringMatch,
        },
        new()
        {
            Name = "ShowMateriaRetrieved",
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1955]
        },
        new()
        {
            Name = "ShowMateriaShatters",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1955],
            StringChecks = [ChatStrings.MateriaShatters],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            // IDs 1049/1053/1050/1054 = crystal/shard/collectable obtain in the Gathering channel
            // (gathering a collectable item with Collector's Glove before reducing it)
            Name = "ShowAetherialReductionSands",
            SettingsTab = "System",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1049, 1050, 1053, 1054]
        },
        new()
        {
            // ID 3553 = "You successfully reduce <item> (Collectability: N)." (reduction success)
            // ID 3555 = "N <sands> are obtained." (the resulting aethersand)
            Name = "ShowAetherialReductionSands",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3553, 3555]
        },
        new()
        {
            // 5514 = "Your meticulous actions prove effective. Integrity is not reduced."
            // 5516 = "Collectability can be raised no higher."
            // 5573 = "Collector's high standard sharpens your focus. Brazen and meticulous actions are enhanced."
            // All are fixed-text (0 params) GatheringSystem notifications unique to the collectable mini-game.
            Name = "ShowAetherialReductionSands",
            SettingsTab = "System",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [5514, 5516, 5573]
        },
        new()
        {
            Name = "ShowAetherialReductionSands",
            SettingsTab = "System",
            Channel = ChatType.Gathering,
            IsActive = true,
            LogMessageIds = [1049, 1050, 1053, 1054],
            StringChecks = [ChatStrings.AetherialReductionSands],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherialReductionSands",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3553],
            StringChecks = [ChatStrings.AetherialReductionSuccess],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherialReductionSands",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3555],
            StringChecks = [ChatStrings.AetherialReductionSands],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherialReductionSands",
            SettingsTab = "System",
            Channel = ChatType.GatheringSystem,
            IsActive = true,
            LogMessageIds = [5514, 5516, 5573],
            StringChecks = [ChatStrings.AetherialReductionIntegrity],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherialReductionSands",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            RegexChecks = [ChatRegexStrings.AetherialReductionSands],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            LogMessageIds = [3553, 3555, 1049, 1050, 1053, 1054, 5514, 5516, 5573]
        },
    ];
}
