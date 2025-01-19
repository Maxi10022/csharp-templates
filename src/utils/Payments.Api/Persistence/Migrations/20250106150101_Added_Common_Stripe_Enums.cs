using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payments.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Common_Stripe_Enums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:payments.stripe_mode", "live,test")
                .Annotation("Npgsql:Enum:payments.stripe_status", "active,inactive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
