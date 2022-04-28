using AutoMapper;
using Satistools.DataReader.Entities;
using Satistools.DataReader.Entities.Items;
using Satistools.DataReader.Entities.Recipes;
using Satistools.GameData.Items;

namespace Satistools.GameData.Recipes;

public static class RecipeIngredientMapper
{
    public static IMapper Create(RecipeDescriptor recipe, IEnumerable<Item> items)
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RecipeDescriptor.Part, RecipeIngredient>()
                .ForMember(d => d.ItemId, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => CalculateAmount(src, items.First(i => i.Id == src.ClassName))))
                .ForMember(d => d.RecipeId, opt => opt.MapFrom(src => recipe.ClassName))
                .ForMember(d => d.AmountPerMin, opt => opt.MapFrom(src => CalculateAmountPerMin(recipe, src, items.First(i => i.Id == src.ClassName))));
        }).CreateMapper();
    }

    private static int CalculateAmount(RecipeDescriptor.Part part, Item item)
    {
        if (item.Form == ItemForm.Liquid)
        {
            return part.Amount / 1000;
        }

        return part.Amount;
    }

    private static float CalculateAmountPerMin(RecipeDescriptor recipe, RecipeDescriptor.Part part, Item item)
    {
        float rate = 60 / recipe.ManufactoringDuration;
        if (item.Form == ItemForm.Liquid)
        {
            return rate * part.Amount / 1000;
        }

        return rate * part.Amount;
    }
}