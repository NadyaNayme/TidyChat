using TidyChat.Translation.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    public static readonly LocalizedStrings LocationAffects = new()
    {
        Jpn = ["採集場所", "特徴"],
        Eng = ["the", "location", "affects", "your"],
        Deu = ["sammelstelle", "beeinflusst"],
        Fra = ["propriétés", "lieu", "vous", "conférent"]
    };

    /// <see href="https://xivapi.com/LogMessage/5550?pretty=true">This location grants an increase to item collectability!</see>
    public static readonly LocalizedStrings LocationCollectabilityIncrease = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["location", "grants", "increase", "collectability"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/5551?pretty=true">This location affects the chance your meticulous actions do not reduce integrity!</see>
    public static readonly LocalizedStrings LocationMeticulousIntegrity = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["location", "meticulous", "integrity"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/3549?pretty=true">You use … Collectability increases by N.</see>
    public static readonly LocalizedStrings CollectabilityIncreases = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["collectability", "increases"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/3569?pretty=true">Collector's intuition … Collectability increases by N.</see>
    public static readonly LocalizedStrings CollectabilityMeticulousIntuition = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["collector's", "intuition", "collectability", "increases"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1099?pretty=true">The location affects your gathering yield!</see>
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
    public static readonly LocalizedStrings GatherersBoonScore = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["earn", "score", "gatherer's", "boon"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
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
    public static readonly LocalizedStrings GatheringBegin = new()
    {
        Jpn = ["開始"],
        Eng = ["you", "begin"],
        Deu = ["beginnst"],
        Fra = ["commencez"]
    };

    /// <see href="https://xivapi.com/LogMessage/1086?pretty=true">You sense a grade … node …</see>
    public static readonly LocalizedStrings GatheringSenses = new()
    {
        Jpn = ["感じ"],
        Eng = ["you", "sense"],
        Deu = ["güte"],
        Fra = ["grade"]
    };

    /// <see href="https://xivapi.com/LogMessage/3502?pretty=true">You no longer sense any unspoiled mineral deposits…</see>
    public static readonly LocalizedStrings GatheringNoLongerSense = new()
    {
        Jpn = ["感じられなく"],
        Eng = ["no", "longer", "sense"],
        Deu = ["kannst", "mehr", "wahrnehmen"],
        Fra = ["perdu", "la", "trace"]
    };

    /// <see href="https://xivapi.com/LogMessage/1103?pretty=true">
    ///     You have been granted an additional gathering attempt at
    ///     this rocky outcropping.
    /// </see>
    public static readonly LocalizedStrings GatheringAttemptGranted = new()
    {
        Jpn = ["採集回数", "復し"],
        Eng = ["granted", "an", "additional", "gathering", "attempt"],
        Deu = ["weiteren", "sammelversuch"],
        Fra = ["une", "fois", "supplémentaire"]
    };

    /// <see href="https://xivapi.com/LogMessage/1116?pretty=true">Something bites!</see>
    public static readonly LocalizedStrings SomethingBites = new()
    {
        Jpn = ["フッキング"],
        Eng = ["something", "bites"],
        Deu = ["angebissen"],
        Fra = ["touche"]
    };

    /// <see href="https://xivapi.com/LogMessage/5584?pretty=true">You reel in your line.</see>
    /// <seealso href="https://xivapi.com/LogMessage/3511?pretty=true">You reel in your line.</seealso>
    public static readonly LocalizedStrings ReelInLine = new()
    {
        Jpn = ["竿を上げ"],
        Eng = ["reel", "line"],
        Deu = ["angel"],
        Fra = ["hameçon"]
    };

    /// <see href="https://xivapi.com/LogMessage/1111?pretty=true">You put away your rod.</see>
    public static readonly LocalizedStrings PutAwayRod = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["put", "away", "rod"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/11333?pretty=true">The multihook has reeled in additional fish!</see>
    public static readonly LocalizedStrings MultihookBonusFish = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["multihook", "reeled", "additional", "fish"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/11154?pretty=true">The stellar mission … is now underway.</see>
    public static readonly LocalizedStrings StellarMissionUnderway = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["stellar", "mission", "underway"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10764?pretty=true">You can now use the special action …!</see>
    public static readonly LocalizedStrings StellarSpecialActionUnlock = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["special", "action"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10804?pretty=true">You earn a score of N.</see>
    public static readonly LocalizedStrings StellarMissionScore = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["earn", "score"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10770?pretty=true">You received a Silver Star rating!</see>
    public static readonly LocalizedStrings StellarSilverStarRating = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["received", "silver", "star", "rating"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10771?pretty=true">You received a Gold Star rating!</see>
    public static readonly LocalizedStrings StellarGoldStarRating = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["received", "gold", "star", "rating"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10766?pretty=true">All stellar mission objectives complete!</see>
    public static readonly LocalizedStrings StellarObjectivesComplete = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["stellar", "mission", "objectives", "complete"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10822?pretty=true">The time limit has expired.</see>
    public static readonly LocalizedStrings StellarTimeLimitExpired = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["time", "limit", "expired"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10769?pretty=true">From the Mission in Progress window, press the Report button to complete the mission.</see>
    public static readonly LocalizedStrings StellarReportMission = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["report", "button", "complete", "mission"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10815?pretty=true">Sequential missions are now available via the Stellar Missions interface.</see>
    public static readonly LocalizedStrings StellarSequentialMissions = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["sequential", "missions", "stellar"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10779?pretty=true">You completed the stellar mission "…" with a Gold Star rating.</see>
    public static readonly LocalizedStrings StellarMissionCompleted = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["completed", "stellar", "mission", "gold", "star"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/11197?pretty=true">Your gold count streak has reached N!</see>
    public static readonly LocalizedStrings StellarGoldCountStreak = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["gold", "count", "streak"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10878?pretty=true">Completion of "…" has been committed to your mission log.</see>
    public static readonly LocalizedStrings StellarMissionLogCommittedPlain = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["committed", "mission", "log"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10879?pretty=true">Completion of "…" has been committed to your mission log with a Gold Star rating.</see>
    public static readonly LocalizedStrings StellarMissionLogCommitted = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["committed", "mission", "log", "gold", "star"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/11175?pretty=true">You recovered all N GP consumed during the stellar mission.</see>
    public static readonly LocalizedStrings StellarGpRecovered = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["recovered", "gp", "consumed", "stellar"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/10946?pretty=true">The recast timer for cordials has been reset.</see>
    public static readonly LocalizedStrings CordialRecastReset = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["recast", "timer", "cordials", "reset"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/11379?pretty=true">The reconnaissance drone has located an artifact!</see>
    public static readonly LocalizedStrings ReconnaissanceDroneLocatedArtifact = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["reconnaissance", "drone", "located", "artifact"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/11383?pretty=true">Artifact appraisal complete!</see>
    public static readonly LocalizedStrings ArtifactAppraisalComplete = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["artifact", "appraisal", "complete"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1121?pretty=true">You recast your line with the fish still hooked.</see>
    public static readonly LocalizedStrings Mooching = new()
    {
        Jpn = ["泳がせ"],
        Eng = ["fish", "still", "hooked"],
        Deu = ["köder"],
        Fra = ["vif"]
    };

    /// <see href="https://xivapi.com/LogMessage/1110?pretty=true">Current fishing hole name.</see>
    public static readonly LocalizedStrings CurrentFishingHole = new()
    {
        Jpn = ["釣り場"],
        Eng = ["fishing", "location"],
        Deu = ["angelstelle"],
        Fra = ["pêche"]
    };

    /// <see href="https://xivapi.com/LogMessage/1130?pretty=true">You have discovered the fishing location …</see>
    public static readonly LocalizedStrings DiscoveredFishingHole = new()
    {
        Jpn = ["釣り場", "発見"],
        Eng = ["discovered", "fishing"],
        Deu = ["angelstelle", "entdeckt"],
        Fra = ["découvert", "pêche"]
    };

    /// <see href="https://xivapi.com/LogMessage/3512?pretty=true">You land … measuring … ilms!</see>
    public static readonly LocalizedStrings MeasuringIlms = new()
    {
        Jpn = ["イルム"],
        Eng = ["ilms"],
        Deu = ["ilme"],
        Fra = ["ilm"]
    };

    /// <see href="https://xivapi.com/LogMessage/5566?pretty=true">You attempt to lure large-sized fish …</see>
    public static readonly LocalizedStrings LureFish = new()
    {
        Jpn = ["誘っ"],
        Eng = ["lure"],
        Deu = ["angelockt"],
        Fra = ["attirez"]
    };
}
