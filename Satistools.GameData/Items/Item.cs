using System.Drawing;
using Satistools.DataReader.Entities.Items;
using Satistools.GameData.Extensions;
using Satistools.GameData.Helpers;

namespace Satistools.GameData.Items;

/// <summary>
/// Description of single in-game item.
/// </summary>
public class Item
{
    /// <summary>
    /// Identification of the item in the form of Class Name.
    /// </summary>
    public string Id { get; set; } = string.Empty;
    
    /// <summary>
    /// Display name of the item.
    /// </summary>
    public string DisplayName { get; set; } = string.Empty;
    
    /// <summary>
    /// Description of the item.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The physical form of the item.
    /// </summary>
    public ItemForm Form { get; set; } = ItemForm.NotAvailable;

    /// <summary>
    /// By how many units can be item stacked in inventory. 
    /// </summary>
    public ItemStackSize StackSize { get; set; } = ItemStackSize.NotAvailable;
    
    /// <summary>
    /// Is the item radioactive?
    /// </summary>
    public bool IsRadioactive { get; set; }

    /// <summary>
    /// The color of the fluid in the hexa format.
    /// </summary>
    public string FluidColorHexa { get; set; } = Color.Transparent.ToHexaString();
    
    /// <summary>
    /// The color of the gas in the hexa format.
    /// </summary>
    public string GasColorHexa { get; set; } = Color.Transparent.ToHexaString();

    /// <summary>
    /// The path to the small icon for the item.
    /// </summary>
    /// <remarks>
    /// Small icon have dimension 64x64
    /// </remarks>
    public string SmallIcon { get; set; } = string.Empty;

    /// <summary>
    /// The path to the big icon for the item.
    /// </summary>
    /// <remarks>
    /// Big iconshave dimension 256x256
    /// </remarks>
    public string BigIcon { get; set; } = string.Empty;
    
    /// <summary>
    /// Is this item used for events?
    /// </summary>
    public bool IsEvent { get; set; }

    /// <summary>
    /// The color of the fluid form of the item.
    /// </summary>
    public Color FluidColor
    {
        get => ColorHelper.FromHexaString(FluidColorHexa);
        set => FluidColorHexa = value.ToHexaString();
    }

    /// <summary>
    /// The color of the gas form of the item.
    /// </summary>
    public Color GasColor
    {
        get => ColorHelper.FromHexaString(GasColorHexa);
        set => GasColorHexa = value.ToHexaString();
    }
    
    /// <summary>
    /// How many points are rewarded in the resource sink.
    /// </summary>
    public int ResourceSinkPoints { get; set; }
}