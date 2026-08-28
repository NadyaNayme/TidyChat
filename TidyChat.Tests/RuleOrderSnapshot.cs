namespace TidyChat.Tests;

internal static class RuleOrderSnapshot
{
    /// <summary>Update when rule evaluation order intentionally changes.</summary>
    public const int ExpectedRuleCount = 389;

    /// <summary>SHA-256 hex of newline-joined <see cref="RuleOrderFingerprint.Format" /> lines.</summary>
    public const string ExpectedOrderHash = "FF5703D6D58F8D6A776CB9CC319AF37E0E7EBAD87FA26773943D23622772617E";
}
