using Microsoft.EntityFrameworkCore;
using Satistools.GameData.Buildings;
using Satistools.GameData.Items;
using Satistools.GameData.Recipes;

namespace Satistools.GameData;

public class GameDataContext : DbContext
{
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<Recipe> Recipes { get; set; } = null!;
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
    public DbSet<RecipeProduct> RecipeProducts { get; set; } = null!;
    public DbSet<BuildableManufacturer> BuildableManufacturers { get; set; } = null!;

    public GameDataContext(DbContextOptions<GameDataContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameDataContext).Assembly);
    }
}