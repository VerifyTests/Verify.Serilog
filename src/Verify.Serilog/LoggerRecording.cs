using Serilog;
using Serilog.Core;

namespace VerifyTests.Serilog;

public static class LoggerRecording
{
    static AsyncLocal<RecordingLogger?> local = new();

    public static RecordingLogger Start(LogEventLevel logLevel = LogEventLevel.Information)
    {
        return local.Value = new(logLevel);
    }

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

public class RecordingLogger:Ilogger
{
    public RecordingLogger(LogEventLevel logLevel)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(logLevel)
            .WriteTo.Sink(this)
            .CreateLogger();
    }

    public List<object> entries = new();

    public void Emit(LogEvent logEvent)
    {
        entries.Add(logEvent);
    }
}
{
}

public class RecordingSink:ILogEventSink   
{
    ConcurrentQueue<LogEvent> entries = new();
    public void Emit(LogEvent logEvent) =>
        throw new NotImplementedException();
}