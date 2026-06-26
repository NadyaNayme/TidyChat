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

    [Test]
    public void Venture_coffer_does_not_match_venture_hide_rule_or_dedicated_obtain_type()
    {
        var text = "you obtain a venture coffer.";
        var ventureRule = FindObtainMarkerRule("HideObtainedVenture", obtainMarkerItemId: ItemMarkerCatalog.Items.Venture);

        Assert.That(RuleMatcher.MatchesText(ventureRule, text, out _), Is.False);
        Assert.That(ObtainCurrencyHelper.HasDedicatedObtainType(text), Is.False);
        Assert.That(ObtainCurrencyHelper.IsGenericItemObtainLine(text), Is.True);
    }

    [Test]
    public void Venture_currency_obtain_still_matches_venture_hide_rule()
    {
        var text = "you obtain a venture.";
        var ventureRule = FindObtainMarkerRule("HideObtainedVenture", obtainMarkerItemId: ItemMarkerCatalog.Items.Venture);

        Assert.That(RuleMatcher.MatchesText(ventureRule, text, out _), Is.True);
        Assert.That(ObtainCurrencyHelper.GetAllowBecauseHideOffRuleName(new(), text),
            Is.EqualTo("HideObtainedVenture"));
    }

    [Test]
    public void HideObtainedShards_covers_gathering_obtain_templates()
    {
        // Gathering obtains for crystals/shards arrive on LootNotice with the same templates used by
        // ShowGatheringCollectableObtains (3538, 1049, 1050, 1053, 1054). HideObtainedShards must cover them
        // so the active-hide precedence wins over the active show rule on the LogMessage path.
        var gatheringObtainIds = new uint[] { 3538, 1049, 1050, 1053, 1054 };

        var shardRule = Rules.AllRules.FirstOrDefault(rule =>
            string.Equals(rule.Name, "HideObtainedShards", StringComparison.Ordinal) &&
            rule.Channel == ChatTwo.Code.ChatType.LootNotice &&
            rule.ObtainMarkerAnyElemental &&
            rule.LogMessageIds?.SequenceEqual(gatheringObtainIds) == true);

        Assert.That(shardRule, Is.Not.Null,
            "HideObtainedShards must cover the gathering obtain templates 3538/1049/1050/1053/1054.");
        Assert.That(shardRule!.BlockWhenActive, Is.True);

        foreach (var id in gatheringObtainIds)
        {
            Assert.That(Rules.LogMessageIdToRules.TryGetValue(id, out var rulesForId), Is.True, $"ID {id}");
            Assert.That(rulesForId!.Any(r => string.Equals(r.Name, "HideObtainedShards", StringComparison.Ordinal)),
                Is.True, $"ID {id} should map to HideObtainedShards");
            Assert.That(rulesForId!.Any(r =>
                string.Equals(r.Name, "ShowGatheringCollectableObtains", StringComparison.Ordinal)),
                Is.True, $"ID {id} should still map to ShowGatheringCollectableObtains");
        }
    }

    [Test]
    public void Cactpot_ticket_purchase_does_not_match_hide_obtained_mgp_rules()
    {
        const string text =
            "you use 100 mgp to purchase a jumbo cactpot ticket with the numbers 0459.";

        foreach (var rule in Rules.AllRules.Where(r => r.Name == "HideObtainedMGP"))
        {
            Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.False, $"{rule.Channel}");
        }
    }

    [Test]
    public void Cactpot_ticket_purchase_matches_show_mgp_spending()
    {
        const string text =
            "you use 100 mgp to purchase a jumbo cactpot ticket with the numbers 0459.";
        var rule = Rules.AllRules.First(r => r.Name == "ShowMgpSpending");

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
    }

    private static LocalizedFilterRule FindObtainMarkerRule(string name, bool obtainMarkerGil = false,
        bool obtainMarkerMgp = false, uint? obtainMarkerItemId = null) =>
        Rules.AllRules.First(rule =>
            string.Equals(rule.Name, name, StringComparison.Ordinal) &&
            rule.ObtainMarkerGil == obtainMarkerGil &&
            rule.ObtainMarkerMgp == obtainMarkerMgp &&
            rule.ObtainMarkerItemId == obtainMarkerItemId &&
            rule.LogMessageIds?.SequenceEqual(LogMessageCatalog.SharedObtainTemplateIds) == true);
}
