namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] PartyRulesSegment0 =
    [
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
    ];

    private static readonly LocalizedFilterRule[] PartyRulesSegment1 =
    [
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
            Channel = ChatType.Progress,
            IsActive = true,
            LogMessageIds = [4680],
            StringChecks = [ChatStrings.DutyFinderMinimumIlActive],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4681],
            StringChecks = [ChatStrings.DutyFinderRegistrationLanguage],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowDutyFinder",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4682],
            StringChecks = [ChatStrings.DutyFinderLanguageSet],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
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
            Channel = ChatType.Error,
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
            Channel = ChatType.Error,
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
    ];

    private static readonly LocalizedFilterRule[] PartyRulesSegment2 =
    [
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
                    ];

    private static readonly LocalizedFilterRule[] PartyRulesSegment3 =
    [
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
            ];

    private static readonly LocalizedFilterRule[] PartyRulesSegment4 =
    [
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
    ];

    private static readonly LocalizedFilterRule[] PartyRulesSegment5 =
    [
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
    ];

    private static readonly LocalizedFilterRule[] PartyRulesSegment6 =
    [
        new()
        {
            Name = "ShowNowLeaderOf",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [15, 16, 23, 24, 367, 383, 9284, 9285, 9289, 9290, 9291, 9298]
        },
    ];

    private static readonly LocalizedFilterRule[] PartyRulesSegment7 =
    [
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
    ];

    private static readonly LocalizedFilterRule[] PartyRulesSegment8 =
    [
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
    ];

}
