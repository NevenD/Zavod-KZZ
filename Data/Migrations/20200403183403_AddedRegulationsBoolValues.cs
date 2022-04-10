using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class AddedRegulationsBoolValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDrainageRegulation",
                table: "regulations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGasRegulation",
                table: "regulations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOtherRegulation",
                table: "regulations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRailRoadRegulation",
                table: "regulations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSortedRoadRegulation",
                table: "regulations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSpatialDocumentRegulation",
                table: "regulations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUnSortedRoadRegulation",
                table: "regulations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWaterSupplyRegulation",
                table: "regulations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RegulationRemarks",
                table: "regulations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDrainageRegulation",
                table: "regulations");

            migrationBuilder.DropColumn(
                name: "IsGasRegulation",
                table: "regulations");

            migrationBuilder.DropColumn(
                name: "IsOtherRegulation",
                table: "regulations");

            migrationBuilder.DropColumn(
                name: "IsRailRoadRegulation",
                table: "regulations");

            migrationBuilder.DropColumn(
                name: "IsSortedRoadRegulation",
                table: "regulations");

            migrationBuilder.DropColumn(
                name: "IsSpatialDocumentRegulation",
                table: "regulations");

            migrationBuilder.DropColumn(
                name: "IsUnSortedRoadRegulation",
                table: "regulations");

            migrationBuilder.DropColumn(
                name: "IsWaterSupplyRegulation",
                table: "regulations");

            migrationBuilder.DropColumn(
                name: "RegulationRemarks",
                table: "regulations");
        }
    }
}
