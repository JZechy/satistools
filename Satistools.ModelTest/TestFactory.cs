using Microsoft.Extensions.DependencyInjection;

namespace Satistools.ModelTest;

/// <summary>
/// 
/// </summary>
public abstract class TestFactory
{
    /// <summary>
    /// Collection for building <see cref="IServiceProvider" />
    /// </summary>
    private readonly ServiceCollection _serviceCollection = new();

    /// <summary>
    /// Backing field for <see cref="ServiceProvider" />
    /// </summary>
    private IServiceProvider? _serviceProvider;

    /// <summary>
    /// Initializes a new instance of <see cref="TestFactory" /> with configured services.
    /// </summary>
    protected TestFactory()
    {
    }

    /// <summary>
    /// Access to Dependency Container.
    /// </summary>
    /// <remarks>
    /// Provider is created on demand. If the provider has no instance yet, configuration and building process
    /// will be called.
    /// </remarks>
    public IServiceProvider ServiceProvider
    {
        get
        {
            if (_serviceProvider is null)
            {
                OnConfiguring(_serviceCollection);
                _serviceProvider = _serviceCollection.BuildServiceProvider();
            }

            return _serviceProvider;
        }
    }

    /// <summary>
    /// Method providing additional way to register custom services.
    /// </summary>
    /// <param name="services">Services collection</param>
    protected virtual void OnConfiguring(ServiceCollection services)
    {
    }

    /// <summary>
    /// Loads up a default connection string from <see cref="ConnectionStringFile" /> and adds
    /// randomly generated database name to ensure each test will be running in separate database
    /// context.
    /// </summary>
    /// <returns>Default connection string.</returns>
    /// <exception cref="DirectoryNotFoundException">Unable to determine current location.</exception>
    protected static string GetDatabaseName()
    {
        return $"xunit_{Guid.NewGuid():N}";
    }
}