using KamiSama.Modules.ServicePlans.DataTypes;
using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.ServicePlans.Entities;

/// <summary>
/// Represents a reusable subscription definition.
/// </summary>
public class Plan
{
	/// <summary>
	/// Gets or sets the identifier of the subscription plan.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the unique name of the subscription plan.
	/// </summary>
	[MaxLength(200)]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the usage units provided by the plan during its allowance period.
	/// </summary>
	public required decimal ComputationUnits { get; set; }

	/// <summary>
	/// Gets or sets the maximum usage rate allowed by the plan.
	/// </summary>
	public required int RateLimit { get; set; }

	/// <summary>
	/// Gets or sets the period over which the plan allowance is measured.
	/// </summary>
	public required SubscriptionPeriodType PeriodType { get; set; }

	/// <summary>
	/// Gets or sets the optional number of days for which an activated plan remains valid.
	/// </summary>
	public required int? DurationInDays { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the subscription plan may be offered to users.
	/// </summary>
	public required bool IsEnabled { get; set; }

	/// <summary>
	/// Gets or sets the creation timestamp of the subscription plan.
	/// </summary>
	public required DateTime CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the last update timestamp of the subscription plan.
	/// </summary>
	public required DateTime UpdatedAt { get; set; }

	/// <summary>
	/// Gets or sets the offers through which the subscription plan may be acquired.
	/// </summary>
	public virtual ICollection<Offer> Offers { get; set; } = [];

	/// <summary>
	/// Gets or sets the subscriptions created from this plan.
	/// </summary>
	public virtual ICollection<Subscription> Subscriptions { get; set; } = [];
}
