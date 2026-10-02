using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/1096?pretty=true">Location affects gathering rate (1096).</see>
    public static readonly LocalizedStrings LocationAffects = new()
    {
        Jpn = ["採集場所", "特質", "獲得率"],
        Eng = ["location", "affects", "gathering", "rate"],
        Deu = ["sammelstelle", "beeinflusst", "sammelrate"],
        Fra = ["propriétés", "lieu", "bonus", "récolte"]
    };

    public static readonly LocalizedStrings LocationCollectabilityIncrease = new()
    {
        Jpn = ["採集場所の特質が", "収集品の収集価値上昇量に影響を及ぼした"],
        Eng = ["location", "grants", "increase", "collectability"],
        Deu = ["sammelstelle", "beeinflusst", "sammlerwerts"],
        Fra = ["propriétés", "augmentation", "collection"]
    };

    /// <see href="https://xivapi.com/LogMessage/5551?pretty=true">
    ///     This location affects the chance your meticulous actions do
    ///     not reduce integrity!
    /// </see>
    public static readonly LocalizedStrings LocationMeticulousIntegrity = new()
    {
        Jpn = ["採集場所の特質が", "慎重純化の追加効果発生率に影響を及ぼした"],
        Eng = ["location", "meticulous", "integrity"],
        Deu = ["sammelstelle", "beeinflusst", "wahrscheinlichkeit"],
        Fra = ["propriétés", "confèrent", "méthodique"]
    };

    public static readonly LocalizedStrings CollectabilityIncreases = new()
    {
        Jpn = ["収集価値が", "上昇した"],
        Eng = ["collectability", "increases"],
        Deu = ["setzt", "sammlerwert", "gestiegen"],
        Fra = ["valeur", "collection", "augmente"]
    };

    public static readonly LocalizedStrings CollectabilityMeticulousIntuition = new()
    {
        Jpn = ["バリューアップ発生", "収集価値が", "上昇した"],
        Eng = ["collector's", "intuition", "collectability", "increases"],
        Deu = ["vertraust", "intuition", "sammlerwert"],
        Fra = ["intuition", "collection", "augmente"]
    };

    public static readonly LocalizedStrings GatheringYield = new()
    {
        Jpn = ["獲得数"],
        Eng = ["gathering", "yield"],
        Deu = ["ertrag"],
        Fra = ["plus", "importantes", "récoltes"]
    };

    /// <see href="https://xivapi.com/LogMessage/1097?pretty=true">
    ///     The location affects your chance of receiving the Gatherer's
    ///     Boon!
    /// </see>
    public static readonly LocalizedStrings GatherersBoon = new()
    {
        Jpn = ["ボーナス"],
        Eng = ["chance", "of", "receiving", "the", "gatherer's", "boon"],
        Deu = ["chancen", "ertrags"],
        Fra = ["plus", "grandes", "chances"]
    };

    /// <see href="https://xivapi.com/LogMessage/11172?pretty=true">You earn a score of N from Gatherer's Boon.</see>
    /// <see href="https://xivapi.com/LogMessage/11173?pretty=true">
    ///     You earn a score of N for achieving M successive chains and
    ///     a score of P from Gatherer's Boon.
    /// </see>
    public static readonly LocalizedStrings GatherersBoonScore = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["earn", "score", "gatherer's", "boon"],
        Deu = ["auslösen", "stückzahl", "erhalten"],
        Fra = ["obtenez", "évaluation", "supplémentaire"]
    };

    /// <see href="https://xivapi.com/LogMessage/1098?pretty=true">
    ///     The location has increased integrity, and affects the number
    ///     of your gathering attempts!
    /// </see>
    public static readonly LocalizedStrings GatheringAttempts = new()
    {
        Jpn = ["耐久", "採集回数"],
        Eng = ["increased", "integrity", "number", "of", "gathering", "attempts"],
        Deu = ["belastbarkeit", "sammelversuche"],
        Fra = ["tentatives", "récolte", "supplémentaires"]
    };

    /// <see href="https://xivapi.com/LogMessage/1063?pretty=true">You begin mining.</see>
    /// <seealso href="https://xivapi.com/LogMessage/1064?pretty=true">You begin quarrying.</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/1065?pretty=true">You begin logging.</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/1066?pretty=true">You begin harvesting.</seealso>
    public static readonly LocalizedStrings GatheringBegin = new()
    {
        Jpn = ["開始"],
        Eng = ["you", "begin"],
        Deu = ["beginnst"],
        Fra = ["commencez"]
    };

    /// <see href="https://xivapi.com/LogMessage/1067?pretty=true">You finish mining.</see>
    /// <seealso href="https://xivapi.com/LogMessage/1068?pretty=true">You finish quarrying.</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/1069?pretty=true">You finish logging.</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/1070?pretty=true">You finish harvesting.</seealso>
    public static readonly LocalizedStrings GatheringFinish = new()
    {
        Jpn = ["終え"],
        Eng = ["you", "finish"],
        Deu = ["fertig"],
        Fra = ["arrêtez"]
    };

    public static readonly LocalizedStrings GatheringSenses = new()
    {
        Jpn = ["感じ"],
        Eng = ["you", "sense"],
        Deu = ["güte"],
        Fra = ["grade"]
    };

    public static readonly LocalizedStrings GatheringNoLongerSense = new()
    {
        Jpn = ["感じられなく"],
        Eng = ["no", "longer", "sense"],
        Deu = ["kannst", "mehr", "wahrnehmen"],
        Fra = ["perdu", "la", "trace"]
    };

    /// <see href="https://xivapi.com/LogMessage/1102?pretty=true">
    ///     You have been granted an additional gathering attempt at
    ///     this mineral deposit.
    /// </see>
    /// <seealso href="https://xivapi.com/LogMessage/1103?pretty=true">
    ///     You have been granted an additional gathering attempt at
    ///     this rocky outcropping.
    /// </seealso>
    public static readonly LocalizedStrings GatheringAttemptGranted = new()
    {
        Jpn = ["採集回数", "復し"],
        Eng = ["granted", "an", "additional", "gathering", "attempt"],
        Deu = ["weiteren", "sammelversuch"],
        Fra = ["une", "fois", "supplémentaire"]
    };

    public static readonly LocalizedStrings StellarMissionUnderway = new()
    {
        Jpn = ["コスモミッション", "を開始した"],
        Eng = ["stellar", "mission", "underway"],
        Deu = ["stellarmission", "gestartet"],
        Fra = ["commencé", "mission"]
    };

    public static readonly LocalizedStrings StellarSpecialActionUnlock = new()
    {
        Jpn = ["特殊アクション", "が使用可能になった"],
        Eng = ["special", "action"],
        Deu = ["spezialkommando", "ausgeführt"],
        Fra = ["désormais", "utiliser", "spéciale"]
    };

    public static readonly LocalizedStrings StellarMissionScore = new()
    {
        Jpn = ["ミッションハイスコア", "を記録した"],
        Eng = ["record", "high", "score"],
        Deu = ["neue", "höchstwertung", "verzeichnet"],
        Fra = ["nouveau", "mission", "enregistré"]
    };

    /// <see href="https://xivapi.com/LogMessage/10781?pretty=true">You complete the stellar mission "…".</see>
    public static readonly LocalizedStrings StellarMissionComplete = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["complete the", "stellar", "mission"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings StellarSilverStarRating = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["received", "silver", "star", "rating"],
        Deu = ["silberwertung"],
        Fra = ["obtenu", "rang", "argent"]
    };

    public static readonly LocalizedStrings StellarGoldStarRating = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["received", "gold", "star", "rating"],
        Deu = ["goldwertung"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings StellarObjectivesComplete = new()
    {
        Jpn = ["コスモミッションの目標を達成した"],
        Eng = ["stellar", "mission", "objectives", "complete"],
        Deu = ["alle", "missionsziele", "erreicht"],
        Fra = ["accompli", "objectifs", "cosmique"]
    };

    public static readonly LocalizedStrings StellarTimeLimitExpired = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["time", "limit", "expired"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10769?pretty=true">
    ///     From the Mission in Progress window, press the Report
    ///     button to complete the mission.
    /// </see>
    public static readonly LocalizedStrings StellarReportMission = new()
    {
        Jpn = ["進行中ミッション", "ウィンドウから", "ミッションを完了してください"],
        Eng = ["report", "button", "complete", "mission"],
        Deu = ["missionen", "berichten", "stellarmission"],
        Fra = ["cliquez", "valider", "terminer"]
    };

    /// <see href="https://xivapi.com/LogMessage/10815?pretty=true">
    ///     Sequential missions are now available via the Stellar
    ///     Missions interface.
    /// </see>
    public static readonly LocalizedStrings StellarSequentialMissions = new()
    {
        Jpn = ["連続ミッション", "が発生しました", "コスモミッションから受注する事が可能です"],
        Eng = ["sequential", "missions", "stellar"],
        Deu = ["fortführende", "stellarmissionen", "bestritten"],
        Fra = ["successives", "disponibles", "cosmiques"]
    };

    /// <see href="https://xivapi.com/LogMessage/10779?pretty=true">
    ///     You completed the stellar mission "…" with a Gold Star
    ///     rating.
    /// </see>
    public static readonly LocalizedStrings StellarMissionCompleted = new()
    {
        Jpn = ["はコスモミッション", "をゴールドグレードでコンプリートした"],
        Eng = ["completed", "stellar", "mission", "gold", "star"],
        Deu = ["goldwertung", "abgeschlossen"],
        Fra = ["obtenu", "rang", "mission"]
    };

    public static readonly LocalizedStrings StellarGoldCountStreak = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["gold", "count", "streak"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings StellarMissionLogCommittedPlain = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["committed", "mission", "log"],
        Deu = ["missionslog", "verzeichnet"],
        Fra = ["complétion", "enregistrée", "missions"]
    };

    /// <see href="https://xivapi.com/LogMessage/10879?pretty=true">
    ///     Completion of "…" has been committed to your mission log
    ///     with a Gold Star rating.
    /// </see>
    public static readonly LocalizedStrings StellarMissionLogCommitted = new()
    {
        Jpn = ["の達成状況をゴールドグレードでミッションログに記録した"],
        Eng = ["committed", "mission", "log", "gold", "star"],
        Deu = ["goldwertung", "missionslog", "verzeichnet"],
        Fra = ["complétion", "enregistrée", "missions"]
    };

    /// <see href="https://xivapi.com/LogMessage/10828?pretty=true">Mission evaluation complete.</see>
    public static readonly LocalizedStrings StellarMissionEvaluationComplete = new()
    {
        Jpn = ["コスモミッションの評価が確定しました"],
        Eng = ["mission", "evaluation", "complete"],
        Deu = ["missionswertung", "abgeschlossen"],
        Fra = ["évaluation", "mission", "définitif"]
    };

    /// <see href="https://xivapi.com/LogMessage/10827?pretty=true">You have no more items left for stellar reduction.</see>
    public static readonly LocalizedStrings StellarReductionNoItemsLeft = new()
    {
        Jpn = ["精選可能なアイテムを全て精選しました"],
        Eng = ["no", "more", "items", "stellar", "reduction"],
        Deu = ["raffinierbare", "gegenstände", "raffiniert"],
        Fra = ["plus", "objets", "éthérolyser"]
    };

    /// <see href="https://xivapi.com/LogMessage/11200?pretty=true">
    ///     A mission below class A has been undertaken. Your gold
    ///     count has been reset.
    /// </see>
    public static readonly LocalizedStrings StellarMissionGoldCountReset = new()
    {
        Jpn = ["aクラス未満のミッションを開始した為", "ゴールドカウントがリセットされました"],
        Eng = ["mission", "below", "class", "gold", "count", "reset"],
        Deu = ["mission", "goldzähler", "zurückgesetzt"],
        Fra = ["démarré", "mission", "inférieure"]
    };

    /// <see href="https://xivapi.com/LogMessage/11165?pretty=true">N minute(s) remaining to complete the mission.</see>
    public static readonly LocalizedStrings StellarMissionTimeRemaining = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["minute", "remaining", "complete", "mission"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/11174?pretty=true">You recover N GP.</see>
    public static readonly LocalizedStrings StellarGpRecoverySelf = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "recover", "gp"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/11174?pretty=true">PlayerName recovers N GP.</see>
    public static readonly LocalizedStrings StellarGpRecoveryOther = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["recovers", "gp"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings StellarGpRecovered = new()
    {
        Jpn = ["コスモミッションで使用したgp", "を回復しました"],
        Eng = ["recovered", "gp", "consumed", "stellar"],
        Deu = ["stellarmission", "verbraucht", "regeneriert"],
        Fra = ["dépensés", "cosmique", "récupérés"]
    };

    public static readonly LocalizedStrings CordialRecastReset = new()
    {
        Jpn = ["コーディアル類のリキャストタイマーをリセットしました"],
        Eng = ["recast", "timer", "cordials", "reset"],
        Deu = ["reaktivierungs", "kräutertränke", "zurückgesetzt"],
        Fra = ["recharge", "breuvages", "réinitialisé"]
    };

    public static readonly LocalizedStrings ReconnaissanceDroneLocatedArtifact = new()
    {
        Jpn = ["探索ドローンが", "惑星の遺物を発見した"],
        Eng = ["reconnaissance", "drone", "located", "artifact"],
        Deu = ["kundschafterdrohne", "artefakt", "entdeckt"],
        Fra = ["drone", "repéré", "vestige"]
    };

    public static readonly LocalizedStrings ArtifactAppraisalComplete = new()
    {
        Jpn = ["惑星の遺物", "の解析が完了した"],
        Eng = ["artifact", "appraisal", "complete"],
        Deu = ["artefaktanalyse", "abgeschlossen"],
        Fra = ["analyse", "vestige", "terminée"]
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
    /// <see href="https://xivapi.com/LogMessage/3563?pretty=true">You receive a double bonus!</see>
    public static readonly LocalizedStrings AetherialReductionDoubleBonus = new()
    {
        Jpn = ["ダブルボーナスが発生した"],
        Eng = ["receive", "double", "bonus"],
        Deu = ["doppelbonus"],
        Fra = ["bénéficiez", "double", "bonus"]
    };

    public static readonly LocalizedStrings CollectabilityLocationBonus = new()
    {
        Jpn = ["採集場所の特質が", "収集品の収集価値上昇量に影響を及ぼした"],
        Eng = ["location", "collectability", "increase"],
        Deu = ["sammelstelle", "beeinflusst", "sammlerwerts"],
        Fra = ["propriétés", "augmentation", "collection"]
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
}
