using Sagittaras.Model.TestFramework;
using Satistools.GameData;
using Xunit.Abstractions;

namespace Satistools.Calculator.Test.SetUp;

public abstract class CalcTest : UnitTest<CalculatorFactory, GameDataContext>
{
    protected CalcTest(CalculatorFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
    {
    }
}