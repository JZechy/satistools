using AutoMapper;
using Satistools.DataReader.Entities;

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
                .ForMember(d => d.ProducedIn, opt => opt.Ignore());
        }).CreateMapper();
    }
}