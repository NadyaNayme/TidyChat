using System.Reflection;
using TidyChat.Translation.Data;
namespace TidyChat.Utility;

internal static class InternalStrings
{
    public const string SettingsCommand = "/tidychat";

    public const string ShorthandCommand = "/tidy";
    public static readonly string Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Unknown";

    public static readonly string PluginName = "Tidy Chat";

    public static readonly string SettingsHelper = "Open settings";

    public static readonly string ShorthandHelper = "Shorthand command to open settings";

    // The space at the end is intentional
    public static readonly string Tag = "[TidyChat] ";
    public static readonly string DebugTag = "[Debug] ";

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

    public static readonly LocalizedTidyStrings Guildhest = new()
    {
        Jpn = new("ギルドヘストから入手"),
        Eng = new("a Guildhest"),
        Deu = new("ein Gildengeheiß"),
        Fra = new("une opération de guilde")
    };

    public static readonly LocalizedTidyStrings PvPDuty = new()
    {
        Jpn = new("NeedsLocalization"),
        Eng = new("a PvP duty"),
        Deu = new("aus einer PVP"),
        Fra = new("une mission JcJ")
    };

    /// <see href="https://xivapi.com/LogMessage/1534?pretty=true">Palace of the Dead</see>
    public static readonly LocalizedTidyStrings POTD = new()
    {
        Jpn = new("NeedsLocalization"),
        Eng = new("Palace of the Dead"),
        Deu = new("Palast der Toten"),
        Fra = new("Palais des morts")
    };

    /// <see href="https://xivapi.com/LogMessage/2775?pretty=true">Heaven-on-High</see>
    public static readonly LocalizedTidyStrings HOH = new()
    {
        Jpn = new("NeedsLocalization"),
        Eng = new("Heaven-on-High"),
        Deu = new("Himmelssäule"),
        Fra = new("Pilier des Cieux")
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

    public static string LastDuty { get; set; } = "";
    public static short CommendationsEarned { get; set; } = 0;
    public static short LastCommendations { get; set; } = 0;
    public static string LastTreasureDungeonChamber { get; set; } = "";
}
