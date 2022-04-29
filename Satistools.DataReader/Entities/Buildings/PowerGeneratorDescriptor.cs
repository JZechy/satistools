using System.Text.Json.Serialization;
using Satistools.DataReader.Attributes;

namespace Satistools.DataReader.Entities.Buildings;

[DataEntity("Class'/Script/FactoryGame.FGBuildableGeneratorFuel'")]
public class PowerGeneratorDescriptor : BuildingDescriptor
{
    [JsonPropertyName("mPowerProduction")]
    public float PowerProduction { get; set; }
    
    [JsonPropertyName("mPowerProductionExponent")]
    public float PowerProductionExponent { get; set; }

    public override BuildingType BuildingType => BuildingType.PowerGenerator;
}