using System.Text.RegularExpressions;
namespace TidyChat.Settings;

public enum PlayerNameMatchMode
{
    MessageContains = 0,

    ExactSender = 1
}

public class PlayerName
{

    [NonSerialized] private Regex? _compiledPattern;
    [NonSerialized] private string? _compiledPatternSource;
    [NonSerialized] private uint[]? _parsedLogMessageIds;
    [NonSerialized] private string? _parsedLogMessageIdSource;
    public bool AllowMessage = true;
    public string FirstName = string.Empty;

    public PlayerNameMatchMode MatchMode = PlayerNameMatchMode.MessageContains;
    public int WhitelistedChannels = 1 << 3; // System — most custom filters target system lines

    public bool IsRegex => IsRegexShape(FirstName);

    public bool IsLogMessageId => IsLogMessageIdShape(FirstName);

    /// <summary>
    ///     Allow-list player name rows used by the global "show messages by/from whitelisted player" toggles.
    ///     Custom text/regex/#ID filters are excluded.
    /// </summary>
    public bool IsGlobalWhitelistPlayerEntry =>
        AllowMessage &&
        MatchMode == PlayerNameMatchMode.ExactSender &&
        !IsRegex &&
        !IsLogMessageId &&
        !string.IsNullOrWhiteSpace(FirstName);

    public Regex? GetCompiledRegex(Action<string, Exception>? onError = null)
    {
        if (string.IsNullOrEmpty(FirstName) || !IsRegexShape(FirstName))
        {
            return null;
        }

        if (string.Equals(_compiledPatternSource, FirstName, StringComparison.Ordinal))
        {
            return _compiledPattern;
        }

        _compiledPatternSource = FirstName;
        try
        {
            _compiledPattern = new(
                FirstName[1..^1],
                RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture,
                TimeSpan.FromSeconds(1));
        }
        catch (Exception ex)
        {
            _compiledPattern = null;
            onError?.Invoke(FirstName, ex);
        }
        return _compiledPattern;
    }

    public uint[] GetLogMessageIds()
    {
        if (string.IsNullOrEmpty(FirstName) || !IsLogMessageIdShape(FirstName))
        {
            return [];
        }

        if (string.Equals(_parsedLogMessageIdSource, FirstName, StringComparison.Ordinal))
        {
            return _parsedLogMessageIds ?? [];
        }

        _parsedLogMessageIdSource = FirstName;
        try
        {
            var parts = FirstName[1..].Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            _parsedLogMessageIds = new uint[parts.Length];
            for (var j = 0; j < parts.Length; j++)
            {
                _parsedLogMessageIds[j] = uint.Parse(parts[j], CultureInfo.InvariantCulture);
            }
        }
        catch
        {
            _parsedLogMessageIds = [];
        }
        return _parsedLogMessageIds ?? [];
    }

    private static bool IsRegexShape(string s)
        => s.Length >= 2 && s.StartsWith('/') && s.EndsWith('/');

    private static bool IsLogMessageIdShape(string s)
        => s.Length >= 2 && s[0] == '#' && char.IsAsciiDigit(s[1]);
}
