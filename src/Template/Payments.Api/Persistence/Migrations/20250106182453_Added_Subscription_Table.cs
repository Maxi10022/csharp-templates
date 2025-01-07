using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Payments.Api.Stripe;
using Payments.Api.Stripe.Components;
using Payments.Api.Subscriptions.Components;

#nullable disable

namespace Payments.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Subscription_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subscriptions",
                schema: "payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    stripe_id = table.Column<string>(type: "text", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<SubscriptionStatus>(type: "payments.subscription_status", nullable: false),
                    currency = table.Column<SupportedCurrency>(type: "payments.supported_currency", nullable: false),
                    current_period_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    current_period_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cancel_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_subscriptions_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "payments",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subscription_items_subscription_id",
                schema: "payments",
                table: "subscription_items",
                column: "subscription_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_customer_id",
                schema: "payments",
                table: "subscriptions",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_subscription_items_subscriptions_subscription_id",
                schema: "payments",
                table: "subscription_items",
                column: "subscription_id",
                principalSchema: "payments",
                principalTable: "subscriptions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subscription_items_subscriptions_subscription_id",
                schema: "payments",
                table: "subscription_items");

            migrationBuilder.DropTable(
                name: "subscriptions",
                schema: "payments");

            migrationBuilder.DropIndex(
                name: "IX_subscription_items_subscription_id",
                schema: "payments",
                table: "subscription_items");
        }
    }
}
