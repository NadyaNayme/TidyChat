namespace TidyChat.Tests;

internal static class RuleOrderSnapshot
{
    /// <summary>Update when rule evaluation order intentionally changes.</summary>
    public const int ExpectedRuleCount = 370;

    /// <summary>SHA-256 hex of newline-joined <see cref="RuleOrderFingerprint.Format" /> lines.</summary>
    public const string ExpectedOrderHash = "768636EAE45EAA7BC3F643AE2B8569E2D5C170A7510E160A12D9808A77F4FC96";
}
