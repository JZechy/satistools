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
    private static void MapDescriptor<TDescriptor>(IProfileExpression cfg) where TDescriptor : ItemDescriptor
    {
        cfg.CreateMap<TDescriptor, Item>()
            .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
            .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
            .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(d => d.Form, opt => opt.MapFrom(src => src.Form))
            .ForMember(d => d.StackSize, opt => opt.MapFrom(src => src.StackSize))
            .ForMember(d => d.IsRadioactive, opt => opt.MapFrom(src => src.RadioactiveDecay > 0))
            .ForMember(d => d.FluidColor, opt => opt.MapFrom(src => src.FluidColor))
            .ForMember(d => d.GasColor, opt => opt.MapFrom(src => src.GasColor))
            .ForMember(d => d.ResourceSinkPoints, opt => opt.MapFrom(src => src.ResourceSinkPoints));
    }
}