using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshop.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Title" },
                values: new object[] { 1, "mobile_phone", "Mobile Phone" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Title" },
                values: new object[] { 2, "notebook", "Notebook" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Title" },
                values: new object[] { 3, "tablet", "Tablet" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "CurrencyId", "Description", "Discount", "ImgUrl", "ModifiedDate", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, 0.050000000000000003, "https://productimages.hepsiburada.net/s/51/375/11030207627314.jpg", null, "IPhone", 24000.0 },
                    { 2, 1, null, null, null, 0.050000000000000003, "https://productimages.hepsiburada.net/s/51/375/11030207627314.jpg", null, "Oppo", 16000.0 },
                    { 3, 1, null, null, null, 0.050000000000000003, "https://productimages.hepsiburada.net/s/51/375/11030207627314.jpg", null, "Xiaomi", 11000.0 },
                    { 4, 2, null, null, null, 0.050000000000000003, "https://productimages.hepsiburada.net/s/174/300-443/110000138043760.jpg", null, "Dell", 24000.0 },
                    { 5, 2, null, null, null, 0.050000000000000003, "https://productimages.hepsiburada.net/s/174/300-443/110000138043760.jpg", null, "MSI", 28000.0 },
                    { 6, 2, null, null, null, 0.050000000000000003, "https://productimages.hepsiburada.net/s/174/300-443/110000138043760.jpg", null, "Lenovo", 18000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
