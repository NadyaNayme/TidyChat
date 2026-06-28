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
}
