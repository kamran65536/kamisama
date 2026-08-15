using System.ComponentModel.DataAnnotations;

namespace KamiSama.Modules.ServicePlans.Entities;

/// <summary>
/// Represents a country in which a subscription offer may be acquired.
/// </summary>
public class OfferCountry
{
	/// <summary>
	/// Gets or sets the identifier of the offer country restriction.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Gets or sets the subscription offer available in the country.
	/// </summary>
	public required virtual Offer Offer { get; set; }

	/// <summary>
	/// Gets or sets the ISO 3166-1 alpha-2 country code.
	/// </summary>
	[MaxLength(2)]
	public required string CountryCode { get; set; }

	/// <summary>
	/// Gets or sets the creation timestamp of the offer country restriction.
	/// </summary>
	public required DateTime CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the last update timestamp of the offer country restriction.
	/// </summary>
	public required DateTime UpdatedAt { get; set; }
}
