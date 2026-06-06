using System.Threading;
using Timer = System.Timers.Timer;

namespace TidyChat;

public sealed partial class TidyChatPlugin
{
    private const int LogMessageDebugDedupFlushMs = 500;

    private readonly Lock _logMessageDebugDedupLock = new();
    private string? _logMessageDebugDedupKey;
    private int _logMessageDebugDedupCount;
    private Timer? _logMessageDebugDedupFlushTimer;

    private void EmitDedupedLogMessageDebug(string line)
    {
        lock (_logMessageDebugDedupLock)
        {
            if (string.Equals(_logMessageDebugDedupKey, line, StringComparison.Ordinal))
            {
                _logMessageDebugDedupCount++;
            }
            else
            {
                FlushLogMessageDebugDedupUnlocked();
                _logMessageDebugDedupKey = line;
                _logMessageDebugDedupCount = 1;
            }

            ScheduleLogMessageDebugDedupFlush();
        }
    }

    internal void FlushLogMessageDebugDedup()
    {
        lock (_logMessageDebugDedupLock)
        {
            StopLogMessageDebugDedupFlushTimer();
            FlushLogMessageDebugDedupUnlocked();
        }
    }

    private void DisposeLogMessageDebugDedup()
    {
        FlushLogMessageDebugDedup();
        _logMessageDebugDedupFlushTimer?.Dispose();
        _logMessageDebugDedupFlushTimer = null;
    }

    private void OnLogMessageDebugDedupFlushElapsed(object? sender, System.Timers.ElapsedEventArgs e) =>
        FlushLogMessageDebugDedup();

    private void ScheduleLogMessageDebugDedupFlush()
    {
        _logMessageDebugDedupFlushTimer ??= new Timer
        {
            Interval = LogMessageDebugDedupFlushMs,
            AutoReset = false
        };

        _logMessageDebugDedupFlushTimer.Stop();
        _logMessageDebugDedupFlushTimer.Elapsed -= OnLogMessageDebugDedupFlushElapsed;
        _logMessageDebugDedupFlushTimer.Elapsed += OnLogMessageDebugDedupFlushElapsed;
        _logMessageDebugDedupFlushTimer.Start();
    }

    private void StopLogMessageDebugDedupFlushTimer()
    {
        if (_logMessageDebugDedupFlushTimer is null)
        {
            return;
        }

        _logMessageDebugDedupFlushTimer.Stop();
        _logMessageDebugDedupFlushTimer.Elapsed -= OnLogMessageDebugDedupFlushElapsed;
    }

    private void FlushLogMessageDebugDedupUnlocked()
    {
        if (_logMessageDebugDedupKey is null)
        {
            return;
        }

        var output = _logMessageDebugDedupCount > 1
            ? $"{_logMessageDebugDedupKey} (×{_logMessageDebugDedupCount})"
            : _logMessageDebugDedupKey;
        Log.Debug(output);
        _logMessageDebugDedupKey = null;
        _logMessageDebugDedupCount = 0;
    }
}
