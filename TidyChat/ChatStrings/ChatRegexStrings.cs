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
        Jpn = new Regex(@"you received \d{1} (commendation|commendations)", regexOptions, regexTimeout),
        Eng = new Regex(@"you received \d{1} (commendation|commendations)", regexOptions, regexTimeout),
        Deu = new Regex(@"you received \d{1} (commendation|commendations)", regexOptions, regexTimeout),
        Fra = new Regex(@"you received \d{1} (commendation|commendations)", regexOptions, regexTimeout),
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
public static readonly LocalizedRegex ContainsPlayerName = new()
    {
        Jpn = new Regex(@"(you|your)", regexOptions, regexTimeout),
        Eng = new Regex(@"(you|your)", regexOptions, regexTimeout),
        Deu = new Regex(@"(you|your|du|deiner|dir|dich)", regexOptions, regexTimeout),
        Fra = new Regex(@"(vous|you)", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex NotStartWithYou = new()
    {
        Jpn = new Regex(@"^(?!you)", regexOptions, regexTimeout),
        Eng = new Regex(@"^(?!you)", regexOptions, regexTimeout),
        Deu = new Regex(@"^(?!you)", regexOptions, regexTimeout),
        Fra = new Regex(@"^(?!you)", regexOptions, regexTimeout),
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
        Jpn = new Regex(@"^\w+[ .].+は.+にロットした", regexOptions, regexTimeout),
        Eng = new Regex(@"(.*) casts (his|her) lot for (.*)", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"(.*) lance ses dés pour (la|le|les) (.*)", regexOptions, regexTimeout),
    };

    public static readonly LocalizedRegex OthersRollNeedOrGreed = new()
    {
        Jpn = new Regex(@"^\w+[ .].+は.+に(NEED|GREED)のダイスで\d{1,2}を出した", regexOptions, regexTimeout),
        Eng = new Regex(@"(.*) rolls (Need|Greed) on (.*)\. \d{1,2}", regexOptions, regexTimeout),
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
        Jpn = new Regex(@"ポイントの経験値を得た", regexOptions, regexTimeout),
        Eng = new Regex(@".* (gain|gains) .* experience points", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@".* gagnez .* points d'expérience", regexOptions, regexTimeout),
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
public static readonly LocalizedRegex QuestionMarkCommandResponse = new()
    {
        Jpn = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Eng = new Regex(@"^(usage:|aliases:)", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
    };

#region PotD & HoH
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
/// <see href="https://xivapi.com/LogMessage/7265?pretty=true">Floor Number"</see>
    public static readonly LocalizedRegex FloorNumber = new()
    {
        Jpn = new Regex(@"^地下(\d|\d\d|\d\d\d)階", regexOptions, regexTimeout),
        Eng = new Regex(@"^floor (\d|\d\d|\d\d\d)", regexOptions, regexTimeout),
        Deu = new Regex(@"^ebene (\d|\d\d|\d\d\d) betreten", regexOptions, regexTimeout),
        Fra = new Regex(@"^sous-sol (\d|\d\d|\d\d\d)", regexOptions, regexTimeout),
    };

#endregion PotD & HoH
    
    #region Orchestrion

    // eg. "A Fierce Air Forceth is now playing."
    public static readonly LocalizedRegex OrchestrionPlaying = new()
    {
        Jpn = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Eng = new Regex(@"^.+ is now playing\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
    };
    
    #endregion Orchestrion

    #region Treasure Dungeons

    /// <summary>The gate to the 1st/2nd/3rd/4th/5th/6th chamber opens.</summary>
    public static readonly LocalizedRegex ChamberOpens = new()
    {
        Jpn = new Regex(@"第(?<chamber>[1-6])区画が開放された", regexOptions, regexTimeout),
        Eng = new Regex(@"^the gate to the (?<chamber>1st|2nd|3rd|4th|5th|6th) chamber opens\.$", regexOptions, regexTimeout),
        Deu = new Regex(@"^der zugang zur (?<chamber>1|2|3|4|5|6)\. kammer öffnet sich\.$", regexOptions, regexTimeout),
        Fra = new Regex(@"^la porte de la (?<chamber>1|2|3|4|5|6)(?:re|e) salle s'ouvre\.$", regexOptions, regexTimeout),
    };

    /// <summary>A trap is triggered! You are expelled from the area!</summary>
    public static readonly LocalizedRegex TrapTriggered = new()
    {
        Jpn = new Regex(@"トラップが発動した！.*退出させられた", regexOptions, regexTimeout),
        Eng = new Regex(@"^a trap is triggered! you are expelled from the area!$", regexOptions, regexTimeout),
        Deu = new Regex(@"^eine falle wurde ausgelöst! ihr werdet aus dem gebiet entfernt!$", regexOptions, regexTimeout),
        Fra = new Regex(@"^un piège s'est déclenché ! vous êtes expulsé de la zone !$", regexOptions, regexTimeout),
    };

    #endregion Treasure Dungeons

    #region Trial Synthesis
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

    #region Fishing / Lure

    // eg. "You attempt to lure small-jawed fish to your hook."
    //     "You make a second attempt to lure large-jawed fish to your hook."
    public static readonly LocalizedRegex LureAttempt = new()
    {
        Jpn = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Eng = new Regex(@"lure .+(small|large)-jawed fish to your hook", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
    };

    // eg. "You have a feeling you've attracted a fish with a strong bite!"
    //     "You have a feeling you've attracted a fish with a weak bite!"
    public static readonly LocalizedRegex LureBite = new()
    {
        Jpn = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Eng = new Regex(@"^you have a feeling you've attracted a fish with a (strong|weak) bite", regexOptions, regexTimeout),
        Deu = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new Regex(@"NeedsLocalization", regexOptions, regexTimeout),
    };

    #endregion Fishing / Lure
}
