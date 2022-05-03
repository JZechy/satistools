using Satistools.GameData.Buildings;
using Satistools.GameData.Items;

namespace Satistools.Calculator.Graph;

/// <summary>
/// A single node of network graph for production.
/// </summary>
public class GraphNode : IEquatable<GraphNode>
{
    /// <summary>
    /// Initializes a new node in production graph.
    /// </summary>
    /// <param name="building">Building needed for the production of selected item.</param>
    /// <param name="buildingAmount">How many buildings are needed to produce target amount.</param>
    /// <param name="item">Item which is being produced by this node.</param>
    /// <param name="targetAmount">How units of the product is needed per minute.</param>
    public GraphNode(Building? building, float buildingAmount, Item item, float targetAmount)
    {
        Building = building;
        BuildingAmount = buildingAmount;
        Product = item;
        TargetAmount = targetAmount;
    }

    /// <summary>
    /// Id of this node as ID of the product produced by it.
    /// </summary>
    public string Id => Product.Id;

    /// <summary>
    /// In which building is the product manufactured.
    /// </summary>
    public Building? Building { get; }

    /// <summary>
    /// How many buildings are required.
    /// </summary>
    public float BuildingAmount { get; set; }

    /// <summary>
    /// Which item is being produced by this node.
    /// </summary>
    public Item Product { get; }

    /// <summary>
    /// How many parts of the product are being produced by minute.
    /// </summary>
    public float TargetAmount { get; set; }

    /// <summary>
    /// How many units of the product is used.
    /// </summary>
    public float UsedAmount => UsedBy.Sum(relation => relation.UnitsAmount);

    /// <summary>
    /// How many percents of the production is used.
    /// </summary>
    public float PercentageUsage => UsedAmount / TargetAmount * 100;

    /// <summary>
    /// List of all nodes which are using the selected product.
    /// </summary>
    public ICollection<NodeRelation> UsedBy { get; } = new List<NodeRelation>();

    /// <summary>
    /// List of all nodes which are used for the product of this one.
    /// </summary>
    public ICollection<NodeRelation> NeededProducts { get; } = new List<NodeRelation>();

    public void UpdateUsage(NodeRelation nodeRelation)
    {
        NodeRelation? existing = UsedBy.SingleOrDefault(u => u.TargetNode.Id == nodeRelation.TargetNode.Id);
        if (existing is not null)
        {
            existing.UnitsAmount += nodeRelation.UnitsAmount;
            return;
        }
        
        UsedBy.Add(nodeRelation);
    }

    public void UpdateNeeds(NodeRelation nodeRelation)
    {
        NodeRelation? existing = NeededProducts.SingleOrDefault(u => u.TargetNode.Id == nodeRelation.TargetNode.Id);
        if (existing is not null)
        {
            existing.UnitsAmount += nodeRelation.UnitsAmount;
            return;
        }
        
        NeededProducts.Add(nodeRelation);
    }

    /// <inheritdoc />
    public bool Equals(GraphNode? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id == other.Id;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((GraphNode) obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Building, Product);
    }

    public override string ToString()
    {
        return $"{Product.DisplayName} {TargetAmount}/min ({UsedAmount} used) ({PercentageUsage}%)";
    }
}