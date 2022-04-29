using AutoMapper;
using Satistools.DataReader.Entities.Items;

namespace Satistools.GameData.Items;

public static class ItemMapper
{
    /// <summary>
    /// List of event items.
    /// </summary>
    private static readonly string[] EventItems = {
        "BP_EquipmentDescriptorCandyCane_C",
        "BP_EquipmentDescriptorSnowballMittens_C",
        "Desc_CandyCane_C",
        "Desc_Gift_C",
        "Desc_Snow_C",
        "Desc_SnowballProjectile_C",
        "Desc_XmasBall1_C",
        "Desc_XmasBall2_C",
        "Desc_XmasBall3_C",
        "Desc_XmasBall4_C",
        "Desc_XmasBallCluster_C",
        "Desc_XmasBow_C",
        "Desc_XmasBranch_C",
        "Desc_XmasStar_C",
        "Desc_XmasWreath_C",
        "Desc_CandyCaneDecor_C",
        "Desc_Snowman_C",
        "Desc_WreathDecor_C",
        "Desc_XmassTree_C",
        "Desc_Fireworks_Projectile_01_C",
        "Desc_Fireworks_Projectile_02_C",
        "Desc_Fireworks_Projectile_03_C"
    };
    
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
            .ForMember(d => d.ItemCategory, opt => opt.MapFrom(src => src.ItemCategory))
            .ForMember(d => d.Form, opt => opt.MapFrom(src => src.Form))
            .ForMember(d => d.StackSize, opt => opt.MapFrom(src => src.StackSize))
            .ForMember(d => d.IsRadioactive, opt => opt.MapFrom(src => src.RadioactiveDecay > 0))
            .ForMember(d => d.FluidColor, opt => opt.MapFrom(src => src.FluidColor))
            .ForMember(d => d.GasColor, opt => opt.MapFrom(src => src.GasColor))
            .ForMember(d => d.ResourceSinkPoints, opt => opt.MapFrom(src => src.ResourceSinkPoints))
            .ForMember(d => d.SmallIcon, opt => opt.MapFrom(src => src.SmallIcon))
            .ForMember(d => d.BigIcon, opt => opt.MapFrom(src => src.PersistentBigIcon))
            .ForMember(d => d.IsProjectAssembly, opt => opt.MapFrom(src => src.ClassName.Contains("SpaceElevatorPart")))
            .ForMember(d => d.IsSeasonal, opt => opt.MapFrom(src => EventItems.Contains(src.ClassName)));
    }
}