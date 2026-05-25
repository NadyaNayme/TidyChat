using TidyChat.Translation.Data;
namespace TidyChat;

public static class ChatStrings
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

    /// <see href="https://xivapi.com/LogMessage/1530?pretty=true">Guildhest will end soon</see>
    public static readonly LocalizedStrings GuildhestEnded = new()
    {
        Jpn = ["全員が特務隊長から報酬を受け取る"],
        Eng = ["the", "guildhest", "will", "end", "soon"],
        Deu = ["das", "gildengeheiß", "endet", "alle", "teilnehmer"],
        Fra = ["guilde", "allez", "quitter"]
    };

    /// <see href="https://xivapi.com/LogMessage/659?pretty=true">You acquire \d PvP EXP.</see>
    public static readonly LocalizedStrings GainPvpExp = new()
    {
        Jpn = ["pvp", "exp"],
        Eng = ["you", "acquire", "pvp", "exp"],
        Deu = ["pvp", "exp"],
        Fra = ["vous", "jcj"]
    };

    public static readonly LocalizedStrings ObtainWolfMarks = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "obtain", "wolf", "marks"], // You obtain ### Wolf Marks.
        Deu = ["erhalten", "wolfsmarken"],
        Fra = ["marques", "de", "loup"]
    };

    public static readonly LocalizedStrings CappedWolfMarks = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng =
        [
            "you", "cannot", "receive", "any", "more", "wolf", "marks"
        ], // You cannot receive any more Wolf Marks. (Error Message)
        Deu = ["du", "kannst", "keine", "wolfsmarken"],
        Fra = ["marques", "de", "loup"]
    };

    // With the chat mode in Say, enter a phrase containing "Some Words"
    public static readonly LocalizedStrings SayQuestReminder = new()
    {
        Jpn = ["チャットの会話モードを"],
        Eng = ["with", "the", "chat", "mode", "in"],
        Deu = ["gib", "im", "virtuelle", "tastatur"],
        Fra = ["en", "mode", "de", "discussion"]
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

    public static readonly LocalizedStrings SynthesisComplete = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "synthesize"], // You synthesize a/an <item>.
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings LocationAffects = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["the", "location", "affects", "your"], // The location affects your...
        Deu = ["NeedsLocalization"],
        Fra = ["propriétés", "lieu", "vous", "conférent"] // Les propriétés du lieu vous confèrent (...),
    };

    public static readonly LocalizedStrings GatheringYield = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["gathering", "yield"], // ...gathering yield.
        Deu = ["NeedsLocalization"],
        Fra =
        [
            "plus", "importantes", "récoltes"
        ] //  Les propriétés du lieu vous confèrent de plus importantes récoltes!
    };

    public static readonly LocalizedStrings GatherersBoon = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng =
        [
            "chance", "of", "receiving", "the", "gatherer's", "boon"
        ], // ...chance of receiving the Gatherer's boon.
        Deu = ["NeedsLocalization"],
        Fra =
        [
            "plus", "grandes", "chances"
        ] // Les propriétés du lieu vous confèrent de plus grandes chances de récolte supplémentaire!
    };

    public static readonly LocalizedStrings GatheringAttempts = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["increased", "integrity", "number", "of", "gathering", "attempts"],
        Deu = ["NeedsLocalization"],
        Fra =
        [
            "tentatives", "récolte", "supplémentaires"
        ] // Les propriétés du lieu vous confèrent des tentatives de récolte supplémentaires!
    };

    public static readonly LocalizedStrings JoinParty = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "join"], // You join <Player>'s party.
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "rejoignez", "l'équipe"] // Vous rejoignez l'équipe de <Player>.,
    };
    // https://xivapi.com/LogMessage/4402?pretty=true
    public static readonly LocalizedStrings PalaceOfTheDead = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["palace", "dead", "begun"], // Palace of the Dead Floors (x-y) has begun
        Deu = ["palast", "der", "toten"],
        Fra = ["palais", "des", "morts"]
    };

    public static readonly LocalizedStrings HeavenOnHigh = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["heaven-on-high", "begun"], // Heaven-on-High Floors (x-y) has begun
        Deu = ["himmelssäule"],
        Fra = ["pilier", "des", "cieux"]
    };

    /// <see href="https://xivapi.com/LogMessage/2070?pretty=true">
    ///     You are X or more levels above the recommended level for this FATE.
    ///     To join, use the level sync function located in the duty list.</see>
    public static readonly LocalizedStrings FateLevelSyncWarning = new()
    {
        Jpn = ["比推荐等级高出", "等级同步"],
        Eng = ["recommended level for this fate", "level sync"],
        Deu = ["empfohlenen", "stufenanpassung"],
        Fra = ["synchronisation de niveau", "aléa"],
    };
}
