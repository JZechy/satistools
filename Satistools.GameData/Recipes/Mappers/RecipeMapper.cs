using AutoMapper;
using Satistools.DataReader.Entities.Buildings;
using Satistools.DataReader.Entities.Recipes;

namespace Satistools.GameData.Recipes.Mappers;

/// <summary>
/// Maps RecipesDescriptor to it's datamodel entity.
/// </summary>
public static class RecipeMapper
{
    /// <summary>
    /// List of recipes which is alternate to the original one, yet they don't need to be unlocked via HDD
    /// and are not by default marked as alternate.
    /// </summary>
    private static readonly List<string> OriginalAlternatives = new()
    {
        "Recipe_ResidualPlastic_C",
        "Recipe_ResidualRubber_C",
        "Recipe_LiquidFuel_C",
        "Recipe_UnpackageFuel_C" // TODO: All unpackaging recipes should not be default choice
    };

    public static IMapper Create(IEnumerable<BuildingDescriptor> buildings)
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
                .ForMember(d => d.IsAlternate, opt => opt.MapFrom(src => src.ClassName.Contains("_Alternate_")))
                .ForMember(d => d.IsDefault, opt => opt.MapFrom(src => IsRecipeDefault(src)));
        }).CreateMapper();
    }

    private static bool IsRecipeDefault(RecipeDescriptor descriptor)
    {
        return !descriptor.ClassName.Contains("_Alternate_") && OriginalAlternatives.All(d => d != descriptor.ClassName);
    }
}