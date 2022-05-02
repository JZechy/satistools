using Satistools.DataReader.Entities.Items;
using Satistools.DataReader.Entities.Recipes;
using Satistools.GameData.Items;

namespace Satistools.GameData.Helpers;

/// <summary>
/// Helper class for additional data mapping from the descriptors.
/// </summary>
public static class RecipeMapperHelper
{
    public static int CalculateAmount(RecipeDescriptor.Part part, Item item)
    {
        if (item.Form is ItemForm.Liquid or ItemForm.Gas)
        {
            return part.Amount / 1000;
        }

        return part.Amount;
    }
    
    public static float CalculateAmountPerMin(RecipeDescriptor recipe, RecipeDescriptor.Part part, Item item)
    {
        float rate = 60 / recipe.ManufactoringDuration;
        if (item.Form is ItemForm.Liquid or ItemForm.Gas)
        {
            return rate * part.Amount / 1000;
        }
        return rate * part.Amount;
    }
}