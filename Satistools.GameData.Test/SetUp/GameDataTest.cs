using Satistools.ModelTest;
using Xunit.Abstractions;

namespace Satistools.GameData.Test.SetUp;

/// <summary>
/// TestFixture implementation for tests of GameData.
/// </summary>
public abstract class GameDataTest : TestFixture<GameDataFactory, GameDataContext>
{
    protected GameDataTest(GameDataFactory factory, ITestOutputHelper testOutputHelper) : base(factory, testOutputHelper)
    {
    }
}