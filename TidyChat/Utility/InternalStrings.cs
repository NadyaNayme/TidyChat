namespace TidyChat.Utility
{
    internal static class InternalStrings
    {
        public const string Version = "0.1.0.8";

		public const string PluginName = "Tidy Chat";

		public const string SettingsCommand = "/tidychat";

		public const string SettingsHelper = "Open settings";

		public const string ShorthandHelper = "Shorthand command to open settings" ;

		public const string ShorthandCommand = "/tidy";

		// The space at the end is intentional
		public const string Tag = "[TidyChat] ";

		public const string InstanceText = "You are now in instance:";

		public const string CopiedToClipboard = "has been copied to clipboard";

		public const string Guildhest = "a Guildhest";

		public const string PvPDuty = "a PvP duty";

		public const string POTD = "Palace of the Dead";

		public const string HOH = "Heaven-on-High";
		public static string LastDuty { get; set; } = "";
		public static int NumberOfCommendations { get; set; } = 0;
	}
}
