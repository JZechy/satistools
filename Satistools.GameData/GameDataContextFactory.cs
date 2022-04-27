using Microsoft.EntityFrameworkCore.Design;

namespace Satistools.GameData;

public class GameDataContextFactory : IDesignTimeDbContextFactory<GameDataContext>
{
    public GameDataContext CreateDbContext(string[] args)
    {
        return new GameDataContext();
    }
}