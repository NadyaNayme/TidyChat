namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] GoldSaucerRules =
    [
        new()
        {
            Name = "ShowMgpSpending",
            SettingsTab = "Gold Saucer",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4735],
            StringChecks = [ChatStrings.JumboCactpotTicketPurchase],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideObtainedMGP",
            SettingsTab = "Gold Saucer",
            Channel = ChatType.System,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = [4735],
            StringChecks = [ChatStrings.JumboCactpotTicketPurchase],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "HideObtainedMGP",
            SettingsTab = "Gold Saucer",
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
            SettingsTab = "Gold Saucer",
            Channel = ChatType.LootNotice,
            IsActive = true,
            BlockWhenActive = true,
            LogMessageIds = LogMessageCatalog.SharedObtainTemplateIds,
            StringChecks = [ChatStrings.ObtainedMgpMarker],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true,
            ObtainMarkerMgp = true
        },
        new()
        {
            Name = "ShowGoldSaucerSwingMinigames",
            SettingsTab = "Gold Saucer",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4784, 4789],
            StringChecks = [ChatStrings.GoldSaucerTakeUpTool],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGoldSaucerSwingMinigames",
            SettingsTab = "Gold Saucer",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4785, 4790],
            StringChecks = [ChatStrings.GoldSaucerSenseNothing],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGoldSaucerSwingMinigames",
            SettingsTab = "Gold Saucer",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4786, 4791],
            StringChecks = [ChatStrings.GoldSaucerSenseClose],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGoldSaucerSwingMinigames",
            SettingsTab = "Gold Saucer",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4787, 4792],
            StringChecks = [ChatStrings.GoldSaucerSenseVeryClose],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowGoldSaucerSwingMinigames",
            SettingsTab = "Gold Saucer",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4788, 4793],
            StringChecks = [ChatStrings.GoldSaucerRightOnTop],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        },
        new()
        {
            Name = "ShowTripleTriadAllowed",
            SettingsTab = "Gold Saucer",
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
            SettingsTab = "Gold Saucer",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4764],
            StringChecks = [ChatStrings.TripleTriadNotAllowed],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];
}
