using Dalamud.Game;
using NUnit.Framework;

namespace TidyChat.Tests;

[TestFixture]
public class InstancedAreaMessageTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Instanced_area_rule_matches_instance_reminder_only()
    {
        var rule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowInstancedAreaMessages", StringComparison.Ordinal));

        Assert.That(
            RuleMatcher.MatchesText(
                rule,
                "you are now in the instanced area. current instance can be confirmed at any time using the /instance text command.",
                out _),
            Is.True);
        Assert.That(RuleMatcher.MatchesText(rule, "the sealed door opens.", out _), Is.False);
    }

    [Test]
    public void Sealed_door_open_maps_to_dungeon_mechanic_not_instanced_area()
    {
        Assert.That(Rules.LogMessageIdToRules[2059u].Any(r =>
            string.Equals(r.Name, "ShowDungeonMechanicMessages", StringComparison.Ordinal)), Is.True);
        Assert.That(Rules.LogMessageIdToRules[2059u].Any(r =>
            string.Equals(r.Name, "ShowInstancedAreaMessages", StringComparison.Ordinal)), Is.False);
    }
}
