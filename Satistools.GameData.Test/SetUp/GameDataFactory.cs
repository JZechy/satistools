using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Satistools.ModelTest;

namespace Satistools.GameData.Test.SetUp;

public class GameDataFactory : TestFactory
{
    protected override void OnConfiguring(ServiceCollection services)
    {
        services.AddDbContext<GameDataContext>(options =>
        {
            options.UseInMemoryDatabase(GetDatabaseName());
        });
    }
}