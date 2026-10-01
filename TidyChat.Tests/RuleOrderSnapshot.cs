namespace TidyChat.Tests;

internal static class RuleOrderSnapshot
{
    /// <summary>Update when rule evaluation order intentionally changes.</summary>
    public const int ExpectedRuleCount = 396;

    /// <summary>SHA-256 hex of newline-joined <see cref="RuleOrderFingerprint.Format" /> lines.</summary>
    public const string ExpectedOrderHash = "06A9A7648AE2211B3571A46614F973FE03ECEC2D443C93514F6A91B4B02DF50A";
}
