using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Payments.Api.Prices.Components;
using Payments.Api.Prices.Components.Recurring;
using Payments.Api.Stripe;
using Payments.Api.Stripe.Components;

#nullable disable

namespace Payments.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Price_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fixed_prices",
                schema: "payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    stripe_id = table.Column<string>(type: "text", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    currency = table.Column<SupportedCurrency>(type: "payments.supported_currency", nullable: false),
                    billing_scheme = table.Column<BillingScheme>(type: "payments.billing_scheme", nullable: false),
                    tax_behaviour = table.Column<TaxBehaviour>(type: "payments.tax_behaviour", nullable: false),
                    mode = table.Column<StripeMode>(type: "payments.stripe_mode", nullable: false),
                    status = table.Column<StripeStatus>(type: "payments.stripe_status", nullable: false),
                    unit_amount = table.Column<long>(type: "bigint", nullable: true),
                    unit_amount_decimal = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fixed_prices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recurring_prices",
                schema: "payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    stripe_id = table.Column<string>(type: "text", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    currency = table.Column<SupportedCurrency>(type: "payments.supported_currency", nullable: false),
                    billing_scheme = table.Column<BillingScheme>(type: "payments.billing_scheme", nullable: false),
                    tax_behaviour = table.Column<TaxBehaviour>(type: "payments.tax_behaviour", nullable: false),
                    mode = table.Column<StripeMode>(type: "payments.stripe_mode", nullable: false),
                    status = table.Column<StripeStatus>(type: "payments.stripe_status", nullable: false),
                    unit_amount = table.Column<long>(type: "bigint", nullable: true),
                    unit_amount_decimal = table.Column<decimal>(type: "numeric", nullable: true),
                    aggregate_usage = table.Column<AggregateUsage>(type: "payments.aggregate_usage", nullable: true),
                    interval = table.Column<TimeInterval>(type: "payments.time_interval", nullable: false),
                    interval_count = table.Column<long>(type: "bigint", nullable: false),
                    usage_type = table.Column<UsageType>(type: "payments.usage_type", nullable: false),
                    meter_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recurring_prices", x => x.id);
                    table.ForeignKey(
                        name: "FK_recurring_prices_meters_meter_id",
                        column: x => x.meter_id,
                        principalSchema: "payments",
                        principalTable: "meters",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_fixed_prices_stripe_id",
                schema: "payments",
                table: "fixed_prices",
                column: "stripe_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_recurring_prices_meter_id",
                schema: "payments",
                table: "recurring_prices",
                column: "meter_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_recurring_prices_stripe_id",
                schema: "payments",
                table: "recurring_prices",
                column: "stripe_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fixed_prices",
                schema: "payments");

            migrationBuilder.DropTable(
                name: "recurring_prices",
                schema: "payments");
        }
    }
}
