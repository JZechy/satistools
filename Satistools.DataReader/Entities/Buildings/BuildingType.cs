namespace Satistools.DataReader.Entities.Buildings;

/// <summary>
/// Enumeration describing the type of building.
/// </summary>
public enum BuildingType
{
    /// <summary>
    /// The type of building could not be determined.
    /// </summary>
    NotAvailable = 0,
    
    /// <summary>
    /// The building is producing parts.
    /// </summary>
    Manufactuer = 1,
    
    /// <summary>
    /// Bulding is extracting raw resources.
    /// </summary>
    ResourceExtractor = 2,
    
    /// <summary>
    /// Building is producing power.
    /// </summary>
    PowerGenerator = 3
}