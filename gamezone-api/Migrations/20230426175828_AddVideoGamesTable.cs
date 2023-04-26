using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamezone_api.Migrations
{
    /// <inheritdoc />
    public partial class AddVideoGamesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "videogames",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    publisher_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videogames", x => x.id);
                    table.ForeignKey(
                        name: "FK_videogames_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_videogames_publishers_publisher_id",
                        column: x => x.publisher_id,
                        principalTable: "publishers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_videogames_product_id",
                table: "videogames",
                column: "product_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_videogames_publisher_id",
                table: "videogames",
                column: "publisher_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "videogames");
        }
    }
}
