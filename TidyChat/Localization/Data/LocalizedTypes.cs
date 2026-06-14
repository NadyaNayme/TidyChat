using System.Collections;
using System.Text.RegularExpressions;
namespace TidyChat.Localization.Data;

public readonly record struct LocalizedStrings
{
    public string[] Jpn { get; init; }

    public string[] Eng { get; init; }
    public string[] Deu { get; init; }
    public string[] Fra { get; init; }
}

public readonly record struct LocalizedTidyStrings
{
    public string Jpn { get; init; }

    public string Eng { get; init; }
    public string Deu { get; init; }
    public string Fra { get; init; }
}

public readonly record struct LocalizedRegex : IEnumerable<Regex>
{
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

    readonly IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
