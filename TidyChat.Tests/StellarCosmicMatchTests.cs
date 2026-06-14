using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Localization.Data;
using TidyChat.Settings;

namespace TidyChat.Tests;

[TestFixture]
public class StellarCosmicMatchTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Stellar_mission_complete_matches_dedicated_rule()
    {
        var rule = FindStellarRule(ChatStrings.StellarMissionComplete, 10781);
        var text = "you complete the stellar mission \"master: voyager terminal reproduction\"!";

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
    }

    [Test]
    public void Stellar_high_score_matches_dedicated_rule()
    {
        var rule = FindStellarRule(ChatStrings.StellarMissionScore, 10804);
        var text = "you record a high score of 13,500 for \"master: voyager terminal reproduction.\"";

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
    }

    [Test]
    public void Gold_star_completion_does_not_match_present_tense_complete_rule()
    {
        var rule = FindStellarRule(ChatStrings.StellarMissionComplete, 10781);
        var text =
            "you completed the stellar mission \"master: voyager terminal reproduction\" with a gold star rating.";

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.False);
        Assert.That(RuleMatcher.MatchesText(FindStellarRule(ChatStrings.StellarMissionCompleted, 10779), text, out _),
            Is.True);
    }

    [Test]
    public void Sizable_contribution_matches_dedicated_rule()
    {
        var rule = FindCosmicExplorationRule(ChatStrings.CosmicExplorationSizableContribution, 10790);
        var text = "a sizable contribution to the exploration initiative has been recorded.";

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
        Assert.That(CosmicExplorationFilterHelper.MatchesCosmicExplorationText(text), Is.True);
    }

    [Test]
    public void Modest_contribution_does_not_match_sizable_only_rule()
    {
        var rule = FindCosmicExplorationRule(ChatStrings.CosmicExplorationSizableContribution, 10790);
        var text = "a modest contribution to the exploration initiative has been recorded.";

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.False);
        Assert.That(RuleMatcher.MatchesText(
                FindCosmicExplorationRule(ChatStrings.CosmicExplorationContribution, 10787), text, out _),
            Is.True);
    }

    private static LocalizedFilterRule FindStellarRule(LocalizedStrings stringCheck, uint logMessageId) =>
        Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowStellarMissionMessages", StringComparison.Ordinal) &&
            rule.StringChecks?.Contains(stringCheck) == true &&
            rule.LogMessageIds?.Contains(logMessageId) == true);

    private static LocalizedFilterRule FindCosmicExplorationRule(LocalizedStrings stringCheck, uint logMessageId) =>
        Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowCosmicExplorationMessages", StringComparison.Ordinal) &&
            rule.StringChecks?.Contains(stringCheck) == true &&
            rule.LogMessageIds?.Contains(logMessageId) == true);
}
