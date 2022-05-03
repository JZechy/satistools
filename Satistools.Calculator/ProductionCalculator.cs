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
    private readonly List<(string, float)> _targetIds = new();

    /// <summary>
    /// Contains IDs of used alternate recipes for calculations.
    /// </summary>
    private readonly List<string> _alternateIds = new();

    /// <summary>
    /// Contains all found alternate recipes.
    /// </summary>
    private readonly List<Recipe> _alternateRecipes = new();

    public ProductionCalculator(IRecipeRepository recipeRepository, IItemRepository itemRepository)
    {
        _recipeRepository = recipeRepository;
        _itemRepository = itemRepository;
    }

    /// <inheritdoc />
    public void AddTargetProduct(string itemId, float amount)
    {
        _targetIds.Add((itemId, amount));
    }

    /// <inheritdoc />
    public void UseAlternateRecipe(string recipeId)
    {
        _alternateIds.Add(recipeId);
    }

    /// <inheritdoc />
    public async Task<ProductionGraph> Calculate()
    {
        if (_alternateIds.Count > 0)
        {
            _alternateRecipes.AddRange(await _recipeRepository.FindByIds(_alternateIds));
        }

        ProductionGraph graph = new();

        foreach ((string targetId, float targetAmount) in _targetIds)
        {
            Item? item = await _itemRepository.Get(targetId);
            if (item is null)
            {
                throw new Exception($"Target item {targetId} was not found");
            }

            Recipe? recipe = await GetRecipe(targetId);
            if (recipe is null)
            {
                throw new Exception($"Recipe for {item.Id} was not found");
            }

            RecipeProduct product = recipe.GetProduct(targetId);
            float productionRate = targetAmount / product.AmountPerMin;
            AnalyseResult result = await AnalyseRecipePart(graph, product, productionRate);

            foreach (GraphNode byproduct in result.Byproducts)
            {
                graph.NodeNeedsProduct(byproduct, targetId, targetAmount);
            }
        }

        return graph;
    }

    private async Task<AnalyseResult> AnalyseRecipePart(ProductionGraph graph, RecipePart part, float productionRate)
    {
        float amount;
        GraphNode node;

        Recipe? recipe = await GetRecipe(part.ItemId);
        if (recipe is null)
        {
            amount = part.AmountPerMin * productionRate;
            node = new GraphNode(null, 0, part.Item, amount);
            return new AnalyseResult(graph.AddOrUpdate(node), amount);
        }

        RecipeProduct product = recipe.GetProduct(part.ItemId);
        amount = part.AmountPerMin * productionRate;
        float buildingsCount = amount / product.AmountPerMin; // Serves also as the production rate for the next ingredient.

        node = new GraphNode(recipe.ProducedIn, buildingsCount, part.Item, amount);
        node = graph.AddOrUpdate(node);
        
        List<RecipeProduct> unusedProducts = recipe.Products.Where(p => p.ItemId != part.ItemId).ToList();
        List<GraphNode> byproducts = new(unusedProducts.Count);
        byproducts.AddRange(unusedProducts.Select(unusedProduct => graph.AddOrUpdate(new GraphNode(recipe.ProducedIn, buildingsCount, unusedProduct.Item, unusedProduct.AmountPerMin * productionRate))));
        
        foreach (RecipeIngredient ingredient in recipe.Ingredients)
        {
            AnalyseResult result = await AnalyseRecipePart(graph, ingredient, buildingsCount);
            graph.NodeIsUsedBy(result.ProductNode, node.Id, result.ProductAmount);
            
            foreach (GraphNode byproduct in result.Byproducts)
            {
                graph.NodeNeedsProduct(byproduct, part.ItemId, amount);
            }
        }
        
        return new AnalyseResult(node, amount, byproducts);
    }

    /// <summary>
    /// Gets recipe for the product.
    /// </summary>
    /// <remarks>
    /// First searches in the list of used alternate recipes, then queries the database for the original one.
    /// </remarks>
    /// <param name="productId">Identification of product.</param>
    /// <returns>Found recipe or null if the product does not have any recipe.</returns>
    private async Task<Recipe?> GetRecipe(string productId)
    {
        if (_alternateRecipes.Count > 0)
        {
            Recipe? alternate = _alternateRecipes.Find(r => r.Products.Any(p => p.ItemId == productId));
            if (alternate is not null)
            {
                return alternate;
            }
        }

        return await _recipeRepository.GetOriginalRecipe(productId);
    }
}