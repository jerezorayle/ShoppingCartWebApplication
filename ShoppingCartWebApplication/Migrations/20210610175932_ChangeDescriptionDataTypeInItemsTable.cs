using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartWebApplication.Migrations
{
    public partial class ChangeDescriptionDataTypeInItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "nvarchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");
        }
    }
}
