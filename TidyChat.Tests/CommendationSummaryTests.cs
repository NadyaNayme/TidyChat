using NUnit.Framework;
using TidyChat.Settings;
namespace TidyChat.Tests;

[TestFixture]
public class CommendationSummaryTests
{
    [Test]
    public void Improved_commendations_hide_the_per_commendation_line_even_when_shown()
    {
        // ShowCommendations used to allow 926 on the hook, so the summary printed next to every original
        var configuration = new Configuration { BetterCommendationMessage = true, ShowCommendations = true };

        Assert.That(TidyChatPlugin.ShouldHideCommendationForSummary(926, configuration), Is.True);
    }

    [Test]
    public void Commendation_line_is_left_to_rules_when_summary_is_off()
    {
        var configuration = new Configuration { BetterCommendationMessage = false, ShowCommendations = true };

        Assert.That(TidyChatPlugin.ShouldHideCommendationForSummary(926, configuration), Is.False);
    }

    [Test]
    public void Other_log_messages_are_unaffected()
    {
        var configuration = new Configuration { BetterCommendationMessage = true };

        Assert.That(TidyChatPlugin.ShouldHideCommendationForSummary(925, configuration), Is.False);
    }
}
