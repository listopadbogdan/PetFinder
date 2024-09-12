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

        builder.Property(v => v.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value));

        builder.ComplexProperty(v => v.PersonName, vnb =>
        {
            vnb.Property(v => v.FirstName)
                .HasMaxLength(Constants.Volunteer.MaxFirstNameLength)
                .IsRequired();

            vnb.Property(v => v.MiddleName)
                .HasMaxLength(Constants.Volunteer.MaxMiddleNameLength);

            vnb.Property(v => v.LastName)
                .HasMaxLength(Constants.Volunteer.MaxLastNameLength)
                .IsRequired();
        });

        builder.ComplexProperty(v => v.PhoneNumber, pnb =>
        {
            pnb.Property(p => p.Value)
                .HasMaxLength(Constants.PhoneNumber.MaxLength)
                .IsRequired();
        });

        builder.ComplexProperty(v => v.Email, pnb =>
        {
            pnb.Property(p => p.Value)
                .HasMaxLength(Constants.Email.MaxLength)
                .IsRequired();
        });

        builder.Property(v => v.Description)
            .HasMaxLength(Constants.Volunteer.MaxDescriptionLength)
            .IsRequired();

        builder.Property(v => v.ExperienceYears)
            .IsRequired();

        builder.OwnsMany(v => v.SocialNetworks)
            .ToJson();

        builder.OwnsMany(v => v.AssistanceDetails)
            .ToJson();

        builder.HasMany(v => v.Pets)
            .WithOne();
        
        //TODO - resolve problem with UQ index for Volunteer.PhoneNumber
        // builder.HasIndex(Constants.PhoneNumber.ColumnName)
        //     .HasDatabaseName("UQ_Volunteer_phone_number")
        //     .IsUnique(); 

        builder.ToTable(
            Constants.Volunteer.TableName,
            t => { t.HasCheckConstraint("CK_Volunteer_experience_years", "\"experience_years\" >= 0"); });
    }
}