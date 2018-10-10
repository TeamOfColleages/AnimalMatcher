using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalMatcher.Data.Migrations
{
    public partial class PetLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Pets",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Pets",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Pets");
        }
    }
}
