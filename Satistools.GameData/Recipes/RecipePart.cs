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
    
    /// <summary>
    /// How many items are needed or produced per min.
    /// </summary>
    public float AmountPerMin { get; set; }
    
    public Item Item { get; set; } = null!;
}