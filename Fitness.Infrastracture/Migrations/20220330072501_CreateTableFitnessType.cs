using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness.Infrastracture.Migrations
{
    public partial class CreateTableFitnessType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessTip_FitnessProgram_FitnessProgramId",
                table: "FitnessTip");

            migrationBuilder.AddColumn<int>(
                name: "FitnessTypeId",
                table: "FitnessProgram",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FitnessType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FitnessProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessType_FitnessProgram_Id",
                        column: x => x.Id,
                        principalTable: "FitnessProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessTip_FitnessProgram_FitnessProgramId",
                table: "FitnessTip",
                column: "FitnessProgramId",
                principalTable: "FitnessProgram",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessTip_FitnessProgram_FitnessProgramId",
                table: "FitnessTip");

            migrationBuilder.DropTable(
                name: "FitnessType");

            migrationBuilder.DropColumn(
                name: "FitnessTypeId",
                table: "FitnessProgram");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessTip_FitnessProgram_FitnessProgramId",
                table: "FitnessTip",
                column: "FitnessProgramId",
                principalTable: "FitnessProgram",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
