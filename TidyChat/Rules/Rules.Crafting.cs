namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] CraftingMessageRules =
    [
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
        }
    ];
}
