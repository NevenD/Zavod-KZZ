using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class AddedRegulationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "regulation_type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regulation_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "regulations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    RegulationPublicationDate = table.Column<DateTime>(nullable: true),
                    RegulationEffectiveDate = table.Column<DateTime>(nullable: true),
                    DateArchived = table.Column<DateTime>(nullable: true),
                    RegulationTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regulations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_regulations_regulation_type_RegulationTypeID",
                        column: x => x.RegulationTypeID,
                        principalTable: "regulation_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_regulations_RegulationTypeID",
                table: "regulations",
                column: "RegulationTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "regulations");

            migrationBuilder.DropTable(
                name: "regulation_type");
        }
    }
}
