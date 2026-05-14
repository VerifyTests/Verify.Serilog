class LogEventPropertyConverter :
    WriteOnlyJsonConverter<LogEventProperty>
{
    public override void Write(VerifyJsonWriter writer, LogEventProperty property)
    {
        writer.WriteStartObject();
        writer.WriteMember(property, property.Value, property.Name);
        writer.WriteEndObject();
    }
}
