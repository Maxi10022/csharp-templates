using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payments.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_SubscriptionItem_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subscription_items",
                schema: "payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    stripe_id = table.Column<string>(type: "text", nullable: false),
                    subscription_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    quantity = table.Column<long>(type: "bigint", nullable: false),
                    price_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_subscription_items_recurring_prices_price_id",
                        column: x => x.price_id,
                        principalSchema: "payments",
                        principalTable: "recurring_prices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subscription_items_price_id",
                schema: "payments",
                table: "subscription_items",
                column: "price_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscription_items",
                schema: "payments");
        }
    }
}
