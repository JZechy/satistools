using Satistools.Model.Repository;

namespace Satistools.GameData.Recipes;

public interface IRecipeRepository : IRepository<Recipe, string>
{
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