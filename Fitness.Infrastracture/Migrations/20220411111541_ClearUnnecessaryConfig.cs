using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness.Infrastracture.Migrations
{
    public partial class ClearUnnecessaryConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "FitnessProgram");

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "FitnessType",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Award",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "FitnessType");

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
        }
    }
}
