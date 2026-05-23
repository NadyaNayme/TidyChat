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
        Fra = new(@"you received \d{1} (commendation|commendations)", regexOptions, regexTimeout)
    };

    /// <see href="https://xivapi.com/Item/25?pretty=true">Wolf Marks</see>
    public static readonly LocalizedRegex ObtainedWolfMarks = new()
    {
        Jpn = new(@"(\d{1,3},)?\d{1,3} 対人戦績", regexOptions, regexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} wolf marks\.$", regexOptions, regexTimeout),
        Deu = new(@"(\d{1,3},)?\d{1,3} wolfsmarken erhalten\.$", regexOptions, regexTimeout),
        Fra = new(@"^(vous|you) (a|avez) reçu \d{1,6} marque de loup\.$", regexOptions, regexTimeout)
    };

    /// <see href="https://xivapi.com/Item/21072?pretty=true">Venture</see>
    public static readonly LocalizedRegex ObtainedVenture = new()
    {
        Jpn = new(@"you (obtain|obtains) (a venture|\d{1,2} ventures)\.", regexOptions, regexTimeout),
        Eng = new(@"you (obtain|obtains) (a venture|\d{1,2} ventures)\.", regexOptions, regexTimeout),
        Deu = new(@"you (obtain|obtains) (a venture|\d{1,2} ventures)\.", regexOptions, regexTimeout),
        Fra = new(@"you (obtain|obtains) (a venture|\d{1,2} ventures)\.", regexOptions, regexTimeout)
    };

    /// <see href="https://xivapi.com/Item/27?pretty=true">Allied Seals</see>
    public static readonly LocalizedRegex ObtainedAlliedSeals = new()
    {
        Jpn = new(@"^同盟記章を(\d{1,3},)?\d{1,3}個手に入れた。$", regexOptions, regexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} Allied Seals\.$", regexOptions, regexTimeout),
        Deu = new(@"(\d{1,3},)?\d{1,3} jagdabzeichen erhalten\.", regexOptions, regexTimeout),
        Fra = new(@"^(vous|you) obtenez \d{1,6} insignes alliés\.$", regexOptions, regexTimeout)
    };

    /// <see href="https://xivapi.com/Item/10307?pretty=true">Centurio Seals</see>
    public static readonly LocalizedRegex ObtainedCenturioSeals = new()
    {
        Jpn = new(@"^セントリオ記章を(\d{1,3},)?\d{1,3}個手に入れた。$", regexOptions, regexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} Centurio Seals\.$", regexOptions, regexTimeout),
        Deu = new(@"(\d{1,3},)?\d{1,3} centurio-abzeichen erhalten\.$", regexOptions, regexTimeout),
        Fra = new(@"^(vous|you) obtenez \d{1,6} insignes centurio\.$", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex ObtainedNuts = new()
    {
        Jpn = new(@"^モブハントの戦利品を(\d{1,3},)?\d{1,3}個手に入れた。$", regexOptions, regexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} sacks of Nuts\.$", regexOptions, regexTimeout),
        Deu = new(@"(\d{1,3},)?\d{1,3} kupo-trophaë\.", regexOptions, regexTimeout),
        Fra = new(@"^(vous|you) obtenez \d{1,6} insignes de chasse\.$", regexOptions, regexTimeout)
    };

    /// <see href="https://xivapi.com/Item/20?pretty=true">Storm Seals</see>
    /// <seealso href="https://xivapi.com/Item/21?pretty=true">
    ///     Serpent Seals</see>
    ///     <seealso href="https://xivapi.com/Item/22?pretty=true">Flame Seals</see>
    public static readonly LocalizedRegex ObtainedSeals = new()
    {
        Jpn = new(@"の軍票(\d{1,3},)?\d{1,3}枚を手に入れた。$", regexOptions, regexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3}(\(\+\d{1,2}\%\))? (Flame|Storm|Serpent) Seals\.$", regexOptions, regexTimeout),
        Deu = new(@"(flottentaler|ordenstaler|legionstaler) erhalten", regexOptions, regexTimeout),
        Fra = new(@"^(vous|you) obtenez \d{1,6} sceaux (de|des) (Immortels|Deux Vipères|Maelstrom)\.$",
            regexOptions, regexTimeout)
    };

    /// <see href="https://xivapi.com/Item/2?pretty=true">Fire Shard</see>
    /// ...
    /// <seealso href="https://xivapi.com/Item/19?pretty=true">Water Cluster</see>
    public static readonly LocalizedRegex ObtainedClusters = new()
    {
        Jpn = new(@"クラスター(×2)?を(手に入れた|入手した)", regexOptions, regexTimeout),
        Eng = new(@"^you (obtain|obtains) (a|2) (.*)(cluster|clusters)\.$", regexOptions, regexTimeout),
        Deu = new(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new(@"NeedsLocalization", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex ObtainedMaterials = new()
    {
        Jpn = new(@"^you (obtain|obtains) (.*) materials\.$", regexOptions, regexTimeout),
        Eng = new(@"^you (obtain|obtains) (.*) materials\.$", regexOptions, regexTimeout),
        Deu = new(@"^you (obtain|obtains) (.*) materials\.$", regexOptions, regexTimeout),
        Fra = new(@"^you (obtain|obtains) (.*) materials\.$", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex ObtainedShards = new()
    {
        Jpn = new(@"^you (obtain|obtains) (a|an|\d{1,3}) .{1,3}(fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.$", regexOptions, regexTimeout),
        Eng = new(@"^you (obtain|obtains) (a|an|\d{1,3}) .{1,3}(fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.$", regexOptions, regexTimeout),
        Deu = new(@"^you (obtain|obtains) (a|an|\d{1,3}) .{1,3}(fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.$", regexOptions, regexTimeout),
        Fra = new(@"^you (obtain|obtains) (a|an|\d{1,3}) .{1,3}(fire|ice|wind|earth|lightning|water) (shards|crystals|clusters)\.$", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex ObtainedTribalCurrency = new()
    {
        Jpn = new(@"NeedsTranslation", regexOptions, regexTimeout),
        Eng = new(
            @"^you (obtain|obtains) (a|an|2) (Steel (Amalj'ok|Amalj'oks)|Sylphic (Goldleaf|Goldleaves)|Titan (Cobaltpiece|Cobaltpieces)|(Rainbowtide Psashp|Psashps)|Ixali (oaknot|oaknots)|Vanu (Whitebone|Whitebones)|Black Copper (Gil|Gils)|Carved Kupo (Nut|Nuts)|Kojin (Sango|Sangos)|Ananta Dreamstaves|Ananta Dreamstaffs|Namazu (Koban|Kobans)|Fae (Fancy|Fancies)|Qitari (Compliment|Compliments)|Hammered (Frogment|Fragments)|Arkasodara (Pana|Panas))\.$",
            regexOptions, regexTimeout),
        Deu = new(
            @"^(du|you) hast (einen|2) (Stahl-Amalj'ok|Sylphen-goldblatt|Titan-koboldeistenstück|Regenbogenwellen-Psashp|Ixal-eichenmünze|Vanu-Weißknochen|Schwarzkupfer-Gil|Kupo-Schnitznuss|Kohin-Koralle|Ananta-Traumstab|Namazuo-Koban|Pixie-Glitter|Qitari-Kastanienkreuzer|Zwergenmünze) erhalten\.$",
            regexOptions, regexTimeout),
        Fra = new(@"NeedsTranslation", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex PlayerTargetedEmote = new()
    {
        Jpn = new(@"you|your", regexOptions, regexTimeout),
        Eng = new(@"you|your|question springs|springs a question", regexOptions, regexTimeout),
        Deu = new(@"you|your|du|deiner|dir|dich", regexOptions, regexTimeout),
        Fra = new(@"you|your|vous", regexOptions, regexTimeout)
    };
    public static readonly LocalizedRegex ContainsPlayerName = new()
    {
        Jpn = new(@"(you|your)", regexOptions, regexTimeout),
        Eng = new(@"(you|your)", regexOptions, regexTimeout),
        Deu = new(@"(you|your|du|deiner|dir|dich)", regexOptions, regexTimeout),
        Fra = new(@"(vous|you)", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex NotStartWithYou = new()
    {
        Jpn = new(@"^(?!you)", regexOptions, regexTimeout),
        Eng = new(@"^(?!you)", regexOptions, regexTimeout),
        Deu = new(@"^(?!you)", regexOptions, regexTimeout),
        Fra = new(@"^(?!you)", regexOptions, regexTimeout)
    };

    /// <see href="https://xivapi.com/LogMessage/2600?pretty=true">You sense something foul may be lurking in the distance.</see>
    /// <seealso href="https://xivapi.com/LogMessage/4791?pretty=true">You sense something close.</see>
    public static readonly LocalizedRegex SpideySenses = new()
    {
        Jpn = new("NeedsLocalization", regexOptions, regexTimeout),
        Eng = new("you sense", regexOptions, regexTimeout), // You sense something... , You sense your mark..., You sense a strange...
        Deu = new("NeedsLocalization", regexOptions, regexTimeout),
        Fra = new("(vous|you) (percevez|ressentez)", regexOptions, regexTimeout)
    };

    /// <summary>
    ///     Text-based fallback for XP gain messages whose LogMessageId isn't registered.
    ///     Covers "You gain N experience points." and "You gain N(+M%) job experience points."
    ///     as well as other-player variants ("Name gains N experience points.").
    /// </summary>
    public static readonly LocalizedRegex GainExperience = new()
    {
        Jpn = new(@"経験値", regexOptions, regexTimeout),
        Eng = new(@"\d[\d,]*(\(\+\d+%\))?\s+\w*\s*experience points", regexOptions, regexTimeout),
        Deu = new(@"\d[\d,]* erfahrungspunkte", regexOptions, regexTimeout),
        Fra = new(@"\d[\d,]* points? d'expérience", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex CastLot = new()
    {
        Jpn = new(@"^youは.*にロットした。$", regexOptions, regexTimeout),
        Eng = new(@"^you (cast|casts) (your|his|her) lot for (.*)\.$", regexOptions, regexTimeout),
        Deu = new(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new(@"NeedsLocalization", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex RollsNeedOrGreed = new()
    {
        Jpn = new(@"^youは.+に(NEED|GREED)のダイスで\d{1,2}を出した。$", regexOptions, regexTimeout),
        Eng = new(@"^you (roll|rolls) (Need|Greed) on (.*)\. \d{1,2}\!$", regexOptions, regexTimeout),
        Deu = new(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new(@"NeedsLocalization", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex OthersCastLot = new()
    {
        // relies on the fact that all player names have a space between them (or a period if initialised)
        Jpn = new(@"^\w+[ .].+は.+にロットした", regexOptions, regexTimeout),
        Eng = new(@"(.*) casts (his|her) lot for (.*)", regexOptions, regexTimeout),
        Deu = new(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new(@"(.*) lance ses dés pour (la|le|les) (.*)", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex OthersRollNeedOrGreed = new()
    {
        Jpn = new(@"^\w+[ .].+は.+に(NEED|GREED)のダイスで\d{1,2}を出した", regexOptions, regexTimeout),
        Eng = new(@"(.*) rolls (Need|Greed) on (.*)\. \d{1,2}", regexOptions, regexTimeout),
        Deu = new(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new(@"(.*) jette les dés (Cupidité) pour (la|le|les) (.*)", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex OtherObtains = new()
    {
        Jpn = new(@"^\w+[ .].+は.+を手に入れた。$", regexOptions, regexTimeout),
        Eng = new(@"(.*) obtains .+", regexOptions, regexTimeout),
        Deu = new(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new(@"(.*) obtient (un|une|\d{1,3}) .+", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex ObtainedTomestones = new()
    {
        Jpn = new(@"^アラガントームストーン:([^を]+)を(\d{1,3}個手に入れた|入手した)。$", regexOptions, regexTimeout),
        Eng = new(@"^you (obtain|obtains) \d{1,3} Allagan tomestones of", regexOptions, regexTimeout),
        Deu = new(
            @"(du|you) hast \d{1,3} (Allagischer|Allagisch|Allagische|Allagischa) (Stein|Steine) (der|des) \w+ erhalten\.$",
            regexOptions, regexTimeout),
        Fra = new(@"(vous|you) obtenez \d{1,3} Mémoquartz allagois (\w+)", regexOptions, regexTimeout)
    };

    public static readonly LocalizedRegex AetherialReductionSands = new()
    {
        Jpn = new(@".+handfuls of .+ .+sand are obtained\.", regexOptions, regexTimeout),
        Eng = new(@".+handfuls of .+ .+sand are obtained\.", regexOptions, regexTimeout),
        Deu = new(@".+handfuls of .+ .+sand are obtained\.", regexOptions, regexTimeout),
        Fra = new(@".+handfuls of .+ .+sand are obtained\.", regexOptions, regexTimeout)
    };

    /// <see href="https://xivapi.com/LogMessage/4225?pretty=true">
    ///     One or more party members have yet to complete this duty. A
    ///     bonus of ... will be awarded upon completion.
    /// </see>
    public static readonly LocalizedRegex PartyMemberFirstClear = new()
    {
        Jpn = new(@"未制覇の参加メンバーがいるため、攻略成功時に", regexOptions, regexTimeout),
        Eng = new(@"one or more party members have yet to complete this duty", regexOptions, regexTimeout),
        Deu = new(
            @"weil ein charakter diesen inhalt noch nicht beendet hat",
            regexOptions, regexTimeout),
        Fra = new(
            @"un ou plusieurs participants n\'ont pas encore accompli cette mission",
            regexOptions, regexTimeout)
    };
    public static readonly LocalizedRegex QuestionMarkCommandResponse = new()
    {
        Jpn = new(@"NeedsLocalization", regexOptions, regexTimeout),
        Eng = new(@"^(usage:|aliases:)", regexOptions, regexTimeout),
        Deu = new(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new(@"NeedsLocalization", regexOptions, regexTimeout)
    };
    
    // English patterns cover all of those. Jpn/Deu/Fra match only the lines carrying an
    // sqex.to link (that domain is identical in every client). TODO: add localized welcome /
    // congestion / phishing header text for full non-English coverage.
    public static readonly LocalizedRegex ServerWorldGreeting = new()
    {
        Jpn = new(@"(?!)", regexOptions, regexTimeout),  // TODO(#122): localized "Welcome to <World>!"
        Eng = new(@"^welcome to \w+!\s*$", regexOptions, regexTimeout),
        Deu = new(@"(?!)", regexOptions, regexTimeout),  // TODO(#122): localized greeting
        Fra = new(@"(?!)", regexOptions, regexTimeout)   // TODO(#122): localized greeting
    };

    public static readonly LocalizedRegex ServerAnnouncement = new()
    {
        Jpn = new(@"sqex\.to/", regexOptions, regexTimeout),
        Eng = new(@"welcome to final fantasy xiv|be wary of phishing|if you receive a tell containing a url|is underway until|home world transfer|sqex\.to/", regexOptions, regexTimeout),
        Deu = new(@"sqex\.to/", regexOptions, regexTimeout),
        Fra = new(@"sqex\.to/", regexOptions, regexTimeout)
    };

    /// <summary>
    ///     Matches the phishing/congestion warning lines in the server announcement block.
    ///     Used by <see cref="ServerAnnouncementMode.HidePhishing"/> to suppress only these lines.
    /// </summary>
    public static readonly LocalizedRegex ServerPhishingWarning = new()
    {
        Jpn = new(@"sqex\.to/", regexOptions, regexTimeout),
        Eng = new(@"be wary of phishing|if you receive a tell containing a url|home world transfer", regexOptions, regexTimeout),
        Deu = new(@"sqex\.to/", regexOptions, regexTimeout),
        Fra = new(@"sqex\.to/", regexOptions, regexTimeout)
    };

#region PotD & HoH

    /// <see href="https://xivapi.com/LogMessage/7245?pretty=true">
    ///     Aetherpool item flickers/brightens/flares. Its strength is
    ///     now +0-98"
    /// </see>
    public static readonly LocalizedRegex AetherpoolIncrease = new()
    {
        Jpn = new(@"強化値が([0-9]|[1-8][0-9]|9[0-8])になった", regexOptions, regexTimeout),
        Eng = new(@"its strength is now \+([0-9]|[1-8][0-9]|9[0-8])", regexOptions, regexTimeout),
        Deu = new(@"steigt auf \+([0-9]|[1-8][0-9]|9[0-8])", regexOptions, regexTimeout),
        Fra = new(@"passe à \+([0-9]|[1-8][0-9]|9[0-8])", regexOptions, regexTimeout)
    };
    /// <see href="https://xivapi.com/LogMessage/7265?pretty=true">Floor Number"</see>
    public static readonly LocalizedRegex FloorNumber = new()
    {
        Jpn = new(@"^地下(\d|\d\d|\d\d\d)階", regexOptions, regexTimeout),
        Eng = new(@"^floor (\d|\d\d|\d\d\d)|floors \d+-\d+\) has begun", regexOptions, regexTimeout),
        Deu = new(@"^ebene (\d|\d\d|\d\d\d) betreten", regexOptions, regexTimeout),
        Fra = new(@"^sous-sol (\d|\d\d|\d\d\d)", regexOptions, regexTimeout)
    };

#endregion PotD & HoH


    #region Treasure Dungeons

    /// <summary>The gate to the 1st/2nd/3rd/4th/5th/6th chamber opens.</summary>
    public static readonly LocalizedRegex ChamberOpens = new()
    {
        Jpn = new(@"第(?<chamber>[1-6])区画が開放された", regexOptions, regexTimeout),
        Eng = new(@"^the gate to the (?<chamber>1st|2nd|3rd|4th|5th|6th) chamber opens\.$", regexOptions, regexTimeout),
        Deu = new(@"^der zugang zur (?<chamber>1|2|3|4|5|6)\. kammer öffnet sich\.$", regexOptions, regexTimeout),
        Fra = new(@"^la porte de la (?<chamber>1|2|3|4|5|6)(?:re|e) salle s'ouvre\.$", regexOptions, regexTimeout)
    };

    /// <summary>A trap is triggered! You are expelled from the area!</summary>
    public static readonly LocalizedRegex TrapTriggered = new()
    {
        Jpn = new(@"トラップが発動した！.*退出させられた", regexOptions, regexTimeout),
        Eng = new(@"^a trap is triggered! you are expelled from the area!$", regexOptions, regexTimeout),
        Deu = new(@"^eine falle wurde ausgelöst! ihr werdet aus dem gebiet entfernt!$", regexOptions, regexTimeout),
        Fra = new(@"^un piège s'est déclenché ! vous êtes expulsé de la zone !$", regexOptions, regexTimeout)
    };

    #endregion Treasure Dungeons
}
