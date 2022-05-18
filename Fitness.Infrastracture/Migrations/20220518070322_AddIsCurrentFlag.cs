using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness.Infrastracture.Migrations
{
    public partial class AddIsCurrentFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCurrent",
                table: "PersonFitnessProgram",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCurrent",
                table: "PersonFitnessProgram");
        }
    }
}
