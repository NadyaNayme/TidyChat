namespace TidyChat.Tests;

internal static class RuleOrderSnapshot
{
    /// <summary>Update when rule evaluation order intentionally changes.</summary>
    public const int ExpectedRuleCount = 339;

    /// <summary>SHA-256 hex of newline-joined <see cref="RuleOrderFingerprint.Format"/> lines.</summary>
    public const string ExpectedOrderHash = "C71FC857D626AD379588DA9E95BA4BF983C937F5AB84FEF83622F5C4B4E10908";
}
