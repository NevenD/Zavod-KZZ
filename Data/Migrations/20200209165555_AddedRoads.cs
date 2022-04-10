using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class AddedRoads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sorted_roads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 300, nullable: false),
                    RoadCategoryID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DigitalOrthophotoLength = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    SpatialNewslength = table.Column<decimal>(type: "decimal(10,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sorted_roads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sorted_roads_road_categories_RoadCategoryID",
                        column: x => x.RoadCategoryID,
                        principalTable: "road_categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sorted_roads_RoadCategoryID",
                table: "sorted_roads",
                column: "RoadCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sorted_roads");
        }
    }
}
