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

    // With the chat mode in Say, enter a phrase containing "Some Words"
    public static readonly LocalizedStrings SayQuestReminder = new()
    {
        Jpn = ["チャットの会話モードを"],
        Eng = ["with", "the", "chat", "mode", "in"],
        Deu = ["gib", "im", "virtuelle", "tastatur"],
        Fra = ["en", "mode", "de", "discussion"]
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

    public static readonly LocalizedStrings YouSynthesize = new()
    {
        Jpn = ["you", "を完成させた！"],
        Eng = ["you", "synthesize"], // You synthesize a/an <item>
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "fabriquez"] // Vous fabriquez un <item>,
    };
    public static readonly LocalizedStrings InitiatedReadyCheck = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["initiated", "ready", "check"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    public static readonly LocalizedStrings YouAttainLevel = new()
    {
        Jpn = ["レベルアップ！", "you", "になった。"],
        Eng = ["you", "level"], // You attain level <level>.
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "niveau"] // Vous atteignez le niveau <level>!,
    };

    public static readonly LocalizedStrings OtherAttainsLevel = new()
    {
        // BUG: this won't match abbreviated player names; need to be able to mix string and regexp
        Jpn = ["レベルアップ！", " ", "になった。"],
        Eng = ["attains", "level"], // <Player> attains level 33!
        Deu = ["NeedsLocalization"],
        Fra = ["atteint", "niveau"]
    };

    public static readonly LocalizedStrings YouLearnAbility = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "learn"], // You learn <ability>.
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "apprenez"] // Vous apprenez <ability>.,
    };
    public static readonly LocalizedStrings DebugTeleport = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["teleporting", "to"], // Teleporting to <Location>...
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    public static readonly LocalizedStrings OvermeldFailure = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng =
        [
            "you", "unable", "to", "attach", "the", "materia", "to"
        ], // You are unable to attach the materia to the <item>. The <materia> was lost.
        Deu = ["NeedsLocalization"],
        Fra =
        [
            "sertissage", "vous", "avez", "perdu"
        ] // Le sertissage de la  lorica d'hoplomachus classique a échoué... Vous avez perdu 2  matérias de la parade stratégique IX.
    };

    public static readonly LocalizedStrings MateriaExtract = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "successfully", "a", "from", "the"], // You succesfully extra a <materia> from the <item>
        Deu = ["NeedsLocalization"],
        Fra =
        [
            "vous", "matérialisez", "obtenez"
        ] // Vous matérialisez un  couteau de cuisine en chondrite et obtenez une  matéria du contrôle IX.
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

    public static readonly LocalizedStrings GearsetEquipped = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["equipped", "glamours", "restored"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
    public static readonly LocalizedStrings InviteeJoins = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["joins", "the"], // Player joins the party.
        Deu = ["NeedsLocalization"],
        Fra = ["rejoint", "l'équipe"] // Player rejoint l'équipe.,
    };
    public static readonly LocalizedStrings InvitedBy = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["invites", "you", "to"], // <Player> invites you to a party.
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "dans", "son", "équipe"] // <Player> vous invite dans son équipe.,
    };

    public static readonly LocalizedStrings JoinParty = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "join"], // You join <Player>'s party.
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "rejoignez", "l'équipe"] // Vous rejoignez l'équipe de <Player>.,
    };
    public static readonly LocalizedStrings LeftParty = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["has", "left"], // Player has left the party.
        Deu = ["NeedsLocalization"],
        Fra = ["quitté", "l'équipe"] // Player a quitté l'équipe.,
    };

    /// <see href="https://xivapi.com/LogMessage/440?pretty=true">
    ///     You have been offered a teleport to
    ///     Aetheryte from Player.
    /// </see>
    public static readonly LocalizedStrings OfferedTeleport = new()
    {
        Jpn = ["へのテレポ勧誘を受けました"],
        Eng = ["you", "have", "been", "offered", "a", "teleport", "to", "from"],
        Deu = ["beitet", "einen", "teleport", "zielort"],
        Fra = ["offre", "de", "vous", "téléporter", "destination"]
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
    /// <see href="https://xivapi.com/LogMessage/7027?pretty=true">You've joined the Novice Network</see>
    public static readonly LocalizedStrings NoviceNetworkJoin = new()
    {
        Jpn = ["ビギナーチャンネルに参加しました"],
        Eng = ["joined", "the", "novice", "network"],
        Deu = ["bist", "neulings-chat", "beigetreten"],
        Fra = ["vous", "rejoint", "réseau", "novices"]
    };

    /// <see href="https://xivapi.com/LogMessage/7030?pretty=true">You have left the Novice Network</see>
    public static readonly LocalizedStrings NoviceNetworkLeft = new()
    {
        Jpn = ["ビギナーチャンネルから退出しました"],
        Eng = ["left", "the", "novice", "network"],
        Deu = ["hast", "neulings-chat", "verlassen"],
        Fra = ["vous", "quitté", "réseau", "novices"]
    };

    /// <see href="https://xivapi.com/LogMessage/4325?pretty=true">Desynthesis level increases by</see>
    public static readonly LocalizedStrings DesynthesisLevel = new()
    {
        Jpn = ["ポイント上昇した"],
        Eng = ["desynthesis", "skill", "increases"],
        Deu = ["ist", "um", "gestiegen"],
        Fra = ["recyclage", "augmente"]
    };
// You used Aetheryte Ticket (Remaining: ###).
    public static readonly LocalizedStrings AetheryteTicket = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["aetheryte", "ticket"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };
}
