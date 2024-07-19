namespace TidyChat.Translation.Data
{
    public readonly record struct LocalizedTidyStrings
    {
        /// <remarks>
        ///     For use with Utility.InternalStrings and Utility.BetterStrings
        /// </remarks>
        public string Jpn { get; init; }

        public string Eng { get; init; }
        public string Deu { get; init; }
        public string Fra { get; init; }
    }
}
