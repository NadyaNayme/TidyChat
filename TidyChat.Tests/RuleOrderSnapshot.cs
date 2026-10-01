using System.Security.Cryptography;
using System.Text;
namespace TidyChat.Tests;

internal static class RuleOrderSnapshot
{
    // update both when rule evaluation order intentionally changes
    public const int ExpectedRuleCount = 396;

    public const string ExpectedOrderHash = "7C6975A046D820BFC4EEFB72FA511AACE7D90293995BFA8FF5ED3E2613CAAEBC";

    public static string ComputeOrderHash(IReadOnlyList<LocalizedFilterRule> rules)
    {
        var text = string.Join('\n', rules.Select(Format));
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(text)));
    }

    private static string Format(LocalizedFilterRule rule)
    {
        var id = rule.LogMessageIds is { Length: > 0 } ids ? ids[0] : 0u;
        return $"{rule.Name}|{rule.SettingsTab}|{(int)rule.Channel}|{id}|{rule.BlockWhenActive}|{(int)rule.Pattern}";
    }
}
