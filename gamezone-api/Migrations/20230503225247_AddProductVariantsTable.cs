using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamezone_api.Migrations
{
    /// <inheritdoc />
    public partial class AddProductVariantsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_conditions_condition_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_editions_edition_id",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_condition_id",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_edition_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "condition_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "edition_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "price",
                table: "products");

            migrationBuilder.CreateTable(
                name: "product_variants",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    condition_id = table.Column<int>(type: "int", nullable: false),
                    edition_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_variants", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_variants_conditions_condition_id",
                        column: x => x.condition_id,
                        principalTable: "conditions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_product_variants_editions_edition_id",
                        column: x => x.edition_id,
                        principalTable: "editions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_product_variants_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_variants_condition_id",
                table: "product_variants",
                column: "condition_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_variants_edition_id",
                table: "product_variants",
                column: "edition_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_variants_product_id",
                table: "product_variants",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_variants");

            migrationBuilder.AddColumn<int>(
                name: "condition_id",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "edition_id",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_products_condition_id",
                table: "products",
                column: "condition_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_edition_id",
                table: "products",
                column: "edition_id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_conditions_condition_id",
                table: "products",
                column: "condition_id",
                principalTable: "conditions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_editions_edition_id",
                table: "products",
                column: "edition_id",
                principalTable: "editions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
