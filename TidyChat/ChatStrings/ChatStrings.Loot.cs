using TidyChat.Translation.Data;

namespace TidyChat;

public static partial class ChatStrings
{
/// <summary>Substring markers for another-player obtain lines (<see cref="LocalizedFilterRule.ExcludePlayerObtain"/>).</summary>
    public static readonly LocalizedStrings OtherObtainMarker = new()
    {
        Jpn = ["手に入れた"],
        Eng = ["obtains"],
        Deu = ["erhalten"],
        Fra = ["obtient"]
    };

    /// <summary>Substring markers for "You cast your lot …" loot-roll messages.</summary>
    public static readonly LocalizedStrings CastLot = new()
    {
        Jpn = ["ロット"],
        Eng = ["cast", "lot"],
        Deu = ["würfel"],
        Fra = ["lance", "dés"]
    };

    /// <summary>Substring markers for "You roll Need/Greed …" loot-roll messages.</summary>
    public static readonly LocalizedStrings LootRoll = new()
    {
        Jpn = ["ダイス"],
        Eng = ["roll", "need", "greed"],
        Deu = ["würfel"],
        Fra = ["jette", "dés"]
    };
}
