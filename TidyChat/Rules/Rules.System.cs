namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] SystemRulesSegment0 =
    [
        new()
        {
            Name = "ShowSRankHunt",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9331]
        },
        new()
        {
            Name = "ShowSSRankHunt",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9332]
        }
    ];

    private static readonly LocalizedFilterRule[] SystemRulesSegment1 =
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
        },
        new()
        {
            Name = "ShowSanctuaryMessage",
            SettingsTab = "Housing",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [732, 733],
            StringChecks = [ChatStrings.SanctuaryMessage],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowHousingWardMessage",
            SettingsTab = "Housing",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3379],
            StringChecks = [ChatStrings.HousingWardMessage],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowQuestReminder",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.SayQuestReminder],
            Pattern = PatternKind.StringMatch
        }
    ];

    private static readonly LocalizedFilterRule[] SystemRulesSegment2 =
    [
        new()
        {
            Name = "ShowHuntSlain",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4411]
        },
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
        },
        new()
        {
            Name = "ShowDesynthedItem",
            SettingsTab = "Desynthesis",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4321],
            StringChecks = [ChatStrings.DesynthedItem],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDesynthesisObtains",
            SettingsTab = "Desynthesis",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4322, 4323],
            StringChecks = [ChatStrings.DesynthesisObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] SystemRulesSegment3 =
    [
        new()
        {
            Name = "ShowHostilePresence",
            SettingsTab = "Exploration",
            Channel = ChatType.BattleSystem,
            IsActive = true,
            LogMessageIds = [3240],
            StringChecks = [ChatStrings.HostilePresence],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSpideySenses",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2600],
            StringChecks = [ChatStrings.SpideySenses],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLocationDiscovered",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [88],
            StringChecks = [ChatStrings.LocationDiscovered],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherCompass",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3712],
            StringChecks = [ChatStrings.AetherCompass],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] SystemRulesSegment4 =
    [
        new()
        {
            Name = "ShowSpiritboundGear",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [744],
            StringChecks = [ChatStrings.SpiritboundGear],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] SystemRulesSegment5 =
    [
        new()
        {
            Name = "ShowVistaMessages",
            SettingsTab = "Exploration",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1272, 1273]
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
            LogMessageIds = [4380],
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
        },
        new()
        {
            Name = "ShowEligibleForCoffers",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4233, 4238, 4246]
        }
    ];

    private static readonly LocalizedFilterRule[] SystemRulesSegment6 =
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

    private static readonly LocalizedFilterRule[] SystemRulesSegment7 =
    [
        new()
        {
            Name = "ShowFirstClearAward",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4225],
            StringChecks = [ChatStrings.FirstClearBonus],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSecondChanceAward",
            SettingsTab = "Progress",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7975],
            StringChecks = [ChatStrings.SecondChanceAward],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] SystemRulesSegment8 =
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
            SettingsTab = "Glamour",
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
            StringChecks = [ChatStrings.JobChange],
            Pattern = PatternKind.StringMatch,
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
            StringChecks = [ChatStrings.JobRegistered],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowJobChange",
            SettingsTab = "Glamour",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1281],
            StringChecks = [ChatStrings.JobSpecialistChange],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
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

    private static readonly LocalizedFilterRule[] SystemRulesSegment9 =
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

    private static readonly LocalizedFilterRule[] SystemRules =
    [
        ..SystemRulesSegment0,
        ..PartyRulesIntro,
        ..SystemRulesSegment1,
        ..PartySocialRules,
        ..SystemRulesSegment2,
        ..DutyMessageRules,
        ..DeepDungeonRules,
        ..PartyReadyCheckRules,
        ..SystemRulesSegment3,
        ..PartyCountdownRules,
        ..SystemRulesSegment4,
        ..SystemRulesSegment5,
        ..SystemRulesSegment6,
        ..EconomyTradeStatusRules,
        ..PartyLeadershipRules,
        ..SystemRulesSegment7,
        ..EconomyTradeCompleteRules,
        ..PartyTeleportRules,
        ..EconomyMarketBoardRules,
        ..EconomyRetainerRules,
        ..SystemRulesSegment8,
        ..PartySealedOffRules,
        ..SystemRulesSegment9
    ];
}
