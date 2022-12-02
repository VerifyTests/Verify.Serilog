class LogEventConverter :
    WriteOnlyJsonConverter<LogEvent>
{
    public override void Write(VerifyJsonWriter writer, LogEvent logEvent)
    {
        writer.WriteStartObject();
        var template = logEvent.MessageTemplate;
        writer.WritePropertyName(logEvent.Level.ToString());
        writer.WriteValue(template.Text);
        writer.WriteMember(logEvent, logEvent.Properties, "Properties");
        writer.WriteEndObject();
    }
}