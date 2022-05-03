using Satistools.GameData.Items;

namespace Satistools.Calculator.Graph;

public class NodeProduct
{
    public NodeProduct(Item item, float targetAmount)
    {
        Item = item;
        TargetAmount = targetAmount;
        UsedAmount = 0;
    }

    public string Id => Item.Id;
    
    /// <summary>
    /// Which item is being produced by this node.
    /// </summary>
    public Item Item { get; }

    /// <summary>
    /// How many parts of the product are being produced by minute.
    /// </summary>
    public float TargetAmount { get; set; }

    /// <summary>
    /// How many units of the product is used.
    /// </summary>
    public float UsedAmount { get; set; }

    /// <summary>
    /// How many percents of the production is used.
    /// </summary>
    public float PercentageUsage => UsedAmount / TargetAmount * 100;
}