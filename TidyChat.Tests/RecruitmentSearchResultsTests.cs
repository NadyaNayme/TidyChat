using ChatTwo.Code;
using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Utility;
namespace TidyChat.Tests;

[TestFixture]
public class RecruitmentSearchResultsTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [TestCase("of the 12 parties currently recruiting, all match your search conditions.")]
    [TestCase("of the 12 parties currently recruiting, 3 match your search conditions.")]
    [TestCase("the only party currently recruiting does not match your search conditions.")]
    public void Recruitment_rule_matches_every_log_message_94_variant(string text)
    {
        var rule = Rules.AllRules.Single(r =>
            r.Channel == ChatType.PeriodicRecruitmentNotification);

        Assert.That(rule.Name, Is.EqualTo("ShowRecruitmentSearchResults"));
        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
    }

    [Test]
    public void Custom_filters_on_system_channel_cover_recruitment_notifications()
    {
        Assert.That(ChatFlags.CheckFlags((int)ChatFlags.Channels.System, ChatType.PeriodicRecruitmentNotification),
            Is.True);
    }
}
