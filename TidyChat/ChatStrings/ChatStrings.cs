namespace TidyChat;

public static class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/1350?pretty=true">/instance text</see>
    public static readonly LocalizedStrings InstancedArea = new()
    {
        Jpn = new[] { "で現在のインスタンスを再確認できます。" },
        Eng = new[] { "you", "are", "now", "in", "the", "instanced", "area" },
        Deu = new[] { "instanziierten", "areal" },
        Fra = new[] { "dans", "quelle", "instance", "vous", "trouvez" }
    };

    /// <see href="https://xivapi.com/LogMessage/926?pretty=true">Received Player Commendation</see>
    public static readonly LocalizedStrings PlayerCommendation = new()
    {
        Jpn = new[] { "mip", "推薦を獲得しました" },
        Eng = new[] { "you", "received", "a", "player", "commendation" },
        Deu = new[] { "hast", "die", "auszeichnung" },
        Fra = new[] { "équipiers", "vous", "honoré" }
    };

    /// <see href="https://xivapi.com/LogMessage/5253?pretty=true">You join the [Company] as a freelancer</see>
    public static readonly LocalizedStrings StartOfPvp = new()
    {
        Jpn = new[] { "フロントラインに", "として参加しました" },
        Eng = new[] { "join", "freelancer" },
        Deu = new[] { "pvp-front", "beigetreten" },
        Fra = new[] { "combattez", "dans", "rangs" }
    };

    /// <see href="https://xivapi.com/LogMessage/1534?pretty=true">Duty has ended</see>
    public static readonly LocalizedStrings DutyEnded = new()
    {
        Jpn = new[] { "の攻略を終了した" },
        Eng = new[] { "has", "ended" },
        Deu = new[] { "wurde", "beendet" },
        Fra = new[] { "prend", "fin" }
    };

    /// <see href="https://xivapi.com/LogMessage/1530?pretty=true">Guildhest will end soon</see>
    public static readonly LocalizedStrings GuildhestEnded = new()
    {
        Jpn = new[] { "全員が特務隊長から報酬を受け取る" },
        Eng = new[] { "the", "guildhest", "will", "end", "soon" },
        Deu = new[] { "das", "gildengeheiß", "endet", "alle", "teilnehmer" },
        Fra = new[] { "guilde", "allez", "quitter" }
    };

    // With the chat mode in Say, enter a phrase containing "Some Words"
    public static readonly LocalizedStrings SayQuestReminder = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "with", "the", "chat", "mode", "in" },
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "NeedsLocalization" }
    };

    /// <see href="https://xivapi.com/LogMessage/9331?pretty=true">You sense the presence of a powerful mark...</see>
    public static readonly LocalizedStrings PowerfulMark = new()
    {
        Jpn = new[] { "強大なリスキーモブの気配を感じる" },
        Eng = new[] { "you", "sense", "the", "presence", "of", "a", "powerful", "mark" },
        Deu = new[] { "du", "spücrst", "hochwild" },
        Fra = new[] { "vous", "ressentez", "présence", "monstre" }
    };

    /// <see href="https://xivapi.com/LogMessage/9332?pretty=true">The minions of an extraordinarily powerful mark...</see>
    public static readonly LocalizedStrings ExtraordinarilyPowerfulMark = new()
    {
        Jpn = new[] { "特殊なリスキーモブの配下が", "偵察活動を開始したようだ" },
        Eng = new[] { "minions", "extraordinarily", "powerful", "mark" },
        Deu = new[] { "die", "helfer", "eines", "besonderen", "hochwilds" },
        Fra = new[] { "les", "sous-fifres", "du", "monstre" }
    };

    /// <see href="https://xivapi.com/LogMessage/4341?pretty=true">Retainer completed a venture.</see>
    public static readonly LocalizedStrings CompletedVenture = new()
    {
        Jpn = new[] { "冒険を終えました！" },
        Eng = new[] { "completed", "a", "venture" },
        Deu = new[] { "hat", "eine", "unternehmung", "abgeschlossen" },
        Fra = new[] { "terminé", "sa", "tâche" }
    };


    public static readonly LocalizedStrings GainExperiencePoints = new()
    {
        Jpn = new[] { "you", "ポイントの経験値" },
        Eng = new[] { "you", "experience", "points" }, //You gain \d <class> experience points
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "vous", "gagnez", "points", "d'expérience" }
    };

    /// <see href="https://xivapi.com/LogMessage/2246?pretty=true">
    ///     A bonus of 1,200,000 experience points and 12,000 gil has
    ///     been awards for using the duty roulette.
    /// </see>
    public static readonly LocalizedStrings RouletteBonus = new()
    {
        Jpn = new[] { "コンテンツルーレットのボーナスとして" },
        Eng = new[] { "a", "bonus", "has", "been", "awarded", "for", "using", "the", "duty", "roulette" },
        Deu = new[] { "deinen", "mut", "einer", "herausforderung", "stellen" },
        Fra = new[] { "un", "bonus", "pour", "avoir", "utilisé" }
    };

    /// <see href="https://xivapi.com/LogMessage/2244?pretty=true">
    ///     A bonus of 12,000 gil has been awared for being an
    ///     adventurer in need.
    /// </see>
    public static readonly LocalizedStrings AdventurerInNeedBonus = new()
    {
        Jpn = new[] { "不足ロールボーナスとして" },
        Eng = new[] { "a", "bonus", "for", "being", "an", "adventurer", "in", "need" },
        Deu = new[] { "die", "teilnahme", "einer", "gefragten", "rolle" },
        Fra = new[] { "bonus", "pour", "avoir", "rempli", "nombre", "insuffisant" }
    };

    /// <see href="https://xivapi.com/LogMessage/659?pretty=true">You acquire \d PvP EXP.</see>
    public static readonly LocalizedStrings GainPvpExp = new()
    {
        Jpn = new[] { "pvp", "exp" },
        Eng = new[] { "you", "acquire", "pvp", "exp" },
        Deu = new[] { "pvp", "exp" },
        Fra = new[] { "vous", "jcj" }
    };

    public static readonly LocalizedStrings ObtainWolfMarks = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "you", "obtain", "wolf", "marks" }, // You obtain ### Wolf Marks.
        Deu = new[] { "erhalten", "wolfsmarken" },
        Fra = new[] { "marques", "de", "loup" }
    };

    public static readonly LocalizedStrings CappedWolfMarks = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[]
        {
            "you", "cannot", "receive", "any", "more", "wolf", "marks"
        }, // You cannot receive any more Wolf Marks. (Error Message)
        Deu = new[] { "du", "kannst", "keine", "wolfsmarken" },
        Fra = new[] { "marques", "de", "loup" }
    };

    public static readonly LocalizedStrings EarnAchievement = new()
    {
        Jpn = new[] { "アチーブメント" },
        Eng = new[] { "you", "earn", "the", "achievement" }, // You earn the achievement <achievement>
        Deu = new[] { "hast", "errungenshaft" },
        Fra = new[] { "vous", "accompli", "haut", "fait" } // a accompli le haut fait “ Élémentaliste légendaire”!
    };

    /// <see href="https://xivapi.com/LogMessage/952?pretty=true"">Someone earns the achievement " Blah blah blah, Tidal
    ///     Wave!"
    /// 
    /// </see>
    public static readonly LocalizedStrings OtherEarnAchievement = new()
    {
        Jpn = new[] { "アチーブメント" },
        Eng = new[] { "earns", "the", "achievement" }, // You earn the achievement <achievement>
        Deu = new[] { "hat", "errungenschaft" },
        Fra = new[] { "avez", "accompli", "haut", "fait" } // a accompli le haut fait “ Élémentaliste légendaire”!
    };

    public static readonly LocalizedStrings YouSynthesize = new()
    {
        Jpn = new[] { "you", "を完成させた！" },
        Eng = new[] { "you", "synthesize" }, // You synthesize a/an <item>
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "vous", "fabriquez" } // Vous fabriquez un <item>
    };

    public static readonly LocalizedStrings ObtainedTomestones = new()
    {
        Jpn = new[] { "アラガントームストーン", "手", "入", "た。" }, // (?:手に入れ|入手し)た
        Eng = new[] { "you", "obtain", "allagan", "tomestones", "of" }, // You obtain Allagan Tomestones of <type>
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "vous", "obtenez", "mémoquartz" }
    };

    /// <see href="https://xivapi.com/LogMessage/3794?pretty=true">Ready Check Complete.</see>
    public static readonly LocalizedStrings ReadyCheckComplete = new()
    {
        Jpn = new[] { "レディチェックが終了しました" },
        Eng = new[] { "ready", "check", "complete" },
        Deu = new[] { "bereitschaftsanfrage" },
        Fra = new[] { "l'appel", "préparation", "pris", "fin" }
    };

    public static readonly LocalizedStrings YouAttainLevel = new()
    {
        Jpn = new[] { "レベルアップ！", "you", "になった。" },
        Eng = new[] { "you", "level" }, // You attain level <level>.
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "vous", "niveau" } // Vous atteignez le niveau <level>!
    };

    public static readonly LocalizedStrings OtherAttainsLevel = new()
    {
        // BUG: this won't match abbreviated player names; need to be able to mix string and regexp
        Jpn = new[] { "レベルアップ！", " ", "になった。" },
        Eng = new[] { "attains", "level" }, // <Player> attains level 33!
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "atteint", "niveau" }
    };

    public static readonly LocalizedStrings YouLearnAbility = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "you", "learn" }, // You learn <ability>.
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "vous", "apprenez" } // Vous apprenez <ability>.
    };

    /// <see href="https://xivapi.com/LogMessage/5264?pretty=true">Engage!</see>
    public static readonly LocalizedStrings CountdownTime = new()
    {
        Jpn = new[] { "戦闘開始" },
        Eng = new[] { "engage!" },
        Deu = new[] { "start!" },
        Fra = new[] { "l'attaque!" }
    };

    /// <see href="https://xivapi.com/LogMessage/5260?pretty=true">Battle commencing in <time> seconds.</see>
    public static readonly LocalizedStrings CountdownEngage = new()
    {
        Jpn = new[] { "戦闘開始まで", "秒" },
        Eng = new[] { "battle", "commencing", "in", "seconds" },
        Deu = new[] { "noch", "sekunde" },
        Fra = new[] { "début", "combat", "dans" }
    };

    public static readonly LocalizedStrings DebugTeleport = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "teleporting", "to" }, // Teleporting to <Location>...
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "NeedsLocalization" }
    };

    /// <see href="https://xivapi.com/LogMessage/2600?pretty=true">You sense something foul may be lurking in the distance.</see>
    /// <seealso href="https://xivapi.com/LogMessage/4791?pretty=true">You sense something close.</see>
    public static readonly LocalizedStrings SpideySenses = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "you", "sense" }, // You sense something... , You sense your mark..., You sense a strange...
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "NeedsLocalization" }
    };

    /// <see href="https://xivapi.com/LogMessage/1831?pretty=true">You sense an unsettling presence.</see>
    public static readonly LocalizedStrings UnsettlingPresence = new()
    {
        Jpn = new[] { "不穏な気配" },
        Eng = new[] { "an", "unsettling", "presence" },
        Deu = new[] { "beunruhigende", "präsenz" },
        Fra = new[] { "présence", "inquiétante" }
    };

    /// <see href="https://xivapi.com/LogMessage/3712?pretty=true">
    ///     The compass detects a current approximately <##> yalms to the <direction>...
    /// </see>
    public static readonly LocalizedStrings AetherCompass = new()
    {
        Jpn = new[] { "コンパスの針は" },
        Eng = new[] { "the", "compass", "detects", "a", "current", "approximately" },
        Deu = new[] { "spücrst", "eine", "quelle", "yalme" },
        Fra = new[] { "boussole", "indique" }
    };

    /// <see href="https://xivapi.com/LogMessage/4364?pretty=true">
    ///     Glamours projected from plate <##></see>
    public static readonly LocalizedStrings GlamoursProjected = new()
    {
        Jpn = new[] { "ミラージュプレート", "により武具投影が行われました。" },
        Eng = new[] { "glamours", "projected", "from", "plate" },
        Deu = new[] { "die", "projektionsplatte", "angewendet" },
        Fra = new[] { "planche", "mirage", "projeté" }
    };

    public static readonly LocalizedStrings OvermeldFailure = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[]
        {
            "you", "unable", "to", "attach", "the", "materia", "to"
        }, // You are unable to attach the materia to the <item>. The <materia> was lost.
        Deu = new[] { "NeedsLocalization" },
        Fra = new[]
        {
            "sertissage", "vous", "avez", "perdu"
        } // Le sertissage de la  lorica d'hoplomachus classique a échoué... Vous avez perdu 2  matérias de la parade stratégique IX.
    };

    public static readonly LocalizedStrings MateriaExtract = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "you", "successfully", "a", "from", "the" }, // You succesfully extra a <materia> from the <item>
        Deu = new[] { "NeedsLocalization" },
        Fra = new[]
        {
            "vous", "matérialisez", "obtenez"
        } // Vous matérialisez un  couteau de cuisine en chondrite et obtenez une  matéria du contrôle IX.
    };

    public static readonly LocalizedStrings LocationAffects = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "the", "location", "affects", "your" }, // The location affects your...
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "propriétés", "lieu", "vous", "conférent" } // Les propriétés du lieu vous confèrent (...)
    };

    public static readonly LocalizedStrings GatheringYield = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "gathering", "yield" }, // ...gathering yield.
        Deu = new[] { "NeedsLocalization" },
        Fra = new[]
        {
            "plus", "importantes", "récoltes"
        } //  Les propriétés du lieu vous confèrent de plus importantes récoltes!
    };

    public static readonly LocalizedStrings GatherersBoon = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[]
        {
            "chance", "of", "receiving", "the", "gatherer's", "boon"
        }, // ...chance of receiving the Gatherer's boon.
        Deu = new[] { "NeedsLocalization" },
        Fra = new[]
        {
            "plus", "grandes", "chances"
        } // Les propriétés du lieu vous confèrent de plus grandes chances de récolte supplémentaire!
    };

    public static readonly LocalizedStrings GatheringAttempts = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "increased", "integrity", "number", "of", "gathering", "attempts" },
        Deu = new[] { "NeedsLocalization" },
        Fra = new[]
        {
            "tentatives", "récolte", "supplémentaires"
        } // Les propriétés du lieu vous confèrent des tentatives de récolte supplémentaires!
    };

    /// <see href="https://xivapi.com/LogMessage/38?pretty=true">Trade complete.</see>
    public static readonly LocalizedStrings TradeComplete = new()
    {
        Jpn = new[] { "トレードが完了しました" },
        Eng = new[] { "trade", "complete" },
        Deu = new[] { "der", "handel", "wurde", "abgeschlossen" },
        Fra = new[] { "l'échange", "est", "terminé" }
    };

    /// <see href="https://xivapi.com/LogMessage/36?pretty=true">Trade canceled.</see>
    public static readonly LocalizedStrings TradeCanceled = new()
    {
        Jpn = new[] { "トレードがキャンセルされました" },
        Eng = new[] { "trade", "canceled" },
        Deu = new[] { "l'échange", "été", "annulé" },
        Fra = new[] { "der", "handel", "worde", "abgebrochen" }
    };

    /// <see href="https://xivapi.com/LogMessage/33?pretty=true">Trade request sent to <player></see>
    public static readonly LocalizedStrings TradeSent = new()
    {
        Jpn = new[] { "にトレードを申し込みました" },
        Eng = new[] { "trade", "request", "sent", "to" },
        Deu = new[] { "du", "hast", "einen", "handel", "angeboten" },
        Fra = new[] { "vous", "proposez", "un", "échange" }
    };

    /// <see href="https://xivapi.com/LogMessage/32?pretty=true">Awaiting trade confirmation from <player></see>
    public static readonly LocalizedStrings AwaitingTradeConfirmation = new()
    {
        Jpn = new[] { "の内容確認をまっています" },
        Eng = new[] { "awaiting", "trade", "confirmation", "from" },
        Deu = new[] { "warte", "auf", "bestätigung" },
        Fra = new[] { "la", "proposition" }
    };

    /// <see href="https://xivapi.com/LogMessage/1?pretty=true">You invite <player> to a party.</see>
    public static readonly LocalizedStrings InviteSent = new()
    {
        Jpn = new[] { "をパーティに誘いました" },
        Eng = new[] { "you", "invite", "to", "a", "party" },
        Deu = new[] { "du", "hast", "die", "gruppe", "eingeladen" },
        Fra = new[] { "vous", "invitez", "l'équipe" }
    };

    public static readonly LocalizedStrings InviteeJoins = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "joins", "the", "party" }, // <Player> joins the party.
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "rejoint", "l'équipe" } // <Player> rejoint l'équipe.
    };

    /// <see href="https://xivapi.com/LogMessage/73?pretty=true">The party has been disbanded.</see>
    public static readonly LocalizedStrings PartyDisband = new()
    {
        Jpn = new[] { "パーティが解散されました" },
        Eng = new[] { "the", "party", "has", "been", "disbanded" },
        Deu = new[] { "die", "gruppe", "wurde", "aufgelöst" },
        Fra = new[] { "l'équipe", "été", "dissoute" }
    };

    /// <see href="https://xivapi.com/LogMessage/72?pretty=true">You dissolve the party.</see>
    public static readonly LocalizedStrings PartyDissolved = new()
    {
        Jpn = new[] { "パーティを解散しました" },
        Eng = new[] { "dissolve", "party" },
        Deu = new[] { "deine", "gruppe", "wurde", "aufgelöst" },
        Fra = new[] { "l'équipe", "est", "dissoute" }
    };

    public static readonly LocalizedStrings InvitedBy = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "invites", "you", "to", "a", "party" }, // <Player> invites you to a party.
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "vous", "dans", "son", "équipe" } // <Player> vous invite dans son équipe.
    };

    public static readonly LocalizedStrings JoinParty = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "you", "join", "party" }, // You join <Player>'s party.
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "vous", "rejoignez", "l'équipe" } // Vous rejoignez l'équipe de <Player>.
    };

    /// <see href="https://xivapi.com/LogMessage/4?pretty=true">You leave the party.</see>
    public static readonly LocalizedStrings YouLeaveParty = new()
    {
        Jpn = new[] { "パーティから離脱しました" },
        Eng = new[] { "you", "leave", "party" },
        Deu = new[] { "du", "hast", "gruppe", "verlassen" },
        Fra = new[] { "vous", "quittez", "l'équipe" }
    };

    /// <see href="https://xivapi.com/LogMessage/7446?pretty=true">Cross-world party joined</see>
    public static readonly LocalizedStrings JoinCrossParty = new()
    {
        Jpn = new[] { "クロスワールドパーティに参加しました" },
        Eng = new[] { "cross-world", "party", "joined" },
        Deu = new[] { "du", "bist", "einer", "gruppe", "beigetreten" },
        Fra = new[] { "vous", "avez", "rejoint", "inter-monde" }
    };

    public static readonly LocalizedStrings LeftParty = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "has", "left", "the", "party" }, // <Player> has left the party.
        Deu = new[] { "NeedsLocalization" },
        Fra = new[] { "quitté", "l'équipe" } // <Player> a quitté l'équipe.
    };

    /// <see href="https://xivapi.com/LogMessage/440?pretty=true">
    ///     You have been offered a teleport to
    ///     <Aetheryte> from <Player>.
    /// </see>
    public static readonly LocalizedStrings OfferedTeleport = new()
    {
        Jpn = new[] { "へのテレポ勧誘を受けました" },
        Eng = new[] { "you", "have", "been", "offered", "a", "teleport", "to", "from" },
        Deu = new[] { "beitet", "einen", "teleport", "zielort" },
        Fra = new[] { "offre", "de", "vous", "téléporter", "destination" }
    };

    // https://xivapi.com/LogMessage/4402?pretty=true
    public static readonly LocalizedStrings RelicBookStep = new()
    {
        Jpn = new[] { "黄道十二文書" },
        Eng = new[]
        {
            "record", "of", "added", "for"
        }, // Record of <boss> kill (n/m) added for <Relic Weapon> - <Stats>.1
        Deu = new[] { "ephemeridentafel", "wurde", "beseitigt" },
        Fra = new[] { "vous", "notez", "livre" }
    };

    /// <see href="https://xivapi.com/LogMessage/4400?pretty=true">
    ///     All objectives under the category
    ///     <Category> - <buff> complete!
    /// </see>
    public static readonly LocalizedStrings RelicBookComplete = new()
    {
        Jpn = new[] { "のカテゴリ", "をコンプリートした" },
        Eng = new[] { "all", "objectives", "under", "the", "category", "complete" },
        Deu = new[] { "alle", "ziele", "kategorie", "ephemeridentafel" },
        Fra = new[] { "vous", "avez", "accompli", "toutes", "catégorie" }
    };

    /// <see href="https://xivapi.com/LogMessage/4411?pretty=true">Hunt mark <mark> slain! #/#</see>
    public static readonly LocalizedStrings HuntSlain = new()
    {
        Jpn = new[] { "モブハント" },
        Eng = new[] { "hunt", "mark", "slain" },
        Deu = new[] { "ziel", "der", "hohen", "jagd", "erlgt" },
        Fra = new[] { "contrats", "collège", "glaneurs" }
    };

    /// <see href="https://xivapi.com/LogMessage/4679?pretty=true">Completion time: ##:##</see>
    public static readonly LocalizedStrings CompletionTime = new()
    {
        Jpn = new[] { "コンプリートタイム" },
        Eng = new[] { "completion", "time" },
        Deu = new[] { "wurde", "in", "abgeschlossen" },
        Fra = new[] { "temps", "d'incursion", "pour" }
    };

    /// <see href="https://xivapi.com/LogMessage/1531?pretty=true">[Duty] has begun</see>
    public static readonly LocalizedStrings HasBegun = new()
    {
        Jpn = new[] { "の攻略を開始した" },
        Eng = new[] { "has", "begun" },
        Deu = new[] { "hat", "negpmmem" },
        Fra = new[] { "la", "mission", "commence" }
    };

    public static readonly LocalizedStrings PalaceOfTheDead = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "palace", "dead", "begun" }, // Palace of the Dead Floors (x-y) has begun
        Deu = new[] { "palast", "der", "toten" },
        Fra = new[] { "palais", "des", "morts" }
    };

    public static readonly LocalizedStrings HeavenOnHigh = new()
    {
        Jpn = new[] { "NeedsLocalization" },
        Eng = new[] { "heaven-on-high", "begun" }, // Heaven-on-High Floors (x-y) has begun
        Deu = new[] { "himmelssäule" },
        Fra = new[] { "pilier", "des", "cieux" }
    };

    /// <see href="https://xivapi.com/LogMessage/859?pretty=true">Total Play time: 249 days, 12 hours, 30 minutes</see>
    public static readonly LocalizedStrings Playtime = new()
    {
        Jpn = new[] { "累積プレイ時間" },
        Eng = new[] { "total", "play", "time" },
        Deu = new[] { "gesamtspielzeit" },
        Fra = new[] { "temps", "de", "jeu", "total" }
    };

    /// <see href="https://xivapi.com/LogMessage/7027?pretty=true">You've joined the Novice Network</see>
    public static readonly LocalizedStrings NoviceNetworkJoin = new()
    {
        Jpn = new[] { "ビギナーチャンネルに参加しました" },
        Eng = new[] { "joined", "the", "novice", "network" },
        Deu = new[] { "bist", "neulings-chat", "beigetreten" },
        Fra = new[] { "vous", "rejoint", "réseau", "novices" }
    };

    /// <see href="https://xivapi.com/LogMessage/7030?pretty=true">You have left the Novice Network</see>
    public static readonly LocalizedStrings NoviceNetworkLeft = new()
    {
        Jpn = new[] { "ビギナーチャンネルから退出しました" },
        Eng = new[] { "left", "the", "novice", "network" },
        Deu = new[] { "hast", "neulings-chat", "verlassen" },
        Fra = new[] { "vous", "quitté", "réseau", "novices" }
    };

    /// <see href="https://xivapi.com/LogMessage/4325?pretty=true">Desynthesis level increases by</see>
    public static readonly LocalizedStrings DesynthesisLevel = new()
    {
        Jpn = new[] { "ポイント上昇した" },
        Eng = new[] { "desynthesis", "skill", "increases" },
        Deu = new[] { "ist", "um", "gestiegen" },
        Fra = new[] { "recyclage", "augmente" }
    };

    /// <see href="https://xivapi.com/LogMessage/97?pretty=true">Updating online status</see>
    public static readonly LocalizedStrings OnlineStatus = new()
    {
        Jpn = new[] { "状態", "になりました" },
        Eng = new[] { "updating", "online", "status" },
        Deu = new[] { "online-status", "wurde" },
        Fra = new[] { "l'état", "automatiquiment" }
    };

    /// <see href="https://xivapi.com/LogMessage/672?pretty=true">You attach ... items to the letter</see>
    /// <see href="https://xivapi.com/LogMessage/673?pretty=true">You attach ... gil to the letter</see>
    public static readonly LocalizedStrings AttachToMail = new()
    {
        Jpn = new[] { "レターに", "添付しました" },
        Eng = new[] { "you", "attach", "letter" },
        Deu = new[] { "du", "hast", "brief", "angehängt" },
        Fra = new[] { "vous", "joignez", "lettre" }
    };

    /// <see href="https://xivapi.com/LogMessage/1114?pretty=true">Data on [fish] is added to your fish guide</see>
    public static readonly LocalizedStrings AddedToFishGuide = new()
    {
        Jpn = new[] { "の情報を記録した" },
        Eng = new[] { "data", "added", "fish", "guide" },
        Deu = new[] { "fischverzeichnis", "vermerkt" },
        Fra = new[] { "notez", "informations", "votre", "nomenclature" }
    };

    /// <see href="https://xivapi.com/LogMessage/3512?pretty=true">[Player] lands a [fish] measuring ... ilms</see>
    public static readonly LocalizedStrings MeasuringIlms = new()
    {
        Jpn = new[] { "イルム", "を釣り上げた" },
        Eng = new[] { "measuring", "ilms" },
        Deu = new[] { "ilme", "gefangen" },
        Fra = new[] { "pêché", "de" }
    };
}