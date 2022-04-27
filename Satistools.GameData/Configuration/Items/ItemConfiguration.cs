using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satistools.GameData.Items;

namespace Satistools.GameData.Configuration.Items;

/// <summary>
/// Configuration of <see cref="Item"/> table.
/// </summary>
public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(nameof(Item.Id));
        builder.Property(p => p.DisplayName).IsRequired();
    }
}