using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payments.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Meter_Enums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:payments.meter_event_time_window", "day,hour")
                .Annotation("Npgsql:Enum:payments.stripe_mode", "live,test")
                .Annotation("Npgsql:Enum:payments.stripe_status", "active,inactive")
                .OldAnnotation("Npgsql:Enum:payments.stripe_mode", "live,test")
                .OldAnnotation("Npgsql:Enum:payments.stripe_status", "active,inactive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:payments.stripe_mode", "live,test")
                .Annotation("Npgsql:Enum:payments.stripe_status", "active,inactive")
                .OldAnnotation("Npgsql:Enum:payments.meter_event_time_window", "day,hour")
                .OldAnnotation("Npgsql:Enum:payments.stripe_mode", "live,test")
                .OldAnnotation("Npgsql:Enum:payments.stripe_status", "active,inactive");
        }
    }
}
