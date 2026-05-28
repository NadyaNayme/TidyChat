using TidyChat.Translation.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/1601?pretty=true">Quest accepted.</see>
    public static readonly LocalizedStrings QuestAccepted = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["accepted"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1602?pretty=true">Quest complete.</see>
    public static readonly LocalizedStrings QuestComplete = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["complete"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1603?pretty=true">Quest objective fulfilled.</see>
    public static readonly LocalizedStrings QuestObjectiveFulfilled = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["objective", "fulfilled"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/659?pretty=true">You acquire \d PvP EXP.</see>
    public static readonly LocalizedStrings GainPvpExp = new()
    {
        Jpn = ["pvp", "exp"],
        Eng = ["you", "acquire", "pvp", "exp"],
        Deu = ["pvp", "exp"],
        Fra = ["vous", "jcj"]
    };

    /// <see href="https://xivapi.com/LogMessage/588?pretty=true">You gain N experience points.</see>
    public static readonly LocalizedStrings GainExperience = new()
    {
        Jpn = ["経験値"],
        Eng = ["gain", "experience", "point"],
        Deu = ["routine", "erfahrung"],
        Fra = ["expérience", "point"]
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

    /// <see href="https://xivapi.com/LogMessage/609?pretty=true">You can now summon the … minion.</see>
    public static readonly LocalizedStrings MinionUnlock = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["summon", "minion"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/3612?pretty=true">Paladin wisdom bequeathed.</see>
    public static readonly LocalizedStrings JobWisdomBequeathed = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["wisdom", "bequeathed"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/3613?pretty=true">Paladin memories awoken.</see>
    public static readonly LocalizedStrings JobMemoriesAwoken = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["memories", "awoken"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/1461?pretty=true">Oath gauge expanded.</see>
    public static readonly LocalizedStrings OathGaugeExpanded = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["oath", "gauge", "expanded"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
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
}
