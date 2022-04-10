using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class AddGeometryAndRoadsMaintenanceDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MaintenanceDate",
                table: "sorted_roads",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaintenanceDescription",
                table: "sorted_roads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "road_geometry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CoordinatesProjected = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoordinatesUnprojected = table.Column<string>(nullable: true),
                    WKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineLength = table.Column<decimal>(maxLength: 9, nullable: false),
                    RoadID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_road_geometry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_road_geometry_sorted_roads_RoadID",
                        column: x => x.RoadID,
                        principalTable: "sorted_roads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_road_geometry_RoadID",
                table: "road_geometry",
                column: "RoadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "road_geometry");

            migrationBuilder.DropColumn(
                name: "MaintenanceDate",
                table: "sorted_roads");

            migrationBuilder.DropColumn(
                name: "MaintenanceDescription",
                table: "sorted_roads");
        }
    }
}
