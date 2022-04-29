using Satistools.DataReader.Entities.Items;
using Satistools.DataReader.Entities.Recipes;
using Satistools.GameData.Items;

namespace Satistools.GameData.Recipes.Mappers;

/// <summary>
/// Helper class for additional data mapping from the descriptors.
/// </summary>
public static class RecipeMapperHelper
{
    public static int CalculateAmount(RecipeDescriptor.Part part, Item item)
    {
        if (item.Form == ItemForm.Liquid)
        {
            return part.Amount / 1000;
        }

        return part.Amount;
    }
    
    public static float CalculateAmountPerMin(RecipeDescriptor recipe, RecipeDescriptor.Part part, Item item)
    {
        float rate = 60 / recipe.ManufactoringDuration;
        if (item.Form == ItemForm.Liquid)
        {
            return rate * part.Amount / 1000;
        }
        return rate * part.Amount;
    }
}