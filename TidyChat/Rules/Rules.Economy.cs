namespace TidyChat;

public static partial class Rules
{
    private static readonly LocalizedFilterRule[] EconomyRulesSegment0 =
    [
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
        }
    ];

    private static readonly LocalizedFilterRule[] EconomyRulesSegment1 =
    [
        new()
        {
            Name = "ShowTradeComplete",
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [38]
        }
    ];

    private static readonly LocalizedFilterRule[] EconomyRulesSegment2 =
    [
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
        }
    ];

    private static readonly LocalizedFilterRule[] EconomyRulesRetainer =
    [
        new()
        {
            Name = "ShowCompletedVenture",
            SettingsTab = "Economy",
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
            SettingsTab = "Economy",
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
            SettingsTab = "Economy",
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
            SettingsTab = "Economy",
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
            SettingsTab = "Economy",
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
            SettingsTab = "Economy",
            Channel = ChatType.System,
            IsActive = true,
            LogMessageIds = [4335],
            StringChecks = [ChatStrings.RetainerMaxLevel],
            Pattern = PatternKind.StringMatch,
            PreferLogMessageCatalog = true
        }
    ];
}
