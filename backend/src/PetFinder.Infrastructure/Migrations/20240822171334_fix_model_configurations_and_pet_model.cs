using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFinder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_model_configurations_and_pet_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pet_volunteers_volunteer_id",
                table: "pet");

            migrationBuilder.DropForeignKey(
                name: "fk_pet_photo_pet_pet_id",
                table: "pet_photo");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pet_photo",
                table: "pet_photo");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pet",
                table: "pet");

            migrationBuilder.RenameTable(
                name: "pet_photo",
                newName: "pet_photos");

            migrationBuilder.RenameTable(
                name: "pet",
                newName: "pets");

            migrationBuilder.RenameIndex(
                name: "ix_pet_photo_pet_id",
                table: "pet_photos",
                newName: "ix_pet_photos_pet_id");

            migrationBuilder.RenameIndex(
                name: "ix_pet_volunteer_id",
                table: "pets",
                newName: "ix_pets_volunteer_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "volunteer_id",
                table: "pets",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pet_photos",
                table: "pet_photos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pets",
                table: "pets",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_pet_photos_pets_pet_id",
                table: "pet_photos",
                column: "pet_id",
                principalTable: "pets",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_pets_volunteers_volunteer_id",
                table: "pets",
                column: "volunteer_id",
                principalTable: "volunteers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pet_photos_pets_pet_id",
                table: "pet_photos");

            migrationBuilder.DropForeignKey(
                name: "fk_pets_volunteers_volunteer_id",
                table: "pets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pets",
                table: "pets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pet_photos",
                table: "pet_photos");

            migrationBuilder.RenameTable(
                name: "pets",
                newName: "pet");

            migrationBuilder.RenameTable(
                name: "pet_photos",
                newName: "pet_photo");

            migrationBuilder.RenameIndex(
                name: "ix_pets_volunteer_id",
                table: "pet",
                newName: "ix_pet_volunteer_id");

            migrationBuilder.RenameIndex(
                name: "ix_pet_photos_pet_id",
                table: "pet_photo",
                newName: "ix_pet_photo_pet_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "volunteer_id",
                table: "pet",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_pet",
                table: "pet",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pet_photo",
                table: "pet_photo",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_pet_volunteers_volunteer_id",
                table: "pet",
                column: "volunteer_id",
                principalTable: "volunteers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_pet_photo_pet_pet_id",
                table: "pet_photo",
                column: "pet_id",
                principalTable: "pet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
