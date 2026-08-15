namespace KamiSama.Modules.ServicePlans.DataTypes;

/// <summary>
/// Specifies the period over which a subscription allowance is measured.
/// </summary>
public enum SubscriptionPeriodType
{
	/// <summary>
	/// Indicates that the allowance resets each day.
	/// </summary>
	Daily = 0,

	/// <summary>
	/// Indicates that the allowance resets each month.
	/// </summary>
	Monthly = 1,

	/// <summary>
	/// Indicates that the allowance remains valid for the subscription lifetime without a recurring reset.
	/// </summary>
	Unlimited = 2,
}
