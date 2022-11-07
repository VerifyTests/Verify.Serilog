class LogEventConverter :
    WriteOnlyJsonConverter<LogEvent>
{
    public override void Write(VerifyJsonWriter writer, LogEvent logEvent)
    {
        writer.WriteStartObject();
        writer.WriteMember(logEvent.MessageTemplate, logEvent.MessageTemplate.Text, "MessageTemplate");
        writer.WriteMember(logEvent, logEvent.Level, "Level");
        writer.WriteMember(logEvent, logEvent.Properties, "Properties");
        writer.WriteEndObject();
    }
}