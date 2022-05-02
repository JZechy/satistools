using Microsoft.EntityFrameworkCore;

namespace Satistools.Model.Repository;

/// <summary>
/// Database Context expanding its workflow by registered repositories.
/// </summary>
public abstract class RepositoryContext : DbContext
{
    /// <summary>
    /// Dictionary of registered repositories assigned to its types.
    /// </summary>
    private readonly IDictionary<Type, IRepository> _repositories;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="repositories"></param>
    protected RepositoryContext(DbContextOptions options, IEnumerable<IRepository> repositories) : base(options)
    {
        _repositories = new Dictionary<Type, IRepository>(repositories.Select(repo => new KeyValuePair<Type, IRepository>(repo.EntityType, repo)));
    }

    /// <summary>
    /// Gets target repository by the type of entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of used entity.</typeparam>
    /// <returns>Found instance of entity.</returns>
    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        return (IRepository<TEntity>) _repositories[typeof(TEntity)];
    }
}