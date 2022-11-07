class LogEventConverter :
    WriteOnlyJsonConverter<LogEvent>
{
    public override void Write(VerifyJsonWriter writer, LogEvent logEvent)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("MessageTemplate");
        writer.Serialize(logEvent.MessageTemplate.Text);
        writer.WritePropertyName("Level");
        writer.Serialize(logEvent.Level);
        writer.WritePropertyName("Properties");
        writer.Serialize(logEvent.Properties);
        writer.WriteEndObject();
    }
}