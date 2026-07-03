using ChatTwo.Code;
using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Settings;
namespace TidyChat.Tests;

[TestFixture]
public class GatheringObtainFailureTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Obtain_nothing_does_not_use_other_player_obtain_override()
    {
        var config = new Configuration { HideOthersObtain = false };
        var text = "ren s. obtains nothing.";

        Assert.That(LootFilterHelper.ShouldShowOtherPlayerObtain(config, ChatType.LootNotice, text), Is.False);
    }

    [Test]
    public void Obtain_nothing_regex_matches_self_and_third_person()
    {
        Assert.That(L10N.Get(ChatStrings.GatheringObtainNothingRegex).IsMatch("you obtain nothing."), Is.True);
        Assert.That(L10N.Get(ChatStrings.GatheringObtainNothingRegex).IsMatch("ren s. obtains nothing."), Is.True);
    }

    [Test]
    public void Prospector_use_regex_matches_third_person_collectability_action()
    {
        var text = "ren s. uses meticulous prospector.";

        Assert.That(L10N.Get(ChatStrings.GatheringUsesCollectabilityActionRegex).IsMatch(text), Is.True);
    }

    [Test]
    public void Obtain_nothing_is_not_generic_item_obtain_line()
    {
        Assert.That(ObtainCurrencyHelper.IsGenericItemObtainLine("you obtain nothing."), Is.False);
        Assert.That(ObtainCurrencyHelper.IsGenericItemObtainLine("ren s. obtains nothing."), Is.False);
    }

    [Test]
    public void Collectable_obtain_rule_matches_obtain_nothing_log_message_ids()
    {
        var rule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowGatheringCollectableObtains", StringComparison.Ordinal) &&
            r.Channel == ChatType.Gathering &&
            r.Pattern == PatternKind.None &&
            r.LogMessageIds != null && Array.IndexOf(r.LogMessageIds, 1051u) >= 0);

        Assert.That(rule.LogMessageIds, Does.Contain(1056u));
    }
}
