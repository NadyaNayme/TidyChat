using NUnit.Framework;
using TidyChat.Settings;

namespace TidyChat.Tests;

[TestFixture]
public class CosmicClassPointsTests
{
    [Test]
    public void Tool_mastery_obtain_matches_cosmic_class_points_toggle()
    {
        var text = "you obtain 49248(+8208 armorer tool mastery points.";
        Assert.That(CosmicShowRuleHelper.MatchesCosmicClassPointsAndDatasetText(text), Is.True);
    }

    [Test]
    public void Tool_mastery_obtain_is_not_generic_item_obtain()
    {
        var text = "you obtain 49248(+8208 armorer tool mastery points.";
        Assert.That(ObtainCurrencyHelper.IsGenericItemObtainLine(text), Is.False);
        Assert.That(ObtainCurrencyHelper.HasDedicatedObtainType(text), Is.True);
    }

    [Test]
    public void Cosmic_class_points_toggle_allows_tool_mastery_in_log_message_resolution()
    {
        var config = new Configuration { ShowCosmicClassPointsAndDataset = true };
        var text = "you obtain 49248(+8208 armorer tool mastery points.";

        Assert.That(CosmicShowRuleHelper.IsCosmicMessageAllowed(config, text), Is.True);
        Assert.That(CosmicShowRuleHelper.GetActiveCosmicRuleName(config, text),
            Is.EqualTo("ShowCosmicClassPointsAndDataset"));
    }
}
