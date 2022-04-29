using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satistools.GameData.Recipes;

namespace Satistools.GameData.Configuration.Recipes;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(nameof(Recipe.Id));
        builder.Property(p => p.DisplayName).IsRequired();

        builder.HasOne(e => e.ProducedIn)
            .WithMany()
            .HasForeignKey(e => e.ProducedInId)
            .IsRequired();

        builder.HasMany(e => e.Ingredients)
            .WithOne()
            .HasForeignKey(e => e.RecipeId)
            .IsRequired();

        builder.HasMany(e => e.Products)
            .WithOne()
            .HasForeignKey(e => e.RecipeId)
            .IsRequired();
    }
}