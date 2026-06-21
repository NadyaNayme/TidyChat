using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Localization.Data;
namespace TidyChat.Tests;

[TestFixture]
public class HousingMatchingTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Housing_ward_entry_matches_place_comma_ward_format()
    {
        var ward = FindRuleByRegex("ShowHousingWardMessage", ChatStrings.HousingWardEntryRegex);

        Assert.That(
            RuleMatcher.MatchesText(ward, "the lavender beds, ward 8", out _),
            Is.True);
    }

    [Test]
    public void Housing_ward_rule_does_not_match_lottery_submission_line()
    {
        var ward = FindRuleByRegex("ShowHousingWardMessage", ChatStrings.HousingWardEntryRegex);
        const string lottery =
            "you have submitted a lottery entry for plot 1, ward 8, the lavender beds. your lottery number is 29.";

        Assert.That(RuleMatcher.MatchesText(ward, lottery, out _), Is.False);
    }

    [Test]
    public void Housing_lottery_rule_matches_entry_and_estate_reminder()
    {
        var lottery = FindRuleByRegex("ShowHousingLotteryMessage", ChatStrings.HousingLotteryMessageRegex);

        Assert.That(
            RuleMatcher.MatchesText(lottery,
                "you have submitted a lottery entry for plot 1, ward 8, the lavender beds. your lottery number is 29.",
                out _),
            Is.True);
        Assert.That(
            RuleMatcher.MatchesText(lottery,
                "the status of your lottery entry can be confirmed at any time via the estate tab of the timers interface located under duty in the main menu.",
                out _),
            Is.True);
    }

    [Test]
    public void Housing_lottery_rule_does_not_match_ward_entry_line()
    {
        var lottery = FindRuleByRegex("ShowHousingLotteryMessage", ChatStrings.HousingLotteryMessageRegex);

        Assert.That(
            RuleMatcher.MatchesText(lottery, "the lavender beds, ward 8", out _),
            Is.False);
    }

    private static LocalizedFilterRule FindRuleByRegex(string name, LocalizedRegex regexCheck) =>
        Rules.AllRules.First(rule =>
            string.Equals(rule.Name, name, StringComparison.Ordinal) &&
            rule.RegexChecks?.Contains(regexCheck) == true);
}
