using AutoMapper;
using Satistools.DataReader.Entities.Items;

namespace Satistools.GameData.Items;

public static class ItemMapper
{
    public static IMapper Create()
    {
        return new MapperConfiguration(cfg =>
        {
            MapDescriptor<ItemDescriptor>(cfg);
            MapDescriptor<ResourceDescriptor>(cfg);
            MapDescriptor<ItemDescriptorBiomass>(cfg);
            MapDescriptor<ConsumableDescriptor>(cfg);
            MapDescriptor<EquipmentDescriptor>(cfg);
            MapDescriptor<ItemDescAmmoTypeProjectile>(cfg);
            MapDescriptor<ItemDescriptorNuclearFuel>(cfg);
            MapDescriptor<ItemDescAmmoTypeInstantHit>(cfg);
            MapDescriptor<ItemDescAmmoTypeColorCartridge>(cfg);
        }).CreateMapper();
    }

    /// <summary>
    /// Maps a item descriptor class to Item entity.
    /// </summary>
    /// <param name="cfg">Mapper configuration class.</param>
    /// <typeparam name="TDescriptor">Type of mapped descriptor.</typeparam>
    private static void MapDescriptor<TDescriptor>(IProfileExpression cfg) where TDescriptor : class, IItemDescriptor
    {
        cfg.CreateMap<TDescriptor, Item>()
            .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
            .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
            .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
    }
}