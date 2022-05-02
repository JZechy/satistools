using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Satistools.DataReader;
using Satistools.DataReader.Entities.Buildings;
using Satistools.DataReader.Entities.Items;
using Satistools.DataReader.Entities.Recipes;
using Satistools.GameData.Buildings;
using Satistools.GameData.Items;
using Satistools.GameData.Recipes;
using Satistools.GameData.Recipes.Mappers;
using Satistools.Model.Repository;

namespace Satistools.GameData;

public class GameDataContext : RepositoryContext
{
    /// <summary>
    /// If the context is already preconfigured, the database is not populated with game date.
    /// </summary>
    private bool _populateData;

    /// <summary>
    /// Are we on development environment?
    /// </summary>
    private readonly bool _isDevelopment;

    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<Recipe> Recipes { get; set; } = null!;
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
    public DbSet<RecipeProduct> RecipeProducts { get; set; } = null!;
    public DbSet<Building> Buildings { get; set; } = null!;

    public GameDataContext()
    {
    }

    public GameDataContext(
        DbContextOptions<GameDataContext> options,
        IConfiguration configuration,
        IEnumerable<IRepository> repositories
    ) : base(options, repositories)
    {
        _isDevelopment = _populateData = configuration["ASPNETCORE_ENVIRONMENT"] == "Development";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_isDevelopment)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        // This part is used by design time for migrations.
        optionsBuilder.UseSqlite("Data Source=gamedata.db");
        optionsBuilder.EnableSensitiveDataLogging();
        _populateData = true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameDataContext).Assembly);
        if (!_populateData)
        {
            return;
        }

        FactoryGameReader reader = new(Path.Combine(Directory.GetCurrentDirectory(), ".."), "FactoryGame.json");
        List<Item> items = ImportItems(modelBuilder, reader);
        IEnumerable<BuildingDescriptor> buildings = ImportBuildings(modelBuilder, reader);
        ImportRecipes(modelBuilder, reader, buildings, items);
    }

    /// <summary>
    /// Configures default data about buildings.
    /// </summary>
    private static IEnumerable<BuildingDescriptor> ImportBuildings(ModelBuilder modelBuilder, FactoryGameReader reader)
    {
        List<BuildingDescriptor> buildings = reader.Read<BuildingDescriptor>();
        modelBuilder.Entity<Building>()
            .HasData(BuildingMapper.Create().Map<List<BuildingDescriptor>, List<Building>>(buildings));

        return buildings;
    }

    /// <summary>
    /// Configures default data about recipes.
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <param name="reader"></param>
    /// <param name="buildings"></param>
    /// <param name="items"></param>
    private static void ImportRecipes(ModelBuilder modelBuilder, FactoryGameReader reader, IEnumerable<BuildingDescriptor> buildings, IReadOnlyCollection<Item> items)
    {
        List<RecipeDescriptor> recipes = reader.Read<RecipeDescriptor>().Where(r => r.ProducedIn.Any(p => buildings.Any(b => b.ClassName == p.ClassName))).ToList();
        modelBuilder.Entity<Recipe>().HasData(RecipeMapper.Create(buildings).Map<List<RecipeDescriptor>, List<Recipe>>(recipes));

        List<RecipeIngredient> ingredients = new();
        List<RecipeProduct> products = new();
        foreach (RecipeDescriptor recipe in recipes)
        {
            ingredients.AddRange(RecipeIngredientMapper.Create(recipe, items).Map<RecipeDescriptor.Part[], List<RecipeIngredient>>(recipe.Ingredients));
            products.AddRange(RecipeProductMapper.Create(recipe, items).Map<RecipeDescriptor.Part[], List<RecipeProduct>>(recipe.Products));
        }

        modelBuilder.Entity<RecipeIngredient>().HasData(ingredients);
        modelBuilder.Entity<RecipeProduct>().HasData(products);
    }

    /// <summary>
    /// Configures default item data.
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <param name="reader"></param>
    private static List<Item> ImportItems(ModelBuilder modelBuilder, FactoryGameReader reader)
    {
        List<ItemDescriptor> items = reader.Read<ItemDescriptor>();

        IMapper itemMapper = ItemMapper.Create();
        List<Item> mappedItems = itemMapper.Map<List<ItemDescriptor>, List<Item>>(items);
        modelBuilder.Entity<Item>().HasData(mappedItems);

        return mappedItems;
    }
}