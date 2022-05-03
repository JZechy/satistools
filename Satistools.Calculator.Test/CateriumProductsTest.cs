using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Satistools.Calculator.Graph;
using Satistools.Calculator.Test.SetUp;
using Xunit;
using Xunit.Abstractions;

namespace Satistools.Calculator.Test;

public class CateriumProductsTest : CalcTest
{
    public CateriumProductsTest(CalculatorFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
    {
    }

    /// <summary>
    /// Tests production of Caterium Ingot via alternate: Pure Caterium Ingot.
    /// </summary>
    [Fact]
    public async Task Test_PureCateriumIngot()
    {
        IProductionCalculator calculator = ServiceProvider.GetRequiredService<IProductionCalculator>();
        calculator.AddTargetProduct("Desc_GoldIngot_C", 36);
        calculator.UseAlternateRecipe("Recipe_Alternate_PureCateriumIngot_C");
        ProductionGraph graph = await calculator.Calculate();

        graph.Count.Should().Be(3);

        GraphNode ingot = graph["Desc_GoldIngot_C"];
        ingot.TargetAmount.Should().Be(36f);
        ingot.BuildingAmount.Should().Be(3f);
        ingot.Building!.Id.Should().Be("Build_OilRefinery_C");
        ingot.NeededProducts.Should().HaveCount(2);

        GraphNode water = graph["Desc_Water_C"];
        water.TargetAmount.Should().Be(72f);

        GraphNode ore = graph["Desc_OreGold_C"];
        ore.TargetAmount.Should().Be(72f);
    }
}