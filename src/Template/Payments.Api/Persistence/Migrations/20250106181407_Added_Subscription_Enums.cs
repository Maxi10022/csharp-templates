using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payments.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Added_Subscription_Enums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:payments.aggregate_usage", "last_during_period,last_ever,max,sum")
                .Annotation("Npgsql:Enum:payments.billing_scheme", "per_unit,tiered")
                .Annotation("Npgsql:Enum:payments.meter_event_time_window", "day,hour")
                .Annotation("Npgsql:Enum:payments.stripe_mode", "live,test")
                .Annotation("Npgsql:Enum:payments.stripe_status", "active,inactive")
                .Annotation("Npgsql:Enum:payments.subscription_status", "active,canceled,incomplete,incomplete_expired,past_due,paused,trialing,unpaid")
                .Annotation("Npgsql:Enum:payments.supported_currency", "eur")
                .Annotation("Npgsql:Enum:payments.tax_behaviour", "exclusive,inclusive,unspecified")
                .Annotation("Npgsql:Enum:payments.time_interval", "day,month,week,year")
                .Annotation("Npgsql:Enum:payments.usage_type", "licensed,metered")
                .OldAnnotation("Npgsql:Enum:payments.aggregate_usage", "last_during_period,last_ever,max,sum")
                .OldAnnotation("Npgsql:Enum:payments.billing_scheme", "per_unit,tiered")
                .OldAnnotation("Npgsql:Enum:payments.meter_event_time_window", "day,hour")
                .OldAnnotation("Npgsql:Enum:payments.stripe_mode", "live,test")
                .OldAnnotation("Npgsql:Enum:payments.stripe_status", "active,inactive")
                .OldAnnotation("Npgsql:Enum:payments.supported_currency", "eur")
                .OldAnnotation("Npgsql:Enum:payments.tax_behaviour", "exclusive,inclusive,unspecified")
                .OldAnnotation("Npgsql:Enum:payments.time_interval", "day,month,week,year")
                .OldAnnotation("Npgsql:Enum:payments.usage_type", "licensed,metered");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:payments.aggregate_usage", "last_during_period,last_ever,max,sum")
                .Annotation("Npgsql:Enum:payments.billing_scheme", "per_unit,tiered")
                .Annotation("Npgsql:Enum:payments.meter_event_time_window", "day,hour")
                .Annotation("Npgsql:Enum:payments.stripe_mode", "live,test")
                .Annotation("Npgsql:Enum:payments.stripe_status", "active,inactive")
                .Annotation("Npgsql:Enum:payments.supported_currency", "eur")
                .Annotation("Npgsql:Enum:payments.tax_behaviour", "exclusive,inclusive,unspecified")
                .Annotation("Npgsql:Enum:payments.time_interval", "day,month,week,year")
                .Annotation("Npgsql:Enum:payments.usage_type", "licensed,metered")
                .OldAnnotation("Npgsql:Enum:payments.aggregate_usage", "last_during_period,last_ever,max,sum")
                .OldAnnotation("Npgsql:Enum:payments.billing_scheme", "per_unit,tiered")
                .OldAnnotation("Npgsql:Enum:payments.meter_event_time_window", "day,hour")
                .OldAnnotation("Npgsql:Enum:payments.stripe_mode", "live,test")
                .OldAnnotation("Npgsql:Enum:payments.stripe_status", "active,inactive")
                .OldAnnotation("Npgsql:Enum:payments.subscription_status", "active,canceled,incomplete,incomplete_expired,past_due,paused,trialing,unpaid")
                .OldAnnotation("Npgsql:Enum:payments.supported_currency", "eur")
                .OldAnnotation("Npgsql:Enum:payments.tax_behaviour", "exclusive,inclusive,unspecified")
                .OldAnnotation("Npgsql:Enum:payments.time_interval", "day,month,week,year")
                .OldAnnotation("Npgsql:Enum:payments.usage_type", "licensed,metered");
        }
    }
}
