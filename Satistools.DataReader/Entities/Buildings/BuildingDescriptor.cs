using System.Text.Json.Serialization;

namespace Satistools.DataReader.Entities.Buildings;

/// <summary>
/// Basic descriptor grouping together the repeated building data.
/// </summary>
public abstract class BuildingDescriptor
{
    public string ClassName { get; set; } = string.Empty;
    
    [JsonPropertyName("mDisplayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("mDescription")]
    public string Description { get; set; } = string.Empty;

    public abstract BuildingType BuildingType { get; }
}