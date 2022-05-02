﻿using Satistools.GameData.Buildings;
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
    /// List of all nodes which are using the selected product.
    /// </summary>
    public ICollection<NodeRelation> UsedBy { get; set; } = new List<NodeRelation>();

    /// <summary>
    /// List of all nodes which are used for the product of this one.
    /// </summary>
    public ICollection<NodeRelation> NeededProducts { get; set; } = new List<NodeRelation>();
}