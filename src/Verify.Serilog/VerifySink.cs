class VerifySink : ILogEventSink
{
    public void Emit(LogEvent logEvent) =>
        RecordingLogger.Add(logEvent);
}