using NUnit.Framework;

namespace TidyChat.Tests;

/// <summary>
///     Regression tests for the community report where the Lifestream FATE line
///     "The aramitama has begun to disrupt the Lifestream." was blocked by ShowDutyCommenceMessage.
///     Matching runs against lowercased chat text, so all inputs here are lowercase.
/// </summary>
[TestFixture]
public class DutyCommenceMatchTests
{
    private const string AramitamaLine = "the aramitama has begun to disrupt the lifestream.";

    [TestCase("the palace of the dead has begun.")]
    [TestCase("sastasha has begun")]
    public void English_duty_commence_lines_match(string line)
    {
        Assert.That(ChatStrings.DutyHasBegunRegex.Eng.IsMatch(line), Is.True);
    }

    [Test]
    public void English_event_line_containing_has_begun_mid_sentence_does_not_match()
    {
        Assert.That(ChatStrings.DutyHasBegunRegex.Eng.IsMatch(AramitamaLine), Is.False);
    }

    [Test]
    public void Negative_control_old_token_check_matched_the_reported_line()
    {
        // The old StringChecks were ["has", "begun"] via ordinal Contains; this proves the
        // reported line really did satisfy the previous matching strategy.
        Assert.That(AramitamaLine, Does.Contain("has").And.Contain("begun"));
    }

    [Test]
    public void Japanese_duty_commence_line_matches()
    {
        Assert.That(ChatStrings.DutyHasBegunRegex.Jpn.IsMatch("「サスタシャ浸食洞」の攻略を開始した。"), Is.True);
    }

    [TestCase("„sastasha“ hat begonnen.")]
    [TestCase("„sastasha“ hat begonnen.")]
    public void German_duty_commence_line_matches(string line)
    {
        Assert.That(ChatStrings.DutyHasBegunRegex.Deu.IsMatch(line), Is.True);
    }

    [TestCase("la mission “sastasha” commence.")]
    [TestCase("la mission \"sastasha\" commence.")]
    public void French_duty_commence_line_matches(string line)
    {
        Assert.That(ChatStrings.DutyHasBegunRegex.Fra.IsMatch(line), Is.True);
    }

    [Test]
    public void Duty_name_is_extracted_without_quotes()
    {
        var jpn = ChatStrings.DutyHasBegunRegex.Jpn.Match("「サスタシャ浸食洞」の攻略を開始した。");
        var fra = ChatStrings.DutyHasBegunRegex.Fra.Match("la mission “sastasha” commence.");
        Assert.Multiple(() =>
        {
            Assert.That(jpn.Groups["duty"].Value, Is.EqualTo("サスタシャ浸食洞"));
            Assert.That(fra.Groups["duty"].Value, Is.EqualTo("sastasha"));
        });
    }
}
