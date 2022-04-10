using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class RemoveRoadGeometryLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineLength",
                table: "sorted_roads_geometry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LineLength",
                table: "sorted_roads_geometry",
                maxLength: 9,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
