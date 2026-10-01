namespace TidyChat.Data;

// entries expire so a leftover id can't swallow a later line that loosely matches its template (#132)
internal sealed class PendingLogMessageIds
{
    internal const long DefaultLifetimeMs = 2000;

    private readonly Dictionary<uint, Queue<long>> _expiryById = [];
    private readonly long _lifetimeMs;
    private readonly Func<long> _now;

    public PendingLogMessageIds(long lifetimeMs = DefaultLifetimeMs, Func<long>? now = null)
    {
        _lifetimeMs = lifetimeMs;
        _now = now ?? (() => Environment.TickCount64);
    }

    public int Count
    {
        get
        {
            Prune();
            return _expiryById.Count;
        }
    }

    public void Add(uint logMessageId)
    {
        if (!_expiryById.TryGetValue(logMessageId, out var queue))
        {
            queue = new Queue<long>();
            _expiryById[logMessageId] = queue;
        }
        queue.Enqueue(_now() + _lifetimeMs);
    }

    public uint[] ActiveIds()
    {
        Prune();
        return [.. _expiryById.Keys];
    }

    public bool TryConsume(uint logMessageId)
    {
        Prune();
        if (!_expiryById.TryGetValue(logMessageId, out var queue))
        {
            return false;
        }

        queue.Dequeue();
        if (queue.Count == 0)
        {
            _expiryById.Remove(logMessageId);
        }
        return true;
    }

    public void Clear() => _expiryById.Clear();

    private void Prune()
    {
        if (_expiryById.Count == 0)
        {
            return;
        }

        var now = _now();
        List<uint>? empty = null;
        foreach (var (id, queue) in _expiryById)
        {
            while (queue.Count > 0 && queue.Peek() <= now)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                (empty ??= []).Add(id);
            }
        }

        if (empty is null)
        {
            return;
        }
        foreach (var id in empty)
        {
            _expiryById.Remove(id);
        }
    }
}
