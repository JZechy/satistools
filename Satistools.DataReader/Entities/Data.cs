using System.Text.Json.Nodes;

namespace Satistools.DataReader.Entities;

/// <summary>
/// A root element describing descriptor entites inside of data.json.
/// </summary>
public class Data
{
    /// <summary>
    /// The name of the class descriptor.
    /// </summary>
    public string NativeClass { get; set; } = string.Empty;

    /// <summary>
    /// Node containing all data of the descriptor.
    /// </summary>
    public JsonNode[] Classes { get; set; } = Array.Empty<JsonNode>();
}