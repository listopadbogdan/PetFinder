using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFinder.Domain.Models;
using PetFinder.Domain.Shared;

namespace PetFinder.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.FirstName)
            .HasMaxLength(Constants.Volunteer.MaxFirstNameLength)
            .IsRequired();

        builder.Property(v => v.MiddleName)
            .HasMaxLength(Constants.Volunteer.MaxMiddleNameLength);

        builder.Property(v => v.LastName)
            .HasMaxLength(Constants.Volunteer.MaxLastNameLength)
            .IsRequired();

        builder.Property(v => v.PhoneNumber)
            .HasMaxLength(Constants.Volunteer.MaxPhoneNumberLength)
            .IsRequired();

        builder.Property(v => v.Description)
            .HasMaxLength(Constants.Volunteer.MaxDescriptionLength)
            .IsRequired();

        builder.OwnsMany(v => v.SocialNetworks)
            .ToJson();

        builder.OwnsMany(v => v.AssistanceDetails)
            .ToJson();

        builder.HasIndex(v => v.PhoneNumber)
            .IsUnique();

        builder.ToTable(
            name: Constants.Volunteer.TableName,
            buildAction: t =>
            {
                t.HasCheckConstraint("CK_Volunteer_experience_years", "\"experience_years\" > 0");
            });
    }
}