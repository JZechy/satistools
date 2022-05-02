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
        get
        {
            return _nodes.Single(pair => pair.Key == id).Value;
        }
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
        if (_nodes.ContainsKey(node.Id))
        {
            GraphNode existing = _nodes[node.Id];
            existing.BuildingAmount += node.BuildingAmount;
            existing.TargetAmount += node.TargetAmount;
            return existing;
        }

        _nodes.Add(node.Id, node);
        return node;
    }

    /// <summary>
    /// Creates a relation between two nodes.
    /// </summary>
    /// <param name="node">Instance of node which is used by the product.</param>
    /// <param name="id">ID of node which is requesting the new one.</param>
    /// <param name="amount">Amount of product parts used in this relation.</param>
    public void NodeIsUsedBy(GraphNode node, string id, float amount)
    {
        GraphNode neededNode = this[id];
        neededNode.UpdateNeeds(new NodeRelation(node, amount));
        node.UpdateUsage(new NodeRelation(neededNode, amount));
    }

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