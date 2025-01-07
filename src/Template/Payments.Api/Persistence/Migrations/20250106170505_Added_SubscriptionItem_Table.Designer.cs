﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Payments.Api.Meters.Components;
using Payments.Api.Persistence;
using Payments.Api.Prices.Components;
using Payments.Api.Prices.Components.Recurring;
using Payments.Api.Stripe;
using Payments.Api.Stripe.Components;

#nullable disable

namespace Payments.Api.Persistence.Migrations
{
    [DbContext(typeof(PaymentsDbContext))]
    [Migration("20250106170505_Added_SubscriptionItem_Table")]
    partial class Added_SubscriptionItem_Table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("payments")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "payments", "aggregate_usage", new[] { "last_during_period", "last_ever", "max", "sum" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "payments", "billing_scheme", new[] { "per_unit", "tiered" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "payments", "meter_event_time_window", new[] { "day", "hour" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "payments", "stripe_mode", new[] { "live", "test" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "payments", "stripe_status", new[] { "active", "inactive" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "payments", "supported_currency", new[] { "eur" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "payments", "tax_behaviour", new[] { "exclusive", "inclusive", "unspecified" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "payments", "time_interval", new[] { "day", "month", "week", "year" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "payments", "usage_type", new[] { "licensed", "metered" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Payments.Api.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("StripeId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("stripe_id");

                    b.HasKey("Id");

                    b.HasIndex("StripeId")
                        .IsUnique();

                    b.ToTable("customers", "payments");
                });

            modelBuilder.Entity("Payments.Api.Meters.Meter", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("display_name");

                    b.Property<StripeMode>("Mode")
                        .HasColumnType("payments.stripe_mode");

                    b.Property<StripeStatus>("Status")
                        .HasColumnType("payments.stripe_status");

                    b.Property<string>("StripeId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("stripe_id");

                    b.ComplexProperty<Dictionary<string, object>>("Event", "Payments.Api.Meters.Meter.Event#MeterEvent", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("event_name");

                            b1.Property<MeterEventTimeWindow?>("TimeWindow")
                                .HasColumnType("payments.meter_event_time_window")
                                .HasColumnName("time_window");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("StatusTransitions", "Payments.Api.Meters.Meter.StatusTransitions#MeterStatusTransitions", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<DateTime?>("DeactivatedAt")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("deactivated_at");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Timestamps", "Payments.Api.Meters.Meter.Timestamps#MeterTimestamps", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("created_at");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("updated_at");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("ValueSettings", "Payments.Api.Meters.Meter.ValueSettings#MeterValueSettings", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("EventPayloadKey")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("event_payload_key");
                        });

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StripeId")
                        .IsUnique();

                    b.ToTable("meters", "payments");
                });

            modelBuilder.Entity("Payments.Api.Prices.PriceBase", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<BillingScheme>("BillingScheme")
                        .HasColumnType("payments.billing_scheme")
                        .HasColumnName("billing_scheme");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<SupportedCurrency>("Currency")
                        .HasColumnType("payments.supported_currency")
                        .HasColumnName("currency");

                    b.Property<StripeMode>("Mode")
                        .HasColumnType("payments.stripe_mode")
                        .HasColumnName("mode");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<StripeStatus>("Status")
                        .HasColumnType("payments.stripe_status")
                        .HasColumnName("status");

                    b.Property<string>("StripeId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("stripe_id");

                    b.Property<TaxBehaviour>("TaxBehaviour")
                        .HasColumnType("payments.tax_behaviour")
                        .HasColumnName("tax_behaviour");

                    b.Property<long?>("UnitAmount")
                        .HasColumnType("bigint")
                        .HasColumnName("unit_amount");

                    b.Property<decimal?>("UnitAmountDecimal")
                        .HasColumnType("numeric")
                        .HasColumnName("unit_amount_decimal");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.HasIndex("StripeId")
                        .IsUnique();

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Payments.Api.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("DefaultPriceId")
                        .HasColumnType("uuid")
                        .HasColumnName("default_price_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<StripeMode>("Mode")
                        .HasColumnType("payments.stripe_mode")
                        .HasColumnName("mode");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<StripeStatus>("Status")
                        .HasColumnType("payments.stripe_status")
                        .HasColumnName("status");

                    b.Property<string>("StripeId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("stripe_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("products", "payments");
                });

            modelBuilder.Entity("Payments.Api.SubscriptionItems.SubscriptionItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("PriceId")
                        .HasColumnType("uuid")
                        .HasColumnName("price_id");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity");

                    b.Property<string>("StripeId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("stripe_id");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uuid")
                        .HasColumnName("subscription_id");

                    b.HasKey("Id");

                    b.HasIndex("PriceId");

                    b.ToTable("subscription_items", "payments");
                });

            modelBuilder.Entity("Payments.Api.Prices.FixedPrice", b =>
                {
                    b.HasBaseType("Payments.Api.Prices.PriceBase");

                    b.ToTable("fixed_prices", "payments");
                });

            modelBuilder.Entity("Payments.Api.Prices.RecurringPrice", b =>
                {
                    b.HasBaseType("Payments.Api.Prices.PriceBase");

                    b.Property<AggregateUsage?>("AggregateUsage")
                        .HasColumnType("payments.aggregate_usage")
                        .HasColumnName("aggregate_usage");

                    b.Property<TimeInterval>("Interval")
                        .HasColumnType("payments.time_interval")
                        .HasColumnName("interval");

                    b.Property<long>("IntervalCount")
                        .HasColumnType("bigint")
                        .HasColumnName("interval_count");

                    b.Property<Guid?>("MeterId")
                        .HasColumnType("uuid")
                        .HasColumnName("meter_id");

                    b.Property<UsageType>("UsageType")
                        .HasColumnType("payments.usage_type")
                        .HasColumnName("usage_type");

                    b.HasIndex("MeterId")
                        .IsUnique();

                    b.ToTable("recurring_prices", "payments");
                });

            modelBuilder.Entity("Payments.Api.Meters.Meter", b =>
                {
                    b.HasOne("Payments.Api.Customers.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Payments.Api.Prices.PriceBase", b =>
                {
                    b.HasOne("Payments.Api.Products.Product", "Product")
                        .WithOne("DefaultPrice")
                        .HasForeignKey("Payments.Api.Prices.PriceBase", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Payments.Api.SubscriptionItems.SubscriptionItem", b =>
                {
                    b.HasOne("Payments.Api.Prices.RecurringPrice", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Price");
                });

            modelBuilder.Entity("Payments.Api.Prices.RecurringPrice", b =>
                {
                    b.HasOne("Payments.Api.Meters.Meter", null)
                        .WithOne()
                        .HasForeignKey("Payments.Api.Prices.RecurringPrice", "MeterId");
                });

            modelBuilder.Entity("Payments.Api.Products.Product", b =>
                {
                    b.Navigation("DefaultPrice");
                });
#pragma warning restore 612, 618
        }
    }
}
