using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Payments.Api.Meters.Components;
using Payments.Api.Stripe;
using Payments.Api.Stripe.Components;

#nullable disable

namespace Payments.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Meter_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "meters",
                schema: "payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    stripe_id = table.Column<string>(type: "text", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<StripeStatus>(type: "payments.stripe_status", nullable: false),
                    Mode = table.Column<StripeMode>(type: "payments.stripe_mode", nullable: false),
                    event_name = table.Column<string>(type: "text", nullable: false),
                    time_window = table.Column<MeterEventTimeWindow>(type: "payments.meter_event_time_window", nullable: true),
                    deactivated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    event_payload_key = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meters", x => x.id);
                    table.ForeignKey(
                        name: "FK_meters_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "payments",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_meters_customer_id",
                schema: "payments",
                table: "meters",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_meters_stripe_id",
                schema: "payments",
                table: "meters",
                column: "stripe_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "meters",
                schema: "payments");
        }
    }
}
