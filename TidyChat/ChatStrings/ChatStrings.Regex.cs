using System.Text.RegularExpressions;
using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    private static readonly RegexOptions RegexOptions =
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

    private static readonly TimeSpan RegexTimeout = TimeSpan.FromSeconds(1);

    /// <see href="https://xivapi.com/Item/25?pretty=true">Wolf Marks</see>
    public static readonly LocalizedRegex ObtainedWolfMarks = new()
    {
        Jpn = new(@"(\d{1,3},)?\d{1,3} 対人戦績", RegexOptions, RegexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} wolf marks\.$", RegexOptions, RegexTimeout),
        Deu = new(@"(\d{1,3},)?\d{1,3} wolfsmarken erhalten\.$", RegexOptions, RegexTimeout),
        Fra = new(@"^(vous|you) (a|avez) reçu \d{1,6} marque de loup\.$", RegexOptions, RegexTimeout)
    };

    /// <see href="https://xivapi.com/Item/27?pretty=true">Allied Seals</see>
    public static readonly LocalizedRegex ObtainedAlliedSeals = new()
    {
        Jpn = new(@"^同盟記章を(\d{1,3},)?\d{1,3}個手に入れた。$", RegexOptions, RegexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} Allied Seals\.$", RegexOptions, RegexTimeout),
        Deu = new(@"(\d{1,3},)?\d{1,3} jagdabzeichen erhalten\.", RegexOptions, RegexTimeout),
        Fra = new(@"^(vous|you) obtenez \d{1,6} insignes alliés\.$", RegexOptions, RegexTimeout)
    };

    /// <see href="https://xivapi.com/Item/10307?pretty=true">Centurio Seals</see>
    public static readonly LocalizedRegex ObtainedCenturioSeals = new()
    {
        Jpn = new(@"^セントリオ記章を(\d{1,3},)?\d{1,3}個手に入れた。$", RegexOptions, RegexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} Centurio Seals\.$", RegexOptions, RegexTimeout),
        Deu = new(@"(\d{1,3},)?\d{1,3} centurio-abzeichen erhalten\.$", RegexOptions, RegexTimeout),
        Fra = new(@"^(vous|you) obtenez \d{1,6} insignes centurio\.$", RegexOptions, RegexTimeout)
    };

    /// <see href="https://xivapi.com/Item/41784?pretty=true">Sacks of Nuts</see>
    public static readonly LocalizedRegex ObtainedNuts = new()
    {
        Jpn = new(@"^モブハントの戦利品を(\d{1,3},)?\d{1,3}個手に入れた。$", RegexOptions, RegexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} sacks of Nuts\.$", RegexOptions, RegexTimeout),
        Deu = new(@"(\d{1,3},)?\d{1,3} kupo-trophaë\.", RegexOptions, RegexTimeout),
        Fra = new(@"^(vous|you) obtenez \d{1,6} insignes de chasse\.$", RegexOptions, RegexTimeout)
    };

    /// <see href="https://xivapi.com/Item/20?pretty=true">Storm Seals</see>
    /// <seealso href="https://xivapi.com/Item/21?pretty=true">Serpent Seals</seealso>
    /// <seealso href="https://xivapi.com/Item/22?pretty=true">Flame Seals</seealso>
    public static readonly LocalizedRegex ObtainedSeals = new()
    {
        Jpn = new(@"の軍票(\d{1,3},)?\d{1,3}枚を手に入れた。$", RegexOptions, RegexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\s?\d{1,3}(\(\+\d{1,2}\%\))? (Flame|Storm|Serpent) Seals\.$", RegexOptions, RegexTimeout),
        Deu = new(@"(flottentaler|ordenstaler|legionstaler) erhalten", RegexOptions, RegexTimeout),
        Fra = new(@"^(vous|you) obtenez \d{1,6} sceaux (de|des) (Immortels|Deux Vipères|Maelstrom)\.$",
            RegexOptions, RegexTimeout)
    };

    public static readonly LocalizedRegex ObtainedTribalCurrency = new()
    {
        Jpn = new(@"NeedsTranslation", RegexOptions, RegexTimeout),
        Eng = new(
            @"^you (obtain|obtains) (a|an|\d{1,3}) (Steel (Amalj'ok|Amalj'oks)|Sylphic (Goldleaf|Goldleaves)|Titan (Cobaltpiece|Cobaltpieces)|(Rainbowtide Psashp|Psashps)|Ixali (oaknot|oaknots)|Vanu (Whitebone|Whitebones)|Black Copper (Gil|Gils)|Carved Kupo (Nut|Nuts)|Kojin (Sango|Sangos)|Ananta Dreamstaves|Ananta Dreamstaffs|Namazu (Koban|Kobans)|Fae (Fancy|Fancies)|Qitari (Compliment|Compliments)|Hammered (Frogment|Fragments)|Arkasodara (Pana|Panas)|Pelu (Pelplume|Pelplumes)|Mamool Ja (Nanook|Nanooks)|Yok Huy (Ward|Wards))\.$",
            RegexOptions, RegexTimeout),
        Deu = new(
            @"^(du|you) hast (einen|\d{1,3}) (Stahl-Amalj'ok|Sylphen-goldblatt|Titan-koboldeistenstück|Regenbogenwellen-Psashp|Ixal-eichenmünze|Vanu-Weißknochen|Schwarzkupfer-Gil|Kupo-Schnitznuss|Kohin-Koralle|Ananta-Traumstab|Namazuo-Koban|Pixie-Glitter|Qitari-Kastanienkreuzer|Zwergenmünze|Flügelmünze|Mamool Ja-Nanook|Yok Huy-Brosche) erhalten\.$",
            RegexOptions, RegexTimeout),
        Fra = new(@"NeedsTranslation", RegexOptions, RegexTimeout)
    };

    public static readonly LocalizedRegex PlayerTargetedEmote = new()
    {
        Jpn = new(@"you|your", RegexOptions, RegexTimeout),
        Eng = new(@"you|your|question springs|springs a question", RegexOptions, RegexTimeout),
        Deu = new(@"you|your|du|deiner|dir|dich", RegexOptions, RegexTimeout),
        Fra = new(@"you|your|vous", RegexOptions, RegexTimeout)
    };

    public static readonly LocalizedRegex ContainsPlayerName = new()
    {
        Jpn = new(@"(you|your)", RegexOptions, RegexTimeout),
        Eng = new(@"(you|your)", RegexOptions, RegexTimeout),
        Deu = new(@"(you|your|du|deiner|dir|dich)", RegexOptions, RegexTimeout),
        Fra = new(@"(vous|you)", RegexOptions, RegexTimeout)
    };

    public static readonly LocalizedRegex NotStartWithYou = new()
    {
        Jpn = new(@"^(?!you)", RegexOptions, RegexTimeout),
        Eng = new(@"^(?!you)", RegexOptions, RegexTimeout),
        Deu = new(@"^(?!you)", RegexOptions, RegexTimeout),
        Fra = new(@"^(?!you)", RegexOptions, RegexTimeout)
    };

    /// <see href="https://xivapi.com/LogMessage/2600?pretty=true">You sense something foul may be lurking in the distance.</see>
    public static readonly LocalizedRegex SpideySensesRegex = new()
    {
        Jpn = new("NeedsLocalization", RegexOptions, RegexTimeout),
        Eng = new("you sense", RegexOptions, RegexTimeout),
        Deu = new("NeedsLocalization", RegexOptions, RegexTimeout),
        Fra = new("(vous|you) (percevez|ressentez)", RegexOptions, RegexTimeout)
    };

    /// <see href="https://xivapi.com/LogMessage/588?pretty=true">Gain experience (588, 589, 4466, …)</see>
    /// <seealso href="https://xivapi.com/LogMessage/549?pretty=true">BattleSystem XP / chain bonus</seealso>
    public static readonly LocalizedRegex OthersCastLot = new()
    {
        Jpn = new(@"^\w+[ .].+は.+にロットした", RegexOptions, RegexTimeout),
        Eng = new(@"^(?!you ).* casts (his|her|their) lot for (.*)", RegexOptions, RegexTimeout),
        Deu = new(@"NeedsLocalization", RegexOptions, RegexTimeout),
        Fra = new(@"(.*) lance ses dés pour (la|le|les) (.*)", RegexOptions, RegexTimeout)
    };

    public static readonly LocalizedRegex OthersRollNeedOrGreed = new()
    {
        Jpn = new(@"^\w+[ .].+は.+に(NEED|GREED)のダイスで\d{1,2}を出した", RegexOptions, RegexTimeout),
        Eng = new(@"(.*) rolls (Need|Greed) on (.*)\. \d{1,2}", RegexOptions, RegexTimeout),
        Deu = new(@"NeedsLocalization", RegexOptions, RegexTimeout),
        Fra = new(@"(.*) jette les dés (Cupidité) pour (la|le|les) (.*)", RegexOptions, RegexTimeout)
    };

    /// <see href="https://xivapi.com/LogMessage/657?pretty=true">Shared obtain template (tomestone lines)</see>
    /// <seealso href="https://xivapi.com/LogMessage/2164?pretty=true">Tomestone obtain (alternate template)</seealso>
    /// <seealso href="https://xivapi.com/LogMessage/2165?pretty=true">Tomestone obtain (alternate template)</seealso>
    public static readonly LocalizedRegex ObtainedTomestones = new()
    {
        Jpn = new(@"^アラガントームストーン:([^を]+)を(\d{1,3}個手に入れた|入手した)。$", RegexOptions, RegexTimeout),
        Eng = new(@"^you (obtain|obtains) (\d{1,3},)?\d{1,3} allagan tomestones of", RegexOptions, RegexTimeout),
        Deu = new(
            @"(du|you) hast (\d{1,3},)?\d{1,3} (Allagischer|Allagisch|Allagische|Allagischa) (Stein|Steine) (der|des) \w+ erhalten\.$",
            RegexOptions, RegexTimeout),
        Fra = new(@"(vous|you) obtenez (\d{1,3},)?\d{1,3} Mémoquartz allagois (\w+)", RegexOptions, RegexTimeout)
    };

    /// <see href="https://xivapi.com/LogMessage/2174?pretty=true">Tomestone weekly cap reached</see>
    public static readonly LocalizedRegex TomestoneWeeklyCap = new()
    {
        Jpn = new(@"NeedsLocalization", RegexOptions, RegexTimeout),
        Eng = new(@"^you cannot receive any more allagan tomestones", RegexOptions, RegexTimeout),
        Deu = new(@"NeedsLocalization", RegexOptions, RegexTimeout),
        Fra = new(@"NeedsLocalization", RegexOptions, RegexTimeout)
    };

    public static readonly LocalizedRegex QuestionMarkCommandResponse = new()
    {
        Jpn = new(@"NeedsLocalization", RegexOptions, RegexTimeout),
        Eng = new(@"^(usage:|aliases:)", RegexOptions, RegexTimeout),
        Deu = new(@"NeedsLocalization", RegexOptions, RegexTimeout),
        Fra = new(@"NeedsLocalization", RegexOptions, RegexTimeout)
    };

    /// <see href="https://xivapi.com/LogMessage/4415?pretty=true">You obtain a stack of mark bills.</see>
    public static readonly LocalizedRegex MarkBillObtainRegex = new()
    {
        Jpn = new(@"^(?:you obtain(?:ed)?)\s+a stack of\s+(?<bill>.+?\s+bills?)\.?$", RegexOptions, RegexTimeout),
        Eng = new(@"^(?:you obtain(?:ed)?)\s+a stack of\s+(?<bill>.+?\s+bills?)\.?$", RegexOptions, RegexTimeout),
        Deu = new(@"^(?:du hast|ihr habt)\s+eine jagdlizenz für\s+(?<bill>.+?)\s+angenommen\.?$", RegexOptions,
            RegexTimeout),
        Fra = new(@"^(?:vous avez obtenu)\s+une pile de\s+(?<bill>.+?\s+bills?)\.?$", RegexOptions, RegexTimeout)
    };

    /// <see href="https://xivapi.com/LogMessage/1531?pretty=true">Duty has begun.</see>
    public static readonly LocalizedRegex DutyHasBegunRegex = new()
    {
        Jpn = new(@"^(?<duty>.+?)が開始", RegexOptions, RegexTimeout),
        Eng = new(@"^(?<duty>.+?)\s+has\s+begun\.?$", RegexOptions, RegexTimeout),
        Deu = new(@"^(?<duty>.+?)\s+hat\s+begonnen\.?$", RegexOptions, RegexTimeout),
        Fra = new(@"^(?<duty>.+?)\s+a\s+commencé\.?$", RegexOptions, RegexTimeout)
    };

    /// <see href="https://xivapi.com/LogMessage/748?pretty=true">Market board item sold (after fees).</see>
    public static readonly LocalizedRegex MarketItemSoldRegex = new()
    {
        Jpn = new(@"you put up for sale.*?(?:has|have) sold for (?<gil>[\d,]+) gil", RegexOptions, RegexTimeout),
        Eng = new(@"you put up for sale.*?(?:has|have) sold for (?<gil>[\d,]+) gil", RegexOptions, RegexTimeout),
        Deu = new(@"you put up for sale.*?(?:has|have) sold for (?<gil>[\d,]+) gil", RegexOptions, RegexTimeout),
        Fra = new(@"you put up for sale.*?(?:has|have) sold for (?<gil>[\d,]+) gil", RegexOptions, RegexTimeout)
    };

    #region Treasure Dungeons

    public static readonly LocalizedRegex ChamberOpens = new()
    {
        Jpn = new(@"第(?<chamber>[1-6])区画が開放された", RegexOptions, RegexTimeout),
        Eng = new(@"^the gate to the (?<chamber>1st|2nd|3rd|4th|5th|6th) chamber opens\.$", RegexOptions, RegexTimeout),
        Deu = new(@"^der zugang zur (?<chamber>1|2|3|4|5|6)\. kammer öffnet sich\.$", RegexOptions, RegexTimeout),
        Fra = new(@"^la porte de la (?<chamber>1|2|3|4|5|6)(?:re|e) salle s'ouvre\.$", RegexOptions, RegexTimeout)
    };

    /// <see href="https://xivapi.com/LogMessage/7224?pretty=true">Deep dungeon trap (7224–7229)</see>
    public static readonly LocalizedRegex TrapTriggered = new()
    {
        Jpn = new(@"トラップが発動した！.*退出させられた", RegexOptions, RegexTimeout),
        Eng = new(@"^a trap is triggered! you are expelled from the area!$", RegexOptions, RegexTimeout),
        Deu = new(@"^eine falle wurde ausgelöst! ihr werdet aus dem gebiet entfernt!$", RegexOptions, RegexTimeout),
        Fra = new(@"^un piège s'est déclenché ! vous êtes expulsé de la zone !$", RegexOptions, RegexTimeout)
    };

    #endregion Treasure Dungeons
}
