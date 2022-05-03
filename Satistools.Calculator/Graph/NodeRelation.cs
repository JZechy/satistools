namespace Satistools.Calculator.Graph;

/// <summary>
/// Represents a single relation between nodes in both directions.
/// </summary>
public class NodeRelation
{
    /// <summary>
    /// Initializes a new relation between two nodes.
    /// </summary>
    /// <param name="targetNode">The target node of the relation.</param>
    /// <param name="unitsAmount">How many units is required in the relation.</param>
    public NodeRelation(GraphNode targetNode, float unitsAmount)
    {
        TargetNode = targetNode;
        UnitsAmount = unitsAmount;
    }
    
    /// <summary>
    /// Reference to the other node.
    /// </summary>
    public GraphNode TargetNode { get; }
    
    /// <summary>
    /// How many units of the product are need by the target node.
    /// </summary>
    public float UnitsAmount { get; set; }

    public override string ToString()
    {
        return $"{TargetNode.Product.DisplayName} {UnitsAmount} units/min";
    }
}