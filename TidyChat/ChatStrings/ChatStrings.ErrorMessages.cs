using TidyChat.Translation.Data;
namespace TidyChat;

public static partial class ChatStrings
{

    public static readonly LocalizedStrings OnlyAvailableWhileCrafting = new()
    {
        Jpn = ["製作", "製作練習", "のみ"],
        Eng = ["only", "available", "while", "crafting"],
        Deu = ["synthese", "testsynthese", "verwendbar"],
        Fra = ["synthèse", "réservée"]
    };


    public static readonly LocalizedStrings CannotExecute = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["cannot", "execute"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings CommandUnavailable = new()
    {
        Jpn = ["コマンド", "使用"],
        Eng = ["command", "unavailable"],
        Deu = ["befehl", "nicht", "verfügbar"],
        Fra = ["commande", "indisponible"]
    };

    /// <see href="https://xivapi.com/LogMessage/725?pretty=true">The command /… does not exist.</see>
    public static readonly LocalizedStrings CommandDoesNotExist = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["command", "does", "not", "exist"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };

    /// <see href="https://xivapi.com/LogMessage/458?pretty=true">That command doesn't exist.</see>
    public static readonly LocalizedStrings CommandDoesntExist = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["command", "doesn't", "exist"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings PartyLeaderDutyRegister = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["party", "leader", "register", "duty"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings UnableToExecuteWhileCasting = new()
    {
        Jpn = ["キャスト中"],
        Eng = ["unable", "execute", "command", "casting"],
        Deu = ["aktion", "aus"],
        Fra = ["impossible", "exécuter", "commande", "lancer"]
    };


    public static readonly LocalizedStrings UnableToExecuteWhileMounted = new()
    {
        Jpn = ["騎乗中"],
        Eng = ["unable", "execute", "command", "mounted"],
        Deu = ["reitens", "ausgeführt"],
        Fra = ["impossible", "exécuter", "commande", "monture"]
    };


    public static readonly LocalizedStrings UnableToConvertPartySave = new()
    {
        Jpn = ["マッチングパーティ", "コンバート"],
        Eng = ["unable", "convert", "matched", "party", "save"],
        Deu = ["speicherdaten", "konvertieren"],
        Fra = ["impossible", "convertir", "sauvegarde", "groupement"]
    };


    public static readonly LocalizedStrings InvalidTarget = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["invalid", "target"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings CannotUseAsClass = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["cannot", "use", "current", "class"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings UnableToUseItem = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["unable", "use", "currently", "using", "another", "item"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings UnableToObtain = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["unable", "obtain"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings UnableToObtainAlreadyPossess = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["unable", "obtain", "already", "possess"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings UnableToUseUniqueItem = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["unable", "use", "cannot", "carry", "more", "than", "one"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings NotYetReady = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["not", "yet", "ready"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings TargetOutOfRange = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["target", "out", "range"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings CannotSeeTarget = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["cannot", "see", "target"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings TargetNotInRange = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["target", "not", "range"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings TooFarAway = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["too", "far", "away"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings ActionCanceledUnderAttack = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["action", "canceled", "under", "attack"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings TargetNotInLineOfSight = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["target", "not", "line", "sight"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings UnableToApplyGlamourPlates = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["unable", "apply", "glamour", "plates"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings FateLevelTooHighToAttack = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["unable", "attack", "fate", "target", "level", "high"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings FriendRequestSent = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["friend", "request"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings FriendRequestReceived = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["sent", "you", "friend", "request"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings FriendAddedToList = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["friend", "list"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings FriendListUpdated = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["list", "updated"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings FateDiscovered = new()
    {
        Jpn = ["NeedsLocalization"],
        Eng = ["fate", "discovered", "nearby"],
        Deu = ["NeedsLocalization"],
        Fra = ["NeedsLocalization"]
    };


    public static readonly LocalizedStrings ActiveHelpEntryAdded = new()
    {
        Jpn = ["howto"],
        Eng = ["active", "help", "entry", "added"],
        Deu = ["tutorial-hilfstext"],
        Fra = ["tutoriel"]
    };
}
