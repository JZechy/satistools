using System.Text.RegularExpressions;
using AutoMapper;
using Satistools.DataReader.Entities.Buildings;

namespace Satistools.GameData.Buildings;

public static class BuildingMapper
{
    /// <summary>
    /// Alternate icon names.
    /// </summary>
    /// <remarks>
    /// Some icon names are not named as the shortened building class name.
    /// </remarks>
    private static readonly Dictionary<string, string> IconNames = new()
    {
        { "ManufacturerMk1", "Manufacturer" },
        { "FoundryMk1", "Foundry" },
        { "OilRefinery", "IconDesc_OilRefinery" },
        { "Blender", "IconDesc_Blender" },
        { "Packager", "IconDesc_Packager" },
        { "HadronCollider", "IconDesc_HadronCollider" }
    };

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
            .ForMember(d => d.BuildingType, opt => opt.MapFrom(src => src.BuildingType))
            .ForMember(d => d.IsOverclockable, opt => opt.MapFrom(src => src.CanChangePotential))
            .ForMember(d => d.SmallIcon, opt => opt.MapFrom(src => IconName(src.ClassName, 256)))
            .ForMember(d => d.BigIcon, opt => opt.MapFrom(src => IconName(src.ClassName, 512)));
    }

    private static string IconName(string className, int iconSize)
    {
        Regex regex = new(@"(?<=_).*(?=_)");
        string iconName = regex.Match(className).Value;

        return $"{TranslateIconName(iconName)}_{iconSize}";
    }

    private static string TranslateIconName(string iconName)
    {
        if (IconNames.ContainsKey(iconName))
        {
            return IconNames[iconName];
        }

        return iconName;
    }
}