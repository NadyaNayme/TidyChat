using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Utility;
namespace TidyChat.Tests;

[TestFixture]
public class EnemyCastLogTests
{
    [SetUp]
    public void SetUp()
    {
        L10N.Language = ClientLanguage.English;
        EnemyCastLogHelper.Clear();
    }

    [TearDown]
    public void TearDown() => EnemyCastLogHelper.Clear();

    [Test]
    public void Readies_then_matching_uses_is_suppressed()
    {
        var readies = EnemyCastLogHelper.Handle("kefka readies future's end.");
        Assert.That(readies, Is.EqualTo(EnemyCastLogAction.RecordReadies));

        var uses = EnemyCastLogHelper.Handle("kefka uses future's end.");
        Assert.That(uses, Is.EqualTo(EnemyCastLogAction.SuppressUses));
    }

    [Test]
    public void Readies_then_multi_hit_uses_is_suppressed()
    {
        EnemyCastLogHelper.Handle("kefka readies future's end.");

        var uses = EnemyCastLogHelper.Handle("kefka uses future's end. (2x)");
        Assert.That(uses, Is.EqualTo(EnemyCastLogAction.SuppressUses));
    }

    [Test]
    public void Instant_uses_without_readies_is_not_suppressed_by_default()
    {
        var uses = EnemyCastLogHelper.Handle("kefka uses spellwave.");
        Assert.That(uses, Is.EqualTo(EnemyCastLogAction.None));
    }

    [Test]
    public void Instant_uses_without_readies_is_suppressed_when_enabled()
    {
        var uses = EnemyCastLogHelper.Handle("kefka uses spellwave.", true);
        Assert.That(uses, Is.EqualTo(EnemyCastLogAction.SuppressUses));
    }

    [Test]
    public void Player_readies_and_uses_are_ignored()
    {
        Assert.That(EnemyCastLogHelper.Handle("you readies cure."), Is.EqualTo(EnemyCastLogAction.None));
        Assert.That(EnemyCastLogHelper.Handle("you use cure."), Is.EqualTo(EnemyCastLogAction.None));
    }

    [Test]
    public void New_readies_updates_pending_cast_for_actor()
    {
        EnemyCastLogHelper.Handle("kefka readies future's end.");

        EnemyCastLogHelper.Handle("kefka readies all things ending.");

        Assert.That(EnemyCastLogHelper.Handle("kefka uses future's end."), Is.EqualTo(EnemyCastLogAction.None));
        Assert.That(EnemyCastLogHelper.Handle("kefka uses all things ending."),
            Is.EqualTo(EnemyCastLogAction.SuppressUses));
    }

    [TestCase("Future's End.", "future's end")]
    [TestCase("Spellwave. (2x)", "spellwave")]
    public void NormalizeAbility_strips_trailing_noise(string input, string expected) => Assert.That(EnemyCastLogHelper.NormalizeAbility(input), Is.EqualTo(expected));
}
