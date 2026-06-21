namespace TidyChat.Tests;

internal static class RuleOrderSnapshot
{
    /// <summary>Update when rule evaluation order intentionally changes.</summary>
    public const int ExpectedRuleCount = 352;

    /// <summary>SHA-256 hex of newline-joined <see cref="RuleOrderFingerprint.Format" /> lines.</summary>
    public const string ExpectedOrderHash = "A1B8686E178A3A997091E24097ADFADE3CBF2A96142D799EA48867BD63DC93EC";
}
