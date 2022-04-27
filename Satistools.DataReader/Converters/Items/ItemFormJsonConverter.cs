using System.Text.Json;
using System.Text.Json.Serialization;
using Satistools.DataReader.Entities.Items;

namespace Satistools.DataReader.Converters.Items;

public class ItemFormJsonConverter : JsonConverter<ItemForm>
{
    public override ItemForm Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString()! switch
        {
            "RF_SOLID" => ItemForm.Solid,
            "RF_INVALID" => ItemForm.Invalid,
            "RF_LIQUID" => ItemForm.Liquid,
            _ => ItemForm.NotAvailable
        };
    }

    public override void Write(Utf8JsonWriter writer, ItemForm value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}