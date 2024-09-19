using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFinder.Domain.Shared.Ids;
using PetFinder.Domain.SharedKernel;
using PetFinder.Domain.Volunteer.Models;

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
                .HasColumnName("first_name")
                .HasMaxLength(Constants.Volunteer.MaxFirstNameLength)
                .IsRequired();

            vnb.Property(v => v.MiddleName)
                .HasColumnName("middle_name")
                .HasMaxLength(Constants.Volunteer.MaxMiddleNameLength);

            vnb.Property(v => v.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(Constants.Volunteer.MaxLastNameLength)
                .IsRequired();
        });

        builder.ComplexProperty(v => v.PhoneNumber, pnb =>
        {
            pnb.Property(p => p.Value)
                .HasColumnName("phone_number")
                .HasMaxLength(Constants.PhoneNumber.MaxLength)
                .IsRequired();
        });

        builder.ComplexProperty(v => v.Email, pnb =>
        {
            pnb.Property(p => p.Value)
                .HasColumnName("email")
                .HasMaxLength(Constants.Email.MaxLength)
                .IsRequired();
        });

        builder.ComplexProperty(v => v.Description, cpb =>
        {
            cpb.Property(d => d.Value)
                .HasColumnName("description")
                .HasMaxLength(Constants.Volunteer.MaxDescriptionLength)
                .IsRequired();
        });

        builder.Property(v => v.ExperienceYears)
            .HasColumnName("experience_years")
            .IsRequired();

        builder.OwnsOne(v => v.SocialNetworks, snb =>
        {
            snb.ToJson("social_networks");

            snb.OwnsMany(voList => voList.Values, sn =>
            {
                sn.Property(p => p.Title)
                    .HasColumnName("title")
                    .HasMaxLength(Constants.SocialNetwork.MaxTitleLength)
                    .IsRequired();

                sn.Property(p => p.Url)
                    .HasColumnName("url")
                    .HasMaxLength(Constants.SocialNetwork.MaxUrlLength)
                    .IsRequired();
            });
        });

        builder.OwnsOne(v => v.AssistanceDetails, adb =>
        {
            adb.ToJson("assistance_details");

            adb.OwnsMany(voList => voList.Values, ad =>
            {
                ad.Property(p => p.Title)
                    .HasColumnName("title")
                    .HasMaxLength(Constants.AssistanceDetail.MaxTitleLength)
                    .IsRequired();

                ad.Property(p => p.Description)
                    .HasColumnName("description")
                    .HasMaxLength(Constants.AssistanceDetail.MaxDescriptionLength)
                    .IsRequired();
            });
        });
        
        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        //TODO - resolve problem with UQ index for Volunteer.PhoneNumber
        // builder.HasIndex(Constants.PhoneNumber.ColumnName)
        //     .HasDatabaseName("UQ_Volunteer_phone_number")
        //     .IsUnique(); 

        builder.ToTable(
            Constants.Volunteer.TableName,
            t => { t.HasCheckConstraint("CK_Volunteer_experience_years", "\"experience_years\" >= 0"); });
    }
}
