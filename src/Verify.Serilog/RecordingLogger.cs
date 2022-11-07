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

    public static bool TryFinishRecording(out IEnumerable<LogEvent>? entries)
    {
        var events = local.Value;

        if (events is null)
        {
            local.Value = null;
            entries = null;
            return false;
        }

        entries = events.ToArray();
        local.Value = null;
        return true;
    }
}