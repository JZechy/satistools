using Microsoft.Extensions.DependencyInjection;

namespace Satistools.Model.Repository
{
    /// <summary>
    /// Options for registering a repository pattern.
    /// </summary>
    public class RepositoryPatternBuilderOptions
    {
        internal RepositoryPatternBuilderOptions(IServiceCollection services)
        {
            Services = services;
        }

        /// <summary>
        /// Collection of registered services.
        /// </summary>
        private IServiceCollection Services { get; }

        /// <summary>
        /// Register a new repository to services as direct type.
        /// </summary>
        /// <typeparam name="TImplementation">Implementation type of repository.</typeparam>
        public void AddRepository<TImplementation>() where TImplementation : class, IRepository
        {
            AddRepository<IRepository, TImplementation>();
        }

        /// <summary>
        /// Registers a new repository to services.
        /// </summary>
        /// <typeparam name="TInterface">Interface of repository</typeparam>
        /// <typeparam name="TImplementation">The implementation type of repository.</typeparam>
        public void AddRepository<TInterface, TImplementation>()
            where TInterface : class, IRepository
            where TImplementation : class, TInterface
        {
            Services.AddScoped<TInterface, TImplementation>();
        }
    }
}