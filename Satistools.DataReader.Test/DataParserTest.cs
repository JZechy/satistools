using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Satistools.DataReader.Entities;
using Satistools.DataReader.Entities.Buildings;
using Satistools.DataReader.Entities.Items;
using Satistools.DataReader.Entities.Recipes;

namespace Satistools.DataReader.Test;

public class DataParserTest
{
    /// <summary>
    /// Tests reading of item descriptor.
    /// </summary>
    [Test]
    public void Test_ItemDescriptor()
    {
        FactoryGameReader reader = new(Path.Combine(Directory.GetCurrentDirectory(), "Files"), "itemdescriptor.json");
        List<ItemDescriptor> items = reader.Read<ItemDescriptor>();
        items.Should().HaveCount(1);

        ItemDescriptor item = items.First();
        item.DisplayName.Should().Be("Turbofuel");
        item.ClassName.Should().Be("Desc_LiquidTurboFuel_C");
        item.StackSize.Should().Be(ItemStackSize.Fluid);
        item.Form.Should().Be(ItemForm.Liquid);
        item.CanBeDiscarded.Should().BeTrue();
        item.FluidColor.Equals(Color.FromArgb(255, 212, 41, 46)).Should().BeTrue();
        item.GasColor.Equals(Color.FromArgb(0, 0, 0, 0)).Should().BeTrue();
    }

    /// <summary>
    /// Rests reading of recipe.
    /// </summary>
    [Test]
    public void Test_Recipe()
    {
        FactoryGameReader reader = new(Path.Combine(Directory.GetCurrentDirectory(), "Files"), "recipe.json");
        List<RecipeDescriptor> recipes = reader.Read<RecipeDescriptor>();
        recipes.Should().HaveCount(1);

        RecipeDescriptor recipeDescriptor = recipes.First();
        recipeDescriptor.DisplayName.Should().Be("Reinforced Iron Plate");
        recipeDescriptor.ManufactoringDuration.Should().Be(12f);
        recipeDescriptor.Ingredients.Should().HaveCount(2);
        recipeDescriptor.Products.Should().HaveCount(1);
        recipeDescriptor.ProducedIn.Should().HaveCount(3);

        RecipeDescriptor.Part firstPart = recipeDescriptor.Ingredients.First();
        firstPart.Amount.Should().Be(6);
        firstPart.ClassName.Should().Be("Desc_IronPlate_C");

        RecipeDescriptor.Part firstProduct = recipeDescriptor.Products.First();
        firstProduct.Amount.Should().Be(1);
        firstProduct.ClassName.Should().Be("Desc_IronPlateReinforced_C");

        RecipeDescriptor.Producer firstProducer = recipeDescriptor.ProducedIn.First();
        firstProducer.ClassName.Should().Be("Build_AssemblerMk1_C");
    }
    
    /// <summary>
    /// Rests reading of recipe.
    /// </summary>
    [Test]
    public void Test_Recipe_NonFissibleUranium()
    {
        FactoryGameReader reader = new(Path.Combine(Directory.GetCurrentDirectory(), "Files"), "nonfissibleuranium.json");
        List<RecipeDescriptor> recipes = reader.Read<RecipeDescriptor>();
        recipes.Should().HaveCount(1);

        RecipeDescriptor recipeDescriptor = recipes.First();
        recipeDescriptor.DisplayName.Should().Be("Non-fissile Uranium");
        recipeDescriptor.ManufactoringDuration.Should().Be(24f);
        recipeDescriptor.Ingredients.Should().HaveCount(4);
        recipeDescriptor.Products.Should().HaveCount(2);
    }

    [Test]
    public void Test_Buildings()
    {
        FactoryGameReader reader = new(Path.Combine(Directory.GetCurrentDirectory(), "Files"), "buildings.json");
        List<BuildingDescriptor> manufacturers = reader.Read<BuildingDescriptor>();
        manufacturers.Should().HaveCount(2);

        ManufacturerDescriptor manufacturerDescriptor = (ManufacturerDescriptor) manufacturers.Single(m => m.ClassName == "Build_ConstructorMk1_C");
        manufacturerDescriptor.PowerConsumption.Should().Be(4f);
        manufacturerDescriptor.PowerConsumptionExponent.Should().Be(1.6f);
    }
}