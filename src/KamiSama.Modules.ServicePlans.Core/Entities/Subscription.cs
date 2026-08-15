using KamiSama.Modules.ServicePlans.DataTypes;

namespace KamiSama.Modules.ServicePlans.Entities;

/// <summary>
/// Represents a subscriber's acquired plan and remaining usage balance.
/// </summary>
public class Subscription
{
	/// <summary>
	/// Gets or sets the identifier of the subscription.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the subscriber that owns the subscription.
	/// </summary>
	public required virtual Subscriber Subscriber { get; set; }

	/// <summary>
	/// Gets or sets the plan acquired by the subscriber.
	/// </summary>
	public required virtual Plan Plan { get; set; }

	/// <summary>
	/// Gets or sets the status of the subscription.
	/// </summary>
	public required SubscriptionStatus Status { get; set; }

	/// <summary>
	/// Gets or sets the timestamp at which the subscription becomes active.
	/// </summary>
	public required DateTime StartsAt { get; set; }

	/// <summary>
	/// Gets or sets the optional timestamp at which the subscription expires.
	/// </summary>
	public required DateTime? EndsAt { get; set; }

	/// <summary>
	/// Gets or sets the computation units remaining in the subscription.
	/// </summary>
	public required decimal RemainingComputationUnits { get; set; }

	/// <summary>
	/// Gets or sets the computation units consumed during the current daily window.
	/// </summary>
	public required decimal DailyComputationUnits { get; set; }

	/// <summary>
	/// Gets or sets the computation units consumed during the current monthly window.
	/// </summary>
	public required decimal MonthlyComputationUnits { get; set; }

	/// <summary>
	/// Gets or sets the total metered traffic consumed by the subscription in bytes.
	/// </summary>
	public required long ConsumedTrafficBytes { get; set; }

	/// <summary>
	/// Gets or sets the creation timestamp of the subscription.
	/// </summary>
	public required DateTime CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the last update timestamp of the subscription.
	/// </summary>
	public required DateTime UpdatedAt { get; set; }

}
