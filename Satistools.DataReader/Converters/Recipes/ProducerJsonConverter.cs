using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Satistools.DataReader.Entities;

namespace Satistools.DataReader.Converters.Recipes;

public class ProducerJsonConverter : JsonConverter<Recipe.Producer[]>
{
    public override Recipe.Producer[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Regex regex = new(@"(?<=\.)([A-Za-z0-9_]*)");
        string input = reader.GetString()!;

        return regex.Matches(input).Select(m => new Recipe.Producer() { ClassName = m.Value }).ToArray();
    }

    public override void Write(Utf8JsonWriter writer, Recipe.Producer[] value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}