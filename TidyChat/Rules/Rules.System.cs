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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4341],
            StringChecks = [ChatStrings.RetainerVentureComplete],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCompletedVenture",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4331],
            StringChecks = [ChatStrings.RetainerVentureAssign],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCompletedVenture",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4330],
            StringChecks = [ChatStrings.RetainerVentureAssign],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowCompletedVenture",
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [926],
            StringChecks = [ChatStrings.PlayerCommendation],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowInstanceMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1350, 2055, 2056, 2059],
            StringChecks = [ChatStrings.InstancedArea],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowInstanceMessage",
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
            Name = "ShowInstanceMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1530],
            StringChecks = [ChatStrings.GuildhestEnded],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowInstanceMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.InstancedArea],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowInstanceMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.DutyEnded],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowInstanceMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.GuildhestEnded],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowInstanceMessage",
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
            Name = "ShowInstanceMessage",
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
            Name = "ShowInstanceMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
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
        // OnChat fallback when LogMessage handling did not run.
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.PeriodicRecruitmentNotification,
            IsActive = true,
            StringChecks = [ChatStrings.DutyFinderRecruitment],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.DutyFinderPartyType],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [890],
            StringChecks = [ChatStrings.DutyRegistrationWithdrawn],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.DutyRegistrationWithdrawn],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7242],
            StringChecks = [ChatStrings.CairnGlows],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowCairnGlows",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.CairnGlows],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowRestoresLifeToFallen",
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7250],
            RegexChecks = [ChatRegexStrings.AetherpoolIncrease],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowAetherpoolIncrease",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.AetherpoolIncrease],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowAetherpoolUnchanged",
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [7254, 7255, 7256, 7257, 7258, 7259, 7260, 7261, 7264, 7265],
            StringChecks = [ChatStrings.PomanderEffect],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFloorNumber",
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1531, 7249, 7270, 9218],
            RegexChecks = [ChatRegexStrings.FloorNumber],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSenseAccursedHoard",
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3791],
            StringChecks = [ChatStrings.ReadyCheckInitiated],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowReadyChecks",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.ReadyCheck],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowReadyChecks",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.ReadyCheckInitiated],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowSpideySenses",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3240],
            StringChecks = [ChatStrings.HostilePresence],
            Pattern = PatternKind.StringMatch
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
            Name = "ShowSpideySenses",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [5260, 5264, 5255, 5256],
            StringChecks = [ChatStrings.CountdownTime],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowCountdownTime",
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4163]
        },
        new()
        {
            Name = "ShowSubaquaticVoyage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6061, 6057, 6059, 4168]
        },
        new()
        {
            Name = "ShowSubaquaticVoyage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6057],
            StringChecks = [ChatStrings.SubaquaticVoyageEmbarked],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSubaquaticVoyage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6059],
            StringChecks = [ChatStrings.SubaquaticVoyageFinalized],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowSubaquaticVoyage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.SubaquaticVoyageFinalized],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowSubaquaticVoyage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4168],
            StringChecks = [ChatStrings.SubmarinePartRepaired],
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
            Name = "ShowTryOnGlamour",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3911, 4309, 4364, 4378]
        },
        new()
        {
            Name = "ShowTryOnGlamour",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4309],
            StringChecks = [ChatStrings.TryOnGlamourCast],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTryOnGlamour",
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
            Name = "ShowTryOnGlamour",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4378],
            StringChecks = [ChatStrings.TryOnGlamourPartialApply],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowTryOnGlamour",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.TryOnGlamourCast],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowTryOnGlamour",
            SettingsTab = "System",
            Channel = ChatType.System,
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
        },
        new()
        {
            Name = "ShowFreeCompanyMessageBook",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3087, 6065, 3127]
        },
        new()
        {
            Name = "ShowFreeCompanyMessageBook",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3127],
            StringChecks = [ChatStrings.CompanyActionExpired],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        // OnChat fallback when LogMessage handling did not run.
        new()
        {
            Name = "ShowFreeCompanyMessageBook",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            StringChecks = [ChatStrings.CompanyActionExpired],
            Pattern = PatternKind.StringMatch
        },
        new()
        {
            Name = "ShowPersonalMessageBook",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [6066]
        },
        new()
        {
            Name = "BetterCommendationMessage",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [926],
            StringChecks = [ChatStrings.PlayerCommendation],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTradeSent",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [33]
        },
        new()
        {
            Name = "ShowTradeCanceled",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [36]
        },
        new()
        {
            Name = "ShowAwaitingTradeConfirmation",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [32]
        },
        new()
        {
            Name = "ShowNowLeaderOf",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [15, 16, 23, 24, 367, 383, 9284, 9285, 9289, 9290, 9291, 9298]
        },
        new()
        {
            Name = "ShowFirstClearAward",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4225],
            StringChecks = [ChatStrings.FirstClearBonus],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowFirstClearAward",
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4225],
            RegexChecks = [ChatRegexStrings.PartyMemberFirstClear],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowSecondChanceAward",
            SettingsTab = "System",
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
            SettingsTab = "System",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [38]
        }
    ];
}
