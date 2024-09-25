using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFinder.Domain.Shared.Ids;
using PetFinder.Domain.SharedKernel;
using PetFinder.Domain.Species.Models;

namespace PetFinder.Infrastructure.Configurations;

public class SpeciesConfiguration: IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable(Constants.Species.TableName);
        
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value));

        builder.HasMany(s => s.Breeds)
            .WithOne(b => b.Species)
            .HasForeignKey("species_id");

        builder.Property(s => s.Title)
            .HasColumnName("title")
            .HasMaxLength(Constants.Species.MaxTitleLength)
            .IsRequired();
    }
}