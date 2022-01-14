using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftsmanshipStore.ProductApi.Migrations
{
    public partial class SeedProductDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[] { new Guid("369ae3a1-7cfa-494a-97a5-eb036419dfe4"), "Painting", "Mountain Wood Wall Art, Painting Wood Wall Art, Vertical Wall Art, Wall Decor, Wood Wall Hanging, Housewarming Gift, Office Decor", "https://images.unsplash.com/photo-1640946756511-f5026d7614f9?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1074&q=80", "Mountain Wood Wall Art", 69.8m });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[] { new Guid("b0242955-2e14-4110-938f-95dffdcb2da2"), "Flower", "Glass Tube Vase/Flower Vase Pot/Unique Handmade Home Decor/Living Room Office Table Vase", "https://images.unsplash.com/photo-1444930694458-01babf71870c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=963&q=80", "Metal Wire Decorative", 147.85m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("369ae3a1-7cfa-494a-97a5-eb036419dfe4"));

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: new Guid("b0242955-2e14-4110-938f-95dffdcb2da2"));
        }
    }
}
