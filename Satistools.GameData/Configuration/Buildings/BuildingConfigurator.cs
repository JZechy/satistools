using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Satistools.GameData.Buildings;

namespace Satistools.GameData.Configuration.Buildings;

public class BuildingConfigurator : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.HasKey(p => p.Id);
    }
}