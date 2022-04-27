namespace Satistools.GameData.Recipes;

/// <summary>
/// Represents an in-game recipe.
/// </summary>
public class Recipe
{
    /// <summary>
    /// 
    /// </summary>
    public string Id { get; set; } = string.Empty;
    
    /// <summary>
    /// Full name of recipe.
    /// </summary>
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// How long does it take to produce this item.
    /// </summary>
    public float ManufactoringDuration { get; set; }
    
    /// <summary>
    /// TODO: How this works? is there multipler other than one?
    /// </summary>
    public float ManualManufacturingMultiplier { get; set; }

    public ICollection<RecipeIngredient> Ingredients { get; set; } = Array.Empty<RecipeIngredient>();
    public ICollection<RecipeProduct> Products { get; set; } = Array.Empty<RecipeProduct>();

    /// <summary>
    /// Gets the rate to calculate the production per minut.
    /// </summary>
    public float PerMin => 60 / ManufactoringDuration;
}