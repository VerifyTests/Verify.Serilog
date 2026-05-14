class StructureValueConverter :
    WriteOnlyJsonConverter<StructureValue>
{
    public override void Write(VerifyJsonWriter writer, StructureValue value)
    {
        writer.WriteStartObject();
        if (value.TypeTag != null)
        {
            writer.WriteMember(value, value.TypeTag, "TypeTag");
        }

        foreach (var property in value.Properties)
        {
            writer.WriteMember(value, property.Value, property.Name);
        }

        writer.WriteEndObject();
    }
}
