using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Satistools.DataReader.Entities;
using Satistools.DataReader.Entities.Items;

namespace Satistools.DataReader.Test;

public class DataParserTest
{
    /// <summary>
    /// Tests reading of item descriptor.
    /// </summary>
    [Test]
    public void Test_ItemDescriptor()
    {
        DataReader reader = new(Path.Combine(Directory.GetCurrentDirectory(), "Files"), "itemdescriptor.json");
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
        DataReader reader = new(Path.Combine(Directory.GetCurrentDirectory(), "Files"), "recipe.json");
        List<Recipe> recipes = reader.Read<Recipe>();
        recipes.Should().HaveCount(1);

        Recipe recipe = recipes.First();
        recipe.DisplayName.Should().Be("Reinforced Iron Plate");
        recipe.ManufactoringDuration.Should().Be(12f);
        recipe.Ingredients.Should().HaveCount(2);
        recipe.Products.Should().HaveCount(1);
        recipe.ProducedIn.Should().HaveCount(3);

        Recipe.Part firstPart = recipe.Ingredients.First();
        firstPart.Amount.Should().Be(6);
        firstPart.ClassName.Should().Be("Desc_IronPlate_C");

        Recipe.Part firstProduct = recipe.Products.First();
        firstProduct.Amount.Should().Be(1);
        firstProduct.ClassName.Should().Be("Desc_IronPlateReinforced_C");

        Recipe.Producer firstProducer = recipe.ProducedIn.First();
        firstProducer.ClassName.Should().Be("Build_AssemblerMk1_C");
    }
}