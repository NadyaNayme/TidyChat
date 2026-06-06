namespace TidyChat.Tests;

internal static class RuleOrderSnapshot
{
    /// <summary>Update when rule evaluation order intentionally changes.</summary>
    public const int ExpectedRuleCount = 419;

    /// <summary>SHA-256 hex of newline-joined <see cref="RuleOrderFingerprint.Format"/> lines.</summary>
    public const string ExpectedOrderHash = "822B0C9C0E7B03AA4DC481354AD85840F46E35607CE313C088C1C8AE1BE5D50F";
}
