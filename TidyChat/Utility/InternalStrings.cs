using System.Reflection;

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
        Jpn = new string("インスタンスエリア"),
        Eng = new string("You are now in instance:"),
        Deu = new string("Du bist jetzt in Instanz:"),
        Fra = new string("La zone instanciée:")
    };

    public static readonly LocalizedTidyStrings InstanceWord = new()
    {
        Jpn = new string("インスタンスエリア"),
        Eng = new string("Instance"),
        Deu = new string("Instanz"),
        Fra = new string("Instanciée")
    };

    public static readonly LocalizedTidyStrings CopiedToClipboard = new()
    {
        Jpn = new string("クリップボードにコピーされました"),
        Eng = new string("has been copied to clipboard"),
        Deu = new string("wurde in die Zwischenablage kopiert"),
        Fra = new string("a été copié")
    };

    public static readonly LocalizedTidyStrings Guildhest = new()
    {
        Jpn = new string("ギルドヘストから入手"),
        Eng = new string("a Guildhest"),
        Deu = new string("ein Gildengeheiß"),
        Fra = new string("une opération de guilde")
    };

    public static readonly LocalizedTidyStrings PvPDuty = new()
    {
        Jpn = new string("NeedsLocalization"),
        Eng = new string("a PvP duty"),
        Deu = new string("aus einer PVP"),
        Fra = new string("une mission JcJ")
    };

    /// <see href="https://xivapi.com/LogMessage/1534?pretty=true">Palace of the Dead</see>
    public static readonly LocalizedTidyStrings POTD = new()
    {
        Jpn = new string("NeedsLocalization"),
        Eng = new string("Palace of the Dead"),
        Deu = new string("Palast der Toten"),
        Fra = new string("Palais des morts")
    };

    /// <see href="https://xivapi.com/LogMessage/2775?pretty=true">Heaven-on-High</see>
    public static readonly LocalizedTidyStrings HOH = new()
    {
        Jpn = new string("NeedsLocalization"),
        Eng = new string("Heaven-on-High"),
        Deu = new string("Himmelssäule"),
        Fra = new string("Pilier des Cieux")
    };

    public static readonly LocalizedTidyStrings StartQuotation = new()
    {
        Jpn = new string("『"),
        Eng = new string("“"),
        Deu = new string("„"),
        Fra = new string("“")
    };

    public static readonly LocalizedTidyStrings EndQuotation = new()
    {
        Jpn = new string("』"),
        Eng = new string("”"),
        Deu = new string("“"),
        Fra = new string("”")
    };

    public static readonly string FirstInstance = "";
    public static readonly string SecondInstance = "";
    public static readonly string ThirdInstance = "";

    public static string LastDuty { get; set; } = "";
    public static short CommendationsEarned { get; set; } = 0;
    public static short LastCommendations { get; set; } = 0;
}