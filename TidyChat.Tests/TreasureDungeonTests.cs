using Dalamud.Game;
using NUnit.Framework;
using TidyChat.Utility;
namespace TidyChat.Tests;

[TestFixture]
public class TreasureDungeonTests
{
    [SetUp]
    public void SetUp()
    {
        L10N.Language = ClientLanguage.English;
        TreasureDungeonHelper.Reset();
    }

    [TearDown]
    public void TearDown() => TreasureDungeonHelper.Reset();

    [Test]
    public void Trap_on_first_floor_without_gate_reports_first_floor()
    {
        Assert.That(TreasureDungeonHelper.TryGetExpulsionChamber(out var chamber), Is.True);
        Assert.That(chamber, Is.EqualTo("1st"));
    }

    [Test]
    public void Reset_clears_stale_floor_from_previous_run()
    {
        TreasureDungeonHelper.RecordGateOpened(3);
        TreasureDungeonHelper.Reset();

        Assert.That(TreasureDungeonHelper.TryGetExpulsionChamber(out var chamber), Is.True);
        Assert.That(chamber, Is.EqualTo("1st"));
    }

    [Test]
    public void Trap_after_gate_to_fourth_reports_third_floor_when_gate_just_advanced()
    {
        TreasureDungeonHelper.RecordGateOpened(3);
        TreasureDungeonHelper.ClearGateAdvance();
        TreasureDungeonHelper.RecordGateOpened(4);

        Assert.That(TreasureDungeonHelper.TryGetExpulsionChamber(out var chamber), Is.True);
        Assert.That(chamber, Is.EqualTo("3rd"));
    }

    [Test]
    public void Trap_in_third_floor_after_settling_reports_third_floor()
    {
        TreasureDungeonHelper.RecordGateOpened(3);
        TreasureDungeonHelper.ClearGateAdvance();

        Assert.That(TreasureDungeonHelper.TryGetExpulsionChamber(out var chamber), Is.True);
        Assert.That(chamber, Is.EqualTo("3rd"));
    }

    [TestCase("1st", 1)]
    [TestCase("4th", 4)]
    [TestCase("3", 3)]
    public void TryParseChamber_accepts_ordinals_and_digits(string input, int expected)
    {
        Assert.That(TreasureDungeonHelper.TryParseChamber(input, out var floor), Is.True);
        Assert.That(floor, Is.EqualTo(expected));
    }

    [TestCase(1, "1st")]
    [TestCase(3, "3rd")]
    [TestCase(6, "6th")]
    public void FormatChamber_uses_english_ordinals(int floor, string expected) => Assert.That(TreasureDungeonHelper.FormatChamber(floor), Is.EqualTo(expected));
}
