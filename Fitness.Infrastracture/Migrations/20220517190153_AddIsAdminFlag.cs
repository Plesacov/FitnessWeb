using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness.Infrastracture.Migrations
{
    public partial class AddIsAdminFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVip",
                table: "Person");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Person");

            migrationBuilder.AddColumn<bool>(
                name: "IsVip",
                table: "Person",
                type: "bit",
                nullable: true);
        }
    }
}
