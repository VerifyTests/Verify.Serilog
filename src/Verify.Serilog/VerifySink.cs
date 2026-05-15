class VerifySink : ILogEventSink
{
    public void Emit(LogEvent logEvent)
    {
        if (IsIgnored(logEvent))
        {
            return;
        }

        Recording.Add("log", logEvent);
    }

    static bool IsIgnored(LogEvent logEvent)
    {
        var ignored = VerifySerilog.IgnoredSourceContexts;
        if (ignored.Count == 0)
        {
            return false;
        }

        if (!logEvent.Properties.TryGetValue("SourceContext", out var value))
        {
            return false;
        }

        return value is ScalarValue { Value: string sourceContext } &&
               ignored.Contains(sourceContext);
    }
}
