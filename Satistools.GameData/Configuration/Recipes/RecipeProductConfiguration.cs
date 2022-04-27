﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satistools.GameData.Recipes;

namespace Satistools.GameData.Configuration.Recipes;

public class RecipeProductConfiguration : IEntityTypeConfiguration<RecipeProduct>
{
    public void Configure(EntityTypeBuilder<RecipeProduct> builder)
    {
        builder.HasKey(nameof(RecipeProduct.RecipeId), nameof(RecipeProduct.ItemId));

        builder.HasOne(e => e.Recipe)
            .WithMany(r => r.Products)
            .HasForeignKey(e => e.RecipeId)
            .IsRequired();

        builder.HasOne(e => e.Item)
            .WithMany()
            .HasForeignKey(e => e.ItemId)
            .IsRequired();

        builder.Ignore(p => p.PerMin);
    }
}