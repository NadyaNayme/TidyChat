using NUnit.Framework;

namespace TidyChat.Tests;

[TestFixture]
public class RuleOrderTests
{
    [Test]
    public void AllRules_count_matches_snapshot()
    {
        Assert.That(Rules.AllRules.Length, Is.EqualTo(RuleOrderSnapshot.ExpectedRuleCount));
    }

    [Test]
    public void AllRules_order_hash_matches_snapshot()
    {
        var hash = RuleOrderFingerprint.ComputeOrderHash(Rules.AllRules);
        Assert.That(hash, Is.EqualTo(RuleOrderSnapshot.ExpectedOrderHash));
    }

    [Test, Explicit("Run locally to refresh RuleOrderSnapshot constants after intentional reorder.")]
    public void Print_rule_order_snapshot()
    {
        var rules = Rules.AllRules;
        var hash = RuleOrderFingerprint.ComputeOrderHash(rules);
        Assert.Inconclusive($"ExpectedRuleCount = {rules.Length}; ExpectedOrderHash = \"{hash}\"");
    }
}
