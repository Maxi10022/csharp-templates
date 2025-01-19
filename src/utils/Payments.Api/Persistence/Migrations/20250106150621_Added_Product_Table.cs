using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Payments.Api.Stripe;
using Payments.Api.Stripe.Components;

#nullable disable

namespace Payments.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Product_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                schema: "payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    stripe_id = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    mode = table.Column<StripeMode>(type: "payments.stripe_mode", nullable: false),
                    status = table.Column<StripeStatus>(type: "payments.stripe_status", nullable: false),
                    default_price_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_recurring_prices_product_id",
                schema: "payments",
                table: "recurring_prices",
                column: "product_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fixed_prices_product_id",
                schema: "payments",
                table: "fixed_prices",
                column: "product_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_fixed_prices_products_product_id",
                schema: "payments",
                table: "fixed_prices",
                column: "product_id",
                principalSchema: "payments",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recurring_prices_products_product_id",
                schema: "payments",
                table: "recurring_prices",
                column: "product_id",
                principalSchema: "payments",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fixed_prices_products_product_id",
                schema: "payments",
                table: "fixed_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_recurring_prices_products_product_id",
                schema: "payments",
                table: "recurring_prices");

            migrationBuilder.DropTable(
                name: "products",
                schema: "payments");

            migrationBuilder.DropIndex(
                name: "IX_recurring_prices_product_id",
                schema: "payments",
                table: "recurring_prices");

            migrationBuilder.DropIndex(
                name: "IX_fixed_prices_product_id",
                schema: "payments",
                table: "fixed_prices");
        }
    }
}
