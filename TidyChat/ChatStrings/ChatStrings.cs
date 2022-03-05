namespace TidyChat
{
    public static class ChatStrings
    {
        /// <see href="https://xivapi.com/LogMessage/1350?pretty=true">/instance text</see>
        public readonly static LocalizedStrings InstancedArea = new()
        {
            Jpn = new string[] { "で現在のインスタンスを再確認できます。" },
            Eng = new string[] { "you", "are", "now", "in", "the", "instanced", "area" },
            Deu = new string[] { "instanziierten", "areal" },
            Fra = new string[] { "dans", "quelle", "instance", "vous", "trouvez" }
        };

        /// <see href="https://xivapi.com/LogMessage/926?pretty=true">Received Player Commendation</see>
        public readonly static LocalizedStrings PlayerCommendation = new()
        {
            Jpn = new string[] { "mip", "推薦を獲得しました" },
            Eng = new string[] { "you", "received", "a", "player", "commendation" },
            Deu = new string[] { "hast", "die", "auszeichnung" },
            Fra = new string[] { "équipiers", "vous", "honoré" },
        };

        /// <see href="https://xivapi.com/LogMessage/5253?pretty=true">You join the [Company] as a freelancer</see>
        public readonly static LocalizedStrings StartOfPvp = new()
        {
            Jpn = new string[] { "フロントラインに", "として参加しました" },
            Eng = new string[] { "join", "freelancer" },
            Deu = new string[] { "pvp-front", "beigetreten" },
            Fra = new string[] { "combattez", "dans", "rangs" },
        };

        /// <see href="https://xivapi.com/LogMessage/1534?pretty=true">Duty has ended</see>
        public readonly static LocalizedStrings DutyEnded = new()
        {
            Jpn = new string[] { "の攻略を終了した" },
            Eng = new string[] { "has", "ended" },
            Deu = new string[] { "wurde", "beendet" },
            Fra = new string[] { "prend", "fin" },
        };

        /// <see href="https://xivapi.com/LogMessage/1530?pretty=true">Guildhest will end soon</see>
        public readonly static LocalizedStrings GuildhestEnded = new()
        {
            Jpn = new string[] { "全員が特務隊長から報酬を受け取る" },
            Eng = new string[] { "the", "guildhest", "will", "end", "soon" },
            Deu = new string[] { "das", "gildengeheiß", "endet", "alle", "teilnehmer" },
            Fra = new string[] { "guilde", "allez", "quitter" },
        };

        // With the chat mode in Say, enter a phrase containing "Some Words"
        public readonly static LocalizedStrings SayQuestReminder = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "with", "the", "chat", "mode", "in" },
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/9331?pretty=true">You sense the presence of a powerful mark...</see>
        public readonly static LocalizedStrings PowerfulMark = new()
        {
            Jpn = new string[] { "強大なリスキーモブの気配を感じる" },
            Eng = new string[] { "you", "sense", "the", "presence", "of", "a", "powerful", "mark" },
            Deu = new string[] { "du", "spücrst", "hochwild" },
            Fra = new string[] { "vous", "ressentez", "présence", "monstre" },
        };

        /// <see href="https://xivapi.com/LogMessage/9332?pretty=true">The minions of an extraordinarily powerful mark...</see>
        public readonly static LocalizedStrings ExtraordinarilyPowerfulMark = new()
        {
            Jpn = new string[] { "特殊なリスキーモブの配下が", "偵察活動を開始したようだ" },
            Eng = new string[] { "minions", "extraordinarily", "powerful", "mark" },
            Deu = new string[] { "die", "helfer", "eines", "besonderen", "hochwilds" },
            Fra = new string[] { "les", "sous-fifres", "du", "monstre" }
        };

        /// <see href="https://xivapi.com/LogMessage/4341?pretty=true">Retainer completed a venture.</see>
        public readonly static LocalizedStrings CompletedVenture = new()
        {
            Jpn = new string[] { "冒険を終えました！" },
            Eng = new string[] { "completed", "a", "venture" },
            Deu = new string[] { "hat", "eine", "unternehmung", "abgeschlossen" },
            Fra = new string[] { "terminé", "sa", "tâche" }
        };


        public readonly static LocalizedStrings GainExperiencePoints = new()
        {
            Jpn = new string[] { "you", "ポイントの経験値" },
            Eng = new string[] { "you", "experience", "points" }, //You gain \d <class> experience points
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "vous", "gagnez", "points", "d'expérience" },
        };

        /// <see href="https://xivapi.com/LogMessage/2246?pretty=true">A bonus of 1,200,000 experience points and 12,000 gil has been awards for using the duty roulette.</see>
        public readonly static LocalizedStrings RouletteBonus = new()
        {
            Jpn = new string[] { "コンテンツルーレットのボーナスとして" },
            Eng = new string[] { "a", "bonus", "has", "been", "awarded", "for", "using", "the", "duty", "roulette" },
            Deu = new string[] { "deinen", "mut", "einer", "herausforderung", "stellen" },
            Fra = new string[] { "un", "bonus", "pour", "avoir", "utilisé" },
        };

        /// <see href="https://xivapi.com/LogMessage/2244?pretty=true">A bonus of 12,000 gil has been awared for being an adventurer in need.</see>
        public readonly static LocalizedStrings AdventurerInNeedBonus = new()
        {
            Jpn = new string[] { "不足ロールボーナスとして" },
            Eng = new string[] { "a", "bonus", "for", "being", "an", "adventurer", "in", "need" },
            Deu = new string[] { "die", "teilnahme", "einer", "gefragten", "rolle" },
            Fra = new string[] { "bonus", "pour", "avoir", "rempli", "nombre", "insuffisant" },
        };

        /// <see href="https://xivapi.com/LogMessage/659?pretty=true">You acquire \d PvP EXP.</see>
        public readonly static LocalizedStrings GainPvpExp = new()
        {
            Jpn = new string[] { "pvp", "exp" },
            Eng = new string[] { "you", "acquire", "pvp", "exp" },
            Deu = new string[] { "pvp", "exp" },
            Fra = new string[] { "vous", "jcj" },
        };

        public readonly static LocalizedStrings ObtainWolfMarks = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "obtain", "wolf", "marks" }, // You obtain ### Wolf Marks.
            Deu = new string[] { "erhalten", "wolfsmarken" },
            Fra = new string[] { "marques", "de", "loup" },
        };

        public readonly static LocalizedStrings CappedWolfMarks = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "cannot", "receive", "any", "more", "wolf", "marks" }, // You cannot receive any more Wolf Marks. (Error Message)
            Deu = new string[] { "du", "kannst", "keine", "wolfsmarken" },
            Fra = new string[] { "marques", "de", "loup" },
        };

        public readonly static LocalizedStrings EarnAchievement = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "the", "achievement" }, // You earn the achievement <achievement>
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "vous", "accompli", "haut", "fait" }, // a accompli le haut fait “ Élémentaliste légendaire”!
        };

        public readonly static LocalizedStrings YouSynthesize = new()
        {
            Jpn = new string[] { "you", "を完成させた！" },
            Eng = new string[] { "you", "synthesize" }, // You synthesize a/an <item>
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "vous", "fabriquez" }, // Vous fabriquez un <item>
        };

        public readonly static LocalizedStrings ObtainedTomestones = new()
        {
            Jpn = new string[] { "アラガントームストーン", "手", "入", "た。" }, // (?:手に入れ|入手し)た
            Eng = new string[] { "you", "obtain", "allagan", "tomestones", "of" }, // You obtain Allagan Tomestones of <type>
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "vous", "obtenez", "mémoquartz" },
        };

        /// <see href="https://xivapi.com/LogMessage/3794?pretty=true">Ready Check Complete.</see>
        public readonly static LocalizedStrings ReadyCheckComplete = new()
        {
            Jpn = new string[] { "レディチェックが終了しました" },
            Eng = new string[] { "ready", "check", "complete" },
            Deu = new string[] { "bereitschaftsanfrage" },
            Fra = new string[] { "l'appel", "préparation", "pris", "fin" },
        };

        public readonly static LocalizedStrings YouAttainLevel = new()
        {
            Jpn = new string[] { "レベルアップ！", "you", "になった。" },
            Eng = new string[] { "you", "level" }, // You attain level <level>.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "vous", "niveau" }, // Vous atteignez le niveau <level>!
        };

        public readonly static LocalizedStrings OtherAttainsLevel = new()
        {
            // BUG: this won't match abbreviated player names; need to be able to mix string and regexp
            Jpn = new string[] { "レベルアップ！", " ", "になった。" },
            Eng = new string[] { "attains", "level" }, // <Player> attains level 33!
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "atteint", "niveau" },
        };

        public readonly static LocalizedStrings YouLearnAbility = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "learn" }, // You learn <ability>.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "vous", "apprenez" }, // Vous apprenez <ability>.
        };

        /// <see href="https://xivapi.com/LogMessage/5260?pretty=true">Battle commencing in <time> seconds.</see>
        public readonly static LocalizedStrings CountdownTime = new()
        {
            Jpn = new string[] { "戦闘開始まで", "秒" },
            Eng = new string[] { "battle", "commencing", "in", "seconds" },
            Deu = new string[] { "noch", "sekunde" },
            Fra = new string[] { "début", "combat", "dans" },
        };

        public readonly static LocalizedStrings DebugTeleport = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "teleporting", "to" }, // Teleporting to <Location>...
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/2600?pretty=true">You sense something foul may be lurking in the distance.</see>
        /// <seealso href="https://xivapi.com/LogMessage/4791?pretty=true">You sense something close.</see>
        public readonly static LocalizedStrings SpideySenses = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "sense", "something" }, // You sense something...
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/3712?pretty=true">The compass detects a current approximately <##> yalms to the <direction>...</see>
        public readonly static LocalizedStrings AetherCompass = new()
        {
            Jpn = new string[] { "コンパスの針は" },
            Eng = new string[] { "the", "compass", "detects", "a", "current", "approximately" },
            Deu = new string[] { "spücrst", "eine", "quelle", "yalme" },
            Fra = new string[] { "boussole", "indique" },
        };

        /// <see href="https://xivapi.com/LogMessage/4364?pretty=true">Glamours projected from plate <##></see>
        public readonly static LocalizedStrings GlamoursProjected = new()
        {
            Jpn = new string[] { "ミラージュプレート", "により武具投影が行われました。" },
            Eng = new string[] { "glamours", "projected", "from", "plate" },
            Deu = new string[] { "die", "projektionsplatte", "angewendet" },
            Fra = new string[] { "planche", "mirage", "projeté" },
        };

        public readonly static LocalizedStrings OvermeldFailure = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "unable", "to", "attach", "the", "materia", "to" }, // You are unable to attach the materia to the <item>. The <materia> was lost.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "sertissage", "vous", "avez", "perdu" }, // Le sertissage de la  lorica d'hoplomachus classique a échoué... Vous avez perdu 2  matérias de la parade stratégique IX.
        };

        public readonly static LocalizedStrings MateriaExtract = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "successfully", "a", "from", "the" }, // You succesfully extra a <materia> from the <item>
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "vous", "matérialisez", "obtenez" }, // Vous matérialisez un  couteau de cuisine en chondrite et obtenez une  matéria du contrôle IX.
        };

        public readonly static LocalizedStrings LocationAffects = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "the", "location", "affects", "your" }, // The location affects your...
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "propriétés", "lieu", "vous", "conférent" }, // Les propriétés du lieu vous confèrent (...)
        };

        public readonly static LocalizedStrings GatheringYield = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "gathering", "yield" }, // ...gathering yield.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "plus", "importantes", "récoltes" }, //  Les propriétés du lieu vous confèrent de plus importantes récoltes!
        };

        public readonly static LocalizedStrings GatherersBoon = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "chance", "of", "receiving", "the", "gatherer's", "boon" }, // ...chance of receiving the Gatherer's boon.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "plus", "grandes", "chances" }, // Les propriétés du lieu vous confèrent de plus grandes chances de récolte supplémentaire!
        };

        public readonly static LocalizedStrings GatheringAttempts = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "increased", "integrity", "number", "of", "gathering", "attempts" },
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "tentatives", "récolte", "supplémentaires" }, // Les propriétés du lieu vous confèrent des tentatives de récolte supplémentaires!
        };

        /// <see href="https://xivapi.com/LogMessage/38?pretty=true">Trade complete.</see>
        public readonly static LocalizedStrings TradeComplete = new()
        {
            Jpn = new string[] { "トレードが完了しました" },
            Eng = new string[] { "trade", "complete" },
            Deu = new string[] { "der", "handel", "wurde", "abgeschlossen" },
            Fra = new string[] { "l'échange", "est", "terminé" },
        };

        /// <see href="https://xivapi.com/LogMessage/36?pretty=true">Trade canceled.</see>
        public readonly static LocalizedStrings TradeCanceled = new()
        {
            Jpn = new string[] { "トレードがキャンセルされました" },
            Eng = new string[] { "trade", "canceled" },
            Deu = new string[] { "l'échange", "été", "annulé" },
            Fra = new string[] { "der", "handel", "worde", "abgebrochen" },
        };

        /// <see href="https://xivapi.com/LogMessage/33?pretty=true">Trade request sent to <player></see>
        public readonly static LocalizedStrings TradeSent = new()
        {
            Jpn = new string[] { "にトレードを申し込みました" },
            Eng = new string[] { "trade", "request", "sent", "to" },
            Deu = new string[] { "du", "hast", "einen", "handel", "angeboten" },
            Fra = new string[] { "vous", "proposez", "un", "échange" },
        };

        /// <see href="https://xivapi.com/LogMessage/32?pretty=true">Awaiting trade confirmation from <player></see>
        public readonly static LocalizedStrings AwaitingTradeConfirmation = new()
        {
            Jpn = new string[] { "の内容確認をまっています" },
            Eng = new string[] { "awaiting", "trade", "confirmation", "from" },
            Deu = new string[] { "warte", "auf", "bestätigung" },
            Fra = new string[] { "la", "proposition" },
        };

        /// <see href="https://xivapi.com/LogMessage/1?pretty=true">You invite <player> to a party.</see>
        public readonly static LocalizedStrings InviteSent = new()
        {
            Jpn = new string[] { "をパーティに誘いました" },
            Eng = new string[] { "you", "invite", "to", "a", "party" },
            Deu = new string[] { "du", "hast", "die", "gruppe", "eingeladen" },
            Fra = new string[] { "vous", "invitez", "l'équipe" },
        };

        public readonly static LocalizedStrings InviteeJoins = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "joins", "the", "party" }, // <Player> joins the party.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "rejoint", "l'équipe" }, // <Player> rejoint l'équipe.
        };

        /// <see href="https://xivapi.com/LogMessage/73?pretty=true">The party has been disbanded.</see>
        public readonly static LocalizedStrings PartyDisband = new()
        {
            Jpn = new string[] { "パーティが解散されました" },
            Eng = new string[] { "the", "party", "has", "been", "disbanded" },
            Deu = new string[] { "die", "gruppe", "wurde", "aufgelöst" },
            Fra = new string[] { "l'équipe", "été", "dissoute" },
        };

        /// <see href="https://xivapi.com/LogMessage/72?pretty=true">You dissolve the party.</see>
        public readonly static LocalizedStrings PartyDissolved = new()
        {
            Jpn = new string[] { "パーティを解散しました" },
            Eng = new string[] { "dissolve", "party" },
            Deu = new string[] { "deine", "gruppe", "wurde", "aufgelöst" },
            Fra = new string[] { "l'équipe", "est", "dissoute" },
        };

        public readonly static LocalizedStrings InvitedBy = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "invites", "you", "to", "a", "party" }, // <Player> invites you to a party.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "vous", "dans", "son", "équipe" }, // <Player> vous invite dans son équipe.
        };

        public readonly static LocalizedStrings JoinParty = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "join", "party" }, // You join <Player>'s party.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "vous", "rejoignez", "l'équipe" }, // Vous rejoignez l'équipe de <Player>.
        };

        /// <see href="https://xivapi.com/LogMessage/4?pretty=true">You leave the party.</see>
        public readonly static LocalizedStrings YouLeaveParty = new()
        {
            Jpn = new string[] { "パーティから離脱しました" },
            Eng = new string[] { "you", "leave", "party" },
            Deu = new string[] { "du", "hast", "gruppe", "verlassen" },
            Fra = new string[] { "vous", "quittez", "l'équipe" },
        };

        /// <see href="https://xivapi.com/LogMessage/7446?pretty=true">Cross-world party joined</see>
        public readonly static LocalizedStrings JoinCrossParty = new()
        {
            Jpn = new string[] { "クロスワールドパーティに参加しました" },
            Eng = new string[] { "cross-world", "party", "joined" },
            Deu = new string[] { "du", "bist", "einer", "gruppe", "beigetreten" },
            Fra = new string[] { "vous", "avez", "rejoint", "inter-monde" },
        };

        public readonly static LocalizedStrings LeftParty = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "has", "left", "the", "party" }, // <Player> has left the party.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "quitté", "l'équipe" }, // <Player> a quitté l'équipe.
        };

        /// <see href="https://xivapi.com/LogMessage/440?pretty=true">You have been offered a teleport to <Aetheryte> from <Player>.</see>
        public readonly static LocalizedStrings OfferedTeleport = new()
        {
            Jpn = new string[] { "へのテレポ勧誘を受けました" },
            Eng = new string[] { "you", "have", "been", "offered", "a", "teleport", "to", "from" },
            Deu = new string[] { "beitet", "einen", "teleport", "zielort" },
            Fra = new string[] { "offre", "de", "vous", "téléporter", "destination" },
        };

        // https://xivapi.com/LogMessage/4402?pretty=true
        public readonly static LocalizedStrings RelicBookStep = new()
        {
            Jpn = new string[] { "黄道十二文書" },
            Eng = new string[] { "record", "of", "added", "for" }, // Record of <boss> kill (n/m) added for <Relic Weapon> - <Stats>.1
            Deu = new string[] { "ephemeridentafel", "wurde", "beseitigt" },
            Fra = new string[] { "vous", "notez", "livre" },
        };

        /// <see href="https://xivapi.com/LogMessage/4400?pretty=true">All objectives under the category <Category> - <buff> complete!</see>
        public readonly static LocalizedStrings RelicBookComplete = new()
        {
            Jpn = new string[] { "のカテゴリ", "をコンプリートした" },
            Eng = new string[] { "all", "objectives", "under", "the", "category", "complete" },
            Deu = new string[] { "alle", "ziele", "kategorie", "ephemeridentafel" },
            Fra = new string[] { "vous", "avez", "accompli", "toutes", "catégorie" },
        };

        /// <see href="https://xivapi.com/LogMessage/4411?pretty=true">Hunt mark <mark> slain! #/#</see>
        public readonly static LocalizedStrings HuntSlain = new()
        {
            Jpn = new string[] { "モブハント" },
            Eng = new string[] { "hunt", "mark", "slain" },
            Deu = new string[] { "ziel", "der", "hohen", "jagd", "erlgt" },
            Fra = new string[] { "contrats", "collège", "glaneurs" },
        };

        /// <see href="https://xivapi.com/LogMessage/4679?pretty=true">Completion time: ##:##</see>
        public readonly static LocalizedStrings CompletionTime = new()
        {
            Jpn = new string[] { "コンプリートタイム" },
            Eng = new string[] { "completion", "time" },
            Deu = new string[] { "wurde", "in", "abgeschlossen" },
            Fra = new string[] { "temps", "d'incursion", "pour" },
        };

        /// <see href="https://xivapi.com/LogMessage/1531?pretty=true">[Duty] has begun</see>
        public readonly static LocalizedStrings HasBegun = new()
        {
            Jpn = new string[] { "の攻略を開始した" },
            Eng = new string[] { "has", "begun" },
            Deu = new string[] { "hat", "negpmmem" },
            Fra = new string[] { "la", "mission", "commence" },
        };

        public readonly static LocalizedStrings PalaceOfTheDead = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "palace", "dead", "begun" }, // Palace of the Dead Floors (x-y) has begun
            Deu = new string[] { "palast", "der", "toten" },
            Fra = new string[] { "palais", "des", "morts" },
        };

        public readonly static LocalizedStrings HeavenOnHigh = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "heaven-on-high", "begun" }, // Heaven-on-High Floors (x-y) has begun
            Deu = new string[] { "himmelssäule" },
            Fra = new string[] { "pilier", "des", "cieux" },
        };

        /// <see href="https://xivapi.com/LogMessage/859?pretty=true">Total Play time: 249 days, 12 hours, 30 minutes</see>
        public readonly static LocalizedStrings Playtime = new()
        {
            Jpn = new string[] { "累積プレイ時間" },
            Eng = new string[] { "total", "play", "time" },
            Deu = new string[] { "gesamtspielzeit" },
            Fra = new string[] { "temps", "de", "jeu", "total" },
        };

        /// <see href="https://xivapi.com/LogMessage/7027?pretty=true">You've joined the Novice Network</see>
        public readonly static LocalizedStrings NoviceNetworkJoin = new()
        {
            Jpn = new string[] { "ビギナーチャンネルに参加しました" },
            Eng = new string[] { "joined", "the", "novice", "network" },
            Deu = new string[] { "bist", "neulings-chat", "beigetreten" },
            Fra = new string[] { "vous", "rejoint", "réseau", "novices" },
        };

        /// <see href="https://xivapi.com/LogMessage/7030?pretty=true">You have left the Novice Network</see>
        public readonly static LocalizedStrings NoviceNetworkLeft = new()
        {
            Jpn = new string[] { "ビギナーチャンネルから退出しました" },
            Eng = new string[] { "left", "the", "novice", "network" },
            Deu = new string[] { "hast", "neulings-chat", "verlassen" },
            Fra = new string[] { "vous", "quitté", "réseau", "novices" },
        };

        /// <see href="https://xivapi.com/LogMessage/4325?pretty=true">Desynthesis level increases by</see>
        public readonly static LocalizedStrings DesynthesisLevel = new()
        {
            Jpn = new string[] { "ポイント上昇した" },
            Eng = new string[] { "desynthesis", "skill", "increases" },
            Deu = new string[] { "ist", "um", "gestiegen" },
            Fra = new string[] { "recyclage", "augmente" },
        };

        /// <see href="https://xivapi.com/LogMessage/97?pretty=true">Updating online status</see>
        public readonly static LocalizedStrings OnlineStatus = new()
        {
            Jpn = new string[] { "状態", "になりました" },
            Eng = new string[] { "updating", "online", "status"  },
            Deu = new string[] { "online-status", "wurde" },
            Fra = new string[] { "l'état", "automatiquiment" },
        };

        /// <see href="https://xivapi.com/LogMessage/672?pretty=true">You attach ... items to the letter</see>
        /// <see href="https://xivapi.com/LogMessage/673?pretty=true">You attach ... gil to the letter</see>
        public readonly static LocalizedStrings AttachToMail = new()
        {
            Jpn = new string[] { "レターに", "添付しました" },
            Eng = new string[] { "you", "attach", "letter" },
            Deu = new string[] { "du", "hast", "brief", "angehängt" },
            Fra = new string[] { "vous", "joignez", "lettre" },
        };

    }
}
