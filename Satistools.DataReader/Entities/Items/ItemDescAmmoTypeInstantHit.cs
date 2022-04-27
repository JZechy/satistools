using System.Text.Json;
using System.Text.Json.Serialization;
using Satistools.DataReader.Attributes;

namespace Satistools.DataReader.Entities.Items;

[DataEntity("Class'/Script/FactoryGame.FGItemDescAmmoTypeInstantHit'")]
public class ItemDescAmmoTypeInstantHit : ItemDescriptor
{
    [JsonExtensionData]
    public Dictionary<string, JsonElement> ExtensionData { get; set; } = new();
}