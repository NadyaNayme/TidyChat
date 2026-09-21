using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Data;

namespace TidyChat.Tests;

[TestFixture]
public class GearsetEquippedMatchingTests
{
    private const string RelicQuestReceive =
        "in order to receive the quest \"celestial radiance,\" you must be equipped with a relic weapon animus. paladins must be equipped with both curtana and the holy shield.";

    private const string RelicQuestAdvance =
        "in order to advance the quest \"star light, star bright,\" you must be equipped with a relic weapon animus. paladins must be equipped with both curtana and the holy shield.";

    [SetUp]
    public void SetUp()
    {
        L10N.Language = ClientLanguage.English;
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>());
    }

    [Test]
    public void ShowGearsetEquipped_rules_do_not_match_relic_quest_requirement()
    {
        var rules = GearsetRules();
        Assert.That(rules, Is.Not.Empty);

        foreach (var rule in rules)
        {
            Assert.That(
                RuleMatcher.MatchesText(rule, RelicQuestReceive, out var detail),
                Is.False,
                $"Rule with IDs [{string.Join(", ", rule.LogMessageIds ?? [])}] matched via {detail}");
            Assert.That(
                RuleMatcher.MatchesText(rule, RelicQuestAdvance, out detail),
                Is.False,
                $"Rule with IDs [{string.Join(", ", rule.LogMessageIds ?? [])}] matched via {detail}");
        }
    }

    [Test]
    public void ShowGearsetEquipped_rules_do_not_match_relic_quest_when_catalog_only_has_equipped()
    {
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>
        {
            [700] = " equipped.",
            [755] = "“UNKNOWN” equipped.",
            [788] = " is placed in your Armoury Chest."
        });

        ShowGearsetEquipped_rules_do_not_match_relic_quest_requirement();
    }

    [TestCase("\"red mage\" equipped.")]
    [TestCase("warrior equipped.")]
    public void Gearset_equipped_rule_matches_actual_gearset_line(string text)
    {
        var rule = GearsetRules().First(rule => rule.LogMessageIds is [700, 755]);
        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
    }

    [Test]
    public void Armoury_chest_rule_matches_placement_line()
    {
        var rule = GearsetRules().First(rule => rule.LogMessageIds is [788]);
        Assert.That(
            RuleMatcher.MatchesText(rule, "curtana animus is placed in your armoury chest.", out _),
            Is.True);
    }

    [Test]
    public void Quest_equipment_requirement_rule_matches_relic_quest_lines()
    {
        var rule = Rules.AllRules.First(rule =>
            string.Equals(rule.Name, "ShowQuestEquipmentRequirement", StringComparison.Ordinal));

        Assert.That(RuleMatcher.MatchesText(rule, RelicQuestReceive, out _), Is.True);
        Assert.That(RuleMatcher.MatchesText(rule, RelicQuestAdvance, out _), Is.True);
        Assert.That(
            RuleMatcher.MatchesText(rule, "\"red mage\" equipped.", out _),
            Is.False);
    }

    private static List<LocalizedFilterRule> GearsetRules() =>
        Rules.AllRules
            .Where(rule => string.Equals(rule.Name, "ShowGearsetEquipped", StringComparison.Ordinal))
            .ToList();
}
