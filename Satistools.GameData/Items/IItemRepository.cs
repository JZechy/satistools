using Sagittaras.Repository;

namespace Satistools.GameData.Items;

public interface IItemRepository : IRepository<Item, string>
{
    /// <summary>
    /// Find all products which can be automated and are non-seasonal.
    /// </summary>
    /// <returns>Enumerable of all automated non-seasonal items.</returns>
    Task<IEnumerable<Item>> FindAutomatedProducts();
}