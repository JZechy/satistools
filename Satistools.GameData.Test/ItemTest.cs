using System.Threading.Tasks;
using FluentAssertions;
using Satistools.GameData.Items;
using Satistools.GameData.Test.SetUp;
using Xunit;
using Xunit.Abstractions;

namespace Satistools.GameData.Test;

public class ItemTest : GameDataTest
{
    public ItemTest(GameDataFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
    {
    }

    [Fact]
    public async Task Test_CRUD()
    {
        Item item = new()
        {
            Id = "Desc_LiquidTurboFuel_C",
            DisplayName = "Turbofuel",
            Description = "A more efficient alternative to Fuel. Can be used to generate power or packaged to be used as fuel for Vehicles."
        };
        await Context.AddAsync(item);
        int rows = await Context.SaveChangesAsync();
        rows.Should().Be(1);

        Item? retrieved = await Context.FindAsync<Item>(item.Id);
        retrieved.Should().NotBeNull();
    }
}