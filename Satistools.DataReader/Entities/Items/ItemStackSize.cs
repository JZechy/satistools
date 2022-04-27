namespace Satistools.DataReader.Entities.Items;

/// <summary>
/// By how many items can be the item stacked in inventory.
/// </summary>
public enum ItemStackSize
{
    /// <summary>
    /// The stack size value could not be determined.
    /// </summary>
    NotAvailable = -1,

    /// <summary>
    /// Item can be stacked by one in inventory.
    /// </summary>
    One = 1,

    /// <summary>
    /// Item can be stacked up to 50 units.
    /// </summary>
    Small = 50,

    /// <summary>
    /// Item can be stacked up to 100 units.
    /// </summary>
    Medium = 100,

    /// <summary>
    /// Item can be stacked up to 200 units.
    /// </summary>
    Big = 200,

    /// <summary>
    /// Item can be stacked up to 500 units.
    /// </summary>
    Huge = 500,

    /// <summary>
    /// The item is fluid.
    /// </summary>
    Fluid = 0
}