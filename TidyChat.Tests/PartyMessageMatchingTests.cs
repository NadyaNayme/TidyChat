using Dalamud.Game;
using NUnit.Framework;

namespace TidyChat.Tests;

[TestFixture]
public class PartyMessageMatchingTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [TestCase("you leave the party.")]
    [TestCase("you have left the party.")]
    [TestCase("raven reaver has left the party.")]
    public void Left_party_rule_matches_leave_and_left_variants(string text)
    {
        var rule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowLeftParty", StringComparison.Ordinal) &&
            r.RegexChecks?.Contains(ChatStrings.LeftPartyRegex) == true);

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
    }

    [TestCase("ShowInviteeJoins")]
    [TestCase("ShowJoinParty")]
    [TestCase("ShowLeftParty")]
    public void Party_join_leave_rules_use_soft_log_message_hide_to_preserve_sfx(string ruleName)
    {
        var rules = Rules.AllRules.Where(rule => string.Equals(rule.Name, ruleName, StringComparison.Ordinal));

        Assert.That(rules, Is.Not.Empty);
        Assert.That(rules.All(rule => rule.SoftHideLogMessage), Is.True);
    }
}
