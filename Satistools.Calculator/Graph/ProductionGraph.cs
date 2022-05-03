using System.Collections;

namespace Satistools.Calculator.Graph;

/// <summary>
/// A collection of all nodes representing network graph describing how to produce selected items.
/// </summary>
public class ProductionGraph : IEnumerable<GraphNode>
{
    /// <summary>
    /// List of all nodes inside the graph.
    /// </summary>
    private readonly Dictionary<string, GraphNode> _nodes = new();

    /// <summary>
    /// Gets node by the ID of item which is producing.
    /// </summary>
    /// <param name="id">Identification of the produced item by node.</param>
    public GraphNode this[string id]
    {
        get { return _nodes.Values.Single(n => n.Produces(id)); }
    }

    /// <summary>
    /// How many nodes are already in the graph.
    /// </summary>
    public int Count => _nodes.Count;

    /// <summary>
    /// Adds new node without any relation. Or update the existing one.
    /// </summary>
    /// <param name="node">Instance of new node.</param>
    public GraphNode AddOrUpdate(GraphNode node)
    {
        if (_nodes.ContainsKey(node.ProductId))
        {
            GraphNode existing = _nodes[node.ProductId];
            existing.BuildingAmount += node.BuildingAmount;

            existing.Product.TargetAmount += node.Product.TargetAmount;
            if (node.Byproduct is not null)
            {
                existing.Byproduct!.TargetAmount += node.Byproduct.TargetAmount;
            }

            return existing;
        }

        _nodes.Add(node.ProductId, node);
        return node;
    }

    /// <summary>
    /// Creates a relation between two nodes.
    /// </summary>
    /// <param name="node">Instance of node which is used by the product.</param>
    /// <param name="product"></param>
    /// <param name="amount">Amount of product parts used in this relation.</param>
    public void NodeIsUsedBy(GraphNode node, NodeProduct product, float amount)
    {
        // node is like Iron Ore & neededNode is like Iron Ingot
        GraphNode neededNode = this[product.Id];
        neededNode.UpdateNeeds(new NodeRelation(node, amount));
        node.UpdateUsage(new NodeRelation(neededNode, amount));

        node.Product.UsedAmount += amount;
    }

    /*public void NodeNeedsProduct(GraphNode node, string id, float amount)
    {
        GraphNode usedNode = this[id];
        usedNode.UpdateUsage(new NodeRelation(node, amount));
        node.UpdateNeeds(new NodeRelation(usedNode, amount));
    }*/

    /// <inheritdoc />
    public IEnumerator<GraphNode> GetEnumerator()
    {
        return _nodes.Values.GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}