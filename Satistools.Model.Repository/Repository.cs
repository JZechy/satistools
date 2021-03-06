using Microsoft.EntityFrameworkCore;
using Satistools.Model.Repository.Operations;

namespace Satistools.Model.Repository;

    /// <summary>
    /// Internal implementation of repository.
    /// </summary>
    /// <remarks>
    /// Repository without its generic type is useless.
    /// </remarks>
    public abstract class Repository : IRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="entityType"></param>
        protected Repository(RepositoryContext dbContext, Type entityType)
        {
            Context = dbContext;
            EntityType = entityType;
        }

        /// <inheritdoc />
        public Type EntityType { get; }

        /// <inheritdoc />
        public bool HasChanges => Operations.Count > 0;

        /// <summary>
        /// Protected access to the context of database the repository is working with.
        /// </summary>
        internal RepositoryContext Context { get; }

        /// <summary>
        /// Queue of operations which should be executed the repository is saving changes.
        /// </summary>
        internal Queue<IRepositoryOperation> Operations { get; } = new();

        /// <inheritdoc />
        public void SaveChanges()
        {
            SaveChangesAsync().Wait();
        }

        /// <inheritdoc />
        public async Task SaveChangesAsync()
        {
            while (Operations.TryDequeue(out IRepositoryOperation? operation))
            {
                operation.Apply();
            }

            await Context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Generic implementation of repository.
    /// </summary>
    /// <typeparam name="TEntity">Target type of entity the repository is working with.</typeparam>
    public abstract class Repository<TEntity> : Repository, IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        protected Repository(RepositoryContext dbContext) : base(dbContext, typeof(TEntity))
        {
            Table = dbContext.Set<TEntity>();
            Queryable = Table.AsQueryable();
        }

        /// <summary>
        /// Original <see cref="DbSet{TEntity}"/> for entity.
        /// </summary>
        public DbSet<TEntity> Table { get; }

        /// <summary>
        /// Queryable data source of <see cref="Table"/>
        /// </summary>
        protected IQueryable<TEntity> Queryable { get; }
        
        /// <inheritdoc />
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Queryable.ToListAsync();
        }

        /// <inheritdoc />
        public void Insert(TEntity entity)
        {
            Operations.Enqueue(new InsertOperation<TEntity>(Context, entity));
        }

        /// <inheritdoc />
        public void InsertRange(IEnumerable<TEntity> entities)
        {
            Operations.Enqueue(new InsertRangeOperation<TEntity>(Context, entities));
        }

        /// <inheritdoc />
        public void Update(TEntity entity)
        {
            Operations.Enqueue(new UpdateOperation<TEntity>(Context, entity));
        }

        /// <inheritdoc />
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Operations.Enqueue(new UpdateRangeOperation<TEntity>(Context, entities));
        }

        /// <inheritdoc />
        public void Remove(TEntity entity)
        {
            Operations.Enqueue(new RemoveOperation<TEntity>(Context, entity));
        }

        /// <inheritdoc />
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Operations.Enqueue(new RemoveRangeOperation<TEntity>(Context, entities));
        }

        /// <summary>
        /// Finds a <see cref="DbSet{TEntity}"/> of repository by the type of target entity.
        /// </summary>
        /// <typeparam name="TAnotherEntity">The type of target entity.</typeparam>
        /// <returns>DbSet of repository for the entity.</returns>
        protected DbSet<TAnotherEntity> JoinRepository<TAnotherEntity>() where TAnotherEntity : class
        {
            return Context.GetRepository<TAnotherEntity>().Table;
        }

        /// <summary>
        /// Finds a <see cref="DbSet{TEntity}"/> on context by the target type of entites.
        /// </summary>
        /// <typeparam name="TAnotherEntity">The type of target entity.</typeparam>
        /// <returns>DbSet of repository for the entity.</returns>
        protected DbSet<TAnotherEntity> JoinDbSet<TAnotherEntity>() where TAnotherEntity : class
        {
            return Context.Set<TAnotherEntity>();
        }
    }

    /// <summary>
    /// Generic implementation of Repository controlling the data type of primary key.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    /// <typeparam name="TKey">The type of primary key of entity.</typeparam>
    public abstract class Repository<TEntity, TKey> : Repository<TEntity>, IRepository<TEntity, TKey> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        protected Repository(RepositoryContext dbContext) : base(dbContext)
        {
        }
        
        /// <inheritdoc />
        public async Task<TEntity?> Get(TKey id)
        {
            return await Table.FindAsync(id).AsTask();
        }
    }

    /// <summary>
    /// Repository supporting identification via composite PK.
    /// </summary>
    /// <typeparam name="TEntity">Data type of used entity</typeparam>
    /// <typeparam name="TFirstKey">Data type of first part of PK</typeparam>
    /// <typeparam name="TSecondKey">Data type of second part of PK</typeparam>
    public abstract class Repository<TEntity, TFirstKey, TSecondKey> : Repository<TEntity, TFirstKey>, IRepository<TEntity, TFirstKey, TSecondKey> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        protected Repository(RepositoryContext dbContext) : base(dbContext)
        {
        }

        /// <inheritdoc />
        public async Task<TEntity?> Get(TFirstKey firstKey, TSecondKey secondKey)
        {
            return await Table.FindAsync(firstKey, secondKey).AsTask();
        }
    }