using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class AddedNaturalChangePopulation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "natural_change_population",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    LiveBirth = table.Column<int>(nullable: false),
                    StillBirth = table.Column<int>(nullable: true),
                    InfantDeath = table.Column<int>(nullable: true),
                    Death = table.Column<int>(nullable: false),
                    LocalGovernmentAdministrationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_natural_change_population", x => x.Id);
                    table.ForeignKey(
                        name: "FK_natural_change_population_local_governments_LocalGovernmentAdministrationID",
                        column: x => x.LocalGovernmentAdministrationID,
                        principalTable: "local_governments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_natural_change_population_LocalGovernmentAdministrationID",
                table: "natural_change_population",
                column: "LocalGovernmentAdministrationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "natural_change_population");
        }
    }
}
