namespace TidyChat.Tests;

internal static class RuleOrderSnapshot
{
    /// <summary>Update when rule evaluation order intentionally changes.</summary>
    public const int ExpectedRuleCount = 429;

    /// <summary>SHA-256 hex of newline-joined <see cref="RuleOrderFingerprint.Format"/> lines.</summary>
    public const string ExpectedOrderHash = "A7E3E30FD70169D12D8477C85A064F659A0F181580D3B843377ED37C82E36371";
}
