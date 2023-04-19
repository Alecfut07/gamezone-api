using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamezone_api.Migrations
{
    /// <inheritdoc />
    public partial class ProductWithFKCondition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //var conditionId = migrationBuilder.Sql("SELECT id FROM dbo.conditions LIMIT 1");

            migrationBuilder.AddColumn<int>(
                name: "condition_id",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_products_condition_id",
                table: "products",
                column: "condition_id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_conditions_condition_id",
                table: "products",
                column: "condition_id",
                principalTable: "conditions",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_conditions_condition_id",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_condition_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "condition_id",
                table: "products");
        }
    }
}
