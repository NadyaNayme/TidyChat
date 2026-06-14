using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Localization.Data;
using TidyChat.Settings;

namespace TidyChat.Tests;

[TestFixture]
public class PartyLootFilterTests
{
    [SetUp]
    public void SetUp() => L10N.Language = ClientLanguage.English;

    [Test]
    public void Other_player_obtain_allowed_when_show_toggle_is_on()
    {
        var config = new Configuration { HideOthersObtain = false };
        var text = "tiziana obtains a grand champion's foil.";

        Assert.That(LootFilterHelper.ShouldShowOtherPlayerObtain(config, text), Is.True);
    }

    [Test]
    public void Other_player_obtain_hidden_when_hide_toggle_is_on()
    {
        var config = new Configuration { HideOthersObtain = true };
        var text = "tiziana obtains a grand champion's foil.";

        Assert.That(LootFilterHelper.ShouldShowOtherPlayerObtain(config, text), Is.False);
    }

    [Test]
    public void Self_loot_roll_rule_does_not_apply_to_other_player_lines()
    {
        var rule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowLootRoll", StringComparison.Ordinal) &&
            r.StringChecks?.Contains(ChatStrings.LootRoll) == true);
        var text = "tiziana rolls need on the arcadion orchestrion roll. 42";

        Assert.That(LootFilterHelper.ShouldDeferSelfLootRollOrCastLotRule(text, rule), Is.True);
        Assert.That(RuleMatcher.MatchesText(rule, text, out _), Is.False);
    }

    [Test]
    public void Other_player_loot_roll_allowed_when_show_others_roll_is_on()
    {
        var config = new Configuration { ShowOthersLootRoll = true };
        var text = "tiziana rolls need on the arcadion orchestrion roll. 42";

        Assert.That(LootFilterHelper.ShouldShowOtherPlayerLootRoll(config, 1231, text), Is.True);
    }

    [Test]
    public void Generic_obtain_show_rule_defers_for_other_player_obtain()
    {
        var rule = Rules.AllRules.First(r =>
            string.Equals(r.Name, "ShowObtainedItems", StringComparison.Ordinal) &&
            r.StringChecks?.Contains(ChatStrings.ObtainedSingleItem) == true);
        var text = "tiziana obtains a grand champion's foil.";

        Assert.That(LootFilterHelper.ShouldDeferGenericObtainShowRule(text, rule), Is.True);
    }
}
