using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFinder.Domain.Models;
using PetFinder.Domain.Shared;

namespace PetFinder.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(Constants.Pet.MaxNameLength)
            .IsRequired();

        builder.Property(p => p.AnimalType)
            .HasMaxLength(Constants.Pet.MaxAnimalTypeLength)
            .IsRequired();

        builder.Property(p => p.GeneralDescription)
            .HasMaxLength(Constants.Pet.MaxGeneralDescriptionLength)
            .IsRequired();

        builder.Property(p => p.Breed)
            .HasMaxLength(Constants.Pet.MaxBreedLength)
            .IsRequired();

        builder.Property(p => p.Color)
            .HasMaxLength(Constants.Pet.MaxColorLength)
            .IsRequired();

        builder.Property(p => p.HealthInformation)
            .HasMaxLength(Constants.Pet.MaxHealthInformationLength)
            .IsRequired();

        builder.Property(p => p.Address)
            .HasMaxLength(Constants.Pet.MaxAddressLength)
            .IsRequired();

        builder.Property(p => p.Weight)
            .IsRequired();

        builder.Property(p => p.Height)
            .IsRequired();

        builder.Property(p => p.OwnerPhoneNumber)
            .HasMaxLength(Constants.Pet.MaxOwnerPhoneNumberLength)
            .IsRequired();

        builder.Property(p => p.BirthDate)
            .IsRequired();

        builder.Property(p => p.IsCastrated)
            .IsRequired();

        builder.Property(p => p.IsVaccinated)
            .IsRequired();

        builder.Property(p => p.HelpStatus)
            .IsRequired();

        builder.HasMany(p => p.Photos)
            .WithOne();
        
        builder.ToTable(
            name: Constants.Pet.TableName,
            buildAction: t =>
            {
                t.HasCheckConstraint("CK_Pet_weight", "\"weight\" > 0");
                t.HasCheckConstraint("CK_Pet_height", "\"height\" > 0");
            });
    }
}