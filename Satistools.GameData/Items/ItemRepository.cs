using Microsoft.EntityFrameworkCore;
using Satistools.DataReader.Entities.Items;
using Satistools.Model.Repository;

namespace Satistools.GameData.Items;

public class ItemRepository : Repository<Item, string>, IItemRepository
{
    public ItemRepository(RepositoryContext dbContext) : base(dbContext)
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