using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class AddedRekonstruction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaintenanceDescription",
                table: "sorted_roads",
                newName: "ReconstructionDescription");

            migrationBuilder.RenameColumn(
                name: "MaintenanceDate",
                table: "sorted_roads",
                newName: "ReconstructionDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReconstructionDescription",
                table: "sorted_roads",
                newName: "MaintenanceDescription");

            migrationBuilder.RenameColumn(
                name: "ReconstructionDate",
                table: "sorted_roads",
                newName: "MaintenanceDate");
        }
    }
}
