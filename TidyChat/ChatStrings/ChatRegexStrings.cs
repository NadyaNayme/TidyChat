using System;
using System.Text.RegularExpressions;
using TidyChat.Translation.Data;

namespace TidyChat;

public static class ChatRegexStrings
{
    private static readonly RegexOptions regexOptions =
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

    private static readonly TimeSpan regexTimeout = TimeSpan.FromSeconds(1);

    public static readonly LocalizedRegex BetterPlayerCommendation = new()
    {
        Jpn = new(@"you received \d{1} (commendation|commendations)", regexOptions, regexTimeout),
        Eng = new(@"you received \d{1} (commendation|commendations)", regexOptions, regexTimeout),
        Deu = new(@"you received \d{1} (commendation|commendations)", regexOptions, regexTimeout),
        Fra = new(@"you received \d{1} (commendation|commendations)", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/657?pretty=true">You obtain...</see>
    public static readonly LocalizedRegex ObtainedGil = new()
    {
        Jpn = new Regex(@"ギルを手に入れた。$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} gil\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"^(du|you) hast (\d{1,3},)?\d{1,3} gil erhalten\.$", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) obtenez \d{1,6} gils\.$", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex ObtainedMGP = new()
    {
        Jpn = new Regex(@"(\d{1,3},)?\d{1,3} MGP", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} MGP\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"(\d{1,3},)?\d{1,3} MGP erhalten\.$", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) (a|avez) reçu \d{1,6} PGS\.$", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/Item/25?pretty=true">Wolf Marks</see>
    public static readonly LocalizedRegex ObtainedWolfMarks = new()
    {
        Jpn = new Regex(@"(\d{1,3},)?\d{1,3} 対人戦績", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} wolf marks\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"(\d{1,3},)?\d{1,3} wolfsmarken erhalten\.$", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) (a|avez) reçu \d{1,6} marque de loup\.$", regexOptions, regexTimeout),
    };


    /// <see href="https://xivapi.com/Item/21072?pretty=true">Venture</see>
    public static readonly LocalizedRegex ObtainedVenture = new()
    {
        Jpn = new Regex(@"you (obtain|obtains) (a venture|\d{1,2} ventures)\.", regexOptions, regexTimeout),
        Eng = new Regex(@"you (obtain|obtains) (a venture|\d{1,2} ventures)\.", regexOptions, regexTimeout),
        Deu = new Regex(@"you (obtain|obtains) (a venture|\d{1,2} ventures)\.", regexOptions, regexTimeout),
        Fra = new Regex(@"you (obtain|obtains) (a venture|\d{1,2} ventures)\.", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/Item/27?pretty=true">Allied Seals</see>
    public static readonly LocalizedRegex ObtainedAlliedSeals = new()
    {
        Jpn = new Regex(@"^同盟記章を(\d{1,3},)?\d{1,3}個手に入れた。$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} Allied Seals\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"(\d{1,3},)?\d{1,3} jagdabzeichen erhalten\.", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) obtenez \d{1,6} insignes alliés\.$", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/Item/10307?pretty=true">Centurio Seals</see>
    public static readonly LocalizedRegex ObtainedCenturioSeals = new()
    {
        Jpn = new Regex(@"^セントリオ記章を(\d{1,3},)?\d{1,3}個手に入れた。$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} Centurio Seals\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"(\d{1,3},)?\d{1,3} centurio-abzeichen erhalten\.$", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) obtenez \d{1,6} insignes centurio\.$", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex ObtainedNuts = new()
    {
        Jpn = new Regex(@"^モブハントの戦利品を(\d{1,3},)?\d{1,3}個手に入れた。$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} sacks of Nuts\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"(\d{1,3},)?\d{1,3} kupo-trophaë\.", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) obtenez \d{1,6} insignes de chasse\.$", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/Item/20?pretty=true">Storm Seals</see>
    /// <seealso href="https://xivapi.com/Item/21?pretty=true">
    ///     Serpent Seals</see>
    ///     <seealso href="https://xivapi.com/Item/22?pretty=true">Flame Seals</see>
    public static readonly LocalizedRegex ObtainedSeals = new()
    {
        Jpn = new Regex(@"の軍票(\d{1,3},)?\d{1,3}枚を手に入れた。$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3}(\(\+\d{1,2}\%\))? (Flame|Storm|Serpent) Seals\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"(flottentaler|ordenstaler|legionstaler) erhalten", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) obtenez \d{1,6} sceaux (de|des) (Immortels|Deux Vipères|Maelstrom)\.$",
            regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/Item/2?pretty=true">Fire Shard</see>
    /// ...
    /// <seealso href="https://xivapi.com/Item/19?pretty=true">Water Cluster</see>
    public static readonly LocalizedRegex ObtainedClusters = new()
    {
        Jpn = new Regex(@"クラスター(×2)?を(手に入れた|入手した)", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (obtain|obtains) (a|2) (.*)(cluster|clusters)\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex ObtainedMaterials = new()
    {
        Jpn = new Regex(@"^you (obtain|obtains) (.*) materials\.$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (obtain|obtains) (.*) materials\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"^you (obtain|obtains) (.*) materials\.$", regexOptions, regexTimeout),
        Fra = new Regex(@"^you (obtain|obtains) (.*) materials\.$", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex ObtainedShards = new()
    {
        Jpn = new Regex(@"^you (obtain|obtains) (a|an|\d{1,3}) .{1,3}(fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (obtain|obtains) (a|an|\d{1,3}) .{1,3}(fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"^you (obtain|obtains) (a|an|\d{1,3}) .{1,3}(fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.$", regexOptions, regexTimeout),
        Fra = new Regex(@"^you (obtain|obtains) (a|an|\d{1,3}) .{1,3}(fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.$", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex ObtainedTribalCurrency = new()
    {
        Jpn = new Regex(@"NeedsTranslation", regexOptions, regexTimeout),
        Eng = new Regex(
            @"^you (obtain|obtains) (a|an|2) (Steel (Amalj'ok|Amalj'oks)|Sylphic (Goldleaf|Goldleaves)|Titan (Cobaltpiece|Cobaltpieces)|(Rainbowtide Psashp|Psashps)|Ixali (oaknot|oaknots)|Vanu (Whitebone|Whitebones)|Black Copper (Gil|Gils)|Carved Kupo (Nut|Nuts)|Kojin (Sango|Sangos)|Ananta Dreamstaves|Ananta Dreamstaffs|Namazu (Koban|Kobans)|Fae (Fancy|Fancies)|Qitari (Compliment|Compliments)|Hammered (Frogment|Fragments)|Arkasodara (Pana|Panas))\.$",
            regexOptions, regexTimeout),
        Deu = new Regex(
            @"^(du|you) hast (einen|2) (Stahl-Amalj'ok|Sylphen-goldblatt|Titan-koboldeistenstück|Regenbogenwellen-Psashp|Ixal-eichenmünze|Vanu-Weißknochen|Schwarzkupfer-Gil|Kupo-Schnitznuss|Kohin-Koralle|Ananta-Traumstab|Namazuo-Koban|Pixie-Glitter|Qitari-Kastanienkreuzer|Zwergenmünze) erhalten\.$",
            regexOptions, regexTimeout),
        Fra = new Regex(@"NeedsTranslation", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex PlayerTargetedEmote = new()
    {
        Jpn = new Regex(@"you|your", regexOptions, regexTimeout),
        Eng = new Regex(@"you|your|question springs|springs a question", regexOptions, regexTimeout),
        Deu = new Regex(@"you|your|du|deiner|dir|dich", regexOptions, regexTimeout),
        Fra = new Regex(@"you|your|vous", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex StartsWithYou = new()
    {
        Jpn = new Regex(@"^(you|your)", regexOptions, regexTimeout),
        Eng = new Regex(@"^(you|your)", regexOptions, regexTimeout),
        Deu = new Regex(@"^(you|your|du|deiner|dir|dich)", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you)", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex NotStartWithYou = new()
    {
        Jpn = new(@"^(?!you)", regexOptions, regexTimeout),
        Eng = new(@"^(?!you)", regexOptions, regexTimeout),
        Deu = new(@"^(?!you)", regexOptions, regexTimeout),
        Fra = new(@"^(?!you)", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/2600?pretty=true">You sense something foul may be lurking in the distance.</see>
    /// <seealso href="https://xivapi.com/LogMessage/4791?pretty=true">You sense something close.</see>
    public static readonly LocalizedRegex SpideySenses = new()
    {
        Jpn = new Regex("NeedsLocalization", regexOptions, regexTimeout),
        Eng = new Regex("you sense", regexOptions, regexTimeout), // You sense something... , You sense your mark..., You sense a strange...
        Deu = new Regex("NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex("(vous|you) (percevez|ressentez)", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex CastLot = new()
    {
        Jpn = new Regex(@"^youは.*にロットした。$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (cast|casts) (your|his|her) lot for (.*)\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex RollsNeedOrGreed = new()
    {
        Jpn = new Regex(@"^youは.+に(NEED|GREED)のダイスで\d{1,2}を出した。$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (roll|rolls) (Need|Greed) on (.*)\. \d{1,2}\!$", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex OthersCastLot = new()
    {
        // relies on the fact that all player names have a space between them (or a period if initialised)
        Jpn = new Regex(@"^\w+[ .].+は.+にロットした。$", regexOptions, regexTimeout),
        Eng = new Regex(@"(.*) casts (his|her) lot for (.*)\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"(.*) lance ses dés pour (la|le|les) (.*)\.$", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex OthersRollNeedOrGreed = new()
    {
        Jpn = new Regex(@"^\w+[ .].+は.+に(NEED|GREED)のダイスで\d{1,2}を出した。$", regexOptions, regexTimeout),
        Eng = new Regex(@"(.*) rolls (Need|Greed) on (.*)\. \d{1,2}\!$", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"(.*) jette les dés (Cupidité) pour (la|le|les) (.*)", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex YouDesynth = new()
    {
        Jpn = new Regex(@"を分解した！。$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you desynthesize.+", regexOptions, regexTimeout),
        Deu = new Regex(@"^(du|deiner|dir|dich|you) verwertet", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) obtient", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex YouObtainItem = new()
    {
        Jpn = new Regex(@"^youは.+を手に入れた。$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (obtain|obtains) (a|an).+", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) (recyclez|recycle)", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex YouObtainSystem = new()
    {
        Jpn = new Regex(@"^youは.+を手に入れた。$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you obtain.+", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) (recyclez|recycle)", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex OtherObtains = new()
    {
        Jpn = new Regex(@"^\w+[ .].+は.+を手に入れた。$", regexOptions, regexTimeout),
        Eng = new Regex(@"(.*) obtains .+", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"(.*) obtient (un|une|\d{1,3}) .+", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex ItemSearchCommand = new()
    {
        Jpn = new Regex(@"^\s{1,3}>>|を含む所持アイテムは(\d{1,4}種類見つかりました|ありませんでした)。$", regexOptions, regexTimeout),
        Eng = new Regex(@"(\s{1,3}>>|(No|\d{1,4}) (match|matches) found containing)", regexOptions, regexTimeout),
        Deu = new Regex(@"\s{1,3}>>", regexOptions, regexTimeout),
        Fra = new Regex(@"\s{1,3}>>|(Il n\'y a aucun objet contenant|Il y a \d{1,4} type)", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex SearchForItemResults = new()
    {
        // TODO: items found in the armory chest, items in second tab of saddlebag
        Jpn = new Regex(
            @"^ミラージュドレッサーに\d個あります。$|^愛蔵品キャビネット「.+」に\d個あります。$|に装備中です。$|合計\d{1,9}個見つかりました。|^所持品ブロック[1234]に\d{1,9}個あります。$|^チョコボかばんのかばんタブ[12]に\d{1,9}個あります。$",
            regexOptions, regexTimeout),
        Eng = new Regex(
            @"(^\d (item|items) found in glamour dresser\.)|(^\d (item|items) found in the .* section of the armoire\.)|(^currently equipped to .* slot)|(^total: \d{1,9} (item|items) found)|(^\d{1,9} (item|items) found in the (1st|2nd|3rd|4th) tab of (your|.+'s) inventory)|^\d{1,9} (item|items) found in saddlebag",
            regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(
            @"((possède|possédez) \d{1,3} (cristal|cristaux)\.$|^recherche de l\'objet|^\d{1,4} (exemplaire|exemplaires) de l\'objet se (trouve|trouvent) dans|^total\ \: \d{1,6} (résultat|résultats)\.$|^l\'objet est équipé dans la case|^aucun résultat trouvé\.$)",
            regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex ObtainedTomestones = new()
    {
        Jpn = new Regex(@"^アラガントームストーン:([^を]+)を(\d{1,3}個手に入れた|入手した)。$", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (obtain|obtains) \d{1,3} Allagan tomestones of", regexOptions, regexTimeout),
        Deu = new Regex(
            @"(du|you) hast \d{1,3} (Allagischer|Allagisch|Allagische|Allagischa) (Stein|Steine) (der|des) \w+ erhalten\.$",
            regexOptions, regexTimeout),
        Fra = new Regex(@"(vous|you) obtenez \d{1,3} Mémoquartz allagois (\w+)", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/700?pretty=true">Gearset equipped.</see>
    // TODO: German/French need to be tested and may not use quotes for the gearsets.
    public static readonly LocalizedRegex GearsetEquipped = new()
    {
        Jpn = new Regex(@"」に装備変更しました。", regexOptions, regexTimeout),
        Eng = new Regex(@"^“(.*)” equipped", regexOptions, regexTimeout),
        Deu = new Regex(@"^(du|you) hast „(.*)“ angelegt\.", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) vous équipez (.*)\.", regexOptions, regexTimeout),
    };

    // Future proofing the materias a bit here
    public static readonly LocalizedRegex MateriaRetrieved =
        new()
        {
            Jpn = new Regex(@"^you (receive|receives) (a|an|2) .+ materia [I|V|X|L|C|D|M]{1,10}", regexOptions, regexTimeout),
            Eng = new Regex(@"^you (receive|receives) (a|an|2) .+ materia [I|V|X|L|C|D|M]{1,10}", regexOptions, regexTimeout),
            Deu = new Regex(@"^you (receive|receives) (a|an|2) .+ materia [I|V|X|L|C|D|M]{1,10}", regexOptions, regexTimeout),
            Fra = new Regex(@"^you (receive|receives) (a|an|2) .+ materia [I|V|X|L|C|D|M]{1,10}", regexOptions, regexTimeout),
        };

    public static readonly LocalizedRegex MateriaShatters =
        new()
        {
            Jpn = new Regex(@"^the .+ materia [I|V|X|L|C|D|M]{1,10} shatters", regexOptions, regexTimeout),
            Eng = new Regex(@"^the .+ materia [I|V|X|L|C|D|M]{1,10} shatters", regexOptions, regexTimeout),
            Deu = new Regex(@"^the .+ materia [I|V|X|L|C|D|M]{1,10} shatters", regexOptions, regexTimeout),
            Fra = new Regex(@"^the .+ materia [I|V|X|L|C|D|M]{1,10} shatters", regexOptions, regexTimeout),
        };

    public static readonly LocalizedRegex AttachedMateria =
        new()
        {
            Jpn = new Regex(@"^you successfully (attach|attaches) (a|an) .+ materia [I|V|X|L|C|D|M]{1,10} to the", regexOptions, regexTimeout),
            Eng = new Regex(@"^you successfully (attach|attaches) (a|an) .+ materia [I|V|X|L|C|D|M]{1,10} to the", regexOptions, regexTimeout),
            Deu = new Regex(@"^you successfully (attach|attaches) (a|an) .+ materia [I|V|X|L|C|D|M]{1,10} to the", regexOptions, regexTimeout),
            Fra = new Regex(@"^you successfully (attach|attaches) (a|an) .+ materia [I|V|X|L|C|D|M]{1,10} to the", regexOptions, regexTimeout),
        };

    /// <see href="https://xivapi.com/LogMessage/3860?pretty=true">Master volume muted/unmuted</see>
    /// ...
    /// <seealso href="https://xivapi.com/LogMessage/3866?pretty=true">Performance volume muted/unmuted</see>
    public static readonly LocalizedRegex VolumeControls = new()
    {
        Jpn = new Regex(@"をミュートしました。$|のミュートを解除しました。$|の音量を\d{1,3}に変更しました。$", regexOptions, regexTimeout),
        Eng = new Regex(@"volume (muted|unmuted|set to \d{1,3}\.$)", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(
            @"^(vous|you) avez (activé|déactivé) (la|le|les|l'ambiance) (musqiue|volume général|effets sonores|voix|sons système|sonore|haut-parleur pour les sons système)\.$",
            regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/1063?pretty=true">You begin mining.</see>
    /// ...
    /// <seealso href="https://xivapi.com/LogMessage/1070?pretty=true">You finish harvesting.</see>
    public static readonly LocalizedRegex GatheringStartEnd = new()
    {
        Jpn = new Regex(@"は(採掘|砕岩|伐採|草刈)を(開始した|終えた)", regexOptions, regexTimeout),
        Eng = new Regex(@"^you (begin|finish) (mining|quarrying|logging|harvesting)\.$", regexOptions, regexTimeout),
        Deu = new Regex(
            @"^(du|deiner|dir|dich|you) (beginnst|beginnt|bist fertig mit dem|ist fertig mit dem) (abzubauen|herauszubrechen|abzuholzen|abzuernten|Abbauen|Herausbrechen|Abholzen|Abernten)",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"^(vous|you) (commencez|arrêtez) (á extraire|d'extraire) (du minerai|des pierres|couper du bois|faucher de la végétation)\.",
            regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex Mooching = new()
    {
        Jpn = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Eng = new Regex(@"^you recast your line with the fish still hooked", regexOptions, regexTimeout),
        Deu = new Regex(
            @"NeedsLocalization",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"NeedsLocalization",
            regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/1110?pretty=true">You cast your line on the ...</see>
    public static readonly LocalizedRegex CurrentFishingHole = new()
    {
        Jpn = new Regex(@"で釣りを開始した$", regexOptions, regexTimeout),
        Eng = new Regex(@"^(you cast your|.*? casts (her|his)) line (on|in|at)", regexOptions, regexTimeout),
        Deu = new Regex(
            @"mit dem fischen",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"point de pêche\:",
            regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/3513?pretty=true">
    ///     The fishing hole ... in/on/at ... is added to your fishing
    ///     log.
    /// </see>
    public static readonly LocalizedRegex DiscoveredFishingHoleARR = new()
    {
        Jpn = new Regex(@"^釣り手帳に穴場「.*?」の情報を記録した！$", regexOptions, regexTimeout),
        Eng = new Regex(@"^the fishing hole (in|on|at) .*? is added to your fishing log\.$", regexOptions, regexTimeout),
        Deu = new Regex(
            @"^im fischer-notizbuch wurde der fischgrund „.*?“ verzeichnet\.$",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"^vous notez le banc de poissons “.*?” dans votre carnet\.$",
            regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/3579?pretty=true">Data on ... is added to your fishing log.</see>
    public static readonly LocalizedRegex DataOnFishinghole = new()
    {
        Jpn = new Regex(@"^釣り手帳に新しい漁場「.*?」の情報を記録した！$", regexOptions, regexTimeout),
        Eng = new Regex(@"^data on .*? is added to your fishing log\.$", regexOptions, regexTimeout),
        Deu = new Regex(
            @"^der neue speerfishgrund „.*?“ wurde in deinem fischer-notizbuch vermerkt",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"^vous notez l\'emplacement du point de harponnage “.*?” dans votre carnet\.$",
            regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/1130?pretty=true">You have discovered the fishing location, ...</see>
    public static readonly LocalizedRegex DiscoveredFishingHole = new()
    {
        Jpn = new Regex(@"^新しい釣り場", regexOptions, regexTimeout),
        Eng = new Regex(@"^you have discovered the fishing location", regexOptions, regexTimeout),
        Deu = new Regex(
            @"^du hast eine neue angelstelle entdeckt",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"^vous avez découvert le point de pêche",
            regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex AetherialReductionSands = new()
    {
        Jpn = new Regex(@".+handfuls of .+ .+sand are obtained\.", regexOptions, regexTimeout),
        Eng = new Regex(@".+handfuls of .+ .+sand are obtained\.", regexOptions, regexTimeout),
        Deu = new Regex(@".+handfuls of .+ .+sand are obtained\.", regexOptions, regexTimeout),
        Fra = new Regex(@".+handfuls of .+ .+sand are obtained\.", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/2012?pretty=true">Area will be sealed off in 15 seconds</see>
    /// <seealso href="https://xivapi.com/LogMessage/2013?pretty=true">
    ///     Area is sealed off!</see>
    ///     <seealso href="https://xivapi.com/LogMessage/2014?pretty=true">Area is no longer sealed!</see>
    public static readonly LocalizedRegex SealedOff = new()
    {
        Jpn = new Regex(@"(の封鎖まであと|が封鎖された！|の封鎖が解かれた)", regexOptions, regexTimeout),
        Eng = new Regex(@"(will be sealed off in 15 seconds|is sealed off|is no longer sealed)", regexOptions, regexTimeout),
        Deu = new Regex(@"((sekunde|sekunden)\, bis sich .+ schließt\.|hat sich geschlossen\.|öffnet sich wieder\.)",
            regexOptions, regexTimeout),
        Fra = new Regex(@"(dans \d{1,2} secondes\.|Fermeture|Ouverture)", regexOptions, regexTimeout),
    };

    // Name S. gains \d{1,4} (+\d{1,2}%) experience points.
    public static readonly LocalizedRegex GainExperiencePoints = new()
    {
        Jpn = new Regex(@"ポイントの経験値を得た。$", regexOptions, regexTimeout),
        Eng = new Regex(@".* (gain|gains) .* experience points\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@".* gagnez .* points d'expérience\.$", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/744?pretty=true">Your spiritbond with item is complete!</see>
    public static readonly LocalizedRegex CompleteSpiritbond = new()
    {
        Jpn = new Regex(@"の錬精度が100%になった！$", regexOptions, regexTimeout),
        Eng = new Regex(@"^your spiritbond with .+ is complete\!$", regexOptions, regexTimeout),
        Deu = new Regex(@"^deine emotionale bindung an .+ hat 100 \% erreicht\!$", regexOptions, regexTimeout),
        Fra = new Regex(@"^vous êates en symbiose avec", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/3085?pretty=true">Player has logged out</see>
    public static readonly LocalizedRegex HasLoggedIn = new()
    {
        Jpn = new Regex(@"ポイント上昇した！$", regexOptions, regexTimeout),
        Eng = new Regex(@"(has|have) logged in\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"hat sich eingeloggt\.$", regexOptions, regexTimeout),
        Fra = new Regex(@"s'est (connecté|connectée)\.$", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/3086?pretty=true">Player has logged out</see>
    public static readonly LocalizedRegex HasLoggedOut = new()
    {
        Jpn = new Regex(@"がログアウトしました。$", regexOptions, regexTimeout),
        Eng = new Regex(@"has logged out\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"hat sich ausgeloggt\.$", regexOptions, regexTimeout),
        Fra = new Regex(@"s'est (déconnecté|déconnectée)\.$", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/6065?pretty=true">A new entry has been added to the free company message book.</see>
    public static readonly LocalizedRegex FreeCompanyMessageBook = new()
    {
        Jpn = new Regex(@"フリーカンパニーハウスの交流帳に新着メッセージがあります", regexOptions, regexTimeout),
        Eng = new Regex(@"new entry has been added to the free company message book", regexOptions, regexTimeout),
        Deu = new Regex(@"jemand hat einen neuen eintrag im diarium der freien gesellschaft hinterlassen",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"un ou plusieurs nouveaux messages ont été laissés dans le livre de correspondance de votre maison de compagnie libre",
            regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/6066?pretty=true">A new entry has been added to your estate message book.</see>
    public static readonly LocalizedRegex PersonalEstateMessageBook = new()
    {
        Jpn = new Regex(@"(個人ハウス|個室|アパルトメント)の交流帳に新着メッセージがあります", regexOptions, regexTimeout),
        Eng = new Regex(@"new entry has been added to your (estate|room|apartment) message book", regexOptions, regexTimeout),
        Deu = new Regex(
            @"jemand hat einen neuen eintrag im diarium deiner (wohnung hinterlassen|zimmers hinterlassen|unterkunft hinterlassen)",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"un ou plusieurs nouveaux messages ont été laissés dans le livre de correspondance de votre (appartemen|chambre individuelle|maison individuelle)",
            regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/23?pretty=true">You are now a leader of Linkshell.</see>
    /// <seealso>XivAPI for various other Leader Of messages: 15, 16, 23, 24, 367, 383, 9284, 9285, 9298, 9289, 9290, 9291</seealso>
    public static readonly LocalizedRegex NowLeaderOf = new()
    {
        Jpn = new Regex(@"(のリーダーに設定されました|リーダー設定を解除しました)", regexOptions, regexTimeout),
        Eng = new Regex(
            @"((are|is) (now|no longer) a leader|(is now the|has promoted you to) party leader|have been granted to)",
            regexOptions, regexTimeout),
        Deu = new Regex(
            @"(du|you) bist (nun|nicht) ein anführer",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"êtes maintenant (membre|officier) de",
            regexOptions, regexTimeout),
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
        Jpn = new Regex(@"リワード取得の権利を有するパーティメンバー数が", regexOptions, regexTimeout),
        Eng = new Regex(@"number of coffers", regexOptions, regexTimeout),
        Deu = new Regex(
            @"wöchentliche vergütung erhalten",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"le nombre de coffres sera de",
            regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/4225?pretty=true">
    ///     One or more party members have yet to complete this duty. A
    ///     bonus of ... will be awarded upon completion.
    /// </see>
    public static readonly LocalizedRegex PartyMemberFirstClear = new()
    {
        Jpn = new Regex(@"未制覇の参加メンバーがいるため、攻略成功時に", regexOptions, regexTimeout),
        Eng = new Regex(@"one or more party members have yet to complete this duty", regexOptions, regexTimeout),
        Deu = new Regex(
            @"weil ein charakter diesen inhalt noch nicht beendet hat",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"un ou plusieurs participants n\'ont pas encore accompli cette mission",
            regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/4225?pretty=true">
    ///     One or more party members have yet to complete this duty. A
    ///     bonus of ... will be awarded upon completion.
    /// </see>
    public static readonly LocalizedRegex FirstClearAward = new()
    {
        Jpn = new Regex(@"未制覇の参加メンバーがいるため、攻略成功時に", regexOptions, regexTimeout),
        Eng = new Regex(@"a bonus of", regexOptions, regexTimeout),
        Deu = new Regex(
            @"erhalten alle teilnehmer bei abschluss",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"l\'équipe recevra",
            regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7975?pretty=true">
    ///     One or more party members have yet to complete this duty.
    ///     Second Chance points added to your journal.
    /// </see>
    public static readonly LocalizedRegex SecondChanceAward = new()
    {
        Jpn = new Regex(@"チャンスポイントが加算されました", regexOptions, regexTimeout),
        Eng = new Regex(@"second chance points added to your journal", regexOptions, regexTimeout),
        Deu = new Regex(
            @"zusätzliche chance-punkte",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"le nombre de points de chance dans le carnet",
            regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/732?pretty=true">You have entered a sanctuary.</see>
    public static readonly LocalizedRegex EnteredSanctuary = new()
    {
        Jpn = new Regex(@"レストエリアに入った", regexOptions, regexTimeout),
        Eng = new Regex(@"^you have entered a sanctuary", regexOptions, regexTimeout),
        Deu = new Regex(@"^(du|you) hast einen ruhebereich betreten", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) êtes (entré|entrée) dans un lieu de repos", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/733?pretty=true">You have left the sanctuary.</see>
    public static readonly LocalizedRegex LeftSanctuary = new()
    {
        Jpn = new Regex(@"レストエリアから離れた", regexOptions, regexTimeout),
        Eng = new Regex(@"^you have left the sanctuary", regexOptions, regexTimeout),
        Deu = new Regex(@"^(du|you) hast den ruhebereich verlassen", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) aves quitté le lieu de repos", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/1351?pretty=true">You are currently not in an instanced area.</see>
    public static readonly LocalizedRegex NotInstancedArea = new()
    {
        Jpn = new Regex(@"インスタンスエリアは存在しません", regexOptions, regexTimeout),
        Eng = new Regex(@"^you are currently not in an instanced area", regexOptions, regexTimeout),
        Deu = new Regex(@"momentan ist das areal nicht instanziiert", regexOptions, regexTimeout),
        Fra = new Regex(@"il n'y a actuellement aucune zone instanciée", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex QuestionMarkCommandResponse = new()
    {
        Jpn = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Eng = new Regex(@"^(usage:|aliases:)", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/1272?pretty=true">You have arrived at a vista!</see>
    /// <seealso href="https://xivapi.com/LogMessage/1273?pretty=true">You have strayed too far from the vista.</see>
    public static readonly LocalizedRegex VistaMessages = new()
    {
        Jpn = new Regex(@"(探検手帳の目的地に到達した|探検手帳の目的地から離れた)", regexOptions, regexTimeout),
        Eng = new Regex(@"^you have (arrived at a vista!|strayed too far from the vista\.)", regexOptions, regexTimeout),
        Deu = new Regex(
            @"^(du|you) (bist an einem sehenswerten ort angekommen|hast dich von dem sehenswerten ort entfernt\.)",
            regexOptions, regexTimeout),
        Fra = new Regex(@"(à un lieu notoire!|du lieu notoire\.)", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/1156?pretty=true">Someone synthesizes an item!</see>
    public static readonly LocalizedRegex OtherSynthesis = new()
    {
        Jpn = new Regex(@"完成させた", regexOptions, regexTimeout),
        Eng = new Regex(@"synthesizes", regexOptions, regexTimeout),
        Deu = new Regex(@"hergestellt", regexOptions, regexTimeout),
        Fra = new Regex(@"fabrique", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/3911?pretty=true">You try on item.</see>
    public static readonly LocalizedRegex TryOnGlamour = new()
    {
        Jpn = new Regex(@"を試着した", regexOptions, regexTimeout),
        Eng = new Regex(@"^you try on", regexOptions, regexTimeout),
        Deu = new Regex(@"probeweise angelgt", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) essayez", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7005?pretty=true">
    ///     Unable to join Novice Network. The channel has reached the
    ///     maximum number of users.
    /// </see>
    public static readonly LocalizedRegex NoviceNetworkFull = new()
    {
        Jpn = new Regex(@"定員に達しているため", regexOptions, regexTimeout),
        Eng = new Regex(@"^unable to join novice network\. the channel has reached the maximum number of users\.$",
            regexOptions, regexTimeout),
        Deu = new Regex(@"^(du|you) konntest dem neulings-chat nicht beitreten, weil er bereits voll ist\.$",
            regexOptions, regexTimeout),
        Fra = new Regex(
            @"^\(rdn\) impossible de rejoindre le réseau des novices\. Le nombre maximal de participants a été atteint\.$",
            regexOptions, regexTimeout),
    };

    #region PotD & HoH

    /// <see href="https://xivapi.com/LogMessage/7221?pretty=true">The party obtains a pomander"</see>
    public static readonly LocalizedRegex ObtainedPomander = new()
    {
        Jpn = new Regex(@"たちは、", regexOptions, regexTimeout),
        Eng = new Regex(@"the party obtains a", regexOptions, regexTimeout),
        Deu = new Regex(@"ihr habt ein (.*) erhlaten\!", regexOptions, regexTimeout),
        Fra = new Regex(@"et (vos|ses) compagnons (avez|ont) obtenu", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7222?pretty=true">
    ///     You return the pomander to the coffer. YOu cannot carry any
    ///     more of that item."
    /// </see>
    public static readonly LocalizedRegex ReturnedPomander = new()
    {
        Jpn = new Regex(@"はこれ以上、持つことができないようだ。宝箱に戻した、", regexOptions, regexTimeout),
        Eng = new Regex(@"^you return the (.*) to the coffer", regexOptions, regexTimeout),
        Deu = new Regex(@"^(du|you) kannst kein weiteres (.*) aufnehmen und legst es in die", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) ne pouvez pas obtenir davantage", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7242?pretty=true">The cairn begins to glow!"</see>
    public static readonly LocalizedRegex CairnGlows = new()
    {
        Jpn = new Regex(@"が輝き始めた", regexOptions, regexTimeout),
        Eng = new Regex(@"begins to glow\!", regexOptions, regexTimeout),
        Deu = new Regex(@"beginnt zu leuchten", regexOptions, regexTimeout),
        Fra = new Regex(@"a recommencé à briller", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7243?pretty=true">The...restores live to those fallen in battle!"</see>
    public static readonly LocalizedRegex RestoresLifeToFallen = new()
    {
        Jpn = new Regex(@"倒れていた冒険者に生気が宿った", regexOptions, regexTimeout),
        Eng = new Regex(@"restores life to those fallen in battle", regexOptions, regexTimeout),
        Deu = new Regex(@"hat die gefallenen abenteurer wiederbelebt", regexOptions, regexTimeout),
        Fra = new Regex(@"remettant sur pied les aventuriers inconscients", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7245?pretty=true">... is activated!"</see>
    public static readonly LocalizedRegex CairnActivates = new()
    {
        Jpn = new Regex(@"が起動した", regexOptions, regexTimeout),
        Eng = new Regex(@"is activated", regexOptions, regexTimeout),
        Deu = new Regex(@"wurde aktiviert", regexOptions, regexTimeout),
        Fra = new Regex(@"s'est activé", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7246?pretty=true">Three seconds until transference"</see>
    /// <see href="https://xivapi.com/LogMessage/7247?pretty=true">Transference canceled"</see>
    /// <see href="https://xivapi.com/LogMessage/7248?pretty=true">Transferenced initiated"</see>
    public static readonly LocalizedRegex Transference = new()
    {
        Jpn = new Regex(@"転移", regexOptions, regexTimeout),
        Eng = new Regex(@"transference", regexOptions, regexTimeout),
        Deu = new Regex(@"transport", regexOptions, regexTimeout),
        Fra = new Regex(@"téléportation", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7245?pretty=true">
    ///     Aetherpool item flickers/brightens/flares. Its strength is
    ///     now +0-98"
    /// </see>
    public static readonly LocalizedRegex AetherpoolIncrease = new()
    {
        Jpn = new Regex(@"強化値が([0-9]|[1-8][0-9]|9[0-8])になった", regexOptions, regexTimeout),
        Eng = new Regex(@"its strength is now \+([0-9]|[1-8][0-9]|9[0-8])", regexOptions, regexTimeout),
        Deu = new Regex(@"steigt auf \+([0-9]|[1-8][0-9]|9[0-8])", regexOptions, regexTimeout),
        Fra = new Regex(@"passe à \+([0-9]|[1-8][0-9]|9[0-8])", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7251?pretty=true">Your...remains unchanged"</see>
    public static readonly LocalizedRegex AetherpoolUnchanged = new()
    {
        Jpn = new Regex(@"の強化に失敗した", regexOptions, regexTimeout),
        Eng = new Regex(@"remains unchanged\.\.\.", regexOptions, regexTimeout),
        Deu = new Regex(@"wurde nicht verstärkt \.\.\.", regexOptions, regexTimeout),
        Fra = new Regex(@"n'a pas pu être amélioré\.\.\.", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7255?pretty=true">All the traps on this floor have disappeared!"</see>
    public static readonly LocalizedRegex PomanderOfSafety = new()
    {
        Jpn = new Regex(@"この階層のトラップが、すべて消滅した", regexOptions, regexTimeout),
        Eng = new Regex(@"all the traps on this floor have disappeared", regexOptions, regexTimeout),
        Deu = new Regex(@"alle fallen dieser ebene wurden entfernt", regexOptions, regexTimeout),
        Fra = new Regex(@"tous les pièges de l'étage ont été désamorcés", regexOptions, regexTimeout),
    };


    /// <see href="https://xivapi.com/LogMessage/7256?pretty=true">The map for this floor has been revealed"</see>
    public static readonly LocalizedRegex PomanderOfSight = new()
    {
        Jpn = new Regex(@"この階層のマップが、すべて開示された", regexOptions, regexTimeout),
        Eng = new Regex(@"the map for this floor has been revealed", regexOptions, regexTimeout),
        Deu = new Regex(@"die gesamte karte dieser ebene wurde enthüllt", regexOptions, regexTimeout),
        Fra = new Regex(@"la carte de l'étage a été entièrement révélée", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7259?pretty=true">You sense a treasure coffer somewhere nearby"</see>
    public static readonly LocalizedRegex PomanderOfAffluence = new()
    {
        Jpn = new Regex(@"どこかに宝箱の気配を感じた", regexOptions, regexTimeout),
        Eng = new Regex(@"you sense a treasure coffer somewhere nearby", regexOptions, regexTimeout),
        Deu = new Regex(@"(du|you) hast das gefühl, dass irgendwo eine schatztruhe zu finden ist", regexOptions, regexTimeout),
        Fra = new Regex(@"(vous|you) avez le sentiment qu'il y a un coffre au trésor dans les environs", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7260?pretty=true">The howls of distant creatures begin to fade"</see>
    public static readonly LocalizedRegex PomanderOfFlight = new()
    {
        Jpn = new Regex(@"どこか遠くの魔物の気配が消えていった", regexOptions, regexTimeout),
        Eng = new Regex(@"the howls of distant creatures begin to fade", regexOptions, regexTimeout),
        Deu = new Regex(@"(du|you) spürst, dass eine feindliche präsenz in die ferne entschwunden ist", regexOptions, regexTimeout),
        Fra = new Regex(@"(vous|you) avez le sentiment qu'une présence hostile a disparu", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7261?pretty=true">The sense a distant presence has changed"</see>
    public static readonly LocalizedRegex PomanderOfAlteration = new()
    {
        Jpn = new Regex(@"どこか遠くの魔物の気配が変わったようだ", regexOptions, regexTimeout),
        Eng = new Regex(@"^you sense a distant presence has changed", regexOptions, regexTimeout),
        Deu = new Regex(@"^(du|you) spürst eine veränderte feindliche präsenz in der ferne", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) avez le sentiment qu'une présence hostile a changé de nature", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7264?pretty=true">Shape-altering magicks flow from your body."</see>
    public static readonly LocalizedRegex PomanderOfWitching = new()
    {
        Jpn = new Regex(@"自身の周囲に、変化の魔法を展開した", regexOptions, regexTimeout),
        Eng = new Regex(@"shape-altering magicks flow from your body", regexOptions, regexTimeout),
        Deu = new Regex(@"ein veränderungszauber wird um dich herum wirksam", regexOptions, regexTimeout),
        Fra = new Regex(@"un puissant sort de mutation prend effet autour de vous", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7265?pretty=true">The enchantments fade from this floor"</see>
    public static readonly LocalizedRegex PomanderOfSerenity = new()
    {
        Jpn = new Regex(@"この階層の不浄な魔力が霧散した", regexOptions, regexTimeout),
        Eng = new Regex(@"^the enchantments fade from this floor", regexOptions, regexTimeout),
        Deu = new Regex(@"^die unheilvolle Aura, die diese Ebene beherrschte, ist verflogen", regexOptions, regexTimeout),
        Fra = new Regex(@"^l'aura magique néfaste qui imprégnait l'étage s'est dissipée", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7265?pretty=true">Floor Number"</see>
    public static readonly LocalizedRegex FloorNumber = new()
    {
        Jpn = new Regex(@"^地下(\d|\d\d|\d\d\d)階", regexOptions, regexTimeout),
        Eng = new Regex(@"^floor (\d|\d\d|\d\d\d)", regexOptions, regexTimeout),
        Deu = new Regex(@"^ebene (\d|\d\d|\d\d\d) betreten", regexOptions, regexTimeout),
        Fra = new Regex(@"^sous-sol (\d|\d\d|\d\d\d)", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7272?pretty=true">You sense the Accursed Hoard calling you"</see>
    public static readonly LocalizedRegex SenseAccursedHoard = new()
    {
        Jpn = new Regex(@"^この階層には、財宝がありそうな気がする", regexOptions, regexTimeout),
        Eng = new Regex(@"^you sense the accursed hoard calling you", regexOptions, regexTimeout),
        Deu = new Regex(@"^auf dieser ebene befindet sich ein schatz", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) avez l'intuition qu'il y a un trésor caché à cet étage", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7273?pretty=true">
    ///     You do not sense the call of the Accursed Hoard on this
    ///     floor"
    /// </see>
    public static readonly LocalizedRegex DoNotSenseAccursedHoard = new()
    {
        Jpn = new Regex(@"^この階層には、財宝がなさそうな気がする", regexOptions, regexTimeout),
        Eng = new Regex(@"^you do not sense the call of the accursed hoard on this floor", regexOptions, regexTimeout),
        Deu = new Regex(@"^auf dieser ebene befindet sich kein schatz", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) avez l'intuition qu'il n'y a pas de trésor caché à cet étage", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/7274?pretty=true">You discover a piece of the Accursed Hoard"</see>
    public static readonly LocalizedRegex DiscoverAccursedHoard = new()
    {
        Jpn = new Regex(@"埋もれた財宝を発見した", regexOptions, regexTimeout),
        Eng = new Regex(@"^you discover a piece of the accursed hoard", regexOptions, regexTimeout),
        Deu = new Regex(@"^hier befindet sich ein verborgener schatz", regexOptions, regexTimeout),
        Fra = new Regex(@"^(vous|you) avez découvert un trésor caché", regexOptions, regexTimeout),
    };

    #endregion PotD & HoH

    #region Airship and Submarine

    /// <see href="https://xivapi.com/LogMessage/4163?pretty=true">A new exploratory voyage destination...has been discovered</see>
    public static readonly LocalizedRegex ExploratoryVoyage = new()
    {
        Jpn = new Regex(@"目的地", regexOptions, regexTimeout),
        Eng = new Regex(@"new exploratory voyage destination", regexOptions, regexTimeout),
        Deu = new Regex(@"hier befindet sich ein verborgener schatz", regexOptions, regexTimeout),
        Fra = new Regex(@"(vous|you) avez découvert un trésor caché", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/6061?pretty=true">A new subaquatic voyage destination...has been discovered</see>
    public static readonly LocalizedRegex SubaquaticVoyage = new()
    {
        Jpn = new Regex(@"目的地", regexOptions, regexTimeout),
        Eng = new Regex(@"new subaquatic voyage destination", regexOptions, regexTimeout),
        Deu = new Regex(@"neues erkundungsgebiet entdeckt", regexOptions, regexTimeout),
        Fra = new Regex(@"une nouvelle destination", regexOptions, regexTimeout),
    };

    #endregion Airship and Submarine

    #region Trial Synthesis

    /// <see href="https://xivapi.com/LogMessage/5902?pretty=true">Your trial synthesis of a ... proved a success!</see>
    /// <seealso href="https://xivapi.com/LogMessage/5904?pretty=true">Your trial synthesis of a ... failed!</see>
    public static readonly LocalizedRegex TrialSynthesis = new()
    {
        Jpn = new Regex(@"の製作練習に", regexOptions, regexTimeout),
        Eng = new Regex(@"^your trial synthesis of", regexOptions, regexTimeout),
        Deu = new Regex(@"^die testsynthese von", regexOptions, regexTimeout),
        Fra = new Regex(@"^a réussi sa synthèse", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/5906?pretty=true">Quality 6800/6800</see>
    public static readonly LocalizedRegex TrialQuality = new()
    {
        Jpn = new Regex(@" 上昇した品質 \d{1,6}\/\d{1,6}", regexOptions, regexTimeout),
        Eng = new Regex(@" quality \d{1,6}\/\d{1,6}", regexOptions, regexTimeout),
        Deu = new Regex(@" qualität  \d{1,6}\/\d{1,6}", regexOptions, regexTimeout),
        Fra = new Regex(@" qualité  \d{1,6}\/\d{1,6}", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/5907?pretty=true">HQ 100%</see>
    public static readonly LocalizedRegex TrialHQ = new()
    {
        Jpn = new Regex(@" hq率 \d{1,3}\%", regexOptions, regexTimeout),
        Eng = new Regex(@" hq \d{1,3}\%", regexOptions, regexTimeout),
        Deu = new Regex(@" hq \d{1,3}\%", regexOptions, regexTimeout),
        Fra = new Regex(@" hq \d{1,3}\%", regexOptions, regexTimeout),
    };

    /// <see href="https://xivapi.com/LogMessage/5908?pretty=true">Collectability 6800/6800</see>
    public static readonly LocalizedRegex TrialCollectability = new()
    {
        Jpn = new Regex(@" 収集価値\s{1,3}\d{1,5} \/ \d{1,5}", regexOptions, regexTimeout),
        Eng = new Regex(@" collectability \d{1,5}\/\d{1,5}", regexOptions, regexTimeout),
        Deu = new Regex(@" sammlerwert \d{1,5}\/\d{1,5}", regexOptions, regexTimeout),
        Fra = new Regex(@" valeur de collection \d{1,5}\/\d{1,5}", regexOptions, regexTimeout),
    };

    #endregion Trial Synthesis
}
