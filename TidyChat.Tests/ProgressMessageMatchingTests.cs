using Dalamud.Game;
using NUnit.Framework;

namespace TidyChat.Tests;

[TestFixture]
public class ProgressMessageMatchingTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Ability_unlock_rule_matches_learned_action_or_emote_line()
    {
        var rule = Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowAbilityUnlock", StringComparison.Ordinal));

        Assert.That(RuleMatcher.MatchesText(rule, "you learn ballroom etiquette - well-oiled.", out _), Is.True);
    }

    [TestCase("the icebound tomelith 1 shatters!")]
    [TestCase("the allagan tomelith 2 is activated!")]
    [TestCase("the ovoo 3 is now active!")]
    public void Pvp_zone_announcements_rule_matches_frontline_objective_lines(string text)
    {
        var rule = Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowPvpZoneAnnouncements", StringComparison.Ordinal) &&
            rule.RegexChecks?.Contains(ChatStrings.FrontlineObjectiveAnnouncementRegex) == true);

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
    }
}
