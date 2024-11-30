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
        Fra = ["dans", "quelle", "instance", "vous", "trouvez"],
    };

    /// <see href="https://xivapi.com/LogMessage/926?pretty=true">Received Player Commendation</see>
    public static readonly LocalizedStrings PlayerCommendation = new()
    {
        Jpn = ["mip", "推薦を獲得しました"],
        Eng = ["you", "received", "a", "player", "commendation"],
        Deu = ["hast", "die", "auszeichnung"],
        Fra = ["équipiers", "vous", "honoré"],
    };

    /// <see href="https://xivapi.com/LogMessage/5253?pretty=true">You join the [Company] as a freelancer</see>
    public static readonly LocalizedStrings StartOfPvp = new()
    {
        Jpn = ["フロントラインに", "として参加しました"],
        Eng = ["join", "freelancer"],
        Deu = ["pvp-front", "beigetreten"],
        Fra = ["combattez", "dans", "rangs"],
    };

    /// <see href="https://xivapi.com/LogMessage/1534?pretty=true">Duty has ended</see>
    public static readonly LocalizedStrings DutyEnded = new()
    {
        Jpn = ["の攻略を終了した"],
        Eng = ["has", "ended"],
        Deu = ["wurde", "beendet"],
        Fra = ["prend", "fin"],
    };

    /// <see href="https://xivapi.com/LogMessage/1530?pretty=true">Guildhest will end soon</see>
    public static readonly LocalizedStrings GuildhestEnded = new()
    {
        Jpn = ["全員が特務隊長から報酬を受け取る"],
        Eng = ["the", "guildhest", "will", "end", "soon"],
        Deu = ["das", "gildengeheiß", "endet", "alle", "teilnehmer"],
        Fra = ["guilde", "allez", "quitter"],
    };

    // With the chat mode in Say, enter a phrase containing "Some Words"
    public static readonly LocalizedStrings SayQuestReminder = new()
    {
        Jpn = ["チャットの会話モードを"],
        Eng = ["with", "the", "chat", "mode", "in"],
        Deu = ["gib", "im", "virtuelle", "tastatur"],
        Fra = ["en", "mode", "de", "discussion"],
    };

    /// <see href="https://xivapi.com/LogMessage/9331?pretty=true">You sense the presence of a powerful mark...</see>
    public static readonly LocalizedStrings PowerfulMark = new()
    {
        Jpn = ["強大なリスキーモブの気配を感じる"],
        Eng = ["sense", "presence", "powerful", "mark"],
        Deu = ["du", "spücrst", "hochwild"],
        Fra = ["vous", "ressentez", "présence", "monstre"],
    };

    /// <see href="https://xivapi.com/LogMessage/9332?pretty=true">The minions of an extraordinarily powerful mark...</see>
    public static readonly LocalizedStrings ExtraordinarilyPowerfulMark = new()
    {
        Jpn = ["特殊なリスキーモブの配下が", "偵察活動を開始したようだ"],
        Eng = ["minions", "extraordinarily", "powerful", "mark"],
        Deu = ["die", "helfer", "eines", "besonderen", "hochwilds"],
        Fra = ["les", "sous-fifres", "du", "monstre"],
    };

    /// <see href="https://xivapi.com/LogMessage/4341?pretty=true">Retainer completed a venture.</see>
    public static readonly LocalizedStrings CompletedVenture = new()
    {
        Jpn = ["冒険を終えました！"],
        Eng = ["completed", "a", "venture"],
        Deu = ["hat", "eine", "unternehmung", "abgeschlossen"],
        Fra = ["terminé", "sa", "tâche"],
    };


    public static readonly LocalizedStrings GainExperiencePoints = new()
    {
        Jpn = ["you", "ポイントの経験値"],
        Eng = ["you", "experience", "points"], //You gain \d <class> experience points
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "gagnez", "points", "d'expérience"],
    };

    /// <see href="https://xivapi.com/LogMessage/2246?pretty=true">
    ///     A bonus of 1,200,000 experience points and 12,000 gil has
    ///     been awards for using the duty roulette.
    /// </see>
    public static readonly LocalizedStrings RouletteBonus = new()
    {
        Jpn = ["コンテンツルーレットのボーナスとして"],
        Eng = ["a", "bonus", "has", "been", "awarded", "for", "using", "the", "duty", "roulette"],
        Deu = ["deinen", "mut", "einer", "herausforderung", "stellen"],
        Fra = ["un", "bonus", "pour", "avoir", "utilisé"],
    };

    /// <see href="https://xivapi.com/LogMessage/2244?pretty=true">
    ///     A bonus of 12,000 gil has been awared for being an
    ///     adventurer in need.
    /// </see>
    public static readonly LocalizedStrings AdventurerInNeedBonus = new()
    {
        Jpn = ["不足ロールボーナスとして"],
        Eng = ["a", "bonus", "for", "being", "an", "adventurer", "in", "need"],
        Deu = ["die", "teilnahme", "einer", "gefragten", "rolle"],
        Fra = ["bonus", "pour", "avoir", "rempli", "nombre", "insuffisant"],
    };

    /// <see href="https://xivapi.com/LogMessage/659?pretty=true">You acquire \d PvP EXP.</see>
    public static readonly LocalizedStrings GainPvpExp = new()
    {
        Jpn = ["pvp", "exp"],
        Eng = ["you", "acquire", "pvp", "exp"],
        Deu = ["pvp", "exp"],
        Fra = ["vous", "jcj"],
    };

    public static readonly LocalizedStrings ObtainWolfMarks = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "obtain", "wolf", "marks"], // You obtain ### Wolf Marks.
        Deu = ["erhalten", "wolfsmarken"],
        Fra = ["marques", "de", "loup"],
    };

    public static readonly LocalizedStrings CappedWolfMarks = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng =
        [
            "you", "cannot", "receive", "any", "more", "wolf", "marks",
        ], // You cannot receive any more Wolf Marks. (Error Message)
        Deu = ["du", "kannst", "keine", "wolfsmarken"],
        Fra = ["marques", "de", "loup"],
    };

    public static readonly LocalizedStrings EarnAchievement = new()
    {
        Jpn = ["アチーブメント"],
        Eng = ["you", "earn", "the", "achievement"], // You earn the achievement <achievement>
        Deu = ["hast", "errungenshaft"],
        Fra = ["vous", "accompli", "haut", "fait"], // a accompli le haut fait “ Élémentaliste légendaire”!,
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
        Fra = ["avez", "accompli", "haut", "fait"], // a accompli le haut fait “ Élémentaliste légendaire”!,
    };

    public static readonly LocalizedStrings YouSynthesize = new()
    {
        Jpn = ["you", "を完成させた！"],
        Eng = ["you", "synthesize"], // You synthesize a/an <item>
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "fabriquez"], // Vous fabriquez un <item>,
    };

    public static readonly LocalizedStrings ObtainedTomestones = new()
    {
        Jpn = ["アラガントームストーン", "手", "入", "た。"], // (?:手に入れ|入手し)た
        Eng = ["you", "obtain", "allagan", "tomestones", "of"], // You obtain Allagan Tomestones of <type>
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "obtenez", "mémoquartz"],
    };

    /// <see href="https://xivapi.com/LogMessage/3794?pretty=true">Ready Check Complete.</see>
    public static readonly LocalizedStrings ReadyCheckComplete = new()
    {
        Jpn = ["レディチェックが終了しました"],
        Eng = ["ready", "check", "complete"],
        Deu = ["bereitschaftsanfrage"],
        Fra = ["l'appel", "préparation", "pris", "fin"],
    };

    public static readonly LocalizedStrings InitiatedReadyCheck = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["initiated", "ready", "check"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
    };

    public static readonly LocalizedStrings YouAttainLevel = new()
    {
        Jpn = ["レベルアップ！", "you", "になった。"],
        Eng = ["you", "level"], // You attain level <level>.
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "niveau"], // Vous atteignez le niveau <level>!,
    };

    public static readonly LocalizedStrings OtherAttainsLevel = new()
    {
        // BUG: this won't match abbreviated player names; need to be able to mix string and regexp
        Jpn = ["レベルアップ！", " ", "になった。"],
        Eng = ["attains", "level"], // <Player> attains level 33!
        Deu = ["NeedsLocalization"],
        Fra = ["atteint", "niveau"],
    };

    public static readonly LocalizedStrings YouLearnAbility = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "learn"], // You learn <ability>.
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "apprenez"], // Vous apprenez <ability>.,
    };

    /// <see href="https://xivapi.com/LogMessage/5264?pretty=true">Engage!</see>
    public static readonly LocalizedStrings CountdownEngage = new()
    {
        Jpn = ["戦闘開始"],
        Eng = ["engage!"],
        Deu = ["start!"],
        Fra = ["l'attaque!"],
    };

    /// <see href="https://xivapi.com/LogMessage/5260?pretty=true">Battle commencing in <time> seconds.</see>
    public static readonly LocalizedStrings CountdownTime = new()
    {
        Jpn = ["戦闘開始まで", "秒"],
        Eng = ["battle", "commencing", "in", "seconds"],
        Deu = ["noch", "sekunde"],
        Fra = ["début", "combat", "dans"],
    };

    public static readonly LocalizedStrings DebugTeleport = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["teleporting", "to"], // Teleporting to <Location>...
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
    };

    /// <see href="https://xivapi.com/LogMessage/1831?pretty=true">You sense an unsettling presence.</see>
    public static readonly LocalizedStrings UnsettlingPresence = new()
    {
        Jpn = ["不穏な気配"],
        Eng = ["an", "unsettling", "presence"],
        Deu = ["beunruhigende", "präsenz"],
        Fra = ["présence", "inquiétante"],
    };

    /// <see href="https://xivapi.com/LogMessage/3712?pretty=true">
    ///     The compass detects a current approximately <##> yalms to the <direction>...
    /// </see>
    public static readonly LocalizedStrings AetherCompass = new()
    {
        Jpn = ["コンパスの針は"],
        Eng = ["the", "compass", "detects", "a", "current", "approximately"],
        Deu = ["spücrst", "eine", "quelle", "yalme"],
        Fra = ["boussole", "indique"],
    };

    /// <see href="https://xivapi.com/LogMessage/4364?pretty=true">
    ///     Glamours projected from plate <##></see>
    public static readonly LocalizedStrings GlamoursProjected = new()
    {
        Jpn = ["ミラージュプレート", "により武具投影が行われました。"],
        Eng = ["glamours", "projected", "from", "plate"],
        Deu = ["die", "projektionsplatte", "angewendet"],
        Fra = ["planche", "mirage", "projeté"],
    };

    public static readonly LocalizedStrings OvermeldFailure = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng =
        [
            "you", "unable", "to", "attach", "the", "materia", "to",
        ], // You are unable to attach the materia to the <item>. The <materia> was lost.
        Deu = ["NeedsLocalization"],
        Fra =
        [
            "sertissage", "vous", "avez", "perdu",
        ], // Le sertissage de la  lorica d'hoplomachus classique a échoué... Vous avez perdu 2  matérias de la parade stratégique IX.
    };

    public static readonly LocalizedStrings MateriaExtract = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "successfully", "a", "from", "the"], // You succesfully extra a <materia> from the <item>
        Deu = ["NeedsLocalization"],
        Fra =
        [
            "vous", "matérialisez", "obtenez",
        ], // Vous matérialisez un  couteau de cuisine en chondrite et obtenez une  matéria du contrôle IX.
    };

    public static readonly LocalizedStrings LocationAffects = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["the", "location", "affects", "your"], // The location affects your...
        Deu = ["NeedsLocalization"],
        Fra = ["propriétés", "lieu", "vous", "conférent"], // Les propriétés du lieu vous confèrent (...),
    };

    public static readonly LocalizedStrings GatheringYield = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["gathering", "yield"], // ...gathering yield.
        Deu = ["NeedsLocalization"],
        Fra =
        [
            "plus", "importantes", "récoltes",
        ], //  Les propriétés du lieu vous confèrent de plus importantes récoltes!
    };

    public static readonly LocalizedStrings GatherersBoon = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng =
        [
            "chance", "of", "receiving", "the", "gatherer's", "boon",
        ], // ...chance of receiving the Gatherer's boon.
        Deu = ["NeedsLocalization"],
        Fra =
        [
            "plus", "grandes", "chances",
        ], // Les propriétés du lieu vous confèrent de plus grandes chances de récolte supplémentaire!
    };

    public static readonly LocalizedStrings GatheringAttempts = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["increased", "integrity", "number", "of", "gathering", "attempts"],
        Deu = ["NeedsLocalization"],
        Fra =
        [
            "tentatives", "récolte", "supplémentaires",
        ], // Les propriétés du lieu vous confèrent des tentatives de récolte supplémentaires!
    };


    public static readonly LocalizedStrings GearsetEquipped = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["equipped", "glamours", "restored"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"],
    };

    /// <see href="https://xivapi.com/LogMessage/38?pretty=true">Trade complete.</see>
    public static readonly LocalizedStrings TradeComplete = new()
    {
        Jpn = ["トレードが完了しました"],
        Eng = ["trade", "complete"],
        Deu = ["der", "handel", "wurde", "abgeschlossen"],
        Fra = ["l'échange", "est", "terminé"],
    };

    /// <see href="https://xivapi.com/LogMessage/36?pretty=true">Trade canceled.</see>
    public static readonly LocalizedStrings TradeCanceled = new()
    {
        Jpn = ["トレードがキャンセルされました"],
        Eng = ["trade", "canceled"],
        Deu = ["l'échange", "été", "annulé"],
        Fra = ["der", "handel", "worde", "abgebrochen"],
    };

    /// <see href="https://xivapi.com/LogMessage/33?pretty=true">Trade request sent to <player></see>
    public static readonly LocalizedStrings TradeSent = new()
    {
        Jpn = ["にトレードを申し込みました"],
        Eng = ["trade", "request", "sent", "to"],
        Deu = ["du", "hast", "einen", "handel", "angeboten"],
        Fra = ["vous", "proposez", "un", "échange"],
    };

    /// <see href="https://xivapi.com/LogMessage/32?pretty=true">Awaiting trade confirmation from player</see>
    public static readonly LocalizedStrings AwaitingTradeConfirmation = new()
    {
        Jpn = ["の内容確認をまっています"],
        Eng = ["awaiting", "trade", "confirmation", "from"],
        Deu = ["warte", "auf", "bestätigung"],
        Fra = ["la", "proposition"],
    };

    /// <see href="https://xivapi.com/LogMessage/1?pretty=true">You invite player to a party.</see>
    public static readonly LocalizedStrings InviteSent = new()
    {
        Jpn = ["をパーティに誘いました"],
        Eng = ["you", "invite", "to"],
        Deu = ["du", "hast", "die", "gruppe", "eingeladen"],
        Fra = ["vous", "invitez", "l'équipe"],
    };

    public static readonly LocalizedStrings InviteeJoins = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["joins", "the"], // Player joins the party.
        Deu = ["NeedsLocalization"],
        Fra = ["rejoint", "l'équipe"], // Player rejoint l'équipe.,
    };

    /// <see href="https://xivapi.com/LogMessage/73?pretty=true">The party has been disbanded.</see>
    public static readonly LocalizedStrings PartyDisband = new()
    {
        Jpn = ["パーティが解散されました"],
        Eng = ["the", "party", "has", "been", "disbanded"],
        Deu = ["die", "gruppe", "wurde", "aufgelöst"],
        Fra = ["l'équipe", "été", "dissoute"],
    };

    /// <see href="https://xivapi.com/LogMessage/72?pretty=true">You dissolve the party.</see>
    public static readonly LocalizedStrings PartyDissolved = new()
    {
        Jpn = ["パーティを解散しました"],
        Eng = ["dissolve", "party"],
        Deu = ["deine", "gruppe", "wurde", "aufgelöst"],
        Fra = ["l'équipe", "est", "dissoute"],
    };

    public static readonly LocalizedStrings InvitedBy = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["invites", "you", "to"], // <Player> invites you to a party.
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "dans", "son", "équipe"], // <Player> vous invite dans son équipe.,
    };

    public static readonly LocalizedStrings JoinParty = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["you", "join"], // You join <Player>'s party.
        Deu = ["NeedsLocalization"],
        Fra = ["vous", "rejoignez", "l'équipe"], // Vous rejoignez l'équipe de <Player>.,
    };

    /// <see href="https://xivapi.com/LogMessage/4?pretty=true">You leave the party.</see>
    public static readonly LocalizedStrings YouLeaveParty = new()
    {
        Jpn = ["パーティから離脱しました"],
        Eng = ["you", "leave"],
        Deu = ["du", "hast", "gruppe", "verlassen"],
        Fra = ["vous", "quittez", "l'équipe"],
    };

    /// <see href="https://xivapi.com/LogMessage/7446?pretty=true">Cross-world party joined</see>
    public static readonly LocalizedStrings JoinCrossParty = new()
    {
        Jpn = ["クロスワールドパーティに参加しました"],
        Eng = ["cross-world", "party", "joined"],
        Deu = ["du", "bist", "einer", "gruppe", "beigetreten"],
        Fra = ["vous", "avez", "rejoint", "inter-monde"],
    };

    public static readonly LocalizedStrings LeftParty = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["has", "left"], // Player has left the party.
        Deu = ["NeedsLocalization"],
        Fra = ["quitté", "l'équipe"], // Player a quitté l'équipe.,
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
        Fra = ["offre", "de", "vous", "téléporter", "destination"],
    };

    // https://xivapi.com/LogMessage/4402?pretty=true
    public static readonly LocalizedStrings RelicBookStep = new()
    {
        Jpn = ["黄道十二文書"],
        Eng =
        [
            "record", "of", "added", "for",
        ], // Record of boss kill (n/m) added for Relic Weapon - Stats.1
        Deu = ["ephemeridentafel", "wurde", "beseitigt"],
        Fra = ["vous", "notez", "livre"],
    };

    /// <see href="https://xivapi.com/LogMessage/4400?pretty=true">
    ///     All objectives under the category
    ///     Category - buff complete!
    /// </see>
    public static readonly LocalizedStrings RelicBookComplete = new()
    {
        Jpn = ["のカテゴリ", "をコンプリートした"],
        Eng = ["all", "objectives", "under", "the", "category", "complete"],
        Deu = ["alle", "ziele", "kategorie", "ephemeridentafel"],
        Fra = ["vous", "avez", "accompli", "toutes", "catégorie"],
    };

    /// <see href="https://xivapi.com/LogMessage/4411?pretty=true">Hunt mark mark slain! #/#</see>
    public static readonly LocalizedStrings HuntSlain = new()
    {
        Jpn = ["モブハント"],
        Eng = ["hunt", "mark", "slain"],
        Deu = ["ziel", "der", "hohen", "jagd", "erlgt"],
        Fra = ["contrats", "collège", "glaneurs"],
    };

    /// <see href="https://xivapi.com/LogMessage/4679?pretty=true">Completion time: ##:##</see>
    public static readonly LocalizedStrings CompletionTime = new()
    {
        Jpn = ["コンプリートタイム"],
        Eng = ["completion", "time"],
        Deu = ["wurde", "in", "abgeschlossen"],
        Fra = ["temps", "d'incursion", "pour"],
    };

    /// <see href="https://xivapi.com/LogMessage/1531?pretty=true">[Duty] has begun</see>
    public static readonly LocalizedStrings HasBegun = new()
    {
        Jpn = ["の攻略を開始した"],
        Eng = ["has", "begun"],
        Deu = ["hat", "negpmmem"],
        Fra = ["la", "mission", "commence"],
    };

    public static readonly LocalizedStrings PalaceOfTheDead = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["palace", "dead", "begun"], // Palace of the Dead Floors (x-y) has begun
        Deu = ["palast", "der", "toten"],
        Fra = ["palais", "des", "morts"],
    };

    public static readonly LocalizedStrings HeavenOnHigh = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["heaven-on-high", "begun"], // Heaven-on-High Floors (x-y) has begun
        Deu = ["himmelssäule"],
        Fra = ["pilier", "des", "cieux"],
    };

    /// <see href="https://xivapi.com/LogMessage/859?pretty=true">Total Play time: 249 days, 12 hours, 30 minutes</see>
    public static readonly LocalizedStrings Playtime = new()
    {
        Jpn = ["累積プレイ時間"],
        Eng = ["total", "play", "time"],
        Deu = ["gesamtspielzeit"],
        Fra = ["temps", "de", "jeu", "total"],
    };

    /// <see href="https://xivapi.com/LogMessage/7027?pretty=true">You've joined the Novice Network</see>
    public static readonly LocalizedStrings NoviceNetworkJoin = new()
    {
        Jpn = ["ビギナーチャンネルに参加しました"],
        Eng = ["joined", "the", "novice", "network"],
        Deu = ["bist", "neulings-chat", "beigetreten"],
        Fra = ["vous", "rejoint", "réseau", "novices"],
    };

    /// <see href="https://xivapi.com/LogMessage/7030?pretty=true">You have left the Novice Network</see>
    public static readonly LocalizedStrings NoviceNetworkLeft = new()
    {
        Jpn = ["ビギナーチャンネルから退出しました"],
        Eng = ["left", "the", "novice", "network"],
        Deu = ["hast", "neulings-chat", "verlassen"],
        Fra = ["vous", "quitté", "réseau", "novices"],
    };

    /// <see href="https://xivapi.com/LogMessage/4325?pretty=true">Desynthesis level increases by</see>
    public static readonly LocalizedStrings DesynthesisLevel = new()
    {
        Jpn = ["ポイント上昇した"],
        Eng = ["desynthesis", "skill", "increases"],
        Deu = ["ist", "um", "gestiegen"],
        Fra = ["recyclage", "augmente"],
    };

    /// <see href="https://xivapi.com/LogMessage/97?pretty=true">Updating online status</see>
    public static readonly LocalizedStrings OnlineStatus = new()
    {
        Jpn = ["状態", "になりました"],
        Eng = ["updating", "online", "status"],
        Deu = ["online-status", "wurde"],
        Fra = ["l'état", "automatiquiment"],
    };

    /// <see href="https://xivapi.com/LogMessage/672?pretty=true">You attach ... items to the letter</see>
    /// <see href="https://xivapi.com/LogMessage/673?pretty=true">You attach ... gil to the letter</see>
    public static readonly LocalizedStrings AttachToMail = new()
    {
        Jpn = ["レターに", "添付しました"],
        Eng = ["you", "attach", "letter"],
        Deu = ["du", "hast", "brief", "angehängt"],
        Fra = ["vous", "joignez", "lettre"],
    };

    /// <see href="https://xivapi.com/LogMessage/1114?pretty=true">Data on [fish] is added to your fish guide</see>
    public static readonly LocalizedStrings AddedToFishGuide = new()
    {
        Jpn = ["の情報を記録した"],
        Eng = ["data", "added", "fish", "guide"],
        Deu = ["fischverzeichnis", "vermerkt"],
        Fra = ["notez", "informations", "votre", "nomenclature"],
    };

    /// <see href="https://xivapi.com/LogMessage/3512?pretty=true">[Player] lands a [fish] measuring ... ilms</see>
    public static readonly LocalizedStrings MeasuringIlms = new()
    {
        Jpn = ["イルム", "を釣り上げた"],
        Eng = ["measuring", "ilms"],
        Deu = ["ilme", "gefangen"],
        Fra = ["pêché", "de"],
    };
}