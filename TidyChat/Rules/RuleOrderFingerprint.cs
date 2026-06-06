using System.Security.Cryptography;
using System.Text;
namespace TidyChat;

public static class RuleOrderFingerprint
{
    public static string Format(LocalizedFilterRule rule)
    {
        var id = rule.LogMessageIds is { Length: > 0 } ids ? ids[0] : 0u;
        return $"{rule.Name}|{rule.SettingsTab}|{(int)rule.Channel}|{id}|{rule.BlockWhenActive}|{(int)rule.Pattern}";
    }

    public static string ComputeOrderHash(IReadOnlyList<LocalizedFilterRule> rules)
    {
        var text = string.Join('\n', rules.Select(Format));
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(text)));
    }
}
