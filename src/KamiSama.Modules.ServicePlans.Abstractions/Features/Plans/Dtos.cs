namespace KamiSama.Modules.ServicePlans.Features.Plans;

/// <summary>
/// Carries paging, filtering, and ordering criteria for plan listing.
/// </summary>
/// <param name="Page">The one-based page number, or the paging convention accepted by the implementation.</param>
/// <param name="PageSize">The maximum number of plans to return.</param>
/// <param name="Name">The optional plan name filter.</param>
/// <param name="PeriodType">The optional allowance-period filter.</param>
/// <param name="IsEnabled">The optional enabled-state filter.</param>
/// <param name="OrderBy">The optional implementation-defined ordering token.</param>
public record PlanSearchModel(
	int Page,
	int PageSize,
	string? Name,
	SubscriptionPeriodType? PeriodType,
	bool? IsEnabled,
	string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	/// <summary>
	/// Gets or sets the shared search model requesting all plans without filters.
	/// </summary>
	/// <value>A mutable all-records search model; replacing it affects every caller that reads this property.</value>
	public static new PlanSearchModel All { get; set; } = new(default, default, default, default, default, default);
}

/// <summary>
/// Returns the list-facing fields of a subscription plan.
/// </summary>
/// <param name="Id">The plan identifier.</param>
/// <param name="Name">The plan name.</param>
/// <param name="ComputationUnits">The allowance supplied by the plan.</param>
/// <param name="RateLimit">The maximum usage rate.</param>
/// <param name="PeriodType">The allowance period.</param>
/// <param name="DurationInDays">The optional validity duration in days.</param>
/// <param name="IsEnabled">Whether the plan is enabled.</param>
/// <param name="CreatedAt">The creation timestamp.</param>
/// <param name="UpdatedAt">The last update timestamp.</param>
public record PlanListItemDto(
	Guid Id,
	string Name,
	decimal ComputationUnits,
	int RateLimit,
	SubscriptionPeriodType PeriodType,
	int? DurationInDays,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);

/// <summary>
/// Returns a plan across the provider-neutral feature boundary.
/// </summary>
/// <param name="Id">The plan identifier.</param>
/// <param name="Name">The plan name.</param>
/// <param name="ComputationUnits">The allowance supplied by the plan.</param>
/// <param name="RateLimit">The maximum usage rate.</param>
/// <param name="PeriodType">The allowance period.</param>
/// <param name="DurationInDays">The optional validity duration in days.</param>
/// <param name="IsEnabled">Whether the plan is enabled.</param>
/// <param name="CreatedAt">The creation timestamp.</param>
/// <param name="UpdatedAt">The last update timestamp.</param>
public record PlanDto(
	Guid Id,
	string Name,
	decimal ComputationUnits,
	int RateLimit,
	SubscriptionPeriodType PeriodType,
	int? DurationInDays,
	bool IsEnabled,
	DateTime CreatedAt,
	DateTime UpdatedAt);

/// <summary>
/// Carries caller-supplied values for creating a plan.
/// </summary>
/// <param name="Name">The plan name.</param>
/// <param name="ComputationUnits">The allowance supplied by the plan.</param>
/// <param name="RateLimit">The maximum usage rate.</param>
/// <param name="PeriodType">The allowance period.</param>
/// <param name="DurationInDays">The optional validity duration in days.</param>
/// <param name="IsEnabled">Whether the new plan is enabled.</param>
public record AddPlanRequest(
	string Name,
	decimal ComputationUnits,
	int RateLimit,
	SubscriptionPeriodType PeriodType,
	int? DurationInDays,
	bool IsEnabled);

/// <summary>
/// Carries replacement values for an existing plan.
/// </summary>
/// <param name="Name">The replacement plan name.</param>
/// <param name="ComputationUnits">The replacement allowance.</param>
/// <param name="RateLimit">The replacement maximum usage rate.</param>
/// <param name="PeriodType">The replacement allowance period.</param>
/// <param name="DurationInDays">The replacement optional validity duration in days.</param>
/// <param name="IsEnabled">Whether the plan is enabled.</param>
public record UpdatePlanRequest(
	string Name,
	decimal ComputationUnits,
	int RateLimit,
	SubscriptionPeriodType PeriodType,
	int? DurationInDays,
	bool IsEnabled);
