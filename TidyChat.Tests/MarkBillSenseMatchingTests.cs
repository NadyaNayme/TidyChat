using Dalamud.Game;
using NUnit.Framework;

namespace TidyChat.Tests;

[TestFixture]
public class MarkBillSenseMatchingTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Mark_bill_sense_matches_directional_and_lost_lines()
    {
        var direction = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowMarkBillMessages", StringComparison.Ordinal) &&
            r.RegexChecks?.Contains(ChatStrings.MarkBillSenseDirectionRegex) == true);
        var lost = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowMarkBillMessages", StringComparison.Ordinal) &&
            r.RegexChecks?.Contains(ChatStrings.MarkBillSenseLostRegex) == true);

        Assert.That(
            RuleMatcher.MatchesText(direction, "you sense your mark to the southwest.", out _),
            Is.True);
        Assert.That(
            RuleMatcher.MatchesText(direction, "you sense your mark to the north.", out _),
            Is.True);
        Assert.That(
            RuleMatcher.MatchesText(lost, "you no longer sense the presence of your mark...", out _),
            Is.True);
    }

    [Test]
    public void Mark_bill_sense_does_not_match_s_rank_or_spidey_lines()
    {
        var direction = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowMarkBillMessages", StringComparison.Ordinal) &&
            r.RegexChecks?.Contains(ChatStrings.MarkBillSenseDirectionRegex) == true);

        Assert.That(
            RuleMatcher.MatchesText(direction, "you sense the presence of a powerful mark...", out _),
            Is.False);
        Assert.That(
            RuleMatcher.MatchesText(direction, "you sense something foul may be lurking in the distance.", out _),
            Is.False);
        Assert.That(
            RuleMatcher.MatchesText(direction, "you sense something far, far to the northeast.", out _),
            Is.False);
    }

    [Test]
    public void Mark_bill_sense_matches_french_directional_line()
    {
        L10N.Language = ClientLanguage.French;
        var direction = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowMarkBillMessages", StringComparison.Ordinal) &&
            r.RegexChecks?.Contains(ChatStrings.MarkBillSenseDirectionRegex) == true);

        Assert.That(
            RuleMatcher.MatchesText(
                direction,
                "vous ressentez la présence d'un monstre d'élite au sud-ouest !",
                out _),
            Is.True);
    }
}
