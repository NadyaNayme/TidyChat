using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Data;
using TidyChat.Localization.Data;

namespace TidyChat.Tests;

[TestFixture]
public class SystemMessageMatchingTests
{
    [SetUp]
    public void SetUp()
    {
        L10N.Language = ClientLanguage.English;
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>());
    }

    [TestCase("master volume muted.")]
    [TestCase("bgm volume unmuted.")]
    [TestCase("own sound effects volume set to 10.")]
    [TestCase("party member's sound effects set to 10.")]
    [TestCase("others' sound effects set to 10.")]
    [TestCase("system sounds speaker output set to on.")]
    [TestCase("system sounds speaker output unmuted.")]
    [TestCase("performance volume muted.")]
    [TestCase("mount bgm volume muted.")]
    public void Volume_control_regex_matches_set_and_mute_lines(string text)
    {
        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowVolumeControlMessages" &&
            r.RegexChecks?.Contains(ChatStrings.VolumeControlRegex) == true);

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
    }

    [Test]
    public void Volume_control_regex_does_not_match_unrelated_system_lines()
    {
        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowVolumeControlMessages" &&
            r.RegexChecks?.Contains(ChatStrings.VolumeControlRegex) == true);

        Assert.That(RuleMatcher.MatchesText(rule, "you change to paladin.", out _), Is.False);
        Assert.That(RuleMatcher.MatchesText(rule, "changes saved.", out _), Is.False);
    }

    [Test]
    public void Volume_control_none_row_covers_set_and_performance_ids()
    {
        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowVolumeControlMessages" && r.Pattern == PatternKind.None);

        Assert.That(rule.LogMessageIds, Does.Contain((uint)3856));
        Assert.That(rule.LogMessageIds, Does.Contain((uint)3871));
        Assert.That(rule.LogMessageIds, Does.Contain((uint)3869));
        Assert.That(rule.LogMessageIds, Does.Not.Contain((uint)3867));
        Assert.That(rule.LogMessageIds, Does.Not.Contain((uint)3868));
    }

    [Test]
    public void Config_change_saved_matches_without_catalog()
    {
        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowConfigChangeMessages" &&
            r.StringChecks?.Contains(ChatStrings.ChangesSaved) == true);

        Assert.That(RuleMatcher.MatchesText(rule, "changes saved.", out _), Is.True);
    }

    [Test]
    public void Config_change_none_row_covers_save_lost_and_discarded_ids()
    {
        var rule = Rules.AllRules.First(r =>
            r.Name == "ShowConfigChangeMessages" && r.Pattern == PatternKind.None);

        Assert.That(rule.LogMessageIds, Is.EquivalentTo(new uint[] { 801, 802, 4242 }));
    }
}
