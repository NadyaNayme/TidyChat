using ChatTwo.Code;
using NUnit.Framework;
using TidyChat.Data;
namespace TidyChat.Tests;

[TestFixture]
public class FateLevelSyncMatchingTests
{
    private static LocalizedFilterRule HideFateRule =>
        Rules.AllRules.First(r => r.Name == "HideFateLevelSync");

    [SetUp]
    public void SetUp() =>
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>
        {
            [2070] =
                "You are UNKNOWN or more levels above the recommended level for this FATE.\nTo join, use the level sync function located in the duty list.",
            [2166] = "Unable to attack FATE target. Your level is too high."
        }, logKind: (byte)ChatType.Error);

    [Test]
    public void Matches_five_or_more_levels_chat_line()
    {
        Assert.That(RuleMatcher.MatchesText(HideFateRule,
            "you are 5 or more levels above the recommended level for this fate.", false), Is.True);
    }

    [Test]
    public void Matches_six_or_more_levels_chat_line()
    {
        Assert.That(RuleMatcher.MatchesText(HideFateRule,
            "you are 6 or more levels above the recommended level for this fate.", false), Is.True);
    }

    [Test]
    public void Matches_duty_list_level_sync_half_line()
    {
        Assert.That(RuleMatcher.MatchesText(HideFateRule,
            "to join, use the level sync function located in the duty list.", false), Is.True);
    }

    [Test]
    public void Matches_unable_to_attack_fate_target()
    {
        Assert.That(RuleMatcher.MatchesText(HideFateRule,
            "unable to attack fate target. your level is too high.", false), Is.True);
    }

    [Test]
    public void Does_not_match_unrelated_error()
    {
        Assert.That(RuleMatcher.MatchesText(HideFateRule,
            "the command /foo does not exist.", false), Is.False);
    }
}
