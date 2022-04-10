using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class ChangeFileSizeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "FileSize",
                table: "spatial_plan_additional_documents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileSize",
                table: "spatial_plan_additional_documents",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
