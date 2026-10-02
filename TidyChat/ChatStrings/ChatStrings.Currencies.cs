using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/Item/25?pretty=true">Wolf Marks</see>
    public static readonly LocalizedStrings ObtainWolfMarks = new()
    {
        Jpn = ["対人戦績"],
        Eng = ["you", "obtain", "wolf", "mark"], // You obtain ### Wolf Marks.
        Deu = ["wolfsmarke", "erhalten"],
        Fra = ["marque", "loup"]
    };
    /// <see href="https://xivapi.com/Item/21072?pretty=true">Venture</see>
    public static readonly LocalizedStrings ObtainVentureMarker = new()
    {
        Jpn = ["ベンチャースクリップ"],
        Eng = ["venture"],
        Deu = ["wertmarke"],
        Fra = ["jeton", "tâche"]
    };
    /// <see href="https://xivapi.com/Item/27?pretty=true">Allied Seals</see>
    public static readonly LocalizedStrings ObtainAlliedSealsMarker = new()
    {
        Jpn = ["同盟記章"],
        Eng = ["allied", "seal"],
        Deu = ["jagdabzeichen"],
        Fra = ["insigne", "allié"]
    };

    /// <see href="https://xivapi.com/Item/10307?pretty=true">Centurio Seals</see>
    public static readonly LocalizedStrings ObtainCenturioSealsMarker = new()
    {
        Jpn = ["セントリオ記章"],
        Eng = ["centurio", "seal"],
        Deu = ["centurio-abzeichen"],
        Fra = ["insigne", "centurio"]
    };

    /// <see href="https://xivapi.com/Item/26533?pretty=true">Sacks of Nuts</see>
    public static readonly LocalizedStrings ObtainNutsMarker = new()
    {
        Jpn = ["モブハントの戦利品"],
        Eng = ["nuts"],
        Deu = ["kupo-trophä"],
        Fra = ["insigne", "chasse"]
    };

    /// <see href="https://xivapi.com/Item/20?pretty=true">GC Seals (Storm)</see>
    /// <seealso href="https://xivapi.com/Item/21?pretty=true">Serpent Seals</seealso>
    /// <seealso href="https://xivapi.com/Item/22?pretty=true">Flame Seals</seealso>
    public static readonly LocalizedStrings ObtainSealsMarker = new()
    {
        Jpn = ["黒渦団軍票"],
        Eng = ["storm seal"],
        Deu = ["flottentaler"],
        Fra = ["compagnie limséen"]
    };

    /// <see href="https://xivapi.com/Item/2?pretty=true">Elemental clusters (see Item/14–19)</see>
    public static readonly LocalizedStrings ObtainClusterMarker = new()
    {
        Jpn = ["クラスター"],
        Eng = ["cluster"],
        Deu = ["cluster"],
        Fra = ["cluster"]
    };

    /// <see href="https://xivapi.com/LogMessage/657?pretty=true">You obtain N gil (657 family)</see>
    /// <seealso href="https://xivapi.com/LogMessage/1259?pretty=true">Alternate obtain template</seealso>
    public static readonly LocalizedStrings ObtainedGilMarker = new()
    {
        Jpn = ["ギル"],
        Eng = ["gil"],
        Deu = ["gil"],
        Fra = ["gil"]
    };

    /// <see href="https://xivapi.com/LogMessage/1798?pretty=true">You receive N gil (System channel).</see>
    /// <seealso href="https://xivapi.com/LogMessage/10923?pretty=true">Alternate receive-gil template</seealso>
    public static readonly LocalizedStrings ReceivedGilMarker = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "receive", "gil"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/4765?pretty=true">MGP obtain</see>
    public static readonly LocalizedStrings ObtainedMgpMarker = new()
    {
        Jpn = ["mgp", "手に入れた"],
        Eng = ["you", "obtain", "mgp"],
        Deu = ["mgp", "erhalten"],
        Fra = ["obtenez", "pgs"]
    };
}
