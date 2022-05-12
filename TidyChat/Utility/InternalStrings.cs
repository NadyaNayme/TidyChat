namespace TidyChat.Utility
{
    internal static class InternalStrings
    {
        public readonly static string Version = "0.1.1.20";

        public readonly static string PluginName = "Tidy Chat";

        public const string SettingsCommand = "/tidychat";

        public readonly static string SettingsHelper = "Open settings";

        public readonly static string ShorthandHelper = "Shorthand command to open settings";

        public const string ShorthandCommand = "/tidy";

        // The space at the end is intentional
        public readonly static string Tag = "[TidyChat] ";
        public readonly static string DebugTag = "[Debug] ";

        public readonly static LocalizedTidyStrings InstanceText = new()
        {
            Jpn = new string("インスタンスエリア"),
            Eng = new string("You are now in instance:"),
            Deu = new string("Du bist nun in dem instanziierten:"),
            Fra = new string("La zone instanciée:"),
        };

        public readonly static LocalizedTidyStrings InstanceWord = new()
        {
            Jpn = new string("インスタンスエリア"),
            Eng = new string("Instance"),
            Deu = new string("Instanziierten"),
            Fra = new string("Instanciée"),
        };

        public readonly static LocalizedTidyStrings CopiedToClipboard = new()
        {
            Jpn = new string("クリップボードにコピーされました"),
            Eng = new string("has been copied to clipboard"),
            Deu = new string("wurde in die Zwischenablage kopiert"),
            Fra = new string("a été copié")
        };

        public readonly static LocalizedTidyStrings Guildhest = new()
        {
            Jpn = new string("ギルドヘストから入手"),
            Eng = new string("a Guildhest"),
            Deu = new string("ein Gildengeheiß"),
            Fra = new string("une opération de guilde"),
        };

        public readonly static LocalizedTidyStrings PvPDuty = new()
        {
            Jpn = new string("NeedsLocalization"),
            Eng = new string("a PvP duty"),
            Deu = new string("aus einer PVP"),
            Fra = new string("une mission JcJ"),
        };

        /// <see href="https://xivapi.com/LogMessage/1534?pretty=true">Palace of the Dead</see>
        public readonly static LocalizedTidyStrings POTD = new()
        {
            Jpn = new string("NeedsLocalization"),
            Eng = new string("Palace of the Dead"),
            Deu = new string("Palast der Toten"),
            Fra = new string("Palais des morts"),
        };

        /// <see href="https://xivapi.com/LogMessage/2775?pretty=true">Heaven-on-High</see>
        public readonly static LocalizedTidyStrings HOH = new()
        {
            Jpn = new string("NeedsLocalization"),
            Eng = new string("Heaven-on-High"),
            Deu = new string("Himmelssäule"),
            Fra = new string("Pilier des Cieux"),
        };

        public static string LastDuty { get; set; } = "";

        public static int NumberOfCommendations { get; set; } = 0;
        public readonly static string FirstInstance = "";
        public readonly static string SecondInstance = "";
        public readonly static string ThirdInstance = "";
    }
}
