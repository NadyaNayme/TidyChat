namespace TidyChat.Tests;

internal static class RuleOrderSnapshot
{
    /// <summary>Update when rule evaluation order intentionally changes.</summary>
    public const int ExpectedRuleCount = 340;

    /// <summary>SHA-256 hex of newline-joined <see cref="RuleOrderFingerprint.Format"/> lines.</summary>
    public const string ExpectedOrderHash = "11C3AB404EDC582C7F6163A010BD4B2930AC93B1F743F12474C4161A0378FDC4";
}
