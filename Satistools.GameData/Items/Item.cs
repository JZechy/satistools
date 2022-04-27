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
}