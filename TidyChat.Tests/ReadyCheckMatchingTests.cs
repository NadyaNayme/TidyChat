using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Data;
using TidyChat.Localization.Data;

namespace TidyChat.Tests;

[TestFixture]
public class ReadyCheckMatchingTests
{
    [SetUp]
    public void SetUp()
    {
        L10N.Language = ClientLanguage.English;
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>());
    }

    [Test]
    public void Ready_check_commenced_matches_without_catalog()
    {
        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowReadyCheckMessages" &&
            r.RegexChecks?.Contains(ChatStrings.ReadyCheckCommencedRegex) == true);

        Assert.That(
            RuleMatcher.MatchesText(rule, "you have commenced a ready check.", out _),
            Is.True);
    }

    [Test]
    public void Ready_check_initiated_matches_without_player_name_prefix()
    {
        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowReadyCheckMessages" &&
            r.RegexChecks?.Contains(ChatStrings.ReadyCheckInitiatedRegex) == true);

        Assert.That(
            RuleMatcher.MatchesText(rule, "initiated a ready check.", out _),
            Is.True);
        Assert.That(
            RuleMatcher.MatchesText(rule, "kage okeya initiated a ready check.", out _),
            Is.True);
    }

    [Test]
    public void Ready_check_complete_matches_without_catalog()
    {
        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowReadyCheckMessages" &&
            r.RegexChecks?.Contains(ChatStrings.ReadyCheckCompleteRegex) == true);

        Assert.That(
            RuleMatcher.MatchesText(rule, "ready check complete.", out _),
            Is.True);
    }

    [Test]
    public void Ready_check_rules_match_with_catalog()
    {
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>
        {
            [3790] = "You have commenced a ready check.",
            [3791] = " have initiated a ready check.",
            [3794] = "Ready check complete."
        });

        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowReadyCheckMessages" && r.Pattern == PatternKind.None);

        Assert.That(RuleMatcher.MatchesText(rule, "you have commenced a ready check.", out _), Is.True);
        Assert.That(RuleMatcher.MatchesText(rule, "have initiated a ready check.", out _), Is.True);
        Assert.That(RuleMatcher.MatchesText(rule, "ready check complete.", out _), Is.True);
    }
}
