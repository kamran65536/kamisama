using KamiSama.Modules.ServicePlans.DataTypes;
using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.ServicePlans.Entities;

/// <summary>
/// Represents an acquisition offer for a subscription plan.
/// </summary>
public class Offer
{
	/// <summary>
	/// Gets or sets the identifier of the subscription offer.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the subscription plan made available by the offer.
	/// </summary>
	public required virtual Plan Plan { get; set; }

	/// <summary>
	/// Gets or sets the descriptive name of the subscription offer.
	/// </summary>
	[MaxLength(200)]
	public required string Name { get; set; }

	/// <summary>
	/// Gets or sets the presentation type of the subscription offer.
	/// </summary>
	public required OfferType Type { get; set; }

	/// <summary>
	/// Gets or sets the optional timestamp at which the subscription offer becomes available.
	/// </summary>
	public required DateTime? StartsAt { get; set; }

	/// <summary>
	/// Gets or sets the optional timestamp at which the subscription offer stops being available.
	/// </summary>
	public required DateTime? EndsAt { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the subscription offer may be acquired.
	/// </summary>
	public required bool IsEnabled { get; set; }

	/// <summary>
	/// Gets or sets the creation timestamp of the subscription offer.
	/// </summary>
	public required DateTime CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the last update timestamp of the subscription offer.
	/// </summary>
	public required DateTime UpdatedAt { get; set; }

	/// <summary>
	/// Gets or sets the payment-method restrictions belonging to the subscription offer.
	/// </summary>
	public virtual ICollection<OfferPaymentMethod> PaymentMethods { get; set; } = [];

	/// <summary>
	/// Gets or sets the country restrictions belonging to the subscription offer.
	/// </summary>
	public virtual ICollection<OfferCountry> Countries { get; set; } = [];
}
