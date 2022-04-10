using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class AddingGeojsonFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoordinatesProjected",
                table: "road_geometry",
                newName: "GeoJSON");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GeoJSON",
                table: "road_geometry",
                newName: "CoordinatesProjected");
        }
    }
}
