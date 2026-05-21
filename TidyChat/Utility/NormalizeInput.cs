using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Dalamud.Game.Text.SeStringHandling;
using Lumina.Text.ReadOnly;

namespace TidyChat.Utility;

internal static class NormalizeInput
{
    private const RegexOptions DefaultRegexOptions =
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

    private static readonly TimeSpan RegexTimeout = TimeSpan.FromSeconds(1);

    // Cached compiled regexes for the player's initialled-name variants.
    // Rebuilt only when the source player name changes.
    private static string? _cachedPlayerName;
    private static Regex? _firstNameLastInitial;
    private static Regex? _firstInitialLastName;
    private static Regex? _initialsOnly;
    private static string _firstNameLastInitialLower = string.Empty;
    private static string _firstInitialLastNameLower = string.Empty;
    private static string _initialsOnlyLower = string.Empty;

    // Make everything lowercase so I don't have to think about which words are capitalized in the message.
    // Uses Lumina's ReadOnlySeString.ExtractText() rather than SeString.TextValue so that text embedded
    // inside link/expression payloads (e.g. channel-link payloads that encode "Novice Network" as a
    // string-argument expression rather than a raw TextPayload) is also included in the result.
    // Falls back to TextValue if encoding/extraction throws for any reason.
    public static string ToLowercase(SeString message)
    {
        try
        {
            return new ReadOnlySeString(message.Encode()).ExtractText()
                .ToLower(CultureInfo.CurrentCulture);
        }
        catch
        {
            return message.TextValue.ToLower(CultureInfo.CurrentCulture);
        }
    }

    /*
     * IMPORTANT:
     * Initialed name settings & JP localization depends on the
     * player's name being replaced by "you", as there is no other way
     * to distinguish messages about the player. So we replace the player's name or initials
     * with "you" before filtering the message.
     *
     */
    public static string ReplaceName(string normalizedInput, Configuration configuration)
    {
        string playerName = configuration.PlayerName;
        if (string.IsNullOrWhiteSpace(playerName)) return normalizedInput;

        // Player name must have a first AND last name. Single-word characters (test chars / NPCs / pre-login
        // race conditions) would crash the old Split(' ')[1] code. Bail out gracefully instead.
        string[] parts = playerName.Split(' ');
        if (parts.Length < 2 || parts[0].Length == 0 || parts[1].Length == 0)
        {
            // Best-effort: still replace the literal full name if it appears in the message.
            return normalizedInput.Replace(playerName, "you", StringComparison.Ordinal);
        }

        EnsureCacheFor(playerName, parts);

        // Replace literal full name first (fast path, no regex).
        normalizedInput = normalizedInput.Replace(playerName, "you", StringComparison.Ordinal);

        // Then the three initialled variants, using cached regexes.
        if (_firstNameLastInitial is not null && normalizedInput.Contains(_firstNameLastInitialLower, StringComparison.Ordinal))
            normalizedInput = SafeReplace(_firstNameLastInitial, normalizedInput);
        if (_firstInitialLastName is not null && normalizedInput.Contains(_firstInitialLastNameLower, StringComparison.Ordinal))
            normalizedInput = SafeReplace(_firstInitialLastName, normalizedInput);
        if (_initialsOnly is not null && normalizedInput.Contains(_initialsOnlyLower, StringComparison.Ordinal))
            normalizedInput = SafeReplace(_initialsOnly, normalizedInput);

        return normalizedInput;
    }

    /// <summary>
    ///     Rebuilds the cached initialled-name regexes if the player name has changed since the last call.
    ///     Special characters in the name are <see cref="Regex.Escape"/>'d so dots in "Mat M." don't match
    ///     "MatMx" the way the old un-escaped pattern did.
    /// </summary>
    private static void EnsureCacheFor(string playerName, string[] parts)
    {
        if (string.Equals(_cachedPlayerName, playerName, StringComparison.Ordinal)) return;

        string firstName = parts[0];
        string lastName = parts[1];
        char firstInitial = firstName[0];
        char lastInitial = lastName[0];

        _firstNameLastInitialLower = $"{firstName} {lastInitial}.".ToLower(CultureInfo.CurrentCulture);
        _firstInitialLastNameLower = $"{firstInitial}. {lastName}".ToLower(CultureInfo.CurrentCulture);
        _initialsOnlyLower         = $"{firstInitial}. {lastInitial}.".ToLower(CultureInfo.CurrentCulture);

        _firstNameLastInitial = BuildSafeRegex(_firstNameLastInitialLower);
        _firstInitialLastName = BuildSafeRegex(_firstInitialLastNameLower);
        _initialsOnly         = BuildSafeRegex(_initialsOnlyLower);

        _cachedPlayerName = playerName;
    }

    private static Regex? BuildSafeRegex(string lowerToken)
    {
        try
        {
            return new Regex(@"(^|\s)" + Regex.Escape(lowerToken) + @"(\s|$)",
                DefaultRegexOptions, RegexTimeout);
        }
        catch
        {
            return null;
        }
    }

    private static string SafeReplace(Regex regex, string input)
    {
        try
        {
            // Matches the original whitespace-consuming replacement so downstream rules see the
            // exact same normalized text shape they always have.
            return regex.Replace(input, "you", 1);
        }
        catch(RegexMatchTimeoutException)
        {
            return input;
        }
    }
}
