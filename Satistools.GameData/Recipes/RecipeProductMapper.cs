using AutoMapper;
using Satistools.DataReader.Entities;

namespace Satistools.GameData.Recipes;

public static class RecipeProductMapper
{
    public static IMapper Create(RecipeDescriptor recipeDescriptor)
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RecipeDescriptor.Part, RecipeProduct>()
                .ForMember(d => d.ItemId, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(d => d.RecipeId, opt => opt.MapFrom(src => recipeDescriptor.ClassName));
        }).CreateMapper();
    }
}