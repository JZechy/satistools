using Satistools.GameData.Items;

namespace Satistools.GameData.Recipes;

/// <summary>
/// Description of needed ingredient by the recipe.
/// </summary>
public class RecipeIngredient
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
    public float PerMin => Recipe.PerMin * Amount;
}