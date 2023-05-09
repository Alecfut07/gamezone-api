using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gamezone_api.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersAndAddressesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "address_id",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    line_1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    line_2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    zip_code = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "addresses",
                columns: new[] { "id", "city", "country", "line_1", "line_2", "state", "zip_code" },
                values: new object[,]
                {
                    { 1L, "Denver", "United States", "7700 S Broadway, Littleton", "", "CO", "80122" },
                    { 2L, "Denver", "United States", "5460 S Broadway, Englewood", "", "CO", "80113" },
                    { 3L, "San Diego", "United States", "435 H St, Chula Vista", "", "CA", "91910" },
                    { 4L, "San Diego", "United States", "500 Hotel Cir N, San Diego", "Room 10", "CA", "92108" },
                    { 5L, "San Diego", "United States", "5998 Alcala Park Way, San Diego", "", "CA", "92110" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "address_id", "birthday", "create_date", "email", "first_name", "last_name", "encrypted_password", "phone", "update_date" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2000, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 6, 15, 53, 51, 280, DateTimeKind.Local).AddTicks(7130), "alec@gmail.com", "Alec", "Ortega", "123456", "(664)329-1243", new DateTime(2023, 5, 6, 15, 53, 51, 280, DateTimeKind.Local).AddTicks(7140) },
                    { 2L, 2L, new DateTime(1990, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 6, 15, 53, 51, 280, DateTimeKind.Local).AddTicks(7140), "alexis@gmail.com", "Alexis", "Ortega", "123456", "(664)937-3897", new DateTime(2023, 5, 6, 15, 53, 51, 280, DateTimeKind.Local).AddTicks(7150) },
                    { 3L, 3L, new DateTime(1988, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 6, 15, 53, 51, 280, DateTimeKind.Local).AddTicks(7150), "armando@gmail.com", "Armando", "Ortega", "123456", "(664)467-2145", new DateTime(2023, 5, 6, 15, 53, 51, 280, DateTimeKind.Local).AddTicks(7150) },
                    { 4L, 4L, new DateTime(1952, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 6, 15, 53, 51, 280, DateTimeKind.Local).AddTicks(7150), "aop@gmail.com", "Armando", "Ortega Partida", "123456", "(664)894-4378", new DateTime(2023, 5, 6, 15, 53, 51, 280, DateTimeKind.Local).AddTicks(7150) },
                    { 5L, 5L, new DateTime(1963, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 6, 15, 53, 51, 280, DateTimeKind.Local).AddTicks(7160), "patricia@gmail.com", "Patricia", "Cisneros Mayoral", "123456", "(664)399-1289", new DateTime(2023, 5, 6, 15, 53, 51, 280, DateTimeKind.Local).AddTicks(7160) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_address_id",
                table: "users",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_phone",
                table: "users",
                column: "phone",
                unique: true,
                filter: "[phone] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_users_addresses_address_id",
                table: "users",
                column: "address_id",
                principalTable: "addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_addresses_address_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropIndex(
                name: "IX_users_address_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_phone",
                table: "users");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "users");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "users");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "users");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "users");
        }
    }
}
