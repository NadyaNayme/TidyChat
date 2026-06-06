using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/398?pretty=true">You are now selling items in the … markets.</see>
    public static readonly LocalizedStrings MarketBoardStartSelling = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["selling", "items", "markets"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/399?pretty=true">You are no longer selling items in the … markets.</see>
    public static readonly LocalizedStrings MarketBoardStopSelling = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["no", "longer", "selling"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/748?pretty=true">
    ///     … you put up for sale in the markets has sold for … gil
    ///     (after fees).
    /// </see>
    public static readonly LocalizedStrings MarketItemSold = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["put", "up", "for", "sale", "markets", "sold", "after", "fees"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    public static readonly LocalizedStrings MarketAllItemsSold = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["all", "items", "sale", "markets", "sold"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4578?pretty=true">
    ///     Gil earned from market sales has been entrusted to your
    ///     retainer.
    /// </see>
    public static readonly LocalizedStrings MarketGilEntrustedToRetainer = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["gil", "earned", "market", "sales", "entrusted", "retainer"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    public static readonly LocalizedStrings VendorSellForGil = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "sell", "for", "gil"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    public static readonly LocalizedStrings VendorPurchase = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "purchase"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    public static readonly LocalizedStrings VendorPurchaseForGil = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "purchase", "for", "gil"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4590?pretty=true">You spend gil on a purchase.</see>
    public static readonly LocalizedStrings GilSpent = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["spent", "gil"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    public static readonly LocalizedStrings GilSafelyWithdrawn = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["gil", "safely", "withdrawn"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4735?pretty=true">Jumbo Cactpot ticket purchase (MGP spend).</see>
    public static readonly LocalizedStrings JumboCactpotTicketPurchase = new()
    {
        Jpn = ["mgp", "くじ"],
        Eng = ["mgp", "cactpot"],
        Deu = ["mgp", "gekauft"],
        Fra = ["pgs", "billet"]
    };
}
