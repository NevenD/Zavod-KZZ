using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class AddLocalGovernmentRoads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "local_government_roads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    LocalGovernmentAdministrationID = table.Column<int>(nullable: false),
                    RoadID = table.Column<int>(nullable: false),
                    RoadLength = table.Column<decimal>(maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_local_government_roads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_local_government_roads_local_governments_LocalGovernmentAdministrationID",
                        column: x => x.LocalGovernmentAdministrationID,
                        principalTable: "local_governments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_local_government_roads_sorted_roads_RoadID",
                        column: x => x.RoadID,
                        principalTable: "sorted_roads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_local_government_roads_LocalGovernmentAdministrationID",
                table: "local_government_roads",
                column: "LocalGovernmentAdministrationID");

            migrationBuilder.CreateIndex(
                name: "IX_local_government_roads_RoadID",
                table: "local_government_roads",
                column: "RoadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "local_government_roads");
        }
    }
}
