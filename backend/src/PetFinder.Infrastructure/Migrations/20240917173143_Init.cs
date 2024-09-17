using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_species", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "volunteers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    experience_years = table.Column<int>(type: "integer", nullable: false),
                    description_value = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    email_value = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    person_name_first_name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    person_name_last_name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    person_name_middle_name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    phone_number_value = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    assistance_details = table.Column<string>(type: "jsonb", nullable: true),
                    social_networks = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_volunteers", x => x.id);
                    table.CheckConstraint("CK_Volunteer_experience_years", "\"experience_years\" >= 0");
                });

            migrationBuilder.CreateTable(
                name: "breed",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    title = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    species_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_breed", x => x.id);
                    table.ForeignKey(
                        name: "fk_breed_species_species_id",
                        column: x => x.species_id,
                        principalTable: "species",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    animal_type = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    general_description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    color = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    health_information = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    weight = table.Column<double>(type: "double precision", nullable: false),
                    height = table.Column<double>(type: "double precision", nullable: false),
                    owner_phone_number = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: false),
                    is_castrated = table.Column<bool>(type: "boolean", nullable: false),
                    is_vaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    help_status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    volunteer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    address_city = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    address_country = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    address_description = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    address_house = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    address_street = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    species_breed_object_breed_id = table.Column<Guid>(type: "uuid", nullable: false),
                    species_breed_object_species_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pets", x => x.id);
                    table.CheckConstraint("CK_Pet_height", "\"height\" > 0");
                    table.CheckConstraint("CK_Pet_weight", "\"weight\" > 0");
                    table.ForeignKey(
                        name: "fk_pets_volunteers_volunteer_id",
                        column: x => x.volunteer_id,
                        principalTable: "volunteers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pet_photos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    is_main = table.Column<bool>(type: "boolean", nullable: false),
                    pet_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pet_photos", x => x.id);
                    table.ForeignKey(
                        name: "fk_pet_photos_pets_pet_id",
                        column: x => x.pet_id,
                        principalTable: "pets",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_breed_species_id",
                table: "breed",
                column: "species_id");

            migrationBuilder.CreateIndex(
                name: "ix_pet_photos_pet_id",
                table: "pet_photos",
                column: "pet_id");

            migrationBuilder.CreateIndex(
                name: "ix_pets_volunteer_id",
                table: "pets",
                column: "volunteer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "breed");

            migrationBuilder.DropTable(
                name: "pet_photos");

            migrationBuilder.DropTable(
                name: "species");

            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "volunteers");
        }
    }
}
