using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Satistools.DataReader;
using Satistools.DataReader.Entities.Buildings;
using Satistools.DataReader.Entities.Items;
using Satistools.DataReader.Entities.Recipes;
using Satistools.GameData.Buildings;
using Satistools.GameData.Items;
using Satistools.GameData.Recipes;

namespace Satistools.GameData;

public class GameDataContext : DbContext
{
    /// <summary>
    /// If the context is already preconfigured, the database is not populated with game date.
    /// </summary>
    private bool _populateData;

    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<Recipe> Recipes { get; set; } = null!;
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
    public DbSet<RecipeProduct> RecipeProducts { get; set; } = null!;
    public DbSet<BuildableManufacturer> BuildableManufacturers { get; set; } = null!;

    public GameDataContext()
    {
    }

    public GameDataContext(DbContextOptions<GameDataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }

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
        ImportItems(modelBuilder, reader);
        List<BuildableManufacturerDescriptor> buildings = ImportBuildings(modelBuilder, reader);
        ImportRecipes(modelBuilder, reader, buildings);
    }

    /// <summary>
    /// Configures default data about buildings.
    /// </summary>
    private static List<BuildableManufacturerDescriptor> ImportBuildings(ModelBuilder modelBuilder, FactoryGameReader reader)
    {
        List<BuildableManufacturerDescriptor> buildings = reader.Read<BuildableManufacturerDescriptor>();
        modelBuilder.Entity<BuildableManufacturer>()
            .HasData(BuildableManufacturerMapper.Create().Map<List<BuildableManufacturerDescriptor>, List<BuildableManufacturer>>(buildings));

        return buildings;
    }

    /// <summary>
    /// Configures default data about recipes.
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <param name="reader"></param>
    /// <param name="buildings"></param>
    private static void ImportRecipes(ModelBuilder modelBuilder, FactoryGameReader reader, List<BuildableManufacturerDescriptor> buildings)
    {
        List<RecipeDescriptor> recipes = reader.Read<RecipeDescriptor>().Where(r => r.ProducedIn.Any(p => buildings.Any(b => b.ClassName == p.ClassName))).ToList();
        modelBuilder.Entity<Recipe>().HasData(RecipeMapper.Create(buildings).Map<List<RecipeDescriptor>, List<Recipe>>(recipes));

        List<RecipeIngredient> ingredients = new();
        List<RecipeProduct> products = new();
        foreach (RecipeDescriptor recipe in recipes)
        {
            ingredients.AddRange(RecipeIngredientMapper.Create(recipe).Map<RecipeDescriptor.Part[], List<RecipeIngredient>>(recipe.Ingredients));
            products.AddRange(RecipeProductMapper.Create(recipe).Map<RecipeDescriptor.Part[], List<RecipeProduct>>(recipe.Products));
        }

        modelBuilder.Entity<RecipeIngredient>().HasData(ingredients);
        modelBuilder.Entity<RecipeProduct>().HasData(products);
    }

    /// <summary>
    /// Configures default item data.
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <param name="reader"></param>
    private static void ImportItems(ModelBuilder modelBuilder, FactoryGameReader reader)
    {
        List<ItemDescriptor> items = reader.Read<ItemDescriptor>();
        List<ResourceDescriptor> resources = reader.Read<ResourceDescriptor>();
        List<ItemDescriptorBiomass> biomasses = reader.Read<ItemDescriptorBiomass>();
        List<ConsumableDescriptor> consumables = reader.Read<ConsumableDescriptor>();
        List<EquipmentDescriptor> equipments = reader.Read<EquipmentDescriptor>();
        List<ItemDescAmmoTypeProjectile> projectiles = reader.Read<ItemDescAmmoTypeProjectile>();
        List<ItemDescriptorNuclearFuel> nuclearFuels = reader.Read<ItemDescriptorNuclearFuel>();
        List<ItemDescAmmoTypeInstantHit> instantHits = reader.Read<ItemDescAmmoTypeInstantHit>();
        List<ItemDescAmmoTypeColorCartridge> colorCartridges = reader.Read<ItemDescAmmoTypeColorCartridge>();

        IMapper itemMapper = ItemMapper.Create();
        List<Item> mappedItems = itemMapper.Map<List<ItemDescriptor>, List<Item>>(items);
        mappedItems.AddRange(itemMapper.Map<List<ResourceDescriptor>, List<Item>>(resources));
        mappedItems.AddRange(itemMapper.Map<List<ItemDescriptorBiomass>, List<Item>>(biomasses));
        mappedItems.AddRange(itemMapper.Map<List<ConsumableDescriptor>, List<Item>>(consumables));
        mappedItems.AddRange(itemMapper.Map<List<EquipmentDescriptor>, List<Item>>(equipments));
        mappedItems.AddRange(itemMapper.Map<List<ItemDescAmmoTypeProjectile>, List<Item>>(projectiles));
        mappedItems.AddRange(itemMapper.Map<List<ItemDescriptorNuclearFuel>, List<Item>>(nuclearFuels));
        mappedItems.AddRange(itemMapper.Map<List<ItemDescAmmoTypeInstantHit>, List<Item>>(instantHits));
        mappedItems.AddRange(itemMapper.Map<List<ItemDescAmmoTypeColorCartridge>, List<Item>>(colorCartridges));
        modelBuilder.Entity<Item>().HasData(mappedItems);
    }
}