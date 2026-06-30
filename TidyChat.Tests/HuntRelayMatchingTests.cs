using Dalamud.Game;
using NUnit.Framework;

namespace TidyChat.Tests;

[TestFixture]
public class HuntRelayMatchingTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void S_rank_hunt_rule_matches_community_relay_line()
    {
        var rule = Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowSRankHunt", StringComparison.Ordinal) &&
            rule.RegexChecks?.Contains(ChatStrings.HuntSRankRelayRegex) == true);

        Assert.That(
            RuleMatcher.MatchesText(
                rule,
                "rank s: ihnuxokiy kozama'uka ( 23.6 , 36.5 ) <adamantoise>",
                out _),
            Is.True);
    }

    [Test]
    public void S_rank_hunt_rule_matches_spawn_sense_line()
    {
        var rule = Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowSRankHunt", StringComparison.Ordinal) &&
            rule.Pattern == PatternKind.None);

        Assert.That(
            RuleMatcher.MatchesText(rule, "you sense the presence of a powerful mark...", out _),
            Is.False);
    }

    [Test]
    public void SS_rank_hunt_rule_matches_community_relay_line()
    {
        var rule = Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowSSRankHunt", StringComparison.Ordinal) &&
            rule.RegexChecks?.Contains(ChatStrings.HuntSSRankRelayRegex) == true);

        Assert.That(
            RuleMatcher.MatchesText(
                rule,
                "rank ss: soultaker lakeland ( 10.1 , 20.2 ) <cactbot>",
                out _),
            Is.True);
    }
}
