using TidyChat.Localization.Data;
namespace TidyChat;

public static partial class ChatStrings
{
    /// <see href="https://xivapi.com/LogMessage/1350?pretty=true">/instance text</see>
    public static readonly LocalizedStrings InstancedArea = new()
    {
        Jpn = ["で現在のインスタンスを再確認できます。"],
        Eng = ["you", "are", "now", "in", "the", "instanced", "area"],
        Deu = ["instanziierten", "areal"],
        Fra = ["dans", "quelle", "instance", "vous", "trouvez"]
    };
    /// <see href="https://xivapi.com/LogMessage/926?pretty=true">Received Player Commendation</see>
    public static readonly LocalizedStrings PlayerCommendation = new()
    {
        Jpn = ["mip", "推薦を獲得しました"],
        Eng = ["you", "received", "a", "player", "commendation"],
        Deu = ["hast", "die", "auszeichnung"],
        Fra = ["équipiers", "vous", "honoré"]
    };
    public static readonly LocalizedStrings JoinParty = new()
    {
        Jpn = ["パーティー", "参加"],
        Eng = ["you", "join"],
        Deu = ["trittst", "gruppe"],
        Fra = ["vous", "rejoignez", "l'équipe"]
    };
    /// <see href="https://xivapi.com/LogMessage/7444?pretty=true">Cross-world party formed.</see>
    public static readonly LocalizedStrings CrossWorldPartyFormed = new()
    {
        Jpn = ["クロスワールドパーティを作成しました", "クロスワールドパーティは通常パーティと異なるため", "パーティに対して影響するアクションの効果が得られなくなります"],
        Eng = ["cross-world", "party", "formed"],
        Deu = ["weltenübergreifende", "statuseffekte", "normalerweise"],
        Fra = ["certaines", "appliqueront", "équipiers"]
    };
    /// <see href="https://xivapi.com/LogMessage/1?pretty=true">You invite … to a party.</see>
    public static readonly LocalizedStrings InviteSent = new()
    {
        Jpn = ["誘い"],
        Eng = ["invite"],
        Deu = ["eingeladen"],
        Fra = ["invitez"]
    };
    /// <see href="https://xivapi.com/LogMessage/3?pretty=true">… invites you to a party.</see>
    public static readonly LocalizedStrings InvitedBy = new()
    {
        Jpn = ["誘われ"],
        Eng = ["invites", "party"],
        Deu = ["eingeladen"],
        Fra = ["invite"]
    };
    /// <see href="https://xivapi.com/LogMessage/60?pretty=true">… joins the party.</see>
    public static readonly LocalizedStrings InviteeJoins = new()
    {
        Jpn = ["参加"],
        Eng = ["join", "party"],
        Deu = ["beigetreten"],
        Fra = ["rejoint", "équipe"]
    };
    /// <see href="https://xivapi.com/LogMessage/73?pretty=true">The party has been disbanded.</see>
    public static readonly LocalizedStrings PartyDisband = new()
    {
        Jpn = ["解散"],
        Eng = ["disbanded"],
        Deu = ["aufgelöst"],
        Fra = ["dissoute"]
    };
    /// <see href="https://xivapi.com/LogMessage/72?pretty=true">You dissolve the party.</see>
    public static readonly LocalizedStrings PartyDissolved = new()
    {
        Jpn = ["解散"],
        Eng = ["dissolve", "party"],
        Deu = ["aufgelöst"],
        Fra = ["dissoute"]
    };
    /// <see href="https://xivapi.com/LogMessage/440?pretty=true">You have been offered a Teleport …</see>
    public static readonly LocalizedStrings OfferedTeleport = new()
    {
        Jpn = ["テレポ"],
        Eng = ["teleport"],
        Deu = ["teleport"],
        Fra = ["téléporter"]
    };
}
