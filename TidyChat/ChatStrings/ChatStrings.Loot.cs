using TidyChat.Translation.Data;

namespace TidyChat;

// 3 localized string markers — see ChatStrings.cs for the full index.
public static partial class ChatStrings
{
/// <summary>Marker for another player's obtain verb (used with <see cref="LocalizedFilterRule.ExcludePlayerObtain"/>).</summary>
    public static readonly LocalizedStrings OtherObtainMarker = new()
    {
        Jpn = ["手に入れた"],
        Eng = ["obtains"],
        Deu = ["erhalten"],
        Fra = ["obtient"]
    };

    /// <summary>Marker tokens for "You cast your lot …" loot-roll messages.</summary>
    public static readonly LocalizedStrings CastLot = new()
    {
        Jpn = ["ロット"],
        Eng = ["cast", "lot"],
        Deu = ["würfel"],
        Fra = ["lance", "dés"]
    };

    /// <summary>Marker tokens for "You roll Need/Greed …" loot-roll messages.</summary>
    public static readonly LocalizedStrings LootRoll = new()
    {
        Jpn = ["ダイス"],
        Eng = ["roll", "need", "greed"],
        Deu = ["würfel"],
        Fra = ["jette", "dés"]
    };
}
