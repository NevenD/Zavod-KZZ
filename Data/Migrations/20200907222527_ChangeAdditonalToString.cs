using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class ChangeAdditonalToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileExtension",
                table: "additional_documents_zara",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "FileExtension",
                table: "additional_documents_zara",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
