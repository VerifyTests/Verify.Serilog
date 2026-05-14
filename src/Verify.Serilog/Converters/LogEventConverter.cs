class LogEventConverter :
    WriteOnlyJsonConverter<LogEvent>
{
    public override void Write(VerifyJsonWriter writer, LogEvent logEvent)
    {
        writer.WriteStartObject();
        writer.WritePropertyName(LevelName(logEvent.Level));
        writer.WriteValue(logEvent.MessageTemplate.Text);
        writer.WriteMember(logEvent, logEvent.Properties, "Properties");
        writer.WriteEndObject();
    }

    static string LevelName(LogEventLevel level) =>
        level switch
        {
            LogEventLevel.Verbose => "Verbose",
            LogEventLevel.Debug => "Debug",
            LogEventLevel.Information => "Information",
            LogEventLevel.Warning => "Warning",
            LogEventLevel.Error => "Error",
            LogEventLevel.Fatal => "Fatal",
            _ => level.ToString()
        };
}