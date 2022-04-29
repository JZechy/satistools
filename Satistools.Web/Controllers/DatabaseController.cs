using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Satistools.GameData;
using Satistools.GameData.Items;
using Satistools.GameData.Recipes;

namespace Satistools.Web.Controllers;

/// <summary>
/// Presents the satisfactory in-game data.
/// </summary>
[ApiController]
[Route("[controller]")]
public class DatabaseController : ControllerBase
{
    private readonly GameDataContext _gameDataContext;

    public DatabaseController(GameDataContext gameDataContext)
    {
        _gameDataContext = gameDataContext;
    }

    /// <summary>
    /// Gets all parsed items from the FactoryGame in the alphabetical order.
    /// </summary>
    /// <returns>Enumeration of available items.</returns>
    [HttpGet]
    [Route("items")]
    public async Task<IEnumerable<Item>> GetItems()
    {
        return await _gameDataContext.Items.Where(i => !i.IsSeasonal).OrderBy(i => i.DisplayName).ToListAsync();
    }

    /// <summary>
    /// Gets information about single item by its ID.
    /// </summary>
    /// <param name="id">Identification of the item as the class name.</param>
    /// <returns>Instance of found item or NotFound.</returns>
    [HttpGet]
    [Route("items/{id}")]
    public async Task<ActionResult<Item>> GetItem(string id)
    {
        Item? item = await _gameDataContext.Items.FindAsync(id);
        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    /// <summary>
    /// Gets all recipes which are producing selected items.
    /// </summary>
    /// <param name="itemId">Identification of the item.</param>
    /// <returns>Collection of recipes producing selected item.</returns>
    [HttpGet]
    [Route("recipes/whoProduces/{itemId}")]
    public async Task<ActionResult<ICollection<Recipe>>> GetRecipesProducing(string itemId)
    {
        List<Recipe> producers = await (
            from recipe in _gameDataContext.Recipes
            join product in _gameDataContext.RecipeProducts on recipe.Id equals product.RecipeId
            where product.ItemId == itemId
            select recipe
        ).Include(r => r.Products).ThenInclude(p => p.Item)
            .Include(r => r.Ingredients).ThenInclude(p => p.Item)
            .ToListAsync();

        return Ok(producers);
    }

    [HttpGet]
    [Route("recipes/whoUses/{itemId}")]
    public async Task<ActionResult<ICollection<Recipe>>> GetRecipesUsing(string itemId)
    {
        List<Recipe> producers = await (
            from recipe in _gameDataContext.Recipes
            join ingredient in _gameDataContext.RecipeIngredients on recipe.Id equals ingredient.RecipeId
            where ingredient.ItemId == itemId
            select recipe
        ).Include(r => r.Products).ThenInclude(p => p.Item)
            .Include(r => r.Ingredients).ThenInclude(p => p.Item)
            .ToListAsync();

        return Ok(producers);
    }
}