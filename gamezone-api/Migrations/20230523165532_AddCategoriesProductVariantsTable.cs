using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamezone_api.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriesProductVariantsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<long>(
            //    name: "parent_category_id",
            //    table: "categories",
            //    type: "bigint",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "categories_product_variants",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    product_variant_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories_product_variants", x => x.id );
                    table.ForeignKey(
                        name: "FK_categories_product_variants_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_categories_product_variants_product_variants_product_variant_id",
                        column: x => x.product_variant_id,
                        principalTable: "product_variants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_categories_parent_category_id",
            //    table: "categories",
            //    column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_categories_product_variants_product_variant_id",
                table: "categories_product_variants",
                column: "product_variant_id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_categories_categories_parent_category_id",
            //    table: "categories",
            //    column: "parent_category_id",
            //    principalTable: "categories",
            //    principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_categories_parent_category_id",
                table: "categories");

            migrationBuilder.DropTable(
                name: "categories_product_variants");

            //migrationBuilder.DropIndex(
            //    name: "IX_categories_parent_category_id",
            //    table: "categories");

            //migrationBuilder.DropColumn(
            //    name: "parent_category_id",
            //    table: "categories");
        }
    }
}
