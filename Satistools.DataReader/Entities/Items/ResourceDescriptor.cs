using Satistools.DataReader.Attributes;

namespace Satistools.DataReader.Entities.Items;

[DataEntity("Class'/Script/FactoryGame.FGResourceDescriptor'")]
public class ResourceDescriptor : ItemDescriptor
{
    public override ItemCategory ItemCategory => ItemCategory.Resource;
}