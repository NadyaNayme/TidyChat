namespace TidyChat.Utility
{
	internal static class InternalStrings
	{
		public const string Version = "0.1.0.10";

		public const string PluginName = "Tidy Chat";

		public const string SettingsCommand = "/tidychat";

		public const string SettingsHelper = "Open settings";

		public const string ShorthandHelper = "Shorthand command to open settings";

		public const string ShorthandCommand = "/tidy";

		// The space at the end is intentional
		public const string Tag = "[TidyChat] ";
		public const string DebugTag = "[Debug] ";

		public static LocalizedTidyStrings InstanceText { get; } = new ()
		{
			Jpn = new string("インスタンスエリア"),
			Eng = new string("You are now in instance:"),
			Deu = new string("Du bist nun in dem instanziierten:"),
			Fra = new string("La zone instanciée:"),
		};

		public static LocalizedTidyStrings CopiedToClipboard { get; } = new()
		{
			Jpn = new string("クリップボードにコピーされました"),
			Eng = new string("has been copied to clipboard"),
			Deu = new string("wurde in die Zwischenablage kopiert"),
			Fra = new string("a été copié")
		};

		public static LocalizedTidyStrings Guildhest { get; } = new()
		{
			Jpn = new string("ギルドヘストから入手"),
			Eng = new string("a Guildhest"),
			Deu = new string("ein Gildengeheiß"),
			Fra = new string("une opération de guilde"),
		};

		public static LocalizedTidyStrings PvPDuty { get; } = new()
		{
			Jpn = new string("NeedsLocalization"),
			Eng = new string("a PvP duty"),
			Deu = new string("aus einer PVP"),
			Fra = new string("une mission JcJ"),
		};

		/// <see href="https://xivapi.com/LogMessage/1534?pretty=true">Palace of the Dead</see>
		public static LocalizedTidyStrings POTD { get; } = new()
		{
			Jpn = new string("NeedsLocalization"),
			Eng = new string("Palace of the Dead"),
			Deu = new string("Palast der Toten"),
			Fra = new string("Palais des morts"),
		};

		/// <see href="https://xivapi.com/LogMessage/2775?pretty=true">Heaven-on-High</see>
		public static LocalizedTidyStrings HOH { get; } = new()
		{
			Jpn = new string("NeedsLocalization"),
			Eng = new string("Heaven-on-High"),
			Deu = new string("Himmelssäule"),
			Fra = new string("Pilier des Cieux"),
		};

		public static string LastDuty { get; set; } = "";

		public static int NumberOfCommendations { get; set; } = 0;
	}
}
