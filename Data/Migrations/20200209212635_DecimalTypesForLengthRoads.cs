using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class DecimalTypesForLengthRoads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SpatialNewslength",
                table: "sorted_roads",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DigitalOrthophotoLength",
                table: "sorted_roads",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SpatialNewslength",
                table: "sorted_roads",
                type: "decimal(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<decimal>(
                name: "DigitalOrthophotoLength",
                table: "sorted_roads",
                type: "decimal(10,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldMaxLength: 9,
                oldNullable: true);
        }
    }
}
