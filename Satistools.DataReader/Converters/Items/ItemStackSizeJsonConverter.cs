using System.Text.Json;
using System.Text.Json.Serialization;
using Satistools.DataReader.Entities.Items;

namespace Satistools.DataReader.Converters.Items;

public class ItemStackSizeJsonConverter : JsonConverter<ItemStackSize>
{
    public override ItemStackSize Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString()! switch
        {
            "SS_HUGE" => ItemStackSize.Huge,
            "SS_BIG" => ItemStackSize.Big,
            "SS_MEDIUM" => ItemStackSize.Medium,
            "SS_SMALL" => ItemStackSize.Small,
            _ => ItemStackSize.NotAvailable
        };
    }

    public override void Write(Utf8JsonWriter writer, ItemStackSize value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}