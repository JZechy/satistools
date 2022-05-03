using Satistools.Calculator.Graph;

namespace Satistools.Calculator;

public readonly struct AnalyseResult
{
    public GraphNode ProductNode { get; }
    public float ProductAmount { get; }
    public IEnumerable<GraphNode> Byproducts { get; } = Array.Empty<GraphNode>();

    public AnalyseResult(GraphNode productNode, float productAmount)
    {
        ProductNode = productNode;
        ProductAmount = productAmount;
    }
    
    public AnalyseResult(GraphNode productNode, float productAmount, IEnumerable<GraphNode> byproducts)
    {
        ProductNode = productNode;
        ProductAmount = productAmount;
        Byproducts = byproducts;
    }
}