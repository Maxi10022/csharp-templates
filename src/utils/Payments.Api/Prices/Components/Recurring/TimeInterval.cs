namespace Payments.Api.Prices.Components.Recurring;

/// <summary>
/// The frequency at which a subscription is billed. One of <c>Day</c>, <c>Week</c>, <c>Month</c> or <c>Year</c>.
/// </summary>
internal enum TimeInterval
{
    Day,
    Week,
    Month,
    Year
}