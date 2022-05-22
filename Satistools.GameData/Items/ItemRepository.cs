using Microsoft.EntityFrameworkCore;
using Sagittaras.Repository;
using Satistools.DataReader.Entities.Items;

namespace Satistools.GameData.Items;

public class ItemRepository : Repository<Item, string>, IItemRepository
{
    public ItemRepository(DbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Item>> FindAutomatedProducts()
    {
        return await Queryable
            .Where(i => !i.IsSeasonal)
            .Where(i => i.ItemCategory != ItemCategory.Equipment && i.ItemCategory != ItemCategory.Consumable)
            .OrderBy(i => i.DisplayName)
            .ToListAsync();
    }
}