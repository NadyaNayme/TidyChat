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
}
