using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Satistools.Calculator.Graph;
using Satistools.Calculator.Test.SetUp;
using Xunit;
using Xunit.Abstractions;

namespace Satistools.Calculator.Test;

public class IronProductsTest : CalcTest
{
    public IronProductsTest(CalculatorFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
    {
    }

    /// <summary>
    /// Tests calculation of basic iron ingot production.
    /// </summary>
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

    /// <summary>
    /// Test production of bigger amount of iron plate.
    /// </summary>
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

    /// <summary>
    /// Tests two target products. Iron Plate & Iron Rod.
    /// </summary>
    [Fact]
    public async Task Test_DoubleProduction()
    {
        IProductionCalculator calculator = ServiceProvider.GetRequiredService<IProductionCalculator>();
        calculator.AddTargetProduct("Desc_IronPlate_C", 20);
        calculator.AddTargetProduct("Desc_IronRod_C", 15);
        ProductionGraph graph = await calculator.Calculate();

        graph.Count.Should().Be(4);

        GraphNode ore = graph["Desc_OreIron_C"];
        ore.TargetAmount.Should().Be(45f);

        GraphNode ingot = graph["Desc_IronIngot_C"];
        ingot.TargetAmount.Should().Be(45f);
        ingot.UsedBy.Should().HaveCount(2);
    }

    /// <summary>
    /// Tests production of Reinforced Iron Plate.
    /// </summary>
    [Fact]
    public async Task Test_ReinforcedIronPlate()
    {
        IProductionCalculator calculator = ServiceProvider.GetRequiredService<IProductionCalculator>();
        calculator.AddTargetProduct("Desc_IronPlateReinforced_C", 5);
        ProductionGraph graph = await calculator.Calculate();

        graph.Should().HaveCount(6);

        GraphNode ore = graph["Desc_OreIron_C"];
        ore.TargetAmount.Should().Be(60f);

        GraphNode ingot = graph["Desc_IronIngot_C"];
        ingot.TargetAmount.Should().Be(60f);
        ingot.UsedBy.Should().HaveCount(2);

        GraphNode rip = graph["Desc_IronPlateReinforced_C"];
        rip.NeededProducts.Should().HaveCount(2);
    }

    /// <summary>
    /// Tests production of all advanced iron products - Rotors, Modular Frames & Reinforced Plates.
    /// </summary>
    [Fact]
    public async Task Test_AdvancedIronProducts()
    {
        IProductionCalculator calculator = ServiceProvider.GetRequiredService<IProductionCalculator>();
        calculator.AddTargetProduct("Desc_IronPlateReinforced_C", 5);
        calculator.AddTargetProduct("Desc_Rotor_C", 4);
        calculator.AddTargetProduct("Desc_ModularFrame_C", 2);
        ProductionGraph graph = await calculator.Calculate();

        graph.Should().HaveCount(8);

        GraphNode ingot = graph["Desc_IronIngot_C"];
        ingot.TargetAmount.Should().Be(153f);
        ingot.UsedBy.Should().HaveCount(2);

        GraphNode rip = graph["Desc_IronPlateReinforced_C"];
        rip.TargetAmount.Should().Be(8);
        rip.NeededProducts.Should().HaveCount(2);
        rip.UsedBy.Should().HaveCount(1);
    }

    /// <summary>
    /// Just like previous test, but every manufactuerer is producing at 100%.
    /// </summary>
    [Fact]
    public async Task Test_BalancedProduction()
    {
        IProductionCalculator calculator = ServiceProvider.GetRequiredService<IProductionCalculator>();
        calculator.AddTargetProduct("Desc_IronPlateReinforced_C", 7);
        calculator.AddTargetProduct("Desc_Rotor_C", 4);
        calculator.AddTargetProduct("Desc_ModularFrame_C", 2);
        calculator.AddTargetProduct("Desc_IronScrew_C", 20);
        calculator.AddTargetProduct("Desc_IronRod_C", 13);
        calculator.AddTargetProduct("Desc_IronIngot_C", 15);
        ProductionGraph graph = await calculator.Calculate();

        graph.Should().HaveCount(8);
        graph.Sum(n => n.BuildingAmount).Should().Be(27f);
    }

    /// <summary>
    /// Tests production of rotot via Alternate: Steel Rotor.
    /// </summary>
    [Fact]
    public async Task Test_AlternateSteelRotor()
    {
        IProductionCalculator calculator = ServiceProvider.GetRequiredService<IProductionCalculator>();
        calculator.AddTargetProduct("Desc_Rotor_C", 5);
        calculator.UseAlternateRecipe("Recipe_Alternate_Rotor_C");
        ProductionGraph graph = await calculator.Calculate();

        graph.Should().HaveCount(8);

        GraphNode ironOre = graph["Desc_OreIron_C"];
        ironOre.TargetAmount.Should().Be(15f);

        GraphNode coal = graph["Desc_Coal_C"];
        coal.TargetAmount.Should().Be(15f);
    }
}