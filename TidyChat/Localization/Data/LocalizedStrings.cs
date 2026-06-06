namespace TidyChat.Localization.Data;

public readonly record struct LocalizedStrings
{
    public string[] Jpn { get; init; }

    public string[] Eng { get; init; }
    public string[] Deu { get; init; }
    public string[] Fra { get; init; }
}
