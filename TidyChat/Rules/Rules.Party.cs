namespace TidyChat;

public static partial class Rules
{
    // Rule groups below are interleaved into SystemRules (see Rules.System.cs) to preserve evaluation order.

    private static readonly LocalizedFilterRule[] PartyRulesIntro =
    [
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
            SettingsTab = "Duty",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [1350, 2055, 2056, 2059],
            StringChecks = [ChatStrings.InstancedArea],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];


    private static readonly LocalizedFilterRule[] PartySocialRules =
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
        }
    ];

    private static readonly LocalizedFilterRule[] PartyCountdownRules =
    [
        new()
        {
            Name = "ShowPartyCountdown",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [5255, 5256, 5260, 5261, 5264],
            Pattern = PatternKind.None,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] PartyReadyCheckRules =
    [
        new()
        {
            Name = "ShowReadyCheckMessages",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3790, 3791, 3794],
            Pattern = PatternKind.None,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowReadyCheckMessages",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3790],
            RegexChecks = [ChatStrings.ReadyCheckCommencedRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowReadyCheckMessages",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3791],
            RegexChecks = [ChatStrings.ReadyCheckInitiatedRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowReadyCheckMessages",
            SettingsTab = "Party",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [3794],
            RegexChecks = [ChatStrings.ReadyCheckCompleteRegex],
            Pattern = PatternKind.RegexMatch,
            PreferLogMessageCatalog = true
        }
    ];

    private static readonly LocalizedFilterRule[] PartyTeleportRules =
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
        }
    ];
}
