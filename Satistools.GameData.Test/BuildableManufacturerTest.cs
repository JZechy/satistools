using System.Threading.Tasks;
using FluentAssertions;
using Satistools.GameData.Buildings;
using Satistools.GameData.Test.SetUp;
using Xunit;
using Xunit.Abstractions;

namespace Satistools.GameData.Test;

public class BuildableManufacturerTest : GameDataTest
{
    public BuildableManufacturerTest(GameDataFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
    {
    }

    [Fact]
    public async Task Test_CRUD()
    {
        BuildableManufacturer b = new()
        {
            Id = "Build_ConstructorMk1_C",
            DisplayName = "Constructor",
            PowerConsumption = 4f,
            PowerConsumptionExponent = 1.6f
        };
        await Context.AddAsync(b);
        await Context.SaveChangesAsync();

        BuildableManufacturer? r = await Context.FindAsync<BuildableManufacturer>(b.Id);
        r.Should().NotBeNull();
    }
}