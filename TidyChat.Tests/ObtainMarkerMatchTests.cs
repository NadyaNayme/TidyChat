using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Data;
namespace TidyChat.Tests;

[TestFixture]
public class ObtainMarkerMatchTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Gear_obtain_does_not_match_gil_or_mgp_hide_rules()
    {
        var text = "you obtain a mistwake ring of fending. part of the set mistwake attire of fending!";
        var gilRule = FindObtainMarkerRule("HideObtainedGil", true);
        var mgpRule = FindObtainMarkerRule("HideObtainedMGP", obtainMarkerMgp: true);

        Assert.That(RuleMatcher.MatchesText(gilRule, text, out _), Is.False);
        Assert.That(RuleMatcher.MatchesText(mgpRule, text, out _), Is.False);
        Assert.That(ObtainCurrencyHelper.HasDedicatedObtainType(text), Is.False);
    }

    [Test]
    public void Gil_obtain_still_matches_gil_hide_rule()
    {
        var text = "you obtain 1,000 gil.";
        var gilRule = FindObtainMarkerRule("HideObtainedGil", true);

        Assert.That(RuleMatcher.MatchesText(gilRule, text, out _), Is.True);
        Assert.That(ObtainCurrencyHelper.GetAllowBecauseHideOffRuleName(new(), text),
            Is.EqualTo("HideObtainedGil"));
    }

    [Test]
    public void Mgp_obtain_still_matches_mgp_hide_rule()
    {
        var text = "you obtain 15 mgp.";
        var mgpRule = FindObtainMarkerRule("HideObtainedMGP", obtainMarkerMgp: true);

        Assert.That(RuleMatcher.MatchesText(mgpRule, text, out _), Is.True);
        Assert.That(ObtainCurrencyHelper.GetAllowBecauseHideOffRuleName(new(), text),
            Is.EqualTo("HideObtainedMGP"));
    }

    private static LocalizedFilterRule FindObtainMarkerRule(string name, bool obtainMarkerGil = false,
        bool obtainMarkerMgp = false) =>
        Rules.AllRules.First(rule =>
            string.Equals(rule.Name, name, StringComparison.Ordinal) &&
            rule.ObtainMarkerGil == obtainMarkerGil &&
            rule.ObtainMarkerMgp == obtainMarkerMgp &&
            rule.LogMessageIds?.SequenceEqual(LogMessageCatalog.SharedObtainTemplateIds) == true);
}
