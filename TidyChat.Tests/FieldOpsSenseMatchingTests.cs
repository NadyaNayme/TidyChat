using Dalamud.Game;
using NUnit.Framework;

namespace TidyChat.Tests;

[TestFixture]
public class FieldOpsSenseMatchingTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Treasure_coffer_sense_matches_plural_counts()
    {
        var rule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowTreasureCofferSenses", StringComparison.Ordinal) &&
            r.RegexChecks?.Contains(ChatStrings.TreasureCofferSenseRegex) == true);

        Assert.That(
            RuleMatcher.MatchesText(
                rule,
                "you sense the presence of 2 silver coffers and 30 bronze coffers in the area!",
                out _),
            Is.True);
    }

    [Test]
    public void Treasure_pot_sense_matches_far_far_direction()
    {
        var rule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowTreasurePotSenses", StringComparison.Ordinal) &&
            r.RegexChecks?.Contains(ChatStrings.TreasurePotSenseRegex) == true);

        Assert.That(
            RuleMatcher.MatchesText(rule, "you sense something far, far to the northeast.", out _),
            Is.True);
        Assert.That(
            RuleMatcher.MatchesText(rule, "you sense something far to the north.", out _),
            Is.True);
        Assert.That(
            RuleMatcher.MatchesText(rule, "you sense something to the southeast.", out _),
            Is.True);
    }

    [Test]
    public void Mooch_tip_and_swimbait_keep_match()
    {
        var moochTip = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowMooching", StringComparison.Ordinal) &&
            r.RegexChecks?.Contains(ChatStrings.MoochTipRegex) == true);
        var swimbait = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowSwimbaitMessages", StringComparison.Ordinal) &&
            r.RegexChecks?.Contains(ChatStrings.SwimbaitKeepRegex) == true);

        Assert.That(
            RuleMatcher.MatchesText(moochTip, "mooch to land an even bigger catch!", out _),
            Is.True);
        Assert.That(
            RuleMatcher.MatchesText(swimbait, "you keep the platinum ore as swimbait.", out _),
            Is.True);
    }
}
