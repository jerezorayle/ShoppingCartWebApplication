using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartWebApplication.Migrations
{
    public partial class RenamedColumnCreatedAtToDateAddedInShoppingCartItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ShoppingCartItems",
                newName: "DateAdded");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "ShoppingCartItems",
                newName: "CreatedAt");

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name", "Price", "Quantity" },
                values: new object[] { 1, new DateTime(2021, 6, 9, 3, 3, 37, 473, DateTimeKind.Local).AddTicks(9234), new DateTime(2021, 6, 9, 3, 3, 37, 474, DateTimeKind.Local).AddTicks(8509), "Sign Pen", 1.5m, (short)0 });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name", "Price", "Quantity" },
                values: new object[] { 2, new DateTime(2021, 6, 9, 3, 3, 37, 474, DateTimeKind.Local).AddTicks(9069), new DateTime(2021, 6, 9, 3, 3, 37, 474, DateTimeKind.Local).AddTicks(9101), "Coffee Mug", 2.25m, (short)0 });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name", "Price", "Quantity" },
                values: new object[] { 3, new DateTime(2021, 6, 9, 3, 3, 37, 474, DateTimeKind.Local).AddTicks(9109), new DateTime(2021, 6, 9, 3, 3, 37, 474, DateTimeKind.Local).AddTicks(9111), "Navy Blue Longsleeves", 12.75m, (short)0 });
        }
    }
}
