using Dalamud.Game;
using NUnit.Framework;

namespace TidyChat.Tests;

[TestFixture]
public class FishingHoleMatchingTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Current_fishing_hole_regex_matches_cast_line_with_hole_name()
    {
        var rule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowCurrentFishingHole", StringComparison.Ordinal) &&
            r.Pattern == PatternKind.RegexMatch);

        Assert.That(
            RuleMatcher.MatchesText(rule, "you cast your line at the jade zigzag.", out _),
            Is.True);
    }

    [Test]
    public void Current_fishing_hole_has_id_only_logmessage_row()
    {
        Assert.That(
            Rules.AllRules.Any(r =>
                string.Equals(r.Name, "ShowCurrentFishingHole", StringComparison.Ordinal) &&
                r.Pattern == PatternKind.None &&
                r.LogMessageIds is [1110]),
            Is.True);
    }

    [Test]
    public void ShowLoseBait_has_id_only_row_for_fish_gets_away()
    {
        Assert.That(
            Rules.AllRules.Any(r =>
                string.Equals(r.Name, "ShowLoseBait", StringComparison.Ordinal) &&
                r.Pattern == PatternKind.None &&
                r.LogMessageIds is [1119]),
            Is.True);
    }

    [TestCase("the fish gets away...")]
    [TestCase("the fish gets away…")]
    public void Fish_gets_away_regex_matches_escape_line(string text)
    {
        var rule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowLoseBait", StringComparison.Ordinal) &&
            r.Pattern == PatternKind.RegexMatch &&
            r.LogMessageIds is [1119]);

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
    }

    [Test]
    public void Fish_gets_away_regex_does_not_match_lose_bait_line()
    {
        var rule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowLoseBait", StringComparison.Ordinal) &&
            r.Pattern == PatternKind.RegexMatch &&
            r.LogMessageIds is [1119]);

        Assert.That(RuleMatcher.MatchesText(rule, "you lose your bait...", out _), Is.False);
    }
}
