using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/10508?pretty=true">You use a pot of … dye to change Dye N of … to …</see>
    public static readonly LocalizedStrings GearDyeApplied = new()
    {
        Jpn = ["染め"],
        Eng = ["use", "dye", "change"],
        Deu = ["farbe", "benutzt"],
        Fra = ["teignez", "teinture"]
    };
    /// <see href="https://xivapi.com/LogMessage/3911?pretty=true">You try on …</see>
    public static readonly LocalizedStrings TryOnGlamourPreview = new()
    {
        Jpn = ["を試着した"],
        Eng = ["try on"],
        Deu = ["probeweise", "angelegt"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4309?pretty=true">You cast a glamour …</see>
    public static readonly LocalizedStrings TryOnGlamourCast = new()
    {
        Jpn = ["武器投影"],
        Eng = [" a glamour"],
        Deu = ["projizierst"],
        Fra = ["un mirage"]
    };
    /// <see href="https://xivapi.com/LogMessage/4529?pretty=true">Outfit glamour stored in dresser (7.1+).</see>
    public static readonly LocalizedStrings GlamourOutfitStored = new()
    {
        Jpn = ["として幻影化しました"],
        Eng = ["stored as", "outfit glamour"],
        Deu = ["entfernt", "projiziert"],
        Fra = ["retiré", "transformé", "mirage"]
    };
    /// <see href="https://xivapi.com/LogMessage/?pretty=true">Outfit glamour created in the dresser (7.1+).</see>
    public static readonly LocalizedStrings GlamourOutfitInto = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["into", "outfit glamour"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4380?pretty=true">Projection added to glamour dresser (4380, 4534).</see>
    public static readonly LocalizedStrings GlamourDresserProjectionAdded = new()
    {
        Jpn = ["を幻影化して", "ミラージュドレッサーに保管しました"],
        Eng = ["projection", "added", "glamour dresser"],
        Deu = ["projektion", "kommode", "gelegt"],
        Fra = ["transformé", "mirage", "coiffeuse"]
    };
    /// <see href="https://xivapi.com/LogMessage/4381?pretty=true">Projection removed from glamour dresser.</see>
    public static readonly LocalizedStrings GlamourDresserProjectionRemoved = new()
    {
        Jpn = ["ミラージュドレッサーから", "の幻影を破棄しました"],
        Eng = ["projection", "removed", "glamour dresser"],
        Deu = ["projektion", "kommode", "entfernt"],
        Fra = ["effacé", "mirage", "coiffeuse"]
    };
    /// <see href="https://xivapi.com/LogMessage/4383?pretty=true">Projection restored and removed from glamour dresser.</see>
    public static readonly LocalizedStrings GlamourDresserProjectionRestored = new()
    {
        Jpn = ["の幻影をアイテムに戻し", "ミラージュドレッサーから取り出した"],
        Eng = ["projection", "restored", "glamour dresser"],
        Deu = ["projektion", "zurückverwandelt", "entfernt"],
        Fra = ["retransformé", "mirage", "coiffeuse"]
    };
    /// <see href="https://xivapi.com/LogMessage/?pretty=true">Other glamour dresser projection lines (7.1+).</see>
    public static readonly LocalizedStrings GlamourDresserProjection = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["projection", "glamour dresser"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/624?pretty=true">You store … in the armoire.</see>
    public static readonly LocalizedStrings GlamourArmoireStore = new()
    {
        Jpn = ["を愛蔵品キャビネットの", "へ収納した"],
        Eng = ["store", "armoire"],
        Deu = ["kostbarkeitenkabinett", "abgelegt"],
        Fra = ["remisez", "bahut", "personnel"]
    };
    /// <see href="https://xivapi.com/LogMessage/625?pretty=true">You withdraw … from the armoire.</see>
    public static readonly LocalizedStrings GlamourArmoireWithdraw = new()
    {
        Jpn = ["を取り出した"],
        Eng = ["withdraw", "armoire"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4364?pretty=true">Glamours projected from plate N.</see>
    public static readonly LocalizedStrings GlamourPlateProjected = new()
    {
        Jpn = ["ミラージュプレート"],
        Eng = ["glamours", "projected", "plate"],
        Deu = ["projektionsplatte"],
        Fra = ["planche", "mirage", "projetée"]
    };
    /// <see href="https://xivapi.com/LogMessage/4378?pretty=true">Glamour plate partial apply error.</see>
    public static readonly LocalizedStrings TryOnGlamourPartialApply = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["glamour", "plate", "partially"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/1900?pretty=true">… equipped, but glamours could not be restored.</see>
    public static readonly LocalizedStrings GearsetGlamourRestoreFailed = new()
    {
        Jpn = ["ギアセット", "に装備変更しましたが", "武具投影の異なる装備品が適用されました"],
        Eng = ["equipped", "glamours", "could", "not", "restored"],
        Deu = ["ausrüstungsset", "projektion", "ursprünglich"],
        Fra = ["équipée", "plusieurs", "différents"]
    };

    /// <see href="https://xivapi.com/LogMessage/744?pretty=true">Your spiritbond with … is complete!</see>
    public static readonly LocalizedStrings SpiritboundGear = new()
    {
        Jpn = ["錬精度"],
        Eng = ["spiritbond"],
        Deu = ["bindung"],
        Fra = ["symbiose"]
    };
    /// <see href="https://xivapi.com/LogMessage/1388?pretty=true">N items repaired.</see>
    public static readonly LocalizedStrings GearItemsRepairedBulk = new()
    {
        Jpn = ["修理"],
        Eng = ["items", "repaired"],
        Deu = ["gegenstände", "repariert"],
        Fra = ["objets", "réparé"]
    };
    /// <see href="https://xivapi.com/LogMessage/5865?pretty=true">Portrait set as instant portrait.</see>
    public static readonly LocalizedStrings PortraitSetInstant = new()
    {
        Jpn = ["ポートレート"],
        Eng = ["portrait", "instant"],
        Deu = ["portrait", "schnellportrait"],
        Fra = ["portrait", "instantané"]
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

}
