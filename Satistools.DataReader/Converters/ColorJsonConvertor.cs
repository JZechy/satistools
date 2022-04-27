using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Satistools.DataReader.Converters;

public class ColorJsonConvertor : JsonConverter<Color>
{
    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Regex regex = new(@"([RGBA])(?:\=)(\d{1,3})");
        string color = reader.GetString()!;
        int[] values = regex.Matches(color).Select(m => m.Groups).OrderBy(g =>
        {
            return g[1].Value switch
            {
                "A" => 1,
                "R" => 2,
                "G" => 3,
                "B" => 4,
                _ => throw new ArgumentOutOfRangeException()
            };
        }).Select(g => int.Parse(g[2].Value)).ToArray();

        return Color.FromArgb(values[0], values[1], values[2], values[3]);
    }

    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}