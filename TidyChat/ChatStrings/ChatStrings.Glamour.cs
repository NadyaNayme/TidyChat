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
        Jpn = ["NeedsLocalization"],
        Eng = ["try on"],
        Deu = ["NeedsLocalization"],
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
        Jpn = ["NeedsLocalization"],
        Eng = ["stored as", "outfit glamour"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
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
        Jpn = ["NeedsLocalization"],
        Eng = ["projection", "added", "glamour dresser"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4381?pretty=true">Projection removed from glamour dresser.</see>
    public static readonly LocalizedStrings GlamourDresserProjectionRemoved = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["projection", "removed", "glamour dresser"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4383?pretty=true">Projection restored and removed from glamour dresser.</see>
    public static readonly LocalizedStrings GlamourDresserProjectionRestored = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["projection", "restored", "glamour dresser"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
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
        Jpn = ["NeedsLocalization"],
        Eng = ["store", "armoire"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/625?pretty=true">You withdraw … from the armoire.</see>
    public static readonly LocalizedStrings GlamourArmoireWithdraw = new()
    {
        Jpn = ["NeedsLocalization"],
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
        Jpn = ["NeedsLocalization"],
        Eng = ["equipped", "glamours", "could", "not", "restored"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/5701?pretty=true">You acquire the … personal effect.</see>
    public static readonly LocalizedStrings PersonalEffectAcquired = new()
    {
        Jpn = ["修得", "呼び出し"],
        Eng = ["acquire", "personal effect"],
        Deu = ["freigeschaltet"],
        Fra = ["appris"]
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
