using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamezone_api.Migrations
{
    /// <inheritdoc />
    public partial class AddEditionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "editions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editions", x => x.id);
                });
            migrationBuilder.InsertData("editions", "type", "NORMAL");
            migrationBuilder.InsertData("editions", "type", "DELUXE_EDITION");
            migrationBuilder.InsertData("editions", "type", "COLLECTORS_EDITION");

            migrationBuilder.AddColumn<int>(
                name: "edition_id",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_products_edition_id",
                table: "products",
                column: "edition_id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_editions_edition_id",
                table: "products",
                column: "edition_id",
                principalTable: "editions",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_editions_edition_id",
                table: "products");

            migrationBuilder.DropTable(
                name: "editions");

            migrationBuilder.DropIndex(
                name: "IX_products_edition_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "edition_id",
                table: "products");
        }
    }
}
