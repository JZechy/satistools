using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Satistools.Calculator.Extensions;
using Satistools.GameData;
using Satistools.GameData.Items;
using Satistools.GameData.Recipes;
using Satistools.Model.Repository;
using Satistools.Model.Repository.Extensions;
using Satistools.ModelTest;

namespace Satistools.Calculator.Test.SetUp;

public class CalculatorFactory : TestFactory
{
    protected override void OnConfiguring(ServiceCollection services)
    {
        services.AddDbContext<GameDataContext>(options =>
        {
            options.UseInMemoryDatabase(GetDatabaseName());
        });
        services.AddScoped<RepositoryContext>(b => b.GetRequiredService<GameDataContext>());
        services.UseRepositoryPattern(options =>
        {
            options.AddRepository<IItemRepository, ItemRepository>();
            options.AddRepository<IRecipeRepository, RecipeRepository>();
        });
        services.AddCalculator();
    }
}