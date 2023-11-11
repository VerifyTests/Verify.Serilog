class VerifySink : ILogEventSink
{
    public void Emit(LogEvent logEvent) =>
        Recording.Add("logs", logEvent);
}