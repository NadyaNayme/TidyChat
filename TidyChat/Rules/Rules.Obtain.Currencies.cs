namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] ObtainCurrenciesItemRules =
    [
        new()
        {
            Name = "ShowObtainedQuestItems",
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [743],
            StringChecks = [ChatStrings.ItemBoundToYou],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowObtainedItems",
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [720],
            StringChecks = [ChatStrings.DiscardedItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] ObtainCurrenciesGilHideRules =
    [
        new()
        {
            Name = "HideObtainedGil",
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainVentureMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerItemId = ItemMarkerCatalog.Items.Venture
        },
    ];

    private static readonly LocalizedFilterRule[] ObtainCurrenciesMarkerHideRules =
    [
        new()
        {
            Name = "HideObtainedAlliedSeals",
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
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
            SettingsTab = "Currencies",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainNutsMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerItemId = ItemMarkerCatalog.Items.Nuts
        },
    ];

    private static readonly LocalizedFilterRule[] ObtainCurrenciesTomestoneHideRules =
    [
        new()
        {
            Name = "HideTomestoneWeeklyCap",
            SettingsTab = "Currencies",
            Channel = ChatType.Error,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [2174],
            RegexChecks = [ChatStrings.TomestoneWeeklyCap],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        }
    ];
}