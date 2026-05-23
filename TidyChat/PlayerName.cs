using System;
using System.Text.RegularExpressions;

namespace TidyChat;

#pragma warning disable MA0048
public enum PlayerNameMatchMode
{
    /// <summary>
    ///     Backward-compatible default. Matches when sender == FirstName OR when message contains FirstName as a substring.
    /// </summary>
    MessageContains = 0,

    /// <summary>
    ///     Strict. Matches only when sender.TextValue == FirstName.
    /// </summary>
    ExactSender = 1
}

public class PlayerName
{
    public bool AllowMessage = true;
    public string FirstName = string.Empty;
    public int WhitelistedChannels = 2;

    /// <summary>
    ///     Selects how non-regex entries are compared. Defaults to MessageContains for backward compatibility
    ///     with configs created before this field existed.
    /// </summary>
    public PlayerNameMatchMode MatchMode = PlayerNameMatchMode.MessageContains;

    [NonSerialized] private Regex? _compiledPattern;
    [NonSerialized] private string? _compiledPatternSource;
    [NonSerialized] private uint[]? _parsedLogMessageIds;
    [NonSerialized] private string? _parsedLogMessageIdSource;

    /// <summary>True if <see cref="FirstName"/> is in the <c>/pattern/</c> regex form.</summary>
    public bool IsRegex => IsRegexShape(FirstName);

    /// <summary>True if <see cref="FirstName"/> is in the <c>#ID</c> or <c>#ID1,ID2</c> LogMessageId form.</summary>
    public bool IsLogMessageId => IsLogMessageIdShape(FirstName);

    /// <summary>
    ///     Returns the cached compiled <see cref="Regex"/> for this entry when <see cref="FirstName"/> is a
    ///     <c>/pattern/</c> form. Recompiles only when the source text changes. Returns <c>null</c> if the
    ///     pattern is invalid; <paramref name="onError"/> is invoked once per recompile failure.
    /// </summary>
    public Regex? GetCompiledRegex(Action<string, Exception>? onError = null)
    {
        if (string.IsNullOrEmpty(FirstName) || !IsRegexShape(FirstName)) return null;

        if (string.Equals(_compiledPatternSource, FirstName, StringComparison.Ordinal))
            return _compiledPattern;

        _compiledPatternSource = FirstName;
        try
        {
            _compiledPattern = new Regex(
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

    /// <summary>
    ///     Returns the parsed LogMessageIds for this entry when <see cref="FirstName"/> is a
    ///     <c>#ID</c> or <c>#ID1,ID2,ID3</c> form. Returns an empty array if parsing fails.
    /// </summary>
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
                _parsedLogMessageIds[j] = uint.Parse(parts[j], System.Globalization.CultureInfo.InvariantCulture);
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
