using Microsoft.EntityFrameworkCore.Migrations;

namespace ZAVOD_KZZ.Data.Migrations
{
    public partial class RailRoadCategoriesConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_railroads_RailroadCategory_RailroadCategoryID",
                table: "railroads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RailroadCategory",
                table: "RailroadCategory");

            migrationBuilder.RenameTable(
                name: "RailroadCategory",
                newName: "railroad_categories");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "railroads",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "railroad_categories",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_railroad_categories",
                table: "railroad_categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_railroads_railroad_categories_RailroadCategoryID",
                table: "railroads",
                column: "RailroadCategoryID",
                principalTable: "railroad_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_railroads_railroad_categories_RailroadCategoryID",
                table: "railroads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_railroad_categories",
                table: "railroad_categories");

            migrationBuilder.RenameTable(
                name: "railroad_categories",
                newName: "RailroadCategory");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "railroads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RailroadCategory",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RailroadCategory",
                table: "RailroadCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_railroads_RailroadCategory_RailroadCategoryID",
                table: "railroads",
                column: "RailroadCategoryID",
                principalTable: "RailroadCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
