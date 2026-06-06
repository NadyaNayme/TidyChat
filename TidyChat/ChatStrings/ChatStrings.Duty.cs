using TidyChat.Localization.Data;
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
    /// <see href="https://xivapi.com/LogMessage/1530?pretty=true">Guildhest will end soon</see>
    public static readonly LocalizedStrings GuildhestEnded = new()
    {
        Jpn = ["全員が特務隊長から報酬を受け取る"],
        Eng = ["the", "guildhest", "will", "end", "soon"],
        Deu = ["das", "gildengeheiß", "endet", "alle", "teilnehmer"],
        Fra = ["guilde", "allez", "quitter"]
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
}