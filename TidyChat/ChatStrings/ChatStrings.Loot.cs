using TidyChat.Translation.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/657?pretty=true">Other-player obtain (657 / 1259 templates)</see>

    public static readonly LocalizedStrings OtherObtainMarker = new()
    {
        Jpn = ["手に入れた"],
        Eng = ["obtains"],
        Deu = ["erhalten"],
        Fra = ["obtient"]
    };

    public static readonly LocalizedStrings CastLot = new()
    {
        Jpn = ["ロット"],
        Eng = ["cast", "lot"],
        Deu = ["würfel"],
        Fra = ["lance", "dés"]
    };

    public static readonly LocalizedStrings LootRoll = new()
    {
        Jpn = ["ダイス"],
        Eng = ["roll", "need", "greed"],
        Deu = ["würfel"],
        Fra = ["jette", "dés"]
    };
}
