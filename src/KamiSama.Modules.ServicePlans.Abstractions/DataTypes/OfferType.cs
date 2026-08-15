namespace KamiSama.Modules.ServicePlans.DataTypes;

/// <summary>
/// Specifies how a subscription offer is presented to eligible users.
/// </summary>
public enum OfferType
{
	/// <summary>
	/// Indicates a primary offer available through the normal purchase flow.
	/// </summary>
	Primary = 0,

	/// <summary>
	/// Indicates a temporary offer associated with a campaign or promotion.
	/// </summary>
	Campaign = 1,
}
