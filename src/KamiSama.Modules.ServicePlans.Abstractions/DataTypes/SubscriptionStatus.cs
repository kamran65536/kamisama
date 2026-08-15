namespace KamiSama.Modules.ServicePlans.DataTypes;

/// <summary>
/// Specifies the state of a subscription.
/// </summary>
public enum SubscriptionStatus
{
	/// <summary>
	/// Indicates that the subscription is available for service usage.
	/// </summary>
	Active = 0,

	/// <summary>
	/// Indicates that the subscription has been temporarily suspended.
	/// </summary>
	Suspended = 1,

	/// <summary>
	/// Indicates that the subscription has reached its configured end.
	/// </summary>
	Expired = 2,

	/// <summary>
	/// Indicates that the subscription was cancelled before its configured end.
	/// </summary>
	Cancelled = 3,
}
