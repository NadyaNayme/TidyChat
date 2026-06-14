using TidyChat.Localization.Data;
namespace TidyChat.Utility;

internal static class InternalStrings
{
    public const string SettingsCommand = "/tidychat";

    public const string ShorthandCommand = "/tidy";

    public static readonly string PluginName = "Tidy Chat";

    public static readonly string SettingsHelper = "Open settings";

    public static readonly string ShorthandHelper = "Shorthand command to open settings";

    public static readonly string Tag = "[TidyChat] ";

    public static readonly LocalizedTidyStrings InstanceText = new()
    {
        Jpn = new("インスタンスエリア"),
        Eng = new("You are now in instance:"),
        Deu = new("Du bist jetzt in Instanz:"),
        Fra = new("La zone instanciée:")
    };

    public static readonly LocalizedTidyStrings InstanceWord = new()
    {
        Jpn = new("インスタンスエリア"),
        Eng = new("Instance"),
        Deu = new("Instanz"),
        Fra = new("Instanciée")
    };

    public static readonly LocalizedTidyStrings CopiedToClipboard = new()
    {
        Jpn = new("クリップボードにコピーされました"),
        Eng = new("has been copied to clipboard"),
        Deu = new("wurde in die Zwischenablage kopiert"),
        Fra = new("a été copié")
    };

    public static readonly LocalizedTidyStrings PvPDuty = new()
    {
        Jpn = new("NeedsLocalization"),
        Eng = new("a PvP duty"),
        Deu = new("aus einer PVP"),
        Fra = new("une mission JcJ")
    };

    public static readonly LocalizedTidyStrings StartQuotation = new()
    {
        Jpn = new("『"),
        Eng = new("“"),
        Deu = new("„"),
        Fra = new("“")
    };

    public static readonly LocalizedTidyStrings EndQuotation = new()
    {
        Jpn = new("』"),
        Eng = new("”"),
        Deu = new("“"),
        Fra = new("”")
    };

    public static readonly LocalizedTidyStrings KickedOutMessage = new()
    {
        Jpn = new("第{0}区画で追い出された。"),
        Eng = new("Kicked out on {0} floor."),
        Deu = new("Bei der {0}. Kammer rausgeworfen."),
        Fra = new("Expulsé à la {0} salle.")
    };

    public static readonly LocalizedTidyStrings DutyHasBegunFormat = new()
    {
        Jpn = new("{0}が開始されました。"),
        Eng = new("{0} has begun."),
        Deu = new("{0} hat begonnen."),
        Fra = new("{0} a commencé.")
    };

    public static readonly LocalizedTidyStrings MarkBillObtainFormat = new()
    {
        Jpn = new("{0}を受注しました。"),
        Eng = new("You obtained {0}."),
        Deu = new("Du hast {0} angenommen."),
        Fra = new("Vous avez obtenu {0}.")
    };

    public static string LastDuty { get; set; } = "";
    public static short CommendationsEarned { get; set; } = 0;
    public static short LastCommendations { get; set; } = 0;
}
