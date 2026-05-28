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
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowObtainedQuestItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            StringChecks = [ChatStrings.QuestItemObtain],
            Pattern = PatternKind.StringMatch
        },
        // Dedicated obtain/inventory templates (1607/750/751/789/720); not part of SharedObtainTemplateIds or HideObtainedGil (1605).
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
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.System,
            IsActive = true,
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
            Channel = ChatType.LootNotice,
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
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [789],
            StringChecks = [ChatStrings.InventoryItemAdded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        // Inventory discard (720) — no dedicated setting; shares ShowObtainedItems toggle.
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
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            StringChecks = [ChatStrings.ObtainedSingleItem],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            StringChecks = [ChatStrings.ObtainedItemQuantity],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowObtainedItems",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.InventoryItemAdded],
            Pattern = PatternKind.StringMatch
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
        // Dedicated gil obtain templates (1605/1258/1417); shared obtain shapes use marker rule below.
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
        // Shared "You obtain ." templates — require gil marker so items are not blocked.
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
        // OnChat fallback when LogMessage handling did not run for this message.
        new()
        {
            Name = "HideObtainedGil",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedGil],
            Pattern = PatternKind.RegexMatch
        },
        new()
        {
            Name = "HideObtainedMGP",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [4765],
            StringChecks = [ChatStrings.ObtainedMgpMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideObtainedMGP",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainedMgpMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerMgp = true
        },
        // Shared obtain template + Lumina item marker (657 family).
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
            Name = "HideObtainedWolfMarks",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedWolfMarks],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
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
            StringChecks = [ChatStrings.ObtainSealsMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideObtainedSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainSealsMarker],
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
            RegexChecks = [ChatRegexStrings.ObtainedSeals],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
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
            Name = "HideObtainedVenture",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedVenture],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
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
            Name = "HideObtainedTribalCurrency",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedTribalCurrency],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
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
            Name = "HideObtainedClusters",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedClusters],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
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
            Name = "HideObtainedAlliedSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedAlliedSeals],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
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
            Name = "HideObtainedCenturioSeals",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedCenturioSeals],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
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
            Name = "HideObtainedNuts",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedNuts],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
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
        new()
        {
            Name = "HideObtainedMaterials",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedMaterials],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerMaterials = true
        },
        new()
        {
            Name = "HideObtainedShardsFromLoot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true
        },
        new()
        {
            Name = "HideObtainedShardsFromLoot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.ObtainedShards],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            ObtainMarkerAnyElemental = true
        },
        new()
        {
            Name = "HideObtainedShardsFromLoot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1233],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true,
            ObtainMarkerRequireSharedTemplate = false
        },
        new()
        {
            Name = "HideObtainedShardsFromLoot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [1233],
            RegexChecks = [ChatRegexStrings.ObtainedShards],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerAnyElemental = true,
            ObtainMarkerRequireSharedTemplate = false
        },
        new()
        {
            Name = "HideOthersObtainFromLoot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainMaterialsMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerMaterials = true,
            ExcludePlayerObtain = true
        },
        new()
        {
            Name = "HideOthersObtainFromLoot",
            SettingsTab = "Loot/Obtain",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            RegexChecks = [ChatRegexStrings.NotStartWithYou, ChatRegexStrings.ObtainedMaterials],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerMaterials = true,
            ExcludePlayerObtain = true,
            StringChecks = [ChatStrings.ObtainMaterialsMarker]
        }
    ];
}
