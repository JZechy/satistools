using Microsoft.EntityFrameworkCore;
using Satistools.Model.Repository;

namespace Satistools.GameData.Recipes;

public class RecipeRepository : Repository<Recipe, string>, IRecipeRepository
{
    public RecipeRepository(RepositoryContext dbContext) : base(dbContext)
    {
    }

    /// <summary>
    /// Provides a <see cref="IQueryable{T}"/> datasource which provides eagerly loaded
    /// all related entities.
    /// </summary>
    private IQueryable<Recipe> FullInfoSource => Queryable
        .Include(r => r.Products).ThenInclude(p => p.Item)
        .Include(r => r.Ingredients).ThenInclude(i => i.Item)
        .Include(r => r.ProducedIn)
        .AsSplitQuery();

    /// <inheritdoc />
    public async Task<IEnumerable<Recipe>> FindRecipesProducingItem(string itemId)
    {
        return await (from recipe in FullInfoSource
            join product in JoinDbSet<RecipeProduct>() on recipe.Id equals product.RecipeId
            where product.ItemId == itemId
            select recipe).ToListAsync();
    }

    /// <inheritdoc />  
    public async Task<IEnumerable<Recipe>> FindRecipesUsingItem(string itemId)
    {
        return await (
            from recipe in FullInfoSource
            join ingredient in JoinDbSet<RecipeIngredient>() on recipe.Id equals ingredient.RecipeId
            where ingredient.ItemId == itemId
            select recipe).ToListAsync();
    }
}