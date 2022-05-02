using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Satistools.Calculator.Graph;
using Satistools.Calculator.Test.SetUp;
using Xunit;
using Xunit.Abstractions;

namespace Satistools.Calculator.Test;

public class ProductionCalculatorTest : CalcTest
{
    public ProductionCalculatorTest(CalculatorFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
    {
    }

    [Fact]
    public async Task Test_IronIngot()
    {
        IProductionCalculator calculator = ServiceProvider.GetRequiredService<IProductionCalculator>();
        calculator.AddTargetProduct("Desc_IronIngot_C", 30);
        ProductionGraph graph = await calculator.Calculate();

        graph.Count.Should().Be(2);
        GraphNode topNode = graph.First();
        topNode.TargetAmount.Should().Be(30f);
        topNode.Product.Id.Should().Be("Desc_IronIngot_C");
        topNode.NeededProducts.Should().HaveCount(1);
        topNode.UsedBy.Should().HaveCount(0);

        GraphNode lastNode = graph.Last();
        lastNode.TargetAmount.Should().Be(30f);
        lastNode.Product.Id.Should().Be("Desc_OreIron_C");
        lastNode.UsedBy.Should().HaveCount(1);
        lastNode.NeededProducts.Should().HaveCount(0);

        NodeRelation oreIsUsed = lastNode.UsedBy.First();
        oreIsUsed.UnitsAmount.Should().Be(30f);
    }

    [Fact]
    public async Task Test_IronPlate()
    {
        IProductionCalculator calculator = ServiceProvider.GetRequiredService<IProductionCalculator>();
        calculator.AddTargetProduct("Desc_IronPlate_C", 50);
        ProductionGraph graph = await calculator.Calculate();

        graph.Count.Should().Be(3);
        
        GraphNode ingot = graph["Desc_IronIngot_C"];
        ingot.UsedBy.Should().HaveCount(1);
        ingot.NeededProducts.Should().HaveCount(1);
        ingot.BuildingAmount.Should().Be(2.5f);

        GraphNode plate = graph["Desc_IronPlate_C"];
        plate.NeededProducts.Should().HaveCount(1);
        plate.BuildingAmount.Should().Be(2.5f);
    }
}