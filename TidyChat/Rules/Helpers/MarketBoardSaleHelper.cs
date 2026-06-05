using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using TidyChat.Utility;

namespace TidyChat;

internal static class MarketBoardSaleHelper
{
    public static bool IsMarketItemSoldText(string normalizedText) =>
        LogMessageCatalog.MatchesWithFallback(748, normalizedText, ChatStrings.MarketItemSold) ||
        L10N.Get(ChatRegexStrings.MarketItemSold).IsMatch(normalizedText);

    public static bool TryParseSaleGilAmount(string normalizedText, out string gilAmount)
    {
        gilAmount = string.Empty;
        var gilMatch = L10N.Get(ChatRegexStrings.MarketItemSold).Match(normalizedText);
        if (!gilMatch.Success || !gilMatch.Groups["gil"].Success)
        {
            return false;
        }

        gilAmount = gilMatch.Groups["gil"].Value;
        return true;
    }

    public static bool IsRewrittenMarketItemSoldDisplay(string displayText) =>
        displayText.Contains(" sold for ", StringComparison.OrdinalIgnoreCase) &&
        displayText.Contains(" gil", StringComparison.OrdinalIgnoreCase) &&
        !displayText.Contains("put up for sale", StringComparison.OrdinalIgnoreCase) &&
        !displayText.Contains("entrusted", StringComparison.OrdinalIgnoreCase);

    public static bool IsGilEntrustedToRetainerText(string normalizedText) =>
        TextMatchHelper.MatchesAllTokens(normalizedText, ChatStrings.MarketGilEntrustedToRetainer);

    public static bool ShouldAllowImprovedMarketSale(Configuration config, string normalizedText, string displayText) =>
        config.BetterMarketBoardSaleMessage &&
        FilterMasterAccessors.MarketItemSold(config) &&
        (IsMarketItemSoldText(normalizedText) || IsRewrittenMarketItemSoldDisplay(displayText));

    public static bool ShouldBlockGilEntrusted(Configuration config, string normalizedText) =>
        IsGilEntrustedToRetainerText(normalizedText) && !config.ShowMarketGilEntrustedToRetainer;

    public static SeString? TryRewriteSaleMessage(SeString message, Configuration configuration, string normalizedText)
    {
        if (!IsMarketItemSoldText(normalizedText) || !TryParseSaleGilAmount(normalizedText, out var gilAmount))
        {
            return null;
        }

        var builder = new SeStringBuilder();
        if (configuration.IncludeChatTag)
        {
            BetterStrings.AddTidyChatTag(builder);
        }

        var addedItem = false;
        foreach (var payload in message.Payloads)
        {
            if (payload is TextPayload { Text: { Length: > 0 } text })
            {
                var putUpIndex = text.IndexOf(" you put up", StringComparison.OrdinalIgnoreCase);
                var soldForIndex = text.IndexOf("sold for", StringComparison.OrdinalIgnoreCase);
                var cutIndex = putUpIndex >= 0 ? putUpIndex : soldForIndex;
                if (cutIndex >= 0)
                {
                    if (cutIndex > 0)
                    {
                        builder.AddText(text[..cutIndex]);
                        if (!text.StartsWith("The ", StringComparison.OrdinalIgnoreCase) || cutIndex > "The ".Length)
                        {
                            addedItem = true;
                        }
                    }
                    break;
                }
            }

            builder.Add(payload);
            if (payload is ItemPayload)
            {
                addedItem = true;
            }
        }

        if (!addedItem)
        {
            return null;
        }

        builder.AddText($" sold for {gilAmount} gil.");
        return builder.BuiltString;
    }
}
