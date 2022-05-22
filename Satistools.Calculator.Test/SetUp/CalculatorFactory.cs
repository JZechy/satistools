using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sagittaras.Model.TestFramework;
using Sagittaras.Repository.Extensions;
using Satistools.Calculator.Extensions;
using Satistools.GameData;
using Satistools.GameData.Items;
using Satistools.GameData.Recipes;

namespace Satistools.Calculator.Test.SetUp;

public class CalculatorFactory : TestFactory
{
    protected override void OnConfiguring(ServiceCollection services)
    {
        services.AddDbContext<GameDataContext>(options =>
        {
            options.UseInMemoryDatabase(GetConnectionString(Engine.InMemory));
        });
        services.UseRepositoryPattern(options =>
        {
            options.AddRepository<IItemRepository, ItemRepository>();
            options.AddRepository<IRecipeRepository, RecipeRepository>();
        });
        services.AddCalculator();
    }
}