using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satistools.GameData.Recipes;

namespace Satistools.GameData.Configuration.Recipes;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.HasKey(nameof(RecipeIngredient.RecipeId), nameof(RecipeIngredient.ItemId));
        
        builder.HasOne(e => e.Item)
            .WithMany()
            .HasForeignKey(e => e.ItemId)
            .IsRequired();
    }
}