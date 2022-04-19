using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness.Infrastracture.Migrations
{
    public partial class ChangeConfigurationOfOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessTip_FitnessProgram_FitnessProgramId",
                table: "FitnessTip");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "FitnessProgram");

            migrationBuilder.AddColumn<int>(
                name: "FitnessTypeId",
                table: "FitnessProgram",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Award",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateTable(
                name: "FitnessType",
                columns: table => new
                {
                    FitnessProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessType", x => x.FitnessProgramId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessProgram_FitnessTypeId",
                table: "FitnessProgram",
                column: "FitnessTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessProgram_FitnessType_FitnessTypeId",
                table: "FitnessProgram",
                column: "FitnessTypeId",
                principalTable: "FitnessType",
                principalColumn: "FitnessProgramId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_FitnessProgram_FitnessType_FitnessTypeId",
                table: "FitnessProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessTip_FitnessProgram_FitnessProgramId",
                table: "FitnessTip");

            migrationBuilder.DropTable(
                name: "FitnessType");

            migrationBuilder.DropIndex(
                name: "IX_FitnessProgram_FitnessTypeId",
                table: "FitnessProgram");

            migrationBuilder.DropColumn(
                name: "FitnessTypeId",
                table: "FitnessProgram");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Award");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "FitnessProgram",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

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
