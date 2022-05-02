using Satistools.GameData.Buildings;

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

    /// <summary>
    /// In which building is the recipe produced.
    /// </summary>
    public string ProducedInId { get; set; } = string.Empty;
    
    /// <summary>
    /// Marks if the recipe is alternative.
    /// </summary>
    public bool IsAlternate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Building ProducedIn { get; set; } = null!;

    public ICollection<RecipeIngredient> Ingredients { get; set; } = null!;
    public ICollection<RecipeProduct> Products { get; set; } = null!;

    /// <summary>
    /// Gets the recipe product by ID of item.
    /// </summary>
    /// <param name="id">Item identification.</param>
    /// <returns>Found recipe product.</returns>
    public RecipeProduct GetProduct(string id)
    {
        return Products.Single(p => p.ItemId == id);
    }
}