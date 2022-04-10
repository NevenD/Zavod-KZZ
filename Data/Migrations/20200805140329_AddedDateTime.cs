using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class AddedDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReconstructionDate",
                table: "railroads",
                newName: "ReconstructionDateStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReconstructionDateEnd",
                table: "railroads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReconstructionDateEnd",
                table: "railroads");

            migrationBuilder.RenameColumn(
                name: "ReconstructionDateStart",
                table: "railroads",
                newName: "ReconstructionDate");
        }
    }
}
