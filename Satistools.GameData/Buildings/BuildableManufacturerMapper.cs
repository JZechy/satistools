using AutoMapper;
using Satistools.DataReader.Entities;
using Satistools.DataReader.Entities.Buildings;

namespace Satistools.GameData.Buildings;

public static class BuildableManufacturerMapper
{
    public static IMapper Create()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<BuildableManufacturerDescriptor, BuildableManufacturer>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(d => d.PowerConsumption, opt => opt.MapFrom(src => src.PowerConsumption))
                .ForMember(d => d.PowerConsumptionExponent, opt => opt.MapFrom(src => src.PowerConsumptionExponent))
                .ForMember(d => d.IsOverclockable, opt => opt.MapFrom(src => src.CanChangePotential));
        }).CreateMapper();
    }
}