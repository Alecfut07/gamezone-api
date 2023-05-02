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
                    { 1L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8590), "Nintendo 64 Game", "The Legend of Zelda: Ocarina of Time", 42.99m, new DateTime(1998, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8610) },
                    { 2L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8610), "PlayStation 1 Game", "Tony Hawk's Pro Skater 2", 29.99m, new DateTime(2000, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8610) },
                    { 3L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8620), "PlayStation 3 Game", "Grand Theft Auto 4", 25.38m, new DateTime(2008, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8620) },
                    { 4L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8620), "SEGA Dreamcast Game", "Soul Calibur", 15.99m, new DateTime(1999, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8620) },
                    { 5L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8620), "Nintendo Wii Game", "Super Mario Galaxy", 33.33m, new DateTime(2007, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8630) },
                    { 6L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8630), "Nintendo Wii Game", "Super Mario Galaxy 2", 38.18m, new DateTime(2010, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8630) },
                    { 7L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8630), "Xbox One Game", "Read Dead Redemption 2", 40.92m, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8640) },
                    { 8L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8640), "Xbox One Game", "Grand Theft Auto 5", 27.88m, new DateTime(2014, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8640) },
                    { 9L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8640), "PC Game", "Disco Elysium: The Final Cut", 48.22m, new DateTime(2021, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8640) },
                    { 10L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8650), "Nintendo Switch Game", "The Legend of Zelda: Breath of the Wild", 12.33m, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8650) },
                    { 11L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8650), "Nintendo 64 Game", "Perfect Dark", 24.22m, new DateTime(2000, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8650) },
                    { 12L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8660), "Nintendo Gamecube Game", "Metroid Prime", 51.11m, new DateTime(2002, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8660) },
                    { 13L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8660), "Nintendo Switch Game", "Super Mario Odyssey", 14.73m, new DateTime(2017, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8660) },
                    { 14L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8670), "XBOX Game", "Halo: Combat Evolved", 17.48m, new DateTime(2001, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8670) },
                    { 15L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8670), "SEGA Dreamcast", "NFL 2K1", 19.99m, new DateTime(2000, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8670) },
                    { 16L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8680), "PC Game", "Half-Life 2", 32.22m, new DateTime(2004, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8680) },
                    { 17L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8680), "Xbox 360 Game", "BioSchock", 41.01m, new DateTime(2007, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8680) },
                    { 18L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8680), "Nintendo 64 Game", "GoldenEye 007", 52.21m, new DateTime(1997, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8690) },
                    { 19L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8690), "PlayStation 3 Game", "Uncharted 2: Among Thieves", 39.99m, new DateTime(2009, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8690) },
                    { 20L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8690), "Nintendo Gamecube Game", "Resident Evil 4", 55.55m, new DateTime(2005, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8690) },
                    { 21L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8700), "PlayStation 3 Game", "Batman: Arkham City", 43.73m, new DateTime(2011, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8700) },
                    { 22L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8700), "PlayStation 1 Game", "Tekken 3", 45.75m, new DateTime(1998, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8700) },
                    { 23L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8700), "Xbox Series X Game", "Elden Ring", 35.33m, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8710) },
                    { 24L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8710), "Xbox 360 Game", "Mass Effect 2", 23.23m, new DateTime(2010, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8710) },
                    { 25L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8710), "Nintendo Gamecube Game", "The Legend of Zelda: Twilight Princess", 41.73m, new DateTime(2006, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8710) },
                    { 26L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8720), "Xbox 360 Game", "The Elder Scrolls 5: Skyrim", 17.78m, new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8720) },
                    { 27L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8720), "Nintendo Gamecube Game", "The Legend of Zelda: The Wind Waker", 25.25m, new DateTime(2003, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8720) },
                    { 28L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8730), "PlayStation 1 Game", "Gran Turismo", 27.77m, new DateTime(1998, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8730) },
                    { 29L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8730), "PlayStation 2 Game", "Metal Gear Solid 2: Sons of Liberty", 36.66m, new DateTime(2001, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8730) },
                    { 30L, new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8740), "Nintendo Switch Game", "Persona 5 Royal", 60m, new DateTime(2022, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 24, 10, 19, 4, 246, DateTimeKind.Local).AddTicks(8740) }
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
