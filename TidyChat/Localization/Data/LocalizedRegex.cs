using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TidyChat.Translation.Data
{
    public readonly record struct LocalizedRegex : IEnumerable<Regex>
    {
        /// <remarks>
        ///     The string to be matched is preprocessed and always replaces the local player name with "you"
        /// </remarks>
        public Regex Jpn { get; init; }

        public Regex Eng { get; init; }
        public Regex Deu { get; init; }
        public Regex Fra { get; init; }
        public readonly IEnumerator<Regex> GetEnumerator()
        {
            yield return Jpn;
            yield return Eng;
            yield return Deu;
            yield return Fra;
        }

        readonly IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
