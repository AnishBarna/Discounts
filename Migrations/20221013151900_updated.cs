using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Discount.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    CityName = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    DiscountedProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Product_pkey", x => x.DiscountedProductId);
                });

            migrationBuilder.CreateTable(
                name: "Product_City",
                columns: table => new
                {
                    Product_DiscountedProductId = table.Column<long>(type: "bigint", nullable: false),
                    City_CityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "Product_City_City_CityId_fkey",
                        column: x => x.City_CityId,
                        principalTable: "City",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "Product_City_Product_DiscountedProductId_fkey",
                        column: x => x.Product_DiscountedProductId,
                        principalTable: "Product",
                        principalColumn: "DiscountedProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_City_City_CityId",
                table: "Product_City",
                column: "City_CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_City_Product_DiscountedProductId",
                table: "Product_City",
                column: "Product_DiscountedProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_City");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
