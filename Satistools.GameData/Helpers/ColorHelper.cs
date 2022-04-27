using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Satistools.GameData.Helpers;

public static class ColorHelper
{
    /// <summary>
    /// Converts HEXA string to <see cref="Color"/>
    /// </summary>
    /// <param name="hexa">String in #RRGGBBAA format.</param>
    /// <returns>Instance of color.</returns>
    /// <exception cref="ArgumentException">String is in incorrect format.</exception>
    public static Color FromHexaString(string hexa)
    {
        Regex regex = new(@"#[A-F0-9]{8}");
        hexa = hexa.ToUpper();
        if (!regex.IsMatch(hexa))
        {
            throw new ArgumentException("Color must be in format #RRGGBBAA");
        }

        hexa = hexa.Replace("#", string.Empty);
        const NumberStyles h = NumberStyles.HexNumber;

        int r = int.Parse(hexa[..2], h);
        int g = int.Parse(hexa.Substring(2, 2), h);
        int b = int.Parse(hexa.Substring(4, 2), h);
        int a = int.Parse(hexa.Substring(6, 2), h);

        return Color.FromArgb(a, r, g, b);
    }
}