using Microsoft.AspNetCore.Mvc;
using Satistools.GameData.Items;

namespace Satistools.Web.Controllers.Database;

/// <summary>
/// Database of satisfactory items.
/// </summary>
[ApiController]
[Route("database/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemRepository _itemRepository;

    public ItemsController(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    
    /// <summary>
    /// Gets all parsed items from the FactoryGame in the alphabetical order.
    /// </summary>
    /// <returns>Enumeration of available items.</returns>
    [HttpGet]
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
    [Route("{id}")]
    public async Task<ActionResult<Item>> GetItem(string id)
    {
        Item? item = await _itemRepository.Get(id);
        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }
}