namespace TidyChat.Translation.Data
{
    public readonly record struct LocalizedStrings
    {
        /// <remarks>
        ///     The string to be matched is preprocessed and always replaces the local player name with "you"
        /// </remarks>
        public string[] Jpn { get; init; }

        public string[] Eng { get; init; }
        public string[] Deu { get; init; }
        public string[] Fra { get; init; }
    }
}
