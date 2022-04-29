using System.Text.Json.Serialization;
using Satistools.DataReader.Attributes;
using Satistools.DataReader.Converters;

namespace Satistools.DataReader.Entities.Buildings;

[DataEntity("Class'/Script/FactoryGame.FGBuildableGeneratorFuel'")]
public class PowerGeneratorDescriptor : BuildingDescriptor
{
    [JsonPropertyName("mPowerProduction")]
    public float PowerProduction { get; set; }
    
    [JsonPropertyName("mPowerProductionExponent")]
    public float PowerProductionExponent { get; set; }
    
    [JsonPropertyName("mCanChangePotential")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool CanChangePotential { get; set; }

    public override BuildingType BuildingType => BuildingType.PowerGenerator;
}