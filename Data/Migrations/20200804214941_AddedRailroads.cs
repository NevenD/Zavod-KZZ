using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class AddedRailroads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RailroadCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RailroadCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "railroads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 300, nullable: false),
                    RailroadCategoryID = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConstructionLength = table.Column<decimal>(maxLength: 9, nullable: false),
                    Lenght = table.Column<decimal>(maxLength: 9, nullable: false),
                    ReconstructionDate = table.Column<DateTime>(nullable: true),
                    ReconstructionLenght = table.Column<decimal>(maxLength: 9, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_railroads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_railroads_RailroadCategory_RailroadCategoryID",
                        column: x => x.RailroadCategoryID,
                        principalTable: "RailroadCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_railroads_RailroadCategoryID",
                table: "railroads",
                column: "RailroadCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "railroads");

            migrationBuilder.DropTable(
                name: "RailroadCategory");
        }
    }
}
