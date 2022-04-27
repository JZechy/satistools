using AutoMapper;
using Satistools.DataReader.Entities;
using Satistools.DataReader.Entities.Items;

namespace Satistools.GameData.Items;

public static class ItemMapper
{
    public static IMapper Create()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ItemDescriptor, Item>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
            
            cfg.CreateMap<ResourceDescriptor, Item>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
            
            cfg.CreateMap<ItemDescriptorBiomass, Item>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
            
            cfg.CreateMap<ConsumableDescriptor, Item>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
            
            cfg.CreateMap<EquipmentDescriptor, Item>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
            
            cfg.CreateMap<ItemDescAmmoTypeProjectile, Item>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
            
            cfg.CreateMap<ItemDescriptorNuclearFuel, Item>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
            
            cfg.CreateMap<ItemDescAmmoTypeInstantHit, Item>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
            
            cfg.CreateMap<ItemDescAmmoTypeColorCartridge, Item>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description));
        }).CreateMapper();
    }
}