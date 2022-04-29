using System.Text.Json.Serialization;
using Satistools.DataReader.Converters;

namespace Satistools.DataReader.Entities.Buildings;

/// <summary>
/// Basic descriptor grouping together the repeated building data.
/// </summary>
public class BuildingDescriptor
{
    public string ClassName { get; set; } = string.Empty;
    
    [JsonPropertyName("mDisplayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("mDescription")]
    public string Description { get; set; } = string.Empty;
    
    [JsonPropertyName("mCanChangePotential")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool CanChangePotential { get; set; }

    public virtual BuildingType BuildingType { get; } = BuildingType.NotAvailable;
}