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
    public int whitelistedChannels = 2;

    /// <summary>
    ///     Selects how non-regex entries are compared. Defaults to MessageContains for backward compatibility
    ///     with configs created before this field existed.
    /// </summary>
    public PlayerNameMatchMode MatchMode = PlayerNameMatchMode.MessageContains;

    [NonSerialized] private Regex? _compiledPattern;
    [NonSerialized] private string? _compiledPatternSource;

    /// <summary>True if <see cref="FirstName"/> is in the <c>/pattern/</c> regex form.</summary>
    public bool IsRegex => IsRegexShape(FirstName);

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

    private static bool IsRegexShape(string s)
        => s.Length >= 2 && s.StartsWith('/') && s.EndsWith('/');
}
