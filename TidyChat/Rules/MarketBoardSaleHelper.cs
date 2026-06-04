namespace TidyChat;

/// <summary>
/// Improved market sale rewrites and optional hiding of the gil-entrusted follow-up line.
/// </summary>
internal static class MarketBoardSaleHelper
{
    public static bool IsMarketItemSoldText(string normalizedText) =>
        LogMessageCatalog.MatchesWithFallback(748, normalizedText, ChatStrings.MarketItemSold) ||
        L10N.Get(ChatRegexStrings.MarketItemSold).IsMatch(normalizedText);

    public static bool IsRewrittenMarketItemSoldDisplay(string displayText) =>
        displayText.Contains(" sold for ", StringComparison.OrdinalIgnoreCase) &&
        displayText.Contains(" gil", StringComparison.OrdinalIgnoreCase) &&
        !displayText.Contains("put up for sale", StringComparison.OrdinalIgnoreCase) &&
        !displayText.Contains("entrusted", StringComparison.OrdinalIgnoreCase);

    public static bool IsGilEntrustedToRetainerText(string normalizedText) =>
        L10N.Get(ChatStrings.MarketGilEntrustedToRetainer).All(normalizedText.Contains);

    public static bool ShouldAllowImprovedMarketSale(Configuration config, string normalizedText, string displayText) =>
        config.BetterMarketBoardSaleMessage &&
        (IsMarketItemSoldText(normalizedText) || IsRewrittenMarketItemSoldDisplay(displayText));

    public static bool ShouldBlockGilEntrusted(Configuration config, string normalizedText) =>
        IsGilEntrustedToRetainerText(normalizedText) && !config.ShowMarketGilEntrustedToRetainer;
}
