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

    /// <see href="https://xivapi.com/LogMessage/1099?pretty=true">The location affects your gathering yield!</see>
    public static readonly LocalizedStrings GatheringYield = new()
    {
        Jpn = ["獲得数"],
        Eng = ["gathering", "yield"],
        Deu = ["ertrag"],
        Fra = ["plus", "importantes", "récoltes"]
    };

    /// <see href="https://xivapi.com/LogMessage/3537?pretty=true">The yield for … has increased by N!</see>
    public static readonly LocalizedStrings GatheringYieldIncreased = new()
    {
        Jpn = ["獲得数", "上昇"],
        Eng = ["yield", "increased"],
        Deu = ["ertrag", "gestiegen"],
        Fra = ["augmenté"]
    };

    /// <see href="https://xivapi.com/LogMessage/1097?pretty=true">The location affects your chance of receiving the Gatherer's Boon!</see>
    public static readonly LocalizedStrings GatherersBoon = new()
    {
        Jpn = ["ボーナス"],
        Eng = ["chance", "of", "receiving", "the", "gatherer's", "boon"],
        Deu = ["chancen", "ertrags"],
        Fra = ["plus", "grandes", "chances"]
    };

    /// <see href="https://xivapi.com/LogMessage/1098?pretty=true">The location has increased integrity, and affects the number of your gathering attempts!</see>
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

    /// <see href="https://xivapi.com/LogMessage/1067?pretty=true">You finish mining.</see>
    public static readonly LocalizedStrings GatheringFinish = new()
    {
        Jpn = ["終え"],
        Eng = ["you", "finish"],
        Deu = ["fertig"],
        Fra = ["arrêtez"]
    };

    /// <see href="https://xivapi.com/LogMessage/1086?pretty=true">You sense a grade … node …</see>
    public static readonly LocalizedStrings GatheringSenses = new()
    {
        Jpn = ["感じ"],
        Eng = ["you", "sense"],
        Deu = ["güte"],
        Fra = ["grade"]
    };

    /// <see href="https://xivapi.com/LogMessage/3518?pretty=true">You were unable to locate any unspoiled mining points using Truth of Mountains.</see>
    public static readonly LocalizedStrings GatheringUnspoiledLocateFail = new()
    {
        Jpn = ["感知", "しなかった"],
        Eng = ["unable", "to", "locate", "unspoiled"],
        Deu = ["konntest", "keine", "unbekannten"],
        Fra = ["ne", "détectez", "aucune"]
    };

    /// <see href="https://xivapi.com/LogMessage/3502?pretty=true">You no longer sense any unspoiled mineral deposits…</see>
    public static readonly LocalizedStrings GatheringNoLongerSense = new()
    {
        Jpn = ["感じられなく"],
        Eng = ["no", "longer", "sense"],
        Deu = ["kannst", "mehr", "wahrnehmen"],
        Fra = ["perdu", "la", "trace"]
    };

    /// <see href="https://xivapi.com/LogMessage/3507?pretty=true">The unspoiled mineral deposit vanishes from sight…</see>
    public static readonly LocalizedStrings GatheringUnspoiledVanish = new()
    {
        Jpn = ["消え失せ"],
        Eng = ["vanish", "from", "sight"],
        Deu = ["verschwunden"],
        Fra = ["disparu"]
    };

    /// <see href="https://xivapi.com/LogMessage/1103?pretty=true">You have been granted an additional gathering attempt at this rocky outcropping.</see>
    public static readonly LocalizedStrings GatheringAttemptGranted = new()
    {
        Jpn = ["採集回数", "復し"],
        Eng = ["granted", "an", "additional", "gathering", "attempt"],
        Deu = ["weiteren", "sammelversuch"],
        Fra = ["une", "fois", "supplémentaire"]
    };

    /// <see href="https://xivapi.com/LogMessage/1114?pretty=true">Data on … is added to your fish guide.</see>
    public static readonly LocalizedStrings FishGuideEntry = new()
    {
        Jpn = ["魚類図鑑"],
        Eng = ["fish", "guide"],
        Deu = ["fischverzeichnis"],
        Fra = ["nomenclature"]
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
        Fra = ["NeedsLocalization"],
    };

    /// <see href="https://xivapi.com/LogMessage/10784?pretty=true">You apply a saltwater arthrolure to your line.</see>
    public static readonly LocalizedStrings ApplyArthrolure = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["apply", "arthrolure"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
    };

    /// <see href="https://xivapi.com/LogMessage/11333?pretty=true">The multihook has reeled in additional fish!</see>
    public static readonly LocalizedStrings MultihookBonusFish = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["multihook", "reeled", "additional", "fish"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
    };

    /// <see href="https://xivapi.com/LogMessage/11154?pretty=true">The stellar mission … is now underway.</see>
    public static readonly LocalizedStrings StellarMissionUnderway = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["stellar", "mission", "underway"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
    };

    /// <see href="https://xivapi.com/LogMessage/10764?pretty=true">You can now use the special action …!</see>
    public static readonly LocalizedStrings StellarSpecialActionUnlock = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["special", "action"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
    };

    /// <see href="https://xivapi.com/LogMessage/10804?pretty=true">You earn a score of N.</see>
    public static readonly LocalizedStrings StellarMissionScore = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["earn", "score"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
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
