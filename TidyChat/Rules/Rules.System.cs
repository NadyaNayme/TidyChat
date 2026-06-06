namespace TidyChat;

public static partial class Rules
{
    // AddSystemRules preserves evaluation order (see CreateRules).

    private static readonly LocalizedFilterRule[] SystemDutyStatusRules =
    [
        new()
        {
            Name = "ShowDutyEndedMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1534],
            StringChecks = [ChatStrings.DutyEnded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGuildhestEndedMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1530],
            StringChecks = [ChatStrings.GuildhestEnded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLevelNoLongerSynced",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [619],
            StringChecks = [ChatStrings.LevelNoLongerSynced],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyMechanicMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [605],
            StringChecks = [ChatStrings.DutyMechanicEvent],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyMechanicMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2119],
            StringChecks = [ChatStrings.DutyMechanicCalmPocket],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyObjectiveBonus",
            SettingsTab = "System",
            Channel = ChatType.LootNotice,
            IsActive = true,
            LogMessageIds = [2163],
            StringChecks = [ChatStrings.DutyObjectiveBonus],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] SystemRelicAndStatusRules =
    [
        new()
        {
            Name = "ShowRelicBookStep",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4402],
            StringChecks = [ChatStrings.RelicBookStep],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowRelicBookComplete",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4400],
            StringChecks = [ChatStrings.RelicBookComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowOnlineStatus",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [97]
        },
        new()
        {
            Name = "ShowAttachToMail",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [672, 673]
        }
    ];

    private static readonly LocalizedFilterRule[] SystemEligibleForCoffersRules =
    [
        new()
        {
            Name = "ShowEligibleForCoffers",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4233, 4238, 4246]
        }
    ];

    private static readonly LocalizedFilterRule[] SystemMessageBookRules =
    [
        new()
        {
            Name = "ShowPersonalMessageBook",
            SettingsTab = "System",
            Channel = ChatType.MessageBook,
            IsActive = true,
            LogMessageIds = [6066]
        }
    ];

    private static readonly LocalizedFilterRule[] SystemVolumeControlRules =
    [
        // Always shown when System filtering is on — no user toggle.,
        new()
        {
            Name = "ShowVolumeControlMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3860, 3861, 3862, 3863, 3864, 3865, 3866],
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] SystemUtilityRules =
    [
        new()
        {
            Name = "ShowItemSearchResults",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1629, 1630, 1631]
        },
        new()
        {
            Name = "ShowItemSearchResults",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1629, 1630],
            StringChecks = [ChatStrings.ItemSearchResults],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowItemSearchResults",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1631],
            StringChecks = [ChatStrings.ItemSearchResultLine],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLocationSearchResults",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds =
            [
                1438, 1439, 1440, 1441, 1442, 1443, 1444, 1445, 1446, 1447, 1448, 1449,
                1450, 1451, 1452, 1453
            ]
        },
        new()
        {
            Name = "ShowLocationSearchResults",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds =
            [
                1438, 1439, 1440, 1441, 1442, 1443, 1444, 1445, 1446, 1447, 1448, 1449,
                1450, 1451, 1452, 1453
            ],
            StringChecks = [ChatStrings.LocationSearchStowage],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLocationSearchResults",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds =
            [
                1438, 1439, 1440, 1441, 1442, 1443, 1444, 1445, 1446, 1447, 1448, 1449,
                1450, 1451, 1452, 1453
            ],
            StringChecks = [ChatStrings.LocationSearchEquipped],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLocationSearchResults",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds =
            [
                1438, 1439, 1440, 1441, 1442, 1443, 1444, 1445, 1446, 1447, 1448, 1449,
                1450, 1451, 1452, 1453
            ],
            StringChecks = [ChatStrings.LocationSearchTotal],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetheryteTicket",
            SettingsTab = "System",
            Channel = ChatType.Item,
            IsActive = true,
            LogMessageIds = [503],
            StringChecks = [ChatStrings.AetheryteTicketReady],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetheryteTicket",
            SettingsTab = "System",
            Channel = ChatType.Item,
            IsActive = true,
            LogMessageIds = [535],
            StringChecks = [ChatStrings.AetheryteTicketUsed],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetheryteTicket",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4591],
            StringChecks = [ChatStrings.AetheryteTicketUsed],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAttuneAetheryte",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1341],
            StringChecks = [ChatStrings.AttuneAetheryte],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowChangesDiscarded",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4242],
            StringChecks = [ChatStrings.ChangesDiscarded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowChangesLost",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [802],
            StringChecks = [ChatStrings.ChangesLost],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "BetterNoviceNetworkMessage",
            SettingsTab = "System",
            Channel = ChatType.NoviceNetworkSystem,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [7025]
        },
        new()
        {
            Name = "BetterNoviceNetworkMessage",
            SettingsTab = "System",
            Channel = ChatType.NoviceNetworkSystem,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [7011, 7027]
        },
        new()
        {
            Name = "BetterNoviceNetworkMessage",
            SettingsTab = "System",
            Channel = ChatType.NoviceNetworkSystem,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [7030]
        }
    ];

    private static void AddSystemRules(List<LocalizedFilterRule> rules)
    {
        rules.AddRange(ExplorationHuntRankRules);
        rules.AddRange(PartyRulesIntro);
        rules.AddRange(SystemDutyStatusRules);
        rules.AddRange(HousingRules);
        rules.AddRange(ExplorationQuestReminderRules);
        rules.AddRange(PartySocialRules);
        rules.AddRange(ExplorationHuntSlainRules);
        rules.AddRange(ExplorationHuntMarkBillRules);
        rules.AddRange(SystemRelicAndStatusRules);
        rules.AddRange(DesynthesisRules);
        rules.AddRange(DutyFinderRules);
        rules.AddRange(DeepDungeonRules);
        rules.AddRange(PartyReadyCheckRules);
        rules.AddRange(ExplorationDiscoveryRules);
        rules.AddRange(PartyCountdownRules);
        rules.AddRange(GlamourSpiritboundRules);
        rules.AddRange(ExplorationVistaRules);
        rules.AddRange(GlamourDresserRules);
        rules.AddRange(SystemEligibleForCoffersRules);
        rules.AddRange(SystemMessageBookRules);
        rules.AddRange(EconomyTradeStatusRules);
        rules.AddRange(PartyLeadershipRules);
        rules.AddRange(ProgressAwardRules);
        rules.AddRange(EconomyTradeCompleteRules);
        rules.AddRange(PartyTeleportRules);
        rules.AddRange(EconomyMarketBoardRules);
        rules.AddRange(EconomyRetainerRules);
        rules.AddRange(GlamourGearsetAndJobRules);
        rules.AddRange(SystemVolumeControlRules);
        rules.AddRange(PartySealedOffRules);
        rules.AddRange(SystemUtilityRules);
    }
}
