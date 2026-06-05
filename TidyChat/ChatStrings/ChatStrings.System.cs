using TidyChat.Translation.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/1534?pretty=true">Duty has ended</see>
    public static readonly LocalizedStrings DutyEnded = new()
    {
        Jpn = ["の攻略を終了した"],
        Eng = ["has", "ended"],
        Deu = ["wurde", "beendet"],
        Fra = ["prend", "fin"]
    };
    /// <see href="https://xivapi.com/LogMessage/1531?pretty=true">Duty has begun.</see>
    public static readonly LocalizedStrings DutyHasBegun = new()
    {
        Jpn = ["開始"],
        Eng = ["has", "begun"],
        Deu = ["hat", "begonnen"],
        Fra = ["commencé"]
    };
    /// <see href="https://xivapi.com/LogMessage/9602?pretty=true">This duty is level synced…</see>
    public static readonly LocalizedStrings DutyLevelSyncedBriefing = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["duty", "level", "synced", "participants", "adjusted"],
        Deu = ["stufe", "synchronisiert", "teilnehmer"],
        Fra = ["mission", "niveau", "synchronisé", "participants"]
    };
    /// <see href="https://xivapi.com/LogMessage/618?pretty=true">Your level has been synced to N.</see>
    public static readonly LocalizedStrings DutyPlayerLevelSynced = new()
    {
        Jpn = ["シンク"],
        Eng = ["level", "synced"],
        Deu = ["stufe", "herabgesetzt"],
        Fra = ["niveau", "synchronisé"]
    };
    /// <see href="https://xivapi.com/LogMessage/4224?pretty=true">Your item level has been synced…</see>
    public static readonly LocalizedStrings DutyItemLevelSynced = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["item", "level", "synced", "stats", "adjusted"],
        Deu = ["gegenstandsstufe", "synchronisiert"],
        Fra = ["niveau", "objets", "synchronisé"]
    };
    /// <see href="https://xivapi.com/LogMessage/9795?pretty=true">Alliance temporarily disbanded…</see>
    public static readonly LocalizedStrings DutyAllianceReformNotice = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["reform", "parties", "alliance", "temporarily"],
        Deu = ["gruppen", "allianz", "vorübergehend"],
        Fra = ["groupes", "alliance", "temporairement"]
    };
    /// <see href="https://xivapi.com/LogMessage/619?pretty=true">Your level is no longer synced.</see>
    public static readonly LocalizedStrings LevelNoLongerSynced = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["no", "longer", "synced"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/2163?pretty=true">Duty objectives completion bonus.</see>
    public static readonly LocalizedStrings DutyObjectiveBonus = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["objectives", "bonus"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/88?pretty=true">Location discovered.</see>
    public static readonly LocalizedStrings LocationDiscovered = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["discovered"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/10508?pretty=true">You use a pot of … dye to change Dye N of … to …</see>
    public static readonly LocalizedStrings GearDyeApplied = new()
    {
        Jpn = ["染め"],
        Eng = ["use", "dye", "change"],
        Deu = ["farbe", "benutzt"],
        Fra = ["teignez", "teinture"]
    };
    /// <see href="https://xivapi.com/LogMessage/4309?pretty=true">You cast a glamour …</see>
    public static readonly LocalizedStrings TryOnGlamourCast = new()
    {
        Jpn = ["武器投影"],
        Eng = [" a glamour"],
        Deu = ["projizierst"],
        Fra = ["un mirage"]
    };
    /// <see href="https://xivapi.com/LogMessage/?pretty=true">Outfit glamour stored in dresser (7.1+).</see>
    public static readonly LocalizedStrings GlamourOutfitStored = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["stored as", "outfit glamour"],
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
    /// <see href="https://xivapi.com/LogMessage/1530?pretty=true">Guildhest will end soon</see>
    public static readonly LocalizedStrings GuildhestEnded = new()
    {
        Jpn = ["全員が特務隊長から報酬を受け取る"],
        Eng = ["the", "guildhest", "will", "end", "soon"],
        Deu = ["das", "gildengeheiß", "endet", "alle", "teilnehmer"],
        Fra = ["guilde", "allez", "quitter"]
    };
    /// <see href="https://xivapi.com/LogMessage/1388?pretty=true">N items repaired.</see>
    public static readonly LocalizedStrings GearItemsRepairedBulk = new()
    {
        Jpn = ["修理"],
        Eng = ["items", "repaired"],
        Deu = ["gegenstände", "repariert"],
        Fra = ["objets", "réparé"]
    };
    /// <see href="https://xivapi.com/LogMessage/1385?pretty=true">Item is repaired.</see>
    public static readonly LocalizedStrings GearItemRepairedSingle = new()
    {
        Jpn = ["修理"],
        Eng = ["is", "repaired"],
        Deu = ["wurde", "repariert"],
        Fra = ["été", "réparé"]
    };
    /// <see href="https://xivapi.com/LogMessage">Matched via formatted chat text (not a LogMessage row)</see>
    public static readonly LocalizedStrings SayQuestReminder = new()
    {
        Jpn = ["チャットの会話モードを"],
        Eng = ["with", "the", "chat", "mode", "in", "enter", "phrase", "containing"],
        Deu = ["gib", "im", "virtuelle", "tastatur"],
        Fra = ["en", "mode", "de", "discussion"]
    };
    /// <see href="https://xivapi.com/LogMessage/4321?pretty=true">You desynthesize …</see>
    public static readonly LocalizedStrings DesynthedItem = new()
    {
        Jpn = ["分解"],
        Eng = ["you", "desynthesize"],
        Deu = ["verwertet"],
        Fra = ["recyclez"]
    };
    /// <see href="https://xivapi.com/LogMessage/4322?pretty=true">You obtain … (desynthesis).</see>
    public static readonly LocalizedStrings DesynthesisObtain = new()
    {
        Jpn = ["手に入れ"],
        Eng = ["you", "obtain"],
        Deu = ["erhalten"],
        Fra = ["obtenez"]
    };
    /// <see href="https://xivapi.com/LogMessage/4225?pretty=true">First-clear bonus duty message.</see>
    public static readonly LocalizedStrings FirstClearBonus = new()
    {
        Jpn = ["未制覇", "ボーナス"],
        Eng = ["party", "members", "complete", "duty"],
        Deu = ["inhalt", "noch", "nicht", "beendet"],
        Fra = ["participants", "accompli", "mission"]
    };
    /// <see href="https://xivapi.com/LogMessage/4402?pretty=true">Relic book step progress.</see>
    public static readonly LocalizedStrings RelicBookStep = new()
    {
        Jpn = ["黄道"],
        Eng = ["record", "kill"],
        Deu = ["beseitigt"],
        Fra = ["notez", "livre"]
    };
    /// <see href="https://xivapi.com/LogMessage/4400?pretty=true">Relic book category complete.</see>
    public static readonly LocalizedStrings RelicBookComplete = new()
    {
        Jpn = ["コンプリート"],
        Eng = ["objectives", "complete"],
        Deu = ["erfüllt"],
        Fra = ["accompli", "épreuves"]
    };
    /// <see href="https://xivapi.com/LogMessage/732?pretty=true">You have entered a sanctuary.</see>
    /// <seealso href="https://xivapi.com/LogMessage/733?pretty=true">You have left the sanctuary.</seealso>
    public static readonly LocalizedStrings SanctuaryMessage = new()
    {
        Jpn = ["レストエリア"],
        Eng = ["sanctuary"],
        Deu = ["ruhebereich"],
        Fra = ["repos"]
    };
    /// <see href="https://xivapi.com/LogMessage/3379?pretty=true">Housing ward entry.</see>
    public static readonly LocalizedStrings HousingWardMessage = new()
    {
        Jpn = ["区"],
        Eng = ["ward"],
        Deu = ["bezirk"],
        Fra = ["secteur"]
    };
    /// <see href="https://xivapi.com/LogMessage/2600?pretty=true">You sense something foul …</see>
    /// <seealso href="https://xivapi.com/LogMessage/4791?pretty=true">You sense something close.</seealso>
    public static readonly LocalizedStrings SpideySenses = new()
    {
        Jpn = ["感じ"],
        Eng = ["sense"],
        Deu = ["spürst"],
        Fra = ["percevez"]
    };
    /// <see href="https://xivapi.com/LogMessage/3240?pretty=true">You sense a hostile presence!</see>
    public static readonly LocalizedStrings HostilePresence = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["hostile", "presence"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/3712?pretty=true">The compass detects a current …</see>
    public static readonly LocalizedStrings AetherCompass = new()
    {
        Jpn = ["コンパス"],
        Eng = ["compass"],
        Deu = ["kompass"],
        Fra = ["boussole"]
    };
    /// <see href="https://xivapi.com/LogMessage/744?pretty=true">Your spiritbond with … is complete!</see>
    public static readonly LocalizedStrings SpiritboundGear = new()
    {
        Jpn = ["錬精度"],
        Eng = ["spiritbond"],
        Deu = ["bindung"],
        Fra = ["symbiose"]
    };
    /// <see href="https://xivapi.com/LogMessage/7975?pretty=true">Second Chance points added …</see>
    public static readonly LocalizedStrings SecondChanceAward = new()
    {
        Jpn = ["チャンスポイント"],
        Eng = ["second", "chance"],
        Deu = ["chance-punkte"],
        Fra = ["points", "chance"]
    };
    /// <see href="https://xivapi.com/LogMessage/605?pretty=true">Boss mechanic event (e.g. Titan's heart is shattered!).</see>
    public static readonly LocalizedStrings DutyMechanicEvent = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["shattered"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/2119?pretty=true">Garuda generates a pocket of calm within the storm!</see>
    public static readonly LocalizedStrings DutyMechanicCalmPocket = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["generates", "pocket", "calm"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
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
    /// <see href="https://xivapi.com/LogMessage/5874?pretty=true">
    ///     Portrait has expired. Please readjust its settings and try
    ///     again.
    /// </see>
    public static readonly LocalizedStrings PortraitExpired = new()
    {
        Jpn = ["ポートレート", "期限"],
        Eng = ["portrait", "expired"],
        Deu = ["portrait", "abgelaufen"],
        Fra = ["portrait", "expiré"]
    };
    /// <see href="https://xivapi.com/LogMessage/5886?pretty=true">Unable to update portrait due to incompatible settings.</see>
    public static readonly LocalizedStrings PortraitUpdateIncompatible = new()
    {
        Jpn = ["ポートレート", "更新"],
        Eng = ["update", "portrait", "incompatible"],
        Deu = ["portrait", "aktualisieren", "inkompatibel"],
        Fra = ["portrait", "incompatible"]
    };
    /// <see href="https://xivapi.com/LogMessage/1900?pretty=true">… equipped, but glamours could not be restored.</see>
    public static readonly LocalizedStrings GearsetGlamourRestoreFailed = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["equipped", "glamours", "could", "not", "restored"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/3555?pretty=true">N … sands are obtained.</see>
    public static readonly LocalizedStrings AetherialReductionSands = new()
    {
        Jpn = ["手に入れ"],
        Eng = ["obtained"],
        Deu = ["erhalten"],
        Fra = ["obtenez"]
    };
    /// <see href="https://xivapi.com/LogMessage/3553?pretty=true">You successfully reduce … (Collectability: N).</see>
    public static readonly LocalizedStrings AetherialReductionSuccess = new()
    {
        Jpn = ["精選"],
        Eng = ["successfully", "reduce"],
        Deu = ["raffiniert"],
        Fra = ["éthérolysez"]
    };
    /// <see href="https://xivapi.com/LogMessage/5550?pretty=true">This location grants an increase to item collectability!</see>
    public static readonly LocalizedStrings CollectabilityLocationBonus = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["location", "collectability", "increase"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/3549?pretty=true">You use Brazen Woodsman. Collectability increases by N.</see>
    public static readonly LocalizedStrings BrazenWoodsman = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["brazen", "woodsman", "collectability"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/3569?pretty=true">
    ///     You use Meticulous Woodsman. Collector's intuition guides
    ///     your hand.
    /// </see>
    public static readonly LocalizedStrings MeticulousWoodsman = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["meticulous", "woodsman", "collectability"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/10830?pretty=true">A new mech op directive has been issued.</see>
    public static readonly LocalizedStrings MechOpDirective = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["mech", "directive", "pilots", "application"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/10884?pretty=true">A red alert has been issued.</see>
    /// <seealso href="https://xivapi.com/LogMessage/10881?pretty=true">The red alert has been resolved.</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/10807?pretty=true">Moongate Hub red alert (critical missions).</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/11334?pretty=true">Red alert — critical missions available.</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/11335?pretty=true">Red alert in effect.</seealso>
    public static readonly LocalizedStrings CosmicRedAlert = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["red", "alert"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/5514?pretty=true">
    ///     Your meticulous actions prove effective. Integrity is not
    ///     reduced.
    /// </see>
    /// <see href="https://xivapi.com/LogMessage/5514?pretty=true">
    ///     Your meticulous actions prove effective. Integrity is not
    ///     reduced.
    /// </see>
    /// <seealso href="https://xivapi.com/LogMessage/5574?pretty=true">Revisit restored GP and granted integrity.</seealso>
    public static readonly LocalizedStrings AetherialReductionIntegrity = new()
    {
        Jpn = ["耐久", "減少"],
        Eng = ["integrity", "not", "reduced", "revisit", "gathering point"],
        Deu = ["belastbarkeit"],
        Fra = ["diminué"]
    };
    /// <see href="https://xivapi.com/LogMessage/1629?pretty=true">/isearch match summary.</see>
    /// <seealso href="https://xivapi.com/LogMessage/1438?pretty=true">/isearch location result lines.</seealso>
    public static readonly LocalizedStrings ItemSearchResults = new()
    {
        Jpn = ["含む", "所持"],
        Eng = ["containing", "found"],
        Deu = ["treffer", "inventar"],
        Fra = ["contenant", "inventaire"]
    };

    /// <see href="https://xivapi.com/LogMessage/1438?pretty=true">/isearch location result lines (stowage).</see>
    public static readonly LocalizedStrings LocationSearchStowage = new()
    {
        Jpn = ["あります"],
        Eng = ["found", "in"],
        Deu = ["gefunden"],
        Fra = ["trouvé"]
    };

    /// <see href="https://xivapi.com/LogMessage/1438?pretty=true">/isearch location result lines (equipped).</see>
    public static readonly LocalizedStrings LocationSearchEquipped = new()
    {
        Jpn = ["装備"],
        Eng = ["equipped"],
        Deu = ["angelegt"],
        Fra = ["équipé"]
    };

    /// <see href="https://xivapi.com/LogMessage/1438?pretty=true">/isearch location result lines (total).</see>
    public static readonly LocalizedStrings LocationSearchTotal = new()
    {
        Jpn = ["見つかりました"],
        Eng = ["total", "found"],
        Deu = ["ergab"],
        Fra = ["total"]
    };

    /// <see href="https://xivapi.com/LogMessage/503?pretty=true">Aetheryte ticket ready message.</see>
    public static readonly LocalizedStrings AetheryteTicketReady = new()
    {
        Jpn = ["チケット", "使用"],
        Eng = ["aetheryte", "ticket", "ready"],
        Deu = ["ätheryt", "ticket", "bereit"],
        Fra = ["téléportation", "préparez"]
    };
    /// <see href="https://xivapi.com/LogMessage/535?pretty=true">Aetheryte ticket use message.</see>
    /// <seealso href="https://xivapi.com/LogMessage/4591?pretty=true">Aetheryte ticket used with remaining count (System).</seealso>
    public static readonly LocalizedStrings AetheryteTicketUsed = new()
    {
        Jpn = ["チケット", "使用"],
        Eng = ["aetheryte", "ticket", "used"],
        Deu = ["ätheryt", "ticket", "verwendet"],
        Fra = ["téléportation", "utilise"]
    };
    /// <see href="https://xivapi.com/LogMessage/1341?pretty=true">You attune to the aetheryte.</see>
    public static readonly LocalizedStrings AttuneAetheryte = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["attune", "aetheryte"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4242?pretty=true">Changes discarded.</see>
    public static readonly LocalizedStrings ChangesDiscarded = new()
    {
        Jpn = ["破棄"],
        Eng = ["changes", "discarded"],
        Deu = ["verworfen"],
        Fra = ["annulés"]
    };
    /// <see href="https://xivapi.com/LogMessage/802?pretty=true">Changes lost.</see>
    public static readonly LocalizedStrings ChangesLost = new()
    {
        Jpn = ["失わ"],
        Eng = ["changes", "lost"],
        Deu = ["verloren"],
        Fra = ["perdues"]
    };
    /// <see href="https://xivapi.com/LogMessage/4763?pretty=true">Triple Triad matches allowed in current area.</see>
    public static readonly LocalizedStrings TripleTriadAllowed = new()
    {
        Jpn = ["トリプルトライアド"],
        Eng = ["triple", "triad", "allowed"],
        Deu = ["triple", "triad", "erlaubt"],
        Fra = ["triple", "triad", "autorisées"]
    };
    /// <see href="https://xivapi.com/LogMessage/4764?pretty=true">Triple Triad matches not allowed in current area.</see>
    public static readonly LocalizedStrings TripleTriadNotAllowed = new()
    {
        Jpn = ["トリプルトライアド"],
        Eng = ["triple", "triad", "not", "allowed"],
        Deu = ["triple", "triad", "nicht", "erlaubt"],
        Fra = ["triple", "triad", "interdites"]
    };

}
