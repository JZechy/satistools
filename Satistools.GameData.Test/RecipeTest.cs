using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Satistools.GameData.Items;
using Satistools.GameData.Recipes;
using Satistools.GameData.Test.SetUp;
using Xunit;
using Xunit.Abstractions;

namespace Satistools.GameData.Test;

public class RecipeTest : GameDataTest
{
    public RecipeTest(GameDataFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
    {
    }

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        Item ironPlate = new()
        {
            Id = "Desc_IronPlate_C"
        };
        Item screw = new()
        {
            Id = "Desc_IronScrew_C"
        };
        Item reinforced = new()
        {
            Id = "Desc_IronPlateReinforced_C"
        };

        await Context.AddRangeAsync(ironPlate, screw, reinforced);
        await Context.SaveChangesAsync();
    }

    [Fact]
    public async Task Test_CRUD()
    {
        Recipe recipe = new()
        {
            Id = "Recipe_IronPlateReinforced_C",
            DisplayName = "Reinforced Iron Plate",
            ManufactoringDuration = 12f,
            ManualManufacturingMultiplier = 1f,
            Ingredients = new[]
            {
                new RecipeIngredient
                {
                    ItemId = "Desc_IronPlate_C",
                    Amount = 6
                },
                new RecipeIngredient
                {
                    ItemId = "Desc_IronScrew_C",
                    Amount = 12
                }
            },
            Products = new[]
            {
                new RecipeProduct
                {
                    ItemId = "Desc_IronPlateReinforced_C",
                    Amount = 1
                }
            }
        };
        await Context.AddAsync(recipe);
        await Context.SaveChangesAsync();

        Recipe? retrieved = await Context.FindAsync<Recipe>("Recipe_IronPlateReinforced_C");
        retrieved.Should().NotBeNull();
        retrieved!.Ingredients.Should().HaveCount(2);
        retrieved.Products.Should().HaveCount(1);
        retrieved.PerMin.Should().Be(5);

        RecipeIngredient ingredient = retrieved.Ingredients.First(i => i.ItemId == "Desc_IronPlate_C");
        ingredient.Item.Should().NotBeNull();
        ingredient.Recipe.Should().NotBeNull();
        ingredient.PerMin.Should().Be(30);

        retrieved.Products.First().PerMin.Should().Be(5);
    }
}