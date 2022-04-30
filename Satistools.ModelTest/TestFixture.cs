using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Satistools.ModelTest;

/// <summary>
/// Base class for all unit tests
/// </summary>
/// <typeparam name="TFactory">The type of used test factory</typeparam>
/// <typeparam name="TDbContext">The type of used database context class</typeparam>
public abstract class TestFixture<TFactory, TDbContext> : IClassFixture<TFactory>, IAsyncLifetime
    where TFactory : TestFactory
    where TDbContext : DbContext
{
    protected TestFixture(TFactory factory, ITestOutputHelper testOutputHelper)
    {
        Factory = factory;
        TestOutputHelper = testOutputHelper;
        ServiceProvider = factory.ServiceProvider.CreateScope().ServiceProvider;
        Context = ServiceProvider.GetRequiredService<TDbContext>();
    }

    /// <summary>
    /// Instance of Factory creating Test Context.
    /// </summary>
    protected TFactory Factory { get; }

    /// <summary>
    /// Instance of <see cref="ITestOutputHelper" /> for output debugging purposes.
    /// </summary>
    protected ITestOutputHelper TestOutputHelper { get; }

    /// <summary>
    /// Instance of new Scope of <see cref="IServiceProvider" /> in current context.
    /// </summary>
    protected IServiceProvider ServiceProvider { get; }

    /// <summary>
    /// Instance of actual used <see cref="TDbContext" />
    /// </summary>
    protected TDbContext Context { get; }

    /// <inheritdoc />
    public virtual async Task InitializeAsync()
    {
        await Context.Database.EnsureCreatedAsync();
    }

    /// <inheritdoc />
    public virtual async Task DisposeAsync()
    {
        await Context.Database.EnsureDeletedAsync();
    }
}