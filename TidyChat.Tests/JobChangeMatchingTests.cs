using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Data;

namespace TidyChat.Tests;

[TestFixture]
public class JobChangeMatchingTests
{
    private const string HuntRelay =
        "rank s: ihnuxokiy kozama'uka ( 23.6 , 36.5 ) <adamantoise>";

    [SetUp]
    public void SetUp()
    {
        L10N.Language = ClientLanguage.English;
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>());
    }

    [Test]
    public void ShowJobChange_rules_do_not_match_hunt_relay_line()
    {
        var rules = Rules.AllRules
            .Where(rule => string.Equals(rule.Name, "ShowJobChange", StringComparison.Ordinal))
            .ToList();

        Assert.That(rules, Is.Not.Empty);

        foreach (var rule in rules)
        {
            Assert.That(
                RuleMatcher.MatchesText(rule, HuntRelay, out var detail),
                Is.False,
                $"Rule with IDs [{string.Join(", ", rule.LogMessageIds ?? [])}] matched via {detail}");
        }
    }

    [Test]
    public void ShowJobChange_rules_do_not_match_hunt_relay_when_catalog_only_has_loose_to_token()
    {
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>
        {
            [561] = "to"
        });

        var rule = Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowJobChange", StringComparison.Ordinal) &&
            rule.LogMessageIds is [561]);

        Assert.That(RuleMatcher.MatchesText(rule, HuntRelay, out _), Is.False);
    }

    [Test]
    public void ShowJobChange_rules_do_not_match_hunt_relay_with_lumina_templates()
    {
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>
        {
            [561] = "You change to .",
            [756] = "“UNKNOWN” registered.",
            [1281] = "You change to (specialist)."
        });

        ShowJobChange_rules_do_not_match_hunt_relay_line();
    }

    [TestCase("you change to scholar.")]
    [TestCase("you change to paladin.")]
    public void Job_change_rule_matches_actual_job_change_line(string text)
    {
        var rule = Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowJobChange", StringComparison.Ordinal) &&
            rule.LogMessageIds is [561]);

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
    }

    [TestCase("“paladin” registered.")]
    [TestCase("paladin registered.")]
    public void Job_registered_rule_matches_registered_line(string text)
    {
        var rule = Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowJobChange", StringComparison.Ordinal) &&
            rule.LogMessageIds is [756]);

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
    }

    [Test]
    public void Job_specialist_rule_matches_specialist_line()
    {
        var rule = Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowJobChange", StringComparison.Ordinal) &&
            rule.LogMessageIds is [1281]);

        Assert.That(
            RuleMatcher.MatchesText(rule, "you change to carpenter (specialist).", out _),
            Is.True);
    }
}
