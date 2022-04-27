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
        builder.Ignore(p => p.PerMin);
    }
}