using System.Text.RegularExpressions;
using TidyChat.Translation.Data;
namespace TidyChat;

public static class ChatRegexStrings
{
    private static readonly RegexOptions regexOptions =
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

    private static readonly TimeSpan regexTimeout = TimeSpan.FromSeconds(1);

    /// <see href="https://xivapi.com/Item/25?pretty=true">Wolf Marks</see>
    public static readonly LocalizedRegex ObtainedWolfMarks = new()
    {
        Jpn = new(@"(\d{1,3},)?\d{1,3} 対人戦績", regexOptions, regexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} wolf marks\.$", regexOptions, regexTimeout),
        Deu = new(@"(\d{1,3},)?\d{1,3} wolfsmarken erhalten\.$", regexOptions, regexTimeout),
        Fra = new(@"^(vous|you) (a|avez) reçu \d{1,6} marque de loup\.$", regexOptions, regexTimeout)
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


    /// <see href="https://xivapi.com/Item/41784?pretty=true">Sacks of Nuts</see>
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


    public static readonly LocalizedRegex ObtainedTribalCurrency = new()
    {
        Jpn = new(@"NeedsTranslation", regexOptions, regexTimeout),
        Eng = new(
            @"^you (obtain|obtains) (a|an|\d{1,3}) (Steel (Amalj'ok|Amalj'oks)|Sylphic (Goldleaf|Goldleaves)|Titan (Cobaltpiece|Cobaltpieces)|(Rainbowtide Psashp|Psashps)|Ixali (oaknot|oaknots)|Vanu (Whitebone|Whitebones)|Black Copper (Gil|Gils)|Carved Kupo (Nut|Nuts)|Kojin (Sango|Sangos)|Ananta Dreamstaves|Ananta Dreamstaffs|Namazu (Koban|Kobans)|Fae (Fancy|Fancies)|Qitari (Compliment|Compliments)|Hammered (Frogment|Fragments)|Arkasodara (Pana|Panas)|Pelu (Pelplume|Pelplumes)|Mamool Ja (Nanook|Nanooks)|Yok Huy (Ward|Wards))\.$",
            regexOptions, regexTimeout),
        Deu = new(
            @"^(du|you) hast (einen|\d{1,3}) (Stahl-Amalj'ok|Sylphen-goldblatt|Titan-koboldeistenstück|Regenbogenwellen-Psashp|Ixal-eichenmünze|Vanu-Weißknochen|Schwarzkupfer-Gil|Kupo-Schnitznuss|Kohin-Koralle|Ananta-Traumstab|Namazuo-Koban|Pixie-Glitter|Qitari-Kastanienkreuzer|Zwergenmünze|Flügelmünze|Mamool Ja-Nanook|Yok Huy-Brosche) erhalten\.$",
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
    public static readonly LocalizedRegex SpideySenses = new()
    {
        Jpn = new("NeedsLocalization", regexOptions, regexTimeout),
        Eng = new("you sense", regexOptions, regexTimeout), // You sense something... , You sense your mark..., You sense a strange...
        Deu = new("NeedsLocalization", regexOptions, regexTimeout),
        Fra = new("(vous|you) (percevez|ressentez)", regexOptions, regexTimeout)
    };


    /// <see href="https://xivapi.com/LogMessage/588?pretty=true">Gain experience (588, 589, 4466, …)</see>
    /// <seealso href="https://xivapi.com/LogMessage/549?pretty=true">BattleSystem XP / chain bonus</see>
    public static readonly LocalizedRegex OthersCastLot = new()
    {
        Jpn = new(@"^\w+[ .].+は.+にロットした", regexOptions, regexTimeout),
        Eng = new(@"^(?!you ).* casts (his|her|their) lot for (.*)", regexOptions, regexTimeout),
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


    /// <see href="https://xivapi.com/LogMessage/657?pretty=true">Shared obtain template (tomestone lines)</see>
    /// <seealso href="https://xivapi.com/LogMessage/2164?pretty=true">Tomestone obtain (alternate template)</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/2165?pretty=true">Tomestone obtain (alternate template)</seealso>
    public static readonly LocalizedRegex ObtainedTomestones = new()
    {
        Jpn = new(@"^アラガントームストーン:([^を]+)を(\d{1,3}個手に入れた|入手した)。$", regexOptions, regexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} allagan tomestones of", regexOptions, regexTimeout),
        Deu = new(
            @"(du|you) hast (\d{1,3},)?\d{1,3} (Allagischer|Allagisch|Allagische|Allagischa) (Stein|Steine) (der|des) \w+ erhalten\.$",
            regexOptions, regexTimeout),
        Fra = new(@"(vous|you) obtenez (\d{1,3},)?\d{1,3} Mémoquartz allagois (\w+)", regexOptions, regexTimeout)
    };

    /// <see href="https://xivapi.com/LogMessage/2174?pretty=true">Tomestone weekly cap reached</see>
    public static readonly LocalizedRegex TomestoneWeeklyCap = new()
    {
        Jpn = new(@"NeedsLocalization", regexOptions, regexTimeout),
        Eng = new(@"^you cannot receive any more allagan tomestones", regexOptions, regexTimeout),
        Deu = new(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new(@"NeedsLocalization", regexOptions, regexTimeout)
    };


    public static readonly LocalizedRegex QuestionMarkCommandResponse = new()
    {
        Jpn = new(@"NeedsLocalization", regexOptions, regexTimeout),
        Eng = new(@"^(usage:|aliases:)", regexOptions, regexTimeout),
        Deu = new(@"NeedsLocalization", regexOptions, regexTimeout),
        Fra = new(@"NeedsLocalization", regexOptions, regexTimeout)
    };
    /// <see href="https://xivapi.com/LogMessage/1531?pretty=true">Duty has begun.</see>
    public static readonly LocalizedRegex DutyHasBegun = new()
    {
        Jpn = new(@"^(?<duty>.+?)が開始", regexOptions, regexTimeout),
        Eng = new(@"^(?<duty>.+?)\s+has\s+begun\.?$", regexOptions, regexTimeout),
        Deu = new(@"^(?<duty>.+?)\s+hat\s+begonnen\.?$", regexOptions, regexTimeout),
        Fra = new(@"^(?<duty>.+?)\s+a\s+commencé\.?$", regexOptions, regexTimeout)
    };

    /// <see href="https://xivapi.com/LogMessage/748?pretty=true">Market board item sold (after fees).</see>
    public static readonly LocalizedRegex MarketItemSold = new()
    {
        Jpn = new(@"you put up for sale.*?(?:has|have) sold for (?<gil>[\d,]+) gil", regexOptions, regexTimeout),
        Eng = new(@"you put up for sale.*?(?:has|have) sold for (?<gil>[\d,]+) gil", regexOptions, regexTimeout),
        Deu = new(@"you put up for sale.*?(?:has|have) sold for (?<gil>[\d,]+) gil", regexOptions, regexTimeout),
        Fra = new(@"you put up for sale.*?(?:has|have) sold for (?<gil>[\d,]+) gil", regexOptions, regexTimeout)
    };

    #region Treasure Dungeons

    public static readonly LocalizedRegex ChamberOpens = new()
    {
        Jpn = new(@"第(?<chamber>[1-6])区画が開放された", regexOptions, regexTimeout),
        Eng = new(@"^the gate to the (?<chamber>1st|2nd|3rd|4th|5th|6th) chamber opens\.$", regexOptions, regexTimeout),
        Deu = new(@"^der zugang zur (?<chamber>1|2|3|4|5|6)\. kammer öffnet sich\.$", regexOptions, regexTimeout),
        Fra = new(@"^la porte de la (?<chamber>1|2|3|4|5|6)(?:re|e) salle s'ouvre\.$", regexOptions, regexTimeout)
    };


    /// <see href="https://xivapi.com/LogMessage/7224?pretty=true">Deep dungeon trap (7224–7229)</see>
    public static readonly LocalizedRegex TrapTriggered = new()
    {
        Jpn = new(@"トラップが発動した！.*退出させられた", regexOptions, regexTimeout),
        Eng = new(@"^a trap is triggered! you are expelled from the area!$", regexOptions, regexTimeout),
        Deu = new(@"^eine falle wurde ausgelöst! ihr werdet aus dem gebiet entfernt!$", regexOptions, regexTimeout),
        Fra = new(@"^un piège s'est déclenché ! vous êtes expulsé de la zone !$", regexOptions, regexTimeout)
    };

    #endregion Treasure Dungeons
}
