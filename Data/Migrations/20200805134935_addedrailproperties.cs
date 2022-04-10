using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class addedrailproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainPositionNumber",
                table: "railroads",
                maxLength: 9,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainStationNumber",
                table: "railroads",
                maxLength: 9,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrainPositionNumber",
                table: "railroads");

            migrationBuilder.DropColumn(
                name: "TrainStationNumber",
                table: "railroads");
        }
    }
}
