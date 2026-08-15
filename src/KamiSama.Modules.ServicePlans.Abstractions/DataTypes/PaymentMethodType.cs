namespace KamiSama.Modules.ServicePlans.DataTypes;

/// <summary>
/// Specifies a payment method category accepted by a subscription offer.
/// </summary>
public enum PaymentMethodType
{
	/// <summary>
	/// Indicates payment from an internal credit balance.
	/// </summary>
	Credit = 0,

	/// <summary>
	/// Indicates payment using a supported cryptocurrency.
	/// </summary>
	Crypto = 1,

	/// <summary>
	/// Indicates payment through a fiat payment provider.
	/// </summary>
	FiatGateway = 2,
}
