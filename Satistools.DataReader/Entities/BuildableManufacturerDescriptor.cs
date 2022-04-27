using System.Text.Json;
using System.Text.Json.Serialization;
using Satistools.DataReader.Attributes;

namespace Satistools.DataReader.Entities;

/// <summary>
/// Describes manufacturing buildings like smelters or constructors.
/// </summary>
[DataEntity("Class'/Script/FactoryGame.FGBuildableManufacturer'")]
public class BuildableManufacturerDescriptor
{
    public string ClassName { get; set; } = string.Empty;

    [JsonPropertyName("mDisplayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("mDescription")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("mPowerConsumption")]
    public float PowerConsumption { get; set; }
    
    [JsonPropertyName("mPowerConsumptionExponent")]
    public float PowerConsumptionExponent { get; set; }

    /// <summary>
    /// Extra data describing the building not introduced as entity.
    /// </summary>
    /// <remarks>
    /// Different types of manufacturers has custom fields, and is not possible
    /// to introduce them all.
    /// </remarks>
    [JsonExtensionData]
    public Dictionary<string, JsonElement> ExtensionData { get; set; } = new();
}