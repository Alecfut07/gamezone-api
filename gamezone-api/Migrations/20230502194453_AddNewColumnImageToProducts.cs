using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamezone_api.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnImageToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "products",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1190), "https://coverproject.sfo2.cdn.digitaloceanspaces.com/nintendo_64/n64_zeldaoot_label_thumb.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1220), "https://coverproject.sfo2.cdn.digitaloceanspaces.com/playstation_1/ps1_tonyhawksproskater2_front_de_thumb.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1220) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1220), "https://m.media-amazon.com/images/I/81rSkcE4IYL._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1230), "https://coverproject.sfo2.cdn.digitaloceanspaces.com/dreamcast/dc_soulcalibur_front_thumb.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1230), "https://static.wikia.nocookie.net/nintendo/images/0/00/Super_Mario_Galaxy_%28EU%29.jpg/revision/latest?cb=20090401224138&path-prefix=en", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 6L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1240), "https://upload.wikimedia.org/wikipedia/en/6/65/Super_Mario_Galaxy_2_Box_Art.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1240) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 7L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1240), "https://m.media-amazon.com/images/I/81bbAeAG6vS.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 8L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1250), "https://xboxaddict.com/images/box_art/3243.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 9L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1250), "https://gamefaqs.gamespot.com/a/box/4/5/4/793454_front.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 10L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1260), "https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 11L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1260), "https://i.ebayimg.com/images/g/CegAAOSwn8FXSnIj/s-l500.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 12L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1270), "https://static.wikia.nocookie.net/metroid/images/b/ba/MetroidPrimebox.jpg/revision/latest?cb=20220716192249", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 13L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1270), "https://m.media-amazon.com/images/I/71QevE1u3xL.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 14L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1280), "https://pbs.twimg.com/media/FcJiQ3dXEAEFT1B.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 15L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1280), "https://m.media-amazon.com/images/I/511HHH8C48L.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1280) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 16L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1290), "https://upload.wikimedia.org/wikipedia/en/thumb/2/25/Half-Life_2_cover.jpg/220px-Half-Life_2_cover.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 17L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1290), "https://store-images.s-microsoft.com/image/apps.35693.67628702173327834.9631ebfc-9c57-41b2-b688-4acf5b3815ce.ad223159-35ee-40ef-983b-58be333febbc?q=90&w=177&h=177", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 18L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1290), "https://upload.wikimedia.org/wikipedia/en/3/36/GoldenEye007box.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 19L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1300), "https://m.media-amazon.com/images/I/61bfoo-Z9cL.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 20L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1300), "https://upload.wikimedia.org/wikipedia/en/d/d9/Resi4-gc-cover.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 21L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1310), "https://1.bp.blogspot.com/-RaTxp5ajcNc/TfpQ50ApvCI/AAAAAAAAFkQ/AIjaHa9mdJQ/s1600/Arkham-City-PS3-Cover-Artwork_5.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 22L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1310), "https://static.wikia.nocookie.net/gamia_gamepedia_en/images/9/99/Front-Cover-Tekken-3-EU-PS1.jpg/revision/latest?cb=20180806163905", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 23L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1320), "https://m.media-amazon.com/images/I/81AXuMBqy9L._AC_UF1000,1000_QL80_.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 24L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1320), "https://i.ebayimg.com/images/g/JJMAAOSwHZhhYTPc/s-l1600.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1320) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 25L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1330), "https://m.media-amazon.com/images/I/51I25VxTAfL.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 26L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1330), "https://m.media-amazon.com/images/I/91nOykIoY3L.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 27L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1340), "https://wiki.dolphin-emu.org/images/9/98/Wind_waker_boxart.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 28L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1340), "https://i.ebayimg.com/images/g/05YAAOSwlxRaaLU5/s-l300.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1340) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 29L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1350), "https://cdn.staticneo.com/boxshots/MjAwNS8=/metal_gear_solid_2_sons_of_liberty_frontcover_large_NICQvk5nPZUjp8Y.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 30L,
                columns: new[] { "create_date", "image_url", "update_date" },
                values: new object[] { new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1350), "https://m.media-amazon.com/images/I/81qu57lDKpL.jpg", new DateTime(2023, 5, 2, 11, 27, 49, 311, DateTimeKind.Local).AddTicks(1350) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_url",
                table: "products");
        }
    }
}
