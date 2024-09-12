﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetFinder.Infrastructure;

#nullable disable

namespace PetFinder.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PetFinder.Domain.Models.Breed", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("description");

                    b.Property<Guid>("SpeciesId")
                        .HasColumnType("uuid")
                        .HasColumnName("species_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_breed");

                    b.HasIndex("SpeciesId")
                        .HasDatabaseName("ix_breed_species_id");

                    b.ToTable("breed", (string)null);
                });

            modelBuilder.Entity("PetFinder.Domain.Models.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AnimalType")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("animal_type");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("breed");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("color");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("GeneralDescription")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("general_description");

                    b.Property<string>("HealthInformation")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("health_information");

                    b.Property<double>("Height")
                        .HasColumnType("double precision")
                        .HasColumnName("height");

                    b.Property<int>("HelpStatus")
                        .HasColumnType("integer")
                        .HasColumnName("help_status");

                    b.Property<bool>("IsCastrated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_castrated");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_vaccinated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("name");

                    b.Property<string>("OwnerPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)")
                        .HasColumnName("owner_phone_number");

                    b.Property<Guid?>("VolunteerId")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision")
                        .HasColumnName("weight");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "PetFinder.Domain.Models.Pet.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("address_city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("address_country");

                            b1.Property<string>("Description")
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("address_description");

                            b1.Property<string>("House")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("character varying(16)")
                                .HasColumnName("address_house");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("character varying(64)")
                                .HasColumnName("address_street");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("SpeciesBreedObject", "PetFinder.Domain.Models.Pet.SpeciesBreedObject#SpeciesBreedObject", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<Guid>("BreedId")
                                .HasColumnType("uuid")
                                .HasColumnName("species_breed_object_breed_id");

                            b1.Property<Guid>("SpeciesId")
                                .HasColumnType("uuid")
                                .HasColumnName("species_breed_object_species_id");
                        });

                    b.HasKey("Id")
                        .HasName("pk_pets");

                    b.HasIndex("VolunteerId")
                        .HasDatabaseName("ix_pets_volunteer_id");

                    b.ToTable("pets", null, t =>
                        {
                            t.HasCheckConstraint("CK_Pet_height", "\"height\" > 0");

                            t.HasCheckConstraint("CK_Pet_weight", "\"weight\" > 0");
                        });
                });

            modelBuilder.Entity("PetFinder.Domain.Models.PetPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean")
                        .HasColumnName("is_main");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("path");

                    b.Property<Guid?>("PetId")
                        .HasColumnType("uuid")
                        .HasColumnName("pet_id");

                    b.HasKey("Id")
                        .HasName("pk_pet_photos");

                    b.HasIndex("PetId")
                        .HasDatabaseName("ix_pet_photos_pet_id");

                    b.ToTable("pet_photos", (string)null);
                });

            modelBuilder.Entity("PetFinder.Domain.Models.Species", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_species");

                    b.ToTable("species", (string)null);
                });

            modelBuilder.Entity("PetFinder.Domain.Models.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("description");

                    b.Property<int>("ExperienceYears")
                        .HasColumnType("integer")
                        .HasColumnName("experience_years");

                    b.ComplexProperty<Dictionary<string, object>>("Email", "PetFinder.Domain.Models.Volunteer.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("email_value");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PersonName", "PetFinder.Domain.Models.Volunteer.PersonName#PersonName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(32)
                                .HasColumnType("character varying(32)")
                                .HasColumnName("person_name_first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(32)
                                .HasColumnType("character varying(32)")
                                .HasColumnName("person_name_last_name");

                            b1.Property<string>("MiddleName")
                                .HasMaxLength(32)
                                .HasColumnType("character varying(32)")
                                .HasColumnName("person_name_middle_name");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumber", "PetFinder.Domain.Models.Volunteer.PhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("character varying(16)")
                                .HasColumnName("phone_number_value");
                        });

                    b.HasKey("Id")
                        .HasName("pk_volunteers");

                    b.ToTable("volunteers", null, t =>
                        {
                            t.HasCheckConstraint("CK_Volunteer_experience_years", "\"experience_years\" >= 0");
                        });
                });

            modelBuilder.Entity("PetFinder.Domain.Models.Breed", b =>
                {
                    b.HasOne("PetFinder.Domain.Models.Species", "Species")
                        .WithMany("Breeds")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_breed_species_species_id");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("PetFinder.Domain.Models.Pet", b =>
                {
                    b.HasOne("PetFinder.Domain.Models.Volunteer", null)
                        .WithMany("Pets")
                        .HasForeignKey("VolunteerId")
                        .HasConstraintName("fk_pets_volunteers_volunteer_id");
                });

            modelBuilder.Entity("PetFinder.Domain.Models.PetPhoto", b =>
                {
                    b.HasOne("PetFinder.Domain.Models.Pet", null)
                        .WithMany("Photos")
                        .HasForeignKey("PetId")
                        .HasConstraintName("fk_pet_photos_pets_pet_id");
                });

            modelBuilder.Entity("PetFinder.Domain.Models.Volunteer", b =>
                {
                    b.OwnsMany("PetFinder.Domain.Models.AssistanceDetails", "AssistanceDetails", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("VolunteerId", "Id");

                            b1.ToTable("volunteers");

                            b1.ToJson("assistance_details");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_volunteer_id");
                        });

                    b.OwnsMany("PetFinder.Domain.Models.SocialNetwork", "SocialNetworks", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            b1.Property<string>("Title")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("VolunteerId", "Id");

                            b1.ToTable("volunteers");

                            b1.ToJson("social_networks");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteers_volunteers_volunteer_id");
                        });

                    b.Navigation("AssistanceDetails");

                    b.Navigation("SocialNetworks");
                });

            modelBuilder.Entity("PetFinder.Domain.Models.Pet", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("PetFinder.Domain.Models.Species", b =>
                {
                    b.Navigation("Breeds");
                });

            modelBuilder.Entity("PetFinder.Domain.Models.Volunteer", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
