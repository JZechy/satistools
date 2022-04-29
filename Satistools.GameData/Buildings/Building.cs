using Satistools.DataReader.Entities.Buildings;

namespace Satistools.GameData.Buildings;

/// <summary>
/// Basic table describing building.
/// </summary>
public class Building
{
    public string Id { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public BuildingType BuildingType { get; set; }
    public bool IsOverclockable { get; set; }
    public string SmallIcon { get; set; } = string.Empty;
    public string BigIcon { get; set; } = string.Empty;
}