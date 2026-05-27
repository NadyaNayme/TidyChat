using TidyChat.Translation.Data;

namespace TidyChat;

// 17 localized string markers — see ChatStrings.cs for the full index.
public static partial class ChatStrings
{
/// <see href="https://xivapi.com/LogMessage/756?pretty=true">Job registered (e.g. Paladin registered.).</see>
    public static readonly LocalizedStrings JobRegistered = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["registered"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
    };

    /// <see href="https://xivapi.com/LogMessage/1281?pretty=true">You change to … (specialist).</see>
    public static readonly LocalizedStrings JobSpecialistChange = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["change", "specialist"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
    };

    /// <see href="https://xivapi.com/LogMessage/561?pretty=true">You change to … (job/class).</see>
    public static readonly LocalizedStrings JobChange = new()
    {
        Jpn = ["チェンジ"],
        Eng = ["change", "to"],
        Deu = ["bist", "nun"],
        Fra = ["maintenant"]
    };

    /// <see href="https://github.com/NadyaNayme/TidyChat/issues/122">Login / world-travel server announcements</see>
    public static readonly LocalizedStrings ServerAnnouncementMarkers = new()
    {
        Eng =
        [
            "welcome to final fantasy",
            "congested world",
            "home world transfer",
            "underway until",
            "preferred"
        ],
        Deu =
        [
            "willkommen bei final fantasy",
            "überfüllt",
            "weltentransfer",
            "bevorzugt",
            " läuft bis "
        ],
        Fra =
        [
            "bienvenue dans l'univers",
            "congestion",
            "transfert",
            "privilégié",
            "en cours jusqu"
        ],
        Jpn =
        [
            "ファイナルファンタジー",
            "混雑",
            "ホームワールド",
            "イベント",
            "開催中"
        ]
    };

    /// <see href="https://github.com/NadyaNayme/TidyChat/issues/122">Phishing warning lines in the login block</see>
    public static readonly LocalizedStrings ServerPhishingMarkers = new()
    {
        Eng =
        [
            "be wary of phishing",
            "phishing attempts via tell",
            "if you receive a tell containing a url",
            "url to a website from a random player"
        ],
        Deu =
        [
            "vorsicht vor phishing",
            "tell mit einer url",
            "phishingversuchen"
        ],
        Fra =
        [
            "méfiez-vous",
            "hameçonnage",
            "tell contenant une url"
        ],
        Jpn =
        [
            "フィッシング",
            "テル",
            "url"
        ]
    };

    /// <see href="https://xivapi.com/LogMessage/398?pretty=true">You are now selling items in … markets.</see>
    public static readonly LocalizedStrings MarketBoardStartSelling = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["selling", "items", "markets"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/399?pretty=true">You are no longer selling items in … markets.</see>
    public static readonly LocalizedStrings MarketBoardStopSelling = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["no", "longer", "selling"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/748?pretty=true">… you put up for sale in the markets has sold for … gil (after fees).</see>
    public static readonly LocalizedStrings MarketItemSold = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["put", "up", "for", "sale", "markets", "sold", "after", "fees"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/384?pretty=true">All your items up for sale in the … markets have sold.</see>
    public static readonly LocalizedStrings MarketAllItemsSold = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["all", "items", "sale", "markets", "sold"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/734?pretty=true">You purchase …</see>
    public static readonly LocalizedStrings VendorPurchase = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "purchase"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings CappedWolfMarks = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng =
        [
            "you", "cannot", "receive", "any", "more", "wolf", "marks"
        ], // You cannot receive any more Wolf Marks. (Error Message)
        Deu = ["du", "kannst", "keine", "wolfsmarken"],
        Fra = ["marques", "de", "loup"]
    };

    /// <see href="https://xivapi.com/LogMessage/1117?pretty=true">You lose your bait…</see>
    public static readonly LocalizedStrings LoseBait = new()
    {
        Jpn = ["釣り餌"],
        Eng = ["lose", "bait"],
        Deu = ["köder"],
        Fra = ["appât"]
    };

    /// <see href="https://xivapi.com/LogMessage/631?pretty=true">You recover N GP.</see>
    public static readonly LocalizedStrings GPRecover = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["recover", "gp"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
    };

    /// <see href="https://xivapi.com/LogMessage/11174?pretty=true">You consumed N GP.</see>
    public static readonly LocalizedStrings GPConsumed = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["consumed", "gp"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
    };

    public static readonly LocalizedStrings PalaceOfTheDead = new()
    {
        Jpn = ["死者の宮殿"],
        Eng = ["palace", "dead", "begun"],
        Deu = ["palast", "der", "toten"],
        Fra = ["palais", "des", "morts"]
    };

    public static readonly LocalizedStrings HeavenOnHigh = new()
    {
        Jpn = ["天上"],
        Eng = ["heaven-on-high", "begun"],
        Deu = ["himmelssäule"],
        Fra = ["pilier", "des", "cieux"]
    };

    /// <see href="https://xivapi.com/LogMessage/788?pretty=true">… placed in your Armoury Chest.</see>
    public static readonly LocalizedStrings ArmouryChestPlacement = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["armoury", "chest"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
    };
}
