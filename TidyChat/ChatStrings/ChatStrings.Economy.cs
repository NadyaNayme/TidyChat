using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/398?pretty=true">You are now selling items in the … markets.</see>
    public static readonly LocalizedStrings MarketBoardStartSelling = new()
    {
        Jpn = ["マーケットへの出品を開始しました"],
        Eng = ["selling", "items", "markets"],
        Deu = ["verkaufst", "gegenstände", "markt"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/399?pretty=true">You are no longer selling items in the … markets.</see>
    public static readonly LocalizedStrings MarketBoardStopSelling = new()
    {
        Jpn = ["マーケットへの出品が停止されました"],
        Eng = ["no", "longer", "selling"],
        Deu = ["gegenstände", "verkauf", "zurückgezogen"],
        Fra = ["objets", "retirés", "vente"]
    };
    /// <see href="https://xivapi.com/LogMessage/748?pretty=true">
    ///     … you put up for sale in the markets has sold for … gil
    ///     (after fees).
    /// </see>
    public static readonly LocalizedStrings MarketItemSold = new()
    {
        Jpn = ["マーケットに", "ギルで出品した", "ギルを入手しました"],
        Eng = ["put", "up", "for", "sale", "markets", "sold", "after", "fees"],
        Deu = ["gehilfe", "verkauft", "erhalten"],
        Fra = ["servant", "vendu"]
    };
    public static readonly LocalizedStrings MarketAllItemsSold = new()
    {
        Jpn = ["マーケットへ出品したアイテムが完売しました"],
        Eng = ["all", "items", "sale", "markets", "sold"],
        Deu = ["waren", "markt", "verkauft"],
        Fra = ["objets", "vente", "vendus"]
    };
    /// <see href="https://xivapi.com/LogMessage/4578?pretty=true">
    ///     Gil earned from market sales has been entrusted to your
    ///     retainer.
    /// </see>
    public static readonly LocalizedStrings MarketGilEntrustedToRetainer = new()
    {
        Jpn = ["マーケットで売れた出品物の代金がリテイナーに振り込まれました"],
        Eng = ["gil", "earned", "market", "sales", "entrusted", "retainer"],
        Deu = ["marktverkäufen", "gehilfen", "anvertraut"],
        Fra = ["argent", "transféré", "servant"]
    };
    public static readonly LocalizedStrings VendorSellForGil = new()
    {
        Jpn = ["ギルで売却しました"],
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
        Jpn = ["ギルで購入しました"],
        Eng = ["you", "purchase", "for", "gil"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4590?pretty=true">You spend gil on a purchase.</see>
    public static readonly LocalizedStrings GilSpent = new()
    {
        Jpn = ["ギルを消費しました"],
        Eng = ["spent", "gil"],
        Deu = ["NeedsLocalization"],
        Fra = ["dépensé", "téléporter"]
    };
    public static readonly LocalizedStrings GilSafelyWithdrawn = new()
    {
        Jpn = ["リテイナーからギルを受け取りました"],
        Eng = ["gil", "safely", "withdrawn"],
        Deu = ["wieder", "entnommen"],
        Fra = ["récupéré", "argent", "servant"]
    };
    /// <see href="https://xivapi.com/LogMessage/4735?pretty=true">Jumbo Cactpot ticket purchase (MGP spend).</see>
    public static readonly LocalizedStrings JumboCactpotTicketPurchase = new()
    {
        Jpn = ["mgp", "くじ"],
        Eng = ["mgp", "cactpot"],
        Deu = ["mgp", "gekauft"],
        Fra = ["pgs", "billet"]
    };

    /// <see href="https://xivapi.com/LogMessage/4341?pretty=true">RetainerName has completed a venture!</see>
    public static readonly LocalizedStrings RetainerVentureComplete = new()
    {
        Jpn = ["あなたの雇用している", "冒険を終えました"],
        Eng = ["completed", "venture"],
        Deu = ["unternehmung", "abgeschlossen"],
        Fra = ["terminé", "tâche"]
    };
    /// <see href="https://xivapi.com/LogMessage/4331?pretty=true">You assign your retainer "Quick Exploration."</see>
    public static readonly LocalizedStrings RetainerVentureAssign = new()
    {
        Jpn = ["リテイナーベンチャー", "を依頼しました"],
        Eng = ["assign your retainer"],
        Deu = ["gehilfen", "beauftragt"],
        Fra = ["confié", "tâche", "servant"]
    };
    /// <see href="https://xivapi.com/LogMessage/4334?pretty=true">You pay RetainerName N ventures.</see>
    public static readonly LocalizedStrings RetainerVenturePayment = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["pay", "venture"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4332?pretty=true">"Lv. …" is now complete.</see>
    public static readonly LocalizedStrings RetainerVentureItemComplete = new()
    {
        Jpn = ["リテイナーベンチャー", "が完了しました"],
        Eng = ["now", "complete"],
        Deu = ["gehilfe", "erfolgreich", "beschafft"],
        Fra = ["tâche", "terminée"]
    };
    /// <see href="https://xivapi.com/LogMessage/4335?pretty=true">Retainer has reached maximum level.</see>
    public static readonly LocalizedStrings RetainerMaxLevel = new()
    {
        Jpn = ["はレベルキャップに達しています", "雇用主の同クラス", "リテイナーが越えることはできません"],
        Eng = ["reached", "maximum", "level", "retainer"],
        Deu = ["maximalstufe", "erreicht", "entspricht"],
        Fra = ["atteint", "maximum", "dépasser"]
    };

    /// <see href="https://xivapi.com/LogMessage/32?pretty=true">Trade request sent to …</see>
    public static readonly LocalizedStrings TradeRequestSent = new()
    {
        Jpn = ["にトレードを申し込みました"],
        Eng = ["trade", "request", "sent"],
        Deu = ["handel", "angeboten"],
        Fra = ["proposez", "échange"]
    };

    /// <see href="https://xivapi.com/LogMessage/33?pretty=true">Awaiting trade confirmation from …</see>
    public static readonly LocalizedStrings TradeAwaitingConfirmation = new()
    {
        Jpn = ["の内容確認を待っています"],
        Eng = ["awaiting", "trade", "confirmation"],
        Deu = ["warte", "bestätigung"],
        Fra = ["proposition"]
    };

    /// <see href="https://xivapi.com/LogMessage/34?pretty=true">… wishes to trade with you.</see>
    public static readonly LocalizedStrings TradeRequestReceived = new()
    {
        Jpn = ["からトレードを申し込まれました"],
        Eng = ["wishes", "trade", "you"],
        Deu = ["möchte", "handeln"],
        Fra = ["propose", "échange"]
    };

    /// <see href="https://xivapi.com/LogMessage/36?pretty=true">… cancels the trade.</see>
    public static readonly LocalizedStrings TradeCanceled = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["cancels", "trade"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/38?pretty=true">You complete the trade with …</see>
    public static readonly LocalizedStrings TradeComplete = new()
    {
        Jpn = ["トレードが完了しました"],
        Eng = ["complete", "trade"],
        Deu = ["handel", "abgeschlossen"],
        Fra = ["échange", "terminé"]
    };
}
