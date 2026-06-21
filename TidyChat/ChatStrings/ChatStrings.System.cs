using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/1629?pretty=true">/isearch match summary.</see>
    /// <seealso href="https://xivapi.com/LogMessage/1438?pretty=true">/isearch location result lines.</seealso>
    public static readonly LocalizedStrings ItemSearchResults = new()
    {
        Jpn = ["含む", "所持"],
        Eng = ["containing", "found"],
        Deu = ["treffer", "inventar"],
        Fra = ["contenant", "inventaire"]
    };

    /// <see href="https://xivapi.com/LogMessage/1631?pretty=true">/isearch item name lines (>> …).</see>
    public static readonly LocalizedStrings ItemSearchResultLine = new()
    {
        Jpn = [">>"],
        Eng = [">>"],
        Deu = [">>"],
        Fra = [">>"]
    };

    /// <see href="https://xivapi.com/LogMessage/1438?pretty=true">/isearch location result lines (stowage).</see>
    public static readonly LocalizedStrings LocationSearchStowage = new()
    {
        Jpn = ["あります"],
        Eng = ["found", "in"],
        Deu = ["gefunden"],
        Fra = ["trouvé"]
    };

    /// <see href="https://xivapi.com/LogMessage/1438?pretty=true">/isearch location result lines (equipped).</see>
    public static readonly LocalizedStrings LocationSearchEquipped = new()
    {
        Jpn = ["装備"],
        Eng = ["equipped"],
        Deu = ["angelegt"],
        Fra = ["équipé"]
    };

    /// <see href="https://xivapi.com/LogMessage/1438?pretty=true">/isearch location result lines (total).</see>
    public static readonly LocalizedStrings LocationSearchTotal = new()
    {
        Jpn = ["見つかりました"],
        Eng = ["total", "found"],
        Deu = ["ergab"],
        Fra = ["total"]
    };

    /// <see href="https://xivapi.com/LogMessage/503?pretty=true">Aetheryte ticket ready message.</see>
    public static readonly LocalizedStrings AetheryteTicketReady = new()
    {
        Jpn = ["チケット", "使用"],
        Eng = ["aetheryte", "ticket", "ready"],
        Deu = ["ätheryt", "ticket", "bereit"],
        Fra = ["téléportation", "préparez"]
    };
    /// <see href="https://xivapi.com/LogMessage/535?pretty=true">Aetheryte ticket use message.</see>
    /// <seealso href="https://xivapi.com/LogMessage/4591?pretty=true">Aetheryte ticket used with remaining count (System).</seealso>
    public static readonly LocalizedStrings AetheryteTicketUsed = new()
    {
        Jpn = ["チケット", "使用"],
        Eng = ["aetheryte", "ticket", "used"],
        Deu = ["ätheryt", "ticket", "verwendet"],
        Fra = ["téléportation", "utilise"]
    };
    /// <see href="https://xivapi.com/LogMessage/4242?pretty=true">Changes discarded.</see>
    public static readonly LocalizedStrings ChangesDiscarded = new()
    {
        Jpn = ["破棄"],
        Eng = ["changes", "discarded"],
        Deu = ["verworfen"],
        Fra = ["annulés"]
    };
    /// <see href="https://xivapi.com/LogMessage/802?pretty=true">Changes lost.</see>
    public static readonly LocalizedStrings ChangesLost = new()
    {
        Jpn = ["失わ"],
        Eng = ["changes", "lost"],
        Deu = ["verloren"],
        Fra = ["perdues"]
    };
    /// <see href="https://xivapi.com/LogMessage/4763?pretty=true">Triple Triad matches allowed in current area.</see>
    public static readonly LocalizedStrings TripleTriadAllowed = new()
    {
        Jpn = ["トリプルトライアド"],
        Eng = ["triple", "triad", "allowed"],
        Deu = ["triple", "triad", "erlaubt"],
        Fra = ["triple", "triad", "autorisées"]
    };
    /// <see href="https://xivapi.com/LogMessage/4764?pretty=true">Triple Triad matches not allowed in current area.</see>
    public static readonly LocalizedStrings TripleTriadNotAllowed = new()
    {
        Jpn = ["トリプルトライアド"],
        Eng = ["triple", "triad", "not", "allowed"],
        Deu = ["triple", "triad", "nicht", "erlaubt"],
        Fra = ["triple", "triad", "interdites"]
    };

    /// <see href="https://xivapi.com/LogMessage/81?pretty=true">List updated.</see>
    public static readonly LocalizedStrings FriendListUpdated = new()
    {
        Jpn = ["リスト", "更新"],
        Eng = ["list", "updated"],
        Deu = ["liste", "aktualisiert"],
        Fra = ["liste", "actualisée"]
    };
}
