namespace VerifyTests.Serilog;

public class RecordingLogger : ILogger
{
    static AsyncLocal<EntryTracker?> local = new();

    public static EntryTracker Start(LogEventLevel logLevel = LogEventLevel.Information) =>
        local.Value = new(logLevel);

    public void Write(LogEvent logEvent)
    {
        var tracker = local.Value;
        tracker?.Write(logEvent);
    }

    public ILogger ForContext(string propertyName, object? value, bool destructureObjects = false) =>
        this;

    public static bool TryFinishRecording(out IEnumerable<LogEvent>? entries)
    {
        var provider = local.Value;

        if (provider is null)
        {
            local.Value = null;
            entries = null;
            return false;
        }

        entries = provider.entries.ToArray();
        local.Value = null;
        return true;
    }
}

public class EntryTracker
{
    LogEventLevel level;
    internal ConcurrentQueue<LogEvent> entries = new();

    public EntryTracker(LogEventLevel level) =>
        this.level = level;

    public IEnumerable<LogEvent> Entries => entries;

    public void Write(LogEvent logEvent)
    {
        if (logEvent.Level <= level)
        {
            return;
        }

        entries.Enqueue(logEvent);
    }
}