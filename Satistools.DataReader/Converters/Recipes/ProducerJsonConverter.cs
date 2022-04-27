using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Satistools.DataReader.Entities;

namespace Satistools.DataReader.Converters.Recipes;

public class ProducerJsonConverter : JsonConverter<RecipeDescriptor.Producer[]>
{
    public override RecipeDescriptor.Producer[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Regex regex = new(@"(?<=\.)([A-Za-z0-9_]*)");
        string input = reader.GetString()!;

        return regex.Matches(input).Select(m => new RecipeDescriptor.Producer() { ClassName = m.Value }).ToArray();
    }

    public override void Write(Utf8JsonWriter writer, RecipeDescriptor.Producer[] value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}