using Satistools.Model.Repository;

namespace Satistools.GameData.Items;

public class ItemRepository : Repository<Item, string>, IItemRepository
{
    public ItemRepository(RepositoryContext dbContext) : base(dbContext)
    {
    }
}