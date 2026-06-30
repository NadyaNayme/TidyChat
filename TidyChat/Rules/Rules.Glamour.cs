namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] GlamourSpiritboundRules =
    [
        new()
        {
            Name = "ShowSpiritboundGear",
            SettingsTab = "Materia",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [744],
            StringChecks = [ChatStrings.SpiritboundGear],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] GlamourDresserRules =
    [
        new()
        {
            Name = "ShowGlamourDresserOutfit",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4529],
            StringChecks = [ChatStrings.GlamourOutfitStored],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGlamourDresserOutfit",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GlamourOutfitStored],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGlamourDresserOutfit",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GlamourOutfitInto],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGlamourDresserProjection",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4380, 4534],
            StringChecks = [ChatStrings.GlamourDresserProjectionAdded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGlamourDresserProjection",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4381],
            StringChecks = [ChatStrings.GlamourDresserProjectionRemoved],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGlamourDresserProjection",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4383],
            StringChecks = [ChatStrings.GlamourDresserProjectionRestored],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGlamourDresserProjection",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GlamourDresserProjection],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGlamourArmoireMessages",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [624],
            StringChecks = [ChatStrings.GlamourArmoireStore],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGlamourArmoireMessages",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [625],
            StringChecks = [ChatStrings.GlamourArmoireWithdraw],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTryOnGlamourPreview",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3911],
            StringChecks = [ChatStrings.TryOnGlamourPreview],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGearDyeApplied",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10508],
            StringChecks = [ChatStrings.GearDyeApplied],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTryOnGlamourCast",
            SettingsTab = "Glamour",
            Channel = ChatType.GlamourNotifications,
            IsActive = true,
            LogMessageIds = [4309],
            StringChecks = [ChatStrings.TryOnGlamourCast],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGlamourPlateProjected",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4364],
            StringChecks = [ChatStrings.GlamourPlateProjected],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGlamourPlatePartialApply",
            SettingsTab = "Glamour",
            Channel = ChatType.Error,
            IsActive = true,
            LogMessageIds = [4378],
            StringChecks = [ChatStrings.TryOnGlamourPartialApply],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGearsetGlamourRestoreFailed",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1900],
            StringChecks = [ChatStrings.GearsetGlamourRestoreFailed],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGlamourPlateProjected",
            SettingsTab = "Glamour",
            Channel = ChatType.GlamourNotifications,
            IsActive = true,
            StringChecks = [ChatStrings.GlamourPlateProjected],
            Pattern = PatternKind.StringMatch
        }
    ];

    private static readonly LocalizedFilterRule[] GlamourGearsetAndJobRules =
    [
        new()
        {
            Name = "ShowGearsetEquipped",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [700, 755, 788]
        },
        new()
        {
            Name = "ShowGearsetEquipped",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [700, 755],
            StringChecks = [ChatStrings.GearsetEquipped],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGearItemsRepaired",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1385, 1388],
            StringChecks = [ChatStrings.GearItemsRepairedBulk],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowJobChange",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [561],
            RegexChecks = [ChatStrings.JobChangeRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPortraitMessages",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [5865],
            StringChecks = [ChatStrings.PortraitSetInstant],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGearsetEquipped",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [788],
            StringChecks = [ChatStrings.ArmouryChestPlacement],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowJobChange",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [756],
            RegexChecks = [ChatStrings.JobRegisteredRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowJobChange",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1281],
            RegexChecks = [ChatStrings.JobSpecialistChangeRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        }
    ];
}
