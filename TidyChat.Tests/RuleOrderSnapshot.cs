namespace TidyChat.Tests;

internal static class RuleOrderSnapshot
{
    /// <summary>Update when rule evaluation order intentionally changes.</summary>
    public const int ExpectedRuleCount = 429;

    /// <summary>SHA-256 hex of newline-joined <see cref="RuleOrderFingerprint.Format"/> lines.</summary>
    public const string ExpectedOrderHash = "97D1FFDDAED7AF7B605DB732380AF43EDBF6BED61D32F90992F7DF4516FB80DC";
}
