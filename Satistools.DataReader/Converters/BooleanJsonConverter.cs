using System.Text.Json;
using System.Text.Json.Serialization;

namespace Satistools.DataReader.Converters;

public class BooleanJsonConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return bool.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}