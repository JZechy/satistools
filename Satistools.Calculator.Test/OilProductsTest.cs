using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Satistools.Calculator.Graph;
using Satistools.Calculator.Test.SetUp;
using Xunit;
using Xunit.Abstractions;

namespace Satistools.Calculator.Test;

public class OilProductsTest : CalcTest
{
    public OilProductsTest(CalculatorFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
    {
    }

    /// <summary>
    /// Tests production of plastic.
    /// </summary>
    [Fact]
    public async Task Test_PlasticProduction()
    {
        IProductionCalculator calculator = ServiceProvider.GetRequiredService<IProductionCalculator>();
        calculator.AddTargetProduct("Desc_Plastic_C", 20f);
        ProductionGraph graph = await calculator.Calculate();

        graph.Should().HaveCount(2);

        GraphNode plastic = graph["Desc_Plastic_C"];
        plastic.Byproduct.Should().NotBeNull();
        plastic.Byproduct!.TargetAmount.Should().Be(10f);

        GraphNode residue = graph["Desc_HeavyOilResidue_C"]; // We are able to find the node also by byproduct
        residue.ProductId.Should().Be(plastic.ProductId);
        residue.ByproductId.Should().Be(residue.ByproductId);
    }

    [Fact]
    public async Task Test_PlasticAndFuel()
    {
        IProductionCalculator calculator = ServiceProvider.GetRequiredService<IProductionCalculator>();
        calculator.AddTargetProduct("Desc_Plastic_C", 20f);
        calculator.AddTargetProduct("Desc_LiquidFuel_C", 6.66f);
        ProductionGraph graph = await calculator.Calculate();

        graph.Should().HaveCount(3);
    }
}