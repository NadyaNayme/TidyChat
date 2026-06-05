using Lumina.Text.ReadOnly;
using System.Text.RegularExpressions;
namespace TidyChat.Utility;

internal static class NormalizeInput
{
    private const RegexOptions DefaultRegexOptions =
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

    private static readonly TimeSpan RegexTimeout = TimeSpan.FromSeconds(1);

    private static string? _cachedPlayerName;
    private static Regex? _firstNameLastInitial;
    private static Regex? _firstInitialLastName;
    private static Regex? _initialsOnly;
    private static string _firstNameLastInitialLower = string.Empty;
    private static string _firstInitialLastNameLower = string.Empty;
    private static string _initialsOnlyLower = string.Empty;

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
        var playerName = configuration.PlayerName;
        if (string.IsNullOrWhiteSpace(playerName))
        {
            return normalizedInput;
        }

        var parts = playerName.Split(' ');
        if (parts.Length < 2 || parts[0].Length == 0 || parts[1].Length == 0)
        {
            return normalizedInput.Replace(playerName, "you", StringComparison.Ordinal);
        }

        EnsureCacheFor(playerName, parts);

        normalizedInput = normalizedInput.Replace(playerName, "you", StringComparison.Ordinal);

        if (_firstNameLastInitial is not null && normalizedInput.Contains(_firstNameLastInitialLower, StringComparison.Ordinal))
        {
            normalizedInput = SafeReplace(_firstNameLastInitial, normalizedInput);
        }
        if (_firstInitialLastName is not null && normalizedInput.Contains(_firstInitialLastNameLower, StringComparison.Ordinal))
        {
            normalizedInput = SafeReplace(_firstInitialLastName, normalizedInput);
        }
        if (_initialsOnly is not null && normalizedInput.Contains(_initialsOnlyLower, StringComparison.Ordinal))
        {
            normalizedInput = SafeReplace(_initialsOnly, normalizedInput);
        }

        return normalizedInput;
    }

    private static void EnsureCacheFor(string playerName, string[] parts)
    {
        if (string.Equals(_cachedPlayerName, playerName, StringComparison.Ordinal))
        {
            return;
        }

        var firstName = parts[0];
        var lastName = parts[1];
        var firstInitial = firstName[0];
        var lastInitial = lastName[0];

        _firstNameLastInitialLower = $"{firstName} {lastInitial}.".ToLower(CultureInfo.CurrentCulture);
        _firstInitialLastNameLower = $"{firstInitial}. {lastName}".ToLower(CultureInfo.CurrentCulture);
        _initialsOnlyLower = $"{firstInitial}. {lastInitial}.".ToLower(CultureInfo.CurrentCulture);

        _firstNameLastInitial = BuildSafeRegex(_firstNameLastInitialLower);
        _firstInitialLastName = BuildSafeRegex(_firstInitialLastNameLower);
        _initialsOnly = BuildSafeRegex(_initialsOnlyLower);

        _cachedPlayerName = playerName;
    }

    private static Regex? BuildSafeRegex(string lowerToken)
    {
        try
        {
            return new(@"(^|\s)" + Regex.Escape(lowerToken) + @"(\s|$)",
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
            return regex.Replace(input, "you", 1);
        }
        catch (RegexMatchTimeoutException)
        {
            return input;
        }
    }
}
