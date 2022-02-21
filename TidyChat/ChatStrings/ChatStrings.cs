namespace TidyChat
{
    public static class ChatStrings
    {
        /// <see href="https://xivapi.com/LogMessage/1350?pretty=true">/instance text</see>
        public static LocalizedStrings InstancedArea { get; } = new()
        {
            Jpn = new string[] { "で現在のインスタンスを再確認できます。" },
            Eng = new string[] { "you", "are", "now", "in", "the", "instanced", "area" },
            Deu = new string[] { "instanziierten", "areal" },
            Fra = new string[] { "dans", "quelle", "instance", "vous", "trouvez" }
        };

        /// <see href="https://xivapi.com/LogMessage/926?pretty=true">Received Player Commendation</see>
        public static LocalizedStrings PlayerCommendation { get; } = new() {
            Jpn = new string[] { "mip", "推薦を獲得しました" },
            Eng = new string[] { "you", "received", "a", "player", "commendation" },
            Deu = new string[] { "hast", "die", "auszeichnung" },
            Fra = new string[] { "équipiers", "vous", "honoré" },
        };

        /// <see href="https://xivapi.com/LogMessage/1534?pretty=true">Duty has ended</see>
        public static LocalizedStrings DutyEnded { get; } = new() {
            Jpn = new string[] { "の攻略を終了した" },
            Eng = new string[] { "has", "ended" },
            Deu = new string[] { "wurde", "beendet" },
            Fra = new string[] { "prend", "fin" },
        };

        /// <see href="https://xivapi.com/LogMessage/1530?pretty=true">Guildhest will end soon</see>
        public static LocalizedStrings GuildhestEnded { get; } = new() {
            Jpn = new string[] { "全員が特務隊長から報酬を受け取る" },
            Eng = new string[] { "the", "guildhest", "will", "end", "soon" },
            Deu = new string[] { "das", "gildengeheiß", "endet", "alle", "teilnehmer" },
            Fra = new string[] { "guilde", "prendre", "fin" },
        };

        // With the chat mode in Say, enter a phrase containing "Some Words"
        public static LocalizedStrings SayQuestReminder { get; } = new() {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "with", "the", "chat", "mode", "in" },
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/9331?pretty=true">You sense the presence of a powerful mark...</see>
        public static LocalizedStrings PowerfulMark { get; } = new() {
            Jpn = new string[] { "強大なリスキーモブの気配を感じる" },
            Eng = new string[] { "you", "sense", "the", "presence", "of", "a", "powerful", "mark" },
            Deu = new string[] { "du", "spücrst", "hochwild" },
            Fra = new string[] { "vous", "ressentez", "présence", "monstre" },
        };

        /// <see href="https://xivapi.com/LogMessage/9332?pretty=true">The minions of an extraordinarily powerful mark...</see>
        public static LocalizedStrings ExtraordinarilyPowerfulMark { get; } = new() {
            Jpn = new string[] { "特殊なリスキーモブの配下が", "偵察活動を開始したようだ"},
            Eng = new string[] { "minions", "extraordinarily", "powerful", "mark" },
            Deu = new string[] { "die", "helfer", "eines", "besonderen", "hochwilds" },
            Fra = new string[] { "les", "sous-fifres", "du", "monstre" }
        };

        /// <see href="https://xivapi.com/LogMessage/4341?pretty=true">Retainer completed a venture.</see>
        public static LocalizedStrings CompletedVenture { get; } = new()
        {
            Jpn = new string[] { "冒険を終えました！" },
            Eng = new string[] { "completed", "a", "venture" },
            Deu = new string[] { "hat", "eine", "unternehmung", "abgeschlossen" },
            Fra = new string[] { "terminé", "sa", "tâche" }
        };


        public static LocalizedStrings GainExperiencePoints { get; } = new()
        {
            Jpn = new string[] { "you", "ポイントの経験値" },
            Eng = new string[] { "you", "experience", "points" }, //You gain \d <class> experience points
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/2246?pretty=true">A bonus of 1,200,000 experience points and 12,000 gil has been awards for using the duty roulette.</see>
        public static LocalizedStrings RouletteBonus { get; } = new()
        {
            Jpn = new string[] { "コンテンツルーレットのボーナスとして" },
            Eng = new string[] { "a", "bonus", "has", "been", "awarded", "for", "using", "the", "duty", "roulette" },
            Deu = new string[] { "deinen", "mut", "einer", "herausforderung", "stellen" },
            Fra = new string[] { "un", "bonus", "pour", "avoir", "utilisé" },
        };

        /// <see href="https://xivapi.com/LogMessage/2244?pretty=true">A bonus of 12,000 gil has been awared for being an adventurer in need.</see>
        public static LocalizedStrings AdventurerInNeedBonus { get; } = new()
        {
            Jpn = new string[] { "不足ロールボーナスとして" },
            Eng = new string[] { "a", "bonus", "for", "being", "an", "adventurer", "in", "need" },
            Deu = new string[] { "die", "teilnahme", "einer", "gefragten", "rolle" },
            Fra = new string[] { "bonus", "pour", "avoir", "rempli", "nombre", "insuffisant" },
        };

        /// <see href="https://xivapi.com/LogMessage/659?pretty=true">You acquire \d PvP EXP.</see>
        public static LocalizedStrings GainPvpExp { get; } = new() {
            Jpn = new string[] { "pvp", "exp" },
            Eng = new string[] { "you", "acquire", "pvp", "exp" },
            Deu = new string[] { "pvp", "exp" },
            Fra = new string[] { "vous", "jcj" },
        };

        public static LocalizedStrings ObtainWolfMarks { get; } = new() {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "obtain", "wolf", "marks" }, // You obtain ### Wolf Marks.
            Deu = new string[] { "erhalten", "wolfsmarken" },
            Fra = new string[] { "marques", "de", "loup" },
        };

        public static LocalizedStrings CappedWolfMarks { get; } = new() {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "cannot", "receive", "any", "more", "wolf", "marks" }, // You cannot receive any more Wolf Marks. (Error Message)
            Deu = new string[] { "du", "kannst", "keine" , "wolfsmarken" },
            Fra = new string[] { "marques", "de", "loup" },
        };

        public static LocalizedStrings EarnAchievement { get; } = new() {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "the", "achievement" }, // You earn the achievement <achievement>
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        public static LocalizedStrings YouSynthesize { get; } = new() {
            Jpn = new string[] { "you", "を完成させた！" },
            Eng = new string[] { "you", "synthesize" }, // You synthesize a/an <item>
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        public static LocalizedStrings ObtainedTomestones { get; } = new()
        {
            Jpn = new string[] { "アラガントームストーン", "手", "入", "た。"}, // (?:手に入れ|入手し)た
            Eng = new string[] { "you", "obtain", "allagan", "tomestones", "of" }, // You obtain Allagan Tomestones of <type>
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/3794?pretty=true">Ready Check Complete.</see>
        public static LocalizedStrings ReadyCheckComplete { get; } = new() {
            Jpn = new string[] { "レディチェックが終了しました" },
            Eng = new string[] { "ready", "check", "complete" },
            Deu = new string[] { "bereitschaftsanfrage" },
            Fra = new string[] { "l'appel", "préparation", "pris", "fin" },
        };

        public static LocalizedStrings YouAttainLevel { get; } = new() {
            Jpn = new string[] { "レベルアップ！", "you", "になった。" },
            Eng = new string[] { "you", "level" }, // You attain level <level>.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        public static LocalizedStrings OtherAttainsLevel { get; } = new()
        {
            // BUG: this won't match abbreviated player names; need to be able to mix string and regexp
            Jpn = new string[] { "レベルアップ！", " ", "になった。" },
            Eng = new string[] { "attains", "level" }, // <Player> attains level 33!
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        public static LocalizedStrings YouLearnAbility { get; } = new() {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "learn" }, // You learn <ability>.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/5260?pretty=true">Battle commencing in <time> seconds.</see>
        public static LocalizedStrings CountdownTime { get; } = new() {
            Jpn = new string[] { "戦闘開始まで", "秒" },
            Eng = new string[] { "battle", "commencing", "in", "seconds" },
            Deu = new string[] { "noch", "sekunde" },
            Fra = new string[] { "début", "combat", "dans" },
        };

        public static LocalizedStrings DebugTeleport { get; } = new() {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "teleporting", "to" }, // Teleporting to <Location>...
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/2600?pretty=true">You sense something foul may be lurking in the distance.</see>
        /// <seealso href="https://xivapi.com/LogMessage/4791?pretty=true">You sense something close.</see>
        public static LocalizedStrings SpideySenses { get; } = new() {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "sense", "something" }, // You sense something...
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/3712?pretty=true">The compass detects a current approximately <##> yalms to the <direction>...</see>
        public static LocalizedStrings AetherCompass { get; } = new() {
            Jpn = new string[] { "コンパスの針は" },
            Eng = new string[] { "the", "compass", "detects", "a", "current", "approximately" },
            Deu = new string[] { "spücrst", "eine", "quelle", "yalme" },
            Fra = new string[] { "boussole", "indique" },
        };

        /// <see href="https://xivapi.com/LogMessage/4364?pretty=true">Glamours projected from plate <##></see>
        public static LocalizedStrings GlamoursProjected { get; } = new()
        {
            Jpn = new string[] { "ミラージュプレート", "により武具投影が行われました。" },
            Eng = new string[] { "glamours", "projected", "from", "plate" },
            Deu = new string[] { "die", "projektionsplatte", "angewendet" },
            Fra = new string[] { "planche", "mirage", "projeté" },
        };

        public static LocalizedStrings OvermeldFailure { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "unable", "to", "attach", "the", "materia", "to" }, // You are unable to attach the materia to the <item>. The <materia> was lost.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        public static LocalizedStrings MateriaExtract { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "successfully", "a", "from", "the" }, // You succesfully extra a <materia> from the <item>
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        public static LocalizedStrings LocationAffects { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "the", "location", "affects", "your" }, // The location affects your...
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        public static LocalizedStrings GatheringYield { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "gathering", "yield" }, // ...gathering yield.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        public static LocalizedStrings GatherersBoon { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "chance", "of", "receiving", "the", "gatherer's", "boon" }, // ...chance of receiving the Gatherer's boon.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        public static LocalizedStrings GatheringAttempts { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "increased", "integrity", "number", "of", "gathering", "attempts" },
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/38?pretty=true">Trade complete.</see>
        public static LocalizedStrings TradeComplete { get; } = new()
        {
            Jpn = new string[] { "トレードが完了しました" },
            Eng = new string[] { "trade", "complete" },
            Deu = new string[] { "der", "handel", "wurde", "abgeschlossen" },
            Fra = new string[] { "l'échange", "est", "terminé" },
        };

        /// <see href="https://xivapi.com/LogMessage/36?pretty=true">Trade canceled.</see>
        public static LocalizedStrings TradeCanceled { get; } = new()
        {
            Jpn = new string[] { "トレードがキャンセルされました" },
            Eng = new string[] { "trade", "canceled" },
            Deu = new string[] { "l'échange", "été", "annulé" },
            Fra = new string[] { "der", "handel", "worde", "abgebrochen" },
        };

        /// <see href="https://xivapi.com/LogMessage/33?pretty=true">Trade request sent to <player></see>
        public static LocalizedStrings TradeSent { get; } = new()
        {
            Jpn = new string[] { "にトレードを申し込みました" },
            Eng = new string[] { "trade", "request", "sent", "to" },
            Deu = new string[] { "du", "hast", "einen", "handel", "angeboten" },
            Fra = new string[] { "vous", "proposez", "un", "échange" },
        };

        /// <see href="https://xivapi.com/LogMessage/32?pretty=true">Awaiting trade confirmation from <player></see>
        public static LocalizedStrings AwaitingTradeConfirmation { get; } = new()
        {
            Jpn = new string[] { "の内容確認をまっています" },
            Eng = new string[] { "awaiting", "trade", "confirmation", "from" },
            Deu = new string[] { "warte", "auf", "bestätigung" },
            Fra = new string[] { "la", "proposition" },
        };

        /// <see href="https://xivapi.com/LogMessage/1?pretty=true">You invite <player> to a party.</see>
        public static LocalizedStrings InviteSent { get; } = new()
        {
            Jpn = new string[] { "をパーティに誘いました" },
            Eng = new string[] { "you", "invite", "to", "a", "party" },
            Deu = new string[] { "du", "hast", "die", "gruppe", "eingeladen" },
            Fra = new string[] { "vous", "invitez", "l'équipe" },
        };

        public static LocalizedStrings InviteeJoins { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "joins", "the", "party" }, // <Player> joins the party.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/73?pretty=true">The party has been disbanded.</see>
        public static LocalizedStrings PartyDisband { get; } = new()
        {
            Jpn = new string[] { "パーティが解散されました" },
            Eng = new string[] { "the", "party", "has", "been", "disbanded" },
            Deu = new string[] { "die", "gruppe", "wurde", "aufgelöst" },
            Fra = new string[] { "l'équipe", "été", "dissoute" },
        };

        /// <see href="https://xivapi.com/LogMessage/72?pretty=true">You dissolve the party.</see>
        public static LocalizedStrings PartyDissolved { get; } = new()
        {
            Jpn = new string[] { "パーティを解散しました" },
            Eng = new string[] { "dissolve", "party" },
            Deu = new string[] { "deine", "gruppe", "wurde", "aufgelöst" },
            Fra = new string[] { "l'équipe", "est", "dissoute" },
        };

        public static LocalizedStrings InvitedBy { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "invites", "you", "to", "a", "party" }, // <Player> invites you to a party.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        public static LocalizedStrings JoinParty { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "you", "join", "party" }, // You join <Player>'s party.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/4?pretty=true">You leave the party.</see>
        public static LocalizedStrings YouLeaveParty { get; } = new()
        {
            Jpn = new string[] { "パーティから離脱しました" },
            Eng = new string[] { "you", "leave", "party" },
            Deu = new string[] { "du", "hast", "gruppe", "verlassen" },
            Fra = new string[] { "vous", "quittez", "l'équipe" },
        };

        /// <see href="https://xivapi.com/LogMessage/7446?pretty=true">Cross-world party joined</see>
        public static LocalizedStrings JoinCrossParty { get; } = new()
        {
            Jpn = new string[] { "クロスワールドパーティに参加しました" },
            Eng = new string[] { "cross-world", "party", "joined" },
            Deu = new string[] { "du", "bist", "einer", "gruppe", "beigetreten" },
            Fra = new string[] { "vous", "avez", "rejoint", "inter-monde" },
        };

        public static LocalizedStrings LeftParty { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "has", "left", "the", "party" }, // <Player> has left the party.
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/440?pretty=true">You have been offered a teleport to <Aetheryte> from <Player>.</see>
        public static LocalizedStrings OfferedTeleport { get; } = new()
        {
            Jpn = new string[] { "へのテレポ勧誘を受けました" },
            Eng = new string[] { "you", "have", "been", "offered", "a", "teleport", "to", "from" },
            Deu = new string[] { "beitet", "einen", "teleport", "zielort" },
            Fra = new string[] { "offre", "de", "vous", "téléporter", "destination" },
        };

        public static LocalizedStrings RelicBookStep { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "record", "of", "added", "for" }, // Record of <boss> kill (n/m) added for <Relic Weapon> - <Stats>.1
            Deu = new string[] { "NeedsLocalization" },
            Fra = new string[] { "NeedsLocalization" },
        };

        /// <see href="https://xivapi.com/LogMessage/4400?pretty=true">All objectives under the category <Category> - <buff> complete!</see>
        public static LocalizedStrings RelicBookComplete { get; } = new()
        {
            Jpn = new string[] { "のカテゴリ", "をコンプリートした" },
            Eng = new string[] { "all", "objectives", "under", "the", "category", "complete" },
            Deu = new string[] { "alle", "ziele", "kategorie", "ephemeridentafel" },
            Fra = new string[] { "vous", "avez", "accompli", "toutes", "catégorie" },
        };

        public static LocalizedStrings PalaceOfTheDead { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "palace", "dead", "begun" }, // Palace of the Dead Floors (x-y) has begun
            Deu = new string[] { "palast", "der", "toten" },
            Fra = new string[] { "palais", "des", "morts" },
        };

        public static LocalizedStrings HeavenOnHigh { get; } = new()
        {
            Jpn = new string[] { "NeedsLocalization" },
            Eng = new string[] { "heaven-on-high", "begun" }, // Heaven-on-High Floors (x-y) has begun
            Deu = new string[] { "himmelssäule" },
            Fra = new string[] { "pillier", "des", "cieux" },
        };

        /// <see href="https://xivapi.com/LogMessage/859?pretty=true">Total Play time: 249 days, 12 hours, 30 minutes</see>
        public static LocalizedStrings Playtime { get; } = new()
        {
            Jpn = new string[] { "累積プレイ時間" },
            Eng = new string[] { "total", "play", "time" },
            Deu = new string[] { "gesamtspielzeit" },
            Fra = new string[] { "temps", "de", "jeu", "total" },
        };

        /// <see href="https://xivapi.com/LogMessage/7027?pretty=true">You've joined the Novice Network</see>
        public static LocalizedStrings NoviceNetworkJoin { get; } = new()
        {
            Jpn = new string[] { "ビギナーチャンネルに参加しました" },
            Eng = new string[] { "joined", "the", "novice", "network" },
            Deu = new string[] { "bist", "neulings-chat", "beigetreten" },
            Fra = new string[] { "vous", "rejoint", "réseau", "novices" },
        };

        /// <see href="https://xivapi.com/LogMessage/7030?pretty=true">You have left the Novice Network</see>
        public static LocalizedStrings NoviceNetworkLeft { get; } = new()
        {
            Jpn = new string[] { "ビギナーチャンネルから退出しました" },
            Eng = new string[] { "left", "the", "novice", "network" },
            Deu = new string[] { "hast", "neulings-chat", "verlassen" },
            Fra = new string[] { "vous", "quitté", "réseau", "novices" },
        };
    }
}
