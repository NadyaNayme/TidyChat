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

    /// <see href="https://xivapi.com/LogMessage/2060?pretty=true">The firesand is set.</see>
    public static readonly LocalizedStrings DungeonFiresandSet = new()
    {
        Jpn = ["爆薬をセットした"],
        Eng = ["firesand", "set"],
        Deu = ["sprengstoff", "eingefüllt"],
        Fra = ["poudre", "mise", "place"]
    };

    /// <see href="https://xivapi.com/LogMessage/2065?pretty=true">Shaft E1 is now clear.</see>
    /// <seealso href="https://xivapi.com/LogMessage/2061?pretty=true">Shaft B4 is now clear.</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/2062?pretty=true">Shaft E2 can now be accessed.</seealso>
    public static readonly LocalizedStrings DungeonShaftClear = new()
    {
        Jpn = ["の落石を崩した"],
        Eng = ["shaft", "clear"],
        Deu = ["stollen", "geröll"],
        Fra = ["puits", "dégagé"]
    };
    /// <see href="https://xivapi.com/LogMessage/9602?pretty=true">This duty is level synced…</see>
    public static readonly LocalizedStrings DutyLevelSyncedBriefing = new()
    {
        Jpn = ["特殊なレベルシンクが適用されました", "このコンテンツの攻略中は"],
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
        Jpn = ["アイテムレベルシンク中は", "すべての装備品の性能が", "アイテムレベルシンク以下になるように調整されます"],
        Eng = ["item", "level", "synced", "stats", "adjusted"],
        Deu = ["gegenstandsstufe", "synchronisiert"],
        Fra = ["niveau", "objets", "synchronisé"]
    };
    /// <see href="https://xivapi.com/LogMessage/9795?pretty=true">Alliance temporarily disbanded…</see>
    public static readonly LocalizedStrings DutyAllianceReformNotice = new()
    {
        Jpn = ["このコンテンツでは", "パーティを編成し直すことが可能です", "アライアンスは一時的に解除されます"],
        Eng = ["reform", "parties", "alliance", "temporarily"],
        Deu = ["gruppen", "allianz", "vorübergehend"],
        Fra = ["groupes", "alliance", "temporairement"]
    };
    /// <see href="https://xivapi.com/LogMessage/619?pretty=true">Your level is no longer synced.</see>
    public static readonly LocalizedStrings LevelNoLongerSynced = new()
    {
        Jpn = ["レベルシンクが解除されました"],
        Eng = ["no", "longer", "synced"],
        Deu = ["stufenanpassung", "wieder", "aufgehoben"],
        Fra = ["synchronisation", "niveau", "pris"]
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
    /// <see href="https://xivapi.com/LogMessage/94?pretty=true">Of the N parties / The only party currently recruiting…</see>
    public static readonly LocalizedStrings DutyFinderRecruitment = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["currently", "recruiting"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    /// <see href="https://xivapi.com/LogMessage/979?pretty=true">Party recruitment commenced.</see>
    public static readonly LocalizedStrings PartyRecruitmentCommenced = new()
    {
        Jpn = ["パーティ募集を開始しました"],
        Eng = ["party", "recruitment", "commenced"],
        Deu = ["gruppensuche", "begonnen"],
        Fra = ["recrutement", "équipiers", "commencé"]
    };
    /// <see href="https://xivapi.com/LogMessage/981?pretty=true">Party recruitment ended.</see>
    public static readonly LocalizedStrings PartyRecruitmentEnded = new()
    {
        Jpn = ["パーティ募集を終了しました"],
        Eng = ["party", "recruitment", "ended"],
        Deu = ["gruppensuche", "beendet"],
        Fra = ["recrutement", "équipiers", "terminé"]
    };
    /// <see href="https://xivapi.com/LogMessage/4670?pretty=true">Participation requirements are as follows:</see>
    public static readonly LocalizedStrings DutyFinderParticipation = new()
    {
        Jpn = ["参加条件を下記の内容に設定しました"],
        Eng = ["participation", "requirements"],
        Deu = ["teilnahmebedingungen", "folgt", "festgelegt"],
        Fra = ["conditions", "participation", "suivantes"]
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
        Jpn = ["下限アイテムレベルでの参加"],
        Eng = ["minimum", "il", "active"],
        Deu = ["anpassung", "mindest", "gegenstandsstufe"],
        Fra = ["niveau", "minimum", "appliqué"]
    };
    /// <see href="https://xivapi.com/LogMessage/4681?pretty=true">Registration Language:</see>
    public static readonly LocalizedStrings DutyFinderRegistrationLanguage = new()
    {
        Jpn = ["参加申請時の言語設定"],
        Eng = ["registration", "language"],
        Deu = ["sprache", "registrierung"],
        Fra = ["langue", "choisie"]
    };
    /// <see href="https://xivapi.com/LogMessage/4682?pretty=true">Language set to the following:</see>
    public static readonly LocalizedStrings DutyFinderLanguageSet = new()
    {
        Jpn = ["言語設定を下記の内容に設定しました"],
        Eng = ["language", "set", "following"],
        Deu = ["gewählte", "spracheinstellungen"],
        Fra = ["paramètres", "langue", "modifiés"]
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
        Deu = ["teilnahme", "zurückgezogen", "durchgeführt"],
        Fra = ["participants", "effectuer", "recherche"]
    };
    /// <see href="https://xivapi.com/LogMessage/897?pretty=true">Duty registration complete.</see>
    public static readonly LocalizedStrings DutyRegistrationComplete = new()
    {
        Jpn = ["コンテンツ参加申請を行いました"],
        Eng = ["duty", "registration", "complete"],
        Deu = ["registrierung", "durchgeführt"],
        Fra = ["enregistrement", "participer", "effectué"]
    };
    /// <see href="https://xivapi.com/LogMessage/4676?pretty=true">Commencing duty with an unrestricted party…</see>
    public static readonly LocalizedStrings DutyUnrestrictedCommence = new()
    {
        Jpn = ["でコンテンツに参加しました", "モンスターからの報酬や経験値", "錬精度はレベルシンク状態でのみ得られるようになります"],
        Eng = ["commencing", "unrestricted", "party"],
        Deu = ["beschränkung", "stufenanpassung", "gegenstände"],
        Fra = ["participer", "restriction", "synchronisation"]
    };
    /// <see href="https://xivapi.com/LogMessage/4218?pretty=true">Echo strength after defeats…</see>
    public static readonly LocalizedStrings EchoStrength = new()
    {
        Jpn = ["このコンテンツは", "全滅する度に徐々にキャラクターを強化する", "バフステータスが付与される状態になっています"],
        Eng = ["echo", "strength"],
        Deu = ["kampfunfähig", "stärkender", "angewendet"],
        Fra = ["mission", "confère", "puissant"]
    };
    /// <see href="https://xivapi.com/LogMessage/4248?pretty=true">Entered duty with Unrestricted Party option…</see>
    public static readonly LocalizedStrings EnteredUnrestrictedDuty = new()
    {
        Jpn = ["による突入によってバフステータスが付与されました", "および最大ｈｐが", "上昇しています"],
        Eng = ["entered", "unrestricted", "party"],
        Deu = ["beschränkungen", "ausgeteilter", "regenerationseffekte"],
        Fra = ["participer", "restriction", "bénéfique"]
    };
}
