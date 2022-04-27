using System.Drawing;
using FluentAssertions;
using Satistools.GameData.Extensions;
using Satistools.GameData.Helpers;
using Xunit;

namespace Satistools.GameData.Test.Helpers;

public class ColorHelperTest
{
    [Fact]
    public void Test_FromHexaString()
    {
        Color red = Color.FromArgb(255, 255, 0, 0);
        string redHexa = red.ToHexaString();
        Color red2 = ColorHelper.FromHexaString(redHexa);

        red2.Equals(red).Should().BeTrue();
    }
}