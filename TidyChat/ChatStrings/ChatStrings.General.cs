using TidyChat.Translation.Data;
namespace TidyChat;

public static partial class ChatStrings
{

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

    public static readonly LocalizedStrings GenericGameWelcomeMarkers = new()
    {
        Eng = ["final fantasy", "ffxiv"],
        Deu = ["final fantasy"],
        Fra = ["l'univers", "final fantasy"],
        Jpn = ["ファイナルファンタジー"]
    };

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

    public static readonly LocalizedStrings JobChange = new()
    {
        Jpn = ["チェンジ"],
        Eng = ["change to"],
        Deu = ["bist", "nun"],
        Fra = ["maintenant"]
    };

    public static readonly LocalizedStrings ArmouryChestPlacement = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["armoury", "chest"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings JobRegistered = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["registered"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings JobSpecialistChange = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["change to", "specialist"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
}
