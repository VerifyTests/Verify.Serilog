using System.Diagnostics.CodeAnalysis;

namespace VerifyTests.Serilog;

public static class RecordingLogger
{
    static AsyncLocal<ConcurrentQueue<LogEvent>?> local = new();

    public static void Start() =>
        local.Value = new();

    internal static void Add(LogEvent logEvent)
    {
        var tracker = local.Value;
        tracker?.Enqueue(logEvent);
    }

    public static bool TryFinishRecording([NotNullWhen(true)] out IReadOnlyCollection<LogEvent>? entries)
    {
        var events = local.Value;

        local.Value = null;
        if (events is null)
        {
            local.Value = null;
            entries = null;
            return false;
        }

        entries = events;
        return true;
    }

    public static IReadOnlyCollection<LogEvent> FinishRecording()
    {
        var events = local.Value;

        local.Value = null;
        if (events is null)
        {
            return Array.Empty<LogEvent>();
        }

        return events;
    }
}