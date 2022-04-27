using AutoMapper;
using Satistools.DataReader.Entities;
using Satistools.DataReader.Entities.Buildings;
using Satistools.DataReader.Entities.Recipes;

namespace Satistools.GameData.Recipes;

public static class RecipeMapper
{
    public static IMapper Create(IEnumerable<BuildableManufacturerDescriptor> buildings)
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RecipeDescriptor, Recipe>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(d => d.ManufactoringDuration, opt => opt.MapFrom(src => src.ManufactoringDuration))
                .ForMember(d => d.ManualManufacturingMultiplier, opt => opt.MapFrom(src => src.ManualManufacturingMultipler))
                .ForMember(d => d.Ingredients, opt => opt.Ignore())
                .ForMember(d => d.Products, opt => opt.Ignore())
                .ForMember(d => d.ProducedInId, opt => opt.MapFrom(src => src.ProducedIn.Where(p => buildings.Any(b => b.ClassName == p.ClassName)).Select(p => p.ClassName).Single()))
                .ForMember(d => d.ProducedIn, opt => opt.Ignore())
                .ForMember(d => d.IsAlternate, opt => opt.MapFrom(src => src.ClassName.Contains("_Alternate_")));
        }).CreateMapper();
    }
}