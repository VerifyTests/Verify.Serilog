public class PropertyEnricherConverter :
    WriteOnlyJsonConverter<PropertyEnricher>
{
    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_name")]
    static extern ref string Name(PropertyEnricher enricher);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_value")]
    static extern ref object? Value(PropertyEnricher enricher);

    public override void Write(VerifyJsonWriter writer, PropertyEnricher enricher)
    {
        writer.WriteStartObject();
        var name = Name(enricher);
        var value = Value(enricher);
        writer.WritePropertyName(name);
        if (value == null)
        {
            writer.WriteNull();
        }
        else
        {
            writer.Serialize(value);
        }

        writer.WriteEndObject();
    }
}