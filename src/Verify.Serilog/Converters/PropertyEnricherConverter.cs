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
        writer.WriteMember(enricher, Value(enricher), Name(enricher));
        writer.WriteEndObject();
    }
}