using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class ChangeNameOfRegulations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_regulations_regulation_type_RegulationTypeID",
                table: "regulations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_regulation_type",
                table: "regulation_type");

            migrationBuilder.RenameTable(
                name: "regulation_type",
                newName: "regulation_types");

            migrationBuilder.AddPrimaryKey(
                name: "PK_regulation_types",
                table: "regulation_types",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_regulations_regulation_types_RegulationTypeID",
                table: "regulations",
                column: "RegulationTypeID",
                principalTable: "regulation_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_regulations_regulation_types_RegulationTypeID",
                table: "regulations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_regulation_types",
                table: "regulation_types");

            migrationBuilder.RenameTable(
                name: "regulation_types",
                newName: "regulation_type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_regulation_type",
                table: "regulation_type",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_regulations_regulation_type_RegulationTypeID",
                table: "regulations",
                column: "RegulationTypeID",
                principalTable: "regulation_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
