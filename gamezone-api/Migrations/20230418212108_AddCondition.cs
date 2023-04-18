using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamezone_api.Migrations
{
    /// <inheritdoc />
    public partial class AddCondition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "conditions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conditions", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "conditions",
                columns: new[] { "id", "state" },
                values: new object[,]
                {
                    { 1, "NEW" },
                    { 2, "PRE_OWNED" },
                    { 3, "DIGITAL" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conditions");
        }
    }
}
