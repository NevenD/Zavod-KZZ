using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class AddedZaraDocumentsAndConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "document_zara_status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_zara_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "document_zara_types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_zara_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "official_document_zara",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    DocumentTypeZaraId = table.Column<int>(nullable: false),
                    OfficalSpatialNewsId = table.Column<int>(nullable: false),
                    OfficialSpatialNewsNumber = table.Column<string>(nullable: false),
                    OfficialSpatialNewsNumberUrl = table.Column<string>(nullable: true),
                    DocumentStatusZaraId = table.Column<int>(nullable: false),
                    DocumentEffectiveDate = table.Column<DateTime>(nullable: true),
                    DocumentIneffectiveDate = table.Column<DateTime>(nullable: true),
                    DocumentRemark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_official_document_zara", x => x.Id);
                    table.ForeignKey(
                        name: "FK_official_document_zara_document_zara_status_DocumentStatusZaraId",
                        column: x => x.DocumentStatusZaraId,
                        principalTable: "document_zara_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_official_document_zara_document_zara_types_DocumentTypeZaraId",
                        column: x => x.DocumentTypeZaraId,
                        principalTable: "document_zara_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_official_document_zara_official_spatial_news_OfficalSpatialNewsId",
                        column: x => x.OfficalSpatialNewsId,
                        principalTable: "official_spatial_news",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "additional_documents_zara",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    FileName = table.Column<string>(nullable: false),
                    UniqueFileName = table.Column<string>(nullable: true),
                    FileExtension = table.Column<double>(nullable: false),
                    FileSizeInMb = table.Column<double>(nullable: false),
                    OfficialDocumentZaraId = table.Column<int>(nullable: false)
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
                    FileName = table.Column<string>(nullable: false),
                    UniqueFileName = table.Column<string>(nullable: true),
                    FileExtension = table.Column<double>(nullable: false),
                    FileSizeInMb = table.Column<double>(nullable: false),
                    OfficialDocumentZaraId = table.Column<int>(nullable: false)
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
                name: "IX_official_document_zara_DocumentStatusZaraId",
                table: "official_document_zara",
                column: "DocumentStatusZaraId");

            migrationBuilder.CreateIndex(
                name: "IX_official_document_zara_DocumentTypeZaraId",
                table: "official_document_zara",
                column: "DocumentTypeZaraId");

            migrationBuilder.CreateIndex(
                name: "IX_official_document_zara_OfficalSpatialNewsId",
                table: "official_document_zara",
                column: "OfficalSpatialNewsId");

            migrationBuilder.CreateIndex(
                name: "IX_required_documents_zara_OfficialDocumentZaraId",
                table: "required_documents_zara",
                column: "OfficialDocumentZaraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "additional_documents_zara");

            migrationBuilder.DropTable(
                name: "required_documents_zara");

            migrationBuilder.DropTable(
                name: "official_document_zara");

            migrationBuilder.DropTable(
                name: "document_zara_status");

            migrationBuilder.DropTable(
                name: "document_zara_types");
        }
    }
}
