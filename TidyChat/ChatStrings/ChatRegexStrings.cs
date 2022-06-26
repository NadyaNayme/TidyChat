using System.Text.RegularExpressions;

namespace TidyChat;

public static class ChatRegexStrings
{
    private static readonly RegexOptions regexOptions =
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

    public static readonly Regex BetterPlayerCommendation = new(@"You received \d{1} (commendation|commendations)",
        regexOptions);

    /// <see href="https://xivapi.com/LogMessage/657?pretty=true">You obtain...</see>
    public static readonly LocalizedRegex ObtainedGil = new()
    {
        Jpn = new Regex(@"ギルを手に入れた。$", regexOptions),
        Eng = new Regex(@"^You (obtain|obtains) (\d{1,3},)?\d{1,3} gil\.$", regexOptions),
        Deu = new Regex(@"^(du|you) hast (\d{1,3},)?\d{1,3} gil erhalten\.$", regexOptions),
        Fra = new Regex(@"^(vous|you) obtenez \d{1,6} gils\.$", regexOptions)
    };

    public static readonly LocalizedRegex ObtainedMGP = new()
    {
        Jpn = new Regex(@"(\d{1,3},)?\d{1,3} MGP", regexOptions),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} MGP\.$", regexOptions),
        Deu = new Regex(@"(\d{1,3},)?\d{1,3} MGP erhalten\.$", regexOptions),
        Fra = new Regex(@"^(vous|you) (a|avez) reçu \d{1,6} PGS\.$", regexOptions)
    };

    /// <see href="https://xivapi.com/Item/25?pretty=true">Wolf Marks</see>
    public static readonly LocalizedRegex ObtainedWolfMarks = new()
    {
        Jpn = new Regex(@"(\d{1,3},)?\d{1,3} 対人戦績", regexOptions),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} wolf marks\.$", regexOptions),
        Deu = new Regex(@"(\d{1,3},)?\d{1,3} wolfsmarken erhalten\.$", regexOptions),
        Fra = new Regex(@"^(vous|you) (a|avez) reçu \d{1,6} marque de loup\.$", regexOptions)
    };


    /// <see href="https://xivapi.com/Item/21072?pretty=true">Venture</see>
    public static readonly Regex ObtainedVenture =
        new(@"You (obtain|obtains) (a venture|2 ventures|3 ventures)\.", regexOptions);

    /// <see href="https://xivapi.com/Item/27?pretty=true">Allied Seals</see>
    public static readonly LocalizedRegex ObtainedAlliedSeals = new()
    {
        Jpn = new Regex(@"^同盟記章を(\d{1,3},)?\d{1,3}個手に入れた。$", regexOptions),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} Allied Seals\.$", regexOptions),
        Deu = new Regex(@"(\d{1,3},)?\d{1,3} jagdabzeichen erhalten\.", regexOptions),
        Fra = new Regex(@"^(vous|you) obtenez \d{1,6} insignes alliés\.$", regexOptions)
    };

    /// <see href="https://xivapi.com/Item/10307?pretty=true">Centurio Seals</see>
    public static readonly LocalizedRegex ObtainedCenturioSeals = new()
    {
        Jpn = new Regex(@"^セントリオ記章を(\d{1,3},)?\d{1,3}個手に入れた。$", regexOptions),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} Centurio Seals\.$", regexOptions),
        Deu = new Regex(@"(\d{1,3},)?\d{1,3} centurio-abzeichen erhalten\.$", regexOptions),
        Fra = new Regex(@"^(vous|you) obtenez \d{1,6} insignes centurio\.$", regexOptions)
    };

    public static readonly LocalizedRegex ObtainedNuts = new()
    {
        Jpn = new Regex(@"^モブハントの戦利品を(\d{1,3},)?\d{1,3}個手に入れた。$", regexOptions),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} sacks of Nuts\.$", regexOptions),
        Deu = new Regex(@"(\d{1,3},)?\d{1,3} kupo-trophaë\.", regexOptions),
        Fra = new Regex(@"^(vous|you) obtenez \d{1,6} insignes de chasse\.$", regexOptions)
    };

    /// <see href="https://xivapi.com/Item/20?pretty=true">Storm Seals</see>
    /// <seealso href="https://xivapi.com/Item/21?pretty=true">
    ///     Serpent Seals</see>
    ///     <seealso href="https://xivapi.com/Item/22?pretty=true">Flame Seals</see>
    public static readonly LocalizedRegex ObtainedSeals = new()
    {
        Jpn = new Regex(@"の軍票(\d{1,3},)?\d{1,3}枚を手に入れた。$", regexOptions),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} (Flame|Storm|Serpent) Seals\.$", regexOptions),
        Deu = new Regex(@"(flottentaler|ordenstaler|legionstaler) erhalten", regexOptions),
        Fra = new Regex(@"^(vous|you) obtenez \d{1,6} sceaux (de|des) (Immortels|Deux Vipères|Maelstrom)\.$",
            regexOptions)
    };

    /// <see href="https://xivapi.com/Item/2?pretty=true">Fire Shard</see>
    /// ...
    /// <seealso href="https://xivapi.com/Item/19?pretty=true">Water Cluster</see>
    public static readonly LocalizedRegex ObtainedClusters = new()
    {
        Jpn = new Regex(@"クラスター(×2)?を(手に入れた|入手した)。$", regexOptions),
        Eng = new Regex(@"^you (obtain|obtains) (a|2) (.*)cluster\.$", regexOptions),
        Deu = new Regex(@"NeedsLocalization", regexOptions),
        Fra = new Regex(@"NeedsLocalization", regexOptions)
    };

    public static readonly Regex ObtainedMaterials = new(@"^you (obtain|obtains) (.*) materials\.$", regexOptions);

    public static readonly Regex ObtainedShards =
        new(
            @"^you (obtain|obtains) (a|an|\d{1,3}) .{1,3}(fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.$",
            regexOptions);

    public static readonly LocalizedRegex ObtainedTribalCurrency = new()
    {
        Jpn = new Regex(@"NeedsTranslation", regexOptions),
        Eng = new Regex(
            @"^you (obtain|obtains) (a|an|2) (Steel (Amalj'ok|Amalj'oks)|Sylphic (Goldleaf|Goldleaves)|Titan (Cobaltpiece|Cobaltpieces)|(Rainbowtide Psashp|Psashps)|Ixali (oaknot|oaknots)|Vanu (Whitebone|Whitebones)|Black Copper (Gil|Gils)|Carved Kupo (Nut|Nuts)|Kojin (Sango|Sangos)|Ananta Dreamstaves|Ananta Dreamstaffs|Namazu (Koban|Kobans)|Fae (Fancy|Fancies)|Qitari (Compliment|Compliments)|Hammered (Frogment|Fragments)|Arkasodara (Pana|Panas))\.$",
            regexOptions),
        Deu = new Regex(
            @"^(du|you) hast (einen|2) (Stahl-Amalj'ok|Sylphen-goldblatt|Titan-koboldeistenstück|Regenbogenwellen-Psashp|Ixal-eichenmünze|Vanu-Weißknochen|Schwarzkupfer-Gil|Kupo-Schnitznuss|Kohin-Koralle|Ananta-Traumstab|Namazuo-Koban|Pixie-Glitter|Qitari-Kastanienkreuzer|Zwergenmünze) erhalten\.$",
            regexOptions),
        Fra = new Regex(@"NeedsTranslation", regexOptions)
    };

    public static readonly LocalizedRegex PlayerTargetedEmote = new()
    {
        Jpn = new Regex(@"You|Your", regexOptions),
        Eng = new Regex(@"you|your", regexOptions),
        Deu = new Regex(@"you|your|du|deiner|dir|dich", regexOptions),
        Fra = new Regex(@"you|your|vous", regexOptions)
    };

    public static readonly LocalizedRegex StartsWithYou = new()
    {
        Jpn = new Regex(@"^(You|Your)", regexOptions),
        Eng = new Regex(@"^(You|Your)", regexOptions),
        Deu = new Regex(@"^(You|Your|du|deiner|dir|dich)", regexOptions),
        Fra = new Regex(@"^(Vous)", regexOptions)
    };

    public static readonly LocalizedRegex CastLot = new()
    {
        Jpn = new Regex(@"^youは.*にロットした。$", regexOptions),
        Eng = new Regex(@"^you (cast|casts) (your|his|her) lot for (.*)\.$", regexOptions),
        Deu = new Regex(@"NeedsLocalization", regexOptions),
        Fra = new Regex(@"NeedsLocalization", regexOptions)
    };

    public static readonly LocalizedRegex RollsNeedOrGreed = new()
    {
        Jpn = new Regex(@"^youは.+に(NEED|GREED)のダイスで\d{1,2}を出した。$", regexOptions),
        Eng = new Regex(@"^you (roll|rolls) (Need|Greed) on (.*)\. \d{1,2}\!$", regexOptions),
        Deu = new Regex(@"NeedsLocalization", regexOptions),
        Fra = new Regex(@"NeedsLocalization", regexOptions)
    };

    public static readonly LocalizedRegex OthersCastLot = new()
    {
        // relies on the fact that all player names have a space between them (or a period if initialised)
        Jpn = new Regex(@"^\w+[ .].+は.+にロットした。$", regexOptions),
        Eng = new Regex(@"(.*) casts (his|her) lot for (.*)\.$", regexOptions),
        Deu = new Regex(@"NeedsLocalization", regexOptions),
        Fra = new Regex(@"(.*) lance ses dés pour (la|le|les) (.*)\.$", regexOptions)
    };

    public static readonly LocalizedRegex OthersRollNeedOrGreed = new()
    {
        Jpn = new Regex(@"^\w+[ .].+は.+に(NEED|GREED)のダイスで\d{1,2}を出した。$", regexOptions),
        Eng = new Regex(@"(.*) rolls (Need|Greed) on (.*)\. \d{1,2}\!$", regexOptions),
        Deu = new Regex(@"NeedsLocalization", regexOptions),
        Fra = new Regex(@"(.*) jette les dés (Cupidité) pour (la|le|les) (.*)", regexOptions)
    };

    public static readonly LocalizedRegex YouObtainSystem = new()
    {
        Jpn = new Regex(@"^youは.+を手に入れた。$", regexOptions),
        Eng = new Regex(@"^you obtain.+", regexOptions),
        Deu = new Regex(@"NeedsLocalization", regexOptions),
        Fra = new Regex(@"^vous obtient", regexOptions)
    };

    public static readonly LocalizedRegex OtherObtains = new()
    {
        Jpn = new Regex(@"^\w+[ .].+は.+を手に入れた。$", regexOptions),
        Eng = new Regex(@"(.*) obtains .+", regexOptions),
        Deu = new Regex(@"NeedsLocalization", regexOptions),
        Fra = new Regex(@"(.*) obtient (un|une|\d{1,3}) .+", regexOptions)
    };

    public static readonly LocalizedRegex ItemSearchCommand = new()
    {
        Jpn = new Regex(@"^\s{1,3}>>|を含む所持アイテムは(\d{1,4}種類見つかりました|ありませんでした)。$", regexOptions),
        Eng = new Regex(@"(\s{1,3}>>|(No|\d{1,4}) (match|matches) found containing)", regexOptions),
        Deu = new Regex(@"NeedsLocalization", regexOptions),
        Fra = new Regex(@"NeedsLocalization", regexOptions)
    };

    public static readonly LocalizedRegex SearchForItemResults = new()
    {
        // TODO: items found in the armory chest, items in second tab of saddlebag
        Jpn = new Regex(
            @"^ミラージュドレッサーに\d個あります。$|^愛蔵品キャビネット「.+」に\d個あります。$|に装備中です。$|合計\d{1,9}個見つかりました。|^所持品ブロック[1234]に\d{1,9}個あります。$|^チョコボかばんのかばんタブ[12]に\d{1,9}個あります。$",
            regexOptions),
        Eng = new Regex(
            @"(\d (item|items) found in glamour dresser\.)|(\d (item|items) found in the .* section of the armoire\.)|(Currently equipped to .* slot)|(Total: \d{1,9} (item|items) found)|(\d{1,9} (item|items) found in the (1st|2nd|3rd|4th) tab of (your|.+'s) inventory)|\d{1,9} (item|items) found in saddlebag",
            regexOptions),
        Deu = new Regex(@"NeedsLocalization", regexOptions),
        Fra = new Regex(@"NeedsLocalization", regexOptions)
    };

    public static readonly LocalizedRegex ObtainedTomestones = new()
    {
        Jpn = new Regex(@"^アラガントームストーン:([^を]+)を(\d{1,3}個手に入れた|入手した)。$", regexOptions),
        Eng = new Regex(@"^you (obtain|obtains) \d{1,3} Allagan tomestones of", regexOptions),
        Deu = new Regex(
            @"(du|you) hast \d{1,3} (Allagischer|Allagisch|Allagische|Allagischa) (Stein|Steine) (der|des) \w+ erhalten\.$",
            regexOptions),
        Fra = new Regex(@"(vous|you) obtenez \d{1,3} Mémoquartz allagois (\w+)", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/700?pretty=true">Gearset equipped.</see>
    // TODO: German/French need to be tested and may not use quotes for the gearsets.
    public static readonly LocalizedRegex GearsetEquipped = new()
    {
        Jpn = new Regex(@"」に装備変更しました。$", regexOptions),
        Eng = new Regex(@"^“(.*)” equipped\.$", regexOptions),
        Deu = new Regex(@"^du hast „(.*)“ angelegt\.$", regexOptions),
        Fra = new Regex(@"^vous vous équipez (.*)\.$", regexOptions)
    };

    // Future proofing the materias a bit here
    public static readonly Regex MateriaRetrieved =
        new(
            @"^you (receive|receives) (a|an|2) .+ materia [I|V|X|L|C|D|M]{1,10}",
            regexOptions);

    public static readonly Regex MateriaShatters =
        new(
            @"^the .+ materia [I|V|X|L|C|D|M]{1,10} shatters",
            regexOptions);

    public static readonly Regex AttachedMateria =
        new(
            @"^you successfully attach (a|an) .+ materia [I|V|X|L|C|D|M]{1,10} to the",
            regexOptions);

    /// <see href="https://xivapi.com/LogMessage/3860?pretty=true">Master volume muted/unmuted</see>
    /// ...
    /// <seealso href="https://xivapi.com/LogMessage/3866?pretty=true">Performance volume muted/unmuted</see>
    public static readonly LocalizedRegex VolumeControls = new()
    {
        Jpn = new Regex(@"をミュートしました。$|のミュートを解除しました。$|の音量を\d{1,3}に変更しました。$", regexOptions),
        Eng = new Regex(@"volume (muted|unmuted|set to \d{1,3}\.$)", regexOptions),
        Deu = new Regex(@"NeedsLocalization", regexOptions),
        Fra = new Regex(
            @"^vous avez (activé|déactivé) (la|le|les|l'ambiance) (musqiue|volume général|effets sonores|voix|sons système|sonore|haut-parleur pour les sons système)\.$",
            regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/1063?pretty=true">You begin mining.</see>
    /// ...
    /// <seealso href="https://xivapi.com/LogMessage/1070?pretty=true">You finish harvesting.</see>
    public static readonly LocalizedRegex GatheringStartEnd = new()
    {
        Jpn = new Regex(@"は(採掘|砕岩|伐採|草刈)を(開始した|終えた)", regexOptions),
        Eng = new Regex(@"^you (begin|finish) (mining|quarrying|logging|harvesting)\.$", regexOptions),
        Deu = new Regex(
            @"^(du|deiner|dir|dich) (beginnst|beginnt|bist fertig mit dem|ist fertig mit dem) (abzubauen|herauszubrechen|abzuholzen|abzuernten|Abbauen|Herausbrechen|Abholzen|Abernten)",
            regexOptions),
        Fra = new Regex(
            @"^vous (commencez|arrêtez) (á extraire|d'extraire) (du minerai|des pierres|couper du bois|faucher de la végétation)\.",
            regexOptions)
    };

    public static readonly Regex AetherialReductionSands = new(@".+handfuls of .+ .+sand are obtained\.", regexOptions);

    /// <see href="https://xivapi.com/LogMessage/2012?pretty=true">Area will be sealed off in 15 seconds</see>
    /// <seealso href="https://xivapi.com/LogMessage/2013?pretty=true">
    ///     Area is sealed off!</see>
    ///     <seealso href="https://xivapi.com/LogMessage/2014?pretty=true">Area is no longer sealed!</see>
    public static readonly LocalizedRegex SealedOff = new()
    {
        Jpn = new Regex(@"(の封鎖まであと|が封鎖された！|の封鎖が解かれた)", regexOptions),
        Eng = new Regex(@"(will be sealed off in 15 seconds|is sealed off|is no longer sealed)", regexOptions),
        Deu = new Regex(@"((sekunde|sekunden)\, bis sich .+ schließt\.|hat sich geschlossen\.|öffnet sich wieder\.)",
            regexOptions),
        Fra = new Regex(@"(dans \d{1,2} secondes\.|Fermeture|Ouverture)", regexOptions)
    };

    // Name S. gains \d{1,4} (+\d{1,2}%) experience points.
    public static readonly LocalizedRegex GainExperiencePoints = new()
    {
        Jpn = new Regex(@"ポイントの経験値を得た。$", regexOptions),
        Eng = new Regex(@".* gains .* experience points\.$", regexOptions),
        Deu = new Regex(@"NeedsLocalization", regexOptions),
        Fra = new Regex(@".* gagnez .* points d'expérience\.$", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/744?pretty=true">Your spiritbond with item is complete!</see>
    public static readonly LocalizedRegex CompleteSpiritbond = new()
    {
        Jpn = new Regex(@"の錬精度が100%になった！$", regexOptions),
        Eng = new Regex(@"^your spiritbond with .+ is complete\!$", regexOptions),
        Deu = new Regex(@"^deine emotionale bindung an .+ hat 100 \% erreicht\!$", regexOptions),
        Fra = new Regex(@"^vous êates en symbiose avec", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/3085?pretty=true">Player has logged out</see>
    public static readonly LocalizedRegex HasLoggedIn = new()
    {
        Jpn = new Regex(@"ポイント上昇した！$", regexOptions),
        Eng = new Regex(@"(has|have) logged in\.$", regexOptions),
        Deu = new Regex(@"hat sich eingeloggt\.$", regexOptions),
        Fra = new Regex(@"s'est (connecté|connectée)\.$", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/3086?pretty=true">Player has logged out</see>
    public static readonly LocalizedRegex HasLoggedOut = new()
    {
        Jpn = new Regex(@"がログアウトしました。$", regexOptions),
        Eng = new Regex(@"has logged out\.$", regexOptions),
        Deu = new Regex(@"hat sich ausgeloggt\.$", regexOptions),
        Fra = new Regex(@"s'est (déconnecté|déconnectée)\.$", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/6065?pretty=true">A new entry has been added to the free company message book.</see>
    public static readonly LocalizedRegex FreeCompanyMessageBook = new()
    {
        Jpn = new Regex(@"フリーカンパニーハウスの交流帳に新着メッセージがあります", regexOptions),
        Eng = new Regex(@"new entry has been added to the free company message book", regexOptions),
        Deu = new Regex(@"jemand hat einen neuen eintrag im diarium der freien gesellschaft hinterlassen",
            regexOptions),
        Fra = new Regex(
            @"un ou plusieurs nouveaux messages ont été laissés dans le livre de correspondance de votre maison de compagnie libre",
            regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/6066?pretty=true">A new entry has been added to your estate message book.</see>
    public static readonly LocalizedRegex PersonalEstateMessageBook = new()
    {
        Jpn = new Regex(@"(個人ハウス|個室|アパルトメント)の交流帳に新着メッセージがあります", regexOptions),
        Eng = new Regex(@"new entry has been added to your (estate|room|apartment) message book", regexOptions),
        Deu = new Regex(
            @"jemand hat einen neuen eintrag im diarium deiner (wohnung hinterlassen|zimmers hinterlassen|unterkunft hinterlassen)",
            regexOptions),
        Fra = new Regex(
            @"un ou plusieurs nouveaux messages ont été laissés dans le livre de correspondance de votre (appartemen|chambre individuelle|maison individuelle)",
            regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/23?pretty=true">You are now a leader of Linkshell.</see>
    /// <seealso>XivAPI for various other Leader Of messages: 15, 16, 23, 24, 367, 383, 9284, 9285, 9298, 9289, 9290, 9291</seealso>
    public static readonly LocalizedRegex NowLeaderOf = new()
    {
        Jpn = new Regex(@"(のリーダーに設定されました|リーダー設定を解除しました)", regexOptions),
        Eng = new Regex(
            @"((are|is) (now|no longer) a leader|(is now the|has promoted you to) party leader|have been granted to)",
            regexOptions),
        Deu = new Regex(
            @"du bist (nun|nicht) ein anführer",
            regexOptions),
        Fra = new Regex(
            @"êtes maintenant (membre|officier) de",
            regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/4233?pretty=true">
    ///     Party members are eligible for duty rewards. The number of
    ///     coffers to appear will be 2/2.
    /// </see>
    /// <seealso href="https://xivapi.com/LogMessage/4238?pretty=true">
    ///     Party members are eligible for duty rewards. The number of coffers to appear will be 2/2.</see>
    ///     <seealso href="https://xivapi.com/LogMessage/4246?pretty=true">
    ///         Party members are eligible for duty rewards. The
    ///         number of coffers to appear will be 2/2.</see>
    public static readonly LocalizedRegex EligibleForCoffers = new()
    {
        Jpn = new Regex(@"リワード取得の権利を有するパーティメンバー数が", regexOptions),
        Eng = new Regex(@"number of coffers", regexOptions),
        Deu = new Regex(
            @"wöchentliche vergütung erhalten",
            regexOptions),
        Fra = new Regex(
            @"le nombre de coffres sera de",
            regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/4225?pretty=true">
    ///     One or more party members have yet to complete this duty. A
    ///     bonus of ... will be awarded upon completion.
    /// </see>
    public static readonly LocalizedRegex PartyMemberFirstClear = new()
    {
        Jpn = new Regex(@"未制覇の参加メンバーがいるため、攻略成功時に", regexOptions),
        Eng = new Regex(@"one or more party members have yet to complete this duty", regexOptions),
        Deu = new Regex(
            @"weil ein charakter diesen inhalt noch nicht beendet hat",
            regexOptions),
        Fra = new Regex(
            @"un ou plusieurs participants n\'ont pas encore accompli cette mission",
            regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/4225?pretty=true">
    ///     One or more party members have yet to complete this duty. A
    ///     bonus of ... will be awarded upon completion.
    /// </see>
    public static readonly LocalizedRegex FirstClearAward = new()
    {
        Jpn = new Regex(@"未制覇の参加メンバーがいるため、攻略成功時に", regexOptions),
        Eng = new Regex(@"a bonus of", regexOptions),
        Deu = new Regex(
            @"erhalten alle teilnehmer bei abschluss",
            regexOptions),
        Fra = new Regex(
            @"l\'équipe recevra",
            regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7975?pretty=true">
    ///     One or more party members have yet to complete this duty.
    ///     Second Chance points added to your journal.
    /// </see>
    public static readonly LocalizedRegex SecondChanceAward = new()
    {
        Jpn = new Regex(@"チャンスポイントが加算されました", regexOptions),
        Eng = new Regex(@"second chance points added to your journal", regexOptions),
        Deu = new Regex(
            @"zusätzliche chance-punkte",
            regexOptions),
        Fra = new Regex(
            @"le nombre de points de chance dans le carnet",
            regexOptions)
    };

    public static readonly LocalizedRegex GetInstanceNumber = new()
    {
        Jpn = new Regex(@"(?<instance>||)", regexOptions),
        Eng = new Regex(@"(?<instance>||)", regexOptions),
        Deu = new Regex(@"(?<instance>||)", regexOptions),
        Fra = new Regex(@"(?<instance>||)", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/732?pretty=true">You have entered a sanctuary.</see>
    public static readonly LocalizedRegex EnteredSanctuary = new()
    {
        Jpn = new Regex(@"レストエリアに入った", regexOptions),
        Eng = new Regex(@"^you have entered a sanctuary", regexOptions),
        Deu = new Regex(@"^du hast einen ruhebereich betreten", regexOptions),
        Fra = new Regex(@"^vous êtes (entré|entrée) dans un lieu de repos", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/733?pretty=true">You have left the sanctuary.</see>
    public static readonly LocalizedRegex LeftSanctuary = new()
    {
        Jpn = new Regex(@"レストエリアから離れた", regexOptions),
        Eng = new Regex(@"^you have left the sanctuary", regexOptions),
        Deu = new Regex(@"^du hast den ruhebereich verlassen", regexOptions),
        Fra = new Regex(@"^vous aves quitté le lieu de repos", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/1351?pretty=true">You are currently not in an instanced area.</see>
    public static readonly LocalizedRegex NotInstancedArea = new()
    {
        Jpn = new Regex(@"インスタンスエリアは存在しません", regexOptions),
        Eng = new Regex(@"^you are currently not in an instanced area", regexOptions),
        Deu = new Regex(@"momentan ist das areal nicht instanziiert", regexOptions),
        Fra = new Regex(@"il n'y a actuellement aucune zone instanciée", regexOptions)
    };

    public static readonly LocalizedRegex QuestionMarkCommandResponse = new()
    {
        Jpn = new Regex(@"NeedsLocalization", regexOptions),
        Eng = new Regex(@"^(usage:|aliases:)", regexOptions),
        Deu = new Regex(@"NeedsLocalization", regexOptions),
        Fra = new Regex(@"NeedsLocalization", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/1272?pretty=true">You have arrived at a vista!</see>
    /// <seealso href="https://xivapi.com/LogMessage/1273?pretty=true">You have strayed too far from the vista.</see>
    public static readonly LocalizedRegex VistaMessages = new()
    {
        Jpn = new Regex(@"(探検手帳の目的地に到達した|探検手帳の目的地から離れた)", regexOptions),
        Eng = new Regex(@"^you have (arrived at a vista!|strayed too far from the vista\.)", regexOptions),
        Deu = new Regex(
            @"^du (bist an einem sehenswerten ort angekommen|hast dich von dem sehenswerten ort entfernt\.)",
            regexOptions),
        Fra = new Regex(@"(à un lieu notoire!|du lieu notoire\.)", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/1156?pretty=true">Someone synthesizes an item!</see>
    public static readonly LocalizedRegex OtherSynthesis = new()
    {
        Jpn = new Regex(@"完成させた", regexOptions),
        Eng = new Regex(@"synthesizes", regexOptions),
        Deu = new Regex(@"hergestellt", regexOptions),
        Fra = new Regex(@"fabrique", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/3911?pretty=true">You try on item.</see>
    public static readonly LocalizedRegex TryOnGlamour = new()
    {
        Jpn = new Regex(@"を試着した", regexOptions),
        Eng = new Regex(@"^you try on", regexOptions),
        Deu = new Regex(@"probeweise angelgt", regexOptions),
        Fra = new Regex(@"^vous essayez", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7005?pretty=true">
    ///     Unable to join Novice Network. The channel has reached the
    ///     maximum number of users.
    /// </see>
    public static readonly LocalizedRegex NoviceNetworkFull = new()
    {
        Jpn = new Regex(@"定員に達しているため", regexOptions),
        Eng = new Regex(@"^unable to join novice network\. the channel has reached the maximum number of users\.$",
            regexOptions),
        Deu = new Regex(@"^du konntest dem neulings-chat nicht beitreten, weil er bereits voll ist\.$", regexOptions),
        Fra = new Regex(
            @"^\(rdn\) impossible de rejoindre le réseau des novices\. Le nombre maximal de participants a été atteint\.$",
            regexOptions)
    };

    #region PotD & HoH

    /// <see href="https://xivapi.com/LogMessage/7221?pretty=true">The party obtains a pomander"</see>
    public static readonly LocalizedRegex ObtainedPomander = new()
    {
        Jpn = new Regex(@"たちは、", regexOptions),
        Eng = new Regex(@"the party obtains a", regexOptions),
        Deu = new Regex(@"ihr habt ein (.*) erhlaten\!", regexOptions),
        Fra = new Regex(@"et (vos|ses) compagnons (avez|ont) obtenu", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7222?pretty=true">
    ///     You return the pomander to the coffer. YOu cannot carry any
    ///     more of that item."
    /// </see>
    public static readonly LocalizedRegex ReturnedPomander = new()
    {
        Jpn = new Regex(@"はこれ以上、持つことができないようだ。宝箱に戻した、", regexOptions),
        Eng = new Regex(@"^you return the (.*) to the coffer\.$", regexOptions),
        Deu = new Regex(@"^du kannst kein weiteres (.*) aufnehmen und legst es in die", regexOptions),
        Fra = new Regex(@"^vous ne pouvez pas obtenir davantage", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7242?pretty=true">The cairn begins to glow!"</see>
    public static readonly LocalizedRegex CairnGlows = new()
    {
        Jpn = new Regex(@"が輝き始めた", regexOptions),
        Eng = new Regex(@"begins to glow\!", regexOptions),
        Deu = new Regex(@"beginnt zu leuchten", regexOptions),
        Fra = new Regex(@"a recommencé à briller", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7243?pretty=true">The...restores live to those fallen in battle!"</see>
    public static readonly LocalizedRegex RestoresLifeToFallen = new()
    {
        Jpn = new Regex(@"倒れていた冒険者に生気が宿った", regexOptions),
        Eng = new Regex(@"restores life to those fallen in battle", regexOptions),
        Deu = new Regex(@"hat die gefallenen abenteurer wiederbelebt", regexOptions),
        Fra = new Regex(@"remettant sur pied les aventuriers inconscients", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7245?pretty=true">... is activated!"</see>
    public static readonly LocalizedRegex CairnActivates = new()
    {
        Jpn = new Regex(@"が起動した", regexOptions),
        Eng = new Regex(@"is activated", regexOptions),
        Deu = new Regex(@"wurde aktiviert", regexOptions),
        Fra = new Regex(@"s'est activé", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7246?pretty=true">Three seconds until transference"</see>
    /// <see href="https://xivapi.com/LogMessage/7247?pretty=true">Transference canceled"</see>
    /// <see href="https://xivapi.com/LogMessage/7248?pretty=true">Transferenced initiated"</see>
    public static readonly LocalizedRegex Transference = new()
    {
        Jpn = new Regex(@"転移", regexOptions),
        Eng = new Regex(@"transference", regexOptions),
        Deu = new Regex(@"transport", regexOptions),
        Fra = new Regex(@"téléportation", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7245?pretty=true">
    ///     Aetherpool item flickers/brightens/flares. Its strength is
    ///     now +0-98"
    /// </see>
    public static readonly LocalizedRegex AetherpoolIncrease = new()
    {
        Jpn = new Regex(@"強化値が([0-9]|[1-8][0-9]|9[0-8])になった", regexOptions),
        Eng = new Regex(@"its strength is now \+([0-9]|[1-8][0-9]|9[0-8])", regexOptions),
        Deu = new Regex(@"steigt auf \+([0-9]|[1-8][0-9]|9[0-8])", regexOptions),
        Fra = new Regex(@"passe à \+([0-9]|[1-8][0-9]|9[0-8])", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7251?pretty=true">Your...remains unchanged"</see>
    public static readonly LocalizedRegex AetherpoolUnchanged = new()
    {
        Jpn = new Regex(@"の強化に失敗した", regexOptions),
        Eng = new Regex(@"remains unchanged\.\.\.", regexOptions),
        Deu = new Regex(@"wurde nicht verstärkt \.\.\.", regexOptions),
        Fra = new Regex(@"n'a pas pu être amélioré\.\.\.", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7255?pretty=true">All the traps on this floor have disappeared!"</see>
    public static readonly LocalizedRegex PomanderOfSafety = new()
    {
        Jpn = new Regex(@"この階層のトラップが、すべて消滅した", regexOptions),
        Eng = new Regex(@"all the traps on this floor have disappeared", regexOptions),
        Deu = new Regex(@"alle fallen dieser ebene wurden entfernt", regexOptions),
        Fra = new Regex(@"tous les pièges de l'étage ont été désamorcés", regexOptions)
    };


    /// <see href="https://xivapi.com/LogMessage/7256?pretty=true">The map for this floor has been revealed"</see>
    public static readonly LocalizedRegex PomanderOfSight = new()
    {
        Jpn = new Regex(@"この階層のマップが、すべて開示された", regexOptions),
        Eng = new Regex(@"the map for this floor has been revealed", regexOptions),
        Deu = new Regex(@"die gesamte karte dieser ebene wurde enthüllt", regexOptions),
        Fra = new Regex(@"la carte de l'étage a été entièrement révélée", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7259?pretty=true">You sense a treasure coffer somewhere nearby"</see>
    public static readonly LocalizedRegex PomanderOfAffluence = new()
    {
        Jpn = new Regex(@"どこかに宝箱の気配を感じた", regexOptions),
        Eng = new Regex(@"you sense a treasure coffer somewhere nearby", regexOptions),
        Deu = new Regex(@"du hast das gefühl, dass irgendwo eine schatztruhe zu finden ist", regexOptions),
        Fra = new Regex(@"vous avez le sentiment qu'il y a un coffre au trésor dans les environs", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7260?pretty=true">The howls of distant creatures begin to fade"</see>
    public static readonly LocalizedRegex PomanderOfFlight = new()
    {
        Jpn = new Regex(@"どこか遠くの魔物の気配が消えていった", regexOptions),
        Eng = new Regex(@"the howls of distant creatures begin to fade", regexOptions),
        Deu = new Regex(@"du spürst, dass eine feindliche präsenz in die ferne entschwunden ist", regexOptions),
        Fra = new Regex(@"vous avez le sentiment qu'une présence hostile a disparu", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7261?pretty=true">The sense a distant presence has changed"</see>
    public static readonly LocalizedRegex PomanderOfAlteration = new()
    {
        Jpn = new Regex(@"どこか遠くの魔物の気配が変わったようだ", regexOptions),
        Eng = new Regex(@"^you sense a distant presence has changed", regexOptions),
        Deu = new Regex(@"^du spürst eine veränderte feindliche präsenz in der ferne", regexOptions),
        Fra = new Regex(@"^vous avez le sentiment qu'une présence hostile a changé de nature", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7264?pretty=true">Shape-altering magicks flow from your body."</see>
    public static readonly LocalizedRegex PomanderOfWitching = new()
    {
        Jpn = new Regex(@"自身の周囲に、変化の魔法を展開した", regexOptions),
        Eng = new Regex(@"shape-altering magicks flow from your body", regexOptions),
        Deu = new Regex(@"ein veränderungszauber wird um dich herum wirksam", regexOptions),
        Fra = new Regex(@"un puissant sort de mutation prend effet autour de vous", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7265?pretty=true">The enchantments fade from this floor"</see>
    public static readonly LocalizedRegex PomanderOfSerenity = new()
    {
        Jpn = new Regex(@"この階層の不浄な魔力が霧散した", regexOptions),
        Eng = new Regex(@"^the enchantments fade from this floor", regexOptions),
        Deu = new Regex(@"^die unheilvolle Aura, die diese Ebene beherrschte, ist verflogen", regexOptions),
        Fra = new Regex(@"^l'aura magique néfaste qui imprégnait l'étage s'est dissipée", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7265?pretty=true">Floor Number"</see>
    public static readonly LocalizedRegex FloorNumber = new()
    {
        Jpn = new Regex(@"^地下(\d|\d\d|\d\d\d)階", regexOptions),
        Eng = new Regex(@"^floor (\d|\d\d|\d\d\d)", regexOptions),
        Deu = new Regex(@"^ebene (\d|\d\d|\d\d\d) betreten", regexOptions),
        Fra = new Regex(@"^sous-sol (\d|\d\d|\d\d\d)", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7272?pretty=true">You sense the Accursed Hoard calling you"</see>
    public static readonly LocalizedRegex SenseAccursedHoard = new()
    {
        Jpn = new Regex(@"^この階層には、財宝がありそうな気がする", regexOptions),
        Eng = new Regex(@"^you sense the accursed hoard calling you", regexOptions),
        Deu = new Regex(@"^auf dieser ebene befindet sich ein schatz", regexOptions),
        Fra = new Regex(@"^vous avez l'intuition qu'il y a un trésor caché à cet étage", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7273?pretty=true">
    ///     You do not sense the call of the Accursed Hoard on this
    ///     floor"
    /// </see>
    public static readonly LocalizedRegex DoNotSenseAccursedHoard = new()
    {
        Jpn = new Regex(@"^この階層には、財宝がなさそうな気がする", regexOptions),
        Eng = new Regex(@"^you do not sense the call of the accursed hoard on this floor", regexOptions),
        Deu = new Regex(@"^auf dieser ebene befindet sich kein schatz", regexOptions),
        Fra = new Regex(@"^vous avez l'intuition qu'il n'y a pas de trésor caché à cet étage", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/7274?pretty=true">You discover a piece of the Accursed Hoard"</see>
    public static readonly LocalizedRegex DiscoverAccursedHoard = new()
    {
        Jpn = new Regex(@"埋もれた財宝を発見した", regexOptions),
        Eng = new Regex(@"^you discover a piece of the accursed hoard", regexOptions),
        Deu = new Regex(@"^hier befindet sich ein verborgener schatz", regexOptions),
        Fra = new Regex(@"^vous avez découvert un trésor caché", regexOptions)
    };

    #endregion PotD & HoH

    #region Airship and Submarine

    /// <see href="https://xivapi.com/LogMessage/4163?pretty=true">A new exploratory voyage destination...has been discovered</see>
    public static readonly LocalizedRegex ExploratoryVoyage = new()
    {
        Jpn = new Regex(@"目的地", regexOptions),
        Eng = new Regex(@"new exploratory voyage destination", regexOptions),
        Deu = new Regex(@"hier befindet sich ein verborgener schatz", regexOptions),
        Fra = new Regex(@"vous avez découvert un trésor caché", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/6061?pretty=true">A new subaquatic voyage destination...has been discovered</see>
    public static readonly LocalizedRegex SubaquaticVoyage = new()
    {
        Jpn = new Regex(@"目的地", regexOptions),
        Eng = new Regex(@"new subaquatic voyage destination", regexOptions),
        Deu = new Regex(@"neues erkundungsgebiet entdeckt", regexOptions),
        Fra = new Regex(@"une nouvelle destination", regexOptions)
    };

    #endregion Airship and Submarine

    #region Trial Synthesis

    /// <see href="https://xivapi.com/LogMessage/5902?pretty=true">Your trial synthesis of a ... proved a success!</see>
    /// <seealso href="https://xivapi.com/LogMessage/5904?pretty=true">Your trial synthesis of a ... failed!</see>
    public static readonly LocalizedRegex TrialSynthesis = new()
    {
        Jpn = new Regex(@"の製作練習に", regexOptions),
        Eng = new Regex(@"^your trial synthesis of", regexOptions),
        Deu = new Regex(@"^die testsynthese von", regexOptions),
        Fra = new Regex(@"^a réussi sa synthèse", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/5906?pretty=true">Quality 6800/6800</see>
    public static readonly LocalizedRegex TrialQuality = new()
    {
        Jpn = new Regex(@" 上昇した品質 \d{1,6}\/\d{1,6}", regexOptions),
        Eng = new Regex(@" quality \d{1,6}\/\d{1,6}", regexOptions),
        Deu = new Regex(@" qualität  \d{1,6}\/\d{1,6}", regexOptions),
        Fra = new Regex(@" qualité  \d{1,6}\/\d{1,6}", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/5907?pretty=true">HQ 100%</see>
    public static readonly LocalizedRegex TrialHQ = new()
    {
        Jpn = new Regex(@" hq率 \d{1,3}\%", regexOptions),
        Eng = new Regex(@" hq \d{1,3}\%", regexOptions),
        Deu = new Regex(@" hq \d{1,3}\%", regexOptions),
        Fra = new Regex(@" hq \d{1,3}\%", regexOptions)
    };

    /// <see href="https://xivapi.com/LogMessage/5908?pretty=true">Collectability 6800/6800</see>
    public static readonly LocalizedRegex TrialCollectability = new()
    {
        Jpn = new Regex(@" 収集価値\s{1,3}\d{1,5} \/ \d{1,5}", regexOptions),
        Eng = new Regex(@" collectability \d{1,5}\/\d{1,5}", regexOptions),
        Deu = new Regex(@" sammlerwert \d{1,5}\/\d{1,5}", regexOptions),
        Fra = new Regex(@" valeur de collection \d{1,5}\/\d{1,5}", regexOptions)
    };

    #endregion Trial Synthesis
}