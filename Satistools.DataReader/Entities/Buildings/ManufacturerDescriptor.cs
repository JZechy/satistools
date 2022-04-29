using System.Text.Json.Serialization;
using Satistools.DataReader.Attributes;

namespace Satistools.DataReader.Entities.Buildings;

/// <summary>
/// Describes manufacturing buildings like smelters or constructors.
/// </summary>
[DataEntity("Class'/Script/FactoryGame.FGBuildableManufacturer'")]
public class ManufacturerDescriptor : BuildingDescriptor
{
    [JsonPropertyName("mPowerConsumption")]
    public float PowerConsumption { get; set; }

    [JsonPropertyName("mPowerConsumptionExponent")]
    public float PowerConsumptionExponent { get; set; }
    
    public override BuildingType BuildingType => BuildingType.Manufactuer;
}