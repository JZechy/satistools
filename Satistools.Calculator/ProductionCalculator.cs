using Satistools.Calculator.Graph;
using Satistools.GameData.Items;
using Satistools.GameData.Recipes;

namespace Satistools.Calculator;

/// <summary>
/// Calculates graph for production of needed products.
/// </summary>
public class ProductionCalculator : IProductionCalculator
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IItemRepository _itemRepository;
    
    /// <summary>
    /// Contains IDs of all items which production should calculated in Tuple with target amount.
    /// </summary>
    private readonly List<(string, int)> _targetIds = new();

    public ProductionCalculator(IRecipeRepository recipeRepository, IItemRepository itemRepository)
    {
        _recipeRepository = recipeRepository;
        _itemRepository = itemRepository;
    }
    
    /// <inheritdoc />
    public void AddTargetProduct(string itemId, int amount)
    {
        _targetIds.Add((itemId, amount));
    }

    /// <inheritdoc />
    public async Task<ProductionGraph> Calculate()
    {
        ProductionGraph graph = new();

        foreach ((string targetId, int targetAmount) in _targetIds)
        {
            Item? item = await _itemRepository.Get(targetId);
            if (item is null)
            {
                throw new Exception($"Target item {targetId} was not found");
            }

            Recipe? recipe = await _recipeRepository.GetOriginalRecipe(targetId);
            if (recipe is null)
            {
                throw new Exception($"Original recipe for {item.Id} was not found");
            }

            RecipeProduct product = recipe.GetProduct(targetId);
            float productionRate = targetAmount / product.AmountPerMin;
            await AnalyseRecipePart(graph, product, productionRate);
        }
        
        return graph;
    }

    private async Task<GraphNode?> AnalyseRecipePart(ProductionGraph graph, RecipePart part, float productionRate)
    {
        Recipe? recipe = await _recipeRepository.GetOriginalRecipe(part.ItemId);
        if (recipe is null)
        {
            GraphNode resourceNode = new(null, 0, part.Item, part.AmountPerMin * productionRate);
            graph.Add(resourceNode);
            return resourceNode;
        }

        RecipeProduct product = recipe.GetProduct(part.ItemId);
        float amount = product.AmountPerMin * productionRate;
        float buildingsCount = amount / product.AmountPerMin; // Serves also as the production rate for the next ingredient.
        
        GraphNode node = new(recipe.ProducedIn, buildingsCount, part.Item, amount);
        graph.Add(node);
        
        foreach (RecipeIngredient ingredient in recipe.Ingredients)
        {
            GraphNode? subNode = await AnalyseRecipePart(graph, ingredient, buildingsCount);
            if (subNode is null)
            {
                continue;
            }
            graph.NodeIsUsedBy(subNode, node.Id, amount);
        }

        return node;
    }
}