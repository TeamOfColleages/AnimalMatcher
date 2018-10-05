using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalMatcher.Data.Migrations
{
    public partial class RenameAnimalsToPets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "Animals", newName: "Pets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "Pets", newName: "Animals");
        }
    }
}
