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
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreateDate", "Description", "Name", "Price", "ReleaseDate", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("1ef23f06-626e-4329-afe8-4251c6866293"), new DateTime(2023, 4, 17, 13, 35, 20, 542, DateTimeKind.Local).AddTicks(7080), "PlayStation 5 Console", "PS5", 500m, new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 17, 13, 35, 20, 542, DateTimeKind.Local).AddTicks(7120) },
                    { new Guid("396e7720-0071-4d1a-818f-5af2299e18ee"), new DateTime(2023, 4, 17, 13, 35, 20, 542, DateTimeKind.Local).AddTicks(7130), "Nintendo Switch Console", "Nintendo Switch", 300m, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 17, 13, 35, 20, 542, DateTimeKind.Local).AddTicks(7130) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
