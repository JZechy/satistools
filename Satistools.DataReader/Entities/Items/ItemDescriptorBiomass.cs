using Satistools.DataReader.Attributes;

namespace Satistools.DataReader.Entities.Items;

[DataEntity("Class'/Script/FactoryGame.FGItemDescriptorBiomass'")]
public class ItemDescriptorBiomass : ItemDescriptor
{
    public override ItemCategory ItemCategory => ItemCategory.Biomass;
}