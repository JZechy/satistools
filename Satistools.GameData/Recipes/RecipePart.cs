using Satistools.DataReader.Entities.Items;
using Satistools.GameData.Items;

namespace Satistools.GameData.Recipes;

/// <summary>
/// Class representing a part of recipe.
/// </summary>
public abstract class RecipePart
{
    public string RecipeId { get; set; } = string.Empty;
    public string ItemId { get; set; } = string.Empty;
    
    /// <summary>
    /// How many items are needed by this ingredient.
    /// </summary>
    public int Amount { get; set; }

    public Recipe Recipe { get; set; } = null!;
    public Item Item { get; set; } = null!;

    /// <summary>
    /// Returns how many items are needed per minut.
    /// </summary>
    public float PerMin
    {
        get
        {
            if (Item.Form == ItemForm.Liquid)
            {
                return Recipe.PerMin * Amount / 1000;
            }

            return Recipe.PerMin * Amount;
        }
    }
}