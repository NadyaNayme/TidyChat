using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/1388?pretty=true">N items repaired.</see>
    public static readonly LocalizedStrings GearItemsRepairedBulk = new()
    {
        Jpn = ["修理"],
        Eng = ["items", "repaired"],
        Deu = ["gegenstände", "repariert"],
        Fra = ["objets", "réparé"]
    };
    /// <see href="https://xivapi.com/LogMessage">Matched via formatted chat text (not a LogMessage row)</see>
    public static readonly LocalizedStrings SayQuestReminder = new()
    {
        Jpn = ["チャットの会話モードを"],
        Eng = ["with", "the", "chat", "mode", "in", "enter", "phrase", "containing"],
        Deu = ["gib", "im", "virtuelle", "tastatur"],
        Fra = ["en", "mode", "de", "discussion"]
    };
    /// <see href="https://xivapi.com/LogMessage/732?pretty=true">You have entered a sanctuary.</see>
    /// <seealso href="https://xivapi.com/LogMessage/733?pretty=true">You have left the sanctuary.</seealso>
    public static readonly LocalizedStrings SanctuaryMessage = new()
    {
        Jpn = ["レストエリア"],
        Eng = ["sanctuary"],
        Deu = ["ruhebereich"],
        Fra = ["repos"]
    };
    /// <see href="https://xivapi.com/LogMessage/744?pretty=true">Your spiritbond with … is complete!</see>
    public static readonly LocalizedStrings SpiritboundGear = new()
    {
        Jpn = ["錬精度"],
        Eng = ["spiritbond"],
        Deu = ["bindung"],
        Fra = ["symbiose"]
    };
    /// <see href="https://xivapi.com/LogMessage/7975?pretty=true">Second Chance points added …</see>
    public static readonly LocalizedStrings SecondChanceAward = new()
    {
        Jpn = ["チャンスポイント"],
        Eng = ["second", "chance"],
        Deu = ["chance-punkte"],
        Fra = ["points", "chance"]
    };
    /// <see href="https://xivapi.com/LogMessage/700?pretty=true">… equipped.</see>
    /// <seealso href="https://xivapi.com/LogMessage/755?pretty=true">"…" equipped.</seealso>
    public static readonly LocalizedStrings GearsetEquipped = new()
    {
        Jpn = ["装備"],
        Eng = ["equipped"],
        Deu = ["angelegt"],
        Fra = ["équipez"]
    };
    /// <see href="https://xivapi.com/LogMessage/765?pretty=true">Unable to equip gear set.</see>
    public static readonly LocalizedStrings GearsetUnableToEquip = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["unable", "equip", "gear", "set"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/5865?pretty=true">Portrait set as instant portrait.</see>
    public static readonly LocalizedStrings PortraitSetInstant = new()
    {
        Jpn = ["ポートレート"],
        Eng = ["portrait", "instant"],
        Deu = ["portrait", "schnellportrait"],
        Fra = ["portrait", "instantané"]
    };
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
    /// <see href="https://xivapi.com/LogMessage/1341?pretty=true">You attune to the aetheryte.</see>
    public static readonly LocalizedStrings AttuneAetheryte = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["attune", "aetheryte"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
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
}