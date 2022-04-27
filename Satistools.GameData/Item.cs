namespace Satistools.GameData;

/// <summary>
/// Description of single in-game item.
/// </summary>
public class Item
{
    /// <summary>
    /// TODO: Describe class name
    /// </summary>
    public string ClassName { get; set; } = string.Empty;
    
    /// <summary>
    /// Display name of the item.
    /// </summary>
    public string DisplayName { get; set; } = string.Empty;
    
    /// <summary>
    /// Description of the item.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Name of small icon for the item.
    /// </summary>
    public string SmallIcon { get; set; } = string.Empty;

    /// <summary>
    /// Name of big icon for the item.
    /// </summary>
    public string BigIcon { get; set; } = string.Empty;
}