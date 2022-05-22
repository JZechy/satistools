using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sagittaras.Repository.Extensions;
using Satistools.GameData.Items;
using Satistools.GameData.Recipes;

namespace Satistools.GameData.Extensions;

public static class ServiceExtension
{
    /// <summary>
    /// Registers all service from the game data assembly.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration">The application configuration.</param>
    public static void AddGameDataModel(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GameDataContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("sqlite"));
        });
        services.UseRepositoryPattern(options =>
        {
            options.AddRepository<IItemRepository, ItemRepository>();
            options.AddRepository<IRecipeRepository, RecipeRepository>();
        });    
    }
}