using System.Drawing;

namespace Satistools.GameData.Extensions;

public static class ColorExtension
{
    /// <summary>
    /// Converts the color to hexa string.
    /// </summary>
    /// <param name="c">Instance of color.</param>
    /// <returns>The color value in #RRGGBBAA</returns>
    public static string ToHexaString(this Color c)
    {
        return $"#{c.R:X2}{c.G:X2}{c.B:X2}{c.A:X2}";
    }
}