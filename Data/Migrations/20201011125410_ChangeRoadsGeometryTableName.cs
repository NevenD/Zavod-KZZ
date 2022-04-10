using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class ChangeRoadsGeometryTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_road_geometry_sorted_roads_RoadID",
                table: "road_geometry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_road_geometry",
                table: "road_geometry");

            migrationBuilder.RenameTable(
                name: "road_geometry",
                newName: "sorted_roads_geometry");

            migrationBuilder.RenameIndex(
                name: "IX_road_geometry_RoadID",
                table: "sorted_roads_geometry",
                newName: "IX_sorted_roads_geometry_RoadID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sorted_roads_geometry",
                table: "sorted_roads_geometry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sorted_roads_geometry_sorted_roads_RoadID",
                table: "sorted_roads_geometry",
                column: "RoadID",
                principalTable: "sorted_roads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sorted_roads_geometry_sorted_roads_RoadID",
                table: "sorted_roads_geometry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sorted_roads_geometry",
                table: "sorted_roads_geometry");

            migrationBuilder.RenameTable(
                name: "sorted_roads_geometry",
                newName: "road_geometry");

            migrationBuilder.RenameIndex(
                name: "IX_sorted_roads_geometry_RoadID",
                table: "road_geometry",
                newName: "IX_road_geometry_RoadID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_road_geometry",
                table: "road_geometry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_road_geometry_sorted_roads_RoadID",
                table: "road_geometry",
                column: "RoadID",
                principalTable: "sorted_roads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
