using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Satistools.GameData;
using Satistools.GameData.Items;

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
        return await _gameDataContext.Items.Where(i => !i.IsEvent).OrderBy(i => i.DisplayName).ToListAsync();
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
}