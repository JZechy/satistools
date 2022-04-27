namespace Satistools.DataReader.Entities.Items;

/// <summary>
/// By how many items can be the item stacked in inventory.
/// </summary>
public enum ItemStackSize
{
    /// <summary>
    /// The stack size value could not be determined.
    /// </summary>
    NotAvailable,

    /// <summary>
    /// Item can be stacked by one in inventory.
    /// </summary>
    One,

    /// <summary>
    /// Item can be stacked up to 50 units.
    /// </summary>
    Small,

    /// <summary>
    /// Item can be stacked up to 100 units.
    /// </summary>
    Medium,

    /// <summary>
    /// Item can be stacked up to 200 units.
    /// </summary>
    Big,

    /// <summary>
    /// Item can be stacked up to 500 units.
    /// </summary>
    Huge,

    /// <summary>
    /// The item is fluid.
    /// </summary>
    Fluid
}