using Microsoft.AspNetCore.Mvc;
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
    private readonly IItemRepository _itemRepository;
    private readonly IRecipeRepository _recipeRepository;

    public DatabaseController(IItemRepository itemRepository, IRecipeRepository recipeRepository)
    {
        _itemRepository = itemRepository;
        _recipeRepository = recipeRepository;
    }

    /// <summary>
    /// Gets all parsed items from the FactoryGame in the alphabetical order.
    /// </summary>
    /// <returns>Enumeration of available items.</returns>
    [HttpGet]
    [Route("items")]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems()
    {
        return Ok(await _itemRepository.FindAutomatedProducts());
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
        Item? item = await _itemRepository.Get(id);
        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    /// <summary>
    /// Gets all recipes which are producing selected item.
    /// </summary>
    /// <param name="itemId">Identification of the item.</param>
    /// <returns>Collection of recipes producing selected item with full data.</returns>
    [HttpGet]
    [Route("recipes/whoProduces/{itemId}")]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipesProducing(string itemId)
    {
        return Ok(await _recipeRepository.FindRecipesProducingItem(itemId));
    }

    /// <summary>
    /// Gets all recipes which are using selecte item.
    /// </summary>
    /// <param name="itemId">Identification of item.</param>
    /// <returns>Recipes which are using the selected items with full data.</returns>
    [HttpGet]
    [Route("recipes/whoUses/{itemId}")]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipesUsing(string itemId)
    {
        return Ok(await _recipeRepository.FindRecipesUsingItem(itemId));
    }
}