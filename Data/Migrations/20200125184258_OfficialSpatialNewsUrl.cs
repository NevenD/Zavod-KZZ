using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class OfficialSpatialNewsUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfficialSpatialNewsNumberUrl",
                table: "spatial_plan_documents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficialSpatialNewsNumberUrl",
                table: "spatial_plan_documents");
        }
    }
}
