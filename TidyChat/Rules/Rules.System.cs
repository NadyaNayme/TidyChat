namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] SystemRules =
    [
        new()
        {
            Name = "ShowSRankHunt",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9331]
        },
        new()
        {
            Name = "ShowSSRankHunt",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [9332]
        },
        new()
        {
            Name = "ShowCompletedVenture",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4341],
            StringChecks = [ChatStrings.RetainerVentureComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowRetainerVentureMessages",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4331],
            StringChecks = [ChatStrings.RetainerVentureAssign],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowRetainerVentureMessages",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4330],
            StringChecks = [ChatStrings.RetainerVentureAssign],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowRetainerVentureMessages",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4334],
            StringChecks = [ChatStrings.RetainerVenturePayment],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCompletedVenture",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4332],
            StringChecks = [ChatStrings.RetainerVentureItemComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCompletedVenture",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4335],
            StringChecks = [ChatStrings.RetainerMaxLevel],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCommendations",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [926],
            StringChecks = [ChatStrings.PlayerCommendation],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowInstancedAreaMessages",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1350, 2055, 2056, 2059],
            StringChecks = [ChatStrings.InstancedArea],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
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
            Name = "ShowInstancedAreaMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.InstancedArea],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowDutyEndedMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.DutyEnded],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGuildhestEndedMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GuildhestEnded],
            Pattern = PatternKind.StringMatch
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [732, 733],
            StringChecks = [ChatStrings.SanctuaryMessage],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSanctuaryMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.SanctuaryMessage],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowHousingWardMessage",
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.SayQuestReminder],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowInviteSent",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1],
            StringChecks = [ChatStrings.InviteSent],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowInviteeJoins",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [60],
            StringChecks = [ChatStrings.InviteeJoins],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLeftParty",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4, 69],
            StringChecks = [ChatStrings.LeftParty],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPartyDisband",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [73],
            StringChecks = [ChatStrings.PartyDisband],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPartyDissolved",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [72],
            StringChecks = [ChatStrings.PartyDissolved],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPartyDissolved",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7447],
            StringChecks = [ChatStrings.PartyDissolved],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowInvitedBy",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3],
            StringChecks = [ChatStrings.InvitedBy],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowInvitedBy",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1885],
            StringChecks = [ChatStrings.FreeCompanyInviteReceived],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowInvitedBy",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1895],
            StringChecks = [ChatStrings.FreeCompanyInviteCanceled],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowJoinParty",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [61],
            StringChecks = [ChatStrings.JoinParty],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowJoinParty",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7444],
            StringChecks = [ChatStrings.CrossWorldPartyFormed],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.PeriodicRecruitmentNotification,
            IsActive = true,
            LogMessageIds = [94],
            StringChecks = [ChatStrings.DutyFinderRecruitment],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = false
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.PeriodicRecruitmentNotification,
            IsActive = true,
            StringChecks = [ChatStrings.DutyFinderRecruitment],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4670],
            StringChecks = [ChatStrings.DutyFinderParticipation],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4671],
            StringChecks = [ChatStrings.DutyFinderPartyType],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = false
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [897],
            StringChecks = [ChatStrings.DutyRegistrationComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [890],
            StringChecks = [ChatStrings.DutyRegistrationWithdrawn],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.DutyRegistrationWithdrawn],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.Error,
            IsActive = true,
            StringChecks = [ChatStrings.DutyRegistrationWithdrawn],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [902],
            StringChecks = [ChatStrings.PartyMemberDutyWithdrawn],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.PartyMemberDutyWithdrawn],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.Error,
            IsActive = true,
            StringChecks = [ChatStrings.PartyMemberDutyWithdrawn],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4676],
            StringChecks = [ChatStrings.DutyUnrestrictedCommence],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4218],
            StringChecks = [ChatStrings.EchoStrength],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4248],
            StringChecks = [ChatStrings.EnteredUnrestrictedDuty],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [979],
            StringChecks = [ChatStrings.PartyRecruitmentCommenced],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [981],
            StringChecks = [ChatStrings.PartyRecruitmentEnded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowHuntSlain",
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4322, 4323],
            StringChecks = [ChatStrings.DesynthesisObtain],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowObtainedPomander",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7220, 7221, 7222],
            StringChecks = [ChatStrings.ObtainedPomander],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCairnGlows",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7242],
            StringChecks = [ChatStrings.CairnGlows],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCairnGlows",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.CairnGlows],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowRestoresLifeToFallen",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7243],
            StringChecks = [ChatStrings.CairnRestoresLife],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCairnActivates",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7245],
            StringChecks = [ChatStrings.CairnActivates],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTransference",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7246, 7247, 7248],
            StringChecks = [ChatStrings.Transference],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherpoolIncrease",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7250],
            StringChecks = [ChatStrings.AetherpoolIncrease],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherpoolIncrease",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.AetherpoolIncrease],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowAetherpoolUnchanged",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7251],
            StringChecks = [ChatStrings.AetherpoolUnchanged],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowPomanderEffects",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7254, 7255, 7256, 7257, 7258, 7259, 7260, 7261, 7263, 7264],
            StringChecks = [ChatStrings.PomanderEffect],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTrapTriggered",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7224, 7225, 7226, 7227, 7228, 7229],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTrapTriggered",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.DeepDungeonLandmineTriggered],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowTrapTriggered",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.DeepDungeonTrapTriggered],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowTrapTriggered",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.DeepDungeonDetonatorTriggered],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowFloorNumber",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7249],
            StringChecks = [ChatStrings.DeepDungeonIndependentLeveling],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFloorNumber",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7270, 9218],
            StringChecks = [ChatStrings.FloorNumber],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFloorNumber",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7265],
            StringChecks = [ChatStrings.FloorNumber],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFloorNumber",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7249, 7270, 9218, 7265],
            RegexChecks = [ChatRegexStrings.FloorNumber],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSenseAccursedHoard",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7272],
            StringChecks = [ChatStrings.SenseAccursedHoard],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDoNotSenseAccursedHoard",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7273],
            StringChecks = [ChatStrings.NoAccursedHoard],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDiscoverAccursedHoard",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7274],
            StringChecks = [ChatStrings.DiscoverAccursedHoard],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowReadyChecks",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3790, 3794],
            StringChecks = [ChatStrings.ReadyCheck],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowReadyChecks",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3791],
            StringChecks = [ChatStrings.ReadyCheckInitiated],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowReadyChecks",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.ReadyCheck],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowReadyChecks",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.ReadyCheckInitiated],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowHostilePresence",
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2600, 4791],
            StringChecks = [ChatStrings.SpideySenses],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowLocationDiscovered",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [88],
            StringChecks = [ChatStrings.LocationDiscovered],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSpideySenses",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2600, 4791],
            RegexChecks = [ChatRegexStrings.SpideySenses],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowAetherCompass",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3712],
            StringChecks = [ChatStrings.AetherCompass],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCountdownTime",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [5260, 5264, 5255, 5256],
            StringChecks = [ChatStrings.CountdownTime],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCountdownTime",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.CountdownTime],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowSpiritboundGear",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [744],
            StringChecks = [ChatStrings.SpiritboundGear],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowExploratoryVoyage",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4163]
        },
        new()
        {
            Name = "ShowSubaquaticVoyageEmbarked",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6057],
            StringChecks = [ChatStrings.SubaquaticVoyageEmbarked],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSubaquaticVoyageFinalized",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6059],
            StringChecks = [ChatStrings.SubaquaticVoyageFinalized],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSubaquaticVoyageOtherFinalized",
            SettingsTab = "Party",
            Channel = ChatType.FreeCompanyAnnouncement,
            IsActive = true,
            LogMessageIds = [6060],
            StringChecks = [ChatStrings.SubaquaticVoyageFinalized],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSubaquaticVoyageFinalized",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.SubaquaticVoyageFinalized],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowSubaquaticVoyageReturned",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6061]
        },
        new()
        {
            Name = "ShowSubmarinePartRepaired",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4168],
            StringChecks = [ChatStrings.SubmarinePartRepaired],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSubmarineAttainsRank",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6062],
            StringChecks = [ChatStrings.SubmarineAttainsRank],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSubmarineRetrievalLevelsIncreased",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6092],
            StringChecks = [ChatStrings.SubmarineRetrievalLevelsIncreased],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowVistaMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1272, 1273]
        },
        new()
        {
            Name = "ShowGlamourAltered",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3911]
        },
        new()
        {
            Name = "ShowGearDyeApplied",
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1900],
            StringChecks = [ChatStrings.GearsetGlamourRestoreFailed],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTryOnGlamourCast",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.TryOnGlamourCast],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowTryOnGlamourCast",
            SettingsTab = "System",
            Channel = ChatType.GlamourNotifications,
            IsActive = true,
            StringChecks = [ChatStrings.TryOnGlamourCast],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGlamourPlateProjected",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GlamourPlateProjected],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGlamourPlateProjected",
            SettingsTab = "System",
            Channel = ChatType.GlamourNotifications,
            IsActive = true,
            StringChecks = [ChatStrings.GlamourPlateProjected],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGearsetGlamourRestoreFailed",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GearsetGlamourRestoreFailed],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGearDyeApplied",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GearDyeApplied],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowEligibleForCoffers",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4233, 4238, 4246]
        },
        new()
        {
            Name = "ShowFreeCompanyMessageBook",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3087, 6065, 3127]
        },
        new()
        {
            Name = "ShowFreeCompanyMessageBook",
            SettingsTab = "Party",
            Channel = ChatType.FreeCompanyAnnouncement,
            IsActive = true,
            LogMessageIds = [3127],
            StringChecks = [ChatStrings.CompanyActionExpired],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFreeCompanyMessageBook",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.CompanyActionExpired],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowPersonalMessageBook",
            SettingsTab = "System",
            Channel = ChatType.MessageBook,
            IsActive = true,
            LogMessageIds = [6066]
        },
        new()
        {
            Name = "ShowTradeSent",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [33]
        },
        new()
        {
            Name = "ShowTradeCanceled",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [36]
        },
        new()
        {
            Name = "ShowAwaitingTradeConfirmation",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [32]
        },
        new()
        {
            Name = "ShowNowLeaderOf",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [15, 16, 23, 24, 367, 383, 9284, 9285, 9289, 9290, 9291, 9298]
        },
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
        },
        new()
        {
            Name = "ShowTradeComplete",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [38]
        },
        new()
        {
            Name = "ShowOfferedTeleport",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [440],
            StringChecks = [ChatStrings.OfferedTeleport],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMarketBoardSellingStatus",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [398],
            StringChecks = [ChatStrings.MarketBoardStartSelling],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMarketBoardSellingStatus",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [399],
            StringChecks = [ChatStrings.MarketBoardStopSelling],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMarketItemSold",
            SettingsTab = "Economy",
            Channel = ChatType.RetainerSale,
            IsActive = true,
            LogMessageIds = [748],
            StringChecks = [ChatStrings.MarketItemSold],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMarketAllItemsSold",
            SettingsTab = "Economy",
            Channel = ChatType.RetainerSale,
            IsActive = true,
            LogMessageIds = [384],
            StringChecks = [ChatStrings.MarketAllItemsSold],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowMarketGilEntrustedToRetainer",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4578],
            StringChecks = [ChatStrings.MarketGilEntrustedToRetainer],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowVendorSellMessages",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1688],
            StringChecks = [ChatStrings.VendorSellForGil],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowVendorPurchaseMessages",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [734],
            StringChecks = [ChatStrings.VendorPurchase],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowVendorPurchaseMessages",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1687],
            StringChecks = [ChatStrings.VendorPurchaseForGil],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGilSpentMessage",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4590],
            StringChecks = [ChatStrings.GilSpent],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGilWithdrawnMessage",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [736],
            StringChecks = [ChatStrings.GilSafelyWithdrawn],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGearsetEquipped",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [700, 755, 788]
        },
        new()
        {
            Name = "ShowGearsetEquipped",
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1385, 1388],
            StringChecks = [ChatStrings.GearItemsRepairedBulk],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGearItemsRepaired",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GearItemsRepairedBulk],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGearItemsRepaired",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GearItemRepairedSingle],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowJobChange",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [561, 756, 1281]
        },
        new()
        {
            Name = "ShowJobChange",
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [5865]
        },
        new()
        {
            Name = "ShowPortraitMessages",
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GearsetEquipped],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowJobChange",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.JobChange],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowJobChange",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.JobRegistered],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowJobChange",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.JobSpecialistChange],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowPortraitMessages",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.PortraitSetInstant],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowGearsetEquipped",
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1281],
            StringChecks = [ChatStrings.JobSpecialistChange],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowVolumeControlMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3860, 3861, 3862, 3863, 3864, 3865, 3866]
        },
        new()
        {
            Name = "ShowSealedOff",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2012, 2013, 2014]
        },
        new()
        {
            Name = "ShowSealedOff",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [2012, 2013, 2014],
            StringChecks = [ChatStrings.SealedOff],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
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
            LogMessageIds = [1629, 1630, 1631],
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
            LogMessageIds = [1629, 1630, 1631],
            RegexChecks = [ChatRegexStrings.ItemSearchCommand],
            Pattern = PatternKind.RegexMatch,
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
            RegexChecks = [ChatRegexStrings.SearchForItemResults],
            Pattern = PatternKind.RegexMatch,
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
            Name = "ShowAetheryteTicket",
            SettingsTab = "System",
            Channel = ChatType.Item,
            IsActive = true,
            StringChecks = [ChatStrings.AetheryteTicketReady],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowAetheryteTicket",
            SettingsTab = "System",
            Channel = ChatType.Item,
            IsActive = true,
            StringChecks = [ChatStrings.AetheryteTicketUsed],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowAetheryteTicket",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.AetheryteTicketUsed],
            Pattern = PatternKind.StringMatch
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
            Name = "ShowTripleTriadAllowed",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4763],
            StringChecks = [ChatStrings.TripleTriadAllowed],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTripleTriadNotAllowed",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4764],
            StringChecks = [ChatStrings.TripleTriadNotAllowed],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowChangesDiscarded",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.ChangesDiscarded],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowChangesLost",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.ChangesLost],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowTripleTriadAllowed",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.TripleTriadAllowed],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowTripleTriadNotAllowed",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.TripleTriadNotAllowed],
            Pattern = PatternKind.StringMatch
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
}
