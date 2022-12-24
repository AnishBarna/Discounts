using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Discount.Migrations
{
    public partial class FinalTest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Product_City_City_CityId_fkey",
                table: "Product_City");

            migrationBuilder.DropForeignKey(
                name: "Product_City_Product_DiscountedProductId_fkey",
                table: "Product_City");

            migrationBuilder.DropIndex(
                name: "IX_Product_City_Product_DiscountedProductId",
                table: "Product_City");

            migrationBuilder.DropPrimaryKey(
                name: "Product_pkey",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropColumn(
                name: "Product_DiscountedProductId",
                table: "Product_City");

            migrationBuilder.DropColumn(
                name: "DiscountedProductId",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product_City",
                newName: "ProductCities");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameColumn(
                name: "City_CityId",
                table: "ProductCities",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_City_City_CityId",
                table: "ProductCities",
                newName: "IX_ProductCities_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductCities",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "ProductCities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Cities",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCities",
                table: "ProductCities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityId");

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductCityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCities_CityId",
                table: "ProductCities",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCities_Cities_CityId",
                table: "ProductCities",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCities_Products_ProductId",
                table: "ProductCities",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCities_Cities_CityId",
                table: "ProductCities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCities_Products_ProductId",
                table: "ProductCities");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCities",
                table: "ProductCities");

            migrationBuilder.DropIndex(
                name: "IX_ProductCities_CityId",
                table: "ProductCities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductCities");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "ProductCities");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductCities",
                newName: "Product_City");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product_City",
                newName: "City_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCities_ProductId",
                table: "Product_City",
                newName: "IX_Product_City_City_CityId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Product",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Product",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "DiscountedProductId",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "Product_DiscountedProductId",
                table: "Product_City",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "City",
                type: "character varying",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "City",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "Product_pkey",
                table: "Product",
                column: "DiscountedProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_City_Product_DiscountedProductId",
                table: "Product_City",
                column: "Product_DiscountedProductId");

            migrationBuilder.AddForeignKey(
                name: "Product_City_City_CityId_fkey",
                table: "Product_City",
                column: "City_CityId",
                principalTable: "City",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "Product_City_Product_DiscountedProductId_fkey",
                table: "Product_City",
                column: "Product_DiscountedProductId",
                principalTable: "Product",
                principalColumn: "DiscountedProductId");
        }
    }
}
