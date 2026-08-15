namespace KamiSama.Modules.ServicePlans.Features.Subscriptions;

/// <summary>
/// Carries paging, filtering, and ordering criteria for subscription listing.
/// </summary>
/// <param name="Page">The one-based page number, or the paging convention accepted by the implementation.</param>
/// <param name="PageSize">The maximum number of subscriptions to return.</param>
/// <param name="SubscriberId">The optional owning subscriber identifier filter.</param>
/// <param name="PlanId">The optional acquired plan identifier filter.</param>
/// <param name="Statuses">The optional set of accepted subscription statuses.</param>
/// <param name="OrderBy">The optional implementation-defined ordering token.</param>
public record SubscriptionSearchModel(
	int Page,
	int PageSize,
	Guid? SubscriberId,
	Guid? PlanId,
	SubscriptionStatus[]? Statuses,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	/// <summary>
	/// Gets or sets the shared search model requesting all subscriptions without filters.
	/// </summary>
	/// <value>A mutable all-records search model; replacing it affects every caller that reads this property.</value>
	public static new SubscriptionSearchModel All { get; set; } = new(default, default, default, default, default, default);
}

/// <summary>
/// Returns a subscriber's acquired plan, lifecycle state, and caller-managed usage counters.
/// </summary>
/// <param name="Id">The subscription identifier.</param>
/// <param name="SubscriberId">The owning subscriber identifier.</param>
/// <param name="PlanId">The acquired plan identifier.</param>
/// <param name="Status">The subscription status.</param>
/// <param name="StartsAt">The activation timestamp.</param>
/// <param name="EndsAt">The optional expiration timestamp.</param>
/// <param name="RemainingComputationUnits">The remaining allowance.</param>
/// <param name="DailyComputationUnits">The daily usage counter.</param>
/// <param name="MonthlyComputationUnits">The monthly usage counter.</param>
/// <param name="ConsumedTrafficBytes">The consumed traffic counter in bytes.</param>
/// <param name="CreatedAt">The creation timestamp.</param>
/// <param name="UpdatedAt">The last update timestamp.</param>
public record SubscriptionDto(
	Guid Id,
	Guid SubscriberId,
	Guid PlanId,
	SubscriptionStatus Status,
	DateTime StartsAt,
	DateTime? EndsAt,
	decimal RemainingComputationUnits,
	decimal DailyComputationUnits,
	decimal MonthlyComputationUnits,
	long ConsumedTrafficBytes,
	DateTime CreatedAt,
	DateTime UpdatedAt);

/// <summary>
/// Carries caller-supplied relationship, lifecycle, and usage values for creating a subscription.
/// </summary>
/// <param name="SubscriberId">The existing subscriber identifier.</param>
/// <param name="PlanId">The existing plan identifier.</param>
/// <param name="Status">The initial subscription status.</param>
/// <param name="StartsAt">The activation timestamp.</param>
/// <param name="EndsAt">The optional expiration timestamp.</param>
/// <param name="RemainingComputationUnits">The initial remaining allowance.</param>
/// <param name="DailyComputationUnits">The initial daily usage counter.</param>
/// <param name="MonthlyComputationUnits">The initial monthly usage counter.</param>
/// <param name="ConsumedTrafficBytes">The initial consumed traffic counter in bytes.</param>
public record AddSubscriptionRequest(
	Guid SubscriberId,
	Guid PlanId,
	SubscriptionStatus Status,
	DateTime StartsAt,
	DateTime? EndsAt,
	decimal RemainingComputationUnits,
	decimal DailyComputationUnits,
	decimal MonthlyComputationUnits,
	long ConsumedTrafficBytes);

/// <summary>
/// Carries replacement relationship, lifecycle, and usage values for an existing subscription.
/// </summary>
/// <param name="SubscriberId">The replacement existing subscriber identifier.</param>
/// <param name="PlanId">The replacement existing plan identifier.</param>
/// <param name="Status">The replacement subscription status.</param>
/// <param name="StartsAt">The replacement activation timestamp.</param>
/// <param name="EndsAt">The replacement optional expiration timestamp.</param>
/// <param name="RemainingComputationUnits">The replacement remaining allowance.</param>
/// <param name="DailyComputationUnits">The replacement daily usage counter.</param>
/// <param name="MonthlyComputationUnits">The replacement monthly usage counter.</param>
/// <param name="ConsumedTrafficBytes">The replacement consumed traffic counter in bytes.</param>
public record UpdateSubscriptionRequest(
	Guid SubscriberId,
	Guid PlanId,
	SubscriptionStatus Status,
	DateTime StartsAt,
	DateTime? EndsAt,
	decimal RemainingComputationUnits,
	decimal DailyComputationUnits,
	decimal MonthlyComputationUnits,
	long ConsumedTrafficBytes);
