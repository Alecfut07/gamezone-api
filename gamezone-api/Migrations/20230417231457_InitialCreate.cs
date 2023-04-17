using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gamezone_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    release_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "create_date", "description", "name", "price", "release_date", "update_date" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 4, 17, 17, 14, 57, 904, DateTimeKind.Local).AddTicks(7230), "PlayStation 5 Console", "PS5", 500m, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 17, 17, 14, 57, 904, DateTimeKind.Local).AddTicks(7270) },
                    { 2L, new DateTime(2023, 4, 17, 17, 14, 57, 904, DateTimeKind.Local).AddTicks(7280), "Nintendo Switch Console", "Nintendo Switch", 300m, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 17, 17, 14, 57, 904, DateTimeKind.Local).AddTicks(7280) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
