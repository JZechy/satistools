using Satistools.Calculator.Graph;

namespace Satistools.Calculator;

public interface IProductionCalculator
{
    /// <summary>
    /// Adds a new final product to the calculator.
    /// </summary>
    /// <param name="itemId">ID of item which will be final.</param>
    /// <param name="amount">How many parts of the product should be produced.</param>
    void AddTargetProduct(string itemId, int amount);

    /// <summary>
    /// Calculates the production graph for the set inputs.
    /// </summary>
    /// <returns>Returns an instance of calculated graph of production.</returns>
    Task<ProductionGraph> Calculate();
}