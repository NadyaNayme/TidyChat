using TidyChat.Translation.Data;
namespace TidyChat;

public static partial class ChatStrings
{

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
}
