using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class ChangedPropertyFileSizeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileSize",
                table: "spatial_plan_additional_documents",
                newName: "FileSizeInMb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileSizeInMb",
                table: "spatial_plan_additional_documents",
                newName: "FileSize");
        }
    }
}
