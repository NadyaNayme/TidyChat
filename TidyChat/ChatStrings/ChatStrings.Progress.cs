using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/659?pretty=true">You acquire \d PvP EXP.</see>
    public static readonly LocalizedStrings GainPvpExp = new()
    {
        Jpn = ["pvp", "exp"],
        Eng = ["you", "acquire", "pvp", "exp"],
        Deu = ["pvp", "exp"],
        Fra = ["vous", "jcj"]
    };

    /// <see href="https://xivapi.com/LogMessage/660?pretty=true">You attain PvP rank N!</see>
    public static readonly LocalizedStrings GainPvpRank = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["attain", "pvp", "rank"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/11308?pretty=true">Triumph count reduced after 10 minutes.</see>
    public static readonly LocalizedStrings WorqorTriumphReduced = new()
    {
        Jpn = ["同時に出現する戦略目標地の数が減少した"],
        Eng = ["triumphs", "reduced"],
        Deu = ["gleichzeitig", "triumphpunkte", "verringert"],
        Fra = ["bataille", "commencé", "névralgiques"]
    };

    /// <see href="https://xivapi.com/LogMessage/11311?pretty=true">The limit gauge has begun to fill!</see>
    public static readonly LocalizedStrings WorqorLimitGauge = new()
    {
        Jpn = ["リミットゲージ増加", "状態になった"],
        Eng = ["limit", "gauge"],
        Deu = ["limitrausch", "balken", "beginnt"],
        Fra = ["transcendance", "remplit", "progressivement"]
    };

    /// <see href="https://xivapi.com/LogMessage/11312?pretty=true">Auroras are beginning to form…</see>
    public static readonly LocalizedStrings WorqorAuroras = new()
    {
        Jpn = ["天候が変わり", "オーロラが発生しそうだ"],
        Eng = ["auroras"],
        Deu = ["himmel", "langsam", "aurora"],
        Fra = ["aurores", "boréales", "apparaître"]
    };

    /// <see href="https://xivapi.com/LogMessage/11313?pretty=true">High rank triumphs are now more likely to manifest!</see>
    public static readonly LocalizedStrings WorqorHighRankTriumphs = new()
    {
        Jpn = ["高ランクの戦略目標地が出現しやすくなった"],
        Eng = ["triumphs", "manifest"],
        Deu = ["triumphpunkte", "erscheinen", "häufiger"],
        Fra = ["névralgiques", "susceptibles", "apparaître"]
    };

    /// <see href="https://xivapi.com/LogMessage/11368?pretty=true">The snow has stopped falling…</see>
    public static readonly LocalizedStrings WorqorSnowStopped = new()
    {
        Jpn = ["天候が変わり", "雪は降り止んだ"],
        Eng = ["snow", "stopped"],
        Deu = ["schneefall", "gelegt"],
        Fra = ["neige", "cessé", "tomber"]
    };

    /// <see href="https://xivapi.com/LogMessage/7556?pretty=true">You acquire N Series EXP.</see>
    public static readonly LocalizedStrings GainSeriesExp = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "acquire", "series", "exp"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/7557?pretty=true">You attain Series level N!</see>
    public static readonly LocalizedStrings GainSeriesLevel = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["attain", "series", "level"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/549?pretty=true">EXP chain #N! Chain expires in N seconds.</see>
    public static readonly LocalizedStrings ExpChainBonus = new()
    {
        Jpn = ["チェーン"],
        Eng = ["exp", "chain"],
        Deu = ["erfolgssträhne"],
        Fra = ["chaîne"]
    };

    /// <see href="https://xivapi.com/LogMessage/588?pretty=true">You gain N experience points.</see>
    public static readonly LocalizedStrings GainExperience = new()
    {
        Jpn = ["経験値"],
        Eng = ["gain", "experience", "point"],
        Deu = ["routine", "erfahrung"],
        Fra = ["expérience", "point"]
    };

    /// <see href="https://xivapi.com/LogMessage/9635?pretty=true">You gain N mettle.</see>
    public static readonly LocalizedStrings GainMettle = new()
    {
        Jpn = ["戦果"],
        Eng = ["gain", "mettle"],
        Deu = ["frontwissen"],
        Fra = ["faits", "armes"]
    };

    /// <see href="https://xivapi.com/LogMessage/10803?pretty=true">You submitted … points toward the … dataset.</see>
    public static readonly LocalizedStrings CosmicDatasetSubmitted = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["submitted", "dataset"],
        Deu = ["NeedsLocalization"],
        Fra = ["obtenez", "ensemble", "données"]
    };

    /// <see href="https://xivapi.com/LogMessage/10874?pretty=true">You earn N cosmic class points for …</see>
    public static readonly LocalizedStrings CosmicClassPoints = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["earn", "cosmic", "class", "point"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <summary>Shared obtain templates 657, 1259 - e.g. You obtain N armorer tool mastery points.</summary>
    public static readonly LocalizedStrings CosmicToolMasteryPoints = new()
    {
        Jpn = ["のマスターシップポイントを", "ポイント入手しました"],
        Eng = ["obtain", "tool", "mastery", "point"],
        Deu = ["meisterpunkte", "erhalten"],
        Fra = ["obtenu", "maîtrise", "classe"]
    };

    /// <see href="https://xivapi.com/LogMessage/10875?pretty=true">You earn N daily points.</see>
    public static readonly LocalizedStrings DailyPointsEarned = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["earn", "daily", "point"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/11156?pretty=true">You achieved the "…" daily success!</see>
    public static readonly LocalizedStrings DailySuccessAchieved = new()
    {
        Jpn = ["デイリー実績", "を達成した"],
        Eng = ["achieved", "daily", "success"],
        Deu = ["tägliche", "errungenschaft", "vollbracht"],
        Fra = ["accompli", "jalon", "journalier"]
    };

    /// <see href="https://xivapi.com/LogMessage/10877?pretty=true">Daily success goal achieved!</see>
    public static readonly LocalizedStrings DailySuccessGoalAchieved = new()
    {
        Jpn = ["デイリー実績の目標値を達成した"],
        Eng = ["daily", "success", "goal", "achieved"],
        Deu = ["tagwerkpunkteziel", "erreicht"],
        Fra = ["atteint", "objectif", "journalier"]
    };

    /// <see href="https://xivapi.com/LogMessage/10876?pretty=true">You achieved the "…" stellar success!</see>
    public static readonly LocalizedStrings StellarSuccessAchieved = new()
    {
        Jpn = ["計画実績", "を達成した"],
        Eng = ["achieved", "stellar", "success"],
        Deu = ["projekterrungenschaft", "vollbracht"],
        Fra = ["atteint", "jalon"]
    };

    /// <see href="https://xivapi.com/LogMessage/952?pretty=true">You earn the achievement "…"!</see>
    public static readonly LocalizedStrings PlayerEarnAchievement = new()
    {
        Jpn = ["アチーブメント", "達成"],
        Eng = ["earn", "the", "achievement"],
        Deu = ["errungenschaft", "erlangt"],
        Fra = ["accompli", "haut", "fait"]
    };

    /// <see href="https://xivapi.com/LogMessage/590?pretty=true">You attain level N!</see>
    public static readonly LocalizedStrings LevelUp = new()
    {
        Jpn = ["レベル"],
        Eng = ["attain", "level"],
        Deu = ["stufe", "gestiegen"],
        Fra = ["atteignez", "niveau"]
    };

    /// <see href="https://xivapi.com/LogMessage/3921?pretty=true">Name attains level N!</see>
    public static readonly LocalizedStrings OtherLevelUp = new()
    {
        Jpn = ["レベル"],
        Eng = ["attains", "level"],
        Deu = ["stufe", "erreicht"],
        Fra = ["atteint", "niveau"]
    };

    /// <see href="https://xivapi.com/LogMessage/552?pretty=true">You learn …</see>
    public static readonly LocalizedStrings AbilityUnlock = new()
    {
        Jpn = ["修得"],
        Eng = ["you", "learn"],
        Deu = ["erlernt"],
        Fra = ["apprenez"]
    };

    /// <see href="https://xivapi.com/LogMessage/4679?pretty=true">Completion time: …</see>
    public static readonly LocalizedStrings CompletionTime = new()
    {
        Jpn = ["コンプリート"],
        Eng = ["completion", "time"],
        Deu = ["abgeschlossen"],
        Fra = ["temps"]
    };

    /// <see href="https://xivapi.com/LogMessage/4325?pretty=true">Desynthesis skill increases …</see>
    public static readonly LocalizedStrings DesynthesisLevel = new()
    {
        Jpn = ["分解"],
        Eng = ["desynthesis", "skill", "increases"],
        Deu = ["verwertungsgeschick"],
        Fra = ["recyclage"]
    };

    /// <see href="https://xivapi.com/LogMessage/952?pretty=true">
    ///     Someone earns the achievement " Blah blah blah, Tidal
    ///     Wave!"
    /// </see>
    public static readonly LocalizedStrings OtherEarnAchievement = new()
    {
        Jpn = ["アチーブメント"],
        Eng = ["earns", "the", "achievement"], // You earn the achievement <achievement>
        Deu = ["hat", "errungenschaft"],
        Fra = ["avez", "accompli", "haut", "fait"] // a accompli le haut fait “ Élémentaliste légendaire”!,
    };

    /// <see href="https://xivapi.com/LogMessage/7975?pretty=true">Second Chance points added …</see>
    public static readonly LocalizedStrings SecondChanceAward = new()
    {
        Jpn = ["チャンスポイント"],
        Eng = ["second", "chance"],
        Deu = ["chance-punkte"],
        Fra = ["points", "chance"]
    };
}
