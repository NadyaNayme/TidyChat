namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] ObtainRules =
    [
        new()
        {
            Name = "ShowObtainedQuestItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            LogMessageIds = [1232],
            StringChecks = [ChatStrings.QuestItemObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            LogMessageIds = [1606],
            StringChecks = [ChatStrings.ObtainedSingleItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [743],
            StringChecks = [ChatStrings.ItemBoundToYou],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            LogMessageIds = [1607],
            StringChecks = [ChatStrings.ObtainedItemQuantity],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3617],
            StringChecks = [ChatStrings.ObtainedGearPiece],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            LogMessageIds = [750, 3208],
            StringChecks = [ChatStrings.ObtainedSingleItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3208],
            StringChecks = [ChatStrings.ObtainedSingleItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            LogMessageIds = [751],
            StringChecks = [ChatStrings.ObtainedItemQuantity],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowInventoryItemAdded",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [789],
            StringChecks = [ChatStrings.InventoryItemAdded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideInventoryItemAdded",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.System,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [789],
            StringChecks = [ChatStrings.InventoryItemAdded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [720],
            StringChecks = [ChatStrings.DiscardedItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideRouletteBonus",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2246]
        },
        new()
        {
            Name = "HideAdventurerInNeedBonus",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2244]
        },
        new()
        {
            Name = "HideObtainedGil",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1605, 1258, 1417],
            StringChecks = [ChatStrings.ObtainedGilMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideObtainedGil",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainedGilMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerGil = true
        },
        new()
        {
            Name = "HideObtainedGil",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.System,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1798, 10923],
            StringChecks = [ChatStrings.ReceivedGilMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideObtainedWolfMarks",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainWolfMarks],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerItemId = ItemMarkerCatalog.Items.WolfMarks
        },
        new()
        {
            Name = "HideObtainedSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1300],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnySeal = true
        },
        new()
        {
            Name = "HideObtainedSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnySeal = true
        },
        new()
        {
            Name = "HideObtainedVenture",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainVentureMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerItemId = ItemMarkerCatalog.Items.Venture
        },
        new()
        {
            Name = "HideObtainedTribalCurrency",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyTribal = true
        },
        new()
        {
            Name = "HideObtainedClusters",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainClusterMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true,
            ObtainMarkerClustersOnly = true
        },
        new()
        {
            Name = "HideObtainedAlliedSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainAlliedSealsMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerItemId = ItemMarkerCatalog.Items.AlliedSeals
        },
        new()
        {
            Name = "HideObtainedCenturioSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainCenturioSealsMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerItemId = ItemMarkerCatalog.Items.CenturioSeals
        },
        new()
        {
            Name = "HideObtainedNuts",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainNutsMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerItemId = ItemMarkerCatalog.Items.Nuts
        },
        new()
        {
            Name = "HideObtainedMaterials",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainMaterialsMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerMaterials = true
        },
    ];
}
