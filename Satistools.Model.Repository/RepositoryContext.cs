using System.Collections.ObjectModel;
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

    protected RepositoryContext()
    {
        _repositories = new ReadOnlyDictionary<Type, IRepository>(new Dictionary<Type, IRepository>());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="repositories"></param>
    protected RepositoryContext(DbContextOptions options, IEnumerable<IRepository> repositories) : base(options)
    {
        _repositories = new ReadOnlyDictionary<Type, IRepository>(repositories.ToDictionary(repo => repo.EntityType, repo => repo));
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