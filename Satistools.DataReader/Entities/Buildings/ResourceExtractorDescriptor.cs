using System.Text.Json.Serialization;
using Satistools.DataReader.Attributes;
using Satistools.DataReader.Converters;

namespace Satistools.DataReader.Entities.Buildings;

[DataEntity("Class'/Script/FactoryGame.FGBuildableResourceExtractor'")]
public class ResourceExtractorDescriptor : BuildingDescriptor
{
    [JsonPropertyName("mPowerConsumption")]
    public float PowerConsumption { get; set; }

    [JsonPropertyName("mPowerConsumptionExponent")]
    public float PowerConsumptionExponent { get; set; }

    public override BuildingType BuildingType => BuildingType.ResourceExtractor;
}