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

        graph.Should().HaveCount(3);
    }
}