using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamezone_api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueConstraintEmailAndTaxAndGrandTotalToOrdersAndDetailsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_orders_email",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "grandtotal",
                table: "order_details");

            migrationBuilder.DropColumn(
                name: "tax",
                table: "order_details");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "grandtotal",
                table: "order_details",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "tax",
                table: "order_details",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_orders_email",
                table: "orders",
                column: "email",
                unique: true);
        }
    }
}
