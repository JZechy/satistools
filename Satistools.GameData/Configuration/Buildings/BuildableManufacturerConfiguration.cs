using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satistools.GameData.Buildings;

namespace Satistools.GameData.Configuration.Buildings;

public class BuildableManufacturerConfiguration : IEntityTypeConfiguration<BuildableManufacturer>
{
    public void Configure(EntityTypeBuilder<BuildableManufacturer> builder)
    {
        builder.HasKey(b => b.Id);
    }
}