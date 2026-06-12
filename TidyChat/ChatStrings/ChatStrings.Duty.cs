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


    /// <see href="https://xivapi.com/LogMessage/94?pretty=true">Of the N parties currently recruiting…</see>
    public static readonly LocalizedStrings DutyFinderRecruitment = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["parties", "recruiting"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/979?pretty=true">Party recruitment commenced.</see>
    public static readonly LocalizedStrings PartyRecruitmentCommenced = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["party", "recruitment", "commenced"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/981?pretty=true">Party recruitment ended.</see>
    public static readonly LocalizedStrings PartyRecruitmentEnded = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["party", "recruitment", "ended"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4670?pretty=true">Participation requirements are as follows:</see>
    public static readonly LocalizedStrings DutyFinderParticipation = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["participation", "requirements"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4671?pretty=true">Join Party in Progress / Unrestricted Party</see>
    public static readonly LocalizedStrings DutyFinderPartyType = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["party", "progress", "unrestricted"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4680?pretty=true">Minimum IL active.</see>
    public static readonly LocalizedStrings DutyFinderMinimumIlActive = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["minimum", "il", "active"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4681?pretty=true">Registration Language:</see>
    public static readonly LocalizedStrings DutyFinderRegistrationLanguage = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["registration", "language"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4682?pretty=true">Language set to the following:</see>
    public static readonly LocalizedStrings DutyFinderLanguageSet = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["language", "set", "following"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/890?pretty=true">Your registration is withdrawn.</see>
    public static readonly LocalizedStrings DutyRegistrationWithdrawn = new()
    {
        Jpn = ["参加申請", "取り消し"],
        Eng = ["registration", "withdrawn"],
        Deu = ["registrierung", "zurückgezogen"],
        Fra = ["enregistrement", "annulé"]
    };
    /// <see href="https://xivapi.com/LogMessage/902?pretty=true">A party member has withdrawn from the duty.</see>
    public static readonly LocalizedStrings PartyMemberDutyWithdrawn = new()
    {
        Jpn = ["パーティメンバー", "取り消"],
        Eng = ["party", "member", "withdrawn", "duty"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/897?pretty=true">Duty registration complete.</see>
    public static readonly LocalizedStrings DutyRegistrationComplete = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["duty", "registration", "complete"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4676?pretty=true">Commencing duty with an unrestricted party…</see>
    public static readonly LocalizedStrings DutyUnrestrictedCommence = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["commencing", "unrestricted", "party"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4218?pretty=true">Echo strength after defeats…</see>
    public static readonly LocalizedStrings EchoStrength = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["echo", "strength"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/4248?pretty=true">Entered duty with Unrestricted Party option…</see>
    public static readonly LocalizedStrings EnteredUnrestrictedDuty = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["entered", "unrestricted", "party"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
}
