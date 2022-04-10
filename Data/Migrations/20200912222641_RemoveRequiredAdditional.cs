using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class RemoveRequiredAdditional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "additional_documents_zara");

            migrationBuilder.DropTable(
                name: "required_documents_zara");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "additional_documents_zara",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    FileExtension = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: false),
                    FileSizeInMb = table.Column<double>(nullable: false),
                    OfficialDocumentZaraId = table.Column<int>(nullable: false),
                    UniqueFileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_additional_documents_zara", x => x.Id);
                    table.ForeignKey(
                        name: "FK_additional_documents_zara_official_document_zara_OfficialDocumentZaraId",
                        column: x => x.OfficialDocumentZaraId,
                        principalTable: "official_document_zara",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "required_documents_zara",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    FileExtension = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: false),
                    FileSizeInMb = table.Column<double>(nullable: false),
                    OfficialDocumentZaraId = table.Column<int>(nullable: false),
                    UniqueFileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_required_documents_zara", x => x.Id);
                    table.ForeignKey(
                        name: "FK_required_documents_zara_official_document_zara_OfficialDocumentZaraId",
                        column: x => x.OfficialDocumentZaraId,
                        principalTable: "official_document_zara",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_additional_documents_zara_OfficialDocumentZaraId",
                table: "additional_documents_zara",
                column: "OfficialDocumentZaraId");

            migrationBuilder.CreateIndex(
                name: "IX_required_documents_zara_OfficialDocumentZaraId",
                table: "required_documents_zara",
                column: "OfficialDocumentZaraId");
        }
    }
}
