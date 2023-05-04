using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gamezone_api.Migrations
{
    /// <inheritdoc />
    public partial class AddProductVariantsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_products_variants_conditions_condition_id",
            //    table: "products_variants");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_products_variants_editions_edition_id",
            //    table: "products_variants");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_products_variants_products_product_id",
            //    table: "products_variants");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_products_variants",
            //    table: "products_variants");

            //migrationBuilder.RenameTable(
            //    name: "products_variants",
            //    newName: "product_variants");

            //migrationBuilder.RenameIndex(
            //    name: "IX_products_variants_product_id",
            //    table: "product_variants",
            //    newName: "IX_product_variants_product_id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_products_variants_edition_id",
            //    table: "product_variants",
            //    newName: "IX_product_variants_edition_id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_products_variants_condition_id",
            //    table: "product_variants",
            //    newName: "IX_product_variants_condition_id");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_product_variants",
            //    table: "product_variants",
            //    column: "id");

            migrationBuilder.InsertData(
                table: "product_variants",
                columns: new[] { "id", "condition_id", "edition_id", "price", "product_id" },
                values: new object[,]
                {
                    { 1L, 1, 1, 10.20m, 1L },
                    { 2L, 1, 2, 15.10m, 2L },
                    { 3L, 1, 3, 5.12m, 3L },
                    { 4L, 2, 1, 40.22m, 4L },
                    { 5L, 2, 2, 32.25m, 5L },
                    { 6L, 2, 3, 12.11m, 6L },
                    { 7L, 3, 1, 2.02m, 7L },
                    { 8L, 3, 2, 11.11m, 8L },
                    { 9L, 3, 3, 3.33m, 9L },
                    { 10L, 1, 1, 31.31m, 10L },
                    { 11L, 2, 1, 60m, 11L },
                    { 12L, 3, 1, 21m, 12L },
                    { 13L, 1, 2, 10.01m, 13L },
                    { 14L, 2, 2, 9m, 14L },
                    { 15L, 3, 2, 2m, 15L },
                    { 16L, 1, 3, 45.21m, 16L },
                    { 17L, 2, 3, 40.04m, 17L },
                    { 18L, 3, 3, 12.43m, 18L },
                    { 19L, 1, 2, 7.07m, 19L },
                    { 20L, 1, 3, 4.31m, 20L },
                    { 21L, 2, 1, 6.50m, 21L },
                    { 22L, 2, 3, 17.90m, 22L },
                    { 23L, 3, 1, 27m, 23L },
                    { 24L, 3, 2, 30.08m, 24L },
                    { 25L, 3, 2, 41.14m, 25L },
                    { 26L, 3, 1, 18.89m, 26L },
                    { 27L, 2, 3, 55m, 27L },
                    { 28L, 2, 1, 5m, 28L },
                    { 29L, 1, 3, 46.72m, 29L },
                    { 30L, 1, 2, 60m, 30L }
                });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_product_variants_conditions_condition_id",
            //    table: "product_variants",
            //    column: "condition_id",
            //    principalTable: "conditions",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_product_variants_editions_edition_id",
            //    table: "product_variants",
            //    column: "edition_id",
            //    principalTable: "editions",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_product_variants_products_product_id",
            //    table: "product_variants",
            //    column: "product_id",
            //    principalTable: "products",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_product_variants_conditions_condition_id",
            //    table: "product_variants");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_product_variants_editions_edition_id",
            //    table: "product_variants");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_product_variants_products_product_id",
            //    table: "product_variants");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_product_variants",
            //    table: "product_variants");

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "product_variants",
                keyColumn: "id",
                keyValue: 30L);

            //migrationBuilder.RenameTable(
            //    name: "product_variants",
            //    newName: "products_variants");

            //migrationBuilder.RenameIndex(
            //    name: "IX_product_variants_product_id",
            //    table: "products_variants",
            //    newName: "IX_products_variants_product_id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_product_variants_edition_id",
            //    table: "products_variants",
            //    newName: "IX_products_variants_edition_id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_product_variants_condition_id",
            //    table: "products_variants",
            //    newName: "IX_products_variants_condition_id");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_products_variants",
            //    table: "products_variants",
            //    column: "id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_products_variants_conditions_condition_id",
            //    table: "products_variants",
            //    column: "condition_id",
            //    principalTable: "conditions",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_products_variants_editions_edition_id",
            //    table: "products_variants",
            //    column: "edition_id",
            //    principalTable: "editions",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_products_variants_products_product_id",
            //    table: "products_variants",
            //    column: "product_id",
            //    principalTable: "products",
            //    principalColumn: "id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
