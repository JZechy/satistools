using Satistools.DataReader.Attributes;

namespace Satistools.DataReader.Entities.Items;

[DataEntity("Class'/Script/FactoryGame.FGEquipmentDescriptor'")]
public class EquipmentDescriptor : ItemDescriptor
{
    public override ItemCategory ItemCategory => ItemCategory.Equipment;
}