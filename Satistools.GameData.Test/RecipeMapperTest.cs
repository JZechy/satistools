using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Satistools.DataReader;
using Satistools.DataReader.Entities;
using Satistools.DataReader.Entities.Buildings;
using Satistools.DataReader.Entities.Recipes;
using Satistools.GameData.Recipes;
using Xunit;

namespace Satistools.GameData.Test;

public class RecipeMapperTest
{
    [Fact(Skip = "")]
    public void Test_RecipeMapper()
    {
        /*FactoryGameReader reader = new(Directory.GetCurrentDirectory(), "FactoryGame.json");

        List<BuildableManufacturerDescriptor> buildings = reader.Read<BuildableManufacturerDescriptor>();
        List<RecipeDescriptor> recipes = reader.Read<RecipeDescriptor>().Where(r => r.ProducedIn.Any(p => buildings.Any(b => b.ClassName == p.ClassName))).ToList();
        recipes.Should().HaveCountGreaterThan(0);
        List<Recipe> mapped = RecipeMapper.Create(buildings).Map<List<RecipeDescriptor>, List<Recipe>>(recipes);
        mapped.Should().HaveCount(recipes.Count);
        
        List<RecipeIngredient> ingredients = new();
        List<RecipeProduct> products = new();
        
        foreach (RecipeDescriptor recipe in recipes)
        {
            ingredients.AddRange(RecipeIngredientMapper.Create(recipe).Map<RecipeDescriptor.Part[], List<RecipeIngredient>>(recipe.Ingredients));
            products.AddRange(RecipeProductMapper.Create(recipe).Map<RecipeDescriptor.Part[], List<RecipeProduct>>(recipe.Products));
        }

        ingredients.Should().HaveCountGreaterThan(0);
        products.Should().HaveCountGreaterThan(0);*/
    }
}