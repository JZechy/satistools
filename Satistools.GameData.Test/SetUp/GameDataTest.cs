using Sagittaras.Model.TestFramework;
using Xunit.Abstractions;

namespace Satistools.GameData.Test.SetUp;

/// <summary>
/// TestFixture implementation for tests of GameData.
/// </summary>
public abstract class GameDataTest : UnitTest<GameDataFactory, GameDataContext>
{
    protected GameDataTest(GameDataFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
    {
    }
}