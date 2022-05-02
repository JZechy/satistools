using AutoMapper;
using Satistools.DataReader.Entities.Recipes;
using Satistools.GameData.Helpers;
using Satistools.GameData.Items;

namespace Satistools.GameData.Recipes.Mappers;

public static class RecipeProductMapper
{
    public static IMapper Create(RecipeDescriptor recipe, IEnumerable<Item> items)
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RecipeDescriptor.Part, RecipeProduct>()
                .ForMember(d => d.ItemId, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => RecipeMapperHelper.CalculateAmount(src, items.First(i => i.Id == src.ClassName))))
                .ForMember(d => d.RecipeId, opt => opt.MapFrom(src => recipe.ClassName))
                .ForMember(d => d.AmountPerMin, opt => opt.MapFrom(src => RecipeMapperHelper.CalculateAmountPerMin(recipe, src, items.First(i => i.Id == src.ClassName))));
        }).CreateMapper();
    }
}