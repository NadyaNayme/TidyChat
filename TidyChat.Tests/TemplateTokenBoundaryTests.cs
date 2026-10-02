using NUnit.Framework;
using TidyChat.Data;
namespace TidyChat.Tests;

[TestFixture]
public class TemplateTokenBoundaryTests
{
    private const char Macro = LogMessageTokenExtractor.MacroMarker;

    [SetUp]
    public void SetUp() =>
        LogMessageCatalog.LoadForTests(new Dictionary<uint, string>
        {
            [3379] = $"{Macro}, Ward {Macro}",
            [700] = $"{Macro} equipped.",
            [657] = $"You obtain {Macro} point{Macro}."
        });

    [Test]
    public void Ward_entry_template_no_longer_matches_a_name_containing_ward()
    {
        // #132: "ward" used to substring-match "wardr…" in a Doorbell line
        Assert.That(LogMessageCatalog.Matches(3379, "[doorbell] raven wardrobe has left the house."), Is.False);
        Assert.That(LogMessageCatalog.Matches(3379, "the lavender beds, ward 8"), Is.True);
    }

    [Test]
    public void Strict_edges_reject_longer_words()
    {
        Assert.That(LogMessageCatalog.Matches(700, "the armor was unequipped."), Is.False);
        Assert.That(LogMessageCatalog.Matches(700, "\"red mage\" equipped."), Is.True);
    }

    [TestCase("you obtain 1 point.")]
    [TestCase("you obtain 3 points.")]
    public void Edge_glued_to_a_macro_still_allows_plural_suffixes(string line) =>
        Assert.That(LogMessageCatalog.Matches(657, line), Is.True);

    [Test]
    public void String_form_parameters_mark_macro_edges()
    {
        var tokens = LogMessageTokenExtractor.ExtractTokens("You entrusted {IntegerParameter(1)} item<If(x)>s</If> to your retainer.");
        var item = tokens.Single(t => t.Text == "item");

        Assert.That(item.OpenStart, Is.False);
        Assert.That(item.OpenEnd, Is.True);
    }
}
