class DictionaryValueConverter :
    WriteOnlyJsonConverter<DictionaryValue>
{
    public override void Write(VerifyJsonWriter writer, DictionaryValue value) =>
        writer.Serialize(value.Elements.ToDictionary(_ => _.Key.Value!, _ => _.Value));
}