using Microsoft.AspNetCore.Mvc;
using Satistools.GameData.Recipes;

namespace Satistools.Web.Controllers.Database;

/// <summary>
/// Database of Satisfactory recipes.
/// </summary>
[ApiController]
[Route("api/database/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeRepository _recipeRepository;

    public RecipesController(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    /// <summary>
    /// Gets all recipes which are producing selected item.
    /// </summary>
    /// <param name="itemId">Identification of the item.</param>
    /// <returns>Collection of recipes producing selected item with full data.</returns>
    [HttpGet]
    [Route("whoProduces/{itemId}")]
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
    [Route("whoUses/{itemId}")]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipesUsing(string itemId)
    {
        return Ok(await _recipeRepository.FindRecipesUsingItem(itemId));
    }
}