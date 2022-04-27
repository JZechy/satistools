using System.Text.Json.Serialization;
using Satistools.DataReader.Attributes;
using Satistools.DataReader.Converters.Recipes;

namespace Satistools.DataReader.Entities;

/// <summary>
/// Describes an in-game recipe.
/// </summary>
[DataEntity("Class'/Script/FactoryGame.FGRecipe'")]
public class RecipeDescriptor
{
    /// <summary>
    /// Describes a single part of ingredients or final products.
    /// </summary>
    public class Part
    {
        /// <summary>
        /// Name of in-game class describing the item.
        /// </summary>
        public string ClassName { get; set; } = string.Empty;
        
        /// <summary>
        /// How many of the item is produced or needed.
        /// </summary>
        public int Amount { get; set; }
    }

    /// <summary>
    /// Describes a tool or building for producing a recipe.
    /// </summary>
    public class Producer
    {
        /// <summary>
        /// Name of in-game class describing the tool/building.
        /// </summary>
        public string ClassName { get; set; } = string.Empty;
    }
    
    /// <summary>
    /// Name of the recipe class.
    /// </summary>
    public string ClassName { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Displayed name in the game.
    /// </summary>
    [JsonPropertyName("mDisplayName")]
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Ingredients needed by the recipe.
    /// </summary>
    [JsonPropertyName("mIngredients")]
    [JsonConverter(typeof(PartJsonConverter))]
    public Part[] Ingredients { get; set; } = Array.Empty<Part>();

    /// <summary>
    /// Final products of the recipe
    /// </summary>
    [JsonPropertyName("mProduct")]
    [JsonConverter(typeof(PartJsonConverter))]
    public Part[] Products { get; set; } = Array.Empty<Part>();
    
    [JsonPropertyName("mManufacturingMenuPriority")]
    public float ManufacturingMenuPriority { get; set; }
    
    [JsonPropertyName("mManufactoringDuration")]
    public float ManufactoringDuration { get; set; }
    
    [JsonPropertyName("mManualManufacturingMultiplier")]
    public float ManualManufacturingMultipler { get; set; }

    /// <summary>
    /// Where this recipe is used.
    /// </summary>
    [JsonPropertyName("mProducedIn")]
    [JsonConverter(typeof(ProducerJsonConverter))]
    public Producer[] ProducedIn { get; set; } = Array.Empty<Producer>();

    [JsonPropertyName("mRelevantEvents")]
    public string RelevantEvents { get; set; } = string.Empty;
    
    [JsonPropertyName("mVariablePowerConsumptionConstant")]
    public float VariablePowerConsumptionConstant { get; set; }
    
    [JsonPropertyName("mVariablePowerConsumptionFactor")]
    public float VariablePowerConsumptionFactor { get; set; }
}