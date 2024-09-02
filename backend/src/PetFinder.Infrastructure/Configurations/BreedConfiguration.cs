using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFinder.Domain.Models;
using PetFinder.Domain.Shared;

namespace PetFinder.Infrastructure.Configurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasConversion(
                id => id.Value,
                value => BreedId.Create(value));

        builder.HasOne(b => b.Species)
            .WithMany(s => s.Breeds);
        
        builder.Property(b => b.Title)
            .HasMaxLength(Constants.Breed.MaxTitleLength)
            .IsRequired();

        builder.Property(b => b.Description)
            .HasMaxLength(Constants.Breed.MaxDescriptionLength)
            .IsRequired();
    }
}