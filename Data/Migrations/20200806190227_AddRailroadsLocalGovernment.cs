using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class AddRailroadsLocalGovernment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "local_government_railroads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    LocalGovernmentAdministrationID = table.Column<int>(nullable: false),
                    RailroadID = table.Column<int>(nullable: false),
                    RailroadLength = table.Column<decimal>(maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_local_government_railroads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_local_government_railroads_local_governments_LocalGovernmentAdministrationID",
                        column: x => x.LocalGovernmentAdministrationID,
                        principalTable: "local_governments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_local_government_railroads_railroads_RailroadID",
                        column: x => x.RailroadID,
                        principalTable: "railroads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_local_government_railroads_LocalGovernmentAdministrationID",
                table: "local_government_railroads",
                column: "LocalGovernmentAdministrationID");

            migrationBuilder.CreateIndex(
                name: "IX_local_government_railroads_RailroadID",
                table: "local_government_railroads",
                column: "RailroadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "local_government_railroads");
        }
    }
}
