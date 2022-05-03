using Satistools.Model.Repository;

namespace Satistools.GameData.Recipes;

public interface IRecipeRepository : IRepository<Recipe, string>
{
    /// <summary>
    /// Gets the original which is used for production of the item.
    /// </summary>
    /// <remarks>
    /// By original recipe is meant the one, which is not marked as alternate.
    /// </remarks>
    /// <param name="itemId">ID of item used for production of the item.</param>
    /// <returns>Instance of original recipe for the item or null, if there is no original recipe.</returns>
    Task<Recipe?> GetOriginalRecipe(string itemId);

    /// <summary>
    /// Search recipes by their IDs.
    /// </summary>
    /// <param name="recipeIds">Enumerable of all IDs which should be found.</param>
    /// <returns>Enumeration of all found recipes.</returns>
    Task<IEnumerable<Recipe>> FindByIds(IEnumerable<string> recipeIds);

    /// <summary>
    /// Finds all recipes which are producing selected item.
    /// </summary>
    /// <param name="itemId">Item which be should be produced by the recipes.</param>
    /// <returns>Enumerable of all recipes producing selected item.</returns>
    Task<IEnumerable<Recipe>> FindRecipesProducingItem(string itemId);

    /// <summary>
    /// Finds all recipes which are using selected item.
    /// </summary>
    /// <param name="itemId">Item which should be used by the recipes.</param>
    /// <returns>Enumerable of all recipes using selected item.</returns>
    Task<IEnumerable<Recipe>> FindRecipesUsingItem(string itemId);
}