﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamezone_api.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceColumnToOrderDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "order_details",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "order_details");
        }
    }
}
