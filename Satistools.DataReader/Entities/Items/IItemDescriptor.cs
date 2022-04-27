namespace Satistools.DataReader.Entities.Items;

/// <summary>
/// Common interface for the 
/// </summary>
public interface IItemDescriptor
{
    public string ClassName { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
}