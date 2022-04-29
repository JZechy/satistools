using System.Text.RegularExpressions;
using AutoMapper;
using Satistools.DataReader.Entities.Buildings;

namespace Satistools.GameData.Buildings;

public static class BuildingMapper
{
    public static IMapper Create()
    {
        return new MapperConfiguration(cfg =>
        {
            MapBuildingDescriptor<FrackingActivatorDescriptor>(cfg);
            MapBuildingDescriptor<FrackingExtractorDescriptor>(cfg);
            MapBuildingDescriptor<ManufacturerDescriptor>(cfg);
            MapBuildingDescriptor<ManufacturerVariablePowerDescriptor>(cfg);
            MapBuildingDescriptor<NuclearGeneratorDescriptor>(cfg);
            MapBuildingDescriptor<PowerGeneratorDescriptor>(cfg);
            MapBuildingDescriptor<ResourceExtractorDescriptor>(cfg);
            MapBuildingDescriptor<WaterPumpDescriptor>(cfg);
        }).CreateMapper();
    }

    private static void MapBuildingDescriptor<TDescriptor>(IProfileExpression cfg) where TDescriptor : BuildingDescriptor
    {
        cfg.CreateMap<TDescriptor, Building>()
            .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
            .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
            .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(d => d.IsOverclockable, opt => opt.MapFrom(src => src.CanChangePotential))
            .ForMember(d => d.SmallIcon, opt => opt.MapFrom(src => IconName(src.ClassName, 256)))
            .ForMember(d => d.BigIcon, opt => opt.MapFrom(src => IconName(src.ClassName, 512)));
    }

    private static string IconName(string className, int iconSize)
    {
        Regex regex = new(@"(?<=_).*(?=_)");

        return $"{regex.Match(className).Value}_{iconSize}";
    }
}