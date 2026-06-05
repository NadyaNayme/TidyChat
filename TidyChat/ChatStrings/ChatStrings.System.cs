using TidyChat.Translation.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/1350?pretty=true">/instance text</see>
    public static readonly LocalizedStrings InstancedArea = new()
    {
        Jpn = ["で現在のインスタンスを再確認できます。"],
        Eng = ["you", "are", "now", "in", "the", "instanced", "area"],
        Deu = ["instanziierten", "areal"],
        Fra = ["dans", "quelle", "instance", "vous", "trouvez"]
    };

    /// <see href="https://xivapi.com/LogMessage/926?pretty=true">Received Player Commendation</see>
    public static readonly LocalizedStrings PlayerCommendation = new()
    {
        Jpn = ["mip", "推薦を獲得しました"],
        Eng = ["you", "received", "a", "player", "commendation"],
        Deu = ["hast", "die", "auszeichnung"],
        Fra = ["équipiers", "vous", "honoré"]
    };

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

    /// <see href="https://xivapi.com/LogMessage/1885?pretty=true">You have received a free company invite from …</see>
    public static readonly LocalizedStrings FreeCompanyInviteReceived = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["free", "company", "invite", "received"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1895?pretty=true">Free company invite from … canceled.</see>
    public static readonly LocalizedStrings FreeCompanyInviteCanceled = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["free", "company", "invite", "canceled"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/3127?pretty=true">Company action "…" is no longer active.</see>
    public static readonly LocalizedStrings CompanyActionExpired = new()
    {
        Jpn = ["カンパニーアクション", "終了"],
        Eng = ["company", "action", "no", "longer", "active"],
        Deu = ["gesellschaftskommandos", "geendet"],
        Fra = ["bienfait", "dissipés"]
    };

    /// <see href="https://xivapi.com/LogMessage/3791?pretty=true">… initiated a ready check.</see>
    public static readonly LocalizedStrings ReadyCheckInitiated = new()
    {
        Jpn = ["レディチェック", "開始"],
        Eng = ["initiated", "ready", "check"],
        Deu = ["bereitschaftsanfrage", "gestellt"],
        Fra = ["appel", "préparation"]
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
        Eng = ["cast", "glamour"],
        Deu = ["projizierst"],
        Fra = ["projetez", "mirage"]
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

    /// <see href="https://xivapi.com/LogMessage/4341?pretty=true">RetainerName has completed a venture!</see>
    public static readonly LocalizedStrings RetainerVentureComplete = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["completed", "venture"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/4331?pretty=true">You assign your retainer "Quick Exploration."</see>
    public static readonly LocalizedStrings RetainerVentureAssign = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["assign", "retainer"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/4334?pretty=true">You pay RetainerName N ventures.</see>
    public static readonly LocalizedStrings RetainerVenturePayment = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["pay", "venture"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/4332?pretty=true">"Lv. …" is now complete.</see>
    public static readonly LocalizedStrings RetainerVentureItemComplete = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["now", "complete"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/6057?pretty=true">Submersible has embarked on a subaquatic voyage.</see>
    public static readonly LocalizedStrings SubaquaticVoyageEmbarked = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["embarked", "subaquatic", "voyage"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/6059?pretty=true">Submersible subaquatic voyage finalized.</see>
    /// <seealso href="https://xivapi.com/LogMessage/6060?pretty=true">Other player finalizes subaquatic voyage.</seealso>
    public static readonly LocalizedStrings SubaquaticVoyageFinalized = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["subaquatic", "voyage", "finaliz"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/4168?pretty=true">Submarine part has been repaired.</see>
    public static readonly LocalizedStrings SubmarinePartRepaired = new()
    {
        Jpn = ["潜水艦", "修理"],
        Eng = ["submarine", "part", "repaired"],
        Deu = ["tauchboot", "repariert"],
        Fra = ["sous-marin", "réparé"]
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

    /// <see href="https://xivapi.com/LogMessage/6062?pretty=true">Submersible attains rank N!</see>
    public static readonly LocalizedStrings SubmarineAttainsRank = new()
    {
        Jpn = ["ランク", "潜水艦"],
        Eng = ["attains", "rank"],
        Deu = ["rang", "tauchboot"],
        Fra = ["sous-marin", "rang"]
    };

    /// <see href="https://xivapi.com/LogMessage/6092?pretty=true">Submersible's retrieval levels increased by N.</see>
    public static readonly LocalizedStrings SubmarineRetrievalLevelsIncreased = new()
    {
        Jpn = ["潜水艦", "上昇"],
        Eng = ["retrieval", "levels"],
        Deu = ["tauchboot", "gestiegen"],
        Fra = ["sous-marin", "augmenté"]
    };

    /// <see href="https://xivapi.com/LogMessage/4335?pretty=true">Retainer has reached maximum level.</see>
    public static readonly LocalizedStrings RetainerMaxLevel = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["reached", "maximum", "level", "retainer"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage">Matched via formatted chat text (not a LogMessage row)</see>
    public static readonly LocalizedStrings SayQuestReminder = new()
    {
        Jpn = ["チャットの会話モードを"],
        Eng = ["with", "the", "chat", "mode", "in", "enter", "phrase", "containing"],
        Deu = ["gib", "im", "virtuelle", "tastatur"],
        Fra = ["en", "mode", "de", "discussion"]
    };

    public static readonly LocalizedStrings JoinParty = new()
    {
        Jpn = ["パーティー", "参加"],
        Eng = ["you", "join"],
        Deu = ["trittst", "gruppe"],
        Fra = ["vous", "rejoignez", "l'équipe"]
    };

    /// <see href="https://xivapi.com/LogMessage/7444?pretty=true">Cross-world party formed.</see>
    public static readonly LocalizedStrings CrossWorldPartyFormed = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["cross-world", "party", "formed"],
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

    /// <see href="https://xivapi.com/LogMessage/897?pretty=true">Duty registration complete.</see>
    public static readonly LocalizedStrings DutyRegistrationComplete = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["duty", "registration", "complete"],
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

    /// <see href="https://xivapi.com/LogMessage/7242?pretty=true">The Cairn of Passage begins to glow!</see>
    public static readonly LocalizedStrings CairnGlows = new()
    {
        Jpn = ["輝き"],
        Eng = ["begins", "glow"],
        Deu = ["leuchten"],
        Fra = ["briller"]
    };

    /// <see href="https://xivapi.com/LogMessage/7243?pretty=true">The Cairn of Return restores life …</see>
    public static readonly LocalizedStrings CairnRestoresLife = new()
    {
        Jpn = ["生気"],
        Eng = ["restores", "life", "fallen"],
        Deu = ["wiederbelebt"],
        Fra = ["remettant", "pied"]
    };

    /// <see href="https://xivapi.com/LogMessage/7245?pretty=true">The Cairn of Passage is activated!</see>
    public static readonly LocalizedStrings CairnActivates = new()
    {
        Jpn = ["起動"],
        Eng = ["activated"],
        Deu = ["aktiviert"],
        Fra = ["activé"]
    };

    /// <see href="https://xivapi.com/LogMessage/7246?pretty=true">Transference message.</see>
    public static readonly LocalizedStrings Transference = new()
    {
        Jpn = ["転移"],
        Eng = ["transference"],
        Deu = ["transfer"],
        Fra = ["transfert"]
    };

    /// <see href="https://xivapi.com/LogMessage/7250?pretty=true">Aetherpool arm/armor strength increase.</see>
    public static readonly LocalizedStrings AetherpoolIncrease = new()
    {
        Jpn = ["強化値"],
        Eng = ["strength"],
        Deu = ["verstärkung"],
        Fra = ["amélioration"]
    };

    /// <see href="https://xivapi.com/LogMessage/7251?pretty=true">Aetherpool strength unchanged.</see>
    public static readonly LocalizedStrings AetherpoolUnchanged = new()
    {
        Jpn = ["変わら"],
        Eng = ["unchanged"],
        Deu = ["unverändert"],
        Fra = ["inchangé"]
    };

    /// <see href="https://xivapi.com/LogMessage/7220?pretty=true">You obtain a pomander of …</see>
    public static readonly LocalizedStrings ObtainedPomander = new()
    {
        Jpn = ["ポマンダー"],
        Eng = ["obtain", "pomander"],
        Deu = ["pomander"],
        Fra = ["obtenu"]
    };

    /// <see href="https://xivapi.com/LogMessage/7254?pretty=true">Pomander effect message.</see>
    public static readonly LocalizedStrings PomanderEffect = new()
    {
        Jpn = ["ポマンダー"],
        Eng = ["pomander"],
        Deu = ["pomander"],
        Fra = ["pomander"]
    };

    /// <see href="https://xivapi.com/LogMessage/7224?pretty=true">The landmine is triggered...</see>
    public static readonly LocalizedStrings DeepDungeonLandmineTriggered = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["landmine", "triggered"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/7225?pretty=true">The luring trap is triggered...</see>
    public static readonly LocalizedStrings DeepDungeonTrapTriggered = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["trap", "triggered"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    /// <see href="https://xivapi.com/LogMessage/7229?pretty=true">
    ///     The detonator is triggered! The treasure coffer is no
    ///     more...
    /// </see>
    public static readonly LocalizedStrings DeepDungeonDetonatorTriggered = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["detonator", "triggered"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/9218?pretty=true">Floor N</see>
    public static readonly LocalizedStrings FloorNumber = new()
    {
        Jpn = ["層"],
        Eng = ["floor"],
        Deu = ["ebene"],
        Fra = ["étage"]
    };

    /// <see href="https://xivapi.com/LogMessage/7249?pretty=true">The current duty uses an independent leveling system.</see>
    public static readonly LocalizedStrings DeepDungeonIndependentLeveling = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["independent", "leveling", "system"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/7272?pretty=true">You sense the Accursed Hoard calling you…</see>
    public static readonly LocalizedStrings SenseAccursedHoard = new()
    {
        Jpn = ["財宝"],
        Eng = ["accursed", "hoard"],
        Deu = ["schatz"],
        Fra = ["trésor", "caché"]
    };

    /// <see href="https://xivapi.com/LogMessage/7273?pretty=true">You do not sense the call of the Accursed Hoard …</see>
    public static readonly LocalizedStrings NoAccursedHoard = new()
    {
        Jpn = ["財宝", "なさ"],
        Eng = ["do", "not", "sense", "accursed", "hoard"],
        Deu = ["kein", "schatz"],
        Fra = ["pas", "trésor"]
    };

    /// <see href="https://xivapi.com/LogMessage/7274?pretty=true">You discover a piece of the Accursed Hoard!</see>
    public static readonly LocalizedStrings DiscoverAccursedHoard = new()
    {
        Jpn = ["財宝", "発見"],
        Eng = ["discover", "accursed", "hoard"],
        Deu = ["verborgener", "schatz"],
        Fra = ["découvert", "trésor"]
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

    /// <see href="https://xivapi.com/LogMessage/1?pretty=true">You invite … to a party.</see>
    public static readonly LocalizedStrings InviteSent = new()
    {
        Jpn = ["誘い"],
        Eng = ["invite"],
        Deu = ["eingeladen"],
        Fra = ["invitez"]
    };

    /// <see href="https://xivapi.com/LogMessage/3?pretty=true">… invites you to a party.</see>
    public static readonly LocalizedStrings InvitedBy = new()
    {
        Jpn = ["誘われ"],
        Eng = ["invites", "party"],
        Deu = ["eingeladen"],
        Fra = ["invite"]
    };

    /// <see href="https://xivapi.com/LogMessage/60?pretty=true">… joins the party.</see>
    public static readonly LocalizedStrings InviteeJoins = new()
    {
        Jpn = ["参加"],
        Eng = ["join", "party"],
        Deu = ["beigetreten"],
        Fra = ["rejoint", "équipe"]
    };

    /// <see href="https://xivapi.com/LogMessage/4?pretty=true">You leave the party.</see>
    /// <seealso href="https://xivapi.com/LogMessage/69?pretty=true">… has left the party.</seealso>
    public static readonly LocalizedStrings LeftParty = new()
    {
        Jpn = ["離脱"],
        Eng = ["leave", "party"],
        Deu = ["verlassen"],
        Fra = ["quittez", "équipe"]
    };

    /// <see href="https://xivapi.com/LogMessage/73?pretty=true">The party has been disbanded.</see>
    public static readonly LocalizedStrings PartyDisband = new()
    {
        Jpn = ["解散"],
        Eng = ["disbanded"],
        Deu = ["aufgelöst"],
        Fra = ["dissoute"]
    };

    /// <see href="https://xivapi.com/LogMessage/72?pretty=true">You dissolve the party.</see>
    public static readonly LocalizedStrings PartyDissolved = new()
    {
        Jpn = ["解散"],
        Eng = ["dissolve", "party"],
        Deu = ["aufgelöst"],
        Fra = ["dissoute"]
    };

    /// <see href="https://xivapi.com/LogMessage/3790?pretty=true">You have commenced a ready check.</see>
    /// <seealso href="https://xivapi.com/LogMessage/3794?pretty=true">Ready check complete.</seealso>
    public static readonly LocalizedStrings ReadyCheck = new()
    {
        Jpn = ["レディチェック"],
        Eng = ["ready", "check"],
        Deu = ["bereitschaft"],
        Fra = ["préparation"]
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

    /// <see href="https://xivapi.com/LogMessage/5260?pretty=true">Battle commencing in …</see>
    /// <seealso href="https://xivapi.com/LogMessage/5255?pretty=true">Battle commencing in … (party countdown)</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/5256?pretty=true">Engage!</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/5264?pretty=true">Engage!</seealso>
    public static readonly LocalizedStrings CountdownTime = new()
    {
        Jpn = ["戦闘"],
        Eng = ["commencing", "engage"],
        Deu = ["sekunde", "start"],
        Fra = ["combat", "attaque"]
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

    /// <see href="https://xivapi.com/LogMessage/440?pretty=true">You have been offered a Teleport …</see>
    public static readonly LocalizedStrings OfferedTeleport = new()
    {
        Jpn = ["テレポ"],
        Eng = ["teleport"],
        Deu = ["teleport"],
        Fra = ["téléporter"]
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

    /// <see href="https://xivapi.com/LogMessage/4735?pretty=true">Jumbo Cactpot ticket purchase (MGP spend).</see>
    public static readonly LocalizedStrings JumboCactpotTicketPurchase = new()
    {
        Jpn = ["mgp", "くじ"],
        Eng = ["mgp", "cactpot"],
        Deu = ["mgp", "gekauft"],
        Fra = ["pgs", "billet"]
    };
}
