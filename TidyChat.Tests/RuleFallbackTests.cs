using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Localization.Data;
using TidyChat.Settings;

namespace TidyChat.Tests;

[TestFixture]
public class RuleFallbackTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Rejects_generic_obtain_text_fallback_for_specialized_rules()
    {
        var desynth = FindRuleByString("ShowDesynthesisObtains", ChatStrings.DesynthesisObtain);
        var cosmic = FindRuleByString("ShowCosmicRewards", ChatStrings.ObtainedSingleItem);

        Assert.That(ObtainCurrencyHelper.ShouldRejectCatalogTextFallback(desynth), Is.True);
        Assert.That(ObtainCurrencyHelper.ShouldRejectCatalogTextFallback(cosmic), Is.True);
    }

    [Test]
    public void Allows_generic_obtain_text_fallback_for_general_item_rules()
    {
        var general = FindRuleByString("ShowObtainedItems", ChatStrings.ObtainedSingleItem);

        Assert.That(ObtainCurrencyHelper.ShouldRejectCatalogTextFallback(general), Is.False);
    }

    [Test]
    public void Allows_specific_regex_fallback_for_catalog_rules()
    {
        var dutyCommence = FindRuleByRegex("ShowDutyCommenceMessage", ChatStrings.DutyHasBegunRegex);

        Assert.That(ObtainCurrencyHelper.ShouldRejectCatalogTextFallback(dutyCommence), Is.False);
    }

    [Test]
    public void Allows_tightened_buff_effect_fallback_on_catalog_rules()
    {
        var buff = FindRuleByString("ShowCraftingBuffEffectGain", ChatStrings.BuffEffectGain);

        Assert.That(ObtainCurrencyHelper.ShouldRejectCatalogTextFallback(buff), Is.False);
        Assert.That(RuleMatcher.MatchesText(buff, "you gain the effect of inner quiet.", out _), Is.True);
        Assert.That(RuleMatcher.MatchesText(buff, "a special effect occurs.", out _), Is.False);
    }

    [Test]
    public void Spidey_senses_requires_foul_phrasing()
    {
        var spidey = FindRuleByString("ShowSpideySenses", ChatStrings.SpideySenses);

        Assert.That(
            RuleMatcher.MatchesText(spidey, "you sense something foul may be lurking in the distance.", out _),
            Is.True);
        Assert.That(
            RuleMatcher.MatchesText(spidey, "you sense the fertile presence of minerals.", out _),
            Is.False);
    }

    [Test]
    public void Defers_inactive_specialized_obtain_rules_when_general_obtains_are_on()
    {
        var config = new Configuration { ShowObtainedItems = true };
        var desynth = FindRuleByString("ShowDesynthesisObtains", ChatStrings.DesynthesisObtain);

        Assert.That(
            ObtainCurrencyHelper.ShouldDeferObtainRuleToGeneral(config, desynth, "you obtain a tiny key."),
            Is.True);
    }

    [Test]
    public void Does_not_match_specialized_rules_on_catalog_miss_after_rejection()
    {
        var desynth = FindRuleByString("ShowDesynthesisObtains", ChatStrings.DesynthesisObtain);

        Assert.That(
            RuleMatcher.MatchesText(desynth, "you obtain a tiny key.", out _),
            Is.False);
    }

    private static LocalizedFilterRule FindRuleByString(string name, LocalizedStrings stringCheck) =>
        Rules.AllRules.First(rule =>
            string.Equals(rule.Name, name, StringComparison.Ordinal) &&
            rule.StringChecks?.Contains(stringCheck) == true);

    private static LocalizedFilterRule FindRuleByRegex(string name, LocalizedRegex regexCheck) =>
        Rules.AllRules.First(rule =>
            string.Equals(rule.Name, name, StringComparison.Ordinal) &&
            rule.RegexChecks?.Contains(regexCheck) == true);
}
