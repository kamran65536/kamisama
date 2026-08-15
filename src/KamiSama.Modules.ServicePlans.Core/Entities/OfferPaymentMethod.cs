using KamiSama.Modules.ServicePlans.DataTypes;
using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.ServicePlans.Entities;

/// <summary>
/// Represents a payment method accepted by a subscription offer.
/// </summary>
public class OfferPaymentMethod
{
	/// <summary>
	/// Gets or sets the identifier of the offer payment method.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the subscription offer that accepts the payment method.
	/// </summary>
	public required virtual Offer Offer { get; set; }

	/// <summary>
	/// Gets or sets the payment method category.
	/// </summary>
	public required PaymentMethodType Type { get; set; }

	/// <summary>
	/// Gets or sets the optional currency code required by the payment method.
	/// </summary>
	[MaxLength(20)]
	public required string? CurrencyCode { get; set; }

	/// <summary>
	/// Gets or sets the optional external payment-provider identifier.
	/// </summary>
	[MaxLength(200)]
	public required string? ExternalProviderId { get; set; }

	/// <summary>
	/// Gets or sets the creation timestamp of the offer payment method.
	/// </summary>
	public required DateTime CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the last update timestamp of the offer payment method.
	/// </summary>
	public required DateTime UpdatedAt { get; set; }
}
