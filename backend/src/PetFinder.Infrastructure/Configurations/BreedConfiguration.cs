using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFinder.Domain.Shared.Ids;
using PetFinder.Domain.SharedKernel;
using PetFinder.Domain.Species.Models;

namespace PetFinder.Infrastructure.Configurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable(Constants.Breed.TableName);
        
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasConversion(
                id => id.Value,
                value => BreedId.Create(value));

        builder.HasOne(b => b.Species)
            .WithMany(s => s.Breeds)
            .HasForeignKey("species_id");
        
        builder.Property(b => b.Title)
            .HasColumnName("title")
            .HasMaxLength(Constants.Breed.MaxTitleLength)
            .IsRequired();

        builder.Property(b => b.Description)
            .HasColumnName("description")
            .HasMaxLength(Constants.Breed.MaxDescriptionLength)
            .IsRequired();
    }
}