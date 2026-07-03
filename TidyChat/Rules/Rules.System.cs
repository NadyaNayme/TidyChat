namespace TidyChat;

public static partial class Rules
{
    // AddSystemRules preserves evaluation order (see CreateRules).

    private static readonly LocalizedFilterRule[] SystemDutyStatusRules =
    [
        new()
        {
            Name = "ShowDutyEndedMessage",
            SettingsTab = "Duty",
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
            SettingsTab = "Duty",
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
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [619],
            StringChecks = [ChatStrings.LevelNoLongerSynced],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] SystemRelicAndStatusRules =
    [
        new()
        {
            Name = "ShowRelicBookStep",
            SettingsTab = "Progress",
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
            SettingsTab = "Progress",
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

    private static readonly LocalizedFilterRule[] SystemFriendListRules =
    [
        new()
        {
            Name = "ShowFriendListMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10, 78, 81, 7487],
            Pattern = PatternKind.None,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFriendListMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [10, 7487],
            RegexChecks = [ChatStrings.FriendRequestSentRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFriendListMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [78],
            RegexChecks = [ChatStrings.FriendListAddedRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFriendListMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [81],
            StringChecks = [ChatStrings.FriendListUpdated],
            Pattern = PatternKind.StringMatch,
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
            Name = "ShowPlaytime",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [859],
            Pattern = PatternKind.None,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPlaytime",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [859],
            StringChecks = [ChatStrings.TotalPlayTime],
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
        rules.AddRange(DungeonMechanicRules);
        rules.AddRange(HousingRules);
        rules.AddRange(ExplorationQuestReminderRules);
        rules.AddRange(PartySocialRules);
        rules.AddRange(PartyCountdownRules);
        rules.AddRange(PartyReadyCheckRules);
        rules.AddRange(ExplorationHuntSlainRules);
        rules.AddRange(ExplorationHuntMarkBillRules);
        rules.AddRange(SystemRelicAndStatusRules);
        rules.AddRange(DesynthesisRules);
        rules.AddRange(DutyFinderRules);
        rules.AddRange(DeepDungeonRules);
        rules.AddRange(ExplorationDiscoveryRules);
        rules.AddRange(GlamourSpiritboundRules);
        rules.AddRange(ExplorationVistaRules);
        rules.AddRange(GlamourDresserRules);
        rules.AddRange(SystemMessageBookRules);
        rules.AddRange(EconomyTradeStatusRules);
        rules.AddRange(ProgressAwardRules);
        rules.AddRange(EconomyTradeCompleteRules);
        rules.AddRange(PartyTeleportRules);
        rules.AddRange(EconomyMarketBoardRules);
        rules.AddRange(EconomyRetainerRules);
        rules.AddRange(GlamourGearsetAndJobRules);
        rules.AddRange(SystemVolumeControlRules);
        rules.AddRange(SystemFriendListRules);
        rules.AddRange(SystemUtilityRules);
    }
}
