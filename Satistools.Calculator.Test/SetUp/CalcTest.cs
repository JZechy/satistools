using Satistools.GameData;
using Satistools.ModelTest;
using Xunit.Abstractions;

namespace Satistools.Calculator.Test.SetUp;

public abstract class CalcTest : TestFixture<CalculatorFactory, GameDataContext>
{
    protected CalcTest(CalculatorFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
    {
    }
}