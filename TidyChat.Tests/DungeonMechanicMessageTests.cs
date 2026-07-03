using Dalamud.Game;
using NUnit.Framework;

namespace TidyChat.Tests;

[TestFixture]
public class DungeonMechanicMessageTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Blasting_cap_drop_matches_dungeon_mechanic_rule()
    {
        var rule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowDungeonMechanicMessages", StringComparison.Ordinal) &&
            r.RegexChecks?.Contains(ChatStrings.DungeonMechanicDropsRegex) == true);
        var text = "the blasting cap drops a six-onze pinch of firesand.";

        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.True);
        Assert.That(Rules.LogMessageIdToRules.ContainsKey(2069u), Is.True);
    }

    [Test]
    public void Static_dungeon_mechanic_ids_are_registered()
    {
        foreach (var id in new uint[] { 2060, 2065, 2069 })
        {
            Assert.That(Rules.LogMessageIdToRules.ContainsKey(id), Is.True, $"ID {id}");
            Assert.That(Rules.LogMessageIdToRules[id].Any(r =>
                string.Equals(r.Name, "ShowDungeonMechanicMessages", StringComparison.Ordinal)), Is.True);
        }
    }

    [Test]
    public void Firesand_and_shaft_clear_match_string_fallbacks()
    {
        var firesandRule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowDungeonMechanicMessages", StringComparison.Ordinal) &&
            r.StringChecks?.Contains(ChatStrings.DungeonFiresandSet) == true);
        var shaftRule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowDungeonMechanicMessages", StringComparison.Ordinal) &&
            r.StringChecks?.Contains(ChatStrings.DungeonShaftClear) == true);

        Assert.That(RuleMatcher.MatchesText(firesandRule, "the firesand is set.", out _), Is.True);
        Assert.That(RuleMatcher.MatchesText(shaftRule, "shaft e1 is now clear.", out _), Is.True);
    }
}
