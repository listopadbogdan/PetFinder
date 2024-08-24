using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFinder.Domain.Models;
using PetFinder.Domain.Shared;

namespace PetFinder.Infrastructure.Configurations;

public class PetPhotoConfiguration : IEntityTypeConfiguration<PetPhoto>
{
    public void Configure(EntityTypeBuilder<PetPhoto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Path)
            .HasMaxLength(Constants.PetPhoto.MaxPathLength)
            .IsRequired();

        builder.Property(p => p.IsMain)
            .IsRequired();

        builder.ToTable(
            name: Constants.PetPhoto.TableName
        );
    }
}