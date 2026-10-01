using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    public static readonly LocalizedStrings QuestItemObtain = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "obtain"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings ObtainedItemQuantity = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "obtain"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings ObtainedGearPiece = new()
    {
        Jpn = ["手に入れた"],
        Eng = ["obtain", "piece"],
        Deu = ["teil", "erhalten"],
        Fra = ["obtenez", "pièce"]
    };

    /// <see href="https://xivapi.com/LogMessage/3538?pretty=true">Collectable gather obtain (LootNotice).</see>
    public static readonly LocalizedStrings ObtainedSingleItem = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "obtain"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings InventoryItemAdded = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["added", "inventory"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings DiscardedItem = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["throw", "away"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings ItemBoundToYou = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["bound", "you"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings ObtainMaterialsMarker = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["materials"],
        Deu = ["materials"],
        Fra = ["materials"]
    };

    /// <see href="https://xivapi.com/LogMessage/657?pretty=true">Other-player obtain (657 / 1259 templates)</see>
    public static readonly LocalizedStrings OtherObtainMarker = new()
    {
        Jpn = ["手に入れた"],
        Eng = ["obtains"],
        Deu = ["erhalten"],
        Fra = ["obtient"]
    };

    /// <see href="https://xivapi.com/LogMessage/5180?pretty=true">You cast your lot / another player casts lot (5180)</see>
    public static readonly LocalizedStrings CastLot = new()
    {
        Jpn = ["you", "ロット"],
        Eng = ["you", "lot"],
        Deu = ["würfel"],
        Fra = ["lance", "dés"]
    };

    /// <see href="https://xivapi.com/LogMessage/1231?pretty=true">You roll Need/Greed / another player rolls (1231)</see>
    public static readonly LocalizedStrings LootRoll = new()
    {
        Jpn = ["you", "ダイス"],
        Eng = ["you", "roll"],
        Deu = ["würfel"],
        Fra = ["jette", "dés"]
    };
}
