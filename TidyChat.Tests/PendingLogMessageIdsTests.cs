using NUnit.Framework;
using TidyChat.Data;
namespace TidyChat.Tests;

[TestFixture]
public class PendingLogMessageIdsTests
{
    private long _now;

    private PendingLogMessageIds Create() => new(lifetimeMs: 100, now: () => _now);

    [SetUp]
    public void SetUp() => _now = 1000;

    [Test]
    public void Consumes_each_added_id_once()
    {
        var pending = Create();
        pending.Add(3379);
        pending.Add(3379);

        Assert.That(pending.TryConsume(3379), Is.True);
        Assert.That(pending.TryConsume(3379), Is.True);
        Assert.That(pending.TryConsume(3379), Is.False);
        Assert.That(pending.Count, Is.Zero);
    }

    [Test]
    public void Expired_id_cannot_claim_a_later_unrelated_line()
    {
        // #132: a ward-entry id left pending blocked a much later plugin line containing "ward"
        var pending = Create();
        pending.Add(3379);

        _now += 101;

        Assert.That(pending.ActiveIds(), Is.Empty);
        Assert.That(pending.TryConsume(3379), Is.False);
    }

    [Test]
    public void Only_expired_entries_are_pruned()
    {
        var pending = Create();
        pending.Add(3379);
        _now += 60;
        pending.Add(3379);
        _now += 60;

        Assert.That(pending.TryConsume(3379), Is.True);
        Assert.That(pending.TryConsume(3379), Is.False);
    }
}
