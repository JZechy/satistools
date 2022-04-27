using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Satistools.DataReader.Entities;

namespace Satistools.DataReader.Converters.Recipes;

public class PartJsonConverter : JsonConverter<RecipeDescriptor.Part[]>
{
    public override RecipeDescriptor.Part[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Regex regex = new(@"ItemClass=(?:[a-zA-Z'""\/_]*)\.([A-Za-z_]*)[""']*,Amount=(\d*)");
        string parts = reader.GetString()!;

        return regex.Matches(parts).Select(m => new RecipeDescriptor.Part { ClassName = m.Groups[1].Value, Amount = int.Parse(m.Groups[2].Value) }).ToArray();
    }

    public override void Write(Utf8JsonWriter writer, RecipeDescriptor.Part[] value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}