using Satistools.GameData.Buildings;
using Satistools.GameData.Items;

namespace Satistools.Calculator.Graph;

/// <summary>
/// A single node of network graph for production.
/// </summary>
public class GraphNode
{
    /// <summary>
    /// Initializes a new node in production graph.
    /// </summary>
    /// <param name="building">Building needed for the production of selected item.</param>
    /// <param name="buildingAmount">How many buildings are needed to produce target amount.</param>
    /// <param name="product">Item which is being produced by this node.</param>
    /// <param name="productAmount">How units of the product is needed per minute.</param>
    public GraphNode(Building? building, float buildingAmount, Item product, float productAmount)
    {
        Building = building;
        BuildingAmount = buildingAmount;

        Product = new NodeProduct(product, productAmount);
    }

    public GraphNode(Building? building, float buildingAmount, Item product, float productAmount, Item byproduct, float byproductAmount)
    {
        Building = building;
        BuildingAmount = buildingAmount;

        Product = new NodeProduct(product, productAmount);
        Byproduct = new NodeProduct(byproduct, byproductAmount);
    }

    /// <summary>
    /// ID of item which is produced as the main product.
    /// </summary>
    public string ProductId => Product.Item.Id;

    /// <summary>
    /// ID of byproduct if exists.
    /// </summary>
    public string ByproductId => Byproduct?.Item.Id ?? string.Empty;
    
    /// <summary>
    /// In which building is the product manufactured.
    /// </summary>
    public Building? Building { get; }

    /// <summary>
    /// How many buildings are required.
    /// </summary>
    public float BuildingAmount { get; set; }
    
    /// <summary>
    /// Informations about item produced by this node.
    /// </summary>
    public NodeProduct Product { get; }
    
    /// <summary>
    /// Informations about byproduct if it's produced by the recipe.
    /// </summary>
    public NodeProduct? Byproduct { get; }
    
    /// <summary>
    /// List of all nodes which are using the selected product.
    /// </summary>
    public ICollection<NodeRelation> UsedBy { get; } = new List<NodeRelation>();

    /// <summary>
    /// List of all nodes which are used for the product of this one.
    /// </summary>
    public ICollection<NodeRelation> NeededProducts { get; } = new List<NodeRelation>();

    /// <summary>
    /// Checks if the node is producing the item.
    /// </summary>
    /// <param name="itemId">Item identification.</param>
    /// <returns>True if the item is produced as product or byproduct.</returns>
    public bool Produces(string itemId)
    {
        return ProductId == itemId || ByproductId == itemId;
    }

    public void UpdateUsage(NodeRelation nodeRelation)
    {
        NodeRelation? existing = UsedBy.SingleOrDefault(u => u.TargetNode.ProductId == nodeRelation.TargetNode.ProductId);
        if (existing is not null)
        {
            existing.UnitsAmount += nodeRelation.UnitsAmount;
            return;
        }
        
        UsedBy.Add(nodeRelation);
    }

    public void UpdateNeeds(NodeRelation nodeRelation)
    {
        NodeRelation? existing = NeededProducts.SingleOrDefault(u => u.TargetNode.ProductId == nodeRelation.TargetNode.ProductId);
        if (existing is not null)
        {
            existing.UnitsAmount += nodeRelation.UnitsAmount;
            return;
        }
        
        NeededProducts.Add(nodeRelation);
    }

    public override string ToString()
    {
        string description = $"{Product.Item.DisplayName} {Product.TargetAmount}/min ({Product.UsedAmount} used) ({Product.PercentageUsage}%)";
        if (Building is not null)
        {
            description += $"; {BuildingAmount}x {Building.DisplayName}";
        }
        
        return description;
    }
}