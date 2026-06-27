namespace TidyChat.Tests;

internal static class RuleOrderSnapshot
{
    /// <summary>Update when rule evaluation order intentionally changes.</summary>
    public const int ExpectedRuleCount = 355;

    /// <summary>SHA-256 hex of newline-joined <see cref="RuleOrderFingerprint.Format" /> lines.</summary>
    public const string ExpectedOrderHash = "1FF3C69BC3F581787E8FFACE40032066B2BA7DE456F69434C90EF93183B11F4A";
}
