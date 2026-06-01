using System;
using System.Globalization;
using System.Text.RegularExpressions;
namespace TidyChat.Settings;

#pragma warning disable MA0048
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
    public int WhitelistedChannels = 2;

    public bool IsRegex => IsRegexShape(FirstName);

    public bool IsLogMessageId => IsLogMessageIdShape(FirstName);

    public Regex? GetCompiledRegex(Action<string, Exception>? onError = null)
    {
        if (string.IsNullOrEmpty(FirstName) || !IsRegexShape(FirstName)) return null;

        if (string.Equals(_compiledPatternSource, FirstName, StringComparison.Ordinal))
            return _compiledPattern;

        _compiledPatternSource = FirstName;
        try
        {
            _compiledPattern = new(
                FirstName[1..^1],
                RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture,
                TimeSpan.FromSeconds(1));
        }
        catch(Exception ex)
        {
            _compiledPattern = null;
            onError?.Invoke(FirstName, ex);
        }
        return _compiledPattern;
    }

    public uint[] GetLogMessageIds()
    {
        if (string.IsNullOrEmpty(FirstName) || !IsLogMessageIdShape(FirstName)) return [];

        if (string.Equals(_parsedLogMessageIdSource, FirstName, StringComparison.Ordinal))
            return _parsedLogMessageIds ?? [];

        _parsedLogMessageIdSource = FirstName;
        try
        {
            string[] parts = FirstName[1..].Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            _parsedLogMessageIds = new uint[parts.Length];
            for (int j = 0; j < parts.Length; j++)
                _parsedLogMessageIds[j] = uint.Parse(parts[j], CultureInfo.InvariantCulture);
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
