using Microsoft.EntityFrameworkCore;
using Satistools.GameData.Buildings;
using Satistools.GameData.Items;
using Satistools.GameData.Recipes;

namespace Satistools.GameData;

public class GameDataContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<RecipeProduct> RecipeProducts { get; set; }
    public DbSet<BuildableManufacturer> BuildableManufacturers { get; set; }

    public GameDataContext(DbContextOptions<GameDataContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameDataContext).Assembly);
    }
}